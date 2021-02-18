namespace Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Models.Api20200214
{
    using static Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Runtime.Extensions;

    /// <summary>
    /// Tags that will be applied to the artifact once it has been created/updated by the distributor.
    /// </summary>
    public partial class ImageTemplateDistributorArtifactTags :
        Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Models.Api20200214.IImageTemplateDistributorArtifactTags,
        Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Models.Api20200214.IImageTemplateDistributorArtifactTagsInternal
    {

        /// <summary>Creates an new <see cref="ImageTemplateDistributorArtifactTags" /> instance.</summary>
        public ImageTemplateDistributorArtifactTags()
        {

        }
    }
    /// Tags that will be applied to the artifact once it has been created/updated by the distributor.
    public partial interface IImageTemplateDistributorArtifactTags :
        Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Runtime.IAssociativeArray<string>
    {

    }
    /// Tags that will be applied to the artifact once it has been created/updated by the distributor.
    public partial interface IImageTemplateDistributorArtifactTagsInternal

    {

    }
}