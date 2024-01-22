using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace framework.core_app
{
    public interface IServiceApp<TEntity> where TEntity : BaseEntity
    {
          void create(TEntity entity);
         TEntity[] read();
         void delete(TEntity entity);
         void update(TEntity entity);
       
    }
}
