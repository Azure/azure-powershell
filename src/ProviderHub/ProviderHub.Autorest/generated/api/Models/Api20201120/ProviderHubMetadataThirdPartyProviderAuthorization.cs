namespace Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120
{
    using static Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.Extensions;

    public partial class ProviderHubMetadataThirdPartyProviderAuthorization :
        Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IProviderHubMetadataThirdPartyProviderAuthorization,
        Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IProviderHubMetadataThirdPartyProviderAuthorizationInternal,
        Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.IValidates
    {
        /// <summary>
        /// Backing field for Inherited model <see cref= "Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IThirdPartyProviderAuthorization"
        /// />
        /// </summary>
        private Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IThirdPartyProviderAuthorization __thirdPartyProviderAuthorization = new Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.ThirdPartyProviderAuthorization();

        [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Origin(Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.PropertyOrigin.Inherited)]
        public Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.ILightHouseAuthorization[] Authorization { get => ((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IThirdPartyProviderAuthorizationInternal)__thirdPartyProviderAuthorization).Authorization; set => ((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IThirdPartyProviderAuthorizationInternal)__thirdPartyProviderAuthorization).Authorization = value ?? null /* arrayOf */; }

        [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Origin(Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.PropertyOrigin.Inherited)]
        public string ManagedByTenantId { get => ((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IThirdPartyProviderAuthorizationInternal)__thirdPartyProviderAuthorization).ManagedByTenantId; set => ((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IThirdPartyProviderAuthorizationInternal)__thirdPartyProviderAuthorization).ManagedByTenantId = value ?? null; }

        /// <summary>
        /// Creates an new <see cref="ProviderHubMetadataThirdPartyProviderAuthorization" /> instance.
        /// </summary>
        public ProviderHubMetadataThirdPartyProviderAuthorization()
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
            await eventListener.AssertNotNull(nameof(__thirdPartyProviderAuthorization), __thirdPartyProviderAuthorization);
            await eventListener.AssertObjectIsValid(nameof(__thirdPartyProviderAuthorization), __thirdPartyProviderAuthorization);
        }
    }
    public partial interface IProviderHubMetadataThirdPartyProviderAuthorization :
        Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IThirdPartyProviderAuthorization
    {

    }
    internal partial interface IProviderHubMetadataThirdPartyProviderAuthorizationInternal :
        Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IThirdPartyProviderAuthorizationInternal
    {

    }
}