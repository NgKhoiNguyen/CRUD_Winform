using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace framework.core_app
{
    public interface IAuthBase:BaseEntity
    {
         string Id { set; get; }
         string username { set; get; }
         string password { set; get; }
        string name { set; get; }
    }
}
