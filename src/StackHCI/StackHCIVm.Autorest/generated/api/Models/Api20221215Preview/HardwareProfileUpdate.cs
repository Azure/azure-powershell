namespace Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview
{
    using static Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Runtime.Extensions;

    /// <summary>HardwareProfile - Specifies the hardware settings for the virtual machine.</summary>
    public partial class HardwareProfileUpdate :
        Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IHardwareProfileUpdate,
        Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IHardwareProfileUpdateInternal
    {

        /// <summary>Backing field for <see cref="MemoryMb" /> property.</summary>
        private long? _memoryMb;

        /// <summary>RAM in MB for the virtual machine</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Origin(Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.PropertyOrigin.Owned)]
        public long? MemoryMb { get => this._memoryMb; set => this._memoryMb = value; }

        /// <summary>Backing field for <see cref="Processor" /> property.</summary>
        private int? _processor;

        /// <summary>number of processors for the virtual machine</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Origin(Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.PropertyOrigin.Owned)]
        public int? Processor { get => this._processor; set => this._processor = value; }

        /// <summary>Backing field for <see cref="VMSize" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Support.VMSizeEnum? _vMSize;

        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Origin(Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Support.VMSizeEnum? VMSize { get => this._vMSize; set => this._vMSize = value; }

        /// <summary>Creates an new <see cref="HardwareProfileUpdate" /> instance.</summary>
        public HardwareProfileUpdate()
        {

        }
    }
    /// HardwareProfile - Specifies the hardware settings for the virtual machine.
    public partial interface IHardwareProfileUpdate :
        Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Runtime.IJsonSerializable
    {
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
    internal partial interface IHardwareProfileUpdateInternal

    {
        /// <summary>RAM in MB for the virtual machine</summary>
        long? MemoryMb { get; set; }
        /// <summary>number of processors for the virtual machine</summary>
        int? Processor { get; set; }

        Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Support.VMSizeEnum? VMSize { get; set; }

    }
}