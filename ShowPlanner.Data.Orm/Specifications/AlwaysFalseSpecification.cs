using System;
using System.Linq.Expressions;
using PPA.Repository.Specifications;

namespace ShowPlanner.Data.Orm.Specifications
{
    public class AlwaysFalseSpecification<T> : ISpecification<T>
    {
        public Expression<Func<T, bool>> IsSatisfied()
        {
            return row => false;
        }
    }
}