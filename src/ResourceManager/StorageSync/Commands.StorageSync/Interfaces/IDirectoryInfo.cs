namespace Microsoft.Azure.Commands.StorageSync.Evaluation.Interfaces
{
    using System.Collections.Generic;

    public interface IDirectoryInfo : INamedObjectInfo
    {
        IDirectoryInfo Parent { get; }

        IEnumerable<IFileInfo> EnumerateFiles();
        IEnumerable<IDirectoryInfo> EnumerateDirectories();
    }
}
