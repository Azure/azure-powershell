namespace Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20181130
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Extensions;

    /// <summary>Resource tags</summary>
    public partial class SystemAssignedIdentityTags :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20181130.ISystemAssignedIdentityTags,
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20181130.ISystemAssignedIdentityTagsInternal
    {

        /// <summary>Creates an new <see cref="SystemAssignedIdentityTags" /> instance.</summary>
        public SystemAssignedIdentityTags()
        {

        }
    }
    /// Resource tags
    public partial interface ISystemAssignedIdentityTags :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.IAssociativeArray<string>
    {

    }
    /// Resource tags
    internal partial interface ISystemAssignedIdentityTagsInternal

    {

    }
}