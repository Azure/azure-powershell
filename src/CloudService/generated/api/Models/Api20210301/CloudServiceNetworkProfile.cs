namespace Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301
{
    using static Microsoft.Azure.PowerShell.Cmdlets.CloudService.Runtime.Extensions;

    /// <summary>Network Profile for the cloud service.</summary>
    public partial class CloudServiceNetworkProfile :
        Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.ICloudServiceNetworkProfile,
        Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.ICloudServiceNetworkProfileInternal
    {

        /// <summary>Backing field for <see cref="LoadBalancerConfiguration" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.ILoadBalancerConfiguration[] _loadBalancerConfiguration;

        /// <summary>
        /// List of Load balancer configurations. Cloud service can have up to two load balancer configurations, corresponding to
        /// a Public Load Balancer and an Internal Load Balancer.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Origin(Microsoft.Azure.PowerShell.Cmdlets.CloudService.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.ILoadBalancerConfiguration[] LoadBalancerConfiguration { get => this._loadBalancerConfiguration; set => this._loadBalancerConfiguration = value; }

        /// <summary>Backing field for <see cref="SwappableCloudService" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.ISubResource _swappableCloudService;

        /// <summary>
        /// The id reference of the cloud service containing the target IP with which the subject cloud service can perform a swap.
        /// This property cannot be updated once it is set. The swappable cloud service referred by this id must be present otherwise
        /// an error will be thrown.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Origin(Microsoft.Azure.PowerShell.Cmdlets.CloudService.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.ISubResource SwappableCloudService { get => (this._swappableCloudService = this._swappableCloudService ?? new Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.SubResource()); set => this._swappableCloudService = value; }

        /// <summary>Creates an new <see cref="CloudServiceNetworkProfile" /> instance.</summary>
        public CloudServiceNetworkProfile()
        {

        }
    }
    /// Network Profile for the cloud service.
    public partial interface ICloudServiceNetworkProfile :
        Microsoft.Azure.PowerShell.Cmdlets.CloudService.Runtime.IJsonSerializable
    {
        /// <summary>
        /// List of Load balancer configurations. Cloud service can have up to two load balancer configurations, corresponding to
        /// a Public Load Balancer and an Internal Load Balancer.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"List of Load balancer configurations. Cloud service can have up to two load balancer configurations, corresponding to a Public Load Balancer and an Internal Load Balancer.",
        SerializedName = @"loadBalancerConfigurations",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.ILoadBalancerConfiguration) })]
        Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.ILoadBalancerConfiguration[] LoadBalancerConfiguration { get; set; }
        /// <summary>
        /// The id reference of the cloud service containing the target IP with which the subject cloud service can perform a swap.
        /// This property cannot be updated once it is set. The swappable cloud service referred by this id must be present otherwise
        /// an error will be thrown.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The id reference of the cloud service containing the target IP with which the subject cloud service can perform a swap. This property cannot be updated once it is set. The swappable cloud service referred by this id must be present otherwise an error will be thrown.",
        SerializedName = @"swappableCloudService",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.ISubResource) })]
        Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.ISubResource SwappableCloudService { get; set; }

    }
    /// Network Profile for the cloud service.
    internal partial interface ICloudServiceNetworkProfileInternal

    {
        /// <summary>
        /// List of Load balancer configurations. Cloud service can have up to two load balancer configurations, corresponding to
        /// a Public Load Balancer and an Internal Load Balancer.
        /// </summary>
        Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.ILoadBalancerConfiguration[] LoadBalancerConfiguration { get; set; }
        /// <summary>
        /// The id reference of the cloud service containing the target IP with which the subject cloud service can perform a swap.
        /// This property cannot be updated once it is set. The swappable cloud service referred by this id must be present otherwise
        /// an error will be thrown.
        /// </summary>
        Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.ISubResource SwappableCloudService { get; set; }

    }
}