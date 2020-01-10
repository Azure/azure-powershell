namespace Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Extensions;

    /// <summary>Describes the storage location for a packet capture session.</summary>
    public partial class PacketCaptureStorageLocation :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPacketCaptureStorageLocation,
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPacketCaptureStorageLocationInternal
    {

        /// <summary>Backing field for <see cref="FilePath" /> property.</summary>
        private string _filePath;

        /// <summary>
        /// A valid local path on the targeting VM. Must include the name of the capture file (*.cap). For linux virtual machine it
        /// must start with /var/captures. Required if no storage ID is provided, otherwise optional.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public string FilePath { get => this._filePath; set => this._filePath = value; }

        /// <summary>Backing field for <see cref="StorageId" /> property.</summary>
        private string _storageId;

        /// <summary>
        /// The ID of the storage account to save the packet capture session. Required if no local file path is provided.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public string StorageId { get => this._storageId; set => this._storageId = value; }

        /// <summary>Backing field for <see cref="StoragePath" /> property.</summary>
        private string _storagePath;

        /// <summary>
        /// The URI of the storage path to save the packet capture. Must be a well-formed URI describing the location to save the
        /// packet capture.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public string StoragePath { get => this._storagePath; set => this._storagePath = value; }

        /// <summary>Creates an new <see cref="PacketCaptureStorageLocation" /> instance.</summary>
        public PacketCaptureStorageLocation()
        {

        }
    }
    /// Describes the storage location for a packet capture session.
    public partial interface IPacketCaptureStorageLocation :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.IJsonSerializable
    {
        /// <summary>
        /// A valid local path on the targeting VM. Must include the name of the capture file (*.cap). For linux virtual machine it
        /// must start with /var/captures. Required if no storage ID is provided, otherwise optional.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"A valid local path on the targeting VM. Must include the name of the capture file (*.cap). For linux virtual machine it must start with /var/captures. Required if no storage ID is provided, otherwise optional.",
        SerializedName = @"filePath",
        PossibleTypes = new [] { typeof(string) })]
        string FilePath { get; set; }
        /// <summary>
        /// The ID of the storage account to save the packet capture session. Required if no local file path is provided.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The ID of the storage account to save the packet capture session. Required if no local file path is provided.",
        SerializedName = @"storageId",
        PossibleTypes = new [] { typeof(string) })]
        string StorageId { get; set; }
        /// <summary>
        /// The URI of the storage path to save the packet capture. Must be a well-formed URI describing the location to save the
        /// packet capture.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The URI of the storage path to save the packet capture. Must be a well-formed URI describing the location to save the packet capture.",
        SerializedName = @"storagePath",
        PossibleTypes = new [] { typeof(string) })]
        string StoragePath { get; set; }

    }
    /// Describes the storage location for a packet capture session.
    internal partial interface IPacketCaptureStorageLocationInternal

    {
        /// <summary>
        /// A valid local path on the targeting VM. Must include the name of the capture file (*.cap). For linux virtual machine it
        /// must start with /var/captures. Required if no storage ID is provided, otherwise optional.
        /// </summary>
        string FilePath { get; set; }
        /// <summary>
        /// The ID of the storage account to save the packet capture session. Required if no local file path is provided.
        /// </summary>
        string StorageId { get; set; }
        /// <summary>
        /// The URI of the storage path to save the packet capture. Must be a well-formed URI describing the location to save the
        /// packet capture.
        /// </summary>
        string StoragePath { get; set; }

    }
}