namespace Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Extensions;

    /// <summary>
    /// Result of the request to list all vpn connections to a virtual wan vpn gateway. It contains a list of Vpn Connections
    /// and a URL nextLink to get the next set of results.
    /// </summary>
    public partial class ListVpnConnectionsResult :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IListVpnConnectionsResult,
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IListVpnConnectionsResultInternal
    {

        /// <summary>Backing field for <see cref="NextLink" /> property.</summary>
        private string _nextLink;

        /// <summary>URL to get the next set of operation list results if there are any.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public string NextLink { get => this._nextLink; set => this._nextLink = value; }

        /// <summary>Backing field for <see cref="Value" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVpnConnection[] _value;

        /// <summary>List of Vpn Connections.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVpnConnection[] Value { get => this._value; set => this._value = value; }

        /// <summary>Creates an new <see cref="ListVpnConnectionsResult" /> instance.</summary>
        public ListVpnConnectionsResult()
        {

        }
    }
    /// Result of the request to list all vpn connections to a virtual wan vpn gateway. It contains a list of Vpn Connections
    /// and a URL nextLink to get the next set of results.
    public partial interface IListVpnConnectionsResult :
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
        /// <summary>List of Vpn Connections.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"List of Vpn Connections.",
        SerializedName = @"value",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVpnConnection) })]
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVpnConnection[] Value { get; set; }

    }
    /// Result of the request to list all vpn connections to a virtual wan vpn gateway. It contains a list of Vpn Connections
    /// and a URL nextLink to get the next set of results.
    internal partial interface IListVpnConnectionsResultInternal

    {
        /// <summary>URL to get the next set of operation list results if there are any.</summary>
        string NextLink { get; set; }
        /// <summary>List of Vpn Connections.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVpnConnection[] Value { get; set; }

    }
}