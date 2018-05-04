using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AFSEvaluationTool
{
    class AFSDirectoryInfo : IDirectoryInfo
    {
        private readonly DirectoryInfo _node;

        public AFSDirectoryInfo(DirectoryInfo node)
        {
            this._node = node;
        }

        public string Name => _node.Name;
        public string FullName => _node.FullName;
        public IDirectoryInfo Parent => new AFSDirectoryInfo(_node.Parent);

        public IEnumerable<IDirectoryInfo> EnumerateDirectories()
        {
            IEnumerable<DirectoryInfo> dirs = _node.EnumerateDirectories();

            return dirs.Select(dir => new AFSDirectoryInfo(dir));


        }

        public IEnumerable<IFileInfo> EnumerateFiles()
        {
            IEnumerable<FileInfo> files = _node.EnumerateFiles();

            return files.Select(file => new AFSFileInfo(file));
        }
    }
}
