namespace Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Extensions;

    /// <summary>
    /// Response for ListPeeredConnections API service call retrieves all global reach peer circuit connections that belongs to
    /// a Private Peering for an ExpressRouteCircuit.
    /// </summary>
    public partial class PeerExpressRouteCircuitConnectionListResult :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPeerExpressRouteCircuitConnectionListResult,
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPeerExpressRouteCircuitConnectionListResultInternal
    {

        /// <summary>Backing field for <see cref="NextLink" /> property.</summary>
        private string _nextLink;

        /// <summary>The URL to get the next set of results.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public string NextLink { get => this._nextLink; set => this._nextLink = value; }

        /// <summary>Backing field for <see cref="Value" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPeerExpressRouteCircuitConnection[] _value;

        /// <summary>
        /// The global reach peer circuit connection associated with Private Peering in an ExpressRoute Circuit.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPeerExpressRouteCircuitConnection[] Value { get => this._value; set => this._value = value; }

        /// <summary>
        /// Creates an new <see cref="PeerExpressRouteCircuitConnectionListResult" /> instance.
        /// </summary>
        public PeerExpressRouteCircuitConnectionListResult()
        {

        }
    }
    /// Response for ListPeeredConnections API service call retrieves all global reach peer circuit connections that belongs to
    /// a Private Peering for an ExpressRouteCircuit.
    public partial interface IPeerExpressRouteCircuitConnectionListResult :
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
        /// The global reach peer circuit connection associated with Private Peering in an ExpressRoute Circuit.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The global reach peer circuit connection associated with Private Peering in an ExpressRoute Circuit.",
        SerializedName = @"value",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPeerExpressRouteCircuitConnection) })]
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPeerExpressRouteCircuitConnection[] Value { get; set; }

    }
    /// Response for ListPeeredConnections API service call retrieves all global reach peer circuit connections that belongs to
    /// a Private Peering for an ExpressRouteCircuit.
    internal partial interface IPeerExpressRouteCircuitConnectionListResultInternal

    {
        /// <summary>The URL to get the next set of results.</summary>
        string NextLink { get; set; }
        /// <summary>
        /// The global reach peer circuit connection associated with Private Peering in an ExpressRoute Circuit.
        /// </summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPeerExpressRouteCircuitConnection[] Value { get; set; }

    }
}