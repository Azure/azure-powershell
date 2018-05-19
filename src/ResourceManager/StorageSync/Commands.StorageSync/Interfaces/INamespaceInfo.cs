using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.Azure.Commands.StorageSync.Evaluation
{
    public interface INamespaceInfo
    {
        string Path { get; }

        long NumberOfFiles { get; }

        long NumberOfDirectories { get; }

        long TotalFileSizeInBytes { get; }

        bool IsComplete { get; }
    }
}
