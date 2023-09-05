namespace Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview
{
    using static Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Runtime.Extensions;

    /// <summary>Defines the resource properties for the update.</summary>
    public partial class VirtualMachineUpdateProperties :
        Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachineUpdateProperties,
        Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachineUpdatePropertiesInternal
    {

        /// <summary>Backing field for <see cref="HardwareProfile" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IHardwareProfileUpdate _hardwareProfile;

        /// <summary>HardwareProfile - Specifies the hardware settings for the virtual machine.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Origin(Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IHardwareProfileUpdate HardwareProfile { get => (this._hardwareProfile = this._hardwareProfile ?? new Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.HardwareProfileUpdate()); set => this._hardwareProfile = value; }

        /// <summary>RAM in MB for the virtual machine</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Origin(Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.PropertyOrigin.Inlined)]
        public long? HardwareProfileMemoryMb { get => ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IHardwareProfileUpdateInternal)HardwareProfile).MemoryMb; set => ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IHardwareProfileUpdateInternal)HardwareProfile).MemoryMb = value ?? default(long); }

        /// <summary>number of processors for the virtual machine</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Origin(Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.PropertyOrigin.Inlined)]
        public int? HardwareProfileProcessor { get => ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IHardwareProfileUpdateInternal)HardwareProfile).Processor; set => ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IHardwareProfileUpdateInternal)HardwareProfile).Processor = value ?? default(int); }

        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Origin(Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Support.VMSizeEnum? HardwareProfileVMSize { get => ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IHardwareProfileUpdateInternal)HardwareProfile).VMSize; set => ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IHardwareProfileUpdateInternal)HardwareProfile).VMSize = value ?? ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Support.VMSizeEnum)""); }

        /// <summary>Internal Acessors for HardwareProfile</summary>
        Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IHardwareProfileUpdate Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachineUpdatePropertiesInternal.HardwareProfile { get => (this._hardwareProfile = this._hardwareProfile ?? new Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.HardwareProfileUpdate()); set { {_hardwareProfile = value;} } }

        /// <summary>Internal Acessors for NetworkProfile</summary>
        Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.INetworkProfileUpdate Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachineUpdatePropertiesInternal.NetworkProfile { get => (this._networkProfile = this._networkProfile ?? new Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.NetworkProfileUpdate()); set { {_networkProfile = value;} } }

        /// <summary>Internal Acessors for StorageProfile</summary>
        Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IStorageProfileUpdate Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachineUpdatePropertiesInternal.StorageProfile { get => (this._storageProfile = this._storageProfile ?? new Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.StorageProfileUpdate()); set { {_storageProfile = value;} } }

        /// <summary>Backing field for <see cref="NetworkProfile" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.INetworkProfileUpdate _networkProfile;

        /// <summary>NetworkProfile - describes the network update configuration the virtual machine</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Origin(Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.INetworkProfileUpdate NetworkProfile { get => (this._networkProfile = this._networkProfile ?? new Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.NetworkProfileUpdate()); set => this._networkProfile = value; }

        /// <summary>
        /// NetworkInterfaces - list of network interfaces to be attached to the virtual machine
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Origin(Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.INetworkProfileUpdateNetworkInterfacesItem[] NetworkProfileNetworkInterface { get => ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.INetworkProfileUpdateInternal)NetworkProfile).NetworkInterface; set => ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.INetworkProfileUpdateInternal)NetworkProfile).NetworkInterface = value ?? null /* arrayOf */; }

        /// <summary>Backing field for <see cref="StorageProfile" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IStorageProfileUpdate _storageProfile;

        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Origin(Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IStorageProfileUpdate StorageProfile { get => (this._storageProfile = this._storageProfile ?? new Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.StorageProfileUpdate()); set => this._storageProfile = value; }

        /// <summary>adds data disks to the virtual machine for the update call</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Origin(Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IStorageProfileUpdateDataDisksItem[] StorageProfileDataDisk { get => ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IStorageProfileUpdateInternal)StorageProfile).DataDisk; set => ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IStorageProfileUpdateInternal)StorageProfile).DataDisk = value ?? null /* arrayOf */; }

        /// <summary>Creates an new <see cref="VirtualMachineUpdateProperties" /> instance.</summary>
        public VirtualMachineUpdateProperties()
        {

        }
    }
    /// Defines the resource properties for the update.
    public partial interface IVirtualMachineUpdateProperties :
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

    }
    /// Defines the resource properties for the update.
    internal partial interface IVirtualMachineUpdatePropertiesInternal

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

        Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IStorageProfileUpdate StorageProfile { get; set; }
        /// <summary>adds data disks to the virtual machine for the update call</summary>
        Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IStorageProfileUpdateDataDisksItem[] StorageProfileDataDisk { get; set; }

    }
}