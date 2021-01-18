namespace Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Extensions;

    /// <summary>Disable protection input.</summary>
    public partial class DisableProtectionInput :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IDisableProtectionInput,
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IDisableProtectionInputInternal
    {

        /// <summary>Disable protection reason. It can have values NotSpecified/MigrationComplete.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Migrate.Support.DisableProtectionReason? DisableProtectionReason { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IDisableProtectionInputPropertiesInternal)Property).DisableProtectionReason; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IDisableProtectionInputPropertiesInternal)Property).DisableProtectionReason = value ?? ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Support.DisableProtectionReason)""); }

        /// <summary>Internal Acessors for Property</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IDisableProtectionInputProperties Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IDisableProtectionInputInternal.Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.DisableProtectionInputProperties()); set { {_property = value;} } }

        /// <summary>Internal Acessors for ReplicationProviderInput</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IDisableProtectionProviderSpecificInput Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IDisableProtectionInputInternal.ReplicationProviderInput { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IDisableProtectionInputPropertiesInternal)Property).ReplicationProviderInput; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IDisableProtectionInputPropertiesInternal)Property).ReplicationProviderInput = value; }

        /// <summary>Backing field for <see cref="Property" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IDisableProtectionInputProperties _property;

        /// <summary>Disable protection input properties.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IDisableProtectionInputProperties Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.DisableProtectionInputProperties()); set => this._property = value; }

        /// <summary>The class type.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inlined)]
        public string ReplicationProviderInputInstanceType { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IDisableProtectionInputPropertiesInternal)Property).ReplicationProviderInputInstanceType; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IDisableProtectionInputPropertiesInternal)Property).ReplicationProviderInputInstanceType = value ?? null; }

        /// <summary>Creates an new <see cref="DisableProtectionInput" /> instance.</summary>
        public DisableProtectionInput()
        {

        }
    }
    /// Disable protection input.
    public partial interface IDisableProtectionInput :
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
    /// Disable protection input.
    internal partial interface IDisableProtectionInputInternal

    {
        /// <summary>Disable protection reason. It can have values NotSpecified/MigrationComplete.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Support.DisableProtectionReason? DisableProtectionReason { get; set; }
        /// <summary>Disable protection input properties.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IDisableProtectionInputProperties Property { get; set; }
        /// <summary>Replication provider specific input.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IDisableProtectionProviderSpecificInput ReplicationProviderInput { get; set; }
        /// <summary>The class type.</summary>
        string ReplicationProviderInputInstanceType { get; set; }

    }
}