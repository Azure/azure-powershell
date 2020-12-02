namespace Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Extensions;

    public partial class HypervisorConfiguration :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHypervisorConfiguration,
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHypervisorConfigurationInternal
    {

        /// <summary>Backing field for <see cref="HypervisorType" /> property.</summary>
        private string _hypervisorType;

        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string HypervisorType { get => this._hypervisorType; set => this._hypervisorType = value; }

        /// <summary>Backing field for <see cref="NativeHostMachineId" /> property.</summary>
        private string _nativeHostMachineId;

        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string NativeHostMachineId { get => this._nativeHostMachineId; set => this._nativeHostMachineId = value; }

        /// <summary>Creates an new <see cref="HypervisorConfiguration" /> instance.</summary>
        public HypervisorConfiguration()
        {

        }
    }
    public partial interface IHypervisorConfiguration :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.IJsonSerializable
    {
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"",
        SerializedName = @"hypervisorType",
        PossibleTypes = new [] { typeof(string) })]
        string HypervisorType { get; set; }

        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"",
        SerializedName = @"nativeHostMachineId",
        PossibleTypes = new [] { typeof(string) })]
        string NativeHostMachineId { get; set; }

    }
    internal partial interface IHypervisorConfigurationInternal

    {
        string HypervisorType { get; set; }

        string NativeHostMachineId { get; set; }

    }
}