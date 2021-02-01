namespace Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Extensions;

    /// <summary>Recovery point properties.</summary>
    public partial class RecoveryPointProperties :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IRecoveryPointProperties,
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IRecoveryPointPropertiesInternal
    {

        /// <summary>Internal Acessors for ProviderSpecificDetail</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IProviderSpecificRecoveryPointDetails Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IRecoveryPointPropertiesInternal.ProviderSpecificDetail { get => (this._providerSpecificDetail = this._providerSpecificDetail ?? new Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.ProviderSpecificRecoveryPointDetails()); set { {_providerSpecificDetail = value;} } }

        /// <summary>Internal Acessors for ProviderSpecificDetailInstanceType</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IRecoveryPointPropertiesInternal.ProviderSpecificDetailInstanceType { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IProviderSpecificRecoveryPointDetailsInternal)ProviderSpecificDetail).InstanceType; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IProviderSpecificRecoveryPointDetailsInternal)ProviderSpecificDetail).InstanceType = value; }

        /// <summary>Backing field for <see cref="ProviderSpecificDetail" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IProviderSpecificRecoveryPointDetails _providerSpecificDetail;

        /// <summary>The provider specific details for the recovery point.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IProviderSpecificRecoveryPointDetails ProviderSpecificDetail { get => (this._providerSpecificDetail = this._providerSpecificDetail ?? new Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.ProviderSpecificRecoveryPointDetails()); set => this._providerSpecificDetail = value; }

        /// <summary>Gets the provider type.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inlined)]
        public string ProviderSpecificDetailInstanceType { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IProviderSpecificRecoveryPointDetailsInternal)ProviderSpecificDetail).InstanceType; }

        /// <summary>Backing field for <see cref="RecoveryPointTime" /> property.</summary>
        private global::System.DateTime? _recoveryPointTime;

        /// <summary>The recovery point time.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public global::System.DateTime? RecoveryPointTime { get => this._recoveryPointTime; set => this._recoveryPointTime = value; }

        /// <summary>Backing field for <see cref="RecoveryPointType" /> property.</summary>
        private string _recoveryPointType;

        /// <summary>The recovery point type: ApplicationConsistent, CrashConsistent.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string RecoveryPointType { get => this._recoveryPointType; set => this._recoveryPointType = value; }

        /// <summary>Creates an new <see cref="RecoveryPointProperties" /> instance.</summary>
        public RecoveryPointProperties()
        {

        }
    }
    /// Recovery point properties.
    public partial interface IRecoveryPointProperties :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.IJsonSerializable
    {
        /// <summary>Gets the provider type.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Gets the provider type.",
        SerializedName = @"instanceType",
        PossibleTypes = new [] { typeof(string) })]
        string ProviderSpecificDetailInstanceType { get;  }
        /// <summary>The recovery point time.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The recovery point time.",
        SerializedName = @"recoveryPointTime",
        PossibleTypes = new [] { typeof(global::System.DateTime) })]
        global::System.DateTime? RecoveryPointTime { get; set; }
        /// <summary>The recovery point type: ApplicationConsistent, CrashConsistent.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The recovery point type: ApplicationConsistent, CrashConsistent.",
        SerializedName = @"recoveryPointType",
        PossibleTypes = new [] { typeof(string) })]
        string RecoveryPointType { get; set; }

    }
    /// Recovery point properties.
    internal partial interface IRecoveryPointPropertiesInternal

    {
        /// <summary>The provider specific details for the recovery point.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IProviderSpecificRecoveryPointDetails ProviderSpecificDetail { get; set; }
        /// <summary>Gets the provider type.</summary>
        string ProviderSpecificDetailInstanceType { get; set; }
        /// <summary>The recovery point time.</summary>
        global::System.DateTime? RecoveryPointTime { get; set; }
        /// <summary>The recovery point type: ApplicationConsistent, CrashConsistent.</summary>
        string RecoveryPointType { get; set; }

    }
}