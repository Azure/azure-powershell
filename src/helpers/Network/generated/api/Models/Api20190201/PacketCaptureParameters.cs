namespace Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Extensions;

    /// <summary>Parameters that define the create packet capture operation.</summary>
    public partial class PacketCaptureParameters :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPacketCaptureParameters,
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPacketCaptureParametersInternal
    {

        /// <summary>Backing field for <see cref="BytesToCapturePerPacket" /> property.</summary>
        private int? _bytesToCapturePerPacket;

        /// <summary>Number of bytes captured per packet, the remaining bytes are truncated.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public int? BytesToCapturePerPacket { get => this._bytesToCapturePerPacket; set => this._bytesToCapturePerPacket = value; }

        /// <summary>Backing field for <see cref="Filter" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPacketCaptureFilter[] _filter;

        /// <summary>A list of packet capture filters.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPacketCaptureFilter[] Filter { get => this._filter; set => this._filter = value; }

        /// <summary>Internal Acessors for StorageLocation</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPacketCaptureStorageLocation Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPacketCaptureParametersInternal.StorageLocation { get => (this._storageLocation = this._storageLocation ?? new Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.PacketCaptureStorageLocation()); set { {_storageLocation = value;} } }

        /// <summary>Backing field for <see cref="StorageLocation" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPacketCaptureStorageLocation _storageLocation;

        /// <summary>Describes the storage location for a packet capture session.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPacketCaptureStorageLocation StorageLocation { get => (this._storageLocation = this._storageLocation ?? new Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.PacketCaptureStorageLocation()); set => this._storageLocation = value; }

        /// <summary>
        /// A valid local path on the targeting VM. Must include the name of the capture file (*.cap). For linux virtual machine it
        /// must start with /var/captures. Required if no storage ID is provided, otherwise optional.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public string StorageLocationFilePath { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPacketCaptureStorageLocationInternal)StorageLocation).FilePath; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPacketCaptureStorageLocationInternal)StorageLocation).FilePath = value; }

        /// <summary>
        /// The ID of the storage account to save the packet capture session. Required if no local file path is provided.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public string StorageLocationStorageId { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPacketCaptureStorageLocationInternal)StorageLocation).StorageId; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPacketCaptureStorageLocationInternal)StorageLocation).StorageId = value; }

        /// <summary>
        /// The URI of the storage path to save the packet capture. Must be a well-formed URI describing the location to save the
        /// packet capture.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public string StorageLocationStoragePath { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPacketCaptureStorageLocationInternal)StorageLocation).StoragePath; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPacketCaptureStorageLocationInternal)StorageLocation).StoragePath = value; }

        /// <summary>Backing field for <see cref="Target" /> property.</summary>
        private string _target;

        /// <summary>The ID of the targeted resource, only VM is currently supported.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public string Target { get => this._target; set => this._target = value; }

        /// <summary>Backing field for <see cref="TimeLimitInSeconds" /> property.</summary>
        private int? _timeLimitInSeconds;

        /// <summary>Maximum duration of the capture session in seconds.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public int? TimeLimitInSeconds { get => this._timeLimitInSeconds; set => this._timeLimitInSeconds = value; }

        /// <summary>Backing field for <see cref="TotalBytesPerSession" /> property.</summary>
        private int? _totalBytesPerSession;

        /// <summary>Maximum size of the capture output.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public int? TotalBytesPerSession { get => this._totalBytesPerSession; set => this._totalBytesPerSession = value; }

        /// <summary>Creates an new <see cref="PacketCaptureParameters" /> instance.</summary>
        public PacketCaptureParameters()
        {

        }
    }
    /// Parameters that define the create packet capture operation.
    public partial interface IPacketCaptureParameters :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.IJsonSerializable
    {
        /// <summary>Number of bytes captured per packet, the remaining bytes are truncated.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Number of bytes captured per packet, the remaining bytes are truncated.",
        SerializedName = @"bytesToCapturePerPacket",
        PossibleTypes = new [] { typeof(int) })]
        int? BytesToCapturePerPacket { get; set; }
        /// <summary>A list of packet capture filters.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"A list of packet capture filters.",
        SerializedName = @"filters",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPacketCaptureFilter) })]
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPacketCaptureFilter[] Filter { get; set; }
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
        string StorageLocationFilePath { get; set; }
        /// <summary>
        /// The ID of the storage account to save the packet capture session. Required if no local file path is provided.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The ID of the storage account to save the packet capture session. Required if no local file path is provided.",
        SerializedName = @"storageId",
        PossibleTypes = new [] { typeof(string) })]
        string StorageLocationStorageId { get; set; }
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
        string StorageLocationStoragePath { get; set; }
        /// <summary>The ID of the targeted resource, only VM is currently supported.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"The ID of the targeted resource, only VM is currently supported.",
        SerializedName = @"target",
        PossibleTypes = new [] { typeof(string) })]
        string Target { get; set; }
        /// <summary>Maximum duration of the capture session in seconds.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Maximum duration of the capture session in seconds.",
        SerializedName = @"timeLimitInSeconds",
        PossibleTypes = new [] { typeof(int) })]
        int? TimeLimitInSeconds { get; set; }
        /// <summary>Maximum size of the capture output.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Maximum size of the capture output.",
        SerializedName = @"totalBytesPerSession",
        PossibleTypes = new [] { typeof(int) })]
        int? TotalBytesPerSession { get; set; }

    }
    /// Parameters that define the create packet capture operation.
    internal partial interface IPacketCaptureParametersInternal

    {
        /// <summary>Number of bytes captured per packet, the remaining bytes are truncated.</summary>
        int? BytesToCapturePerPacket { get; set; }
        /// <summary>A list of packet capture filters.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPacketCaptureFilter[] Filter { get; set; }
        /// <summary>Describes the storage location for a packet capture session.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPacketCaptureStorageLocation StorageLocation { get; set; }
        /// <summary>
        /// A valid local path on the targeting VM. Must include the name of the capture file (*.cap). For linux virtual machine it
        /// must start with /var/captures. Required if no storage ID is provided, otherwise optional.
        /// </summary>
        string StorageLocationFilePath { get; set; }
        /// <summary>
        /// The ID of the storage account to save the packet capture session. Required if no local file path is provided.
        /// </summary>
        string StorageLocationStorageId { get; set; }
        /// <summary>
        /// The URI of the storage path to save the packet capture. Must be a well-formed URI describing the location to save the
        /// packet capture.
        /// </summary>
        string StorageLocationStoragePath { get; set; }
        /// <summary>The ID of the targeted resource, only VM is currently supported.</summary>
        string Target { get; set; }
        /// <summary>Maximum duration of the capture session in seconds.</summary>
        int? TimeLimitInSeconds { get; set; }
        /// <summary>Maximum size of the capture output.</summary>
        int? TotalBytesPerSession { get; set; }

    }
}