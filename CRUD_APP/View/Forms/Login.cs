using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using framework.core_app;
using CRUD_APP;
namespace framework.View.Forms
{
    
    public partial  class LoginBase<IAuth> : AuthBase<IAuth> where IAuth: class, IAuthBase
    {
        //service
        public LoginBase()
        {
            InitializeComponent();
        }
        public override void OnButtonClick(object sender, EventArgs e)
        {
            if (sender == buttonLogin)
            {
                IAuth auth = (IAuth)Activator.CreateInstance(typeof(IAuth));
                auth.username = this.textBoxUsername.Text;
                auth.password = this.textBoxPassword.Text;

                string authResult = Login(auth);


                if (authResult == "ok")
                {
                    target.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Invalid username or password");
                }

            }
        }

       
        private void linkLabelRegister_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            RegisterBase<IAuth> register = new RegisterBase<IAuth>();
            this.Hide();
            register.Show();
        }

        public override string Login(IAuth auth) {
            string isAuthenticated = App.instance().GetAuthService<IAuth>().Login(auth);
            return isAuthenticated;
        }
    }
}
