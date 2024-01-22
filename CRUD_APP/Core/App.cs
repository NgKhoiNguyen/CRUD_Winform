using System;
using System.Windows.Forms ;
using Unity;
using Unity.Injection;
using framework.core_app;
using System.Linq;
using System.Reflection;
using DotNetEnv;
using framework.View.Forms;

namespace framework.core_app
{
    public class App
    {
        private static App myContainer = null;
        private IDatabase _database;
        private IUnityContainer container;
        private Form target;
        private IDbConfig dbConfig;
        private App()
        {
            container = new UnityContainer();
            container.AddExtension(new Diagnostic());
        }

        public static App instance()
        {
            if (myContainer == null)
                myContainer = new App();
            return myContainer;
        }


        public void readDbConfig()
        {
            if (dbConfig == null)
            {
                throw new ArgumentNullException(nameof(dbConfig), "Database configuration is null.");
            }
            
            if (dbConfig.DatabaseType == "SQL")
            {

                this.container.RegisterType<IDatabase, Sql>(new InjectionConstructor(new DbConfigAdapter(dbConfig)));
                this._database = container.Resolve<IDatabase>();
                _database.connect();
            }
        }


        public T resolve<T>(string name)
        {
            T resolved = default(T);

            if (container.IsRegistered<T>(name))
                resolved = container.Resolve<T>(name);

            return resolved;
        }
        public void InitAuthService<T>() where T:class,IAuthBase{
            
        }
        public T resolve<T>()
        {
            T resolved = default(T);

            if (container.IsRegistered<T>())

                resolved = container.Resolve<T>();

            return resolved;
        }


        public IAuthentication<TEntity> GetAuthService<TEntity>() where TEntity : class, IAuthBase
        {
            container.RegisterType<IRepository<TEntity>, AppRepository<TEntity>>();
            container.RegisterType<IAuthentication<TEntity>, auth_service<TEntity>>();
            container.RegisterType<IAuthentication<TEntity>, AuthProxy<TEntity>>("proxy");

            var authProxy = resolve<IAuthentication<TEntity>>("proxy");
            if (authProxy == null)
                throw new ArgumentNullException("000");
            return authProxy;
        }
        public IServiceApp<TEntity> GetServiceApp<TEntity>() where TEntity : class, BaseEntity
        {
            container.RegisterType<IRepository<TEntity>, AppRepository<TEntity>>();
            container.RegisterType<IServiceApp<TEntity>, AppService<TEntity>>();

            var appservice = resolve<IServiceApp<TEntity>>();
            if (appservice == null)
                throw new ArgumentNullException("000");
            return appservice;
        }

        public Form initAuthForm<T>() where T:class,IAuthBase
        {
            return new LoginBase<T>();
        }
        
        
        public void setTarget<Entity>() where Entity : class, BaseEntity
        {
            container.RegisterType(typeof(BaseForm<Entity>));
            target = container.Resolve<BaseForm<Entity>>();
        }

        public void setConfig(IDbConfig config)
        {
            dbConfig = config;
        }

        public Form getTarget()
        {
            return target;
        }

        
    }
}
