namespace Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview
{
    using static Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Runtime.Extensions;

    /// <summary>Resource tags.</summary>
    public partial class ResourcePatchTags :
        Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IResourcePatchTags,
        Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IResourcePatchTagsInternal
    {

        /// <summary>Creates an new <see cref="ResourcePatchTags" /> instance.</summary>
        public ResourcePatchTags()
        {

        }
    }
    /// Resource tags.
    public partial interface IResourcePatchTags :
        Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Runtime.IAssociativeArray<string>
    {

    }
    /// Resource tags.
    internal partial interface IResourcePatchTagsInternal

    {

    }
}