namespace Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20201001Preview
{
    using static Microsoft.Azure.PowerShell.Cmdlets.CloudService.Runtime.Extensions;

    public partial class LoadBalancerConfigurationProperties :
        Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20201001Preview.ILoadBalancerConfigurationProperties,
        Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20201001Preview.ILoadBalancerConfigurationPropertiesInternal
    {

        /// <summary>Backing field for <see cref="FrontendIPConfiguration" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20201001Preview.ILoadBalancerFrontendIPConfiguration[] _frontendIPConfiguration;

        /// <summary>List of IP</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Origin(Microsoft.Azure.PowerShell.Cmdlets.CloudService.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20201001Preview.ILoadBalancerFrontendIPConfiguration[] FrontendIPConfiguration { get => this._frontendIPConfiguration; set => this._frontendIPConfiguration = value; }

        /// <summary>Creates an new <see cref="LoadBalancerConfigurationProperties" /> instance.</summary>
        public LoadBalancerConfigurationProperties()
        {

        }
    }
    public partial interface ILoadBalancerConfigurationProperties :
        Microsoft.Azure.PowerShell.Cmdlets.CloudService.Runtime.IJsonSerializable
    {
        /// <summary>List of IP</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"List of IP",
        SerializedName = @"frontendIPConfigurations",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20201001Preview.ILoadBalancerFrontendIPConfiguration) })]
        Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20201001Preview.ILoadBalancerFrontendIPConfiguration[] FrontendIPConfiguration { get; set; }

    }
    internal partial interface ILoadBalancerConfigurationPropertiesInternal

    {
        /// <summary>List of IP</summary>
        Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20201001Preview.ILoadBalancerFrontendIPConfiguration[] FrontendIPConfiguration { get; set; }

    }
}