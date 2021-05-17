namespace Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120
{
    using static Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.Extensions;

    public partial class NotificationEndpoint :
        Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.INotificationEndpoint,
        Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.INotificationEndpointInternal
    {

        /// <summary>Backing field for <see cref="Location" /> property.</summary>
        private string[] _location;

        [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Origin(Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.PropertyOrigin.Owned)]
        public string[] Location { get => this._location; set => this._location = value; }

        /// <summary>Backing field for <see cref="NotificationDestination" /> property.</summary>
        private string _notificationDestination;

        [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Origin(Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.PropertyOrigin.Owned)]
        public string NotificationDestination { get => this._notificationDestination; set => this._notificationDestination = value; }

        /// <summary>Creates an new <see cref="NotificationEndpoint" /> instance.</summary>
        public NotificationEndpoint()
        {

        }
    }
    public partial interface INotificationEndpoint :
        Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.IJsonSerializable
    {
        [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"",
        SerializedName = @"locations",
        PossibleTypes = new [] { typeof(string) })]
        string[] Location { get; set; }

        [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"",
        SerializedName = @"notificationDestination",
        PossibleTypes = new [] { typeof(string) })]
        string NotificationDestination { get; set; }

    }
    internal partial interface INotificationEndpointInternal

    {
        string[] Location { get; set; }

        string NotificationDestination { get; set; }

    }
}