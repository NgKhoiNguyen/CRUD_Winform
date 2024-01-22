using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace framework.core_app
{
    public class auth_service<TEntity>:IAuthentication<TEntity> where TEntity : class, IAuthBase
    {
        private readonly IRepository<TEntity> _repository;
        public auth_service(IRepository<TEntity> repository)
        {
            _repository = repository;
        }

        public string Login(TEntity auth)
        {
            string res = "fail";
            TEntity find = _repository.FindByUsn(auth.username);
            if (find == null) return res;
           
            if (find.password == auth.password)
            {
                //res = auth_helper.generateToken();
                res = "ok";
            }
            return res;
        }
        public bool Register(TEntity auth)
        {
            TEntity find = _repository.FindByUsn(auth.username);
            if (find != null)
            {
                return false;
            }
            _repository.Save(auth);
            return true;
        }
        public bool ChangePassword(TEntity auth, string newPass)
        {
            TEntity find = _repository.FindByUsn(auth.username);
            if (find == null) return false;

            if (find.password == auth.password)
            {
                find.password = newPass;
                _repository.Save(find);
                return true;
            }
            return false;
        }
        public void Logout()
        {

        }
        public bool authorized()
        {
            return true;
        }
        public bool accessControl()
        {
            return true;
        }
    }
}
