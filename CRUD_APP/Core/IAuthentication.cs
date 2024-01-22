using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace framework.core_app
{
    public interface IAuthentication<TEntity> where TEntity:IAuthBase
    {
         string Login(TEntity auth);
         bool Register(TEntity auth);
         bool ChangePassword(TEntity auth,string newPass);
         void Logout();
         bool authorized();
         bool accessControl();
    }
}
