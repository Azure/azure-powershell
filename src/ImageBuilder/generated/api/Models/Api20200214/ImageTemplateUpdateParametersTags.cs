namespace Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Models.Api20200214
{
    using static Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Runtime.Extensions;

    /// <summary>The user-specified tags associated with the image template.</summary>
    public partial class ImageTemplateUpdateParametersTags :
        Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Models.Api20200214.IImageTemplateUpdateParametersTags,
        Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Models.Api20200214.IImageTemplateUpdateParametersTagsInternal
    {

        /// <summary>Creates an new <see cref="ImageTemplateUpdateParametersTags" /> instance.</summary>
        public ImageTemplateUpdateParametersTags()
        {

        }
    }
    /// The user-specified tags associated with the image template.
    public partial interface IImageTemplateUpdateParametersTags :
        Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Runtime.IAssociativeArray<string>
    {

    }
    /// The user-specified tags associated with the image template.
    public partial interface IImageTemplateUpdateParametersTagsInternal

    {

    }
}