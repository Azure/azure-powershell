namespace Microsoft.Azure.Commands.Common.Strategies
{
    public interface IReport
    {
        void Start(IResourceConfig config);
        void Done(IResourceConfig config);
    }
}
