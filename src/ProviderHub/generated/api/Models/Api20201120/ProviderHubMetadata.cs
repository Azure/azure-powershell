namespace Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120
{
    using static Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.Extensions;

    public partial class ProviderHubMetadata :
        Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IProviderHubMetadata,
        Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IProviderHubMetadataInternal
    {

        /// <summary>Internal Acessors for ProviderAuthentication</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IResourceProviderAuthentication Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IProviderHubMetadataInternal.ProviderAuthentication { get => (this._providerAuthentication = this._providerAuthentication ?? new Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.ResourceProviderAuthentication()); set { {_providerAuthentication = value;} } }

        /// <summary>Internal Acessors for ThirdPartyProviderAuthorization</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IThirdPartyProviderAuthorization Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IProviderHubMetadataInternal.ThirdPartyProviderAuthorization { get => (this._thirdPartyProviderAuthorization = this._thirdPartyProviderAuthorization ?? new Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.ThirdPartyProviderAuthorization()); set { {_thirdPartyProviderAuthorization = value;} } }

        /// <summary>Backing field for <see cref="ProviderAuthentication" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IResourceProviderAuthentication _providerAuthentication;

        [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Origin(Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IResourceProviderAuthentication ProviderAuthentication { get => (this._providerAuthentication = this._providerAuthentication ?? new Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.ResourceProviderAuthentication()); set => this._providerAuthentication = value; }

        [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Origin(Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.PropertyOrigin.Inlined)]
        public string[] ProviderAuthenticationAllowedAudience { get => ((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IResourceProviderAuthenticationInternal)ProviderAuthentication).AllowedAudience; set => ((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IResourceProviderAuthenticationInternal)ProviderAuthentication).AllowedAudience = value ?? null /* arrayOf */; }

        /// <summary>Backing field for <see cref="ProviderAuthorization" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IResourceProviderAuthorization[] _providerAuthorization;

        [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Origin(Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IResourceProviderAuthorization[] ProviderAuthorization { get => this._providerAuthorization; set => this._providerAuthorization = value; }

        /// <summary>Backing field for <see cref="ThirdPartyProviderAuthorization" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IThirdPartyProviderAuthorization _thirdPartyProviderAuthorization;

        [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Origin(Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IThirdPartyProviderAuthorization ThirdPartyProviderAuthorization { get => (this._thirdPartyProviderAuthorization = this._thirdPartyProviderAuthorization ?? new Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.ThirdPartyProviderAuthorization()); set => this._thirdPartyProviderAuthorization = value; }

        [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Origin(Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.ILightHouseAuthorization[] ThirdPartyProviderAuthorizationAuthorization { get => ((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IThirdPartyProviderAuthorizationInternal)ThirdPartyProviderAuthorization).Authorization; set => ((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IThirdPartyProviderAuthorizationInternal)ThirdPartyProviderAuthorization).Authorization = value ?? null /* arrayOf */; }

        [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Origin(Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.PropertyOrigin.Inlined)]
        public string ThirdPartyProviderAuthorizationManagedByTenantId { get => ((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IThirdPartyProviderAuthorizationInternal)ThirdPartyProviderAuthorization).ManagedByTenantId; set => ((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IThirdPartyProviderAuthorizationInternal)ThirdPartyProviderAuthorization).ManagedByTenantId = value ?? null; }

        /// <summary>Creates an new <see cref="ProviderHubMetadata" /> instance.</summary>
        public ProviderHubMetadata()
        {

        }
    }
    public partial interface IProviderHubMetadata :
        Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.IJsonSerializable
    {
        [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"",
        SerializedName = @"allowedAudiences",
        PossibleTypes = new [] { typeof(string) })]
        string[] ProviderAuthenticationAllowedAudience { get; set; }

        [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"",
        SerializedName = @"providerAuthorizations",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IResourceProviderAuthorization) })]
        Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IResourceProviderAuthorization[] ProviderAuthorization { get; set; }

        [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"",
        SerializedName = @"authorizations",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.ILightHouseAuthorization) })]
        Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.ILightHouseAuthorization[] ThirdPartyProviderAuthorizationAuthorization { get; set; }

        [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"",
        SerializedName = @"managedByTenantId",
        PossibleTypes = new [] { typeof(string) })]
        string ThirdPartyProviderAuthorizationManagedByTenantId { get; set; }

    }
    internal partial interface IProviderHubMetadataInternal

    {
        Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IResourceProviderAuthentication ProviderAuthentication { get; set; }

        string[] ProviderAuthenticationAllowedAudience { get; set; }

        Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IResourceProviderAuthorization[] ProviderAuthorization { get; set; }

        Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IThirdPartyProviderAuthorization ThirdPartyProviderAuthorization { get; set; }

        Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.ILightHouseAuthorization[] ThirdPartyProviderAuthorizationAuthorization { get; set; }

        string ThirdPartyProviderAuthorizationManagedByTenantId { get; set; }

    }
}