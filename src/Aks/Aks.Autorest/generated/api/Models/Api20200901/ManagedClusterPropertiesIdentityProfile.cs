namespace Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Aks.Runtime.Extensions;

    /// <summary>Identities associated with the cluster.</summary>
    public partial class ManagedClusterPropertiesIdentityProfile :
        Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterPropertiesIdentityProfile,
        Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterPropertiesIdentityProfileInternal
    {

        /// <summary>Creates an new <see cref="ManagedClusterPropertiesIdentityProfile" /> instance.</summary>
        public ManagedClusterPropertiesIdentityProfile()
        {

        }
    }
    /// Identities associated with the cluster.
    public partial interface IManagedClusterPropertiesIdentityProfile :
        Microsoft.Azure.PowerShell.Cmdlets.Aks.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.Aks.Runtime.IAssociativeArray<Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IUserAssignedIdentity>
    {

    }
    /// Identities associated with the cluster.
    internal partial interface IManagedClusterPropertiesIdentityProfileInternal

    {

    }
}