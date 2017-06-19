using System.Collections.Generic;
using System.Configuration;

namespace AppConfigSE
{
    public class AppConfigBAL
    {

        public List<AppConfigEntity> ListOfConnection()
        {
            var result = new List<AppConfigEntity>();

            foreach (ConnectionStringSettings v in ConfigurationManager.ConnectionStrings)
            {
                if (v.Name != "LocalSqlServer") {
                    var t = new AppConfigEntity();
                    t.Name = v.Name;
                    t.ConnectionString = v.ConnectionString;

                    result.Add(t);
                }

            }

            return result;
        }

        public string ReadTitle()
        {
            return ConfigurationManager.AppSettings["Title"];
        }

        public string ReadDefaultServer()
        {
            return ConfigurationManager.AppSettings["DefaultServer"];
        }

       
    }
}
