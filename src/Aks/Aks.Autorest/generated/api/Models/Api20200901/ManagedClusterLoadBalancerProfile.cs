namespace Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Aks.Runtime.Extensions;

    /// <summary>Profile of the managed cluster load balancer.</summary>
    public partial class ManagedClusterLoadBalancerProfile :
        Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterLoadBalancerProfile,
        Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterLoadBalancerProfileInternal
    {

        /// <summary>Backing field for <see cref="AllocatedOutboundPort" /> property.</summary>
        private int? _allocatedOutboundPort;

        /// <summary>
        /// Desired number of allocated SNAT ports per VM. Allowed values must be in the range of 0 to 64000 (inclusive). The default
        /// value is 0 which results in Azure dynamically allocating ports.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Origin(Microsoft.Azure.PowerShell.Cmdlets.Aks.PropertyOrigin.Owned)]
        public int? AllocatedOutboundPort { get => this._allocatedOutboundPort; set => this._allocatedOutboundPort = value; }

        /// <summary>Backing field for <see cref="EffectiveOutboundIP" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IResourceReference[] _effectiveOutboundIP;

        /// <summary>The effective outbound IP resources of the cluster load balancer.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Origin(Microsoft.Azure.PowerShell.Cmdlets.Aks.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IResourceReference[] EffectiveOutboundIP { get => this._effectiveOutboundIP; set => this._effectiveOutboundIP = value; }

        /// <summary>Backing field for <see cref="IdleTimeoutInMinute" /> property.</summary>
        private int? _idleTimeoutInMinute;

        /// <summary>
        /// Desired outbound flow idle timeout in minutes. Allowed values must be in the range of 4 to 120 (inclusive). The default
        /// value is 30 minutes.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Origin(Microsoft.Azure.PowerShell.Cmdlets.Aks.PropertyOrigin.Owned)]
        public int? IdleTimeoutInMinute { get => this._idleTimeoutInMinute; set => this._idleTimeoutInMinute = value; }

        /// <summary>Backing field for <see cref="ManagedOutboundIP" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterLoadBalancerProfileManagedOutboundIPs _managedOutboundIP;

        /// <summary>Desired managed outbound IPs for the cluster load balancer.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Origin(Microsoft.Azure.PowerShell.Cmdlets.Aks.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterLoadBalancerProfileManagedOutboundIPs ManagedOutboundIP { get => (this._managedOutboundIP = this._managedOutboundIP ?? new Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.ManagedClusterLoadBalancerProfileManagedOutboundIPs()); set => this._managedOutboundIP = value; }

        /// <summary>
        /// Desired number of outbound IP created/managed by Azure for the cluster load balancer. Allowed values must be in the range
        /// of 1 to 100 (inclusive). The default value is 1.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Origin(Microsoft.Azure.PowerShell.Cmdlets.Aks.PropertyOrigin.Inlined)]
        public int? ManagedOutboundIPCount { get => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterLoadBalancerProfileManagedOutboundIPsInternal)ManagedOutboundIP).Count; set => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterLoadBalancerProfileManagedOutboundIPsInternal)ManagedOutboundIP).Count = value ?? default(int); }

        /// <summary>Internal Acessors for ManagedOutboundIP</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterLoadBalancerProfileManagedOutboundIPs Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterLoadBalancerProfileInternal.ManagedOutboundIP { get => (this._managedOutboundIP = this._managedOutboundIP ?? new Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.ManagedClusterLoadBalancerProfileManagedOutboundIPs()); set { {_managedOutboundIP = value;} } }

        /// <summary>Internal Acessors for OutboundIP</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterLoadBalancerProfileOutboundIPs Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterLoadBalancerProfileInternal.OutboundIP { get => (this._outboundIP = this._outboundIP ?? new Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.ManagedClusterLoadBalancerProfileOutboundIPs()); set { {_outboundIP = value;} } }

        /// <summary>Internal Acessors for OutboundIPPrefix</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterLoadBalancerProfileOutboundIPPrefixes Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterLoadBalancerProfileInternal.OutboundIPPrefix { get => (this._outboundIPPrefix = this._outboundIPPrefix ?? new Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.ManagedClusterLoadBalancerProfileOutboundIPPrefixes()); set { {_outboundIPPrefix = value;} } }

        /// <summary>Backing field for <see cref="OutboundIP" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterLoadBalancerProfileOutboundIPs _outboundIP;

        /// <summary>Desired outbound IP resources for the cluster load balancer.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Origin(Microsoft.Azure.PowerShell.Cmdlets.Aks.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterLoadBalancerProfileOutboundIPs OutboundIP { get => (this._outboundIP = this._outboundIP ?? new Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.ManagedClusterLoadBalancerProfileOutboundIPs()); set => this._outboundIP = value; }

        /// <summary>Backing field for <see cref="OutboundIPPrefix" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterLoadBalancerProfileOutboundIPPrefixes _outboundIPPrefix;

        /// <summary>Desired outbound IP Prefix resources for the cluster load balancer.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Origin(Microsoft.Azure.PowerShell.Cmdlets.Aks.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterLoadBalancerProfileOutboundIPPrefixes OutboundIPPrefix { get => (this._outboundIPPrefix = this._outboundIPPrefix ?? new Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.ManagedClusterLoadBalancerProfileOutboundIPPrefixes()); set => this._outboundIPPrefix = value; }

        /// <summary>A list of public IP prefix resources.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Origin(Microsoft.Azure.PowerShell.Cmdlets.Aks.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IResourceReference[] OutboundIPPrefixPublicIpprefix { get => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterLoadBalancerProfileOutboundIPPrefixesInternal)OutboundIPPrefix).PublicIPPrefix; set => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterLoadBalancerProfileOutboundIPPrefixesInternal)OutboundIPPrefix).PublicIPPrefix = value ?? null /* arrayOf */; }

        /// <summary>A list of public IP resources.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Origin(Microsoft.Azure.PowerShell.Cmdlets.Aks.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IResourceReference[] OutboundIPPublicIP { get => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterLoadBalancerProfileOutboundIPsInternal)OutboundIP).PublicIP; set => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterLoadBalancerProfileOutboundIPsInternal)OutboundIP).PublicIP = value ?? null /* arrayOf */; }

        /// <summary>Creates an new <see cref="ManagedClusterLoadBalancerProfile" /> instance.</summary>
        public ManagedClusterLoadBalancerProfile()
        {

        }
    }
    /// Profile of the managed cluster load balancer.
    public partial interface IManagedClusterLoadBalancerProfile :
        Microsoft.Azure.PowerShell.Cmdlets.Aks.Runtime.IJsonSerializable
    {
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
        int? AllocatedOutboundPort { get; set; }
        /// <summary>The effective outbound IP resources of the cluster load balancer.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The effective outbound IP resources of the cluster load balancer.",
        SerializedName = @"effectiveOutboundIPs",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IResourceReference) })]
        Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IResourceReference[] EffectiveOutboundIP { get; set; }
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
        int? IdleTimeoutInMinute { get; set; }
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

    }
    /// Profile of the managed cluster load balancer.
    internal partial interface IManagedClusterLoadBalancerProfileInternal

    {
        /// <summary>
        /// Desired number of allocated SNAT ports per VM. Allowed values must be in the range of 0 to 64000 (inclusive). The default
        /// value is 0 which results in Azure dynamically allocating ports.
        /// </summary>
        int? AllocatedOutboundPort { get; set; }
        /// <summary>The effective outbound IP resources of the cluster load balancer.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IResourceReference[] EffectiveOutboundIP { get; set; }
        /// <summary>
        /// Desired outbound flow idle timeout in minutes. Allowed values must be in the range of 4 to 120 (inclusive). The default
        /// value is 30 minutes.
        /// </summary>
        int? IdleTimeoutInMinute { get; set; }
        /// <summary>Desired managed outbound IPs for the cluster load balancer.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterLoadBalancerProfileManagedOutboundIPs ManagedOutboundIP { get; set; }
        /// <summary>
        /// Desired number of outbound IP created/managed by Azure for the cluster load balancer. Allowed values must be in the range
        /// of 1 to 100 (inclusive). The default value is 1.
        /// </summary>
        int? ManagedOutboundIPCount { get; set; }
        /// <summary>Desired outbound IP resources for the cluster load balancer.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterLoadBalancerProfileOutboundIPs OutboundIP { get; set; }
        /// <summary>Desired outbound IP Prefix resources for the cluster load balancer.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterLoadBalancerProfileOutboundIPPrefixes OutboundIPPrefix { get; set; }
        /// <summary>A list of public IP prefix resources.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IResourceReference[] OutboundIPPrefixPublicIpprefix { get; set; }
        /// <summary>A list of public IP resources.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IResourceReference[] OutboundIPPublicIP { get; set; }

    }
}