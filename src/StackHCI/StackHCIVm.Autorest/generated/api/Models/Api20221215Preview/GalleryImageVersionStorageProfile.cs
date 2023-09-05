namespace Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview
{
    using static Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Runtime.Extensions;

    /// <summary>This is the storage profile of a Gallery Image Version.</summary>
    public partial class GalleryImageVersionStorageProfile :
        Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IGalleryImageVersionStorageProfile,
        Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IGalleryImageVersionStorageProfileInternal
    {

        /// <summary>Internal Acessors for OSDiskImage</summary>
        Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IGalleryDiskImage Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IGalleryImageVersionStorageProfileInternal.OSDiskImage { get => (this._oSDiskImage = this._oSDiskImage ?? new Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.GalleryDiskImage()); set { {_oSDiskImage = value;} } }

        /// <summary>Internal Acessors for OSDiskImageSizeInMb</summary>
        long? Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IGalleryImageVersionStorageProfileInternal.OSDiskImageSizeInMb { get => ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IGalleryDiskImageInternal)OSDiskImage).SizeInMb; set => ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IGalleryDiskImageInternal)OSDiskImage).SizeInMb = value; }

        /// <summary>Backing field for <see cref="OSDiskImage" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IGalleryDiskImage _oSDiskImage;

        /// <summary>This is the disk image base class.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Origin(Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IGalleryDiskImage OSDiskImage { get => (this._oSDiskImage = this._oSDiskImage ?? new Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.GalleryDiskImage()); set => this._oSDiskImage = value; }

        /// <summary>This property indicates the size of the VHD to be created.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Origin(Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.PropertyOrigin.Inlined)]
        public long? OSDiskImageSizeInMb { get => ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IGalleryDiskImageInternal)OSDiskImage).SizeInMb; }

        /// <summary>Creates an new <see cref="GalleryImageVersionStorageProfile" /> instance.</summary>
        public GalleryImageVersionStorageProfile()
        {

        }
    }
    /// This is the storage profile of a Gallery Image Version.
    public partial interface IGalleryImageVersionStorageProfile :
        Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Runtime.IJsonSerializable
    {
        /// <summary>This property indicates the size of the VHD to be created.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"This property indicates the size of the VHD to be created.",
        SerializedName = @"sizeInMB",
        PossibleTypes = new [] { typeof(long) })]
        long? OSDiskImageSizeInMb { get;  }

    }
    /// This is the storage profile of a Gallery Image Version.
    internal partial interface IGalleryImageVersionStorageProfileInternal

    {
        /// <summary>This is the disk image base class.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IGalleryDiskImage OSDiskImage { get; set; }
        /// <summary>This property indicates the size of the VHD to be created.</summary>
        long? OSDiskImageSizeInMb { get; set; }

    }
}