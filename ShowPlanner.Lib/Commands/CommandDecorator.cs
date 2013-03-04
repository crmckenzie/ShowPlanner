using System;

namespace ShowPlanner.Commands
{
    public abstract class CommandDecorator<TRequest, TResponse> : ICommand<TRequest, TResponse>
    {
        protected ICommand<TRequest, TResponse> InnerCommand { get; private set; }

        protected CommandDecorator(ICommand<TRequest, TResponse> innerCommand)
        {
            InnerCommand = innerCommand;
        }

        public Type GetInnermostCommandType()
        {
            var innerDecorator = InnerCommand as CommandDecorator<TRequest, TResponse>;
            if (innerDecorator != null)
            {
                return innerDecorator.GetInnermostCommandType();
            }
            return InnerCommand.GetType();
        }

        public abstract TResponse Execute(TRequest request);

        public void Dispose()
        {
            InnerCommand.Dispose();
        }
    }
}