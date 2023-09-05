namespace Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview
{
    using static Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Runtime.Extensions;

    /// <summary>The download status of the gallery image</summary>
    public partial class GalleryImageStatusDownloadStatus :
        Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IGalleryImageStatusDownloadStatus,
        Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IGalleryImageStatusDownloadStatusInternal
    {

        /// <summary>Backing field for <see cref="DownloadSizeInMb" /> property.</summary>
        private long? _downloadSizeInMb;

        /// <summary>The downloaded sized of the image in MB</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Origin(Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.PropertyOrigin.Owned)]
        public long? DownloadSizeInMb { get => this._downloadSizeInMb; set => this._downloadSizeInMb = value; }

        /// <summary>Creates an new <see cref="GalleryImageStatusDownloadStatus" /> instance.</summary>
        public GalleryImageStatusDownloadStatus()
        {

        }
    }
    /// The download status of the gallery image
    public partial interface IGalleryImageStatusDownloadStatus :
        Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Runtime.IJsonSerializable
    {
        /// <summary>The downloaded sized of the image in MB</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The downloaded sized of the image in MB",
        SerializedName = @"downloadSizeInMB",
        PossibleTypes = new [] { typeof(long) })]
        long? DownloadSizeInMb { get; set; }

    }
    /// The download status of the gallery image
    internal partial interface IGalleryImageStatusDownloadStatusInternal

    {
        /// <summary>The downloaded sized of the image in MB</summary>
        long? DownloadSizeInMb { get; set; }

    }
}