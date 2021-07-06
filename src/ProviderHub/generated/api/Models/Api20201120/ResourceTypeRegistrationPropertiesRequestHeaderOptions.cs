namespace Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120
{
    using static Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.Extensions;

    public partial class ResourceTypeRegistrationPropertiesRequestHeaderOptions :
        Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IResourceTypeRegistrationPropertiesRequestHeaderOptions,
        Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IResourceTypeRegistrationPropertiesRequestHeaderOptionsInternal,
        Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.IValidates
    {
        /// <summary>
        /// Backing field for Inherited model <see cref= "Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IRequestHeaderOptions"
        /// />
        /// </summary>
        private Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IRequestHeaderOptions __requestHeaderOptions = new Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.RequestHeaderOptions();

        [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Origin(Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.PropertyOrigin.Inherited)]
        public Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Support.OptInHeaderType? OptInHeader { get => ((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IRequestHeaderOptionsInternal)__requestHeaderOptions).OptInHeader; set => ((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IRequestHeaderOptionsInternal)__requestHeaderOptions).OptInHeader = value ?? ((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Support.OptInHeaderType)""); }

        /// <summary>
        /// Creates an new <see cref="ResourceTypeRegistrationPropertiesRequestHeaderOptions" /> instance.
        /// </summary>
        public ResourceTypeRegistrationPropertiesRequestHeaderOptions()
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
            await eventListener.AssertNotNull(nameof(__requestHeaderOptions), __requestHeaderOptions);
            await eventListener.AssertObjectIsValid(nameof(__requestHeaderOptions), __requestHeaderOptions);
        }
    }
    public partial interface IResourceTypeRegistrationPropertiesRequestHeaderOptions :
        Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IRequestHeaderOptions
    {

    }
    internal partial interface IResourceTypeRegistrationPropertiesRequestHeaderOptionsInternal :
        Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IRequestHeaderOptionsInternal
    {

    }
}