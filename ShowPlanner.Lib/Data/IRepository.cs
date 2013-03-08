using System;
using System.Linq;

namespace ShowPlanner.Data
{
    public interface IRepository : IDisposable
    {
        IQueryable<T> Find<T>() where T : class;
        T Get<T>(object key) where T : class;
        void Save(object value);
        void Delete(object value);
        void Commit();
    }
}