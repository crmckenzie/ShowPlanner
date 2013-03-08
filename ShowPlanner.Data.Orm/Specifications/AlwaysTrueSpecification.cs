using System;
using System.Linq.Expressions;
using Isg.Specification;

namespace ShowPlanner.Data.Orm.Specifications
{
    public class AlwaysTrueSpecification<T> : ISpecification<T>
    {
        public Expression<Func<T, bool>> IsSatisfied()
        {
            return row => true;
        }
    }
}
