using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Newtonsoft.Json;

namespace VKAPI_WinForm.DBModel
{
    public class ResponseVK
    {
        [JsonProperty("response")]
        public List<Group> respGroup { get; set; }

    }
}
