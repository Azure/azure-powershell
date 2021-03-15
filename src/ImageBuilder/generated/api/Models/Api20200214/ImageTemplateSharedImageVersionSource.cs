namespace Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Models.Api20200214
{
    using static Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Runtime.Extensions;

    /// <summary>Describes an image source that is an image version in a shared image gallery.</summary>
    public partial class ImageTemplateSharedImageVersionSource :
        Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Models.Api20200214.IImageTemplateSharedImageVersionSource,
        Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Models.Api20200214.IImageTemplateSharedImageVersionSourceInternal,
        Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Runtime.IValidates
    {
        /// <summary>
        /// Backing field for Inherited model <see cref= "Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Models.Api20200214.IImageTemplateSource"
        /// />
        /// </summary>
        private Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Models.Api20200214.IImageTemplateSource __imageTemplateSource = new Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Models.Api20200214.ImageTemplateSource();

        /// <summary>Backing field for <see cref="ImageVersionId" /> property.</summary>
        private string _imageVersionId;

        /// <summary>ARM resource id of the image version in the shared image gallery</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Origin(Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.PropertyOrigin.Owned)]
        public string ImageVersionId { get => this._imageVersionId; set => this._imageVersionId = value; }

        /// <summary>Specifies the type of source image you want to start with.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Origin(Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.PropertyOrigin.Inherited)]
        public string Type { get => ((Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Models.Api20200214.IImageTemplateSourceInternal)__imageTemplateSource).Type; set => ((Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Models.Api20200214.IImageTemplateSourceInternal)__imageTemplateSource).Type = value ; }

        /// <summary>Creates an new <see cref="ImageTemplateSharedImageVersionSource" /> instance.</summary>
        public ImageTemplateSharedImageVersionSource()
        {

        }

        /// <summary>Validates that this object meets the validation criteria.</summary>
        /// <param name="eventListener">an <see cref="Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Runtime.IEventListener" /> instance that will receive validation
        /// events.</param>
        /// <returns>
        /// A < see cref = "global::System.Threading.Tasks.Task" /> that will be complete when validation is completed.
        /// </returns>
        public async global::System.Threading.Tasks.Task Validate(Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Runtime.IEventListener eventListener)
        {
            await eventListener.AssertNotNull(nameof(__imageTemplateSource), __imageTemplateSource);
            await eventListener.AssertObjectIsValid(nameof(__imageTemplateSource), __imageTemplateSource);
        }
    }
    /// Describes an image source that is an image version in a shared image gallery.
    public partial interface IImageTemplateSharedImageVersionSource :
        Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Models.Api20200214.IImageTemplateSource
    {
        /// <summary>ARM resource id of the image version in the shared image gallery</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"ARM resource id of the image version in the shared image gallery",
        SerializedName = @"imageVersionId",
        PossibleTypes = new [] { typeof(string) })]
        string ImageVersionId { get; set; }

    }
    /// Describes an image source that is an image version in a shared image gallery.
    public partial interface IImageTemplateSharedImageVersionSourceInternal :
        Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Models.Api20200214.IImageTemplateSourceInternal
    {
        /// <summary>ARM resource id of the image version in the shared image gallery</summary>
        string ImageVersionId { get; set; }

    }
}