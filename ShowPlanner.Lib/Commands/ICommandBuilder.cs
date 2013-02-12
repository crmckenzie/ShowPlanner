namespace Sextant.Common.Commands
{
    public interface ICommandBuilder
    {
        ICommandRequestApi<TRequest> Requires<TRequest>();
    }
}