namespace Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Models.Api20200214
{
    using static Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Runtime.Extensions;

    /// <summary>Describes an image source that is a managed image in customer subscription.</summary>
    public partial class ImageTemplateManagedImageSource :
        Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Models.Api20200214.IImageTemplateManagedImageSource,
        Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Models.Api20200214.IImageTemplateManagedImageSourceInternal,
        Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Runtime.IValidates
    {
        /// <summary>
        /// Backing field for Inherited model <see cref= "Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Models.Api20200214.IImageTemplateSource"
        /// />
        /// </summary>
        private Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Models.Api20200214.IImageTemplateSource __imageTemplateSource = new Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Models.Api20200214.ImageTemplateSource();

        /// <summary>Backing field for <see cref="ImageId" /> property.</summary>
        private string _imageId;

        /// <summary>ARM resource id of the managed image in customer subscription</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Origin(Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.PropertyOrigin.Owned)]
        public string ImageId { get => this._imageId; set => this._imageId = value; }

        /// <summary>Specifies the type of source image you want to start with.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Origin(Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.PropertyOrigin.Inherited)]
        public string Type { get => ((Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Models.Api20200214.IImageTemplateSourceInternal)__imageTemplateSource).Type; set => ((Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Models.Api20200214.IImageTemplateSourceInternal)__imageTemplateSource).Type = value; }

        /// <summary>Creates an new <see cref="ImageTemplateManagedImageSource" /> instance.</summary>
        public ImageTemplateManagedImageSource()
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
    /// Describes an image source that is a managed image in customer subscription.
    public partial interface IImageTemplateManagedImageSource :
        Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Models.Api20200214.IImageTemplateSource
    {
        /// <summary>ARM resource id of the managed image in customer subscription</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"ARM resource id of the managed image in customer subscription",
        SerializedName = @"imageId",
        PossibleTypes = new [] { typeof(string) })]
        string ImageId { get; set; }

    }
    /// Describes an image source that is a managed image in customer subscription.
    public partial interface IImageTemplateManagedImageSourceInternal :
        Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Models.Api20200214.IImageTemplateSourceInternal
    {
        /// <summary>ARM resource id of the managed image in customer subscription</summary>
        string ImageId { get; set; }

    }
}