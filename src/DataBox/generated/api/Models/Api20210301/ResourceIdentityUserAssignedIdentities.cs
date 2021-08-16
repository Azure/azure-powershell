namespace Microsoft.Azure.PowerShell.Cmdlets.DataBox.Models.Api20210301
{
    using static Microsoft.Azure.PowerShell.Cmdlets.DataBox.Runtime.Extensions;

    /// <summary>User Assigned Identities</summary>
    public partial class ResourceIdentityUserAssignedIdentities :
        Microsoft.Azure.PowerShell.Cmdlets.DataBox.Models.Api20210301.IResourceIdentityUserAssignedIdentities,
        Microsoft.Azure.PowerShell.Cmdlets.DataBox.Models.Api20210301.IResourceIdentityUserAssignedIdentitiesInternal
    {

        /// <summary>Creates an new <see cref="ResourceIdentityUserAssignedIdentities" /> instance.</summary>
        public ResourceIdentityUserAssignedIdentities()
        {

        }
    }
    /// User Assigned Identities
    public partial interface IResourceIdentityUserAssignedIdentities :
        Microsoft.Azure.PowerShell.Cmdlets.DataBox.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.DataBox.Runtime.IAssociativeArray<Microsoft.Azure.PowerShell.Cmdlets.DataBox.Models.Api20210301.IUserAssignedIdentity>
    {

    }
    /// User Assigned Identities
    internal partial interface IResourceIdentityUserAssignedIdentitiesInternal

    {

    }
}