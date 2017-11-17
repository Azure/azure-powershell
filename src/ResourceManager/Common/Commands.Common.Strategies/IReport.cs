namespace Microsoft.Azure.Commands.Common.Strategies
{
    public interface IReport
    {
        void Start(IResourceBaseConfig config);
        void Done(IResourceBaseConfig config);
    }
}
