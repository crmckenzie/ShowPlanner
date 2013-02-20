using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using PPA.Repository;

namespace ShowPlanner.Data.Orm
{
    public class ShowPlannerRepository : IRepository
    {
        private readonly ShowPlannerDbContext _dbContext;

        public ShowPlannerRepository(ShowPlannerDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        #region IRepository Members

        public void Dispose()
        {
            _dbContext.Dispose();
        }

        public IQueryable<T> Find<T>() where T : class
        {
            return _dbContext.Set<T>();
        }

        public T Get<T>(object key) where T : class
        {
            return _dbContext.Set<T>().Find(key);
        }

        public void Save(object value)
        {
            // do nothing
        }

        public void Delete(object value)
        {
            _dbContext.Set(value.GetType()).Remove(value);
        }

        public ITransaction BeginTransaction()
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}