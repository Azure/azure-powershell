namespace Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview
{
    using static Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Runtime.Extensions;

    /// <summary>Properties under the gallery image resource</summary>
    public partial class GalleryImageProperties :
        Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IGalleryImageProperties,
        Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IGalleryImagePropertiesInternal
    {

        /// <summary>Backing field for <see cref="CloudInitDataSource" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Support.CloudInitDataSource? _cloudInitDataSource;

        /// <summary>
        /// Datasource for the gallery image when provisioning with cloud-init [NoCloud, Azure]
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Origin(Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Support.CloudInitDataSource? CloudInitDataSource { get => this._cloudInitDataSource; set => this._cloudInitDataSource = value; }

        /// <summary>Backing field for <see cref="ContainerName" /> property.</summary>
        private string _containerName;

        /// <summary>Container Name for storage container</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Origin(Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.PropertyOrigin.Owned)]
        public string ContainerName { get => this._containerName; set => this._containerName = value; }

        /// <summary>The downloaded sized of the image in MB</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Origin(Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.PropertyOrigin.Inlined)]
        public long? DownloadStatusDownloadSizeInMb { get => ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IGalleryImageStatusInternal)Status).DownloadStatusDownloadSizeInMb; set => ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IGalleryImageStatusInternal)Status).DownloadStatusDownloadSizeInMb = value ?? default(long); }

        /// <summary>Backing field for <see cref="HyperVGeneration" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Support.HyperVGeneration? _hyperVGeneration;

        /// <summary>The hypervisor generation of the Virtual Machine [V1, V2]</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Origin(Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Support.HyperVGeneration? HyperVGeneration { get => this._hyperVGeneration; set => this._hyperVGeneration = value; }

        /// <summary>Backing field for <see cref="Identifier" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IGalleryImageIdentifier _identifier;

        /// <summary>This is the gallery image definition identifier.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Origin(Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IGalleryImageIdentifier Identifier { get => (this._identifier = this._identifier ?? new Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.GalleryImageIdentifier()); set => this._identifier = value; }

        /// <summary>The name of the gallery image definition offer.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Origin(Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.PropertyOrigin.Inlined)]
        public string IdentifierOffer { get => ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IGalleryImageIdentifierInternal)Identifier).Offer; set => ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IGalleryImageIdentifierInternal)Identifier).Offer = value ?? null; }

        /// <summary>The name of the gallery image definition publisher.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Origin(Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.PropertyOrigin.Inlined)]
        public string IdentifierPublisher { get => ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IGalleryImageIdentifierInternal)Identifier).Publisher; set => ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IGalleryImageIdentifierInternal)Identifier).Publisher = value ?? null; }

        /// <summary>The name of the gallery image definition SKU.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Origin(Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.PropertyOrigin.Inlined)]
        public string IdentifierSku { get => ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IGalleryImageIdentifierInternal)Identifier).Sku; set => ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IGalleryImageIdentifierInternal)Identifier).Sku = value ?? null; }

        /// <summary>Backing field for <see cref="ImagePath" /> property.</summary>
        private string _imagePath;

        /// <summary>location of the image the gallery image should be created from</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Origin(Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.PropertyOrigin.Owned)]
        public string ImagePath { get => this._imagePath; set => this._imagePath = value; }

        /// <summary>Internal Acessors for Identifier</summary>
        Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IGalleryImageIdentifier Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IGalleryImagePropertiesInternal.Identifier { get => (this._identifier = this._identifier ?? new Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.GalleryImageIdentifier()); set { {_identifier = value;} } }

        /// <summary>Internal Acessors for OSDiskImageSizeInMb</summary>
        long? Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IGalleryImagePropertiesInternal.OSDiskImageSizeInMb { get => ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IGalleryImageVersionInternal)Version).OSDiskImageSizeInMb; set => ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IGalleryImageVersionInternal)Version).OSDiskImageSizeInMb = value; }

        /// <summary>Internal Acessors for ProvisioningState</summary>
        Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Support.ProvisioningStateEnum? Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IGalleryImagePropertiesInternal.ProvisioningState { get => this._provisioningState; set { {_provisioningState = value;} } }

        /// <summary>Internal Acessors for Status</summary>
        Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IGalleryImageStatus Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IGalleryImagePropertiesInternal.Status { get => (this._status = this._status ?? new Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.GalleryImageStatus()); set { {_status = value;} } }

        /// <summary>Internal Acessors for StatusDownloadStatus</summary>
        Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IGalleryImageStatusDownloadStatus Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IGalleryImagePropertiesInternal.StatusDownloadStatus { get => ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IGalleryImageStatusInternal)Status).DownloadStatus; set => ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IGalleryImageStatusInternal)Status).DownloadStatus = value; }

        /// <summary>Internal Acessors for StatusProvisioningStatus</summary>
        Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IGalleryImageStatusProvisioningStatus Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IGalleryImagePropertiesInternal.StatusProvisioningStatus { get => ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IGalleryImageStatusInternal)Status).ProvisioningStatus; set => ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IGalleryImageStatusInternal)Status).ProvisioningStatus = value; }

        /// <summary>Internal Acessors for StorageProfile</summary>
        Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IGalleryImageVersionStorageProfile Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IGalleryImagePropertiesInternal.StorageProfile { get => ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IGalleryImageVersionInternal)Version).StorageProfile; set => ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IGalleryImageVersionInternal)Version).StorageProfile = value; }

        /// <summary>Internal Acessors for StorageProfileOSDiskImage</summary>
        Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IGalleryDiskImage Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IGalleryImagePropertiesInternal.StorageProfileOSDiskImage { get => ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IGalleryImageVersionInternal)Version).StorageProfileOSDiskImage; set => ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IGalleryImageVersionInternal)Version).StorageProfileOSDiskImage = value; }

        /// <summary>Internal Acessors for Version</summary>
        Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IGalleryImageVersion Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IGalleryImagePropertiesInternal.Version { get => (this._version = this._version ?? new Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.GalleryImageVersion()); set { {_version = value;} } }

        /// <summary>Internal Acessors for VersionProperty</summary>
        Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IGalleryImageVersionProperties Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IGalleryImagePropertiesInternal.VersionProperty { get => ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IGalleryImageVersionInternal)Version).Property; set => ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IGalleryImageVersionInternal)Version).Property = value; }

        /// <summary>This property indicates the size of the VHD to be created.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Origin(Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.PropertyOrigin.Inlined)]
        public long? OSDiskImageSizeInMb { get => ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IGalleryImageVersionInternal)Version).OSDiskImageSizeInMb; }

        /// <summary>Backing field for <see cref="OSType" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Support.OperatingSystemTypes? _oSType;

        /// <summary>Operating system type that the gallery image uses [Windows, Linux]</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Origin(Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Support.OperatingSystemTypes? OSType { get => this._oSType; set => this._oSType = value; }

        /// <summary>Backing field for <see cref="ProvisioningState" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Support.ProvisioningStateEnum? _provisioningState;

        /// <summary>Provisioning state of the gallery image.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Origin(Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Support.ProvisioningStateEnum? ProvisioningState { get => this._provisioningState; }

        /// <summary>
        /// The status of the operation performed on the gallery image [Succeeded, Failed, InProgress]
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Origin(Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Support.Status? ProvisioningStatus { get => ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IGalleryImageStatusInternal)Status).ProvisioningStatusStatus; set => ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IGalleryImageStatusInternal)Status).ProvisioningStatusStatus = value ?? ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Support.Status)""); }

        /// <summary>The ID of the operation performed on the gallery image</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Origin(Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.PropertyOrigin.Inlined)]
        public string ProvisioningStatusOperationId { get => ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IGalleryImageStatusInternal)Status).ProvisioningStatusOperationId; set => ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IGalleryImageStatusInternal)Status).ProvisioningStatusOperationId = value ?? null; }

        /// <summary>Backing field for <see cref="Status" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IGalleryImageStatus _status;

        /// <summary>The observed state of gallery images</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Origin(Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IGalleryImageStatus Status { get => (this._status = this._status ?? new Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.GalleryImageStatus()); }

        /// <summary>GalleryImage provisioning error code</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Origin(Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.PropertyOrigin.Inlined)]
        public string StatusErrorCode { get => ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IGalleryImageStatusInternal)Status).ErrorCode; set => ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IGalleryImageStatusInternal)Status).ErrorCode = value ?? null; }

        /// <summary>Descriptive error message</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Origin(Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.PropertyOrigin.Inlined)]
        public string StatusErrorMessage { get => ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IGalleryImageStatusInternal)Status).ErrorMessage; set => ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IGalleryImageStatusInternal)Status).ErrorMessage = value ?? null; }

        /// <summary>The progress of the operation in percentage</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Origin(Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.PropertyOrigin.Inlined)]
        public long? StatusProgressPercentage { get => ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IGalleryImageStatusInternal)Status).ProgressPercentage; set => ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IGalleryImageStatusInternal)Status).ProgressPercentage = value ?? default(long); }

        /// <summary>Backing field for <see cref="Version" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IGalleryImageVersion _version;

        /// <summary>
        /// Specifies information about the gallery image version that you want to create or update.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Origin(Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IGalleryImageVersion Version { get => (this._version = this._version ?? new Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.GalleryImageVersion()); set => this._version = value; }

        /// <summary>This is the version of the gallery image.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Origin(Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.PropertyOrigin.Inlined)]
        public string VersionName { get => ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IGalleryImageVersionInternal)Version).Name; set => ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IGalleryImageVersionInternal)Version).Name = value ?? null; }

        /// <summary>Creates an new <see cref="GalleryImageProperties" /> instance.</summary>
        public GalleryImageProperties()
        {

        }
    }
    /// Properties under the gallery image resource
    public partial interface IGalleryImageProperties :
        Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Runtime.IJsonSerializable
    {
        /// <summary>
        /// Datasource for the gallery image when provisioning with cloud-init [NoCloud, Azure]
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Datasource for the gallery image when provisioning with cloud-init [NoCloud, Azure]",
        SerializedName = @"cloudInitDataSource",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Support.CloudInitDataSource) })]
        Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Support.CloudInitDataSource? CloudInitDataSource { get; set; }
        /// <summary>Container Name for storage container</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Container Name for storage container",
        SerializedName = @"containerName",
        PossibleTypes = new [] { typeof(string) })]
        string ContainerName { get; set; }
        /// <summary>The downloaded sized of the image in MB</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The downloaded sized of the image in MB",
        SerializedName = @"downloadSizeInMB",
        PossibleTypes = new [] { typeof(long) })]
        long? DownloadStatusDownloadSizeInMb { get; set; }
        /// <summary>The hypervisor generation of the Virtual Machine [V1, V2]</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The hypervisor generation of the Virtual Machine [V1, V2]",
        SerializedName = @"hyperVGeneration",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Support.HyperVGeneration) })]
        Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Support.HyperVGeneration? HyperVGeneration { get; set; }
        /// <summary>The name of the gallery image definition offer.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The name of the gallery image definition offer.",
        SerializedName = @"offer",
        PossibleTypes = new [] { typeof(string) })]
        string IdentifierOffer { get; set; }
        /// <summary>The name of the gallery image definition publisher.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The name of the gallery image definition publisher.",
        SerializedName = @"publisher",
        PossibleTypes = new [] { typeof(string) })]
        string IdentifierPublisher { get; set; }
        /// <summary>The name of the gallery image definition SKU.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The name of the gallery image definition SKU.",
        SerializedName = @"sku",
        PossibleTypes = new [] { typeof(string) })]
        string IdentifierSku { get; set; }
        /// <summary>location of the image the gallery image should be created from</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"location of the image the gallery image should be created from",
        SerializedName = @"imagePath",
        PossibleTypes = new [] { typeof(string) })]
        string ImagePath { get; set; }
        /// <summary>This property indicates the size of the VHD to be created.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"This property indicates the size of the VHD to be created.",
        SerializedName = @"sizeInMB",
        PossibleTypes = new [] { typeof(long) })]
        long? OSDiskImageSizeInMb { get;  }
        /// <summary>Operating system type that the gallery image uses [Windows, Linux]</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Operating system type that the gallery image uses [Windows, Linux]",
        SerializedName = @"osType",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Support.OperatingSystemTypes) })]
        Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Support.OperatingSystemTypes? OSType { get; set; }
        /// <summary>Provisioning state of the gallery image.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Provisioning state of the gallery image.",
        SerializedName = @"provisioningState",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Support.ProvisioningStateEnum) })]
        Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Support.ProvisioningStateEnum? ProvisioningState { get;  }
        /// <summary>
        /// The status of the operation performed on the gallery image [Succeeded, Failed, InProgress]
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The status of the operation performed on the gallery image [Succeeded, Failed, InProgress]",
        SerializedName = @"status",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Support.Status) })]
        Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Support.Status? ProvisioningStatus { get; set; }
        /// <summary>The ID of the operation performed on the gallery image</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The ID of the operation performed on the gallery image",
        SerializedName = @"operationId",
        PossibleTypes = new [] { typeof(string) })]
        string ProvisioningStatusOperationId { get; set; }
        /// <summary>GalleryImage provisioning error code</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"GalleryImage provisioning error code",
        SerializedName = @"errorCode",
        PossibleTypes = new [] { typeof(string) })]
        string StatusErrorCode { get; set; }
        /// <summary>Descriptive error message</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Descriptive error message",
        SerializedName = @"errorMessage",
        PossibleTypes = new [] { typeof(string) })]
        string StatusErrorMessage { get; set; }
        /// <summary>The progress of the operation in percentage</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The progress of the operation in percentage",
        SerializedName = @"progressPercentage",
        PossibleTypes = new [] { typeof(long) })]
        long? StatusProgressPercentage { get; set; }
        /// <summary>This is the version of the gallery image.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"This is the version of the gallery image.",
        SerializedName = @"name",
        PossibleTypes = new [] { typeof(string) })]
        string VersionName { get; set; }

    }
    /// Properties under the gallery image resource
    internal partial interface IGalleryImagePropertiesInternal

    {
        /// <summary>
        /// Datasource for the gallery image when provisioning with cloud-init [NoCloud, Azure]
        /// </summary>
        Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Support.CloudInitDataSource? CloudInitDataSource { get; set; }
        /// <summary>Container Name for storage container</summary>
        string ContainerName { get; set; }
        /// <summary>The downloaded sized of the image in MB</summary>
        long? DownloadStatusDownloadSizeInMb { get; set; }
        /// <summary>The hypervisor generation of the Virtual Machine [V1, V2]</summary>
        Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Support.HyperVGeneration? HyperVGeneration { get; set; }
        /// <summary>This is the gallery image definition identifier.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IGalleryImageIdentifier Identifier { get; set; }
        /// <summary>The name of the gallery image definition offer.</summary>
        string IdentifierOffer { get; set; }
        /// <summary>The name of the gallery image definition publisher.</summary>
        string IdentifierPublisher { get; set; }
        /// <summary>The name of the gallery image definition SKU.</summary>
        string IdentifierSku { get; set; }
        /// <summary>location of the image the gallery image should be created from</summary>
        string ImagePath { get; set; }
        /// <summary>This property indicates the size of the VHD to be created.</summary>
        long? OSDiskImageSizeInMb { get; set; }
        /// <summary>Operating system type that the gallery image uses [Windows, Linux]</summary>
        Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Support.OperatingSystemTypes? OSType { get; set; }
        /// <summary>Provisioning state of the gallery image.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Support.ProvisioningStateEnum? ProvisioningState { get; set; }
        /// <summary>
        /// The status of the operation performed on the gallery image [Succeeded, Failed, InProgress]
        /// </summary>
        Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Support.Status? ProvisioningStatus { get; set; }
        /// <summary>The ID of the operation performed on the gallery image</summary>
        string ProvisioningStatusOperationId { get; set; }
        /// <summary>The observed state of gallery images</summary>
        Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IGalleryImageStatus Status { get; set; }
        /// <summary>The download status of the gallery image</summary>
        Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IGalleryImageStatusDownloadStatus StatusDownloadStatus { get; set; }
        /// <summary>GalleryImage provisioning error code</summary>
        string StatusErrorCode { get; set; }
        /// <summary>Descriptive error message</summary>
        string StatusErrorMessage { get; set; }
        /// <summary>The progress of the operation in percentage</summary>
        long? StatusProgressPercentage { get; set; }

        Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IGalleryImageStatusProvisioningStatus StatusProvisioningStatus { get; set; }
        /// <summary>This is the storage profile of a Gallery Image Version.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IGalleryImageVersionStorageProfile StorageProfile { get; set; }
        /// <summary>This is the disk image base class.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IGalleryDiskImage StorageProfileOSDiskImage { get; set; }
        /// <summary>
        /// Specifies information about the gallery image version that you want to create or update.
        /// </summary>
        Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IGalleryImageVersion Version { get; set; }
        /// <summary>This is the version of the gallery image.</summary>
        string VersionName { get; set; }
        /// <summary>Describes the properties of a gallery image version.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IGalleryImageVersionProperties VersionProperty { get; set; }

    }
}