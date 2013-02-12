using System;
using System.Linq;
using Simple.Validation;

namespace Sextant.Common.Commands
{
    public class RequestValidationCommandDecorator<TRequest, TResponse> : ICommand<TRequest, TResponse>
    {
        private readonly ICommand<TRequest, TResponse> _innerCommand;
        private readonly IValidationEngine _validationEngine;

        public RequestValidationCommandDecorator(ICommand<TRequest, TResponse> innerCommand, IValidationEngine validationEngine)
        {
            _innerCommand = innerCommand;
            _validationEngine = validationEngine;

            if (!ImplementsIValidatedResponse())
            {
                const string format = "WithRequestValidation requires that {0} is required to implement to decorate {1}.";
                var msg = string.Format(format, typeof(TResponse).FullName, typeof(IValidatedResponse).FullName);
                throw new ArgumentOutOfRangeException(msg);
            }
        }

        public static bool ImplementsIValidatedResponse()
        {
            return typeof(TResponse).GetInterfaces().Contains(typeof(IValidatedResponse));
        }

        public TResponse Execute(TRequest request)
        {
            var requestValidationResults = _validationEngine.Validate(request).ToArray();
            if (requestValidationResults.HasErrors())
            {
                var preemptiveResponse = System.Activator.CreateInstance<TResponse>();
                (preemptiveResponse as IValidatedResponse).ValidationResults = requestValidationResults;
                return preemptiveResponse;
            }

            var response = _innerCommand.Execute(request);

            var validateResponse = response as IValidatedResponse;

            validateResponse.ValidationResults = validateResponse.ValidationResults == null ? 
                requestValidationResults : 
                requestValidationResults.Concat(validateResponse.ValidationResults);

            return response;
        }

        public void Dispose()
        {
        }
    }
}
