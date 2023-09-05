namespace Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview
{
    using static Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Runtime.Extensions;

    /// <summary>This is the OS disk image.</summary>
    public partial class GalleryOSDiskImage :
        Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IGalleryOSDiskImage,
        Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IGalleryOSDiskImageInternal,
        Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Runtime.IValidates
    {
        /// <summary>
        /// Backing field for Inherited model <see cref= "Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IGalleryDiskImage"
        /// />
        /// </summary>
        private Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IGalleryDiskImage __galleryDiskImage = new Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.GalleryDiskImage();

        /// <summary>Internal Acessors for SizeInMb</summary>
        long? Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IGalleryDiskImageInternal.SizeInMb { get => ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IGalleryDiskImageInternal)__galleryDiskImage).SizeInMb; set => ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IGalleryDiskImageInternal)__galleryDiskImage).SizeInMb = value; }

        /// <summary>This property indicates the size of the VHD to be created.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Origin(Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.PropertyOrigin.Inherited)]
        public long? SizeInMb { get => ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IGalleryDiskImageInternal)__galleryDiskImage).SizeInMb; }

        /// <summary>Creates an new <see cref="GalleryOSDiskImage" /> instance.</summary>
        public GalleryOSDiskImage()
        {

        }

        /// <summary>Validates that this object meets the validation criteria.</summary>
        /// <param name="eventListener">an <see cref="Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Runtime.IEventListener" /> instance that will receive validation
        /// events.</param>
        /// <returns>
        /// A < see cref = "global::System.Threading.Tasks.Task" /> that will be complete when validation is completed.
        /// </returns>
        public async global::System.Threading.Tasks.Task Validate(Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Runtime.IEventListener eventListener)
        {
            await eventListener.AssertNotNull(nameof(__galleryDiskImage), __galleryDiskImage);
            await eventListener.AssertObjectIsValid(nameof(__galleryDiskImage), __galleryDiskImage);
        }
    }
    /// This is the OS disk image.
    public partial interface IGalleryOSDiskImage :
        Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IGalleryDiskImage
    {

    }
    /// This is the OS disk image.
    internal partial interface IGalleryOSDiskImageInternal :
        Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IGalleryDiskImageInternal
    {

    }
}