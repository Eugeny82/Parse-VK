using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VKAPI_WinForm.Settings
{
    public class PropFields
    {
        public String XMLFileName = Environment.CurrentDirectory + "\\settings.xml";
        public String clientId = @"";
        public bool scopeWall = false;
        public bool scopeGroups = false;
        public DateTime tokenExpire = DateTime.Now;
        public String Token = @"";
        public String userId = @"";
        public int lastGroupId = 0;
    }
}
