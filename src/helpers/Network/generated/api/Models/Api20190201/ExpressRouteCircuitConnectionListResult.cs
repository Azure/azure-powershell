namespace Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Extensions;

    /// <summary>
    /// Response for ListConnections API service call retrieves all global reach connections that belongs to a Private Peering
    /// for an ExpressRouteCircuit.
    /// </summary>
    public partial class ExpressRouteCircuitConnectionListResult :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRouteCircuitConnectionListResult,
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRouteCircuitConnectionListResultInternal
    {

        /// <summary>Backing field for <see cref="NextLink" /> property.</summary>
        private string _nextLink;

        /// <summary>The URL to get the next set of results.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public string NextLink { get => this._nextLink; set => this._nextLink = value; }

        /// <summary>Backing field for <see cref="Value" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRouteCircuitConnection[] _value;

        /// <summary>
        /// The global reach connection associated with Private Peering in an ExpressRoute Circuit.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRouteCircuitConnection[] Value { get => this._value; set => this._value = value; }

        /// <summary>Creates an new <see cref="ExpressRouteCircuitConnectionListResult" /> instance.</summary>
        public ExpressRouteCircuitConnectionListResult()
        {

        }
    }
    /// Response for ListConnections API service call retrieves all global reach connections that belongs to a Private Peering
    /// for an ExpressRouteCircuit.
    public partial interface IExpressRouteCircuitConnectionListResult :
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
        /// <summary>
        /// The global reach connection associated with Private Peering in an ExpressRoute Circuit.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The global reach connection associated with Private Peering in an ExpressRoute Circuit.",
        SerializedName = @"value",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRouteCircuitConnection) })]
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRouteCircuitConnection[] Value { get; set; }

    }
    /// Response for ListConnections API service call retrieves all global reach connections that belongs to a Private Peering
    /// for an ExpressRouteCircuit.
    internal partial interface IExpressRouteCircuitConnectionListResultInternal

    {
        /// <summary>The URL to get the next set of results.</summary>
        string NextLink { get; set; }
        /// <summary>
        /// The global reach connection associated with Private Peering in an ExpressRoute Circuit.
        /// </summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRouteCircuitConnection[] Value { get; set; }

    }
}