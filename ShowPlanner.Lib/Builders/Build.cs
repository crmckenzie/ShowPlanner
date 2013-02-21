namespace ShowPlanner.Builders
{
    public class Build : IBuild
    {
        private readonly IBuilderProvider _builderProvider;

        public IBuilderNode<TOutput> Create<TOutput>()
        {
            return new BuilderNode<TOutput>(_builderProvider);
        }

        public IBuilderNode<TOutput> CreateEnumerable<TOutput>()
        {
            return new BuilderNode<TOutput>(_builderProvider);
        }

        public Build(IBuilderProvider builderProvider)
        {
            _builderProvider = builderProvider;
        }
    }
}