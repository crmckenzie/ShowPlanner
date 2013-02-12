namespace Isg.Lib
{
    public class BuilderNode<TOutput> : IBuilderNode<TOutput>
    {
        private readonly IBuildProvider _buildProvider;

        public TOutput From<TInput>(TInput input)
        {
            var builder = _buildProvider.Get<TInput, TOutput>();
            var result = builder.Build(input);
            return result;
        }

        public BuilderNode(IBuildProvider buildProvider)
        {
            _buildProvider = buildProvider;
        }
    }
}