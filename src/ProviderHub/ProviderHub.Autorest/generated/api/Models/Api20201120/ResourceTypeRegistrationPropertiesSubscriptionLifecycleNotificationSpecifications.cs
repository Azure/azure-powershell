namespace Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120
{
    using static Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.Extensions;

    public partial class ResourceTypeRegistrationPropertiesSubscriptionLifecycleNotificationSpecifications :
        Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IResourceTypeRegistrationPropertiesSubscriptionLifecycleNotificationSpecifications,
        Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IResourceTypeRegistrationPropertiesSubscriptionLifecycleNotificationSpecificationsInternal,
        Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.IValidates
    {
        /// <summary>
        /// Backing field for Inherited model <see cref= "Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.ISubscriptionLifecycleNotificationSpecifications"
        /// />
        /// </summary>
        private Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.ISubscriptionLifecycleNotificationSpecifications __subscriptionLifecycleNotificationSpecifications = new Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.SubscriptionLifecycleNotificationSpecifications();

        [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Origin(Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.PropertyOrigin.Inherited)]
        public global::System.TimeSpan? SoftDeleteTtl { get => ((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.ISubscriptionLifecycleNotificationSpecificationsInternal)__subscriptionLifecycleNotificationSpecifications).SoftDeleteTtl; set => ((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.ISubscriptionLifecycleNotificationSpecificationsInternal)__subscriptionLifecycleNotificationSpecifications).SoftDeleteTtl = value ?? default(global::System.TimeSpan); }

        [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Origin(Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.PropertyOrigin.Inherited)]
        public Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.ISubscriptionStateOverrideAction[] SubscriptionStateOverrideAction { get => ((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.ISubscriptionLifecycleNotificationSpecificationsInternal)__subscriptionLifecycleNotificationSpecifications).SubscriptionStateOverrideAction; set => ((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.ISubscriptionLifecycleNotificationSpecificationsInternal)__subscriptionLifecycleNotificationSpecifications).SubscriptionStateOverrideAction = value ?? null /* arrayOf */; }

        /// <summary>
        /// Creates an new <see cref="ResourceTypeRegistrationPropertiesSubscriptionLifecycleNotificationSpecifications" /> instance.
        /// </summary>
        public ResourceTypeRegistrationPropertiesSubscriptionLifecycleNotificationSpecifications()
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
            await eventListener.AssertNotNull(nameof(__subscriptionLifecycleNotificationSpecifications), __subscriptionLifecycleNotificationSpecifications);
            await eventListener.AssertObjectIsValid(nameof(__subscriptionLifecycleNotificationSpecifications), __subscriptionLifecycleNotificationSpecifications);
        }
    }
    public partial interface IResourceTypeRegistrationPropertiesSubscriptionLifecycleNotificationSpecifications :
        Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.ISubscriptionLifecycleNotificationSpecifications
    {

    }
    internal partial interface IResourceTypeRegistrationPropertiesSubscriptionLifecycleNotificationSpecificationsInternal :
        Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.ISubscriptionLifecycleNotificationSpecificationsInternal
    {

    }
}