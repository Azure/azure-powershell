namespace Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Extensions;

    /// <summary>Enable migration input properties.</summary>
    public partial class EnableMigrationInputProperties :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IEnableMigrationInputProperties,
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IEnableMigrationInputPropertiesInternal
    {

        /// <summary>Backing field for <see cref="PolicyId" /> property.</summary>
        private string _policyId;

        /// <summary>The policy Id.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string PolicyId { get => this._policyId; set => this._policyId = value; }

        /// <summary>Backing field for <see cref="ProviderSpecificDetail" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IEnableMigrationProviderSpecificInput _providerSpecificDetail;

        /// <summary>The provider specific details.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IEnableMigrationProviderSpecificInput ProviderSpecificDetail { get => (this._providerSpecificDetail = this._providerSpecificDetail ?? new Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.EnableMigrationProviderSpecificInput()); set => this._providerSpecificDetail = value; }

        /// <summary>Creates an new <see cref="EnableMigrationInputProperties" /> instance.</summary>
        public EnableMigrationInputProperties()
        {

        }
    }
    /// Enable migration input properties.
    public partial interface IEnableMigrationInputProperties :
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
    /// Enable migration input properties.
    internal partial interface IEnableMigrationInputPropertiesInternal

    {
        /// <summary>The policy Id.</summary>
        string PolicyId { get; set; }
        /// <summary>The provider specific details.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IEnableMigrationProviderSpecificInput ProviderSpecificDetail { get; set; }

    }
}