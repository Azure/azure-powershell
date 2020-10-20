namespace Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Extensions;

    public partial class VirtualMachineConfiguration :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVirtualMachineConfiguration,
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVirtualMachineConfigurationInternal
    {

        /// <summary>Backing field for <see cref="NativeHostMachineId" /> property.</summary>
        private string _nativeHostMachineId;

        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string NativeHostMachineId { get => this._nativeHostMachineId; set => this._nativeHostMachineId = value; }

        /// <summary>Backing field for <see cref="NativeMachineId" /> property.</summary>
        private string _nativeMachineId;

        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string NativeMachineId { get => this._nativeMachineId; set => this._nativeMachineId = value; }

        /// <summary>Backing field for <see cref="VirtualMachineName" /> property.</summary>
        private string _virtualMachineName;

        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string VirtualMachineName { get => this._virtualMachineName; set => this._virtualMachineName = value; }

        /// <summary>Backing field for <see cref="VirtualMachineType" /> property.</summary>
        private string _virtualMachineType;

        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string VirtualMachineType { get => this._virtualMachineType; set => this._virtualMachineType = value; }

        /// <summary>Creates an new <see cref="VirtualMachineConfiguration" /> instance.</summary>
        public VirtualMachineConfiguration()
        {

        }
    }
    public partial interface IVirtualMachineConfiguration :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.IJsonSerializable
    {
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"",
        SerializedName = @"nativeHostMachineId",
        PossibleTypes = new [] { typeof(string) })]
        string NativeHostMachineId { get; set; }

        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"",
        SerializedName = @"nativeMachineId",
        PossibleTypes = new [] { typeof(string) })]
        string NativeMachineId { get; set; }

        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"",
        SerializedName = @"virtualMachineName",
        PossibleTypes = new [] { typeof(string) })]
        string VirtualMachineName { get; set; }

        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"",
        SerializedName = @"virtualMachineType",
        PossibleTypes = new [] { typeof(string) })]
        string VirtualMachineType { get; set; }

    }
    internal partial interface IVirtualMachineConfigurationInternal

    {
        string NativeHostMachineId { get; set; }

        string NativeMachineId { get; set; }

        string VirtualMachineName { get; set; }

        string VirtualMachineType { get; set; }

    }
}