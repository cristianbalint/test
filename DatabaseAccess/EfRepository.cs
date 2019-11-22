using Common.Net46.DataAccess;
using Common.Net46.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;

namespace DatabaseAccess
{
    public class EfRepository<T> : IGenericRepository<T>
        //where C : DbContext, new()
         where T : class, new() // entity passed to repository must be derived from BaseEntity
    {
        public AppDbContext context; // context need to be derived from DbContext
        public EfRepository(AppDbContext _context)
        {
            context = _context;
            foreach (var entity in context.ChangeTracker.Entries().Where(e => e.State == EntityState.Added || e.State == EntityState.Modified || e.State == EntityState.Deleted))
            {
                context.Entry(entity.Entity).State = EntityState.Detached;
            }
        }

        public IQueryable<T> GetAll(bool withChilds)
        {
            // context.DetachAllEntities();
            return context.Set<T>().AsNoTracking().AsQueryable();
        }

        public IQueryable<T> Where(Func<T, bool> where, bool withChilds)
        {
            // context.DetachAllEntities();
            return context.Set<T>().AsNoTracking<T>().Where(where).AsQueryable();
        }

        public T Add(T item)
        {
            T result = new T();
            if (item != null)
            {
                context.Entry(item).State = EntityState.Added;
                result = item;
            }
            return result;
        }

        public T Update(T item)
        {
            // context.DetachAllEntities();
            T result = new T();
            if (item != null)
            {
                context.Entry(item).State = EntityState.Modified;
                result = item;
            }
            return result;
        }

        public T Remove(T item)
        {
            T result = new T();
            if (item != null)
            {
                context.Entry(item).State = EntityState.Deleted;
                result = item;
            }
            return result;
        }

        public IEnumerable<T> Add(IEnumerable<T> items)
        {
            List<T> result = new List<T>();
            if (items != null)
            {
                foreach (var item in items)
                {
                    context.Entry(item).State = EntityState.Added;
                    result.Add(item);
                }
            }
            return result;
        }

        public IEnumerable<T> Update(IEnumerable<T> items)
        {
            // context.DetachAllEntities();
            List<T> result = new List<T>();
            if (items != null)
            {
                foreach (var item in items)
                {
                    context.Entry(item).State = EntityState.Modified;
                    result.Add(item);
                }
            }
            return result;
        }

        public IEnumerable<T> Remove(IEnumerable<T> items)
        {
            List<T> result = new List<T>();
            if (items != null)
            {
                foreach (var item in items)
                {
                    context.Entry(item).State = EntityState.Deleted;
                    result.Add(item);
                }
            }
            return result;
        }

        public bool Commit(out string message)
        {
            try
            {
                context.SaveChanges();
                message = "";
                return true;
            }
            catch (Exception ex)
            {
                message = ex.Message;
                return false;
            }
        }

        public T AddAndSave(T item)
        {
            T result = Add(item);
            context.SaveChanges();
            context.Entry<T>(item).State = EntityState.Detached;
            return result;
        }

        public T UpdateAndSave(T item)
        {

            T result = Update(item);
            context.SaveChanges();
            context.Entry<T>(item).State = EntityState.Detached;
            return result;
        }

        public IEnumerable<T> AddAndSave(IEnumerable<T> items)
        {
            IEnumerable<T> result = Add(items);
            context.SaveChanges();
            foreach (var item in items)
            {
                context.Entry<T>(item).State = EntityState.Detached;
            }
            return result;
        }

        public IEnumerable<T> UpdateAndSave(IEnumerable<T> items)
        {
            IEnumerable<T> result = Update(items);
            context.SaveChanges();
            foreach (var item in items)
            {
                context.Entry<T>(item).State = EntityState.Detached;
            }
            return result;
        }

        public T RemoveAndSave(T item)
        {
            T result = Remove(item);
            context.SaveChanges();
            context.Entry<T>(item).State = EntityState.Detached;
            return result;
        }

        public IEnumerable<T> RemoveAndSave(IEnumerable<T> items)
        {
            IEnumerable<T> result = Remove(items);
            context.SaveChanges();
            foreach (var item in items)
            {
                context.Entry<T>(item).State = EntityState.Detached;
            }
            return result;
        }

        public IGenericRepository<T> IncludeReference<TProperty>(Expression<Func<T, TProperty>> path)
        {
            context.Set<T>().AsNoTracking<T>().Include(path);
            return this;
        }

        public IGenericRepository<T> IncludeReferences<TType>()
        {
            return this;
        }
    }
}
