namespace Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview
{
    using static Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Runtime.Extensions;

    /// <summary>This is the disk image base class.</summary>
    public partial class GalleryDiskImage :
        Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IGalleryDiskImage,
        Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IGalleryDiskImageInternal
    {

        /// <summary>Internal Acessors for SizeInMb</summary>
        long? Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IGalleryDiskImageInternal.SizeInMb { get => this._sizeInMb; set { {_sizeInMb = value;} } }

        /// <summary>Backing field for <see cref="SizeInMb" /> property.</summary>
        private long? _sizeInMb;

        /// <summary>This property indicates the size of the VHD to be created.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Origin(Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.PropertyOrigin.Owned)]
        public long? SizeInMb { get => this._sizeInMb; }

        /// <summary>Creates an new <see cref="GalleryDiskImage" /> instance.</summary>
        public GalleryDiskImage()
        {

        }
    }
    /// This is the disk image base class.
    public partial interface IGalleryDiskImage :
        Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Runtime.IJsonSerializable
    {
        /// <summary>This property indicates the size of the VHD to be created.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"This property indicates the size of the VHD to be created.",
        SerializedName = @"sizeInMB",
        PossibleTypes = new [] { typeof(long) })]
        long? SizeInMb { get;  }

    }
    /// This is the disk image base class.
    internal partial interface IGalleryDiskImageInternal

    {
        /// <summary>This property indicates the size of the VHD to be created.</summary>
        long? SizeInMb { get; set; }

    }
}