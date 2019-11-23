using System;
using System.Collections.Generic;
using System.Threading;
using VKAPI_WinForm.DBModel;
using xNet;
using Newtonsoft.Json;

namespace VKAPI_WinForm
{
    class VkAPI
    {        
        private const string __VKAPIURL = "https://api.vk.com/method/";   
        private string _Token; 
        private bool flagExcept;
        private string _version;        
        private string[] _strFields = { "wall", "description", "city", "country", "members_count" };
        
        private List<Group> _lstGroup;
        private List<GroupComplete> _lstGrCompl;

        public VkAPI(string AccessToken)
        {
            _Token = AccessToken;
        }                        

        public List<GroupComplete> GetInfGroup(string lastGroupId)
        {
            _lstGroup = new List<Group>();
            _lstGrCompl = new List<GroupComplete>();
            HttpRequest getInfGroup;

            flagExcept = false; 
            string Result = "";
            _version = "5.101";            
                        
            string groupIds = lastGroupId;

            foreach (string fields in _strFields)
            {
                if (groupIds == String.Empty)
                    break;

                getInfGroup = new HttpRequest();
                getInfGroup.AddUrlParam("group_ids", groupIds);
                getInfGroup.AddUrlParam("fields", fields);
                getInfGroup.AddUrlParam("access_token", _Token);
                getInfGroup.AddUrlParam("v", _version);

                try
                {
                    Result = getInfGroup.Get(__VKAPIURL + "groups.getById").ToString();
                }
                catch (Exception e)
                {
                    if (e.Source == "xNet" && e.Message.Contains("Код состояния: 414"))
                    {
                        OnDecrementCountGroupId();
                        //Частота запросов VKAPI
                        Thread.Sleep(400);
                        break;
                    }
                    else
                    {
                        flagExcept = true;
                        throw new Exception(e.Message);
                    }
                }

                if (fields == "city" || fields == "country")
                    Result = jsonTransform(Result, fields);

                var respVK = JsonConvert.DeserializeObject<ResponseVK>(Result);

                if (fields == "wall")
                {
                    groupIds = "";
                }

                foreach (Group gr in respVK.respGroup)
                {
                    if (fields == "wall")
                    {
                        if (gr.Deactivated == null && gr.IsClosed == 0 && gr.Wall != 0)
                        {
                            groupIds += gr.GroupId;
                            groupIds += ",";

                            if (_lstGroup.Count > 0)
                            {
                                foreach (Group lstGr in _lstGroup)
                                {
                                    if (gr.GroupId == lstGr.GroupId)
                                        lstGr.Wall = gr.Wall;
                                    else
                                    {
                                        _lstGroup.Add(gr);
                                        break;
                                    }
                                }
                            }
                            else
                            {
                                _lstGroup.Add(gr);
                            }
                        }
                    }

                    if (fields == "description")
                    {
                        foreach (Group lstGr in _lstGroup)
                        {
                            if (gr.GroupId == lstGr.GroupId)
                            {
                                lstGr.Description = gr.Description;
                                break;
                            }
                        }
                    }

                    if (fields == "city")
                    {
                        foreach (Group lstGr in _lstGroup)
                        {
                            if (gr.GroupId == lstGr.GroupId)
                            {
                                lstGr.CityId = gr.CityId;
                                lstGr.CityTitle = gr.CityTitle;
                                break;
                            }
                        }
                    }

                    if (fields == "country")
                    {
                        foreach (Group lstGr in _lstGroup)
                        {
                            if (gr.GroupId == lstGr.GroupId)
                            {
                                lstGr.CountryId = gr.CountryId;
                                lstGr.CountryTitle = gr.CountryTitle;
                                break;
                            }
                        }
                    }

                    if (fields == "members_count")
                    {
                        foreach (Group lstGr in _lstGroup)
                        {
                            if (gr.GroupId == lstGr.GroupId)
                            {
                                lstGr.МembersСount = gr.МembersСount;
                                break;
                            }
                        }
                    }
                }
                //Частота запросов
                Thread.Sleep(400);
            }
            
            if (!flagExcept)
            {                
                foreach (Group g in _lstGroup)
                {
                    _lstGrCompl.Add(new GroupComplete()
                    {
                        Id = g.Id,
                        GroupId = g.GroupId,
                        Name = g.Name,
                        ScreenName = g.ScreenName,
                        Type = g.Type,
                        CityId = g.CityId,
                        CityTitle = g.CityTitle,
                        CountryId = g.CountryId,
                        CountryTitle = g.CountryTitle,
                        Description = g.Description,
                        МembersСount = g.МembersСount,
                        Wall = g.Wall
                    });
                }
            }

            return _lstGrCompl;
        }

        private string jsonTransform(string res, string fields)
        {
            if (fields == "city")
            {
                res = res.Replace("city\":{\"id", "cityId");
                res = res.Replace("title", "cityTitle");
                res = res.Replace("},\"photo", ",\"photo");
            }

            if (fields == "country")
            {
                res = res.Replace("country\":{\"id", "countryId");
                res = res.Replace("title", "countryTitle");
                res = res.Replace("},\"photo", ",\"photo");
            }
                        
            return res;
        }

        public void OnDecrementCountGroupId()
        {
            if (DecrementCountGroupId != null)
                DecrementCountGroupId();
        }
        
        public event Action DecrementCountGroupId;
    }
}
