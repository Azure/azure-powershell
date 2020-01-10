namespace Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20150501Preview
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Extensions;

    /// <summary>Response for ListStats from Express Route Circuits Api service call</summary>
    public partial class ExpressRouteCircuitsStatsListResult :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20150501Preview.IExpressRouteCircuitsStatsListResult,
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20150501Preview.IExpressRouteCircuitsStatsListResultInternal
    {

        /// <summary>Backing field for <see cref="NextLink" /> property.</summary>
        private string _nextLink;

        /// <summary>Gets the URL to get the next set of results.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public string NextLink { get => this._nextLink; set => this._nextLink = value; }

        /// <summary>Backing field for <see cref="Value" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20150501Preview.IExpressRouteCircuitStats[] _value;

        /// <summary>Gets List of Stats</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20150501Preview.IExpressRouteCircuitStats[] Value { get => this._value; set => this._value = value; }

        /// <summary>Creates an new <see cref="ExpressRouteCircuitsStatsListResult" /> instance.</summary>
        public ExpressRouteCircuitsStatsListResult()
        {

        }
    }
    /// Response for ListStats from Express Route Circuits Api service call
    public partial interface IExpressRouteCircuitsStatsListResult :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.IJsonSerializable
    {
        /// <summary>Gets the URL to get the next set of results.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Gets the URL to get the next set of results.",
        SerializedName = @"nextLink",
        PossibleTypes = new [] { typeof(string) })]
        string NextLink { get; set; }
        /// <summary>Gets List of Stats</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Gets List of Stats",
        SerializedName = @"value",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20150501Preview.IExpressRouteCircuitStats) })]
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20150501Preview.IExpressRouteCircuitStats[] Value { get; set; }

    }
    /// Response for ListStats from Express Route Circuits Api service call
    internal partial interface IExpressRouteCircuitsStatsListResultInternal

    {
        /// <summary>Gets the URL to get the next set of results.</summary>
        string NextLink { get; set; }
        /// <summary>Gets List of Stats</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20150501Preview.IExpressRouteCircuitStats[] Value { get; set; }

    }
}