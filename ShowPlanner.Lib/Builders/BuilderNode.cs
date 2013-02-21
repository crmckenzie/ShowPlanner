using System.Collections.Generic;
using System.Linq;

namespace ShowPlanner.Builders
{
    public class BuilderNode<TOutput> : IBuilderNode<TOutput>
    {
        private readonly IBuilderProvider _builderProvider;

        public TOutput From<TInput>(TInput input)
        {
            var builder = _builderProvider.Get<TInput, TOutput>();
            var result = builder.Build(input);
            return result;
        }

        public IEnumerable<TOutput> FromEnumerable<TInput>(IEnumerable<TInput> input)
        {
            var builder = _builderProvider.Get<TInput, TOutput>();
            var results = input.Select(builder.Build);
            return results;
        }

        public BuilderNode(IBuilderProvider builderProvider)
        {
            _builderProvider = builderProvider;
        }
    }
}