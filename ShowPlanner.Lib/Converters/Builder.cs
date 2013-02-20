namespace ShowPlanner.Converters
{
    public class Builder : IBuilder
    {
        private readonly IBuildProvider _buildProvider;

        public IBuilderNode<TOutput> Create<TOutput>()
        {
            return new BuilderNode<TOutput>(_buildProvider);
        }

        public IBuilderNode<TOutput> CreateEnumerable<TOutput>()
        {
            return new BuilderNode<TOutput>(_buildProvider);
        }

        public Builder(IBuildProvider buildProvider)
        {
            _buildProvider = buildProvider;
        }
    }
}