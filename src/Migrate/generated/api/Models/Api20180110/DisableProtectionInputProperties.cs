namespace Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Extensions;

    /// <summary>Disable protection input properties.</summary>
    public partial class DisableProtectionInputProperties :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IDisableProtectionInputProperties,
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IDisableProtectionInputPropertiesInternal
    {

        /// <summary>Backing field for <see cref="DisableProtectionReason" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Migrate.Support.DisableProtectionReason? _disableProtectionReason;

        /// <summary>Disable protection reason. It can have values NotSpecified/MigrationComplete.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Migrate.Support.DisableProtectionReason? DisableProtectionReason { get => this._disableProtectionReason; set => this._disableProtectionReason = value; }

        /// <summary>Internal Acessors for ReplicationProviderInput</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IDisableProtectionProviderSpecificInput Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IDisableProtectionInputPropertiesInternal.ReplicationProviderInput { get => (this._replicationProviderInput = this._replicationProviderInput ?? new Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.DisableProtectionProviderSpecificInput()); set { {_replicationProviderInput = value;} } }

        /// <summary>Backing field for <see cref="ReplicationProviderInput" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IDisableProtectionProviderSpecificInput _replicationProviderInput;

        /// <summary>Replication provider specific input.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IDisableProtectionProviderSpecificInput ReplicationProviderInput { get => (this._replicationProviderInput = this._replicationProviderInput ?? new Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.DisableProtectionProviderSpecificInput()); set => this._replicationProviderInput = value; }

        /// <summary>The class type.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inlined)]
        public string ReplicationProviderInputInstanceType { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IDisableProtectionProviderSpecificInputInternal)ReplicationProviderInput).InstanceType; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IDisableProtectionProviderSpecificInputInternal)ReplicationProviderInput).InstanceType = value ?? null; }

        /// <summary>Creates an new <see cref="DisableProtectionInputProperties" /> instance.</summary>
        public DisableProtectionInputProperties()
        {

        }
    }
    /// Disable protection input properties.
    public partial interface IDisableProtectionInputProperties :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.IJsonSerializable
    {
        /// <summary>Disable protection reason. It can have values NotSpecified/MigrationComplete.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Disable protection reason. It can have values NotSpecified/MigrationComplete.",
        SerializedName = @"disableProtectionReason",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Migrate.Support.DisableProtectionReason) })]
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Support.DisableProtectionReason? DisableProtectionReason { get; set; }
        /// <summary>The class type.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The class type.",
        SerializedName = @"instanceType",
        PossibleTypes = new [] { typeof(string) })]
        string ReplicationProviderInputInstanceType { get; set; }

    }
    /// Disable protection input properties.
    internal partial interface IDisableProtectionInputPropertiesInternal

    {
        /// <summary>Disable protection reason. It can have values NotSpecified/MigrationComplete.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Support.DisableProtectionReason? DisableProtectionReason { get; set; }
        /// <summary>Replication provider specific input.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IDisableProtectionProviderSpecificInput ReplicationProviderInput { get; set; }
        /// <summary>The class type.</summary>
        string ReplicationProviderInputInstanceType { get; set; }

    }
}