namespace ShowPlanner.Converters
{
    public interface IBuild<in TInput, out TOutput>
    {
        TOutput Build(TInput input);
    }
}
