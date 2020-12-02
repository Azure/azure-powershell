namespace Microsoft.Azure.PowerShell.Cmdlets.DedicatedHsm.Models.Api20181031
{
    using static Microsoft.Azure.PowerShell.Cmdlets.DedicatedHsm.Runtime.Extensions;

    /// <summary>Resource tags</summary>
    public partial class ResourceTags :
        Microsoft.Azure.PowerShell.Cmdlets.DedicatedHsm.Models.Api20181031.IResourceTags,
        Microsoft.Azure.PowerShell.Cmdlets.DedicatedHsm.Models.Api20181031.IResourceTagsInternal
    {

        /// <summary>Creates an new <see cref="ResourceTags" /> instance.</summary>
        public ResourceTags()
        {

        }
    }
    /// Resource tags
    public partial interface IResourceTags :
        Microsoft.Azure.PowerShell.Cmdlets.DedicatedHsm.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.DedicatedHsm.Runtime.IAssociativeArray<string>
    {

    }
    /// Resource tags
    internal partial interface IResourceTagsInternal

    {

    }
}