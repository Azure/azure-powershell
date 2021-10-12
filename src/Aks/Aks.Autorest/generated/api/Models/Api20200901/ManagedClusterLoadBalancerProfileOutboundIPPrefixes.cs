namespace Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Aks.Runtime.Extensions;

    /// <summary>Desired outbound IP Prefix resources for the cluster load balancer.</summary>
    public partial class ManagedClusterLoadBalancerProfileOutboundIPPrefixes :
        Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterLoadBalancerProfileOutboundIPPrefixes,
        Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterLoadBalancerProfileOutboundIPPrefixesInternal
    {

        /// <summary>Backing field for <see cref="PublicIPPrefix" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IResourceReference[] _publicIPPrefix;

        /// <summary>A list of public IP prefix resources.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Origin(Microsoft.Azure.PowerShell.Cmdlets.Aks.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IResourceReference[] PublicIPPrefix { get => this._publicIPPrefix; set => this._publicIPPrefix = value; }

        /// <summary>
        /// Creates an new <see cref="ManagedClusterLoadBalancerProfileOutboundIPPrefixes" /> instance.
        /// </summary>
        public ManagedClusterLoadBalancerProfileOutboundIPPrefixes()
        {

        }
    }
    /// Desired outbound IP Prefix resources for the cluster load balancer.
    public partial interface IManagedClusterLoadBalancerProfileOutboundIPPrefixes :
        Microsoft.Azure.PowerShell.Cmdlets.Aks.Runtime.IJsonSerializable
    {
        /// <summary>A list of public IP prefix resources.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"A list of public IP prefix resources.",
        SerializedName = @"publicIPPrefixes",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IResourceReference) })]
        Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IResourceReference[] PublicIPPrefix { get; set; }

    }
    /// Desired outbound IP Prefix resources for the cluster load balancer.
    internal partial interface IManagedClusterLoadBalancerProfileOutboundIPPrefixesInternal

    {
        /// <summary>A list of public IP prefix resources.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IResourceReference[] PublicIPPrefix { get; set; }

    }
}