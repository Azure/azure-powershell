namespace Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Extensions;

    /// <summary>Input for migrate.</summary>
    public partial class MigrateInput :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IMigrateInput,
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IMigrateInputInternal
    {

        /// <summary>Internal Acessors for Property</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IMigrateInputProperties Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IMigrateInputInternal.Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.MigrateInputProperties()); set { {_property = value;} } }

        /// <summary>Backing field for <see cref="Property" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IMigrateInputProperties _property;

        /// <summary>Migrate input properties.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IMigrateInputProperties Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.MigrateInputProperties()); set => this._property = value; }

        /// <summary>The provider specific details.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IMigrateProviderSpecificInput ProviderSpecificDetail { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IMigrateInputPropertiesInternal)Property).ProviderSpecificDetail; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IMigrateInputPropertiesInternal)Property).ProviderSpecificDetail = value ; }

        /// <summary>Creates an new <see cref="MigrateInput" /> instance.</summary>
        public MigrateInput()
        {

        }
    }
    /// Input for migrate.
    public partial interface IMigrateInput :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.IJsonSerializable
    {
        /// <summary>The provider specific details.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"The provider specific details.",
        SerializedName = @"providerSpecificDetails",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IMigrateProviderSpecificInput) })]
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IMigrateProviderSpecificInput ProviderSpecificDetail { get; set; }

    }
    /// Input for migrate.
    internal partial interface IMigrateInputInternal

    {
        /// <summary>Migrate input properties.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IMigrateInputProperties Property { get; set; }
        /// <summary>The provider specific details.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IMigrateProviderSpecificInput ProviderSpecificDetail { get; set; }

    }
}