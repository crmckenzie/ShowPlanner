namespace ShowPlanner.Commands
{
    public interface ICommandRequestApi<in TRequest>
    {
        ICommandDecoratorApi<TRequest, TResponse> RespondsWith<TResponse>();
    }
}