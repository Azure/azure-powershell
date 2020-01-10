namespace Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Extensions;

    /// <summary>ExpressRoute circuit peering identifier.</summary>
    public partial class ExpressRouteCircuitPeeringId :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRouteCircuitPeeringId,
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRouteCircuitPeeringIdInternal
    {

        /// <summary>Backing field for <see cref="Id" /> property.</summary>
        private string _id;

        /// <summary>The ID of the ExpressRoute circuit peering.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public string Id { get => this._id; set => this._id = value; }

        /// <summary>Creates an new <see cref="ExpressRouteCircuitPeeringId" /> instance.</summary>
        public ExpressRouteCircuitPeeringId()
        {

        }
    }
    /// ExpressRoute circuit peering identifier.
    public partial interface IExpressRouteCircuitPeeringId :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.IJsonSerializable
    {
        /// <summary>The ID of the ExpressRoute circuit peering.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The ID of the ExpressRoute circuit peering.",
        SerializedName = @"id",
        PossibleTypes = new [] { typeof(string) })]
        string Id { get; set; }

    }
    /// ExpressRoute circuit peering identifier.
    internal partial interface IExpressRouteCircuitPeeringIdInternal

    {
        /// <summary>The ID of the ExpressRoute circuit peering.</summary>
        string Id { get; set; }

    }
}