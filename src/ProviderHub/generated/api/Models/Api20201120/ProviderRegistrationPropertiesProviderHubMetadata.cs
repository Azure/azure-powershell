namespace Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120
{
    using static Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.Extensions;

    public partial class ProviderRegistrationPropertiesProviderHubMetadata :
        Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IProviderRegistrationPropertiesProviderHubMetadata,
        Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IProviderRegistrationPropertiesProviderHubMetadataInternal,
        Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.IValidates
    {
        /// <summary>
        /// Backing field for Inherited model <see cref= "Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IProviderHubMetadata"
        /// />
        /// </summary>
        private Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IProviderHubMetadata __providerHubMetadata = new Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.ProviderHubMetadata();

        [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Origin(Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.PropertyOrigin.Inherited)]
        public Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IResourceProviderAuthentication ProviderAuthentication { get => ((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IProviderHubMetadataInternal)__providerHubMetadata).ProviderAuthentication; set => ((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IProviderHubMetadataInternal)__providerHubMetadata).ProviderAuthentication = value ?? null /* model class */; }

        [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Origin(Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.PropertyOrigin.Inherited)]
        public string[] ProviderAuthenticationAllowedAudience { get => ((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IProviderHubMetadataInternal)__providerHubMetadata).ProviderAuthenticationAllowedAudience; set => ((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IProviderHubMetadataInternal)__providerHubMetadata).ProviderAuthenticationAllowedAudience = value ?? null /* arrayOf */; }

        [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Origin(Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.PropertyOrigin.Inherited)]
        public Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IResourceProviderAuthorization[] ProviderAuthorization { get => ((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IProviderHubMetadataInternal)__providerHubMetadata).ProviderAuthorization; set => ((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IProviderHubMetadataInternal)__providerHubMetadata).ProviderAuthorization = value ?? null /* arrayOf */; }

        [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Origin(Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.PropertyOrigin.Inherited)]
        public Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IThirdPartyProviderAuthorization ThirdPartyProviderAuthorization { get => ((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IProviderHubMetadataInternal)__providerHubMetadata).ThirdPartyProviderAuthorization; set => ((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IProviderHubMetadataInternal)__providerHubMetadata).ThirdPartyProviderAuthorization = value ?? null /* model class */; }

        [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Origin(Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.PropertyOrigin.Inherited)]
        public Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.ILightHouseAuthorization[] ThirdPartyProviderAuthorizationAuthorization { get => ((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IProviderHubMetadataInternal)__providerHubMetadata).ThirdPartyProviderAuthorizationAuthorization; set => ((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IProviderHubMetadataInternal)__providerHubMetadata).ThirdPartyProviderAuthorizationAuthorization = value ?? null /* arrayOf */; }

        [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Origin(Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.PropertyOrigin.Inherited)]
        public string ThirdPartyProviderAuthorizationManagedByTenantId { get => ((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IProviderHubMetadataInternal)__providerHubMetadata).ThirdPartyProviderAuthorizationManagedByTenantId; set => ((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IProviderHubMetadataInternal)__providerHubMetadata).ThirdPartyProviderAuthorizationManagedByTenantId = value ?? null; }

        /// <summary>
        /// Creates an new <see cref="ProviderRegistrationPropertiesProviderHubMetadata" /> instance.
        /// </summary>
        public ProviderRegistrationPropertiesProviderHubMetadata()
        {

        }

        /// <summary>Validates that this object meets the validation criteria.</summary>
        /// <param name="eventListener">an <see cref="Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.IEventListener" /> instance that will receive validation
        /// events.</param>
        /// <returns>
        /// A < see cref = "global::System.Threading.Tasks.Task" /> that will be complete when validation is completed.
        /// </returns>
        public async global::System.Threading.Tasks.Task Validate(Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.IEventListener eventListener)
        {
            await eventListener.AssertNotNull(nameof(__providerHubMetadata), __providerHubMetadata);
            await eventListener.AssertObjectIsValid(nameof(__providerHubMetadata), __providerHubMetadata);
        }
    }
    public partial interface IProviderRegistrationPropertiesProviderHubMetadata :
        Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IProviderHubMetadata
    {

    }
    internal partial interface IProviderRegistrationPropertiesProviderHubMetadataInternal :
        Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IProviderHubMetadataInternal
    {

    }
}