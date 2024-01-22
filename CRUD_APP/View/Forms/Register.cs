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
namespace framework.View.Forms
{
    
    public partial class RegisterBase<IAuth> : AuthBase<IAuth> where IAuth : class, IAuthBase
    {
        public RegisterBase()
        {
            InitializeComponent();

        }
        public override bool Register(IAuth auth)
        {
            var t =App.instance().GetAuthService<IAuth>();

            
            bool isRegistered = t.Register(auth);

            return isRegistered;
        }

        public override void OnButtonClick(object sender, EventArgs e)
        {
            IAuth auth = (IAuth)Activator.CreateInstance(typeof(IAuth));
            auth.username = this.textBoxUsername.Text;
            auth.password = this.textBoxPassword.Text;
            auth.name = this.textBoxName.Text;
            auth.Id = auth_helper.GenerateShortGuid();

            bool authResult = Register(auth);


            if (!authResult)
            {
                MessageBox.Show("Invalid username or password.");

            }
            else
            {
                MessageBox.Show("Success");
                this.Hide();
                
                LoginBase<IAuth> login = new LoginBase<IAuth>();
                login.Show();
            }
        }

  
        private void linkLabelRegister_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            LoginBase<IAuth> login = new LoginBase<IAuth>();
            login.Show();
            this.Close();
        }
    }
}
