namespace Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Aks.Runtime.Extensions;

    /// <summary>Desired outbound IP resources for the cluster load balancer.</summary>
    public partial class ManagedClusterLoadBalancerProfileOutboundIPs :
        Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterLoadBalancerProfileOutboundIPs,
        Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterLoadBalancerProfileOutboundIPsInternal
    {

        /// <summary>Backing field for <see cref="PublicIP" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IResourceReference[] _publicIP;

        /// <summary>A list of public IP resources.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Origin(Microsoft.Azure.PowerShell.Cmdlets.Aks.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IResourceReference[] PublicIP { get => this._publicIP; set => this._publicIP = value; }

        /// <summary>
        /// Creates an new <see cref="ManagedClusterLoadBalancerProfileOutboundIPs" /> instance.
        /// </summary>
        public ManagedClusterLoadBalancerProfileOutboundIPs()
        {

        }
    }
    /// Desired outbound IP resources for the cluster load balancer.
    public partial interface IManagedClusterLoadBalancerProfileOutboundIPs :
        Microsoft.Azure.PowerShell.Cmdlets.Aks.Runtime.IJsonSerializable
    {
        /// <summary>A list of public IP resources.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"A list of public IP resources.",
        SerializedName = @"publicIPs",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IResourceReference) })]
        Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IResourceReference[] PublicIP { get; set; }

    }
    /// Desired outbound IP resources for the cluster load balancer.
    internal partial interface IManagedClusterLoadBalancerProfileOutboundIPsInternal

    {
        /// <summary>A list of public IP resources.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IResourceReference[] PublicIP { get; set; }

    }
}