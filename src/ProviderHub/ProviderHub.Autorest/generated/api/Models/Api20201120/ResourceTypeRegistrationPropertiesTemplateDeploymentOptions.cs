namespace Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120
{
    using static Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.Extensions;

    public partial class ResourceTypeRegistrationPropertiesTemplateDeploymentOptions :
        Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IResourceTypeRegistrationPropertiesTemplateDeploymentOptions,
        Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IResourceTypeRegistrationPropertiesTemplateDeploymentOptionsInternal,
        Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.IValidates
    {
        /// <summary>
        /// Backing field for Inherited model <see cref= "Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.ITemplateDeploymentOptions"
        /// />
        /// </summary>
        private Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.ITemplateDeploymentOptions __templateDeploymentOptions = new Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.TemplateDeploymentOptions();

        [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Origin(Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.PropertyOrigin.Inherited)]
        public Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Support.PreflightOption[] PreflightOption { get => ((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.ITemplateDeploymentOptionsInternal)__templateDeploymentOptions).PreflightOption; set => ((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.ITemplateDeploymentOptionsInternal)__templateDeploymentOptions).PreflightOption = value ?? null /* arrayOf */; }

        [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Origin(Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.PropertyOrigin.Inherited)]
        public bool? PreflightSupported { get => ((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.ITemplateDeploymentOptionsInternal)__templateDeploymentOptions).PreflightSupported; set => ((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.ITemplateDeploymentOptionsInternal)__templateDeploymentOptions).PreflightSupported = value ?? default(bool); }

        /// <summary>
        /// Creates an new <see cref="ResourceTypeRegistrationPropertiesTemplateDeploymentOptions" /> instance.
        /// </summary>
        public ResourceTypeRegistrationPropertiesTemplateDeploymentOptions()
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
            await eventListener.AssertNotNull(nameof(__templateDeploymentOptions), __templateDeploymentOptions);
            await eventListener.AssertObjectIsValid(nameof(__templateDeploymentOptions), __templateDeploymentOptions);
        }
    }
    public partial interface IResourceTypeRegistrationPropertiesTemplateDeploymentOptions :
        Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.ITemplateDeploymentOptions
    {

    }
    internal partial interface IResourceTypeRegistrationPropertiesTemplateDeploymentOptionsInternal :
        Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.ITemplateDeploymentOptionsInternal
    {

    }
}