using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Threading;
using VKAPI_WinForm.DAL;
using VKAPI_WinForm.DBModel;

namespace VKAPI_WinForm
{
    public class GetGroups
    {
        string strId = "";
        string token;
        int _maxGroupId; 
        int _count;
        List<GroupComplete> _lstGroup;

        bool _cancel = false; 
        bool decremFlag = false;

        public GetGroups(string token, int maxGroupId, int count)
        {
            this.token = token;
            _maxGroupId = maxGroupId;   
            _count = count;              
        }

        public void Cancel()
        {
            _cancel = true;
        }

        public int GetLastGroupID()
        {
            return _maxGroupId;
        }

        public void GetInfGroup(object context)
        {
            SynchronizationContext contextSync = (SynchronizationContext)context;

            VkAPI _ApiRequest = new VkAPI(token);

            DBContext dal = new DBContext();

            _ApiRequest.DecrementCountGroupId += _ApiRequest_decrementMaxGroupId;

            while (!_cancel)
            {
                strId = "";
                                 
                contextSync.Send(OnGetGroupsProcessing, "Getting groups ID starting with " + _maxGroupId);

                for (int i = 1; i <= _count; i++)
                {
                    _maxGroupId += 1;
                    strId += _maxGroupId;

                    if (i < _count)
                        strId += ",";
                }

                try
                {
                    _lstGroup = _ApiRequest.GetInfGroup(strId);
                    dal.WriteDBSQL(_lstGroup);                    
                }
                catch (Exception e)
                {
                    contextSync.Send(OnGetGroupsException, e);
                    contextSync.Send(OnGetGroupsProcessing, "Error");                    
                    break;
                }

                contextSync.Send(OnGetLastGroupId, _maxGroupId);
                contextSync.Send(OnGetGroupsProcessing, "Groups ID saved up to " + _maxGroupId);

                if (decremFlag)
                {
                    contextSync.Send(OnDecrementCountGroupId, _count);
                    decremFlag = false;
                }                
            }
            
            contextSync.Send(OnStopGetGroupId, true);     
        }

        private void _ApiRequest_decrementMaxGroupId()
        {
            _count -= 1;
            decremFlag = true;
        }

        public void OnGetGroupsException(object ex)
        {
            if (GetGroupsException != null)
                GetGroupsException((Exception)ex);
        }

        public void OnGetGroupsProcessing(object infoProc)
        {
            if (GetGroupsProcessing != null)
                GetGroupsProcessing((string)infoProc);
        }

        public void OnGetLastGroupId(object lastGroupId)
        {
            if (GetLastGroupId != null)
                GetLastGroupId((int)lastGroupId);
        }

        public void OnStopGetGroupId(object cancelled)
        {
            if (StopGetGroupId != null)
                StopGetGroupId((bool)cancelled);
        }

        public void OnDecrementCountGroupId(object obj)
        {
            if (DecrementCountGroupId != null)
                DecrementCountGroupId((int)_count);
        }
        
        
        public event Action<string> GetGroupsProcessing;
        public event Action<Exception> GetGroupsException;
        public event Action<int> GetLastGroupId;
        public event Action<bool> StopGetGroupId;
        public event Action<int> DecrementCountGroupId;
    }
}
