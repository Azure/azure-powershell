namespace Microsoft.Azure.Commands.StorageSync.Evaluation
{
    using Interfaces;

    class AfsFileInfo : AfsNamedObjectInfo, IFileInfo
    {
        public AfsFileInfo(string name, long length) : base(name)
        {
            this.Length = length;
        }

        public long Length { get; private set; }
    }
}
