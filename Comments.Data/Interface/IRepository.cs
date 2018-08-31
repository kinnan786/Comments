using System;
using System.Linq;
using System.Linq.Expressions;

namespace SMOAPP.Data.Interface
{
    public interface IRepository<T> where T : class
    {
        IQueryable<T> Get(Expression<Func<T, bool>> filter = null,
            Func<IQueryable<T>,
                IOrderedQueryable<T>> orderBy = null,
            string includeProperties = "");

        IQueryable<T> GetAll();

        T GetById(int id);
        T GetById(long id);
        T GetById(Guid id);
        T GetById(string id);

        void Add(T entity, bool immediatedCommit = false);
        void Update(T entity, bool immediatedCommit = false);
        void Delete(T entity, bool immediatedCommit = false);
        void Delete(long id, bool immediatedCommit = false);
        void Delete(int id, bool immediatedCommit = false);
        void Delete(Guid id, bool immediatedCommit = false);
    }
}