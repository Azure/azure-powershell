namespace Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Extensions;

    /// <summary>Response for ListNetworkWatchers API service call.</summary>
    public partial class NetworkWatcherListResult :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.INetworkWatcherListResult,
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.INetworkWatcherListResultInternal
    {

        /// <summary>Backing field for <see cref="Value" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.INetworkWatcher[] _value;

        /// <summary>List of network watcher resources.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.INetworkWatcher[] Value { get => this._value; set => this._value = value; }

        /// <summary>Creates an new <see cref="NetworkWatcherListResult" /> instance.</summary>
        public NetworkWatcherListResult()
        {

        }
    }
    /// Response for ListNetworkWatchers API service call.
    public partial interface INetworkWatcherListResult :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.IJsonSerializable
    {
        /// <summary>List of network watcher resources.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"List of network watcher resources.",
        SerializedName = @"value",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.INetworkWatcher) })]
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.INetworkWatcher[] Value { get; set; }

    }
    /// Response for ListNetworkWatchers API service call.
    internal partial interface INetworkWatcherListResultInternal

    {
        /// <summary>List of network watcher resources.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.INetworkWatcher[] Value { get; set; }

    }
}