namespace Isg.Lib
{
    /// <summary>
    /// Implement using your favorite Dependency Injection framework.
    /// </summary>
    public interface IBuildProvider
    {
        IBuild<TInput, TOutput> Get<TInput, TOutput>();
    }
}