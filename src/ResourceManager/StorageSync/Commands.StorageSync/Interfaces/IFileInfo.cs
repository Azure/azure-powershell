using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.Azure.Commands.StorageSync.Evaluation
{
    public interface IFileInfo : INamedObjectInfo
    {
        long Length { get; }
        IDirectoryInfo Directory { get; }
    }
}
