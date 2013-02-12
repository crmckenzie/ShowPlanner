using Ninject;
using Sextant.Common.Commands;

namespace ShowPlanner.Ninject.Commands
{
    public class CommandBuilder : ICommandBuilder
    {
        private readonly IKernel _kernel;

        public ICommandRequestApi<TRequest> Requires<TRequest>()
        {
            return new CommandRequestApi<TRequest>(_kernel);
        }

        public CommandBuilder(IKernel kernel)
        {
            _kernel = kernel;
        }
    }
}