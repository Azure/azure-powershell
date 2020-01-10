namespace Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Extensions;

    /// <summary>Effective Route</summary>
    public partial class EffectiveRoute :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IEffectiveRoute,
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IEffectiveRouteInternal
    {

        /// <summary>Backing field for <see cref="AddressPrefix" /> property.</summary>
        private string[] _addressPrefix;

        /// <summary>The address prefixes of the effective routes in CIDR notation.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public string[] AddressPrefix { get => this._addressPrefix; set => this._addressPrefix = value; }

        /// <summary>Backing field for <see cref="DisableBgpRoutePropagation" /> property.</summary>
        private bool? _disableBgpRoutePropagation;

        /// <summary>
        /// If true, on-premises routes are not propagated to the network interfaces in the subnet.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public bool? DisableBgpRoutePropagation { get => this._disableBgpRoutePropagation; set => this._disableBgpRoutePropagation = value; }

        /// <summary>Backing field for <see cref="Name" /> property.</summary>
        private string _name;

        /// <summary>The name of the user defined route. This is optional.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public string Name { get => this._name; set => this._name = value; }

        /// <summary>Backing field for <see cref="NextHopIPAddress" /> property.</summary>
        private string[] _nextHopIPAddress;

        /// <summary>The IP address of the next hop of the effective route.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public string[] NextHopIPAddress { get => this._nextHopIPAddress; set => this._nextHopIPAddress = value; }

        /// <summary>Backing field for <see cref="NextHopType" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Network.Support.RouteNextHopType? _nextHopType;

        /// <summary>The type of Azure hop the packet should be sent to.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Support.RouteNextHopType? NextHopType { get => this._nextHopType; set => this._nextHopType = value; }

        /// <summary>Backing field for <see cref="Source" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Network.Support.EffectiveRouteSource? _source;

        /// <summary>
        /// Who created the route. Possible values are: 'Unknown', 'User', 'VirtualNetworkGateway', and 'Default'.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Support.EffectiveRouteSource? Source { get => this._source; set => this._source = value; }

        /// <summary>Backing field for <see cref="State" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Network.Support.EffectiveRouteState? _state;

        /// <summary>The value of effective route. Possible values are: 'Active' and 'Invalid'.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Support.EffectiveRouteState? State { get => this._state; set => this._state = value; }

        /// <summary>Creates an new <see cref="EffectiveRoute" /> instance.</summary>
        public EffectiveRoute()
        {

        }
    }
    /// Effective Route
    public partial interface IEffectiveRoute :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.IJsonSerializable
    {
        /// <summary>The address prefixes of the effective routes in CIDR notation.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The address prefixes of the effective routes in CIDR notation.",
        SerializedName = @"addressPrefix",
        PossibleTypes = new [] { typeof(string) })]
        string[] AddressPrefix { get; set; }
        /// <summary>
        /// If true, on-premises routes are not propagated to the network interfaces in the subnet.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"If true, on-premises routes are not propagated to the network interfaces in the subnet.",
        SerializedName = @"disableBgpRoutePropagation",
        PossibleTypes = new [] { typeof(bool) })]
        bool? DisableBgpRoutePropagation { get; set; }
        /// <summary>The name of the user defined route. This is optional.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The name of the user defined route. This is optional.",
        SerializedName = @"name",
        PossibleTypes = new [] { typeof(string) })]
        string Name { get; set; }
        /// <summary>The IP address of the next hop of the effective route.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The IP address of the next hop of the effective route.",
        SerializedName = @"nextHopIpAddress",
        PossibleTypes = new [] { typeof(string) })]
        string[] NextHopIPAddress { get; set; }
        /// <summary>The type of Azure hop the packet should be sent to.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The type of Azure hop the packet should be sent to.",
        SerializedName = @"nextHopType",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Network.Support.RouteNextHopType) })]
        Microsoft.Azure.PowerShell.Cmdlets.Network.Support.RouteNextHopType? NextHopType { get; set; }
        /// <summary>
        /// Who created the route. Possible values are: 'Unknown', 'User', 'VirtualNetworkGateway', and 'Default'.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Who created the route. Possible values are: 'Unknown', 'User', 'VirtualNetworkGateway', and 'Default'.",
        SerializedName = @"source",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Network.Support.EffectiveRouteSource) })]
        Microsoft.Azure.PowerShell.Cmdlets.Network.Support.EffectiveRouteSource? Source { get; set; }
        /// <summary>The value of effective route. Possible values are: 'Active' and 'Invalid'.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The value of effective route. Possible values are: 'Active' and 'Invalid'.",
        SerializedName = @"state",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Network.Support.EffectiveRouteState) })]
        Microsoft.Azure.PowerShell.Cmdlets.Network.Support.EffectiveRouteState? State { get; set; }

    }
    /// Effective Route
    internal partial interface IEffectiveRouteInternal

    {
        /// <summary>The address prefixes of the effective routes in CIDR notation.</summary>
        string[] AddressPrefix { get; set; }
        /// <summary>
        /// If true, on-premises routes are not propagated to the network interfaces in the subnet.
        /// </summary>
        bool? DisableBgpRoutePropagation { get; set; }
        /// <summary>The name of the user defined route. This is optional.</summary>
        string Name { get; set; }
        /// <summary>The IP address of the next hop of the effective route.</summary>
        string[] NextHopIPAddress { get; set; }
        /// <summary>The type of Azure hop the packet should be sent to.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Support.RouteNextHopType? NextHopType { get; set; }
        /// <summary>
        /// Who created the route. Possible values are: 'Unknown', 'User', 'VirtualNetworkGateway', and 'Default'.
        /// </summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Support.EffectiveRouteSource? Source { get; set; }
        /// <summary>The value of effective route. Possible values are: 'Active' and 'Invalid'.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Support.EffectiveRouteState? State { get; set; }

    }
}