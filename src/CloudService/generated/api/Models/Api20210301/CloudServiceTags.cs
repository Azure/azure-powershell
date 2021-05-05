namespace Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301
{
    using static Microsoft.Azure.PowerShell.Cmdlets.CloudService.Runtime.Extensions;

    /// <summary>Resource tags.</summary>
    public partial class CloudServiceTags :
        Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.ICloudServiceTags,
        Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.ICloudServiceTagsInternal
    {

        /// <summary>Creates an new <see cref="CloudServiceTags" /> instance.</summary>
        public CloudServiceTags()
        {

        }
    }
    /// Resource tags.
    public partial interface ICloudServiceTags :
        Microsoft.Azure.PowerShell.Cmdlets.CloudService.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.CloudService.Runtime.IAssociativeArray<string>
    {

    }
    /// Resource tags.
    internal partial interface ICloudServiceTagsInternal

    {

    }
}