namespace Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Aks.Runtime.Extensions;

    /// <summary>Profile of network configuration.</summary>
    public partial class ContainerServiceNetworkProfile :
        Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IContainerServiceNetworkProfile,
        Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IContainerServiceNetworkProfileInternal
    {

        /// <summary>Backing field for <see cref="DnsServiceIP" /> property.</summary>
        private string _dnsServiceIP;

        /// <summary>
        /// An IP address assigned to the Kubernetes DNS service. It must be within the Kubernetes service address range specified
        /// in serviceCidr.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Origin(Microsoft.Azure.PowerShell.Cmdlets.Aks.PropertyOrigin.Owned)]
        public string DnsServiceIP { get => this._dnsServiceIP; set => this._dnsServiceIP = value; }

        /// <summary>Backing field for <see cref="DockerBridgeCidr" /> property.</summary>
        private string _dockerBridgeCidr;

        /// <summary>
        /// A CIDR notation IP range assigned to the Docker bridge network. It must not overlap with any Subnet IP ranges or the Kubernetes
        /// service address range.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Origin(Microsoft.Azure.PowerShell.Cmdlets.Aks.PropertyOrigin.Owned)]
        public string DockerBridgeCidr { get => this._dockerBridgeCidr; set => this._dockerBridgeCidr = value; }

        /// <summary>Backing field for <see cref="LoadBalancerProfile" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterLoadBalancerProfile _loadBalancerProfile;

        /// <summary>Profile of the cluster load balancer.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Origin(Microsoft.Azure.PowerShell.Cmdlets.Aks.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterLoadBalancerProfile LoadBalancerProfile { get => (this._loadBalancerProfile = this._loadBalancerProfile ?? new Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.ManagedClusterLoadBalancerProfile()); set => this._loadBalancerProfile = value; }

        /// <summary>
        /// Desired number of allocated SNAT ports per VM. Allowed values must be in the range of 0 to 64000 (inclusive). The default
        /// value is 0 which results in Azure dynamically allocating ports.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Origin(Microsoft.Azure.PowerShell.Cmdlets.Aks.PropertyOrigin.Inlined)]
        public int? LoadBalancerProfileAllocatedOutboundPort { get => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterLoadBalancerProfileInternal)LoadBalancerProfile).AllocatedOutboundPort; set => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterLoadBalancerProfileInternal)LoadBalancerProfile).AllocatedOutboundPort = value ?? default(int); }

        /// <summary>The effective outbound IP resources of the cluster load balancer.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Origin(Microsoft.Azure.PowerShell.Cmdlets.Aks.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IResourceReference[] LoadBalancerProfileEffectiveOutboundIP { get => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterLoadBalancerProfileInternal)LoadBalancerProfile).EffectiveOutboundIP; set => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterLoadBalancerProfileInternal)LoadBalancerProfile).EffectiveOutboundIP = value ?? null /* arrayOf */; }

        /// <summary>
        /// Desired outbound flow idle timeout in minutes. Allowed values must be in the range of 4 to 120 (inclusive). The default
        /// value is 30 minutes.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Origin(Microsoft.Azure.PowerShell.Cmdlets.Aks.PropertyOrigin.Inlined)]
        public int? LoadBalancerProfileIdleTimeoutInMinute { get => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterLoadBalancerProfileInternal)LoadBalancerProfile).IdleTimeoutInMinute; set => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterLoadBalancerProfileInternal)LoadBalancerProfile).IdleTimeoutInMinute = value ?? default(int); }

        /// <summary>Backing field for <see cref="LoadBalancerSku" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Aks.Support.LoadBalancerSku? _loadBalancerSku;

        /// <summary>The load balancer sku for the managed cluster.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Origin(Microsoft.Azure.PowerShell.Cmdlets.Aks.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Aks.Support.LoadBalancerSku? LoadBalancerSku { get => this._loadBalancerSku; set => this._loadBalancerSku = value; }

        /// <summary>
        /// Desired number of outbound IP created/managed by Azure for the cluster load balancer. Allowed values must be in the range
        /// of 1 to 100 (inclusive). The default value is 1.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Origin(Microsoft.Azure.PowerShell.Cmdlets.Aks.PropertyOrigin.Inlined)]
        public int? ManagedOutboundIPCount { get => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterLoadBalancerProfileInternal)LoadBalancerProfile).ManagedOutboundIPCount; set => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterLoadBalancerProfileInternal)LoadBalancerProfile).ManagedOutboundIPCount = value ?? default(int); }

        /// <summary>Internal Acessors for LoadBalancerProfile</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterLoadBalancerProfile Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IContainerServiceNetworkProfileInternal.LoadBalancerProfile { get => (this._loadBalancerProfile = this._loadBalancerProfile ?? new Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.ManagedClusterLoadBalancerProfile()); set { {_loadBalancerProfile = value;} } }

        /// <summary>Internal Acessors for LoadBalancerProfileManagedOutboundIP</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterLoadBalancerProfileManagedOutboundIPs Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IContainerServiceNetworkProfileInternal.LoadBalancerProfileManagedOutboundIP { get => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterLoadBalancerProfileInternal)LoadBalancerProfile).ManagedOutboundIP; set => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterLoadBalancerProfileInternal)LoadBalancerProfile).ManagedOutboundIP = value; }

        /// <summary>Internal Acessors for LoadBalancerProfileOutboundIP</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterLoadBalancerProfileOutboundIPs Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IContainerServiceNetworkProfileInternal.LoadBalancerProfileOutboundIP { get => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterLoadBalancerProfileInternal)LoadBalancerProfile).OutboundIP; set => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterLoadBalancerProfileInternal)LoadBalancerProfile).OutboundIP = value; }

        /// <summary>Internal Acessors for LoadBalancerProfileOutboundIPPrefix</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterLoadBalancerProfileOutboundIPPrefixes Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IContainerServiceNetworkProfileInternal.LoadBalancerProfileOutboundIPPrefix { get => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterLoadBalancerProfileInternal)LoadBalancerProfile).OutboundIPPrefix; set => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterLoadBalancerProfileInternal)LoadBalancerProfile).OutboundIPPrefix = value; }

        /// <summary>Backing field for <see cref="NetworkMode" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Aks.Support.NetworkMode? _networkMode;

        /// <summary>Network mode used for building Kubernetes network.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Origin(Microsoft.Azure.PowerShell.Cmdlets.Aks.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Aks.Support.NetworkMode? NetworkMode { get => this._networkMode; set => this._networkMode = value; }

        /// <summary>Backing field for <see cref="NetworkPlugin" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Aks.Support.NetworkPlugin? _networkPlugin;

        /// <summary>Network plugin used for building Kubernetes network.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Origin(Microsoft.Azure.PowerShell.Cmdlets.Aks.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Aks.Support.NetworkPlugin? NetworkPlugin { get => this._networkPlugin; set => this._networkPlugin = value; }

        /// <summary>Backing field for <see cref="NetworkPolicy" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Aks.Support.NetworkPolicy? _networkPolicy;

        /// <summary>Network policy used for building Kubernetes network.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Origin(Microsoft.Azure.PowerShell.Cmdlets.Aks.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Aks.Support.NetworkPolicy? NetworkPolicy { get => this._networkPolicy; set => this._networkPolicy = value; }

        /// <summary>A list of public IP prefix resources.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Origin(Microsoft.Azure.PowerShell.Cmdlets.Aks.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IResourceReference[] OutboundIPPrefixPublicIpprefix { get => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterLoadBalancerProfileInternal)LoadBalancerProfile).OutboundIPPrefixPublicIpprefix; set => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterLoadBalancerProfileInternal)LoadBalancerProfile).OutboundIPPrefixPublicIpprefix = value ?? null /* arrayOf */; }

        /// <summary>A list of public IP resources.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Origin(Microsoft.Azure.PowerShell.Cmdlets.Aks.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IResourceReference[] OutboundIPPublicIP { get => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterLoadBalancerProfileInternal)LoadBalancerProfile).OutboundIPPublicIP; set => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterLoadBalancerProfileInternal)LoadBalancerProfile).OutboundIPPublicIP = value ?? null /* arrayOf */; }

        /// <summary>Backing field for <see cref="OutboundType" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Aks.Support.OutboundType? _outboundType;

        /// <summary>The outbound (egress) routing method.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Origin(Microsoft.Azure.PowerShell.Cmdlets.Aks.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Aks.Support.OutboundType? OutboundType { get => this._outboundType; set => this._outboundType = value; }

        /// <summary>Backing field for <see cref="PodCidr" /> property.</summary>
        private string _podCidr;

        /// <summary>A CIDR notation IP range from which to assign pod IPs when kubenet is used.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Origin(Microsoft.Azure.PowerShell.Cmdlets.Aks.PropertyOrigin.Owned)]
        public string PodCidr { get => this._podCidr; set => this._podCidr = value; }

        /// <summary>Backing field for <see cref="ServiceCidr" /> property.</summary>
        private string _serviceCidr;

        /// <summary>
        /// A CIDR notation IP range from which to assign service cluster IPs. It must not overlap with any Subnet IP ranges.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Origin(Microsoft.Azure.PowerShell.Cmdlets.Aks.PropertyOrigin.Owned)]
        public string ServiceCidr { get => this._serviceCidr; set => this._serviceCidr = value; }

        /// <summary>Creates an new <see cref="ContainerServiceNetworkProfile" /> instance.</summary>
        public ContainerServiceNetworkProfile()
        {

        }
    }
    /// Profile of network configuration.
    public partial interface IContainerServiceNetworkProfile :
        Microsoft.Azure.PowerShell.Cmdlets.Aks.Runtime.IJsonSerializable
    {
        /// <summary>
        /// An IP address assigned to the Kubernetes DNS service. It must be within the Kubernetes service address range specified
        /// in serviceCidr.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"An IP address assigned to the Kubernetes DNS service. It must be within the Kubernetes service address range specified in serviceCidr.",
        SerializedName = @"dnsServiceIP",
        PossibleTypes = new [] { typeof(string) })]
        string DnsServiceIP { get; set; }
        /// <summary>
        /// A CIDR notation IP range assigned to the Docker bridge network. It must not overlap with any Subnet IP ranges or the Kubernetes
        /// service address range.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"A CIDR notation IP range assigned to the Docker bridge network. It must not overlap with any Subnet IP ranges or the Kubernetes service address range.",
        SerializedName = @"dockerBridgeCidr",
        PossibleTypes = new [] { typeof(string) })]
        string DockerBridgeCidr { get; set; }
        /// <summary>
        /// Desired number of allocated SNAT ports per VM. Allowed values must be in the range of 0 to 64000 (inclusive). The default
        /// value is 0 which results in Azure dynamically allocating ports.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Desired number of allocated SNAT ports per VM. Allowed values must be in the range of 0 to 64000 (inclusive). The default value is 0 which results in Azure dynamically allocating ports.",
        SerializedName = @"allocatedOutboundPorts",
        PossibleTypes = new [] { typeof(int) })]
        int? LoadBalancerProfileAllocatedOutboundPort { get; set; }
        /// <summary>The effective outbound IP resources of the cluster load balancer.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The effective outbound IP resources of the cluster load balancer.",
        SerializedName = @"effectiveOutboundIPs",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IResourceReference) })]
        Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IResourceReference[] LoadBalancerProfileEffectiveOutboundIP { get; set; }
        /// <summary>
        /// Desired outbound flow idle timeout in minutes. Allowed values must be in the range of 4 to 120 (inclusive). The default
        /// value is 30 minutes.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Desired outbound flow idle timeout in minutes. Allowed values must be in the range of 4 to 120 (inclusive). The default value is 30 minutes.",
        SerializedName = @"idleTimeoutInMinutes",
        PossibleTypes = new [] { typeof(int) })]
        int? LoadBalancerProfileIdleTimeoutInMinute { get; set; }
        /// <summary>The load balancer sku for the managed cluster.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The load balancer sku for the managed cluster.",
        SerializedName = @"loadBalancerSku",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Aks.Support.LoadBalancerSku) })]
        Microsoft.Azure.PowerShell.Cmdlets.Aks.Support.LoadBalancerSku? LoadBalancerSku { get; set; }
        /// <summary>
        /// Desired number of outbound IP created/managed by Azure for the cluster load balancer. Allowed values must be in the range
        /// of 1 to 100 (inclusive). The default value is 1.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Desired number of outbound IP created/managed by Azure for the cluster load balancer. Allowed values must be in the range of 1 to 100 (inclusive). The default value is 1. ",
        SerializedName = @"count",
        PossibleTypes = new [] { typeof(int) })]
        int? ManagedOutboundIPCount { get; set; }
        /// <summary>Network mode used for building Kubernetes network.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Network mode used for building Kubernetes network.",
        SerializedName = @"networkMode",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Aks.Support.NetworkMode) })]
        Microsoft.Azure.PowerShell.Cmdlets.Aks.Support.NetworkMode? NetworkMode { get; set; }
        /// <summary>Network plugin used for building Kubernetes network.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Network plugin used for building Kubernetes network.",
        SerializedName = @"networkPlugin",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Aks.Support.NetworkPlugin) })]
        Microsoft.Azure.PowerShell.Cmdlets.Aks.Support.NetworkPlugin? NetworkPlugin { get; set; }
        /// <summary>Network policy used for building Kubernetes network.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Network policy used for building Kubernetes network.",
        SerializedName = @"networkPolicy",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Aks.Support.NetworkPolicy) })]
        Microsoft.Azure.PowerShell.Cmdlets.Aks.Support.NetworkPolicy? NetworkPolicy { get; set; }
        /// <summary>A list of public IP prefix resources.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"A list of public IP prefix resources.",
        SerializedName = @"publicIPPrefixes",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IResourceReference) })]
        Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IResourceReference[] OutboundIPPrefixPublicIpprefix { get; set; }
        /// <summary>A list of public IP resources.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"A list of public IP resources.",
        SerializedName = @"publicIPs",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IResourceReference) })]
        Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IResourceReference[] OutboundIPPublicIP { get; set; }
        /// <summary>The outbound (egress) routing method.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The outbound (egress) routing method.",
        SerializedName = @"outboundType",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Aks.Support.OutboundType) })]
        Microsoft.Azure.PowerShell.Cmdlets.Aks.Support.OutboundType? OutboundType { get; set; }
        /// <summary>A CIDR notation IP range from which to assign pod IPs when kubenet is used.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"A CIDR notation IP range from which to assign pod IPs when kubenet is used.",
        SerializedName = @"podCidr",
        PossibleTypes = new [] { typeof(string) })]
        string PodCidr { get; set; }
        /// <summary>
        /// A CIDR notation IP range from which to assign service cluster IPs. It must not overlap with any Subnet IP ranges.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"A CIDR notation IP range from which to assign service cluster IPs. It must not overlap with any Subnet IP ranges.",
        SerializedName = @"serviceCidr",
        PossibleTypes = new [] { typeof(string) })]
        string ServiceCidr { get; set; }

    }
    /// Profile of network configuration.
    internal partial interface IContainerServiceNetworkProfileInternal

    {
        /// <summary>
        /// An IP address assigned to the Kubernetes DNS service. It must be within the Kubernetes service address range specified
        /// in serviceCidr.
        /// </summary>
        string DnsServiceIP { get; set; }
        /// <summary>
        /// A CIDR notation IP range assigned to the Docker bridge network. It must not overlap with any Subnet IP ranges or the Kubernetes
        /// service address range.
        /// </summary>
        string DockerBridgeCidr { get; set; }
        /// <summary>Profile of the cluster load balancer.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterLoadBalancerProfile LoadBalancerProfile { get; set; }
        /// <summary>
        /// Desired number of allocated SNAT ports per VM. Allowed values must be in the range of 0 to 64000 (inclusive). The default
        /// value is 0 which results in Azure dynamically allocating ports.
        /// </summary>
        int? LoadBalancerProfileAllocatedOutboundPort { get; set; }
        /// <summary>The effective outbound IP resources of the cluster load balancer.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IResourceReference[] LoadBalancerProfileEffectiveOutboundIP { get; set; }
        /// <summary>
        /// Desired outbound flow idle timeout in minutes. Allowed values must be in the range of 4 to 120 (inclusive). The default
        /// value is 30 minutes.
        /// </summary>
        int? LoadBalancerProfileIdleTimeoutInMinute { get; set; }
        /// <summary>Desired managed outbound IPs for the cluster load balancer.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterLoadBalancerProfileManagedOutboundIPs LoadBalancerProfileManagedOutboundIP { get; set; }
        /// <summary>Desired outbound IP resources for the cluster load balancer.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterLoadBalancerProfileOutboundIPs LoadBalancerProfileOutboundIP { get; set; }
        /// <summary>Desired outbound IP Prefix resources for the cluster load balancer.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterLoadBalancerProfileOutboundIPPrefixes LoadBalancerProfileOutboundIPPrefix { get; set; }
        /// <summary>The load balancer sku for the managed cluster.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Aks.Support.LoadBalancerSku? LoadBalancerSku { get; set; }
        /// <summary>
        /// Desired number of outbound IP created/managed by Azure for the cluster load balancer. Allowed values must be in the range
        /// of 1 to 100 (inclusive). The default value is 1.
        /// </summary>
        int? ManagedOutboundIPCount { get; set; }
        /// <summary>Network mode used for building Kubernetes network.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Aks.Support.NetworkMode? NetworkMode { get; set; }
        /// <summary>Network plugin used for building Kubernetes network.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Aks.Support.NetworkPlugin? NetworkPlugin { get; set; }
        /// <summary>Network policy used for building Kubernetes network.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Aks.Support.NetworkPolicy? NetworkPolicy { get; set; }
        /// <summary>A list of public IP prefix resources.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IResourceReference[] OutboundIPPrefixPublicIpprefix { get; set; }
        /// <summary>A list of public IP resources.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IResourceReference[] OutboundIPPublicIP { get; set; }
        /// <summary>The outbound (egress) routing method.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Aks.Support.OutboundType? OutboundType { get; set; }
        /// <summary>A CIDR notation IP range from which to assign pod IPs when kubenet is used.</summary>
        string PodCidr { get; set; }
        /// <summary>
        /// A CIDR notation IP range from which to assign service cluster IPs. It must not overlap with any Subnet IP ranges.
        /// </summary>
        string ServiceCidr { get; set; }

    }
}