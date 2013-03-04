using System;
using System.Collections.Generic;
using System.Security.Principal;
using Ninject;
using ShowPlanner.Commands;
using ShowPlanner.Logging;
using Simple.Validation;

namespace ShowPlanner.Ninject.Commands
{
    public class CommandDecoratorApi<TRequest, TResponse> : ICommandDecoratorApi<TRequest, TResponse>
    {
        private ICommand<TRequest, TResponse> _baseCommand;
        private readonly IKernel _kernel;

        private readonly List<Func<ICommand<TRequest, TResponse>, ICommand<TRequest, TResponse>>> _instructions =
            new List<Func<ICommand<TRequest, TResponse>, ICommand<TRequest, TResponse>>>();


        public ICommandDecoratorApi<TRequest, TResponse> WithRequestValidation()
        {
            _instructions.Add(input =>
            {
                var validationEngine = _kernel.Get<IValidationEngine>();
                var decorator = new RequestValidationCommandDecorator<TRequest, TResponse>(input, validationEngine);
                return decorator;
            });
            return this;
        }

        public ICommandDecoratorApi<TRequest, TResponse> WithPerformanceLogging()
        {
            _instructions.Add(input =>
            {
                var logProvider = _kernel.Get<ILogProvider>();
                var decorator = new PerformanceCommandDecorator<TRequest, TResponse>(input, logProvider);
                return decorator;
            });
            return this;
        }

        public ICommandDecoratorApi<TRequest, TResponse> UsesImplementation<TCommandType>() where TCommandType : ICommand<TRequest, TResponse>
        {
            _baseCommand = _kernel.Get<TCommandType>();
            return this;
        }

        public ICommandDecoratorApi<TRequest, TResponse> WithAuthorization(params string[] roles)
        {
            _instructions.Add(input =>
            {
                var principal = _kernel.Get<IPrincipal>();
                var decorator = new AuthorizationCommandDecorator<TRequest, TResponse>(input, principal, roles);
                return decorator;
            });
            return this;
        }

        public ICommand<TRequest, TResponse> Build()
        {
            if (_baseCommand == null)
                _baseCommand = _kernel.Get<ICommand<TRequest, TResponse>>();

            var result = _baseCommand;
            foreach (var decorator in _instructions)
            {
                result = decorator.Invoke(result);
            }
            return result;

        }

        public CommandDecoratorApi(IKernel kernel)
        {
            _kernel = kernel;
        }
    }
}