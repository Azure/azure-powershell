namespace Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Extensions;

    /// <summary>Common input details for network mapping operation.</summary>
    public partial class CreateNetworkMappingInputProperties :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.ICreateNetworkMappingInputProperties,
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.ICreateNetworkMappingInputPropertiesInternal
    {

        /// <summary>Backing field for <see cref="FabricSpecificDetail" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IFabricSpecificCreateNetworkMappingInput _fabricSpecificDetail;

        /// <summary>Fabric specific input properties.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IFabricSpecificCreateNetworkMappingInput FabricSpecificDetail { get => (this._fabricSpecificDetail = this._fabricSpecificDetail ?? new Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.FabricSpecificCreateNetworkMappingInput()); set => this._fabricSpecificDetail = value; }

        /// <summary>The instance type.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inlined)]
        public string FabricSpecificDetailInstanceType { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IFabricSpecificCreateNetworkMappingInputInternal)FabricSpecificDetail).InstanceType; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IFabricSpecificCreateNetworkMappingInputInternal)FabricSpecificDetail).InstanceType = value ?? null; }

        /// <summary>Internal Acessors for FabricSpecificDetail</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IFabricSpecificCreateNetworkMappingInput Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.ICreateNetworkMappingInputPropertiesInternal.FabricSpecificDetail { get => (this._fabricSpecificDetail = this._fabricSpecificDetail ?? new Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.FabricSpecificCreateNetworkMappingInput()); set { {_fabricSpecificDetail = value;} } }

        /// <summary>Backing field for <see cref="RecoveryFabricName" /> property.</summary>
        private string _recoveryFabricName;

        /// <summary>Recovery fabric Name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string RecoveryFabricName { get => this._recoveryFabricName; set => this._recoveryFabricName = value; }

        /// <summary>Backing field for <see cref="RecoveryNetworkId" /> property.</summary>
        private string _recoveryNetworkId;

        /// <summary>Recovery network Id.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string RecoveryNetworkId { get => this._recoveryNetworkId; set => this._recoveryNetworkId = value; }

        /// <summary>Creates an new <see cref="CreateNetworkMappingInputProperties" /> instance.</summary>
        public CreateNetworkMappingInputProperties()
        {

        }
    }
    /// Common input details for network mapping operation.
    public partial interface ICreateNetworkMappingInputProperties :
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
        /// <summary>Recovery fabric Name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Recovery fabric Name.",
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
    internal partial interface ICreateNetworkMappingInputPropertiesInternal

    {
        /// <summary>Fabric specific input properties.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IFabricSpecificCreateNetworkMappingInput FabricSpecificDetail { get; set; }
        /// <summary>The instance type.</summary>
        string FabricSpecificDetailInstanceType { get; set; }
        /// <summary>Recovery fabric Name.</summary>
        string RecoveryFabricName { get; set; }
        /// <summary>Recovery network Id.</summary>
        string RecoveryNetworkId { get; set; }

    }
}