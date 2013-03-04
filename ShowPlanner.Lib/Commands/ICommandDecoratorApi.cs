namespace ShowPlanner.Commands
{
    public interface ICommandDecoratorApi<in TRequest, out TResponse>
    {
        ICommandDecoratorApi<TRequest, TResponse> WithAuthorization(params string[] roles);
        ICommandDecoratorApi<TRequest, TResponse> WithPerformanceLogging();
        ICommandDecoratorApi<TRequest, TResponse> WithRequestValidation();


        ICommand<TRequest, TResponse> Build();
    }
}