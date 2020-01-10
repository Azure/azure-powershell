namespace Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20150501Preview
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Extensions;

    /// <summary>The routes table associated with the ExpressRouteCircuit</summary>
    public partial class ExpressRouteCircuitRoutesTable :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20150501Preview.IExpressRouteCircuitRoutesTable,
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20150501Preview.IExpressRouteCircuitRoutesTableInternal
    {

        /// <summary>Backing field for <see cref="AddressPrefix" /> property.</summary>
        private string _addressPrefix;

        /// <summary>Gets AddressPrefix.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public string AddressPrefix { get => this._addressPrefix; set => this._addressPrefix = value; }

        /// <summary>Backing field for <see cref="AsPath" /> property.</summary>
        private string _asPath;

        /// <summary>Gets AsPath.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public string AsPath { get => this._asPath; set => this._asPath = value; }

        /// <summary>Backing field for <see cref="NextHopIP" /> property.</summary>
        private string _nextHopIP;

        /// <summary>Gets NextHopIP.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public string NextHopIP { get => this._nextHopIP; set => this._nextHopIP = value; }

        /// <summary>Backing field for <see cref="NextHopType" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Network.Support.RouteNextHopType _nextHopType;

        /// <summary>Gets NextHopType.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Support.RouteNextHopType NextHopType { get => this._nextHopType; set => this._nextHopType = value; }

        /// <summary>Creates an new <see cref="ExpressRouteCircuitRoutesTable" /> instance.</summary>
        public ExpressRouteCircuitRoutesTable()
        {

        }
    }
    /// The routes table associated with the ExpressRouteCircuit
    public partial interface IExpressRouteCircuitRoutesTable :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.IJsonSerializable
    {
        /// <summary>Gets AddressPrefix.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Gets AddressPrefix.",
        SerializedName = @"addressPrefix",
        PossibleTypes = new [] { typeof(string) })]
        string AddressPrefix { get; set; }
        /// <summary>Gets AsPath.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Gets AsPath.",
        SerializedName = @"asPath",
        PossibleTypes = new [] { typeof(string) })]
        string AsPath { get; set; }
        /// <summary>Gets NextHopIP.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Gets NextHopIP.",
        SerializedName = @"nextHopIP",
        PossibleTypes = new [] { typeof(string) })]
        string NextHopIP { get; set; }
        /// <summary>Gets NextHopType.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"Gets NextHopType.",
        SerializedName = @"nextHopType",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Network.Support.RouteNextHopType) })]
        Microsoft.Azure.PowerShell.Cmdlets.Network.Support.RouteNextHopType NextHopType { get; set; }

    }
    /// The routes table associated with the ExpressRouteCircuit
    internal partial interface IExpressRouteCircuitRoutesTableInternal

    {
        /// <summary>Gets AddressPrefix.</summary>
        string AddressPrefix { get; set; }
        /// <summary>Gets AsPath.</summary>
        string AsPath { get; set; }
        /// <summary>Gets NextHopIP.</summary>
        string NextHopIP { get; set; }
        /// <summary>Gets NextHopType.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Support.RouteNextHopType NextHopType { get; set; }

    }
}