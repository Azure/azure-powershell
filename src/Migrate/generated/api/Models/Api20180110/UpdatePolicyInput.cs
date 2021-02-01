namespace Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Extensions;

    /// <summary>Update policy input.</summary>
    public partial class UpdatePolicyInput :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IUpdatePolicyInput,
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IUpdatePolicyInputInternal
    {

        /// <summary>Internal Acessors for Property</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IUpdatePolicyInputProperties Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IUpdatePolicyInputInternal.Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.UpdatePolicyInputProperties()); set { {_property = value;} } }

        /// <summary>Backing field for <see cref="Property" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IUpdatePolicyInputProperties _property;

        /// <summary>The ReplicationProviderSettings.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IUpdatePolicyInputProperties Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.UpdatePolicyInputProperties()); set => this._property = value; }

        /// <summary>The ReplicationProviderSettings.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IPolicyProviderSpecificInput ReplicationProviderSetting { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IUpdatePolicyInputPropertiesInternal)Property).ReplicationProviderSetting; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IUpdatePolicyInputPropertiesInternal)Property).ReplicationProviderSetting = value ?? null /* model class */; }

        /// <summary>Creates an new <see cref="UpdatePolicyInput" /> instance.</summary>
        public UpdatePolicyInput()
        {

        }
    }
    /// Update policy input.
    public partial interface IUpdatePolicyInput :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.IJsonSerializable
    {
        /// <summary>The ReplicationProviderSettings.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The ReplicationProviderSettings.",
        SerializedName = @"replicationProviderSettings",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IPolicyProviderSpecificInput) })]
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IPolicyProviderSpecificInput ReplicationProviderSetting { get; set; }

    }
    /// Update policy input.
    internal partial interface IUpdatePolicyInputInternal

    {
        /// <summary>The ReplicationProviderSettings.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IUpdatePolicyInputProperties Property { get; set; }
        /// <summary>The ReplicationProviderSettings.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IPolicyProviderSpecificInput ReplicationProviderSetting { get; set; }

    }
}