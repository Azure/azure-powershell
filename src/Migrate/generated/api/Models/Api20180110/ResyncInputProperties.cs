namespace Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Extensions;

    /// <summary>Resync input properties.</summary>
    public partial class ResyncInputProperties :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IResyncInputProperties,
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IResyncInputPropertiesInternal
    {

        /// <summary>Backing field for <see cref="ProviderSpecificDetail" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IResyncProviderSpecificInput _providerSpecificDetail;

        /// <summary>The provider specific details.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IResyncProviderSpecificInput ProviderSpecificDetail { get => (this._providerSpecificDetail = this._providerSpecificDetail ?? new Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.ResyncProviderSpecificInput()); set => this._providerSpecificDetail = value; }

        /// <summary>Creates an new <see cref="ResyncInputProperties" /> instance.</summary>
        public ResyncInputProperties()
        {

        }
    }
    /// Resync input properties.
    public partial interface IResyncInputProperties :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.IJsonSerializable
    {
        /// <summary>The provider specific details.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"The provider specific details.",
        SerializedName = @"providerSpecificDetails",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IResyncProviderSpecificInput) })]
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IResyncProviderSpecificInput ProviderSpecificDetail { get; set; }

    }
    /// Resync input properties.
    internal partial interface IResyncInputPropertiesInternal

    {
        /// <summary>The provider specific details.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IResyncProviderSpecificInput ProviderSpecificDetail { get; set; }

    }
}