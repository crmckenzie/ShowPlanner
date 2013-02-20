using System;

namespace ShowPlanner.Commands
{
    public interface ICommand<out T>
    {
        T Execute();
    }

    public interface ICommand<in TRequest, out TResponse> : IDisposable
    {
        TResponse Execute(TRequest request);
    }
}
