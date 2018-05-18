namespace Microsoft.Azure.Commands.StorageSync.Evaluation
{
    using System.IO;

    class AfsFileInfo : IFileInfo
    {
        private FileInfo _node;

        public AfsFileInfo(FileInfo node)
        {
            this._node = node;
        }

        public string Name => _node.Name;
        public string FullName => _node.FullName;
        public long Length => _node.Length;
        public IDirectoryInfo Directory => new AfsDirectoryInfo(_node.Directory);
    }
}
