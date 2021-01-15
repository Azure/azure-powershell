namespace Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20201001Preview
{
    using static Microsoft.Azure.PowerShell.Cmdlets.CloudService.Runtime.Extensions;

    /// <summary>Network Profile for the cloud service.</summary>
    public partial class CloudServiceNetworkProfile :
        Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20201001Preview.ICloudServiceNetworkProfile,
        Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20201001Preview.ICloudServiceNetworkProfileInternal
    {

        /// <summary>Backing field for <see cref="LoadBalancerConfiguration" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20201001Preview.ILoadBalancerConfiguration[] _loadBalancerConfiguration;

        /// <summary>The list of load balancer configurations for the cloud service.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Origin(Microsoft.Azure.PowerShell.Cmdlets.CloudService.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20201001Preview.ILoadBalancerConfiguration[] LoadBalancerConfiguration { get => this._loadBalancerConfiguration; set => this._loadBalancerConfiguration = value; }

        /// <summary>Backing field for <see cref="SwappableCloudService" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20201001Preview.ISubResource _swappableCloudService;

        [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Origin(Microsoft.Azure.PowerShell.Cmdlets.CloudService.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20201001Preview.ISubResource SwappableCloudService { get => (this._swappableCloudService = this._swappableCloudService ?? new Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20201001Preview.SubResource()); set => this._swappableCloudService = value; }

        /// <summary>Creates an new <see cref="CloudServiceNetworkProfile" /> instance.</summary>
        public CloudServiceNetworkProfile()
        {

        }
    }
    /// Network Profile for the cloud service.
    public partial interface ICloudServiceNetworkProfile :
        Microsoft.Azure.PowerShell.Cmdlets.CloudService.Runtime.IJsonSerializable
    {
        /// <summary>The list of load balancer configurations for the cloud service.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The list of load balancer configurations for the cloud service.",
        SerializedName = @"loadBalancerConfigurations",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20201001Preview.ILoadBalancerConfiguration) })]
        Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20201001Preview.ILoadBalancerConfiguration[] LoadBalancerConfiguration { get; set; }

        [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"",
        SerializedName = @"swappableCloudService",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20201001Preview.ISubResource) })]
        Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20201001Preview.ISubResource SwappableCloudService { get; set; }

    }
    /// Network Profile for the cloud service.
    internal partial interface ICloudServiceNetworkProfileInternal

    {
        /// <summary>The list of load balancer configurations for the cloud service.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20201001Preview.ILoadBalancerConfiguration[] LoadBalancerConfiguration { get; set; }

        Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20201001Preview.ISubResource SwappableCloudService { get; set; }

    }
}