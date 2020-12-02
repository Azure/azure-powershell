namespace Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Extensions;

    /// <summary>Replication protected item custom data details.</summary>
    public partial class ProtectableItemProperties :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IProtectableItemProperties,
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IProtectableItemPropertiesInternal
    {

        /// <summary>Backing field for <see cref="CustomDetail" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IConfigurationSettings _customDetail;

        /// <summary>The Replication provider custom settings.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IConfigurationSettings CustomDetail { get => (this._customDetail = this._customDetail ?? new Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.ConfigurationSettings()); set => this._customDetail = value; }

        /// <summary>Gets the class type. Overridden in derived classes.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inlined)]
        public string CustomDetailInstanceType { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IConfigurationSettingsInternal)CustomDetail).InstanceType; }

        /// <summary>Backing field for <see cref="FriendlyName" /> property.</summary>
        private string _friendlyName;

        /// <summary>The name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string FriendlyName { get => this._friendlyName; set => this._friendlyName = value; }

        /// <summary>Internal Acessors for CustomDetail</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IConfigurationSettings Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IProtectableItemPropertiesInternal.CustomDetail { get => (this._customDetail = this._customDetail ?? new Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.ConfigurationSettings()); set { {_customDetail = value;} } }

        /// <summary>Internal Acessors for CustomDetailInstanceType</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IProtectableItemPropertiesInternal.CustomDetailInstanceType { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IConfigurationSettingsInternal)CustomDetail).InstanceType; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IConfigurationSettingsInternal)CustomDetail).InstanceType = value; }

        /// <summary>Backing field for <see cref="ProtectionReadinessError" /> property.</summary>
        private string[] _protectionReadinessError;

        /// <summary>The Current protection readiness errors.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string[] ProtectionReadinessError { get => this._protectionReadinessError; set => this._protectionReadinessError = value; }

        /// <summary>Backing field for <see cref="ProtectionStatus" /> property.</summary>
        private string _protectionStatus;

        /// <summary>The protection status.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string ProtectionStatus { get => this._protectionStatus; set => this._protectionStatus = value; }

        /// <summary>Backing field for <see cref="RecoveryServicesProviderId" /> property.</summary>
        private string _recoveryServicesProviderId;

        /// <summary>The recovery provider ARM Id.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string RecoveryServicesProviderId { get => this._recoveryServicesProviderId; set => this._recoveryServicesProviderId = value; }

        /// <summary>Backing field for <see cref="ReplicationProtectedItemId" /> property.</summary>
        private string _replicationProtectedItemId;

        /// <summary>The ARM resource of protected items.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string ReplicationProtectedItemId { get => this._replicationProtectedItemId; set => this._replicationProtectedItemId = value; }

        /// <summary>Backing field for <see cref="SupportedReplicationProvider" /> property.</summary>
        private string[] _supportedReplicationProvider;

        /// <summary>The list of replication providers supported for the protectable item.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string[] SupportedReplicationProvider { get => this._supportedReplicationProvider; set => this._supportedReplicationProvider = value; }

        /// <summary>Creates an new <see cref="ProtectableItemProperties" /> instance.</summary>
        public ProtectableItemProperties()
        {

        }
    }
    /// Replication protected item custom data details.
    public partial interface IProtectableItemProperties :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.IJsonSerializable
    {
        /// <summary>Gets the class type. Overridden in derived classes.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Gets the class type. Overridden in derived classes.",
        SerializedName = @"instanceType",
        PossibleTypes = new [] { typeof(string) })]
        string CustomDetailInstanceType { get;  }
        /// <summary>The name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The name.",
        SerializedName = @"friendlyName",
        PossibleTypes = new [] { typeof(string) })]
        string FriendlyName { get; set; }
        /// <summary>The Current protection readiness errors.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The Current protection readiness errors.",
        SerializedName = @"protectionReadinessErrors",
        PossibleTypes = new [] { typeof(string) })]
        string[] ProtectionReadinessError { get; set; }
        /// <summary>The protection status.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The protection status.",
        SerializedName = @"protectionStatus",
        PossibleTypes = new [] { typeof(string) })]
        string ProtectionStatus { get; set; }
        /// <summary>The recovery provider ARM Id.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The recovery provider ARM Id.",
        SerializedName = @"recoveryServicesProviderId",
        PossibleTypes = new [] { typeof(string) })]
        string RecoveryServicesProviderId { get; set; }
        /// <summary>The ARM resource of protected items.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The ARM resource of protected items.",
        SerializedName = @"replicationProtectedItemId",
        PossibleTypes = new [] { typeof(string) })]
        string ReplicationProtectedItemId { get; set; }
        /// <summary>The list of replication providers supported for the protectable item.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The list of replication providers supported for the protectable item.",
        SerializedName = @"supportedReplicationProviders",
        PossibleTypes = new [] { typeof(string) })]
        string[] SupportedReplicationProvider { get; set; }

    }
    /// Replication protected item custom data details.
    internal partial interface IProtectableItemPropertiesInternal

    {
        /// <summary>The Replication provider custom settings.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IConfigurationSettings CustomDetail { get; set; }
        /// <summary>Gets the class type. Overridden in derived classes.</summary>
        string CustomDetailInstanceType { get; set; }
        /// <summary>The name.</summary>
        string FriendlyName { get; set; }
        /// <summary>The Current protection readiness errors.</summary>
        string[] ProtectionReadinessError { get; set; }
        /// <summary>The protection status.</summary>
        string ProtectionStatus { get; set; }
        /// <summary>The recovery provider ARM Id.</summary>
        string RecoveryServicesProviderId { get; set; }
        /// <summary>The ARM resource of protected items.</summary>
        string ReplicationProtectedItemId { get; set; }
        /// <summary>The list of replication providers supported for the protectable item.</summary>
        string[] SupportedReplicationProvider { get; set; }

    }
}