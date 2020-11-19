namespace Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Extensions;

    /// <summary>Update migration item input properties.</summary>
    public partial class UpdateMigrationItemInputProperties :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IUpdateMigrationItemInputProperties,
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IUpdateMigrationItemInputPropertiesInternal
    {

        /// <summary>Backing field for <see cref="ProviderSpecificDetail" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IUpdateMigrationItemProviderSpecificInput _providerSpecificDetail;

        /// <summary>The provider specific input to update migration item.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IUpdateMigrationItemProviderSpecificInput ProviderSpecificDetail { get => (this._providerSpecificDetail = this._providerSpecificDetail ?? new Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.UpdateMigrationItemProviderSpecificInput()); set => this._providerSpecificDetail = value; }

        /// <summary>Creates an new <see cref="UpdateMigrationItemInputProperties" /> instance.</summary>
        public UpdateMigrationItemInputProperties()
        {

        }
    }
    /// Update migration item input properties.
    public partial interface IUpdateMigrationItemInputProperties :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.IJsonSerializable
    {
        /// <summary>The provider specific input to update migration item.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"The provider specific input to update migration item.",
        SerializedName = @"providerSpecificDetails",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IUpdateMigrationItemProviderSpecificInput) })]
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IUpdateMigrationItemProviderSpecificInput ProviderSpecificDetail { get; set; }

    }
    /// Update migration item input properties.
    internal partial interface IUpdateMigrationItemInputPropertiesInternal

    {
        /// <summary>The provider specific input to update migration item.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IUpdateMigrationItemProviderSpecificInput ProviderSpecificDetail { get; set; }

    }
}