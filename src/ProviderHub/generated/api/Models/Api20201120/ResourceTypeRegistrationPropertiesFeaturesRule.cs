namespace Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120
{
    using static Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.Extensions;

    public partial class ResourceTypeRegistrationPropertiesFeaturesRule :
        Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IResourceTypeRegistrationPropertiesFeaturesRule,
        Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IResourceTypeRegistrationPropertiesFeaturesRuleInternal,
        Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.IValidates
    {
        /// <summary>
        /// Backing field for Inherited model <see cref= "Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IFeaturesRule"
        /// />
        /// </summary>
        private Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IFeaturesRule __featuresRule = new Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.FeaturesRule();

        [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Origin(Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.PropertyOrigin.Inherited)]
        public string RequiredFeaturesPolicy { get => ((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IFeaturesRuleInternal)__featuresRule).RequiredFeaturesPolicy; set => ((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IFeaturesRuleInternal)__featuresRule).RequiredFeaturesPolicy = value ; }

        /// <summary>
        /// Creates an new <see cref="ResourceTypeRegistrationPropertiesFeaturesRule" /> instance.
        /// </summary>
        public ResourceTypeRegistrationPropertiesFeaturesRule()
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
            await eventListener.AssertNotNull(nameof(__featuresRule), __featuresRule);
            await eventListener.AssertObjectIsValid(nameof(__featuresRule), __featuresRule);
        }
    }
    public partial interface IResourceTypeRegistrationPropertiesFeaturesRule :
        Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IFeaturesRule
    {

    }
    internal partial interface IResourceTypeRegistrationPropertiesFeaturesRuleInternal :
        Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IFeaturesRuleInternal
    {

    }
}