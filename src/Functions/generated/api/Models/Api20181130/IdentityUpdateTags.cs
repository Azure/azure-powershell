namespace Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20181130
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Extensions;

    /// <summary>Resource tags</summary>
    public partial class IdentityUpdateTags :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20181130.IIdentityUpdateTags,
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20181130.IIdentityUpdateTagsInternal
    {

        /// <summary>Creates an new <see cref="IdentityUpdateTags" /> instance.</summary>
        public IdentityUpdateTags()
        {

        }
    }
    /// Resource tags
    public partial interface IIdentityUpdateTags :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.IAssociativeArray<string>
    {

    }
    /// Resource tags
    internal partial interface IIdentityUpdateTagsInternal

    {

    }
}