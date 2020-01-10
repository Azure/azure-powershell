namespace Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20150615
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Extensions;

    /// <summary>Response for ListArpTable associated with the Express Route Circuits API.</summary>
    public partial class ExpressRouteCircuitsArpTableListResult :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20150615.IExpressRouteCircuitsArpTableListResult,
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20150615.IExpressRouteCircuitsArpTableListResultInternal
    {

        /// <summary>Backing field for <see cref="NextLink" /> property.</summary>
        private string _nextLink;

        /// <summary>The URL to get the next set of results.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public string NextLink { get => this._nextLink; set => this._nextLink = value; }

        /// <summary>Backing field for <see cref="Value" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20150615.IExpressRouteCircuitArpTable[] _value;

        /// <summary>Gets list of the ARP table.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20150615.IExpressRouteCircuitArpTable[] Value { get => this._value; set => this._value = value; }

        /// <summary>Creates an new <see cref="ExpressRouteCircuitsArpTableListResult" /> instance.</summary>
        public ExpressRouteCircuitsArpTableListResult()
        {

        }
    }
    /// Response for ListArpTable associated with the Express Route Circuits API.
    public partial interface IExpressRouteCircuitsArpTableListResult :
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
        /// <summary>Gets list of the ARP table.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Gets list of the ARP table.",
        SerializedName = @"value",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20150615.IExpressRouteCircuitArpTable) })]
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20150615.IExpressRouteCircuitArpTable[] Value { get; set; }

    }
    /// Response for ListArpTable associated with the Express Route Circuits API.
    internal partial interface IExpressRouteCircuitsArpTableListResultInternal

    {
        /// <summary>The URL to get the next set of results.</summary>
        string NextLink { get; set; }
        /// <summary>Gets list of the ARP table.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20150615.IExpressRouteCircuitArpTable[] Value { get; set; }

    }
}