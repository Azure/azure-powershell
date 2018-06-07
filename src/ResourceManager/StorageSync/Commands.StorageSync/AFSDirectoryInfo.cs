namespace Microsoft.Azure.Commands.StorageSync.Evaluation
{
    using Interfaces;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class AfsDirectoryInfo : AfsNamedObjectInfo, IDirectoryInfo
    {
        public AfsDirectoryInfo(string path) : base(path)
        {
        }

        public IEnumerable<IDirectoryInfo> EnumerateDirectories()
        {
            List<string> subDirectories = ListFiles.GetDirectories(ListFiles.EnsureUncPrefixPresent(this.FullName));
            return subDirectories.Select(subDirectoryName => new AfsDirectoryInfo(Combine(this.FullName, subDirectoryName)));
        }

        public IEnumerable<IFileInfo> EnumerateFiles()
        {
            List<Tuple<string, long>> subDirectories = ListFiles.GetFiles(ListFiles.EnsureUncPrefixPresent(this.FullName));
            return subDirectories.Select(tuple => new AfsFileInfo(Combine(this.FullName, tuple.Item1), tuple.Item2));
        }
    }
}
