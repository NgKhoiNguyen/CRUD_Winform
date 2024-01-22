using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace framework.core_app
{
    public interface IDatabase
    {
         void connect();
         T[] Query<T>() where T : class, BaseEntity;

         bool Save<T>(T entity) where T : class, BaseEntity;

         T Get<T>(string id) where T : class, BaseEntity;

         T FindByUsn<T>(string constraints) where T : class, BaseEntity;

         bool remove<T>(T entity) where T : class, BaseEntity;

         bool Update<T>(T entity) where T : class, BaseEntity;

    }
}
