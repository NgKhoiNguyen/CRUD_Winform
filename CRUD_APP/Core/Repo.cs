using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
namespace framework.core_app
{
    public class AppRepository<TEntity> : IRepository<TEntity> where TEntity : class, BaseEntity
    {
        private readonly IDatabase _database;

        public AppRepository(IDatabase database)
        {
            _database = database ?? throw new ArgumentNullException(nameof(database));
        }

       
        public TEntity[] FindAll()
        {
            return _database.Query<TEntity>().ToArray();
        }

        public TEntity FindOneById(string id)
        {
            return _database.Get<TEntity>(id);
        }

        public bool Save(TEntity entity)
        {
            if (entity == null)
                throw new ArgumentNullException("000");

            _database.Save<TEntity>(entity);
            return true;
        }

        public bool Delete(TEntity entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            _database.remove<TEntity>(entity);

            return true; // Return true for simplicity, handle success/failure as needed
        }

        public TEntity FindByUsn(string constraints)
        {
            return _database.FindByUsn<TEntity>(constraints);
        }

        public bool Update(TEntity entity)
        {
            return _database.Update<TEntity>(entity);

        }
    }
}
