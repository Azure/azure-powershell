namespace Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Extensions;

    /// <summary>The routes table associated with the ExpressRouteCircuit</summary>
    public partial class ExpressRouteCircuitRoutesTable :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRouteCircuitRoutesTable,
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRouteCircuitRoutesTableInternal
    {

        /// <summary>Backing field for <see cref="LocPrf" /> property.</summary>
        private string _locPrf;

        /// <summary>
        /// Local preference value as set with the set local-preference route-map configuration command
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public string LocPrf { get => this._locPrf; set => this._locPrf = value; }

        /// <summary>Backing field for <see cref="Network" /> property.</summary>
        private string _network;

        /// <summary>IP address of a network entity</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public string Network { get => this._network; set => this._network = value; }

        /// <summary>Backing field for <see cref="NextHop" /> property.</summary>
        private string _nextHop;

        /// <summary>NextHop address</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public string NextHop { get => this._nextHop; set => this._nextHop = value; }

        /// <summary>Backing field for <see cref="Path" /> property.</summary>
        private string _path;

        /// <summary>Autonomous system paths to the destination network.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public string Path { get => this._path; set => this._path = value; }

        /// <summary>Backing field for <see cref="Weight" /> property.</summary>
        private int? _weight;

        /// <summary>Route Weight.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public int? Weight { get => this._weight; set => this._weight = value; }

        /// <summary>Creates an new <see cref="ExpressRouteCircuitRoutesTable" /> instance.</summary>
        public ExpressRouteCircuitRoutesTable()
        {

        }
    }
    /// The routes table associated with the ExpressRouteCircuit
    public partial interface IExpressRouteCircuitRoutesTable :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.IJsonSerializable
    {
        /// <summary>
        /// Local preference value as set with the set local-preference route-map configuration command
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Local preference value as set with the set local-preference route-map configuration command",
        SerializedName = @"locPrf",
        PossibleTypes = new [] { typeof(string) })]
        string LocPrf { get; set; }
        /// <summary>IP address of a network entity</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"IP address of a network entity",
        SerializedName = @"network",
        PossibleTypes = new [] { typeof(string) })]
        string Network { get; set; }
        /// <summary>NextHop address</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"NextHop address",
        SerializedName = @"nextHop",
        PossibleTypes = new [] { typeof(string) })]
        string NextHop { get; set; }
        /// <summary>Autonomous system paths to the destination network.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Autonomous system paths to the destination network.",
        SerializedName = @"path",
        PossibleTypes = new [] { typeof(string) })]
        string Path { get; set; }
        /// <summary>Route Weight.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Route Weight.",
        SerializedName = @"weight",
        PossibleTypes = new [] { typeof(int) })]
        int? Weight { get; set; }

    }
    /// The routes table associated with the ExpressRouteCircuit
    internal partial interface IExpressRouteCircuitRoutesTableInternal

    {
        /// <summary>
        /// Local preference value as set with the set local-preference route-map configuration command
        /// </summary>
        string LocPrf { get; set; }
        /// <summary>IP address of a network entity</summary>
        string Network { get; set; }
        /// <summary>NextHop address</summary>
        string NextHop { get; set; }
        /// <summary>Autonomous system paths to the destination network.</summary>
        string Path { get; set; }
        /// <summary>Route Weight.</summary>
        int? Weight { get; set; }

    }
}