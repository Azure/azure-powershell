namespace Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Extensions;

    /// <summary>Response for ListNatGateways API service call.</summary>
    public partial class NatGatewayListResult :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.INatGatewayListResult,
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.INatGatewayListResultInternal
    {

        /// <summary>Backing field for <see cref="NextLink" /> property.</summary>
        private string _nextLink;

        /// <summary>The URL to get the next set of results.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public string NextLink { get => this._nextLink; set => this._nextLink = value; }

        /// <summary>Backing field for <see cref="Value" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.INatGateway[] _value;

        /// <summary>A list of Nat Gateways that exists in a resource group.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.INatGateway[] Value { get => this._value; set => this._value = value; }

        /// <summary>Creates an new <see cref="NatGatewayListResult" /> instance.</summary>
        public NatGatewayListResult()
        {

        }
    }
    /// Response for ListNatGateways API service call.
    public partial interface INatGatewayListResult :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.IJsonSerializable
    {
        /// <summary>The URL to get the next set of results.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The URL to get the next set of results.",
        SerializedName = @"nextLink",
        PossibleTypes = new [] { typeof(string) })]
        string NextLink { get; set; }
        /// <summary>A list of Nat Gateways that exists in a resource group.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"A list of Nat Gateways that exists in a resource group.",
        SerializedName = @"value",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.INatGateway) })]
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.INatGateway[] Value { get; set; }

    }
    /// Response for ListNatGateways API service call.
    internal partial interface INatGatewayListResultInternal

    {
        /// <summary>The URL to get the next set of results.</summary>
        string NextLink { get; set; }
        /// <summary>A list of Nat Gateways that exists in a resource group.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.INatGateway[] Value { get; set; }

    }
}