using System.Collections.Generic;
using System.Linq;

namespace ShowPlanner.Converters
{
    public class BuilderNode<TOutput> : IBuilderNode<TOutput>
    {
        private readonly IBuildProvider _buildProvider;

        public TOutput From<TInput>(TInput input)
        {
            var builder = _buildProvider.Get<TInput, TOutput>();
            var result = builder.Build(input);
            return result;
        }

        public IEnumerable<TOutput> FromEnumerable<TInput>(IEnumerable<TInput> input)
        {
            var builder = _buildProvider.Get<TInput, TOutput>();
            var results = input.Select(builder.Build);
            return results;
        }

        public BuilderNode(IBuildProvider buildProvider)
        {
            _buildProvider = buildProvider;
        }
    }
}