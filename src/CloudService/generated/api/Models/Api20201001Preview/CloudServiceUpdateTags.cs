namespace Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20201001Preview
{
    using static Microsoft.Azure.PowerShell.Cmdlets.CloudService.Runtime.Extensions;

    /// <summary>Resource tags</summary>
    public partial class CloudServiceUpdateTags :
        Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20201001Preview.ICloudServiceUpdateTags,
        Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20201001Preview.ICloudServiceUpdateTagsInternal
    {

        /// <summary>Creates an new <see cref="CloudServiceUpdateTags" /> instance.</summary>
        public CloudServiceUpdateTags()
        {

        }
    }
    /// Resource tags
    public partial interface ICloudServiceUpdateTags :
        Microsoft.Azure.PowerShell.Cmdlets.CloudService.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.CloudService.Runtime.IAssociativeArray<string>
    {

    }
    /// Resource tags
    internal partial interface ICloudServiceUpdateTagsInternal

    {

    }
}