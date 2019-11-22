using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Common.Net46.Interfaces
{
    public interface IGenericRepository<T> where T : class, new()
    {
        IQueryable<T> GetAll(bool includeChilds = false);
        IQueryable<T> Where(Func<T, bool> where, bool includeChilds = false);
        T Add(T item);
        T AddAndSave(T item);
        T Update(T item);
        T UpdateAndSave(T item);
        T Remove(T item);
        T RemoveAndSave(T item);
        IEnumerable<T> Add(IEnumerable<T> items);
        IEnumerable<T> Update(IEnumerable<T> items);
        IEnumerable<T> AddAndSave(IEnumerable<T> items);
        IEnumerable<T> UpdateAndSave(IEnumerable<T> items);
        IEnumerable<T> Remove(IEnumerable<T> items);
        IEnumerable<T> RemoveAndSave(IEnumerable<T> items);
        IGenericRepository<T> IncludeReference<TProperty>(Expression<Func<T, TProperty>> path);
        IGenericRepository<T> IncludeReferences<TType>();
        bool Commit(out string message);
    }
}
