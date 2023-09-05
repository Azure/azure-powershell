namespace Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview
{
    using static Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Runtime.Extensions;

    /// <summary>
    /// Specifies information about the gallery image version that you want to create or update.
    /// </summary>
    public partial class GalleryImageVersion :
        Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IGalleryImageVersion,
        Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IGalleryImageVersionInternal
    {

        /// <summary>Internal Acessors for OSDiskImageSizeInMb</summary>
        long? Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IGalleryImageVersionInternal.OSDiskImageSizeInMb { get => ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IGalleryImageVersionPropertiesInternal)Property).OSDiskImageSizeInMb; set => ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IGalleryImageVersionPropertiesInternal)Property).OSDiskImageSizeInMb = value; }

        /// <summary>Internal Acessors for Property</summary>
        Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IGalleryImageVersionProperties Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IGalleryImageVersionInternal.Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.GalleryImageVersionProperties()); set { {_property = value;} } }

        /// <summary>Internal Acessors for StorageProfile</summary>
        Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IGalleryImageVersionStorageProfile Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IGalleryImageVersionInternal.StorageProfile { get => ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IGalleryImageVersionPropertiesInternal)Property).StorageProfile; set => ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IGalleryImageVersionPropertiesInternal)Property).StorageProfile = value; }

        /// <summary>Internal Acessors for StorageProfileOSDiskImage</summary>
        Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IGalleryDiskImage Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IGalleryImageVersionInternal.StorageProfileOSDiskImage { get => ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IGalleryImageVersionPropertiesInternal)Property).StorageProfileOSDiskImage; set => ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IGalleryImageVersionPropertiesInternal)Property).StorageProfileOSDiskImage = value; }

        /// <summary>Backing field for <see cref="Name" /> property.</summary>
        private string _name;

        /// <summary>This is the version of the gallery image.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Origin(Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.PropertyOrigin.Owned)]
        public string Name { get => this._name; set => this._name = value; }

        /// <summary>This property indicates the size of the VHD to be created.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Origin(Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.PropertyOrigin.Inlined)]
        public long? OSDiskImageSizeInMb { get => ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IGalleryImageVersionPropertiesInternal)Property).OSDiskImageSizeInMb; }

        /// <summary>Backing field for <see cref="Property" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IGalleryImageVersionProperties _property;

        /// <summary>Describes the properties of a gallery image version.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Origin(Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IGalleryImageVersionProperties Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.GalleryImageVersionProperties()); set => this._property = value; }

        /// <summary>Creates an new <see cref="GalleryImageVersion" /> instance.</summary>
        public GalleryImageVersion()
        {

        }
    }
    /// Specifies information about the gallery image version that you want to create or update.
    public partial interface IGalleryImageVersion :
        Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Runtime.IJsonSerializable
    {
        /// <summary>This is the version of the gallery image.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"This is the version of the gallery image.",
        SerializedName = @"name",
        PossibleTypes = new [] { typeof(string) })]
        string Name { get; set; }
        /// <summary>This property indicates the size of the VHD to be created.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"This property indicates the size of the VHD to be created.",
        SerializedName = @"sizeInMB",
        PossibleTypes = new [] { typeof(long) })]
        long? OSDiskImageSizeInMb { get;  }

    }
    /// Specifies information about the gallery image version that you want to create or update.
    internal partial interface IGalleryImageVersionInternal

    {
        /// <summary>This is the version of the gallery image.</summary>
        string Name { get; set; }
        /// <summary>This property indicates the size of the VHD to be created.</summary>
        long? OSDiskImageSizeInMb { get; set; }
        /// <summary>Describes the properties of a gallery image version.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IGalleryImageVersionProperties Property { get; set; }
        /// <summary>This is the storage profile of a Gallery Image Version.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IGalleryImageVersionStorageProfile StorageProfile { get; set; }
        /// <summary>This is the disk image base class.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IGalleryDiskImage StorageProfileOSDiskImage { get; set; }

    }
}