using Ninject;
using Sextant.Common.Commands;

namespace ShowPlanner.Ninject.Commands
{
    public class CommandRequestApi<TRequest>: ICommandRequestApi<TRequest>
    {
        private readonly IKernel _kernel;

        public ICommandDecoratorApi<TRequest, TResponse> RespondsWith<TResponse>()
        {
            var baseCommand = _kernel.Get<ICommand<TRequest, TResponse>>();
            return new CommandDecoratorApi<TRequest, TResponse>(baseCommand, _kernel);
        }

        public CommandRequestApi(IKernel kernel)
        {
            _kernel = kernel;
        }
    }
}