namespace Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview
{
    using static Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Runtime.Extensions;

    /// <summary>Properties under the virtual hard disk resource</summary>
    public partial class VirtualHardDiskProperties :
        Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualHardDiskProperties,
        Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualHardDiskPropertiesInternal
    {

        /// <summary>Backing field for <see cref="BlockSizeByte" /> property.</summary>
        private int? _blockSizeByte;

        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Origin(Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.PropertyOrigin.Owned)]
        public int? BlockSizeByte { get => this._blockSizeByte; set => this._blockSizeByte = value; }

        /// <summary>Backing field for <see cref="ContainerId" /> property.</summary>
        private string _containerId;

        /// <summary>Storage ContainerID of the storage container to be used for VHD</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Origin(Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.PropertyOrigin.Owned)]
        public string ContainerId { get => this._containerId; set => this._containerId = value; }

        /// <summary>Backing field for <see cref="DiskFileFormat" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Support.DiskFileFormat? _diskFileFormat;

        /// <summary>The format of the actual VHD file [vhd, vhdx]</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Origin(Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Support.DiskFileFormat? DiskFileFormat { get => this._diskFileFormat; set => this._diskFileFormat = value; }

        /// <summary>Backing field for <see cref="DiskSizeGb" /> property.</summary>
        private long? _diskSizeGb;

        /// <summary>Size of the disk in GB</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Origin(Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.PropertyOrigin.Owned)]
        public long? DiskSizeGb { get => this._diskSizeGb; set => this._diskSizeGb = value; }

        /// <summary>Backing field for <see cref="Dynamic" /> property.</summary>
        private bool? _dynamic;

        /// <summary>Boolean for enabling dynamic sizing on the virtual hard disk</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Origin(Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.PropertyOrigin.Owned)]
        public bool? Dynamic { get => this._dynamic; set => this._dynamic = value; }

        /// <summary>Backing field for <see cref="HyperVGeneration" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Support.HyperVGeneration? _hyperVGeneration;

        /// <summary>The hypervisor generation of the Virtual Machine [V1, V2]</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Origin(Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Support.HyperVGeneration? HyperVGeneration { get => this._hyperVGeneration; set => this._hyperVGeneration = value; }

        /// <summary>Backing field for <see cref="LogicalSectorByte" /> property.</summary>
        private int? _logicalSectorByte;

        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Origin(Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.PropertyOrigin.Owned)]
        public int? LogicalSectorByte { get => this._logicalSectorByte; set => this._logicalSectorByte = value; }

        /// <summary>Internal Acessors for ProvisioningState</summary>
        Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Support.ProvisioningStateEnum? Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualHardDiskPropertiesInternal.ProvisioningState { get => this._provisioningState; set { {_provisioningState = value;} } }

        /// <summary>Internal Acessors for Status</summary>
        Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualHardDiskStatus Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualHardDiskPropertiesInternal.Status { get => (this._status = this._status ?? new Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.VirtualHardDiskStatus()); set { {_status = value;} } }

        /// <summary>Internal Acessors for StatusProvisioningStatus</summary>
        Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualHardDiskStatusProvisioningStatus Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualHardDiskPropertiesInternal.StatusProvisioningStatus { get => ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualHardDiskStatusInternal)Status).ProvisioningStatus; set => ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualHardDiskStatusInternal)Status).ProvisioningStatus = value; }

        /// <summary>Backing field for <see cref="PhysicalSectorByte" /> property.</summary>
        private int? _physicalSectorByte;

        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Origin(Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.PropertyOrigin.Owned)]
        public int? PhysicalSectorByte { get => this._physicalSectorByte; set => this._physicalSectorByte = value; }

        /// <summary>Backing field for <see cref="ProvisioningState" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Support.ProvisioningStateEnum? _provisioningState;

        /// <summary>Provisioning state of the virtual hard disk.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Origin(Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Support.ProvisioningStateEnum? ProvisioningState { get => this._provisioningState; }

        /// <summary>
        /// The status of the operation performed on the virtual hard disk [Succeeded, Failed, InProgress]
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Origin(Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Support.Status? ProvisioningStatus { get => ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualHardDiskStatusInternal)Status).ProvisioningStatusStatus; set => ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualHardDiskStatusInternal)Status).ProvisioningStatusStatus = value ?? ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Support.Status)""); }

        /// <summary>The ID of the operation performed on the virtual hard disk</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Origin(Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.PropertyOrigin.Inlined)]
        public string ProvisioningStatusOperationId { get => ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualHardDiskStatusInternal)Status).ProvisioningStatusOperationId; set => ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualHardDiskStatusInternal)Status).ProvisioningStatusOperationId = value ?? null; }

        /// <summary>Backing field for <see cref="Status" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualHardDiskStatus _status;

        /// <summary>The observed state of virtual hard disks</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Origin(Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualHardDiskStatus Status { get => (this._status = this._status ?? new Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.VirtualHardDiskStatus()); }

        /// <summary>VirtualHardDisk provisioning error code</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Origin(Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.PropertyOrigin.Inlined)]
        public string StatusErrorCode { get => ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualHardDiskStatusInternal)Status).ErrorCode; set => ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualHardDiskStatusInternal)Status).ErrorCode = value ?? null; }

        /// <summary>Descriptive error message</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Origin(Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.PropertyOrigin.Inlined)]
        public string StatusErrorMessage { get => ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualHardDiskStatusInternal)Status).ErrorMessage; set => ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualHardDiskStatusInternal)Status).ErrorMessage = value ?? null; }

        /// <summary>Creates an new <see cref="VirtualHardDiskProperties" /> instance.</summary>
        public VirtualHardDiskProperties()
        {

        }
    }
    /// Properties under the virtual hard disk resource
    public partial interface IVirtualHardDiskProperties :
        Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Runtime.IJsonSerializable
    {
        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"",
        SerializedName = @"blockSizeBytes",
        PossibleTypes = new [] { typeof(int) })]
        int? BlockSizeByte { get; set; }
        /// <summary>Storage ContainerID of the storage container to be used for VHD</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Storage ContainerID of the storage container to be used for VHD",
        SerializedName = @"containerId",
        PossibleTypes = new [] { typeof(string) })]
        string ContainerId { get; set; }
        /// <summary>The format of the actual VHD file [vhd, vhdx]</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The format of the actual VHD file [vhd, vhdx]",
        SerializedName = @"diskFileFormat",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Support.DiskFileFormat) })]
        Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Support.DiskFileFormat? DiskFileFormat { get; set; }
        /// <summary>Size of the disk in GB</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Size of the disk in GB",
        SerializedName = @"diskSizeGB",
        PossibleTypes = new [] { typeof(long) })]
        long? DiskSizeGb { get; set; }
        /// <summary>Boolean for enabling dynamic sizing on the virtual hard disk</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Boolean for enabling dynamic sizing on the virtual hard disk",
        SerializedName = @"dynamic",
        PossibleTypes = new [] { typeof(bool) })]
        bool? Dynamic { get; set; }
        /// <summary>The hypervisor generation of the Virtual Machine [V1, V2]</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The hypervisor generation of the Virtual Machine [V1, V2]",
        SerializedName = @"hyperVGeneration",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Support.HyperVGeneration) })]
        Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Support.HyperVGeneration? HyperVGeneration { get; set; }

        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"",
        SerializedName = @"logicalSectorBytes",
        PossibleTypes = new [] { typeof(int) })]
        int? LogicalSectorByte { get; set; }

        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"",
        SerializedName = @"physicalSectorBytes",
        PossibleTypes = new [] { typeof(int) })]
        int? PhysicalSectorByte { get; set; }
        /// <summary>Provisioning state of the virtual hard disk.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Provisioning state of the virtual hard disk.",
        SerializedName = @"provisioningState",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Support.ProvisioningStateEnum) })]
        Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Support.ProvisioningStateEnum? ProvisioningState { get;  }
        /// <summary>
        /// The status of the operation performed on the virtual hard disk [Succeeded, Failed, InProgress]
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The status of the operation performed on the virtual hard disk [Succeeded, Failed, InProgress]",
        SerializedName = @"status",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Support.Status) })]
        Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Support.Status? ProvisioningStatus { get; set; }
        /// <summary>The ID of the operation performed on the virtual hard disk</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The ID of the operation performed on the virtual hard disk",
        SerializedName = @"operationId",
        PossibleTypes = new [] { typeof(string) })]
        string ProvisioningStatusOperationId { get; set; }
        /// <summary>VirtualHardDisk provisioning error code</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"VirtualHardDisk provisioning error code",
        SerializedName = @"errorCode",
        PossibleTypes = new [] { typeof(string) })]
        string StatusErrorCode { get; set; }
        /// <summary>Descriptive error message</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Descriptive error message",
        SerializedName = @"errorMessage",
        PossibleTypes = new [] { typeof(string) })]
        string StatusErrorMessage { get; set; }

    }
    /// Properties under the virtual hard disk resource
    internal partial interface IVirtualHardDiskPropertiesInternal

    {
        int? BlockSizeByte { get; set; }
        /// <summary>Storage ContainerID of the storage container to be used for VHD</summary>
        string ContainerId { get; set; }
        /// <summary>The format of the actual VHD file [vhd, vhdx]</summary>
        Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Support.DiskFileFormat? DiskFileFormat { get; set; }
        /// <summary>Size of the disk in GB</summary>
        long? DiskSizeGb { get; set; }
        /// <summary>Boolean for enabling dynamic sizing on the virtual hard disk</summary>
        bool? Dynamic { get; set; }
        /// <summary>The hypervisor generation of the Virtual Machine [V1, V2]</summary>
        Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Support.HyperVGeneration? HyperVGeneration { get; set; }

        int? LogicalSectorByte { get; set; }

        int? PhysicalSectorByte { get; set; }
        /// <summary>Provisioning state of the virtual hard disk.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Support.ProvisioningStateEnum? ProvisioningState { get; set; }
        /// <summary>
        /// The status of the operation performed on the virtual hard disk [Succeeded, Failed, InProgress]
        /// </summary>
        Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Support.Status? ProvisioningStatus { get; set; }
        /// <summary>The ID of the operation performed on the virtual hard disk</summary>
        string ProvisioningStatusOperationId { get; set; }
        /// <summary>The observed state of virtual hard disks</summary>
        Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualHardDiskStatus Status { get; set; }
        /// <summary>VirtualHardDisk provisioning error code</summary>
        string StatusErrorCode { get; set; }
        /// <summary>Descriptive error message</summary>
        string StatusErrorMessage { get; set; }

        Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualHardDiskStatusProvisioningStatus StatusProvisioningStatus { get; set; }

    }
}