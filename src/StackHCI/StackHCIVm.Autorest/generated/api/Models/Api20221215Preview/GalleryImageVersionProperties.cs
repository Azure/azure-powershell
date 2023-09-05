namespace Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview
{
    using static Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Runtime.Extensions;

    /// <summary>Describes the properties of a gallery image version.</summary>
    public partial class GalleryImageVersionProperties :
        Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IGalleryImageVersionProperties,
        Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IGalleryImageVersionPropertiesInternal
    {

        /// <summary>Internal Acessors for OSDiskImageSizeInMb</summary>
        long? Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IGalleryImageVersionPropertiesInternal.OSDiskImageSizeInMb { get => ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IGalleryImageVersionStorageProfileInternal)StorageProfile).OSDiskImageSizeInMb; set => ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IGalleryImageVersionStorageProfileInternal)StorageProfile).OSDiskImageSizeInMb = value; }

        /// <summary>Internal Acessors for StorageProfile</summary>
        Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IGalleryImageVersionStorageProfile Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IGalleryImageVersionPropertiesInternal.StorageProfile { get => (this._storageProfile = this._storageProfile ?? new Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.GalleryImageVersionStorageProfile()); set { {_storageProfile = value;} } }

        /// <summary>Internal Acessors for StorageProfileOSDiskImage</summary>
        Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IGalleryDiskImage Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IGalleryImageVersionPropertiesInternal.StorageProfileOSDiskImage { get => ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IGalleryImageVersionStorageProfileInternal)StorageProfile).OSDiskImage; set => ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IGalleryImageVersionStorageProfileInternal)StorageProfile).OSDiskImage = value; }

        /// <summary>This property indicates the size of the VHD to be created.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Origin(Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.PropertyOrigin.Inlined)]
        public long? OSDiskImageSizeInMb { get => ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IGalleryImageVersionStorageProfileInternal)StorageProfile).OSDiskImageSizeInMb; }

        /// <summary>Backing field for <see cref="StorageProfile" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IGalleryImageVersionStorageProfile _storageProfile;

        /// <summary>This is the storage profile of a Gallery Image Version.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Origin(Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IGalleryImageVersionStorageProfile StorageProfile { get => (this._storageProfile = this._storageProfile ?? new Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.GalleryImageVersionStorageProfile()); set => this._storageProfile = value; }

        /// <summary>Creates an new <see cref="GalleryImageVersionProperties" /> instance.</summary>
        public GalleryImageVersionProperties()
        {

        }
    }
    /// Describes the properties of a gallery image version.
    public partial interface IGalleryImageVersionProperties :
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
    /// Describes the properties of a gallery image version.
    internal partial interface IGalleryImageVersionPropertiesInternal

    {
        /// <summary>This property indicates the size of the VHD to be created.</summary>
        long? OSDiskImageSizeInMb { get; set; }
        /// <summary>This is the storage profile of a Gallery Image Version.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IGalleryImageVersionStorageProfile StorageProfile { get; set; }
        /// <summary>This is the disk image base class.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IGalleryDiskImage StorageProfileOSDiskImage { get; set; }

    }
}