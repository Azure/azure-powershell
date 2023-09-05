namespace Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview
{
    using static Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Runtime.Extensions;

    public partial class VirtualMachinePropertiesHardwareProfileDynamicMemoryConfig :
        Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinePropertiesHardwareProfileDynamicMemoryConfig,
        Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinePropertiesHardwareProfileDynamicMemoryConfigInternal
    {

        /// <summary>Backing field for <see cref="MaximumMemoryMb" /> property.</summary>
        private long? _maximumMemoryMb;

        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Origin(Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.PropertyOrigin.Owned)]
        public long? MaximumMemoryMb { get => this._maximumMemoryMb; set => this._maximumMemoryMb = value; }

        /// <summary>Backing field for <see cref="MinimumMemoryMb" /> property.</summary>
        private long? _minimumMemoryMb;

        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Origin(Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.PropertyOrigin.Owned)]
        public long? MinimumMemoryMb { get => this._minimumMemoryMb; set => this._minimumMemoryMb = value; }

        /// <summary>Backing field for <see cref="TargetMemoryBuffer" /> property.</summary>
        private int? _targetMemoryBuffer;

        /// <summary>
        /// Defines the amount of extra memory that should be reserved for a virtual machine at runtime, as a percentage of the total
        /// memory that the virtual machine is thought to need. This only applies to virtual systems with dynamic memory enabled.
        /// This property can be in the range of 5 to 2000.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Origin(Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.PropertyOrigin.Owned)]
        public int? TargetMemoryBuffer { get => this._targetMemoryBuffer; set => this._targetMemoryBuffer = value; }

        /// <summary>
        /// Creates an new <see cref="VirtualMachinePropertiesHardwareProfileDynamicMemoryConfig" /> instance.
        /// </summary>
        public VirtualMachinePropertiesHardwareProfileDynamicMemoryConfig()
        {

        }
    }
    public partial interface IVirtualMachinePropertiesHardwareProfileDynamicMemoryConfig :
        Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Runtime.IJsonSerializable
    {
        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"",
        SerializedName = @"maximumMemoryMB",
        PossibleTypes = new [] { typeof(long) })]
        long? MaximumMemoryMb { get; set; }

        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"",
        SerializedName = @"minimumMemoryMB",
        PossibleTypes = new [] { typeof(long) })]
        long? MinimumMemoryMb { get; set; }
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
        int? TargetMemoryBuffer { get; set; }

    }
    internal partial interface IVirtualMachinePropertiesHardwareProfileDynamicMemoryConfigInternal

    {
        long? MaximumMemoryMb { get; set; }

        long? MinimumMemoryMb { get; set; }
        /// <summary>
        /// Defines the amount of extra memory that should be reserved for a virtual machine at runtime, as a percentage of the total
        /// memory that the virtual machine is thought to need. This only applies to virtual systems with dynamic memory enabled.
        /// This property can be in the range of 5 to 2000.
        /// </summary>
        int? TargetMemoryBuffer { get; set; }

    }
}