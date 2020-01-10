namespace Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Extensions;

    /// <summary>SKU of a load balancer</summary>
    public partial class LoadBalancerSku :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ILoadBalancerSku,
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ILoadBalancerSkuInternal
    {

        /// <summary>Backing field for <see cref="Name" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Network.Support.LoadBalancerSkuName? _name;

        /// <summary>Name of a load balancer SKU.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Support.LoadBalancerSkuName? Name { get => this._name; set => this._name = value; }

        /// <summary>Creates an new <see cref="LoadBalancerSku" /> instance.</summary>
        public LoadBalancerSku()
        {

        }
    }
    /// SKU of a load balancer
    public partial interface ILoadBalancerSku :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.IJsonSerializable
    {
        /// <summary>Name of a load balancer SKU.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Name of a load balancer SKU.",
        SerializedName = @"name",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Network.Support.LoadBalancerSkuName) })]
        Microsoft.Azure.PowerShell.Cmdlets.Network.Support.LoadBalancerSkuName? Name { get; set; }

    }
    /// SKU of a load balancer
    internal partial interface ILoadBalancerSkuInternal

    {
        /// <summary>Name of a load balancer SKU.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Support.LoadBalancerSkuName? Name { get; set; }

    }
}