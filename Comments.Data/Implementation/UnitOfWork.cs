using System;
using System.Collections.Generic;
using System.Data.Entity;
using SMOAPP.Data.Implementation;
using SMOAPP.Data.Interface;

namespace Comments.Data.Implementation
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private bool _disposed;

        public UnitOfWork()
        {
        }

        public UnitOfWork(IDictionary<Type, object> repositories, DbContext dbContext)
        {
            DbContext = dbContext;
            Repositories = repositories;
        }

        protected DbContext DbContext { get; set; }

        protected IDictionary<Type, object> Repositories { get; set; }

        public void Dispose()
        {
            /* Dispose the scoped DbContext instance: */
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public void Commit()
        {
            DbContext.SaveChanges();
        }

        public IRepository<T> RepoOf<T>() where T : class
        {
            object repoObj;
            Repositories.TryGetValue(typeof(T), out repoObj);
            if (repoObj == null && DbContext != null)
            {
                repoObj = new EfRepository<T>(DbContext);
                Repositories[typeof(T)] = repoObj;
            }
            return repoObj as IRepository<T>;
        }

        public T Repo<T>() where T : class
        {
            object repoObj;
            Repositories.TryGetValue(typeof(T), out repoObj);
            if (repoObj != null)
                return repoObj as T;
            foreach (var obj in Repositories.Values)
            {
                if (obj is T)
                {
                    Repositories.Add(typeof(T), obj);
                    return obj as T;
                }
            }
            throw new NotImplementedException("No repository found for given object type");
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    DbContext.Dispose();
                }
            }
            _disposed = true;
        }
    }
}