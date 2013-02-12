namespace Sextant.Common.Commands
{
    public interface ICommandRequestApi<in TRequest>
    {
        ICommandDecoratorApi<TRequest, TResponse> RespondsWith<TResponse>();
    }
}