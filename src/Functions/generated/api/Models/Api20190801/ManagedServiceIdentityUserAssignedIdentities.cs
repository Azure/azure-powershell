namespace Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Extensions;

    /// <summary>
    /// The list of user assigned identities associated with the resource. The user identity dictionary key references will be
    /// ARM resource ids in the form: '/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ManagedIdentity/userAssignedIdentities/{identityName}
    /// </summary>
    public partial class ManagedServiceIdentityUserAssignedIdentities :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IManagedServiceIdentityUserAssignedIdentities,
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IManagedServiceIdentityUserAssignedIdentitiesInternal
    {

        /// <summary>
        /// Creates an new <see cref="ManagedServiceIdentityUserAssignedIdentities" /> instance.
        /// </summary>
        public ManagedServiceIdentityUserAssignedIdentities()
        {

        }
    }
    /// The list of user assigned identities associated with the resource. The user identity dictionary key references will be
    /// ARM resource ids in the form: '/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ManagedIdentity/userAssignedIdentities/{identityName}
    public partial interface IManagedServiceIdentityUserAssignedIdentities :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.IAssociativeArray<Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IComponents1Jq1T4ISchemasManagedserviceidentityPropertiesUserassignedidentitiesAdditionalproperties>
    {

    }
    /// The list of user assigned identities associated with the resource. The user identity dictionary key references will be
    /// ARM resource ids in the form: '/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ManagedIdentity/userAssignedIdentities/{identityName}
    internal partial interface IManagedServiceIdentityUserAssignedIdentitiesInternal

    {

    }
}