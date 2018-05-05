namespace Microsoft.Azure.Commands.StorageSync.Evaluation
{
    public interface INamespaceEnumeratorListener
    {
        void NextFile(IFileInfo node);
        void BeginDir(IDirectoryInfo node);
        void EndDir(IDirectoryInfo node);
        void EndOfEnumeration();
    }
}