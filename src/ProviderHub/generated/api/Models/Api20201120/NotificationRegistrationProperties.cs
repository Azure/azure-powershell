namespace Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120
{
    using static Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.Extensions;

    public partial class NotificationRegistrationProperties :
        Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.INotificationRegistrationProperties,
        Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.INotificationRegistrationPropertiesInternal
    {

        /// <summary>Backing field for <see cref="IncludedEvent" /> property.</summary>
        private string[] _includedEvent;

        [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Origin(Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.PropertyOrigin.Owned)]
        public string[] IncludedEvent { get => this._includedEvent; set => this._includedEvent = value; }

        /// <summary>Backing field for <see cref="MessageScope" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Support.MessageScope? _messageScope;

        [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Origin(Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Support.MessageScope? MessageScope { get => this._messageScope; set => this._messageScope = value; }

        /// <summary>Backing field for <see cref="NotificationEndpoint" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.INotificationEndpoint[] _notificationEndpoint;

        [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Origin(Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.INotificationEndpoint[] NotificationEndpoint { get => this._notificationEndpoint; set => this._notificationEndpoint = value; }

        /// <summary>Backing field for <see cref="NotificationMode" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Support.NotificationMode? _notificationMode;

        [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Origin(Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Support.NotificationMode? NotificationMode { get => this._notificationMode; set => this._notificationMode = value; }

        /// <summary>Creates an new <see cref="NotificationRegistrationProperties" /> instance.</summary>
        public NotificationRegistrationProperties()
        {

        }
    }
    public partial interface INotificationRegistrationProperties :
        Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.IJsonSerializable
    {
        [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"",
        SerializedName = @"includedEvents",
        PossibleTypes = new [] { typeof(string) })]
        string[] IncludedEvent { get; set; }

        [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"",
        SerializedName = @"messageScope",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Support.MessageScope) })]
        Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Support.MessageScope? MessageScope { get; set; }

        [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"",
        SerializedName = @"notificationEndpoints",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.INotificationEndpoint) })]
        Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.INotificationEndpoint[] NotificationEndpoint { get; set; }

        [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"",
        SerializedName = @"notificationMode",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Support.NotificationMode) })]
        Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Support.NotificationMode? NotificationMode { get; set; }

    }
    internal partial interface INotificationRegistrationPropertiesInternal

    {
        string[] IncludedEvent { get; set; }

        Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Support.MessageScope? MessageScope { get; set; }

        Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.INotificationEndpoint[] NotificationEndpoint { get; set; }

        Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Support.NotificationMode? NotificationMode { get; set; }

    }
}