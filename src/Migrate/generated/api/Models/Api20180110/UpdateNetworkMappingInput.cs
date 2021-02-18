namespace Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Extensions;

    /// <summary>Update network mapping input.</summary>
    public partial class UpdateNetworkMappingInput :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IUpdateNetworkMappingInput,
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IUpdateNetworkMappingInputInternal
    {

        /// <summary>The instance type.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inlined)]
        public string FabricSpecificDetailInstanceType { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IUpdateNetworkMappingInputPropertiesInternal)Property).FabricSpecificDetailInstanceType; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IUpdateNetworkMappingInputPropertiesInternal)Property).FabricSpecificDetailInstanceType = value ?? null; }

        /// <summary>Internal Acessors for FabricSpecificDetail</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IFabricSpecificUpdateNetworkMappingInput Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IUpdateNetworkMappingInputInternal.FabricSpecificDetail { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IUpdateNetworkMappingInputPropertiesInternal)Property).FabricSpecificDetail; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IUpdateNetworkMappingInputPropertiesInternal)Property).FabricSpecificDetail = value; }

        /// <summary>Internal Acessors for Property</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IUpdateNetworkMappingInputProperties Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IUpdateNetworkMappingInputInternal.Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.UpdateNetworkMappingInputProperties()); set { {_property = value;} } }

        /// <summary>Backing field for <see cref="Property" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IUpdateNetworkMappingInputProperties _property;

        /// <summary>The input properties needed to update network mapping.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IUpdateNetworkMappingInputProperties Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.UpdateNetworkMappingInputProperties()); set => this._property = value; }

        /// <summary>Recovery fabric name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inlined)]
        public string RecoveryFabricName { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IUpdateNetworkMappingInputPropertiesInternal)Property).RecoveryFabricName; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IUpdateNetworkMappingInputPropertiesInternal)Property).RecoveryFabricName = value ?? null; }

        /// <summary>Recovery network Id.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inlined)]
        public string RecoveryNetworkId { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IUpdateNetworkMappingInputPropertiesInternal)Property).RecoveryNetworkId; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IUpdateNetworkMappingInputPropertiesInternal)Property).RecoveryNetworkId = value ?? null; }

        /// <summary>Creates an new <see cref="UpdateNetworkMappingInput" /> instance.</summary>
        public UpdateNetworkMappingInput()
        {

        }
    }
    /// Update network mapping input.
    public partial interface IUpdateNetworkMappingInput :
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
    /// Update network mapping input.
    internal partial interface IUpdateNetworkMappingInputInternal

    {
        /// <summary>Fabrics specific input network Id.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IFabricSpecificUpdateNetworkMappingInput FabricSpecificDetail { get; set; }
        /// <summary>The instance type.</summary>
        string FabricSpecificDetailInstanceType { get; set; }
        /// <summary>The input properties needed to update network mapping.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IUpdateNetworkMappingInputProperties Property { get; set; }
        /// <summary>Recovery fabric name.</summary>
        string RecoveryFabricName { get; set; }
        /// <summary>Recovery network Id.</summary>
        string RecoveryNetworkId { get; set; }

    }
}