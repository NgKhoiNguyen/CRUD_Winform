using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace framework.core_app
{
    public class DbConfig:IDbConfig
    {
        public string DatabaseType { get; set; }
        public string Server { get; set; }
        public string DatabaseName { get; set; }

        //public string getStr() 
         //{
           //return "Server="+this.Server + ";" +"Database="+ DatabaseName + ";" +"TrustServerCertificate = true;"+ "Integrated Security = True;";
        //}

    }
}
