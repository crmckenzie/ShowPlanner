namespace Isg.Lib
{
    public interface IBuilder
    {
        IBuilderNode<TOutput> Create<TOutput>();
    }
}