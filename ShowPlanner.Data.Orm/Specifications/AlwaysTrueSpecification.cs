using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using PPA.Repository.Specifications;

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
