namespace Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Extensions;

    /// <summary>The routes table associated with the ExpressRouteCircuit.</summary>
    public partial class ExpressRouteCircuitRoutesTableSummary :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRouteCircuitRoutesTableSummary,
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRouteCircuitRoutesTableSummaryInternal
    {

        /// <summary>Backing field for <see cref="As" /> property.</summary>
        private int? _as;

        /// <summary>Autonomous system number.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public int? As { get => this._as; set => this._as = value; }

        /// <summary>Backing field for <see cref="Neighbor" /> property.</summary>
        private string _neighbor;

        /// <summary>IP address of the neighbor.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public string Neighbor { get => this._neighbor; set => this._neighbor = value; }

        /// <summary>Backing field for <see cref="StatePfxRcd" /> property.</summary>
        private string _statePfxRcd;

        /// <summary>
        /// Current state of the BGP session, and the number of prefixes that have been received from a neighbor or peer group.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public string StatePfxRcd { get => this._statePfxRcd; set => this._statePfxRcd = value; }

        /// <summary>Backing field for <see cref="UpDown" /> property.</summary>
        private string _upDown;

        /// <summary>
        /// The length of time that the BGP session has been in the Established state, or the current status if not in the Established
        /// state.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public string UpDown { get => this._upDown; set => this._upDown = value; }

        /// <summary>Backing field for <see cref="V" /> property.</summary>
        private int? _v;

        /// <summary>BGP version number spoken to the neighbor.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public int? V { get => this._v; set => this._v = value; }

        /// <summary>Creates an new <see cref="ExpressRouteCircuitRoutesTableSummary" /> instance.</summary>
        public ExpressRouteCircuitRoutesTableSummary()
        {

        }
    }
    /// The routes table associated with the ExpressRouteCircuit.
    public partial interface IExpressRouteCircuitRoutesTableSummary :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.IJsonSerializable
    {
        /// <summary>Autonomous system number.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Autonomous system number.",
        SerializedName = @"as",
        PossibleTypes = new [] { typeof(int) })]
        int? As { get; set; }
        /// <summary>IP address of the neighbor.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"IP address of the neighbor.",
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
        SerializedName = @"statePfxRcd",
        PossibleTypes = new [] { typeof(string) })]
        string StatePfxRcd { get; set; }
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
        /// <summary>BGP version number spoken to the neighbor.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"BGP version number spoken to the neighbor.",
        SerializedName = @"v",
        PossibleTypes = new [] { typeof(int) })]
        int? V { get; set; }

    }
    /// The routes table associated with the ExpressRouteCircuit.
    internal partial interface IExpressRouteCircuitRoutesTableSummaryInternal

    {
        /// <summary>Autonomous system number.</summary>
        int? As { get; set; }
        /// <summary>IP address of the neighbor.</summary>
        string Neighbor { get; set; }
        /// <summary>
        /// Current state of the BGP session, and the number of prefixes that have been received from a neighbor or peer group.
        /// </summary>
        string StatePfxRcd { get; set; }
        /// <summary>
        /// The length of time that the BGP session has been in the Established state, or the current status if not in the Established
        /// state.
        /// </summary>
        string UpDown { get; set; }
        /// <summary>BGP version number spoken to the neighbor.</summary>
        int? V { get; set; }

    }
}