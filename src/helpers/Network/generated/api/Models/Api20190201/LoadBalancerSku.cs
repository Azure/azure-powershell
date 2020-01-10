namespace Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Extensions;

    public partial class LoadBalancerSku :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ILoadBalancerSku,
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ILoadBalancerSkuInternal,
        Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.IValidates
    {
        /// <summary>
        /// Backing field for Inherited model <see cref= "Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ILoadBalancerSku"
        /// />
        /// </summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ILoadBalancerSku __loadBalancerSku = new Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.LoadBalancerSku();

        /// <summary>Name of a load balancer SKU.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inherited)]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Support.LoadBalancerSkuName? Name { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ILoadBalancerSkuInternal)__loadBalancerSku).Name; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ILoadBalancerSkuInternal)__loadBalancerSku).Name = value; }

        /// <summary>Creates an new <see cref="LoadBalancerSku" /> instance.</summary>
        public LoadBalancerSku()
        {

        }

        /// <summary>Validates that this object meets the validation criteria.</summary>
        /// <param name="eventListener">an <see cref="Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.IEventListener" /> instance that will receive validation
        /// events.</param>
        /// <returns>
        /// A < see cref = "global::System.Threading.Tasks.Task" /> that will be complete when validation is completed.
        /// </returns>
        public async global::System.Threading.Tasks.Task Validate(Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.IEventListener eventListener)
        {
            await eventListener.AssertNotNull(nameof(__loadBalancerSku), __loadBalancerSku);
            await eventListener.AssertObjectIsValid(nameof(__loadBalancerSku), __loadBalancerSku);
        }
    }
    public partial interface ILoadBalancerSku :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ILoadBalancerSku
    {

    }
    internal partial interface ILoadBalancerSkuInternal :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ILoadBalancerSkuInternal
    {

    }
}