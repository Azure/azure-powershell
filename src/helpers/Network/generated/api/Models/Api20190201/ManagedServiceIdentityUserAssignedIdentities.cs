namespace Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Extensions;

    /// <summary>
    /// The list of user identities associated with resource. The user identity dictionary key references will be ARM resource
    /// ids in the form: '/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ManagedIdentity/userAssignedIdentities/{identityName}'.
    /// </summary>
    public partial class ManagedServiceIdentityUserAssignedIdentities :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IManagedServiceIdentityUserAssignedIdentities,
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IManagedServiceIdentityUserAssignedIdentitiesInternal
    {

        /// <summary>
        /// Creates an new <see cref="ManagedServiceIdentityUserAssignedIdentities" /> instance.
        /// </summary>
        public ManagedServiceIdentityUserAssignedIdentities()
        {

        }
    }
    /// The list of user identities associated with resource. The user identity dictionary key references will be ARM resource
    /// ids in the form: '/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ManagedIdentity/userAssignedIdentities/{identityName}'.
    public partial interface IManagedServiceIdentityUserAssignedIdentities :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.IAssociativeArray<Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IComponentsSchemasManagedserviceidentityPropertiesUserassignedidentitiesAdditionalproperties>
    {

    }
    /// The list of user identities associated with resource. The user identity dictionary key references will be ARM resource
    /// ids in the form: '/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ManagedIdentity/userAssignedIdentities/{identityName}'.
    internal partial interface IManagedServiceIdentityUserAssignedIdentitiesInternal

    {

    }
}