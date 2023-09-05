namespace Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview
{
    using static Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Runtime.Extensions;

    /// <summary>HardwareProfile - Specifies the hardware settings for the virtual machine.</summary>
    public partial class VirtualMachinePropertiesHardwareProfile :
        Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinePropertiesHardwareProfile,
        Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinePropertiesHardwareProfileInternal
    {

        /// <summary>Backing field for <see cref="DynamicMemoryConfig" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinePropertiesHardwareProfileDynamicMemoryConfig _dynamicMemoryConfig;

        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Origin(Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinePropertiesHardwareProfileDynamicMemoryConfig DynamicMemoryConfig { get => (this._dynamicMemoryConfig = this._dynamicMemoryConfig ?? new Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.VirtualMachinePropertiesHardwareProfileDynamicMemoryConfig()); set => this._dynamicMemoryConfig = value; }

        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Origin(Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.PropertyOrigin.Inlined)]
        public long? DynamicMemoryConfigMaximumMemoryMb { get => ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinePropertiesHardwareProfileDynamicMemoryConfigInternal)DynamicMemoryConfig).MaximumMemoryMb; set => ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinePropertiesHardwareProfileDynamicMemoryConfigInternal)DynamicMemoryConfig).MaximumMemoryMb = value ?? default(long); }

        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Origin(Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.PropertyOrigin.Inlined)]
        public long? DynamicMemoryConfigMinimumMemoryMb { get => ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinePropertiesHardwareProfileDynamicMemoryConfigInternal)DynamicMemoryConfig).MinimumMemoryMb; set => ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinePropertiesHardwareProfileDynamicMemoryConfigInternal)DynamicMemoryConfig).MinimumMemoryMb = value ?? default(long); }

        /// <summary>
        /// Defines the amount of extra memory that should be reserved for a virtual machine at runtime, as a percentage of the total
        /// memory that the virtual machine is thought to need. This only applies to virtual systems with dynamic memory enabled.
        /// This property can be in the range of 5 to 2000.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Origin(Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.PropertyOrigin.Inlined)]
        public int? DynamicMemoryConfigTargetMemoryBuffer { get => ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinePropertiesHardwareProfileDynamicMemoryConfigInternal)DynamicMemoryConfig).TargetMemoryBuffer; set => ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinePropertiesHardwareProfileDynamicMemoryConfigInternal)DynamicMemoryConfig).TargetMemoryBuffer = value ?? default(int); }

        /// <summary>Backing field for <see cref="MemoryMb" /> property.</summary>
        private long? _memoryMb;

        /// <summary>RAM in MB for the virtual machine</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Origin(Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.PropertyOrigin.Owned)]
        public long? MemoryMb { get => this._memoryMb; set => this._memoryMb = value; }

        /// <summary>Internal Acessors for DynamicMemoryConfig</summary>
        Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinePropertiesHardwareProfileDynamicMemoryConfig Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinePropertiesHardwareProfileInternal.DynamicMemoryConfig { get => (this._dynamicMemoryConfig = this._dynamicMemoryConfig ?? new Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.VirtualMachinePropertiesHardwareProfileDynamicMemoryConfig()); set { {_dynamicMemoryConfig = value;} } }

        /// <summary>Backing field for <see cref="Processor" /> property.</summary>
        private int? _processor;

        /// <summary>number of processors for the virtual machine</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Origin(Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.PropertyOrigin.Owned)]
        public int? Processor { get => this._processor; set => this._processor = value; }

        /// <summary>Backing field for <see cref="VMSize" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Support.VMSizeEnum? _vMSize;

        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Origin(Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Support.VMSizeEnum? VMSize { get => this._vMSize; set => this._vMSize = value; }

        /// <summary>Creates an new <see cref="VirtualMachinePropertiesHardwareProfile" /> instance.</summary>
        public VirtualMachinePropertiesHardwareProfile()
        {

        }
    }
    /// HardwareProfile - Specifies the hardware settings for the virtual machine.
    public partial interface IVirtualMachinePropertiesHardwareProfile :
        Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Runtime.IJsonSerializable
    {
        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"",
        SerializedName = @"maximumMemoryMB",
        PossibleTypes = new [] { typeof(long) })]
        long? DynamicMemoryConfigMaximumMemoryMb { get; set; }

        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"",
        SerializedName = @"minimumMemoryMB",
        PossibleTypes = new [] { typeof(long) })]
        long? DynamicMemoryConfigMinimumMemoryMb { get; set; }
        /// <summary>
        /// Defines the amount of extra memory that should be reserved for a virtual machine at runtime, as a percentage of the total
        /// memory that the virtual machine is thought to need. This only applies to virtual systems with dynamic memory enabled.
        /// This property can be in the range of 5 to 2000.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Defines the amount of extra memory that should be reserved for a virtual machine at runtime, as a percentage of the total memory that the virtual machine is thought to need. This only applies to virtual systems with dynamic memory enabled. This property can be in the range of 5 to 2000.",
        SerializedName = @"targetMemoryBuffer",
        PossibleTypes = new [] { typeof(int) })]
        int? DynamicMemoryConfigTargetMemoryBuffer { get; set; }
        /// <summary>RAM in MB for the virtual machine</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"RAM in MB for the virtual machine",
        SerializedName = @"memoryMB",
        PossibleTypes = new [] { typeof(long) })]
        long? MemoryMb { get; set; }
        /// <summary>number of processors for the virtual machine</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"number of processors for the virtual machine",
        SerializedName = @"processors",
        PossibleTypes = new [] { typeof(int) })]
        int? Processor { get; set; }

        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"",
        SerializedName = @"vmSize",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Support.VMSizeEnum) })]
        Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Support.VMSizeEnum? VMSize { get; set; }

    }
    /// HardwareProfile - Specifies the hardware settings for the virtual machine.
    internal partial interface IVirtualMachinePropertiesHardwareProfileInternal

    {
        Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinePropertiesHardwareProfileDynamicMemoryConfig DynamicMemoryConfig { get; set; }

        long? DynamicMemoryConfigMaximumMemoryMb { get; set; }

        long? DynamicMemoryConfigMinimumMemoryMb { get; set; }
        /// <summary>
        /// Defines the amount of extra memory that should be reserved for a virtual machine at runtime, as a percentage of the total
        /// memory that the virtual machine is thought to need. This only applies to virtual systems with dynamic memory enabled.
        /// This property can be in the range of 5 to 2000.
        /// </summary>
        int? DynamicMemoryConfigTargetMemoryBuffer { get; set; }
        /// <summary>RAM in MB for the virtual machine</summary>
        long? MemoryMb { get; set; }
        /// <summary>number of processors for the virtual machine</summary>
        int? Processor { get; set; }

        Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Support.VMSizeEnum? VMSize { get; set; }

    }
}