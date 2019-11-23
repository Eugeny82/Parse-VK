using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Newtonsoft.Json;

namespace VKAPI_WinForm.DBModel
{
    //модель "Сообщество" 
    public class Group
    {              
        public int Id { get; set; }

        //идентификатор сообщества
        [JsonProperty("id")]
        public int GroupId { get; set; }

        //название сообщества
        [JsonProperty("name")]
        public string Name { get; set; }

        //короткий адрес в адресной строке
        [JsonProperty("screen_name")]
        public string ScreenName { get; set; }
        
        //сообщество: 0 — открытое; 1 — закрытое; 2 — частное
        [JsonProperty("is_closed")]
        public int IsClosed { get; set; }        

        //тип сообщества
        [JsonProperty("type")]
        public string Type { get; set; }        

        //город     
        [JsonProperty("cityId")]
        public int CityId
        {
            get;
            set;
        }

        //город        
        [JsonProperty("cityTitle")]
        public string CityTitle
        {
            get;
            set;
        }
                
        //страна       
        [JsonProperty("countryId")]
        public int CountryId
        {
            get;
            set;
        }

        //страна       
        [JsonProperty("countryTitle")]
        public string CountryTitle
        {
            get;
            set;
        }

        //текст описания 
        [JsonProperty("description")]
        public string Description
        {
            get;
            set;
        }
 
        //Возможные значения: deleted — сообщество удалено; banned — сообщество заблокировано;
        [JsonProperty("deactivated")]
        public string Deactivated
        {
            get;
            set;
        }        
                
        //Количество участников
        [JsonProperty("members_count")]
        public int МembersСount
        {
            get;
            set;
        }
        
        //Возможные значения wall: 0 — выключена; 1 — открытая; 2 — ограниченная; 3 — закрытая.
        [JsonProperty("wall")]
        public int Wall
        {
            get;
            set;
        }
    }    
}
