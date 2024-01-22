using System;
using framework.core_app;


namespace framework.core_app
{
    public class AppService<T> : IServiceApp<T> where T :class, BaseEntity
    {
        private readonly IRepository<T> _appRepository;


        public AppService(IRepository<T> repository)
        {
            _appRepository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        public void create(T entity)
        {
            _appRepository.Save(entity);
        }

        public T[] read()
        {
            return _appRepository.FindAll();
        }

        public void delete(T entity)
        {
            _appRepository.Delete(entity);
        }

        public void update(T entity)
        {
            _appRepository.Update(entity);
        }
    }
    
}
