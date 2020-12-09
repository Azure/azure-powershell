namespace Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.Extensions;

    /// <summary>
    /// The list of user identities associated with the Kusto cluster. The user identity dictionary key references will be ARM
    /// resource ids in the form: '/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ManagedIdentity/userAssignedIdentities/{identityName}'.
    /// </summary>
    public partial class IdentityUserAssignedIdentities :
        Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IIdentityUserAssignedIdentities,
        Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IIdentityUserAssignedIdentitiesInternal
    {

        /// <summary>Creates an new <see cref="IdentityUserAssignedIdentities" /> instance.</summary>
        public IdentityUserAssignedIdentities()
        {

        }
    }
    /// The list of user identities associated with the Kusto cluster. The user identity dictionary key references will be ARM
    /// resource ids in the form: '/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ManagedIdentity/userAssignedIdentities/{identityName}'.
    public partial interface IIdentityUserAssignedIdentities :
        Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.IAssociativeArray<Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IComponentsSgqdofSchemasIdentityPropertiesUserassignedidentitiesAdditionalproperties>
    {

    }
    /// The list of user identities associated with the Kusto cluster. The user identity dictionary key references will be ARM
    /// resource ids in the form: '/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ManagedIdentity/userAssignedIdentities/{identityName}'.
    internal partial interface IIdentityUserAssignedIdentitiesInternal

    {

    }
}