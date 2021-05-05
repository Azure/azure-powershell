namespace Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120
{
    using static Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.Extensions;

    public partial class ResourceTypeIdentityManagement :
        Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IResourceTypeIdentityManagement,
        Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IResourceTypeIdentityManagementInternal,
        Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.IValidates
    {
        /// <summary>
        /// Backing field for Inherited model <see cref= "Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IIdentityManagement"
        /// />
        /// </summary>
        private Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IIdentityManagement __identityManagement = new Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IdentityManagement();

        [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Origin(Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.PropertyOrigin.Inherited)]
        public Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Support.IdentityManagementTypes? Type { get => ((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IIdentityManagementInternal)__identityManagement).Type; set => ((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IIdentityManagementInternal)__identityManagement).Type = value ?? ((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Support.IdentityManagementTypes)""); }

        /// <summary>Creates an new <see cref="ResourceTypeIdentityManagement" /> instance.</summary>
        public ResourceTypeIdentityManagement()
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
            await eventListener.AssertNotNull(nameof(__identityManagement), __identityManagement);
            await eventListener.AssertObjectIsValid(nameof(__identityManagement), __identityManagement);
        }
    }
    public partial interface IResourceTypeIdentityManagement :
        Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IIdentityManagement
    {

    }
    internal partial interface IResourceTypeIdentityManagementInternal :
        Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IIdentityManagementInternal
    {

    }
}