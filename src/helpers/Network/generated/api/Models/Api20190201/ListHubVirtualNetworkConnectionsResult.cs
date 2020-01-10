namespace Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Extensions;

    /// <summary>
    /// List of HubVirtualNetworkConnections and a URL nextLink to get the next set of results.
    /// </summary>
    public partial class ListHubVirtualNetworkConnectionsResult :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IListHubVirtualNetworkConnectionsResult,
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IListHubVirtualNetworkConnectionsResultInternal
    {

        /// <summary>Backing field for <see cref="NextLink" /> property.</summary>
        private string _nextLink;

        /// <summary>URL to get the next set of operation list results if there are any.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public string NextLink { get => this._nextLink; set => this._nextLink = value; }

        /// <summary>Backing field for <see cref="Value" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IHubVirtualNetworkConnection[] _value;

        /// <summary>List of HubVirtualNetworkConnections.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IHubVirtualNetworkConnection[] Value { get => this._value; set => this._value = value; }

        /// <summary>Creates an new <see cref="ListHubVirtualNetworkConnectionsResult" /> instance.</summary>
        public ListHubVirtualNetworkConnectionsResult()
        {

        }
    }
    /// List of HubVirtualNetworkConnections and a URL nextLink to get the next set of results.
    public partial interface IListHubVirtualNetworkConnectionsResult :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.IJsonSerializable
    {
        /// <summary>URL to get the next set of operation list results if there are any.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"URL to get the next set of operation list results if there are any.",
        SerializedName = @"nextLink",
        PossibleTypes = new [] { typeof(string) })]
        string NextLink { get; set; }
        /// <summary>List of HubVirtualNetworkConnections.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"List of HubVirtualNetworkConnections.",
        SerializedName = @"value",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IHubVirtualNetworkConnection) })]
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IHubVirtualNetworkConnection[] Value { get; set; }

    }
    /// List of HubVirtualNetworkConnections and a URL nextLink to get the next set of results.
    internal partial interface IListHubVirtualNetworkConnectionsResultInternal

    {
        /// <summary>URL to get the next set of operation list results if there are any.</summary>
        string NextLink { get; set; }
        /// <summary>List of HubVirtualNetworkConnections.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IHubVirtualNetworkConnection[] Value { get; set; }

    }
}