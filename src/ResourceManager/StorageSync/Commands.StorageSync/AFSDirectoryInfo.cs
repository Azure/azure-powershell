namespace Microsoft.Azure.Commands.StorageSync.Evaluation
{
    using Interfaces;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    class AfsDirectoryInfo : IDirectoryInfo
    {
        private readonly DirectoryInfo _node;

        public AfsDirectoryInfo(string path) : this(new DirectoryInfo(path))
        {
        }

        public AfsDirectoryInfo(DirectoryInfo node)
        {
            this._node = node;
        }

        public string Name => _node.Name;
        public string FullName => _node.FullName;
        public IDirectoryInfo Parent => new AfsDirectoryInfo(_node.Parent);

        public IEnumerable<IDirectoryInfo> EnumerateDirectories()
        {
            IEnumerable<DirectoryInfo> dirs = _node.EnumerateDirectories();

            return dirs.Select(dir => new AfsDirectoryInfo(dir));


        }

        public IEnumerable<IFileInfo> EnumerateFiles()
        {
            IEnumerable<FileInfo> files = _node.EnumerateFiles();

            return files.Select(file => new AfsFileInfo(file));
        }
    }
}
