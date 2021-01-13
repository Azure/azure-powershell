namespace Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Extensions;

    /// <summary>Switch protection input properties.</summary>
    public partial class SwitchProtectionInputProperties :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.ISwitchProtectionInputProperties,
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.ISwitchProtectionInputPropertiesInternal
    {

        /// <summary>Internal Acessors for ProviderSpecificDetail</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.ISwitchProtectionProviderSpecificInput Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.ISwitchProtectionInputPropertiesInternal.ProviderSpecificDetail { get => (this._providerSpecificDetail = this._providerSpecificDetail ?? new Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.SwitchProtectionProviderSpecificInput()); set { {_providerSpecificDetail = value;} } }

        /// <summary>Backing field for <see cref="ProviderSpecificDetail" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.ISwitchProtectionProviderSpecificInput _providerSpecificDetail;

        /// <summary>Provider specific switch protection input.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.ISwitchProtectionProviderSpecificInput ProviderSpecificDetail { get => (this._providerSpecificDetail = this._providerSpecificDetail ?? new Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.SwitchProtectionProviderSpecificInput()); set => this._providerSpecificDetail = value; }

        /// <summary>Gets the Instance type.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inlined)]
        public string ProviderSpecificDetailInstanceType { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.ISwitchProtectionProviderSpecificInputInternal)ProviderSpecificDetail).InstanceType; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.ISwitchProtectionProviderSpecificInputInternal)ProviderSpecificDetail).InstanceType = value ?? null; }

        /// <summary>Backing field for <see cref="ReplicationProtectedItemName" /> property.</summary>
        private string _replicationProtectedItemName;

        /// <summary>The unique replication protected item name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string ReplicationProtectedItemName { get => this._replicationProtectedItemName; set => this._replicationProtectedItemName = value; }

        /// <summary>Creates an new <see cref="SwitchProtectionInputProperties" /> instance.</summary>
        public SwitchProtectionInputProperties()
        {

        }
    }
    /// Switch protection input properties.
    public partial interface ISwitchProtectionInputProperties :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.IJsonSerializable
    {
        /// <summary>Gets the Instance type.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Gets the Instance type.",
        SerializedName = @"instanceType",
        PossibleTypes = new [] { typeof(string) })]
        string ProviderSpecificDetailInstanceType { get; set; }
        /// <summary>The unique replication protected item name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The unique replication protected item name.",
        SerializedName = @"replicationProtectedItemName",
        PossibleTypes = new [] { typeof(string) })]
        string ReplicationProtectedItemName { get; set; }

    }
    /// Switch protection input properties.
    internal partial interface ISwitchProtectionInputPropertiesInternal

    {
        /// <summary>Provider specific switch protection input.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.ISwitchProtectionProviderSpecificInput ProviderSpecificDetail { get; set; }
        /// <summary>Gets the Instance type.</summary>
        string ProviderSpecificDetailInstanceType { get; set; }
        /// <summary>The unique replication protected item name.</summary>
        string ReplicationProtectedItemName { get; set; }

    }
}