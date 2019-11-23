using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.IO;

namespace VKAPI_WinForm
{
    public partial class AuthorizationForm : Form
    {
        string _clientId;
        string _scope;
        string[] URL;

        public AuthorizationForm(string clientId, string scope)
        {
            InitializeComponent();

            _clientId = clientId;
            _scope = scope;
        }

        private void AuthorizationForm_Load(object sender, EventArgs e)
        {
            GetToken.DocumentCompleted += GetToken_DocumentCompleted;

            string strRequest = "https://oauth.vk.com/authorize?" +
                                "client_id=" + _clientId +
                                "&display=page" +
                                "&redirect_uri=https://oauth.vk.com/blank.html" +
                                "&scope=" + _scope +
                                "&response_type=token" +
                                "&v=5.103";

            GetToken.Navigate(strRequest);           
        }

        private void GetToken_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {            
            if (GetToken.Url.ToString().IndexOf("access_token=") > 0)
            {
                char[] Symbols = { '=', '&' };
                URL = GetToken.Url.ToString().Split(Symbols);
                
                string strToken = "";
                foreach (string urll in URL)
                    strToken = strToken + urll + "\n";

                File.WriteAllText("accessToken.txt", strToken);
                File.WriteAllText("UserInf.txt", URL[1] + "\n");
                File.AppendAllText("UserInf.txt", URL[5]);                                
            }

            this.Visible = false;
        }

        public string[] GetUserToken()
        {
            return URL;
        }
    }
}
