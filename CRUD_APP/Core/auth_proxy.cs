using System;

namespace framework.core_app
{
    public class AuthProxy<TEntity> : IAuthentication<TEntity> where TEntity:class,IAuthBase
    {
        private readonly IAuthentication<TEntity> _authService;

        public AuthProxy(IAuthentication<TEntity> authService)
        {
            _authService = authService ?? throw new ArgumentNullException(nameof(authService));
        }

        public string Login(TEntity auth)

        {
            //pre-proccess
            return _authService.Login(auth);
        }

        public bool Register(TEntity auth)
        {
            return _authService.Register(auth);
        }

        public bool ChangePassword(TEntity auth,string newPass)
        {
            return _authService.ChangePassword(auth,newPass);
        }

        public void Logout()
        {
            _authService.Logout();
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
