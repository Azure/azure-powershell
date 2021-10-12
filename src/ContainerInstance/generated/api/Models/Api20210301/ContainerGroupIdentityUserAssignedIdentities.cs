namespace Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301
{
    using static Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.Extensions;

    /// <summary>
    /// The list of user identities associated with the container group. The user identity dictionary key references will be ARM
    /// resource ids in the form: '/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ManagedIdentity/userAssignedIdentities/{identityName}'.
    /// </summary>
    public partial class ContainerGroupIdentityUserAssignedIdentities :
        Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerGroupIdentityUserAssignedIdentities,
        Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerGroupIdentityUserAssignedIdentitiesInternal
    {

        /// <summary>
        /// Creates an new <see cref="ContainerGroupIdentityUserAssignedIdentities" /> instance.
        /// </summary>
        public ContainerGroupIdentityUserAssignedIdentities()
        {

        }
    }
    /// The list of user identities associated with the container group. The user identity dictionary key references will be ARM
    /// resource ids in the form: '/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ManagedIdentity/userAssignedIdentities/{identityName}'.
    public partial interface IContainerGroupIdentityUserAssignedIdentities :
        Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.IAssociativeArray<Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IComponents10Wh5UdSchemasContainergroupidentityPropertiesUserassignedidentitiesAdditionalproperties>
    {

    }
    /// The list of user identities associated with the container group. The user identity dictionary key references will be ARM
    /// resource ids in the form: '/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ManagedIdentity/userAssignedIdentities/{identityName}'.
    internal partial interface IContainerGroupIdentityUserAssignedIdentitiesInternal

    {

    }
}