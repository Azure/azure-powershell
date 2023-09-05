namespace Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview
{
    using static Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Runtime.Extensions;

    /// <summary>The observed state of gallery images</summary>
    public partial class GalleryImageStatus :
        Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IGalleryImageStatus,
        Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IGalleryImageStatusInternal
    {

        /// <summary>Backing field for <see cref="DownloadStatus" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IGalleryImageStatusDownloadStatus _downloadStatus;

        /// <summary>The download status of the gallery image</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Origin(Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IGalleryImageStatusDownloadStatus DownloadStatus { get => (this._downloadStatus = this._downloadStatus ?? new Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.GalleryImageStatusDownloadStatus()); set => this._downloadStatus = value; }

        /// <summary>The downloaded sized of the image in MB</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Origin(Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.PropertyOrigin.Inlined)]
        public long? DownloadStatusDownloadSizeInMb { get => ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IGalleryImageStatusDownloadStatusInternal)DownloadStatus).DownloadSizeInMb; set => ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IGalleryImageStatusDownloadStatusInternal)DownloadStatus).DownloadSizeInMb = value ?? default(long); }

        /// <summary>Backing field for <see cref="ErrorCode" /> property.</summary>
        private string _errorCode;

        /// <summary>GalleryImage provisioning error code</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Origin(Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.PropertyOrigin.Owned)]
        public string ErrorCode { get => this._errorCode; set => this._errorCode = value; }

        /// <summary>Backing field for <see cref="ErrorMessage" /> property.</summary>
        private string _errorMessage;

        /// <summary>Descriptive error message</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Origin(Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.PropertyOrigin.Owned)]
        public string ErrorMessage { get => this._errorMessage; set => this._errorMessage = value; }

        /// <summary>Internal Acessors for DownloadStatus</summary>
        Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IGalleryImageStatusDownloadStatus Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IGalleryImageStatusInternal.DownloadStatus { get => (this._downloadStatus = this._downloadStatus ?? new Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.GalleryImageStatusDownloadStatus()); set { {_downloadStatus = value;} } }

        /// <summary>Internal Acessors for ProvisioningStatus</summary>
        Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IGalleryImageStatusProvisioningStatus Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IGalleryImageStatusInternal.ProvisioningStatus { get => (this._provisioningStatus = this._provisioningStatus ?? new Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.GalleryImageStatusProvisioningStatus()); set { {_provisioningStatus = value;} } }

        /// <summary>Backing field for <see cref="ProgressPercentage" /> property.</summary>
        private long? _progressPercentage;

        /// <summary>The progress of the operation in percentage</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Origin(Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.PropertyOrigin.Owned)]
        public long? ProgressPercentage { get => this._progressPercentage; set => this._progressPercentage = value; }

        /// <summary>Backing field for <see cref="ProvisioningStatus" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IGalleryImageStatusProvisioningStatus _provisioningStatus;

        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Origin(Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IGalleryImageStatusProvisioningStatus ProvisioningStatus { get => (this._provisioningStatus = this._provisioningStatus ?? new Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.GalleryImageStatusProvisioningStatus()); set => this._provisioningStatus = value; }

        /// <summary>The ID of the operation performed on the gallery image</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Origin(Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.PropertyOrigin.Inlined)]
        public string ProvisioningStatusOperationId { get => ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IGalleryImageStatusProvisioningStatusInternal)ProvisioningStatus).OperationId; set => ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IGalleryImageStatusProvisioningStatusInternal)ProvisioningStatus).OperationId = value ?? null; }

        /// <summary>
        /// The status of the operation performed on the gallery image [Succeeded, Failed, InProgress]
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Origin(Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Support.Status? ProvisioningStatusStatus { get => ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IGalleryImageStatusProvisioningStatusInternal)ProvisioningStatus).Status; set => ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IGalleryImageStatusProvisioningStatusInternal)ProvisioningStatus).Status = value ?? ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Support.Status)""); }

        /// <summary>Creates an new <see cref="GalleryImageStatus" /> instance.</summary>
        public GalleryImageStatus()
        {

        }
    }
    /// The observed state of gallery images
    public partial interface IGalleryImageStatus :
        Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Runtime.IJsonSerializable
    {
        /// <summary>The downloaded sized of the image in MB</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The downloaded sized of the image in MB",
        SerializedName = @"downloadSizeInMB",
        PossibleTypes = new [] { typeof(long) })]
        long? DownloadStatusDownloadSizeInMb { get; set; }
        /// <summary>GalleryImage provisioning error code</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"GalleryImage provisioning error code",
        SerializedName = @"errorCode",
        PossibleTypes = new [] { typeof(string) })]
        string ErrorCode { get; set; }
        /// <summary>Descriptive error message</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Descriptive error message",
        SerializedName = @"errorMessage",
        PossibleTypes = new [] { typeof(string) })]
        string ErrorMessage { get; set; }
        /// <summary>The progress of the operation in percentage</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The progress of the operation in percentage",
        SerializedName = @"progressPercentage",
        PossibleTypes = new [] { typeof(long) })]
        long? ProgressPercentage { get; set; }
        /// <summary>The ID of the operation performed on the gallery image</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The ID of the operation performed on the gallery image",
        SerializedName = @"operationId",
        PossibleTypes = new [] { typeof(string) })]
        string ProvisioningStatusOperationId { get; set; }
        /// <summary>
        /// The status of the operation performed on the gallery image [Succeeded, Failed, InProgress]
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The status of the operation performed on the gallery image [Succeeded, Failed, InProgress]",
        SerializedName = @"status",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Support.Status) })]
        Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Support.Status? ProvisioningStatusStatus { get; set; }

    }
    /// The observed state of gallery images
    internal partial interface IGalleryImageStatusInternal

    {
        /// <summary>The download status of the gallery image</summary>
        Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IGalleryImageStatusDownloadStatus DownloadStatus { get; set; }
        /// <summary>The downloaded sized of the image in MB</summary>
        long? DownloadStatusDownloadSizeInMb { get; set; }
        /// <summary>GalleryImage provisioning error code</summary>
        string ErrorCode { get; set; }
        /// <summary>Descriptive error message</summary>
        string ErrorMessage { get; set; }
        /// <summary>The progress of the operation in percentage</summary>
        long? ProgressPercentage { get; set; }

        Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IGalleryImageStatusProvisioningStatus ProvisioningStatus { get; set; }
        /// <summary>The ID of the operation performed on the gallery image</summary>
        string ProvisioningStatusOperationId { get; set; }
        /// <summary>
        /// The status of the operation performed on the gallery image [Succeeded, Failed, InProgress]
        /// </summary>
        Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Support.Status? ProvisioningStatusStatus { get; set; }

    }
}