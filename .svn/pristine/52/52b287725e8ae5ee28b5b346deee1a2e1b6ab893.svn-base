using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Linq.Expressions;
using Comments.Data.Filter;
using SMOAPP.Data.Interface;

namespace SMOAPP.Data.Implementation
{
    public class EfRepository<T> : IRepository<T> where T : class
    {
        public EfRepository()
        {
        }

        public EfRepository(DbContext dbContext)
        {
            if (dbContext == null)
                throw new ArgumentNullException("dbContext");
            DbContext = dbContext;
            DbSet = dbContext.Set<T>();
        }

        protected DbContext DbContext { get; set; }
        protected DbSet<T> DbSet { get; set; }

        public virtual IQueryable<T> Get(Expression<Func<T, bool>> filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            string includeProperties = "")
        {
            IQueryable<T> query = DbSet;
            if (filter != null)
            {
                query = query.Where(filter);
            }

            foreach (var includeProperty in includeProperties.Split
                (new[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }

            return orderBy != null ? orderBy(query) : query;
        }

        public virtual IQueryable<T> GetAll()
        {
            return DbSet;
        }

        public virtual T GetById(int id)
        {
            var filter = GetFilterByKeys<T>(id);
            return GetAll().Single(filter.ToExpression<T>());
        }

        public virtual T GetById(Guid id)
        {
            var filter = GetFilterByKeys<T>(id);
            return GetAll().SingleOrDefault(filter.ToExpression<T>());
        }

        public virtual T GetById(string id)
        {
            var filter = GetFilterByKeys<T>(id);
            return GetAll().SingleOrDefault(filter.ToExpression<T>());
        }

        public virtual T GetById(long id)
        {
            var filter = GetFilterByKeys<T>(id);
            return GetAll().SingleOrDefault(filter.ToExpression<T>());
        }

        public virtual void Add(T entity, bool immediatedCommit = false)
        {
            DbEntityEntry de = DbContext.Entry(entity);
            if (de.State != EntityState.Detached)
                de.State = EntityState.Added;
            else
                DbSet.Add(entity);
            if (immediatedCommit)
                Commit();
        }

        public virtual void Update(T entity, bool immediatedCommit = false)
        {
            if (entity == null)
            {
                throw new ArgumentException("Cannot add a null entity.");
            }
            var entry = DbContext.Entry(entity);
            if (entry.State == EntityState.Detached)
            {
                var keyValues = GetKeyValue(entity);

                var attachedEntity = DbContext.Set<T>().Find(keyValues); // You need to have access to key
                if (attachedEntity != null)
                {
                    var attachedEntry = DbContext.Entry(attachedEntity);
                    attachedEntry.CurrentValues.SetValues(entity);
                }
                else
                {
                    DbSet.Attach(entity);
                    entry.State = EntityState.Modified; // This should attach entity
                }
            }
            if (immediatedCommit)
                Commit();
        }

        public virtual void Delete(T entity, bool immediatedCommit = false)
        {
            if (entity == null)
                return;
            DbEntityEntry de = DbContext.Entry(entity);
            if (de.State != EntityState.Deleted)
                de.State = EntityState.Deleted;
            else
            {
                DbSet.Attach(entity);
                DbSet.Remove(entity);
            }
            if (immediatedCommit)
                Commit();
        }

        public virtual void Delete(long id, bool immediatedCommit = false)
        {
            var entity = GetById(id);
            if (entity == null)
                return;
            Delete(entity, immediatedCommit);
        }

        public virtual void Delete(int id, bool immediatedCommit = false)
        {
            var entity = GetById(id);
            if (entity == null)
                return;
            Delete(entity, immediatedCommit);
        }

        public virtual void Delete(Guid id, bool immediatedCommit = false)
        {
            var entity = GetById(id);
            if (entity == null)
                return;
            Delete(entity, immediatedCommit);
        }

        private object[] GetKeyValue<TEntity>(TEntity entity) where TEntity : class
        {
            var keys =
                typeof(T)
                    .GetProperties()
                    .Where(p => p.GetCustomAttributes(typeof(KeyAttribute), true).Length != 0);
            var keyValues = new List<object>();
            foreach (var key in keys)
            {
                keyValues.Add(key.GetValue(entity, null));
            }
            return keyValues.ToArray();
        }

        protected SearchFilter GetFilterByKeys<T>(params object[] keyValues) where T : class
        {
            var filter = new SearchFilter();
            var keys = typeof(T)
                .GetProperties()
                .Where(p => p.GetCustomAttributes(typeof(KeyAttribute), true).Length != 0);
            var i = 0;
            var f = filter;
            foreach (var key in keys)
            {
                if (i > 0)
                {
                    f = new SearchFilter();
                    if (filter.Filters == null)
                        filter.Filters = new List<SearchFilter>();
                    filter.Filters.Add(f);
                }
                f.Field = key.Name;
                f.Operator = FilterOperations.Eq;
                f.Value = keyValues[i].ToString();
            }
            return filter;
        }

        protected virtual void Commit()
        {
            DbContext.SaveChanges();
        }
    }
}