using Ninject;
using ShowPlanner.Commands;

namespace ShowPlanner.Ninject.Commands
{
    public class CommandRequestApi<TRequest> : ICommandRequestApi<TRequest>
    {
        private readonly IKernel _kernel;

        public ICommandDecoratorApi<TRequest, TResponse> RespondsWith<TResponse>()
        {
            return new CommandDecoratorApi<TRequest, TResponse>(_kernel);
        }

        public CommandRequestApi(IKernel kernel)
        {
            _kernel = kernel;
        }
    }
}