namespace Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Extensions;

    public partial class VirtualNetworkGatewaySku :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVirtualNetworkGatewaySku,
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVirtualNetworkGatewaySkuInternal,
        Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.IValidates
    {
        /// <summary>
        /// Backing field for Inherited model <see cref= "Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IVirtualNetworkGatewaySku"
        /// />
        /// </summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IVirtualNetworkGatewaySku __virtualNetworkGatewaySku = new Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.VirtualNetworkGatewaySku();

        /// <summary>The capacity.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inherited)]
        public int? Capacity { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IVirtualNetworkGatewaySkuInternal)__virtualNetworkGatewaySku).Capacity; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IVirtualNetworkGatewaySkuInternal)__virtualNetworkGatewaySku).Capacity = value; }

        /// <summary>Gateway SKU name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inherited)]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Support.VirtualNetworkGatewaySkuName? Name { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IVirtualNetworkGatewaySkuInternal)__virtualNetworkGatewaySku).Name; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IVirtualNetworkGatewaySkuInternal)__virtualNetworkGatewaySku).Name = value; }

        /// <summary>Gateway SKU tier.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inherited)]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Support.VirtualNetworkGatewaySkuTier? Tier { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IVirtualNetworkGatewaySkuInternal)__virtualNetworkGatewaySku).Tier; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IVirtualNetworkGatewaySkuInternal)__virtualNetworkGatewaySku).Tier = value; }

        /// <summary>Validates that this object meets the validation criteria.</summary>
        /// <param name="eventListener">an <see cref="Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.IEventListener" /> instance that will receive validation
        /// events.</param>
        /// <returns>
        /// A < see cref = "global::System.Threading.Tasks.Task" /> that will be complete when validation is completed.
        /// </returns>
        public async global::System.Threading.Tasks.Task Validate(Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.IEventListener eventListener)
        {
            await eventListener.AssertNotNull(nameof(__virtualNetworkGatewaySku), __virtualNetworkGatewaySku);
            await eventListener.AssertObjectIsValid(nameof(__virtualNetworkGatewaySku), __virtualNetworkGatewaySku);
        }

        /// <summary>Creates an new <see cref="VirtualNetworkGatewaySku" /> instance.</summary>
        public VirtualNetworkGatewaySku()
        {

        }
    }
    public partial interface IVirtualNetworkGatewaySku :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IVirtualNetworkGatewaySku
    {

    }
    internal partial interface IVirtualNetworkGatewaySkuInternal :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IVirtualNetworkGatewaySkuInternal
    {

    }
}