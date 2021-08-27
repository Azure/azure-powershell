namespace Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Aks.Runtime.Extensions;

    /// <summary>
    /// The user identity associated with the managed cluster. This identity will be used in control plane and only one user assigned
    /// identity is allowed. The user identity dictionary key references will be ARM resource ids in the form: '/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ManagedIdentity/userAssignedIdentities/{identityName}'.
    /// </summary>
    public partial class ManagedClusterIdentityUserAssignedIdentities :
        Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterIdentityUserAssignedIdentities,
        Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterIdentityUserAssignedIdentitiesInternal
    {

        /// <summary>
        /// Creates an new <see cref="ManagedClusterIdentityUserAssignedIdentities" /> instance.
        /// </summary>
        public ManagedClusterIdentityUserAssignedIdentities()
        {

        }
    }
    /// The user identity associated with the managed cluster. This identity will be used in control plane and only one user assigned
    /// identity is allowed. The user identity dictionary key references will be ARM resource ids in the form: '/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ManagedIdentity/userAssignedIdentities/{identityName}'.
    public partial interface IManagedClusterIdentityUserAssignedIdentities :
        Microsoft.Azure.PowerShell.Cmdlets.Aks.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.Aks.Runtime.IAssociativeArray<Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterIdentityUserAssignedIdentitiesValue>
    {

    }
    /// The user identity associated with the managed cluster. This identity will be used in control plane and only one user assigned
    /// identity is allowed. The user identity dictionary key references will be ARM resource ids in the form: '/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ManagedIdentity/userAssignedIdentities/{identityName}'.
    internal partial interface IManagedClusterIdentityUserAssignedIdentitiesInternal

    {

    }
}