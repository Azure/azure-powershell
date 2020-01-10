namespace Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Extensions;

    /// <summary>
    /// Result of the request to list P2SVpnGateways. It contains a list of P2SVpnGateways and a URL nextLink to get the next
    /// set of results.
    /// </summary>
    public partial class ListP2SVpnGatewaysResult :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IListP2SVpnGatewaysResult,
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IListP2SVpnGatewaysResultInternal
    {

        /// <summary>Backing field for <see cref="NextLink" /> property.</summary>
        private string _nextLink;

        /// <summary>URL to get the next set of operation list results if there are any.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public string NextLink { get => this._nextLink; set => this._nextLink = value; }

        /// <summary>Backing field for <see cref="Value" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IP2SVpnGateway[] _value;

        /// <summary>List of P2SVpnGateways.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IP2SVpnGateway[] Value { get => this._value; set => this._value = value; }

        /// <summary>Creates an new <see cref="ListP2SVpnGatewaysResult" /> instance.</summary>
        public ListP2SVpnGatewaysResult()
        {

        }
    }
    /// Result of the request to list P2SVpnGateways. It contains a list of P2SVpnGateways and a URL nextLink to get the next
    /// set of results.
    public partial interface IListP2SVpnGatewaysResult :
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
        /// <summary>List of P2SVpnGateways.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"List of P2SVpnGateways.",
        SerializedName = @"value",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IP2SVpnGateway) })]
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IP2SVpnGateway[] Value { get; set; }

    }
    /// Result of the request to list P2SVpnGateways. It contains a list of P2SVpnGateways and a URL nextLink to get the next
    /// set of results.
    internal partial interface IListP2SVpnGatewaysResultInternal

    {
        /// <summary>URL to get the next set of operation list results if there are any.</summary>
        string NextLink { get; set; }
        /// <summary>List of P2SVpnGateways.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IP2SVpnGateway[] Value { get; set; }

    }
}