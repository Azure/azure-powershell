namespace Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Extensions;

    /// <summary>The routes table associated with the ExpressRouteCircuit.</summary>
    public partial class ExpressRouteCrossConnectionRoutesTableSummary :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRouteCrossConnectionRoutesTableSummary,
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRouteCrossConnectionRoutesTableSummaryInternal
    {

        /// <summary>Backing field for <see cref="Asn" /> property.</summary>
        private int? _asn;

        /// <summary>Autonomous system number.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public int? Asn { get => this._asn; set => this._asn = value; }

        /// <summary>Backing field for <see cref="Neighbor" /> property.</summary>
        private string _neighbor;

        /// <summary>IP address of Neighbor router</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public string Neighbor { get => this._neighbor; set => this._neighbor = value; }

        /// <summary>Backing field for <see cref="StateOrPrefixesReceived" /> property.</summary>
        private string _stateOrPrefixesReceived;

        /// <summary>
        /// Current state of the BGP session, and the number of prefixes that have been received from a neighbor or peer group.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public string StateOrPrefixesReceived { get => this._stateOrPrefixesReceived; set => this._stateOrPrefixesReceived = value; }

        /// <summary>Backing field for <see cref="UpDown" /> property.</summary>
        private string _upDown;

        /// <summary>
        /// The length of time that the BGP session has been in the Established state, or the current status if not in the Established
        /// state.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public string UpDown { get => this._upDown; set => this._upDown = value; }

        /// <summary>
        /// Creates an new <see cref="ExpressRouteCrossConnectionRoutesTableSummary" /> instance.
        /// </summary>
        public ExpressRouteCrossConnectionRoutesTableSummary()
        {

        }
    }
    /// The routes table associated with the ExpressRouteCircuit.
    public partial interface IExpressRouteCrossConnectionRoutesTableSummary :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.IJsonSerializable
    {
        /// <summary>Autonomous system number.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Autonomous system number.",
        SerializedName = @"asn",
        PossibleTypes = new [] { typeof(int) })]
        int? Asn { get; set; }
        /// <summary>IP address of Neighbor router</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"IP address of Neighbor router",
        SerializedName = @"neighbor",
        PossibleTypes = new [] { typeof(string) })]
        string Neighbor { get; set; }
        /// <summary>
        /// Current state of the BGP session, and the number of prefixes that have been received from a neighbor or peer group.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Current state of the BGP session, and the number of prefixes that have been received from a neighbor or peer group.",
        SerializedName = @"stateOrPrefixesReceived",
        PossibleTypes = new [] { typeof(string) })]
        string StateOrPrefixesReceived { get; set; }
        /// <summary>
        /// The length of time that the BGP session has been in the Established state, or the current status if not in the Established
        /// state.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The length of time that the BGP session has been in the Established state, or the current status if not in the Established state.",
        SerializedName = @"upDown",
        PossibleTypes = new [] { typeof(string) })]
        string UpDown { get; set; }

    }
    /// The routes table associated with the ExpressRouteCircuit.
    internal partial interface IExpressRouteCrossConnectionRoutesTableSummaryInternal

    {
        /// <summary>Autonomous system number.</summary>
        int? Asn { get; set; }
        /// <summary>IP address of Neighbor router</summary>
        string Neighbor { get; set; }
        /// <summary>
        /// Current state of the BGP session, and the number of prefixes that have been received from a neighbor or peer group.
        /// </summary>
        string StateOrPrefixesReceived { get; set; }
        /// <summary>
        /// The length of time that the BGP session has been in the Established state, or the current status if not in the Established
        /// state.
        /// </summary>
        string UpDown { get; set; }

    }
}