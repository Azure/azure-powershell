using System.IO;

namespace AFSEvaluationTool
{
    class AFSFileSystemInfo : IFileSystemInfo
    {
        private readonly FileSystemInfo info;

        public AFSFileSystemInfo(FileSystemInfo info)
        {
            this.info = info;
        }

        public string Name
        {
            get { return info.Name; }
        }

        public string FullName
        {
            get { return info.FullName; }
        }

    }
}
