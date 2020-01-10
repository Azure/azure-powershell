namespace Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Extensions;

    /// <summary>The routes table associated with the ExpressRouteCircuit</summary>
    public partial class ExpressRouteCircuitRoutesTable :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IExpressRouteCircuitRoutesTable,
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IExpressRouteCircuitRoutesTableInternal
    {

        /// <summary>Backing field for <see cref="LocPrf" /> property.</summary>
        private string _locPrf;

        /// <summary>locPrf</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public string LocPrf { get => this._locPrf; set => this._locPrf = value; }

        /// <summary>Backing field for <see cref="Network" /> property.</summary>
        private string _network;

        /// <summary>network</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public string Network { get => this._network; set => this._network = value; }

        /// <summary>Backing field for <see cref="NextHop" /> property.</summary>
        private string _nextHop;

        /// <summary>nextHop</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public string NextHop { get => this._nextHop; set => this._nextHop = value; }

        /// <summary>Backing field for <see cref="Path" /> property.</summary>
        private string _path;

        /// <summary>path</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public string Path { get => this._path; set => this._path = value; }

        /// <summary>Backing field for <see cref="Weight" /> property.</summary>
        private int? _weight;

        /// <summary>weight.</summary>
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
        /// <summary>locPrf</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"locPrf",
        SerializedName = @"locPrf",
        PossibleTypes = new [] { typeof(string) })]
        string LocPrf { get; set; }
        /// <summary>network</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"network",
        SerializedName = @"network",
        PossibleTypes = new [] { typeof(string) })]
        string Network { get; set; }
        /// <summary>nextHop</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"nextHop",
        SerializedName = @"nextHop",
        PossibleTypes = new [] { typeof(string) })]
        string NextHop { get; set; }
        /// <summary>path</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"path",
        SerializedName = @"path",
        PossibleTypes = new [] { typeof(string) })]
        string Path { get; set; }
        /// <summary>weight.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"weight.",
        SerializedName = @"weight",
        PossibleTypes = new [] { typeof(int) })]
        int? Weight { get; set; }

    }
    /// The routes table associated with the ExpressRouteCircuit
    internal partial interface IExpressRouteCircuitRoutesTableInternal

    {
        /// <summary>locPrf</summary>
        string LocPrf { get; set; }
        /// <summary>network</summary>
        string Network { get; set; }
        /// <summary>nextHop</summary>
        string NextHop { get; set; }
        /// <summary>path</summary>
        string Path { get; set; }
        /// <summary>weight.</summary>
        int? Weight { get; set; }

    }
}