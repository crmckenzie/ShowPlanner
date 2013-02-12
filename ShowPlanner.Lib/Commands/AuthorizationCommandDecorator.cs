using System.Collections.Generic;
using System.Linq;
using System.Security.Authentication;
using System.Security.Principal;
using System.Text;

namespace Sextant.Common.Commands
{
    public class AuthorizationCommandDecorator<TRequest, TResponse> : ICommand<TRequest, TResponse>
    {
        private readonly ICommand<TRequest, TResponse> _innerCommand;
        private readonly IPrincipal _principal;
        private readonly string[] _roles;

        public AuthorizationCommandDecorator(ICommand<TRequest, TResponse> innerCommand, IPrincipal principal, params string[] roles)
        {
            _innerCommand = innerCommand;
            _principal = principal;
            _roles = roles;
        }

        public TResponse Execute(TRequest request)
        {
            var isAuthorized = _roles.Any(role => _principal.IsInRole(role));
            if (!isAuthorized)
                throw new AuthorizationException();

            var result =_innerCommand.Execute(request);
            return result;    
        }

        public void Dispose()
        {
            // do nothing
        }
    }
}
