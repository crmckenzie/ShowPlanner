using System.Collections.Generic;

namespace ShowPlanner.Converters
{
    public interface IBuilderNode<out TOutput>
    {
        TOutput From<TInput>(TInput input);
        IEnumerable<TOutput> FromEnumerable<TInput>(IEnumerable<TInput> input);
    }
}