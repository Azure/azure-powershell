namespace Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Extensions;

    /// <summary>
    /// Result of the request to list VpnGateways. It contains a list of VpnGateways and a URL nextLink to get the next set of
    /// results.
    /// </summary>
    public partial class ListVpnGatewaysResult :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IListVpnGatewaysResult,
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IListVpnGatewaysResultInternal
    {

        /// <summary>Backing field for <see cref="NextLink" /> property.</summary>
        private string _nextLink;

        /// <summary>URL to get the next set of operation list results if there are any.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public string NextLink { get => this._nextLink; set => this._nextLink = value; }

        /// <summary>Backing field for <see cref="Value" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVpnGateway[] _value;

        /// <summary>List of VpnGateways.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVpnGateway[] Value { get => this._value; set => this._value = value; }

        /// <summary>Creates an new <see cref="ListVpnGatewaysResult" /> instance.</summary>
        public ListVpnGatewaysResult()
        {

        }
    }
    /// Result of the request to list VpnGateways. It contains a list of VpnGateways and a URL nextLink to get the next set of
    /// results.
    public partial interface IListVpnGatewaysResult :
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
        /// <summary>List of VpnGateways.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"List of VpnGateways.",
        SerializedName = @"value",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVpnGateway) })]
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVpnGateway[] Value { get; set; }

    }
    /// Result of the request to list VpnGateways. It contains a list of VpnGateways and a URL nextLink to get the next set of
    /// results.
    internal partial interface IListVpnGatewaysResultInternal

    {
        /// <summary>URL to get the next set of operation list results if there are any.</summary>
        string NextLink { get; set; }
        /// <summary>List of VpnGateways.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVpnGateway[] Value { get; set; }

    }
}