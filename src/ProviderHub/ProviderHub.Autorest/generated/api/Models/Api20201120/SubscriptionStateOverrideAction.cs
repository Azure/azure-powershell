namespace Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120
{
    using static Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.Extensions;

    public partial class SubscriptionStateOverrideAction :
        Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.ISubscriptionStateOverrideAction,
        Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.ISubscriptionStateOverrideActionInternal
    {

        /// <summary>Backing field for <see cref="Action" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Support.SubscriptionNotificationOperation _action;

        [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Origin(Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Support.SubscriptionNotificationOperation Action { get => this._action; set => this._action = value; }

        /// <summary>Backing field for <see cref="State" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Support.SubscriptionTransitioningState _state;

        [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Origin(Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Support.SubscriptionTransitioningState State { get => this._state; set => this._state = value; }

        /// <summary>Creates an new <see cref="SubscriptionStateOverrideAction" /> instance.</summary>
        public SubscriptionStateOverrideAction()
        {

        }
    }
    public partial interface ISubscriptionStateOverrideAction :
        Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.IJsonSerializable
    {
        [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"",
        SerializedName = @"action",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Support.SubscriptionNotificationOperation) })]
        Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Support.SubscriptionNotificationOperation Action { get; set; }

        [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"",
        SerializedName = @"state",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Support.SubscriptionTransitioningState) })]
        Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Support.SubscriptionTransitioningState State { get; set; }

    }
    internal partial interface ISubscriptionStateOverrideActionInternal

    {
        Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Support.SubscriptionNotificationOperation Action { get; set; }

        Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Support.SubscriptionTransitioningState State { get; set; }

    }
}