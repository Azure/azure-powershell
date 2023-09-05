namespace Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview
{
    using static Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Runtime.Extensions;

    /// <summary>The virtual machine resource patch definition.</summary>
    public partial class VirtualMachinesUpdateRequest :
        Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinesUpdateRequest,
        Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinesUpdateRequestInternal
    {

        /// <summary>RAM in MB for the virtual machine</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Origin(Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.PropertyOrigin.Inlined)]
        public long? HardwareProfileMemoryMb { get => ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachineUpdatePropertiesInternal)Property).HardwareProfileMemoryMb; set => ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachineUpdatePropertiesInternal)Property).HardwareProfileMemoryMb = value ?? default(long); }

        /// <summary>number of processors for the virtual machine</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Origin(Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.PropertyOrigin.Inlined)]
        public int? HardwareProfileProcessor { get => ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachineUpdatePropertiesInternal)Property).HardwareProfileProcessor; set => ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachineUpdatePropertiesInternal)Property).HardwareProfileProcessor = value ?? default(int); }

        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Origin(Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Support.VMSizeEnum? HardwareProfileVMSize { get => ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachineUpdatePropertiesInternal)Property).HardwareProfileVMSize; set => ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachineUpdatePropertiesInternal)Property).HardwareProfileVMSize = value ?? ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Support.VMSizeEnum)""); }

        /// <summary>Internal Acessors for HardwareProfile</summary>
        Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IHardwareProfileUpdate Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinesUpdateRequestInternal.HardwareProfile { get => ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachineUpdatePropertiesInternal)Property).HardwareProfile; set => ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachineUpdatePropertiesInternal)Property).HardwareProfile = value; }

        /// <summary>Internal Acessors for NetworkProfile</summary>
        Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.INetworkProfileUpdate Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinesUpdateRequestInternal.NetworkProfile { get => ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachineUpdatePropertiesInternal)Property).NetworkProfile; set => ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachineUpdatePropertiesInternal)Property).NetworkProfile = value; }

        /// <summary>Internal Acessors for Property</summary>
        Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachineUpdateProperties Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinesUpdateRequestInternal.Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.VirtualMachineUpdateProperties()); set { {_property = value;} } }

        /// <summary>Internal Acessors for StorageProfile</summary>
        Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IStorageProfileUpdate Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinesUpdateRequestInternal.StorageProfile { get => ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachineUpdatePropertiesInternal)Property).StorageProfile; set => ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachineUpdatePropertiesInternal)Property).StorageProfile = value; }

        /// <summary>
        /// NetworkInterfaces - list of network interfaces to be attached to the virtual machine
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Origin(Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.INetworkProfileUpdateNetworkInterfacesItem[] NetworkProfileNetworkInterface { get => ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachineUpdatePropertiesInternal)Property).NetworkProfileNetworkInterface; set => ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachineUpdatePropertiesInternal)Property).NetworkProfileNetworkInterface = value ?? null /* arrayOf */; }

        /// <summary>Backing field for <see cref="Property" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachineUpdateProperties _property;

        /// <summary>Defines the resource properties for the update.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Origin(Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachineUpdateProperties Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.VirtualMachineUpdateProperties()); set => this._property = value; }

        /// <summary>adds data disks to the virtual machine for the update call</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Origin(Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IStorageProfileUpdateDataDisksItem[] StorageProfileDataDisk { get => ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachineUpdatePropertiesInternal)Property).StorageProfileDataDisk; set => ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachineUpdatePropertiesInternal)Property).StorageProfileDataDisk = value ?? null /* arrayOf */; }

        /// <summary>Backing field for <see cref="Tag" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinesUpdateRequestTags _tag;

        /// <summary>Resource tags</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Origin(Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinesUpdateRequestTags Tag { get => (this._tag = this._tag ?? new Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.VirtualMachinesUpdateRequestTags()); set => this._tag = value; }

        /// <summary>Creates an new <see cref="VirtualMachinesUpdateRequest" /> instance.</summary>
        public VirtualMachinesUpdateRequest()
        {

        }
    }
    /// The virtual machine resource patch definition.
    public partial interface IVirtualMachinesUpdateRequest :
        Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Runtime.IJsonSerializable
    {
        /// <summary>RAM in MB for the virtual machine</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"RAM in MB for the virtual machine",
        SerializedName = @"memoryMB",
        PossibleTypes = new [] { typeof(long) })]
        long? HardwareProfileMemoryMb { get; set; }
        /// <summary>number of processors for the virtual machine</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"number of processors for the virtual machine",
        SerializedName = @"processors",
        PossibleTypes = new [] { typeof(int) })]
        int? HardwareProfileProcessor { get; set; }

        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"",
        SerializedName = @"vmSize",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Support.VMSizeEnum) })]
        Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Support.VMSizeEnum? HardwareProfileVMSize { get; set; }
        /// <summary>
        /// NetworkInterfaces - list of network interfaces to be attached to the virtual machine
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"NetworkInterfaces - list of network interfaces to be attached to the virtual machine",
        SerializedName = @"networkInterfaces",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.INetworkProfileUpdateNetworkInterfacesItem) })]
        Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.INetworkProfileUpdateNetworkInterfacesItem[] NetworkProfileNetworkInterface { get; set; }
        /// <summary>adds data disks to the virtual machine for the update call</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"adds data disks to the virtual machine for the update call",
        SerializedName = @"dataDisks",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IStorageProfileUpdateDataDisksItem) })]
        Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IStorageProfileUpdateDataDisksItem[] StorageProfileDataDisk { get; set; }
        /// <summary>Resource tags</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Resource tags",
        SerializedName = @"tags",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinesUpdateRequestTags) })]
        Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinesUpdateRequestTags Tag { get; set; }

    }
    /// The virtual machine resource patch definition.
    internal partial interface IVirtualMachinesUpdateRequestInternal

    {
        /// <summary>HardwareProfile - Specifies the hardware settings for the virtual machine.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IHardwareProfileUpdate HardwareProfile { get; set; }
        /// <summary>RAM in MB for the virtual machine</summary>
        long? HardwareProfileMemoryMb { get; set; }
        /// <summary>number of processors for the virtual machine</summary>
        int? HardwareProfileProcessor { get; set; }

        Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Support.VMSizeEnum? HardwareProfileVMSize { get; set; }
        /// <summary>NetworkProfile - describes the network update configuration the virtual machine</summary>
        Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.INetworkProfileUpdate NetworkProfile { get; set; }
        /// <summary>
        /// NetworkInterfaces - list of network interfaces to be attached to the virtual machine
        /// </summary>
        Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.INetworkProfileUpdateNetworkInterfacesItem[] NetworkProfileNetworkInterface { get; set; }
        /// <summary>Defines the resource properties for the update.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachineUpdateProperties Property { get; set; }

        Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IStorageProfileUpdate StorageProfile { get; set; }
        /// <summary>adds data disks to the virtual machine for the update call</summary>
        Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IStorageProfileUpdateDataDisksItem[] StorageProfileDataDisk { get; set; }
        /// <summary>Resource tags</summary>
        Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinesUpdateRequestTags Tag { get; set; }

    }
}