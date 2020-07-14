namespace Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101
{
    using static Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Runtime.Extensions;

    /// <summary>Provides information about the drive's status</summary>
    public partial class DriveStatus :
        Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IDriveStatus,
        Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IDriveStatusInternal
    {

        /// <summary>Backing field for <see cref="BitLockerKey" /> property.</summary>
        private string _bitLockerKey;

        /// <summary>The BitLocker key used to encrypt the drive.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Origin(Microsoft.Azure.PowerShell.Cmdlets.ImportExport.PropertyOrigin.Owned)]
        public string BitLockerKey { get => this._bitLockerKey; set => this._bitLockerKey = value; }

        /// <summary>Backing field for <see cref="BytesSucceeded" /> property.</summary>
        private long? _bytesSucceeded;

        /// <summary>Bytes successfully transferred for the drive.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Origin(Microsoft.Azure.PowerShell.Cmdlets.ImportExport.PropertyOrigin.Owned)]
        public long? BytesSucceeded { get => this._bytesSucceeded; set => this._bytesSucceeded = value; }

        /// <summary>Backing field for <see cref="CopyStatus" /> property.</summary>
        private string _copyStatus;

        /// <summary>
        /// Detailed status about the data transfer process. This field is not returned in the response until the drive is in the
        /// Transferring state.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Origin(Microsoft.Azure.PowerShell.Cmdlets.ImportExport.PropertyOrigin.Owned)]
        public string CopyStatus { get => this._copyStatus; set => this._copyStatus = value; }

        /// <summary>Backing field for <see cref="DriveHeaderHash" /> property.</summary>
        private string _driveHeaderHash;

        /// <summary>The drive header hash value.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Origin(Microsoft.Azure.PowerShell.Cmdlets.ImportExport.PropertyOrigin.Owned)]
        public string DriveHeaderHash { get => this._driveHeaderHash; set => this._driveHeaderHash = value; }

        /// <summary>Backing field for <see cref="DriveId" /> property.</summary>
        private string _driveId;

        /// <summary>The drive's hardware serial number, without spaces.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Origin(Microsoft.Azure.PowerShell.Cmdlets.ImportExport.PropertyOrigin.Owned)]
        public string DriveId { get => this._driveId; set => this._driveId = value; }

        /// <summary>Backing field for <see cref="ErrorLogUri" /> property.</summary>
        private string _errorLogUri;

        /// <summary>
        /// A URI that points to the blob containing the error log for the data transfer operation.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Origin(Microsoft.Azure.PowerShell.Cmdlets.ImportExport.PropertyOrigin.Owned)]
        public string ErrorLogUri { get => this._errorLogUri; set => this._errorLogUri = value; }

        /// <summary>Backing field for <see cref="ManifestFile" /> property.</summary>
        private string _manifestFile;

        /// <summary>The relative path of the manifest file on the drive.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Origin(Microsoft.Azure.PowerShell.Cmdlets.ImportExport.PropertyOrigin.Owned)]
        public string ManifestFile { get => this._manifestFile; set => this._manifestFile = value; }

        /// <summary>Backing field for <see cref="ManifestHash" /> property.</summary>
        private string _manifestHash;

        /// <summary>The Base16-encoded MD5 hash of the manifest file on the drive.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Origin(Microsoft.Azure.PowerShell.Cmdlets.ImportExport.PropertyOrigin.Owned)]
        public string ManifestHash { get => this._manifestHash; set => this._manifestHash = value; }

        /// <summary>Backing field for <see cref="ManifestUri" /> property.</summary>
        private string _manifestUri;

        /// <summary>A URI that points to the blob containing the drive manifest file.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Origin(Microsoft.Azure.PowerShell.Cmdlets.ImportExport.PropertyOrigin.Owned)]
        public string ManifestUri { get => this._manifestUri; set => this._manifestUri = value; }

        /// <summary>Backing field for <see cref="PercentComplete" /> property.</summary>
        private int? _percentComplete;

        /// <summary>Percentage completed for the drive.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Origin(Microsoft.Azure.PowerShell.Cmdlets.ImportExport.PropertyOrigin.Owned)]
        public int? PercentComplete { get => this._percentComplete; set => this._percentComplete = value; }

        /// <summary>Backing field for <see cref="State" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Support.DriveState? _state;

        /// <summary>The drive's current state.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Origin(Microsoft.Azure.PowerShell.Cmdlets.ImportExport.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Support.DriveState? State { get => this._state; set => this._state = value; }

        /// <summary>Backing field for <see cref="VerboseLogUri" /> property.</summary>
        private string _verboseLogUri;

        /// <summary>
        /// A URI that points to the blob containing the verbose log for the data transfer operation.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Origin(Microsoft.Azure.PowerShell.Cmdlets.ImportExport.PropertyOrigin.Owned)]
        public string VerboseLogUri { get => this._verboseLogUri; set => this._verboseLogUri = value; }

        /// <summary>Creates an new <see cref="DriveStatus" /> instance.</summary>
        public DriveStatus()
        {

        }
    }
    /// Provides information about the drive's status
    public partial interface IDriveStatus :
        Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Runtime.IJsonSerializable
    {
        /// <summary>The BitLocker key used to encrypt the drive.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The BitLocker key used to encrypt the drive.",
        SerializedName = @"bitLockerKey",
        PossibleTypes = new [] { typeof(string) })]
        string BitLockerKey { get; set; }
        /// <summary>Bytes successfully transferred for the drive.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Bytes successfully transferred for the drive.",
        SerializedName = @"bytesSucceeded",
        PossibleTypes = new [] { typeof(long) })]
        long? BytesSucceeded { get; set; }
        /// <summary>
        /// Detailed status about the data transfer process. This field is not returned in the response until the drive is in the
        /// Transferring state.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Detailed status about the data transfer process. This field is not returned in the response until the drive is in the Transferring state.",
        SerializedName = @"copyStatus",
        PossibleTypes = new [] { typeof(string) })]
        string CopyStatus { get; set; }
        /// <summary>The drive header hash value.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The drive header hash value.",
        SerializedName = @"driveHeaderHash",
        PossibleTypes = new [] { typeof(string) })]
        string DriveHeaderHash { get; set; }
        /// <summary>The drive's hardware serial number, without spaces.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The drive's hardware serial number, without spaces.",
        SerializedName = @"driveId",
        PossibleTypes = new [] { typeof(string) })]
        string DriveId { get; set; }
        /// <summary>
        /// A URI that points to the blob containing the error log for the data transfer operation.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"A URI that points to the blob containing the error log for the data transfer operation.",
        SerializedName = @"errorLogUri",
        PossibleTypes = new [] { typeof(string) })]
        string ErrorLogUri { get; set; }
        /// <summary>The relative path of the manifest file on the drive.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The relative path of the manifest file on the drive. ",
        SerializedName = @"manifestFile",
        PossibleTypes = new [] { typeof(string) })]
        string ManifestFile { get; set; }
        /// <summary>The Base16-encoded MD5 hash of the manifest file on the drive.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The Base16-encoded MD5 hash of the manifest file on the drive.",
        SerializedName = @"manifestHash",
        PossibleTypes = new [] { typeof(string) })]
        string ManifestHash { get; set; }
        /// <summary>A URI that points to the blob containing the drive manifest file.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"A URI that points to the blob containing the drive manifest file. ",
        SerializedName = @"manifestUri",
        PossibleTypes = new [] { typeof(string) })]
        string ManifestUri { get; set; }
        /// <summary>Percentage completed for the drive.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Percentage completed for the drive. ",
        SerializedName = @"percentComplete",
        PossibleTypes = new [] { typeof(int) })]
        int? PercentComplete { get; set; }
        /// <summary>The drive's current state.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The drive's current state. ",
        SerializedName = @"state",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Support.DriveState) })]
        Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Support.DriveState? State { get; set; }
        /// <summary>
        /// A URI that points to the blob containing the verbose log for the data transfer operation.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"A URI that points to the blob containing the verbose log for the data transfer operation. ",
        SerializedName = @"verboseLogUri",
        PossibleTypes = new [] { typeof(string) })]
        string VerboseLogUri { get; set; }

    }
    /// Provides information about the drive's status
    internal partial interface IDriveStatusInternal

    {
        /// <summary>The BitLocker key used to encrypt the drive.</summary>
        string BitLockerKey { get; set; }
        /// <summary>Bytes successfully transferred for the drive.</summary>
        long? BytesSucceeded { get; set; }
        /// <summary>
        /// Detailed status about the data transfer process. This field is not returned in the response until the drive is in the
        /// Transferring state.
        /// </summary>
        string CopyStatus { get; set; }
        /// <summary>The drive header hash value.</summary>
        string DriveHeaderHash { get; set; }
        /// <summary>The drive's hardware serial number, without spaces.</summary>
        string DriveId { get; set; }
        /// <summary>
        /// A URI that points to the blob containing the error log for the data transfer operation.
        /// </summary>
        string ErrorLogUri { get; set; }
        /// <summary>The relative path of the manifest file on the drive.</summary>
        string ManifestFile { get; set; }
        /// <summary>The Base16-encoded MD5 hash of the manifest file on the drive.</summary>
        string ManifestHash { get; set; }
        /// <summary>A URI that points to the blob containing the drive manifest file.</summary>
        string ManifestUri { get; set; }
        /// <summary>Percentage completed for the drive.</summary>
        int? PercentComplete { get; set; }
        /// <summary>The drive's current state.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Support.DriveState? State { get; set; }
        /// <summary>
        /// A URI that points to the blob containing the verbose log for the data transfer operation.
        /// </summary>
        string VerboseLogUri { get; set; }

    }
}