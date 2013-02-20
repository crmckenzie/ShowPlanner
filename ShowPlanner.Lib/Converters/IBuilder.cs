namespace ShowPlanner.Converters
{
    public interface IBuilder
    {
        IBuilderNode<TOutput> Create<TOutput>();
        IBuilderNode<TOutput> CreateEnumerable<TOutput>();
    }
}