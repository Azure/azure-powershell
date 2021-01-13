namespace Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Extensions;

    /// <summary>Common input details for network mapping operation.</summary>
    public partial class UpdateNetworkMappingInputProperties :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IUpdateNetworkMappingInputProperties,
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IUpdateNetworkMappingInputPropertiesInternal
    {

        /// <summary>Backing field for <see cref="FabricSpecificDetail" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IFabricSpecificUpdateNetworkMappingInput _fabricSpecificDetail;

        /// <summary>Fabrics specific input network Id.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IFabricSpecificUpdateNetworkMappingInput FabricSpecificDetail { get => (this._fabricSpecificDetail = this._fabricSpecificDetail ?? new Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.FabricSpecificUpdateNetworkMappingInput()); set => this._fabricSpecificDetail = value; }

        /// <summary>The instance type.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inlined)]
        public string FabricSpecificDetailInstanceType { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IFabricSpecificUpdateNetworkMappingInputInternal)FabricSpecificDetail).InstanceType; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IFabricSpecificUpdateNetworkMappingInputInternal)FabricSpecificDetail).InstanceType = value ?? null; }

        /// <summary>Internal Acessors for FabricSpecificDetail</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IFabricSpecificUpdateNetworkMappingInput Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IUpdateNetworkMappingInputPropertiesInternal.FabricSpecificDetail { get => (this._fabricSpecificDetail = this._fabricSpecificDetail ?? new Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.FabricSpecificUpdateNetworkMappingInput()); set { {_fabricSpecificDetail = value;} } }

        /// <summary>Backing field for <see cref="RecoveryFabricName" /> property.</summary>
        private string _recoveryFabricName;

        /// <summary>Recovery fabric name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string RecoveryFabricName { get => this._recoveryFabricName; set => this._recoveryFabricName = value; }

        /// <summary>Backing field for <see cref="RecoveryNetworkId" /> property.</summary>
        private string _recoveryNetworkId;

        /// <summary>Recovery network Id.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string RecoveryNetworkId { get => this._recoveryNetworkId; set => this._recoveryNetworkId = value; }

        /// <summary>Creates an new <see cref="UpdateNetworkMappingInputProperties" /> instance.</summary>
        public UpdateNetworkMappingInputProperties()
        {

        }
    }
    /// Common input details for network mapping operation.
    public partial interface IUpdateNetworkMappingInputProperties :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.IJsonSerializable
    {
        /// <summary>The instance type.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The instance type.",
        SerializedName = @"instanceType",
        PossibleTypes = new [] { typeof(string) })]
        string FabricSpecificDetailInstanceType { get; set; }
        /// <summary>Recovery fabric name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Recovery fabric name.",
        SerializedName = @"recoveryFabricName",
        PossibleTypes = new [] { typeof(string) })]
        string RecoveryFabricName { get; set; }
        /// <summary>Recovery network Id.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Recovery network Id.",
        SerializedName = @"recoveryNetworkId",
        PossibleTypes = new [] { typeof(string) })]
        string RecoveryNetworkId { get; set; }

    }
    /// Common input details for network mapping operation.
    internal partial interface IUpdateNetworkMappingInputPropertiesInternal

    {
        /// <summary>Fabrics specific input network Id.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IFabricSpecificUpdateNetworkMappingInput FabricSpecificDetail { get; set; }
        /// <summary>The instance type.</summary>
        string FabricSpecificDetailInstanceType { get; set; }
        /// <summary>Recovery fabric name.</summary>
        string RecoveryFabricName { get; set; }
        /// <summary>Recovery network Id.</summary>
        string RecoveryNetworkId { get; set; }

    }
}