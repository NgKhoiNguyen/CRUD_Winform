using System;
using System.Windows.Forms;
using framework.core_app; 
namespace framework.View.Forms
{
    public class AuthBase<IAuth> : Form where IAuth : class, IAuthBase
    {
        protected readonly Form target;
        public AuthBase()
        {
            target = App.instance().getTarget();
        }

        public virtual string  Login(IAuth auth)
        {

            throw new NotImplementedException();

        }
        public virtual void OnButtonClick(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        public virtual bool Register(IAuth auth)
        {
            throw new NotImplementedException();

        }

        public virtual bool ResetPassword(IAuth auth,string newpass)
        {
            throw new NotImplementedException();

        }
    }
}
