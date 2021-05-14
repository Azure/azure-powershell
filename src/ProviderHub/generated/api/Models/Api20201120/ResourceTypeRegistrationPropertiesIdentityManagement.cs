namespace Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120
{
    using static Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.Extensions;

    public partial class ResourceTypeRegistrationPropertiesIdentityManagement :
        Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IResourceTypeRegistrationPropertiesIdentityManagement,
        Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IResourceTypeRegistrationPropertiesIdentityManagementInternal,
        Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.IValidates
    {
        /// <summary>
        /// Backing field for Inherited model <see cref= "Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IIdentityManagementProperties"
        /// />
        /// </summary>
        private Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IIdentityManagementProperties __identityManagementProperties = new Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IdentityManagementProperties();

        [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Origin(Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.PropertyOrigin.Inherited)]
        public string ApplicationId { get => ((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IIdentityManagementPropertiesInternal)__identityManagementProperties).ApplicationId; set => ((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IIdentityManagementPropertiesInternal)__identityManagementProperties).ApplicationId = value ?? null; }

        [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Origin(Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.PropertyOrigin.Inherited)]
        public Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Support.IdentityManagementTypes? Type { get => ((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IIdentityManagementPropertiesInternal)__identityManagementProperties).Type; set => ((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IIdentityManagementPropertiesInternal)__identityManagementProperties).Type = value ?? ((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Support.IdentityManagementTypes)""); }

        /// <summary>
        /// Creates an new <see cref="ResourceTypeRegistrationPropertiesIdentityManagement" /> instance.
        /// </summary>
        public ResourceTypeRegistrationPropertiesIdentityManagement()
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
            await eventListener.AssertNotNull(nameof(__identityManagementProperties), __identityManagementProperties);
            await eventListener.AssertObjectIsValid(nameof(__identityManagementProperties), __identityManagementProperties);
        }
    }
    public partial interface IResourceTypeRegistrationPropertiesIdentityManagement :
        Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IIdentityManagementProperties
    {

    }
    internal partial interface IResourceTypeRegistrationPropertiesIdentityManagementInternal :
        Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IIdentityManagementPropertiesInternal
    {

    }
}