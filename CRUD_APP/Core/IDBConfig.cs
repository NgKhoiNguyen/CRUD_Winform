using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace framework.core_app
{
    public interface IDbConfig
    {
         string  DatabaseType { get; set; }
         string Server { get; set; }
         string DatabaseName { get; set; }

    }
}
