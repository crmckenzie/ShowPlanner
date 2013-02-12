using System.Security.Principal;
using Ninject;
using Sextant.Common.Commands;
using Simple.Validation;

namespace ShowPlanner.Ninject.Commands
{
    public class CommandDecoratorApi<TRequest, TResponse> : ICommandDecoratorApi<TRequest, TResponse>
    {
        private readonly ICommand<TRequest, TResponse> _baseCommand;
        private readonly IKernel _kernel;
        private ICommand<TRequest, TResponse> _workingCommand;

        public ICommandDecoratorApi<TRequest, TResponse> WithRequestValidation()
        {
            var validationEngine = _kernel.Get<IValidationEngine>();
            var decorator = new RequestValidationCommandDecorator<TRequest, TResponse>(_baseCommand, validationEngine);
            _workingCommand = decorator;
            return this;
        }

        public ICommandDecoratorApi<TRequest, TResponse> WithAuthorization(params string[] roles)
        {
            var principal = _kernel.Get<IPrincipal>();
            var decorator = new AuthorizationCommandDecorator<TRequest, TResponse>(_workingCommand, principal, roles);
            _workingCommand = decorator;
            return this;
        } 

        public ICommand<TRequest, TResponse> Build()
        {
            return _workingCommand;
        }

        public CommandDecoratorApi(ICommand<TRequest, TResponse> baseCommand, IKernel kernel)
        {
            _baseCommand = baseCommand;
            _kernel = kernel;
            _workingCommand = baseCommand;
        }
    }
}