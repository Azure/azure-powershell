namespace Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Extensions;

    /// <summary>Input details specific to fabrics during Network Mapping.</summary>
    public partial class FabricSpecificUpdateNetworkMappingInput :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IFabricSpecificUpdateNetworkMappingInput,
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IFabricSpecificUpdateNetworkMappingInputInternal
    {

        /// <summary>Backing field for <see cref="InstanceType" /> property.</summary>
        private string _instanceType;

        /// <summary>The instance type.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string InstanceType { get => this._instanceType; set => this._instanceType = value; }

        /// <summary>Creates an new <see cref="FabricSpecificUpdateNetworkMappingInput" /> instance.</summary>
        public FabricSpecificUpdateNetworkMappingInput()
        {

        }
    }
    /// Input details specific to fabrics during Network Mapping.
    public partial interface IFabricSpecificUpdateNetworkMappingInput :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.IJsonSerializable
    {
        /// <summary>The instance type.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The instance type.",
        SerializedName = @"instanceType",
        PossibleTypes = new [] { typeof(string) })]
        string InstanceType { get; set; }

    }
    /// Input details specific to fabrics during Network Mapping.
    internal partial interface IFabricSpecificUpdateNetworkMappingInputInternal

    {
        /// <summary>The instance type.</summary>
        string InstanceType { get; set; }

    }
}