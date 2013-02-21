using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShowPlanner.Builders
{
    public interface IBuilderNode<out TOutput>
    {
        TOutput From<TInput>(TInput input);
        IEnumerable<TOutput> FromEnumerable<TInput>(IEnumerable<TInput> input);
    }
}
