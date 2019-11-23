using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using VKAPI_WinForm.DBModel;
using System.Data.SqlClient;

namespace VKAPI_WinForm.DAL
{
    class DBContext
    {
        public void WriteDBSQL(List<GroupComplete> lstGroups)
        {
            using (ContextDBMySQL context = new ContextDBMySQL())
            {
                //обязательно проверяется наличие БД (если ее нет, то пересоздается)
                context.Database.EnsureCreated();

                foreach (GroupComplete gr in lstGroups)
                {
                    context.groupsVK.Add(gr);
                }

                context.SaveChanges();
            }
        }

        public int GetId()
        {
            using(ContextDBMySQL contextDB = new ContextDBMySQL())
            {
                int maxGroupId;

                try
                {
                    //получить максимальное значение GroupID из БД SQL (в базе должна быть хотя бы одна запись)
                    maxGroupId = contextDB.groupsVK.Max(g => g.GroupId);
                } 
                catch
                {
                    maxGroupId = 0;
                }

                return maxGroupId;
            }
        }
    }
}
