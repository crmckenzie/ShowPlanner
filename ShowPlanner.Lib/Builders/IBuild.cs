using System;
using System.Text;
using System.Threading.Tasks;

namespace ShowPlanner.Builders
{
    public interface IBuild
    {
        IBuilderNode<TOutput> Create<TOutput>();
        IBuilderNode<TOutput> CreateEnumerable<TOutput>();
    }
}
