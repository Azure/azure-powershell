using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.Azure.Commands.StorageSync.Evaluation
{
    class AFSFileInfo : IFileInfo
    {
        private FileInfo node;

        public AFSFileInfo(FileInfo node)
        {
            this.node = node;
        }

        public string Name => node.Name;
        public string FullName => node.FullName;
        public long Length => node.Length;
        public IDirectoryInfo Directory => new AFSDirectoryInfo(node.Directory);


    }
}
