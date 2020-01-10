namespace Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Extensions;

    /// <summary>Properties of the ExpressRouteConnection subresource.</summary>
    public partial class ExpressRouteConnectionProperties :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRouteConnectionProperties,
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRouteConnectionPropertiesInternal
    {

        /// <summary>Backing field for <see cref="AuthorizationKey" /> property.</summary>
        private string _authorizationKey;

        /// <summary>Authorization key to establish the connection.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public string AuthorizationKey { get => this._authorizationKey; set => this._authorizationKey = value; }

        /// <summary>Backing field for <see cref="ExpressRouteCircuitPeering" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRouteCircuitPeeringId _expressRouteCircuitPeering;

        /// <summary>The ExpressRoute circuit peering.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRouteCircuitPeeringId ExpressRouteCircuitPeering { get => (this._expressRouteCircuitPeering = this._expressRouteCircuitPeering ?? new Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ExpressRouteCircuitPeeringId()); set => this._expressRouteCircuitPeering = value; }

        /// <summary>The ID of the ExpressRoute circuit peering.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public string ExpressRouteCircuitPeeringId { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRouteCircuitPeeringIdInternal)ExpressRouteCircuitPeering).Id; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRouteCircuitPeeringIdInternal)ExpressRouteCircuitPeering).Id = value; }

        /// <summary>Internal Acessors for ExpressRouteCircuitPeering</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRouteCircuitPeeringId Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRouteConnectionPropertiesInternal.ExpressRouteCircuitPeering { get => (this._expressRouteCircuitPeering = this._expressRouteCircuitPeering ?? new Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ExpressRouteCircuitPeeringId()); set { {_expressRouteCircuitPeering = value;} } }

        /// <summary>Backing field for <see cref="ProvisioningState" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ProvisioningState? _provisioningState;

        /// <summary>The provisioning state of the resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ProvisioningState? ProvisioningState { get => this._provisioningState; set => this._provisioningState = value; }

        /// <summary>Backing field for <see cref="RoutingWeight" /> property.</summary>
        private int? _routingWeight;

        /// <summary>The routing weight associated to the connection.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public int? RoutingWeight { get => this._routingWeight; set => this._routingWeight = value; }

        /// <summary>Creates an new <see cref="ExpressRouteConnectionProperties" /> instance.</summary>
        public ExpressRouteConnectionProperties()
        {

        }
    }
    /// Properties of the ExpressRouteConnection subresource.
    public partial interface IExpressRouteConnectionProperties :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.IJsonSerializable
    {
        /// <summary>Authorization key to establish the connection.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Authorization key to establish the connection.",
        SerializedName = @"authorizationKey",
        PossibleTypes = new [] { typeof(string) })]
        string AuthorizationKey { get; set; }
        /// <summary>The ID of the ExpressRoute circuit peering.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The ID of the ExpressRoute circuit peering.",
        SerializedName = @"id",
        PossibleTypes = new [] { typeof(string) })]
        string ExpressRouteCircuitPeeringId { get; set; }
        /// <summary>The provisioning state of the resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The provisioning state of the resource.",
        SerializedName = @"provisioningState",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ProvisioningState) })]
        Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ProvisioningState? ProvisioningState { get; set; }
        /// <summary>The routing weight associated to the connection.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The routing weight associated to the connection.",
        SerializedName = @"routingWeight",
        PossibleTypes = new [] { typeof(int) })]
        int? RoutingWeight { get; set; }

    }
    /// Properties of the ExpressRouteConnection subresource.
    internal partial interface IExpressRouteConnectionPropertiesInternal

    {
        /// <summary>Authorization key to establish the connection.</summary>
        string AuthorizationKey { get; set; }
        /// <summary>The ExpressRoute circuit peering.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRouteCircuitPeeringId ExpressRouteCircuitPeering { get; set; }
        /// <summary>The ID of the ExpressRoute circuit peering.</summary>
        string ExpressRouteCircuitPeeringId { get; set; }
        /// <summary>The provisioning state of the resource.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ProvisioningState? ProvisioningState { get; set; }
        /// <summary>The routing weight associated to the connection.</summary>
        int? RoutingWeight { get; set; }

    }
}