namespace ShowPlanner.Commands
{
    public interface ICommandBuilder
    {
        ICommandRequestApi<TRequest> Requires<TRequest>();
    }
}