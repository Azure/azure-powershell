namespace Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120
{
    using static Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.Extensions;

    public partial class ResourceTypeRegistrationPropertiesResourceMovePolicy :
        Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IResourceTypeRegistrationPropertiesResourceMovePolicy,
        Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IResourceTypeRegistrationPropertiesResourceMovePolicyInternal,
        Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.IValidates
    {
        /// <summary>
        /// Backing field for Inherited model <see cref= "Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IResourceMovePolicy"
        /// />
        /// </summary>
        private Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IResourceMovePolicy __resourceMovePolicy = new Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.ResourceMovePolicy();

        [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Origin(Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.PropertyOrigin.Inherited)]
        public bool? CrossResourceGroupMoveEnabled { get => ((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IResourceMovePolicyInternal)__resourceMovePolicy).CrossResourceGroupMoveEnabled; set => ((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IResourceMovePolicyInternal)__resourceMovePolicy).CrossResourceGroupMoveEnabled = value ?? default(bool); }

        [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Origin(Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.PropertyOrigin.Inherited)]
        public bool? CrossSubscriptionMoveEnabled { get => ((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IResourceMovePolicyInternal)__resourceMovePolicy).CrossSubscriptionMoveEnabled; set => ((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IResourceMovePolicyInternal)__resourceMovePolicy).CrossSubscriptionMoveEnabled = value ?? default(bool); }

        [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Origin(Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.PropertyOrigin.Inherited)]
        public bool? ValidationRequired { get => ((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IResourceMovePolicyInternal)__resourceMovePolicy).ValidationRequired; set => ((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IResourceMovePolicyInternal)__resourceMovePolicy).ValidationRequired = value ?? default(bool); }

        /// <summary>
        /// Creates an new <see cref="ResourceTypeRegistrationPropertiesResourceMovePolicy" /> instance.
        /// </summary>
        public ResourceTypeRegistrationPropertiesResourceMovePolicy()
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
            await eventListener.AssertNotNull(nameof(__resourceMovePolicy), __resourceMovePolicy);
            await eventListener.AssertObjectIsValid(nameof(__resourceMovePolicy), __resourceMovePolicy);
        }
    }
    public partial interface IResourceTypeRegistrationPropertiesResourceMovePolicy :
        Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IResourceMovePolicy
    {

    }
    internal partial interface IResourceTypeRegistrationPropertiesResourceMovePolicyInternal :
        Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IResourceMovePolicyInternal
    {

    }
}