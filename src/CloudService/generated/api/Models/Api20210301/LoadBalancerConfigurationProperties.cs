namespace Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301
{
    using static Microsoft.Azure.PowerShell.Cmdlets.CloudService.Runtime.Extensions;

    public partial class LoadBalancerConfigurationProperties :
        Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.ILoadBalancerConfigurationProperties,
        Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.ILoadBalancerConfigurationPropertiesInternal
    {

        /// <summary>Backing field for <see cref="FrontendIPConfiguration" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.ILoadBalancerFrontendIPConfiguration[] _frontendIPConfiguration;

        /// <summary>
        /// Specifies the frontend IP to be used for the load balancer. Only IPv4 frontend IP address is supported. Each load balancer
        /// configuration must have exactly one frontend IP configuration.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Origin(Microsoft.Azure.PowerShell.Cmdlets.CloudService.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.ILoadBalancerFrontendIPConfiguration[] FrontendIPConfiguration { get => this._frontendIPConfiguration; set => this._frontendIPConfiguration = value; }

        /// <summary>Creates an new <see cref="LoadBalancerConfigurationProperties" /> instance.</summary>
        public LoadBalancerConfigurationProperties()
        {

        }
    }
    public partial interface ILoadBalancerConfigurationProperties :
        Microsoft.Azure.PowerShell.Cmdlets.CloudService.Runtime.IJsonSerializable
    {
        /// <summary>
        /// Specifies the frontend IP to be used for the load balancer. Only IPv4 frontend IP address is supported. Each load balancer
        /// configuration must have exactly one frontend IP configuration.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"Specifies the frontend IP to be used for the load balancer. Only IPv4 frontend IP address is supported. Each load balancer configuration must have exactly one frontend IP configuration.",
        SerializedName = @"frontendIPConfigurations",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.ILoadBalancerFrontendIPConfiguration) })]
        Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.ILoadBalancerFrontendIPConfiguration[] FrontendIPConfiguration { get; set; }

    }
    internal partial interface ILoadBalancerConfigurationPropertiesInternal

    {
        /// <summary>
        /// Specifies the frontend IP to be used for the load balancer. Only IPv4 frontend IP address is supported. Each load balancer
        /// configuration must have exactly one frontend IP configuration.
        /// </summary>
        Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.ILoadBalancerFrontendIPConfiguration[] FrontendIPConfiguration { get; set; }

    }
}