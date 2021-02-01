namespace Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Extensions;

    /// <summary>Enable protection input properties.</summary>
    public partial class EnableProtectionInputProperties :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IEnableProtectionInputProperties,
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IEnableProtectionInputPropertiesInternal
    {

        /// <summary>Internal Acessors for ProviderSpecificDetail</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IEnableProtectionProviderSpecificInput Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IEnableProtectionInputPropertiesInternal.ProviderSpecificDetail { get => (this._providerSpecificDetail = this._providerSpecificDetail ?? new Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.EnableProtectionProviderSpecificInput()); set { {_providerSpecificDetail = value;} } }

        /// <summary>Backing field for <see cref="PolicyId" /> property.</summary>
        private string _policyId;

        /// <summary>The Policy Id.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string PolicyId { get => this._policyId; set => this._policyId = value; }

        /// <summary>Backing field for <see cref="ProtectableItemId" /> property.</summary>
        private string _protectableItemId;

        /// <summary>The protectable item Id.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string ProtectableItemId { get => this._protectableItemId; set => this._protectableItemId = value; }

        /// <summary>Backing field for <see cref="ProviderSpecificDetail" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IEnableProtectionProviderSpecificInput _providerSpecificDetail;

        /// <summary>
        /// The ReplicationProviderInput. For HyperVReplicaAzure provider, it will be AzureEnableProtectionInput object. For San provider,
        /// it will be SanEnableProtectionInput object. For HyperVReplicaAzure provider, it can be null.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IEnableProtectionProviderSpecificInput ProviderSpecificDetail { get => (this._providerSpecificDetail = this._providerSpecificDetail ?? new Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.EnableProtectionProviderSpecificInput()); set => this._providerSpecificDetail = value; }

        /// <summary>The class type.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inlined)]
        public string ProviderSpecificDetailInstanceType { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IEnableProtectionProviderSpecificInputInternal)ProviderSpecificDetail).InstanceType; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IEnableProtectionProviderSpecificInputInternal)ProviderSpecificDetail).InstanceType = value ?? null; }

        /// <summary>Creates an new <see cref="EnableProtectionInputProperties" /> instance.</summary>
        public EnableProtectionInputProperties()
        {

        }
    }
    /// Enable protection input properties.
    public partial interface IEnableProtectionInputProperties :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.IJsonSerializable
    {
        /// <summary>The Policy Id.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The Policy Id.",
        SerializedName = @"policyId",
        PossibleTypes = new [] { typeof(string) })]
        string PolicyId { get; set; }
        /// <summary>The protectable item Id.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The protectable item Id.",
        SerializedName = @"protectableItemId",
        PossibleTypes = new [] { typeof(string) })]
        string ProtectableItemId { get; set; }
        /// <summary>The class type.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The class type.",
        SerializedName = @"instanceType",
        PossibleTypes = new [] { typeof(string) })]
        string ProviderSpecificDetailInstanceType { get; set; }

    }
    /// Enable protection input properties.
    internal partial interface IEnableProtectionInputPropertiesInternal

    {
        /// <summary>The Policy Id.</summary>
        string PolicyId { get; set; }
        /// <summary>The protectable item Id.</summary>
        string ProtectableItemId { get; set; }
        /// <summary>
        /// The ReplicationProviderInput. For HyperVReplicaAzure provider, it will be AzureEnableProtectionInput object. For San provider,
        /// it will be SanEnableProtectionInput object. For HyperVReplicaAzure provider, it can be null.
        /// </summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IEnableProtectionProviderSpecificInput ProviderSpecificDetail { get; set; }
        /// <summary>The class type.</summary>
        string ProviderSpecificDetailInstanceType { get; set; }

    }
}