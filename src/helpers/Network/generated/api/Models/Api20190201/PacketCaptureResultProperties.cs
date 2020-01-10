namespace Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Extensions;

    /// <summary>Describes the properties of a packet capture session.</summary>
    public partial class PacketCaptureResultProperties :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPacketCaptureResultProperties,
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPacketCaptureResultPropertiesInternal,
        Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.IValidates
    {
        /// <summary>
        /// Backing field for Inherited model <see cref= "Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPacketCaptureParameters"
        /// />
        /// </summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPacketCaptureParameters __packetCaptureParameters = new Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.PacketCaptureParameters();

        /// <summary>Number of bytes captured per packet, the remaining bytes are truncated.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inherited)]
        public int? BytesToCapturePerPacket { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPacketCaptureParametersInternal)__packetCaptureParameters).BytesToCapturePerPacket; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPacketCaptureParametersInternal)__packetCaptureParameters).BytesToCapturePerPacket = value; }

        /// <summary>A list of packet capture filters.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inherited)]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPacketCaptureFilter[] Filter { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPacketCaptureParametersInternal)__packetCaptureParameters).Filter; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPacketCaptureParametersInternal)__packetCaptureParameters).Filter = value; }

        /// <summary>Backing field for <see cref="ProvisioningState" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ProvisioningState? _provisioningState;

        /// <summary>The provisioning state of the packet capture session.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ProvisioningState? ProvisioningState { get => this._provisioningState; set => this._provisioningState = value; }

        /// <summary>Describes the storage location for a packet capture session.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inherited)]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPacketCaptureStorageLocation StorageLocation { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPacketCaptureParametersInternal)__packetCaptureParameters).StorageLocation; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPacketCaptureParametersInternal)__packetCaptureParameters).StorageLocation = value; }

        /// <summary>
        /// A valid local path on the targeting VM. Must include the name of the capture file (*.cap). For linux virtual machine it
        /// must start with /var/captures. Required if no storage ID is provided, otherwise optional.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inherited)]
        public string StorageLocationFilePath { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPacketCaptureParametersInternal)__packetCaptureParameters).StorageLocationFilePath; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPacketCaptureParametersInternal)__packetCaptureParameters).StorageLocationFilePath = value; }

        /// <summary>
        /// The ID of the storage account to save the packet capture session. Required if no local file path is provided.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inherited)]
        public string StorageLocationStorageId { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPacketCaptureParametersInternal)__packetCaptureParameters).StorageLocationStorageId; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPacketCaptureParametersInternal)__packetCaptureParameters).StorageLocationStorageId = value; }

        /// <summary>
        /// The URI of the storage path to save the packet capture. Must be a well-formed URI describing the location to save the
        /// packet capture.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inherited)]
        public string StorageLocationStoragePath { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPacketCaptureParametersInternal)__packetCaptureParameters).StorageLocationStoragePath; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPacketCaptureParametersInternal)__packetCaptureParameters).StorageLocationStoragePath = value; }

        /// <summary>The ID of the targeted resource, only VM is currently supported.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inherited)]
        public string Target { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPacketCaptureParametersInternal)__packetCaptureParameters).Target; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPacketCaptureParametersInternal)__packetCaptureParameters).Target = value; }

        /// <summary>Maximum duration of the capture session in seconds.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inherited)]
        public int? TimeLimitInSeconds { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPacketCaptureParametersInternal)__packetCaptureParameters).TimeLimitInSeconds; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPacketCaptureParametersInternal)__packetCaptureParameters).TimeLimitInSeconds = value; }

        /// <summary>Maximum size of the capture output.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inherited)]
        public int? TotalBytesPerSession { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPacketCaptureParametersInternal)__packetCaptureParameters).TotalBytesPerSession; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPacketCaptureParametersInternal)__packetCaptureParameters).TotalBytesPerSession = value; }

        /// <summary>Creates an new <see cref="PacketCaptureResultProperties" /> instance.</summary>
        public PacketCaptureResultProperties()
        {

        }

        /// <summary>Validates that this object meets the validation criteria.</summary>
        /// <param name="eventListener">an <see cref="Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.IEventListener" /> instance that will receive validation
        /// events.</param>
        /// <returns>
        /// A < see cref = "global::System.Threading.Tasks.Task" /> that will be complete when validation is completed.
        /// </returns>
        public async global::System.Threading.Tasks.Task Validate(Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.IEventListener eventListener)
        {
            await eventListener.AssertNotNull(nameof(__packetCaptureParameters), __packetCaptureParameters);
            await eventListener.AssertObjectIsValid(nameof(__packetCaptureParameters), __packetCaptureParameters);
        }
    }
    /// Describes the properties of a packet capture session.
    public partial interface IPacketCaptureResultProperties :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPacketCaptureParameters
    {
        /// <summary>The provisioning state of the packet capture session.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The provisioning state of the packet capture session.",
        SerializedName = @"provisioningState",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ProvisioningState) })]
        Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ProvisioningState? ProvisioningState { get; set; }

    }
    /// Describes the properties of a packet capture session.
    internal partial interface IPacketCaptureResultPropertiesInternal :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPacketCaptureParametersInternal
    {
        /// <summary>The provisioning state of the packet capture session.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ProvisioningState? ProvisioningState { get; set; }

    }
}