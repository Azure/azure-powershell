namespace Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301
{
    using static Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.Extensions;

    /// <summary>The cached image and OS type.</summary>
    public partial class CachedImages :
        Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.ICachedImages,
        Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.ICachedImagesInternal
    {

        /// <summary>Backing field for <see cref="Image" /> property.</summary>
        private string _image;

        /// <summary>The cached image name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Origin(Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.PropertyOrigin.Owned)]
        public string Image { get => this._image; set => this._image = value; }

        /// <summary>Backing field for <see cref="OSType" /> property.</summary>
        private string _oSType;

        /// <summary>The OS type of the cached image.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Origin(Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.PropertyOrigin.Owned)]
        public string OSType { get => this._oSType; set => this._oSType = value; }

        /// <summary>Creates an new <see cref="CachedImages" /> instance.</summary>
        public CachedImages()
        {

        }
    }
    /// The cached image and OS type.
    public partial interface ICachedImages :
        Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.IJsonSerializable
    {
        /// <summary>The cached image name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"The cached image name.",
        SerializedName = @"image",
        PossibleTypes = new [] { typeof(string) })]
        string Image { get; set; }
        /// <summary>The OS type of the cached image.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"The OS type of the cached image.",
        SerializedName = @"osType",
        PossibleTypes = new [] { typeof(string) })]
        string OSType { get; set; }

    }
    /// The cached image and OS type.
    internal partial interface ICachedImagesInternal

    {
        /// <summary>The cached image name.</summary>
        string Image { get; set; }
        /// <summary>The OS type of the cached image.</summary>
        string OSType { get; set; }

    }
}