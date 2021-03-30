namespace Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301
{
    using static Microsoft.Azure.PowerShell.Cmdlets.CloudService.Runtime.Extensions;

    public partial class LoadBalancerFrontendIPConfiguration :
        Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.ILoadBalancerFrontendIPConfiguration,
        Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.ILoadBalancerFrontendIPConfigurationInternal
    {

        /// <summary>Internal Acessors for Property</summary>
        Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.ILoadBalancerFrontendIPConfigurationProperties Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.ILoadBalancerFrontendIPConfigurationInternal.Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.LoadBalancerFrontendIPConfigurationProperties()); set { {_property = value;} } }

        /// <summary>Internal Acessors for PublicIPAddress</summary>
        Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.ISubResource Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.ILoadBalancerFrontendIPConfigurationInternal.PublicIPAddress { get => ((Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.ILoadBalancerFrontendIPConfigurationPropertiesInternal)Property).PublicIPAddress; set => ((Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.ILoadBalancerFrontendIPConfigurationPropertiesInternal)Property).PublicIPAddress = value; }

        /// <summary>Internal Acessors for Subnet</summary>
        Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.ISubResource Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.ILoadBalancerFrontendIPConfigurationInternal.Subnet { get => ((Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.ILoadBalancerFrontendIPConfigurationPropertiesInternal)Property).Subnet; set => ((Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.ILoadBalancerFrontendIPConfigurationPropertiesInternal)Property).Subnet = value; }

        /// <summary>Backing field for <see cref="Name" /> property.</summary>
        private string _name;

        /// <summary>
        /// The name of the resource that is unique within the set of frontend IP configurations used by the load balancer. This name
        /// can be used to access the resource.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Origin(Microsoft.Azure.PowerShell.Cmdlets.CloudService.PropertyOrigin.Owned)]
        public string Name { get => this._name; set => this._name = value; }

        /// <summary>The virtual network private IP address of the IP configuration.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Origin(Microsoft.Azure.PowerShell.Cmdlets.CloudService.PropertyOrigin.Inlined)]
        public string PrivateIPAddress { get => ((Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.ILoadBalancerFrontendIPConfigurationPropertiesInternal)Property).PrivateIPAddress; set => ((Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.ILoadBalancerFrontendIPConfigurationPropertiesInternal)Property).PrivateIPAddress = value ?? null; }

        /// <summary>Backing field for <see cref="Property" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.ILoadBalancerFrontendIPConfigurationProperties _property;

        /// <summary>Properties of load balancer frontend ip configuration.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Origin(Microsoft.Azure.PowerShell.Cmdlets.CloudService.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.ILoadBalancerFrontendIPConfigurationProperties Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.LoadBalancerFrontendIPConfigurationProperties()); set => this._property = value; }

        /// <summary>Resource Id</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Origin(Microsoft.Azure.PowerShell.Cmdlets.CloudService.PropertyOrigin.Inlined)]
        public string PublicIPAddressId { get => ((Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.ILoadBalancerFrontendIPConfigurationPropertiesInternal)Property).PublicIPAddressId; set => ((Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.ILoadBalancerFrontendIPConfigurationPropertiesInternal)Property).PublicIPAddressId = value ?? null; }

        /// <summary>Resource Id</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Origin(Microsoft.Azure.PowerShell.Cmdlets.CloudService.PropertyOrigin.Inlined)]
        public string SubnetId { get => ((Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.ILoadBalancerFrontendIPConfigurationPropertiesInternal)Property).SubnetId; set => ((Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.ILoadBalancerFrontendIPConfigurationPropertiesInternal)Property).SubnetId = value ?? null; }

        /// <summary>Creates an new <see cref="LoadBalancerFrontendIPConfiguration" /> instance.</summary>
        public LoadBalancerFrontendIPConfiguration()
        {

        }
    }
    public partial interface ILoadBalancerFrontendIPConfiguration :
        Microsoft.Azure.PowerShell.Cmdlets.CloudService.Runtime.IJsonSerializable
    {
        /// <summary>
        /// The name of the resource that is unique within the set of frontend IP configurations used by the load balancer. This name
        /// can be used to access the resource.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"The name of the resource that is unique within the set of frontend IP configurations used by the load balancer. This name can be used to access the resource.",
        SerializedName = @"name",
        PossibleTypes = new [] { typeof(string) })]
        string Name { get; set; }
        /// <summary>The virtual network private IP address of the IP configuration.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The virtual network private IP address of the IP configuration.",
        SerializedName = @"privateIPAddress",
        PossibleTypes = new [] { typeof(string) })]
        string PrivateIPAddress { get; set; }
        /// <summary>Resource Id</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Resource Id",
        SerializedName = @"id",
        PossibleTypes = new [] { typeof(string) })]
        string PublicIPAddressId { get; set; }
        /// <summary>Resource Id</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Resource Id",
        SerializedName = @"id",
        PossibleTypes = new [] { typeof(string) })]
        string SubnetId { get; set; }

    }
    internal partial interface ILoadBalancerFrontendIPConfigurationInternal

    {
        /// <summary>
        /// The name of the resource that is unique within the set of frontend IP configurations used by the load balancer. This name
        /// can be used to access the resource.
        /// </summary>
        string Name { get; set; }
        /// <summary>The virtual network private IP address of the IP configuration.</summary>
        string PrivateIPAddress { get; set; }
        /// <summary>Properties of load balancer frontend ip configuration.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.ILoadBalancerFrontendIPConfigurationProperties Property { get; set; }
        /// <summary>The reference to the public ip address resource.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.ISubResource PublicIPAddress { get; set; }
        /// <summary>Resource Id</summary>
        string PublicIPAddressId { get; set; }
        /// <summary>The reference to the virtual network subnet resource.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.ISubResource Subnet { get; set; }
        /// <summary>Resource Id</summary>
        string SubnetId { get; set; }

    }
}