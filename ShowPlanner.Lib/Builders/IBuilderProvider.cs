namespace ShowPlanner.Builders
{
    public interface IBuilderProvider
    {
        IBuilder<TInput, TOutput> Get<TInput, TOutput>();
    }
}