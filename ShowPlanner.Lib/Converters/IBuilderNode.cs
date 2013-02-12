namespace Isg.Lib
{
    public interface IBuilderNode<out TOutput>
    {
        TOutput From<TInput>(TInput input);
    }
}