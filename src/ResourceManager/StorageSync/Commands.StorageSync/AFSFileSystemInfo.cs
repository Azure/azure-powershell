namespace Microsoft.Azure.Commands.StorageSync.Evaluation
{
    using System.IO;

    class AfsFileSystemInfo : INamedObjectInfo
    {
        private readonly FileSystemInfo _info;

        public AfsFileSystemInfo(FileSystemInfo info)
        {
            this._info = info;
        }

        public string Name
        {
            get { return _info.Name; }
        }

        public string FullName
        {
            get { return _info.FullName; }
        }

    }
}
