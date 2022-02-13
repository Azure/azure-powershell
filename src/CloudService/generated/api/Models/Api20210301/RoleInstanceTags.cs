namespace Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301
{
    using static Microsoft.Azure.PowerShell.Cmdlets.CloudService.Runtime.Extensions;

    /// <summary>Resource tags.</summary>
    public partial class RoleInstanceTags :
        Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.IRoleInstanceTags,
        Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.IRoleInstanceTagsInternal
    {

        /// <summary>Creates an new <see cref="RoleInstanceTags" /> instance.</summary>
        public RoleInstanceTags()
        {

        }
    }
    /// Resource tags.
    public partial interface IRoleInstanceTags :
        Microsoft.Azure.PowerShell.Cmdlets.CloudService.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.CloudService.Runtime.IAssociativeArray<string>
    {

    }
    /// Resource tags.
    internal partial interface IRoleInstanceTagsInternal

    {

    }
}