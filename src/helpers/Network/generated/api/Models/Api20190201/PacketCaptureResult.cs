namespace Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Extensions;

    /// <summary>Information about packet capture session.</summary>
    public partial class PacketCaptureResult :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPacketCaptureResult,
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPacketCaptureResultInternal
    {

        /// <summary>Number of bytes captured per packet, the remaining bytes are truncated.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public int? BytesToCapturePerPacket { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPacketCaptureParametersInternal)Property).BytesToCapturePerPacket; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPacketCaptureParametersInternal)Property).BytesToCapturePerPacket = value; }

        /// <summary>Backing field for <see cref="Etag" /> property.</summary>
        private string _etag;

        /// <summary>A unique read-only string that changes whenever the resource is updated.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public string Etag { get => this._etag; set => this._etag = value; }

        /// <summary>A list of packet capture filters.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPacketCaptureFilter[] Filter { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPacketCaptureParametersInternal)Property).Filter; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPacketCaptureParametersInternal)Property).Filter = value; }

        /// <summary>Backing field for <see cref="Id" /> property.</summary>
        private string _id;

        /// <summary>ID of the packet capture operation.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public string Id { get => this._id; }

        /// <summary>Internal Acessors for Id</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPacketCaptureResultInternal.Id { get => this._id; set { {_id = value;} } }

        /// <summary>Internal Acessors for Name</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPacketCaptureResultInternal.Name { get => this._name; set { {_name = value;} } }

        /// <summary>Internal Acessors for Property</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPacketCaptureResultProperties Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPacketCaptureResultInternal.Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.PacketCaptureResultProperties()); set { {_property = value;} } }

        /// <summary>Internal Acessors for StorageLocation</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPacketCaptureStorageLocation Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPacketCaptureResultInternal.StorageLocation { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPacketCaptureParametersInternal)Property).StorageLocation; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPacketCaptureParametersInternal)Property).StorageLocation = value; }

        /// <summary>Backing field for <see cref="Name" /> property.</summary>
        private string _name;

        /// <summary>Name of the packet capture session.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public string Name { get => this._name; }

        /// <summary>Backing field for <see cref="Property" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPacketCaptureResultProperties _property;

        /// <summary>Properties of the packet capture result.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPacketCaptureResultProperties Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.PacketCaptureResultProperties()); set => this._property = value; }

        /// <summary>The provisioning state of the packet capture session.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ProvisioningState? ProvisioningState { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPacketCaptureResultPropertiesInternal)Property).ProvisioningState; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPacketCaptureResultPropertiesInternal)Property).ProvisioningState = value; }

        /// <summary>
        /// A valid local path on the targeting VM. Must include the name of the capture file (*.cap). For linux virtual machine it
        /// must start with /var/captures. Required if no storage ID is provided, otherwise optional.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public string StorageLocationFilePath { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPacketCaptureParametersInternal)Property).StorageLocationFilePath; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPacketCaptureParametersInternal)Property).StorageLocationFilePath = value; }

        /// <summary>
        /// The ID of the storage account to save the packet capture session. Required if no local file path is provided.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public string StorageLocationStorageId { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPacketCaptureParametersInternal)Property).StorageLocationStorageId; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPacketCaptureParametersInternal)Property).StorageLocationStorageId = value; }

        /// <summary>
        /// The URI of the storage path to save the packet capture. Must be a well-formed URI describing the location to save the
        /// packet capture.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public string StorageLocationStoragePath { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPacketCaptureParametersInternal)Property).StorageLocationStoragePath; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPacketCaptureParametersInternal)Property).StorageLocationStoragePath = value; }

        /// <summary>The ID of the targeted resource, only VM is currently supported.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public string Target { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPacketCaptureParametersInternal)Property).Target; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPacketCaptureParametersInternal)Property).Target = value; }

        /// <summary>Maximum duration of the capture session in seconds.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public int? TimeLimitInSeconds { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPacketCaptureParametersInternal)Property).TimeLimitInSeconds; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPacketCaptureParametersInternal)Property).TimeLimitInSeconds = value; }

        /// <summary>Maximum size of the capture output.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public int? TotalBytesPerSession { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPacketCaptureParametersInternal)Property).TotalBytesPerSession; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPacketCaptureParametersInternal)Property).TotalBytesPerSession = value; }

        /// <summary>Creates an new <see cref="PacketCaptureResult" /> instance.</summary>
        public PacketCaptureResult()
        {

        }
    }
    /// Information about packet capture session.
    public partial interface IPacketCaptureResult :
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
        /// <summary>A unique read-only string that changes whenever the resource is updated.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"A unique read-only string that changes whenever the resource is updated.",
        SerializedName = @"etag",
        PossibleTypes = new [] { typeof(string) })]
        string Etag { get; set; }
        /// <summary>A list of packet capture filters.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"A list of packet capture filters.",
        SerializedName = @"filters",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPacketCaptureFilter) })]
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPacketCaptureFilter[] Filter { get; set; }
        /// <summary>ID of the packet capture operation.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"ID of the packet capture operation.",
        SerializedName = @"id",
        PossibleTypes = new [] { typeof(string) })]
        string Id { get;  }
        /// <summary>Name of the packet capture session.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Name of the packet capture session.",
        SerializedName = @"name",
        PossibleTypes = new [] { typeof(string) })]
        string Name { get;  }
        /// <summary>The provisioning state of the packet capture session.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The provisioning state of the packet capture session.",
        SerializedName = @"provisioningState",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ProvisioningState) })]
        Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ProvisioningState? ProvisioningState { get; set; }
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
    /// Information about packet capture session.
    internal partial interface IPacketCaptureResultInternal

    {
        /// <summary>Number of bytes captured per packet, the remaining bytes are truncated.</summary>
        int? BytesToCapturePerPacket { get; set; }
        /// <summary>A unique read-only string that changes whenever the resource is updated.</summary>
        string Etag { get; set; }
        /// <summary>A list of packet capture filters.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPacketCaptureFilter[] Filter { get; set; }
        /// <summary>ID of the packet capture operation.</summary>
        string Id { get; set; }
        /// <summary>Name of the packet capture session.</summary>
        string Name { get; set; }
        /// <summary>Properties of the packet capture result.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPacketCaptureResultProperties Property { get; set; }
        /// <summary>The provisioning state of the packet capture session.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ProvisioningState? ProvisioningState { get; set; }
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