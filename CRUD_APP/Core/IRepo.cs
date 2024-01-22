using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace framework.core_app
{

    // IRepository.cs
    public interface IRepository<TEntity>
    {
        TEntity[] FindAll();
        TEntity FindOneById(string id);
        TEntity FindByUsn(string constraints);
        bool Save(TEntity entity);
        bool Update(TEntity entity);

        bool Delete(TEntity entity);
    }
}
