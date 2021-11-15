namespace Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120
{
    using static Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.Extensions;

    public partial class SubscriptionLifecycleNotificationSpecifications :
        Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.ISubscriptionLifecycleNotificationSpecifications,
        Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.ISubscriptionLifecycleNotificationSpecificationsInternal
    {

        /// <summary>Backing field for <see cref="SoftDeleteTtl" /> property.</summary>
        private global::System.TimeSpan? _softDeleteTtl;

        [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Origin(Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.PropertyOrigin.Owned)]
        public global::System.TimeSpan? SoftDeleteTtl { get => this._softDeleteTtl; set => this._softDeleteTtl = value; }

        /// <summary>Backing field for <see cref="SubscriptionStateOverrideAction" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.ISubscriptionStateOverrideAction[] _subscriptionStateOverrideAction;

        [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Origin(Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.ISubscriptionStateOverrideAction[] SubscriptionStateOverrideAction { get => this._subscriptionStateOverrideAction; set => this._subscriptionStateOverrideAction = value; }

        /// <summary>
        /// Creates an new <see cref="SubscriptionLifecycleNotificationSpecifications" /> instance.
        /// </summary>
        public SubscriptionLifecycleNotificationSpecifications()
        {

        }
    }
    public partial interface ISubscriptionLifecycleNotificationSpecifications :
        Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.IJsonSerializable
    {
        [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"",
        SerializedName = @"softDeleteTTL",
        PossibleTypes = new [] { typeof(global::System.TimeSpan) })]
        global::System.TimeSpan? SoftDeleteTtl { get; set; }

        [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"",
        SerializedName = @"subscriptionStateOverrideActions",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.ISubscriptionStateOverrideAction) })]
        Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.ISubscriptionStateOverrideAction[] SubscriptionStateOverrideAction { get; set; }

    }
    internal partial interface ISubscriptionLifecycleNotificationSpecificationsInternal

    {
        global::System.TimeSpan? SoftDeleteTtl { get; set; }

        Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.ISubscriptionStateOverrideAction[] SubscriptionStateOverrideAction { get; set; }

    }
}