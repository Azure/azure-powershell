// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.

namespace Microsoft.Azure.PowerShell.Cmdlets.Aks.Models
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Aks.Runtime.Extensions;

    /// <summary>Profile of the managed cluster load balancer.</summary>
    public partial class ManagedClusterLoadBalancerProfile :
        Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.IManagedClusterLoadBalancerProfile,
        Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.IManagedClusterLoadBalancerProfileInternal
    {

        /// <summary>Backing field for <see cref="AllocatedOutboundPort" /> property.</summary>
        private int? _allocatedOutboundPort;

        /// <summary>
        /// The desired number of allocated SNAT ports per VM. Allowed values are in the range of 0 to 64000 (inclusive). The default
        /// value is 0 which results in Azure dynamically allocating ports.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Origin(Microsoft.Azure.PowerShell.Cmdlets.Aks.PropertyOrigin.Owned)]
        public int? AllocatedOutboundPort { get => this._allocatedOutboundPort; set => this._allocatedOutboundPort = value; }

        /// <summary>Backing field for <see cref="EffectiveOutboundIP" /> property.</summary>
        private System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.IResourceReference> _effectiveOutboundIP;

        /// <summary>The effective outbound IP resources of the cluster load balancer.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Origin(Microsoft.Azure.PowerShell.Cmdlets.Aks.PropertyOrigin.Owned)]
        public System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.IResourceReference> EffectiveOutboundIP { get => this._effectiveOutboundIP; set => this._effectiveOutboundIP = value; }

        /// <summary>Backing field for <see cref="EnableMultipleStandardLoadBalancer" /> property.</summary>
        private bool? _enableMultipleStandardLoadBalancer;

        /// <summary>Enable multiple standard load balancers per AKS cluster or not.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Origin(Microsoft.Azure.PowerShell.Cmdlets.Aks.PropertyOrigin.Owned)]
        public bool? EnableMultipleStandardLoadBalancer { get => this._enableMultipleStandardLoadBalancer; set => this._enableMultipleStandardLoadBalancer = value; }

        /// <summary>Backing field for <see cref="IdleTimeoutInMinute" /> property.</summary>
        private int? _idleTimeoutInMinute;

        /// <summary>
        /// Desired outbound flow idle timeout in minutes. Allowed values are in the range of 4 to 120 (inclusive). The default value
        /// is 30 minutes.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Origin(Microsoft.Azure.PowerShell.Cmdlets.Aks.PropertyOrigin.Owned)]
        public int? IdleTimeoutInMinute { get => this._idleTimeoutInMinute; set => this._idleTimeoutInMinute = value; }

        /// <summary>Backing field for <see cref="ManagedOutboundIP" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.IManagedClusterLoadBalancerProfileManagedOutboundIPs _managedOutboundIP;

        /// <summary>Desired managed outbound IPs for the cluster load balancer.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Origin(Microsoft.Azure.PowerShell.Cmdlets.Aks.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.IManagedClusterLoadBalancerProfileManagedOutboundIPs ManagedOutboundIP { get => (this._managedOutboundIP = this._managedOutboundIP ?? new Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.ManagedClusterLoadBalancerProfileManagedOutboundIPs()); set => this._managedOutboundIP = value; }

        /// <summary>
        /// The desired number of IPv4 outbound IPs created/managed by Azure for the cluster load balancer. Allowed values must be
        /// in the range of 1 to 100 (inclusive). The default value is 1.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Origin(Microsoft.Azure.PowerShell.Cmdlets.Aks.PropertyOrigin.Inlined)]
        public int? ManagedOutboundIPCount { get => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.IManagedClusterLoadBalancerProfileManagedOutboundIPsInternal)ManagedOutboundIP).Count; set => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.IManagedClusterLoadBalancerProfileManagedOutboundIPsInternal)ManagedOutboundIP).Count = value ?? default(int); }

        /// <summary>
        /// The desired number of IPv6 outbound IPs created/managed by Azure for the cluster load balancer. Allowed values must be
        /// in the range of 1 to 100 (inclusive). The default value is 0 for single-stack and 1 for dual-stack.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Origin(Microsoft.Azure.PowerShell.Cmdlets.Aks.PropertyOrigin.Inlined)]
        public int? ManagedOutboundIPCountIpv6 { get => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.IManagedClusterLoadBalancerProfileManagedOutboundIPsInternal)ManagedOutboundIP).CountIPv6; set => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.IManagedClusterLoadBalancerProfileManagedOutboundIPsInternal)ManagedOutboundIP).CountIPv6 = value ?? default(int); }

        /// <summary>Internal Acessors for ManagedOutboundIP</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.IManagedClusterLoadBalancerProfileManagedOutboundIPs Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.IManagedClusterLoadBalancerProfileInternal.ManagedOutboundIP { get => (this._managedOutboundIP = this._managedOutboundIP ?? new Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.ManagedClusterLoadBalancerProfileManagedOutboundIPs()); set { {_managedOutboundIP = value;} } }

        /// <summary>Internal Acessors for OutboundIP</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.IManagedClusterLoadBalancerProfileOutboundIPs Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.IManagedClusterLoadBalancerProfileInternal.OutboundIP { get => (this._outboundIP = this._outboundIP ?? new Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.ManagedClusterLoadBalancerProfileOutboundIPs()); set { {_outboundIP = value;} } }

        /// <summary>Internal Acessors for OutboundIPPrefix</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.IManagedClusterLoadBalancerProfileOutboundIPPrefixes Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.IManagedClusterLoadBalancerProfileInternal.OutboundIPPrefix { get => (this._outboundIPPrefix = this._outboundIPPrefix ?? new Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.ManagedClusterLoadBalancerProfileOutboundIPPrefixes()); set { {_outboundIPPrefix = value;} } }

        /// <summary>Backing field for <see cref="OutboundIP" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.IManagedClusterLoadBalancerProfileOutboundIPs _outboundIP;

        /// <summary>Desired outbound IP resources for the cluster load balancer.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Origin(Microsoft.Azure.PowerShell.Cmdlets.Aks.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.IManagedClusterLoadBalancerProfileOutboundIPs OutboundIP { get => (this._outboundIP = this._outboundIP ?? new Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.ManagedClusterLoadBalancerProfileOutboundIPs()); set => this._outboundIP = value; }

        /// <summary>Backing field for <see cref="OutboundIPPrefix" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.IManagedClusterLoadBalancerProfileOutboundIPPrefixes _outboundIPPrefix;

        /// <summary>Desired outbound IP Prefix resources for the cluster load balancer.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Origin(Microsoft.Azure.PowerShell.Cmdlets.Aks.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.IManagedClusterLoadBalancerProfileOutboundIPPrefixes OutboundIPPrefix { get => (this._outboundIPPrefix = this._outboundIPPrefix ?? new Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.ManagedClusterLoadBalancerProfileOutboundIPPrefixes()); set => this._outboundIPPrefix = value; }

        /// <summary>A list of public IP prefix resources.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Origin(Microsoft.Azure.PowerShell.Cmdlets.Aks.PropertyOrigin.Inlined)]
        public System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.IResourceReference> OutboundIPPrefixPublicIpprefix { get => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.IManagedClusterLoadBalancerProfileOutboundIPPrefixesInternal)OutboundIPPrefix).PublicIPPrefix; set => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.IManagedClusterLoadBalancerProfileOutboundIPPrefixesInternal)OutboundIPPrefix).PublicIPPrefix = value ?? null /* arrayOf */; }

        /// <summary>A list of public IP resources.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Origin(Microsoft.Azure.PowerShell.Cmdlets.Aks.PropertyOrigin.Inlined)]
        public System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.IResourceReference> OutboundIPPublicIP { get => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.IManagedClusterLoadBalancerProfileOutboundIPsInternal)OutboundIP).PublicIP; set => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.IManagedClusterLoadBalancerProfileOutboundIPsInternal)OutboundIP).PublicIP = value ?? null /* arrayOf */; }

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
        /// The desired number of allocated SNAT ports per VM. Allowed values are in the range of 0 to 64000 (inclusive). The default
        /// value is 0 which results in Azure dynamically allocating ports.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"The desired number of allocated SNAT ports per VM. Allowed values are in the range of 0 to 64000 (inclusive). The default value is 0 which results in Azure dynamically allocating ports.",
        SerializedName = @"allocatedOutboundPorts",
        PossibleTypes = new [] { typeof(int) })]
        int? AllocatedOutboundPort { get; set; }
        /// <summary>The effective outbound IP resources of the cluster load balancer.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"The effective outbound IP resources of the cluster load balancer.",
        SerializedName = @"effectiveOutboundIPs",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.IResourceReference) })]
        System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.IResourceReference> EffectiveOutboundIP { get; set; }
        /// <summary>Enable multiple standard load balancers per AKS cluster or not.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"Enable multiple standard load balancers per AKS cluster or not.",
        SerializedName = @"enableMultipleStandardLoadBalancers",
        PossibleTypes = new [] { typeof(bool) })]
        bool? EnableMultipleStandardLoadBalancer { get; set; }
        /// <summary>
        /// Desired outbound flow idle timeout in minutes. Allowed values are in the range of 4 to 120 (inclusive). The default value
        /// is 30 minutes.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"Desired outbound flow idle timeout in minutes. Allowed values are in the range of 4 to 120 (inclusive). The default value is 30 minutes.",
        SerializedName = @"idleTimeoutInMinutes",
        PossibleTypes = new [] { typeof(int) })]
        int? IdleTimeoutInMinute { get; set; }
        /// <summary>
        /// The desired number of IPv4 outbound IPs created/managed by Azure for the cluster load balancer. Allowed values must be
        /// in the range of 1 to 100 (inclusive). The default value is 1.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"The desired number of IPv4 outbound IPs created/managed by Azure for the cluster load balancer. Allowed values must be in the range of 1 to 100 (inclusive). The default value is 1. ",
        SerializedName = @"count",
        PossibleTypes = new [] { typeof(int) })]
        int? ManagedOutboundIPCount { get; set; }
        /// <summary>
        /// The desired number of IPv6 outbound IPs created/managed by Azure for the cluster load balancer. Allowed values must be
        /// in the range of 1 to 100 (inclusive). The default value is 0 for single-stack and 1 for dual-stack.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"The desired number of IPv6 outbound IPs created/managed by Azure for the cluster load balancer. Allowed values must be in the range of 1 to 100 (inclusive). The default value is 0 for single-stack and 1 for dual-stack. ",
        SerializedName = @"countIPv6",
        PossibleTypes = new [] { typeof(int) })]
        int? ManagedOutboundIPCountIpv6 { get; set; }
        /// <summary>A list of public IP prefix resources.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"A list of public IP prefix resources.",
        SerializedName = @"publicIPPrefixes",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.IResourceReference) })]
        System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.IResourceReference> OutboundIPPrefixPublicIpprefix { get; set; }
        /// <summary>A list of public IP resources.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"A list of public IP resources.",
        SerializedName = @"publicIPs",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.IResourceReference) })]
        System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.IResourceReference> OutboundIPPublicIP { get; set; }

    }
    /// Profile of the managed cluster load balancer.
    internal partial interface IManagedClusterLoadBalancerProfileInternal

    {
        /// <summary>
        /// The desired number of allocated SNAT ports per VM. Allowed values are in the range of 0 to 64000 (inclusive). The default
        /// value is 0 which results in Azure dynamically allocating ports.
        /// </summary>
        int? AllocatedOutboundPort { get; set; }
        /// <summary>The effective outbound IP resources of the cluster load balancer.</summary>
        System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.IResourceReference> EffectiveOutboundIP { get; set; }
        /// <summary>Enable multiple standard load balancers per AKS cluster or not.</summary>
        bool? EnableMultipleStandardLoadBalancer { get; set; }
        /// <summary>
        /// Desired outbound flow idle timeout in minutes. Allowed values are in the range of 4 to 120 (inclusive). The default value
        /// is 30 minutes.
        /// </summary>
        int? IdleTimeoutInMinute { get; set; }
        /// <summary>Desired managed outbound IPs for the cluster load balancer.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.IManagedClusterLoadBalancerProfileManagedOutboundIPs ManagedOutboundIP { get; set; }
        /// <summary>
        /// The desired number of IPv4 outbound IPs created/managed by Azure for the cluster load balancer. Allowed values must be
        /// in the range of 1 to 100 (inclusive). The default value is 1.
        /// </summary>
        int? ManagedOutboundIPCount { get; set; }
        /// <summary>
        /// The desired number of IPv6 outbound IPs created/managed by Azure for the cluster load balancer. Allowed values must be
        /// in the range of 1 to 100 (inclusive). The default value is 0 for single-stack and 1 for dual-stack.
        /// </summary>
        int? ManagedOutboundIPCountIpv6 { get; set; }
        /// <summary>Desired outbound IP resources for the cluster load balancer.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.IManagedClusterLoadBalancerProfileOutboundIPs OutboundIP { get; set; }
        /// <summary>Desired outbound IP Prefix resources for the cluster load balancer.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.IManagedClusterLoadBalancerProfileOutboundIPPrefixes OutboundIPPrefix { get; set; }
        /// <summary>A list of public IP prefix resources.</summary>
        System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.IResourceReference> OutboundIPPrefixPublicIpprefix { get; set; }
        /// <summary>A list of public IP resources.</summary>
        System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.IResourceReference> OutboundIPPublicIP { get; set; }

    }
}