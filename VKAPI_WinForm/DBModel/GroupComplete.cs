using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Newtonsoft.Json;

namespace VKAPI_WinForm.DBModel
{
    //модель БД MySQL
    public class GroupComplete
    {
        public int Id { get; set; }

        //идентификатор
        [JsonProperty("id")]
        public int GroupId { get; set; }

        //название сообщества
        [JsonProperty("name")]
        public string Name { get; set; }

        //короткий адрес 
        [JsonProperty("screen_name")]
        public string ScreenName { get; set; }  

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
        
        //описание сообщества
        [JsonProperty("description")]
        public string Description
        {
            get;
            set;
        }

        //Количество участников в сообществе
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
