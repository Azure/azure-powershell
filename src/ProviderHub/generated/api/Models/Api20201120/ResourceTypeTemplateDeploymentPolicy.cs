namespace Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120
{
    using static Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.Extensions;

    public partial class ResourceTypeTemplateDeploymentPolicy :
        Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IResourceTypeTemplateDeploymentPolicy,
        Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IResourceTypeTemplateDeploymentPolicyInternal,
        Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.IValidates
    {
        /// <summary>
        /// Backing field for Inherited model <see cref= "Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.ITemplateDeploymentPolicy"
        /// />
        /// </summary>
        private Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.ITemplateDeploymentPolicy __templateDeploymentPolicy = new Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.TemplateDeploymentPolicy();

        [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Origin(Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.PropertyOrigin.Inherited)]
        public Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Support.TemplateDeploymentCapabilities Capability { get => ((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.ITemplateDeploymentPolicyInternal)__templateDeploymentPolicy).Capability; set => ((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.ITemplateDeploymentPolicyInternal)__templateDeploymentPolicy).Capability = value ; }

        [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Origin(Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.PropertyOrigin.Inherited)]
        public Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Support.TemplateDeploymentPreflightOptions PreflightOption { get => ((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.ITemplateDeploymentPolicyInternal)__templateDeploymentPolicy).PreflightOption; set => ((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.ITemplateDeploymentPolicyInternal)__templateDeploymentPolicy).PreflightOption = value ; }

        /// <summary>Creates an new <see cref="ResourceTypeTemplateDeploymentPolicy" /> instance.</summary>
        public ResourceTypeTemplateDeploymentPolicy()
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
            await eventListener.AssertNotNull(nameof(__templateDeploymentPolicy), __templateDeploymentPolicy);
            await eventListener.AssertObjectIsValid(nameof(__templateDeploymentPolicy), __templateDeploymentPolicy);
        }
    }
    public partial interface IResourceTypeTemplateDeploymentPolicy :
        Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.ITemplateDeploymentPolicy
    {

    }
    internal partial interface IResourceTypeTemplateDeploymentPolicyInternal :
        Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.ITemplateDeploymentPolicyInternal
    {

    }
}