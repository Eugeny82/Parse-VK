using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;

using VKAPI_WinForm.DAL;
using VKAPI_WinForm.DBModel;
using VKAPI_WinForm.Settings;
using System.IO;

namespace VKAPI_WinForm
{
    public partial class MainForm : Form
    {
        SynchronizationContext _contextSync;
        Prop prop;
        Thread thread;
        Log logParsGrp;

        string[] strToken;

        private string _Token;  
        private string _UserId;  
        private int _lastGroupId; 
        private DateTime _DateTimeToken; 
        private bool _cancelledGetGroups = true;
        GetGroups getGroups;

        public MainForm()
        {
            InitializeComponent();

            prop = new Prop(); 
            logParsGrp = new Log(); 
            btnStopGetGroups.Enabled = false;            
        }

        private void MainForm_Load(object sender, EventArgs e)
        {            
            _contextSync = SynchronizationContext.Current;
            LoadSettings();            
        }               

        private void LoadSettings()
        {
            DBContext dal = new DBContext();

            if (prop.ReadXml())
            {
                TxBxClientId.Text = prop.Fields.clientId;
                _Token = prop.Fields.Token;
                _UserId = prop.Fields.userId;

                lblTokenExpire.Text = prop.Fields.tokenExpire.ToString();
                _DateTimeToken = prop.Fields.tokenExpire;

                _lastGroupId = prop.Fields.lastGroupId;                
                lblLastGroupId.Text = prop.Fields.lastGroupId.ToString();
            }
            else
            {
                MessageBox.Show("No initial configuration data available.");
            }
        }

        private void SaveSettings()
        {
            prop.Fields.clientId = TxBxClientId.Text;
            prop.Fields.Token = _Token;
            prop.Fields.tokenExpire = _DateTimeToken;
            prop.Fields.userId = _UserId;
            prop.Fields.lastGroupId = _lastGroupId;

            prop.WriteXml();
        }
        
        private void Button_GetToken_Click(object sender, EventArgs e)
        {
            string scopeText = "groups";

            AuthorizationForm GetToken = new AuthorizationForm(TxBxClientId.Text, scopeText);

            try
            {
                GetToken.ShowDialog();
                strToken = GetToken.GetUserToken();

                //получить параметры
                _Token = strToken[1];
                _DateTimeToken = DateTime.Now.AddSeconds(double.Parse(strToken[3]));
                _UserId = strToken[5];
            }
            catch (Exception)
            {
                MessageBox.Show("Ошибка получения входных параметров");
            }        

            SaveSettings();
            LoadSettings();
        }
        private void Btn_GetInf_Click(object sender, EventArgs e)
        {
            List<string> lstText = new List<string>();
            lstText.Add(TxBxClientId.Text);
            lstText.Add(txBxCountOfRec.Text);

            GetInfGroup();

            btn_GetInfGroup.Enabled = false;
            btnStopGetGroups.Enabled = true;
        }

        private void GetInfGroup()
        {
            getGroups = new GetGroups(_Token, _lastGroupId, int.Parse(txBxCountOfRec.Text));

            getGroups.GetGroupsException += getGroups_Exception;
            getGroups.GetGroupsProcessing += getGroups_Processing;
            getGroups.GetLastGroupId += getGroups_LastGroupId;
            getGroups.StopGetGroupId += getGroups_Stop;
            getGroups.DecrementCountGroupId += getGroups_DecrCountGroupId;

            thread = new Thread(getGroups.GetInfGroup);
            thread.Start(_contextSync);

            _cancelledGetGroups = false;
        }        

        private void BtnStopGetGroups_Click(object sender, EventArgs e)
        {
            getGroups.Cancel();
            _lastGroupId = getGroups.GetLastGroupID();
            SaveSettings();

            btnStopGetGroups.Enabled = false; 
        }

        private void getGroups_Processing(string infoProc)
        {
            lblProcessing.Text = infoProc;
            //записать в log
            logParsGrp.LogWrite(infoProc + "\n");
        }

        private void getGroups_Exception(Exception ex)
        {
            btnStopGetGroups.Enabled = false;            
            //записать в log
            logParsGrp.LogWrite(ex.Message + "\n");

            MessageBox.Show(ex.Message);
        }

        private void getGroups_LastGroupId(int lastGroupId)
        {
            _lastGroupId = lastGroupId;
            lblLastGroupId.Text = lastGroupId.ToString();
        }
                
        private void getGroups_Stop(bool cancelled)
        {
            _cancelledGetGroups = cancelled;
            btn_GetInfGroup.Enabled = true;
        }

        private void getGroups_DecrCountGroupId(int cnt)
        {
            txBxCountOfRec.Text = cnt.ToString();
        }
    }
}
