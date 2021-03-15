namespace Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Extensions;

    /// <summary>Enable migration input.</summary>
    public partial class EnableMigrationInput :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IEnableMigrationInput,
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IEnableMigrationInputInternal
    {

        /// <summary>Internal Acessors for Property</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IEnableMigrationInputProperties Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IEnableMigrationInputInternal.Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.EnableMigrationInputProperties()); set { {_property = value;} } }

        /// <summary>The policy Id.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inlined)]
        public string PolicyId { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IEnableMigrationInputPropertiesInternal)Property).PolicyId; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IEnableMigrationInputPropertiesInternal)Property).PolicyId = value ; }

        /// <summary>Backing field for <see cref="Property" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IEnableMigrationInputProperties _property;

        /// <summary>Enable migration input properties.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IEnableMigrationInputProperties Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.EnableMigrationInputProperties()); set => this._property = value; }

        /// <summary>The provider specific details.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IEnableMigrationProviderSpecificInput ProviderSpecificDetail { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IEnableMigrationInputPropertiesInternal)Property).ProviderSpecificDetail; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IEnableMigrationInputPropertiesInternal)Property).ProviderSpecificDetail = value ; }

        /// <summary>Creates an new <see cref="EnableMigrationInput" /> instance.</summary>
        public EnableMigrationInput()
        {

        }
    }
    /// Enable migration input.
    public partial interface IEnableMigrationInput :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.IJsonSerializable
    {
        /// <summary>The policy Id.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"The policy Id.",
        SerializedName = @"policyId",
        PossibleTypes = new [] { typeof(string) })]
        string PolicyId { get; set; }
        /// <summary>The provider specific details.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"The provider specific details.",
        SerializedName = @"providerSpecificDetails",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IEnableMigrationProviderSpecificInput) })]
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IEnableMigrationProviderSpecificInput ProviderSpecificDetail { get; set; }

    }
    /// Enable migration input.
    internal partial interface IEnableMigrationInputInternal

    {
        /// <summary>The policy Id.</summary>
        string PolicyId { get; set; }
        /// <summary>Enable migration input properties.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IEnableMigrationInputProperties Property { get; set; }
        /// <summary>The provider specific details.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IEnableMigrationProviderSpecificInput ProviderSpecificDetail { get; set; }

    }
}