namespace Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101
{
    using static Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Runtime.Extensions;

    /// <summary>Contains the job information.</summary>
    public partial class JobResponse :
        Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IJobResponse,
        Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IJobResponseInternal
    {

        /// <summary>
        /// Default value is false. Indicates whether the manifest files on the drives should be copied to block blobs.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Origin(Microsoft.Azure.PowerShell.Cmdlets.ImportExport.PropertyOrigin.Inlined)]
        public bool? BackupDriveManifest { get => ((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IJobDetailsInternal)Property).BackupDriveManifest; set => ((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IJobDetailsInternal)Property).BackupDriveManifest = value; }

        /// <summary>A collection of blob-path strings.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Origin(Microsoft.Azure.PowerShell.Cmdlets.ImportExport.PropertyOrigin.Inlined)]
        public string[] BlobListBlobPath { get => ((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IJobDetailsInternal)Property).BlobListBlobPath; set => ((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IJobDetailsInternal)Property).BlobListBlobPath = value; }

        /// <summary>A collection of blob-prefix strings.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Origin(Microsoft.Azure.PowerShell.Cmdlets.ImportExport.PropertyOrigin.Inlined)]
        public string[] BlobListBlobPathPrefix { get => ((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IJobDetailsInternal)Property).BlobListBlobPathPrefix; set => ((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IJobDetailsInternal)Property).BlobListBlobPathPrefix = value; }

        /// <summary>Indicates whether a request has been submitted to cancel the job.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Origin(Microsoft.Azure.PowerShell.Cmdlets.ImportExport.PropertyOrigin.Inlined)]
        public bool? CancelRequested { get => ((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IJobDetailsInternal)Property).CancelRequested; set => ((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IJobDetailsInternal)Property).CancelRequested = value; }

        /// <summary>The name of the carrier that is used to ship the import or export drives.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Origin(Microsoft.Azure.PowerShell.Cmdlets.ImportExport.PropertyOrigin.Inlined)]
        public string DeliveryPackageCarrierName { get => ((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IJobDetailsInternal)Property).DeliveryPackageCarrierName; set => ((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IJobDetailsInternal)Property).DeliveryPackageCarrierName = value; }

        /// <summary>The number of drives included in the package.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Origin(Microsoft.Azure.PowerShell.Cmdlets.ImportExport.PropertyOrigin.Inlined)]
        public int DeliveryPackageDriveCount { get => ((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IJobDetailsInternal)Property).DeliveryPackageDriveCount; set => ((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IJobDetailsInternal)Property).DeliveryPackageDriveCount = value; }

        /// <summary>The date when the package is shipped.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Origin(Microsoft.Azure.PowerShell.Cmdlets.ImportExport.PropertyOrigin.Inlined)]
        public string DeliveryPackageShipDate { get => ((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IJobDetailsInternal)Property).DeliveryPackageShipDate; set => ((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IJobDetailsInternal)Property).DeliveryPackageShipDate = value; }

        /// <summary>The tracking number of the package.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Origin(Microsoft.Azure.PowerShell.Cmdlets.ImportExport.PropertyOrigin.Inlined)]
        public string DeliveryPackageTrackingNumber { get => ((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IJobDetailsInternal)Property).DeliveryPackageTrackingNumber; set => ((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IJobDetailsInternal)Property).DeliveryPackageTrackingNumber = value; }

        /// <summary>
        /// The virtual blob directory to which the copy logs and backups of drive manifest files (if enabled) will be stored.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Origin(Microsoft.Azure.PowerShell.Cmdlets.ImportExport.PropertyOrigin.Inlined)]
        public string DiagnosticsPath { get => ((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IJobDetailsInternal)Property).DiagnosticsPath; set => ((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IJobDetailsInternal)Property).DiagnosticsPath = value; }

        /// <summary>
        /// List of up to ten drives that comprise the job. The drive list is a required element for an import job; it is not specified
        /// for export jobs.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Origin(Microsoft.Azure.PowerShell.Cmdlets.ImportExport.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IDriveStatus[] DriveList { get => ((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IJobDetailsInternal)Property).DriveList; set => ((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IJobDetailsInternal)Property).DriveList = value; }

        /// <summary>
        /// The relative URI to the block blob that contains the list of blob paths or blob path prefixes as defined above, beginning
        /// with the container name. If the blob is in root container, the URI must begin with $root.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Origin(Microsoft.Azure.PowerShell.Cmdlets.ImportExport.PropertyOrigin.Inlined)]
        public string ExportBlobListblobPath { get => ((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IJobDetailsInternal)Property).ExportBlobListblobPath; set => ((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IJobDetailsInternal)Property).ExportBlobListblobPath = value; }

        /// <summary>Backing field for <see cref="Id" /> property.</summary>
        private string _id;

        /// <summary>Specifies the resource identifier of the job.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Origin(Microsoft.Azure.PowerShell.Cmdlets.ImportExport.PropertyOrigin.Owned)]
        public string Id { get => this._id; }

        /// <summary>
        /// A blob path that points to a block blob containing a list of blob names that were not exported due to insufficient drive
        /// space. If all blobs were exported successfully, then this element is not included in the response.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Origin(Microsoft.Azure.PowerShell.Cmdlets.ImportExport.PropertyOrigin.Inlined)]
        public string IncompleteBlobListUri { get => ((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IJobDetailsInternal)Property).IncompleteBlobListUri; set => ((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IJobDetailsInternal)Property).IncompleteBlobListUri = value; }

        /// <summary>The type of job</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Origin(Microsoft.Azure.PowerShell.Cmdlets.ImportExport.PropertyOrigin.Inlined)]
        public string JobType { get => ((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IJobDetailsInternal)Property).JobType; set => ((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IJobDetailsInternal)Property).JobType = value; }

        /// <summary>Backing field for <see cref="Location" /> property.</summary>
        private string _location;

        /// <summary>Specifies the Azure location where the job is created.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Origin(Microsoft.Azure.PowerShell.Cmdlets.ImportExport.PropertyOrigin.Owned)]
        public string Location { get => this._location; set => this._location = value; }

        /// <summary>
        /// Default value is Error. Indicates whether error logging or verbose logging will be enabled.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Origin(Microsoft.Azure.PowerShell.Cmdlets.ImportExport.PropertyOrigin.Inlined)]
        public string LogLevel { get => ((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IJobDetailsInternal)Property).LogLevel; set => ((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IJobDetailsInternal)Property).LogLevel = value; }

        /// <summary>Internal Acessors for DeliveryPackage</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IPackageInfomation Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IJobResponseInternal.DeliveryPackage { get => ((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IJobDetailsInternal)Property).DeliveryPackage; set => ((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IJobDetailsInternal)Property).DeliveryPackage = value; }

        /// <summary>Internal Acessors for Export</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IExport Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IJobResponseInternal.Export { get => ((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IJobDetailsInternal)Property).Export; set => ((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IJobDetailsInternal)Property).Export = value; }

        /// <summary>Internal Acessors for ExportBlobList</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IExportBlobList Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IJobResponseInternal.ExportBlobList { get => ((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IJobDetailsInternal)Property).ExportBlobList; set => ((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IJobDetailsInternal)Property).ExportBlobList = value; }

        /// <summary>Internal Acessors for Id</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IJobResponseInternal.Id { get => this._id; set { {_id = value;} } }

        /// <summary>Internal Acessors for Name</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IJobResponseInternal.Name { get => this._name; set { {_name = value;} } }

        /// <summary>Internal Acessors for Property</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IJobDetails Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IJobResponseInternal.Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.JobDetails()); set { {_property = value;} } }

        /// <summary>Internal Acessors for ReturnAddress</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IReturnAddress Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IJobResponseInternal.ReturnAddress { get => ((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IJobDetailsInternal)Property).ReturnAddress; set => ((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IJobDetailsInternal)Property).ReturnAddress = value; }

        /// <summary>Internal Acessors for ReturnPackage</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IPackageInfomation Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IJobResponseInternal.ReturnPackage { get => ((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IJobDetailsInternal)Property).ReturnPackage; set => ((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IJobDetailsInternal)Property).ReturnPackage = value; }

        /// <summary>Internal Acessors for ReturnShipping</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IReturnShipping Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IJobResponseInternal.ReturnShipping { get => ((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IJobDetailsInternal)Property).ReturnShipping; set => ((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IJobDetailsInternal)Property).ReturnShipping = value; }

        /// <summary>Internal Acessors for ShippingInformation</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IShippingInformation Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IJobResponseInternal.ShippingInformation { get => ((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IJobDetailsInternal)Property).ShippingInformation; set => ((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IJobDetailsInternal)Property).ShippingInformation = value; }

        /// <summary>Internal Acessors for Type</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IJobResponseInternal.Type { get => this._type; set { {_type = value;} } }

        /// <summary>Backing field for <see cref="Name" /> property.</summary>
        private string _name;

        /// <summary>Specifies the name of the job.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Origin(Microsoft.Azure.PowerShell.Cmdlets.ImportExport.PropertyOrigin.Owned)]
        public string Name { get => this._name; }

        /// <summary>Overall percentage completed for the job.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Origin(Microsoft.Azure.PowerShell.Cmdlets.ImportExport.PropertyOrigin.Inlined)]
        public int? PercentComplete { get => ((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IJobDetailsInternal)Property).PercentComplete; set => ((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IJobDetailsInternal)Property).PercentComplete = value; }

        /// <summary>Backing field for <see cref="Property" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IJobDetails _property;

        /// <summary>Specifies the job properties</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Origin(Microsoft.Azure.PowerShell.Cmdlets.ImportExport.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IJobDetails Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.JobDetails()); set => this._property = value; }

        /// <summary>Specifies the provisioning state of the job.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Origin(Microsoft.Azure.PowerShell.Cmdlets.ImportExport.PropertyOrigin.Inlined)]
        public string ProvisioningState { get => ((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IJobDetailsInternal)Property).ProvisioningState; set => ((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IJobDetailsInternal)Property).ProvisioningState = value; }

        /// <summary>The city name to use when returning the drives.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Origin(Microsoft.Azure.PowerShell.Cmdlets.ImportExport.PropertyOrigin.Inlined)]
        public string ReturnAddressCity { get => ((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IJobDetailsInternal)Property).ReturnAddressCity; set => ((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IJobDetailsInternal)Property).ReturnAddressCity = value; }

        /// <summary>The country or region to use when returning the drives.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Origin(Microsoft.Azure.PowerShell.Cmdlets.ImportExport.PropertyOrigin.Inlined)]
        public string ReturnAddressCountryOrRegion { get => ((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IJobDetailsInternal)Property).ReturnAddressCountryOrRegion; set => ((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IJobDetailsInternal)Property).ReturnAddressCountryOrRegion = value; }

        /// <summary>Email address of the recipient of the returned drives.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Origin(Microsoft.Azure.PowerShell.Cmdlets.ImportExport.PropertyOrigin.Inlined)]
        public string ReturnAddressEmail { get => ((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IJobDetailsInternal)Property).ReturnAddressEmail; set => ((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IJobDetailsInternal)Property).ReturnAddressEmail = value; }

        /// <summary>Phone number of the recipient of the returned drives.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Origin(Microsoft.Azure.PowerShell.Cmdlets.ImportExport.PropertyOrigin.Inlined)]
        public string ReturnAddressPhone { get => ((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IJobDetailsInternal)Property).ReturnAddressPhone; set => ((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IJobDetailsInternal)Property).ReturnAddressPhone = value; }

        /// <summary>The postal code to use when returning the drives.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Origin(Microsoft.Azure.PowerShell.Cmdlets.ImportExport.PropertyOrigin.Inlined)]
        public string ReturnAddressPostalCode { get => ((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IJobDetailsInternal)Property).ReturnAddressPostalCode; set => ((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IJobDetailsInternal)Property).ReturnAddressPostalCode = value; }

        /// <summary>
        /// The name of the recipient who will receive the hard drives when they are returned.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Origin(Microsoft.Azure.PowerShell.Cmdlets.ImportExport.PropertyOrigin.Inlined)]
        public string ReturnAddressRecipientName { get => ((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IJobDetailsInternal)Property).ReturnAddressRecipientName; set => ((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IJobDetailsInternal)Property).ReturnAddressRecipientName = value; }

        /// <summary>The state or province to use when returning the drives.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Origin(Microsoft.Azure.PowerShell.Cmdlets.ImportExport.PropertyOrigin.Inlined)]
        public string ReturnAddressStateOrProvince { get => ((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IJobDetailsInternal)Property).ReturnAddressStateOrProvince; set => ((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IJobDetailsInternal)Property).ReturnAddressStateOrProvince = value; }

        /// <summary>The first line of the street address to use when returning the drives.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Origin(Microsoft.Azure.PowerShell.Cmdlets.ImportExport.PropertyOrigin.Inlined)]
        public string ReturnAddressStreetAddress1 { get => ((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IJobDetailsInternal)Property).ReturnAddressStreetAddress1; set => ((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IJobDetailsInternal)Property).ReturnAddressStreetAddress1 = value; }

        /// <summary>The second line of the street address to use when returning the drives.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Origin(Microsoft.Azure.PowerShell.Cmdlets.ImportExport.PropertyOrigin.Inlined)]
        public string ReturnAddressStreetAddress2 { get => ((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IJobDetailsInternal)Property).ReturnAddressStreetAddress2; set => ((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IJobDetailsInternal)Property).ReturnAddressStreetAddress2 = value; }

        /// <summary>The name of the carrier that is used to ship the import or export drives.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Origin(Microsoft.Azure.PowerShell.Cmdlets.ImportExport.PropertyOrigin.Inlined)]
        public string ReturnPackageCarrierName { get => ((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IJobDetailsInternal)Property).ReturnPackageCarrierName; set => ((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IJobDetailsInternal)Property).ReturnPackageCarrierName = value; }

        /// <summary>The number of drives included in the package.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Origin(Microsoft.Azure.PowerShell.Cmdlets.ImportExport.PropertyOrigin.Inlined)]
        public int ReturnPackageDriveCount { get => ((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IJobDetailsInternal)Property).ReturnPackageDriveCount; set => ((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IJobDetailsInternal)Property).ReturnPackageDriveCount = value; }

        /// <summary>The date when the package is shipped.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Origin(Microsoft.Azure.PowerShell.Cmdlets.ImportExport.PropertyOrigin.Inlined)]
        public string ReturnPackageShipDate { get => ((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IJobDetailsInternal)Property).ReturnPackageShipDate; set => ((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IJobDetailsInternal)Property).ReturnPackageShipDate = value; }

        /// <summary>The tracking number of the package.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Origin(Microsoft.Azure.PowerShell.Cmdlets.ImportExport.PropertyOrigin.Inlined)]
        public string ReturnPackageTrackingNumber { get => ((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IJobDetailsInternal)Property).ReturnPackageTrackingNumber; set => ((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IJobDetailsInternal)Property).ReturnPackageTrackingNumber = value; }

        /// <summary>The customer's account number with the carrier.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Origin(Microsoft.Azure.PowerShell.Cmdlets.ImportExport.PropertyOrigin.Inlined)]
        public string ReturnShippingCarrierAccountNumber { get => ((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IJobDetailsInternal)Property).ReturnShippingCarrierAccountNumber; set => ((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IJobDetailsInternal)Property).ReturnShippingCarrierAccountNumber = value; }

        /// <summary>The carrier's name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Origin(Microsoft.Azure.PowerShell.Cmdlets.ImportExport.PropertyOrigin.Inlined)]
        public string ReturnShippingCarrierName { get => ((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IJobDetailsInternal)Property).ReturnShippingCarrierName; set => ((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IJobDetailsInternal)Property).ReturnShippingCarrierName = value; }

        /// <summary>The city name to use when returning the drives.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Origin(Microsoft.Azure.PowerShell.Cmdlets.ImportExport.PropertyOrigin.Inlined)]
        public string ShippingInformationCity { get => ((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IJobDetailsInternal)Property).ShippingInformationCity; set => ((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IJobDetailsInternal)Property).ShippingInformationCity = value; }

        /// <summary>The country or region to use when returning the drives.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Origin(Microsoft.Azure.PowerShell.Cmdlets.ImportExport.PropertyOrigin.Inlined)]
        public string ShippingInformationCountryOrRegion { get => ((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IJobDetailsInternal)Property).ShippingInformationCountryOrRegion; set => ((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IJobDetailsInternal)Property).ShippingInformationCountryOrRegion = value; }

        /// <summary>Phone number of the recipient of the returned drives.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Origin(Microsoft.Azure.PowerShell.Cmdlets.ImportExport.PropertyOrigin.Inlined)]
        public string ShippingInformationPhone { get => ((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IJobDetailsInternal)Property).ShippingInformationPhone; set => ((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IJobDetailsInternal)Property).ShippingInformationPhone = value; }

        /// <summary>The postal code to use when returning the drives.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Origin(Microsoft.Azure.PowerShell.Cmdlets.ImportExport.PropertyOrigin.Inlined)]
        public string ShippingInformationPostalCode { get => ((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IJobDetailsInternal)Property).ShippingInformationPostalCode; set => ((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IJobDetailsInternal)Property).ShippingInformationPostalCode = value; }

        /// <summary>
        /// The name of the recipient who will receive the hard drives when they are returned.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Origin(Microsoft.Azure.PowerShell.Cmdlets.ImportExport.PropertyOrigin.Inlined)]
        public string ShippingInformationRecipientName { get => ((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IJobDetailsInternal)Property).ShippingInformationRecipientName; set => ((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IJobDetailsInternal)Property).ShippingInformationRecipientName = value; }

        /// <summary>The state or province to use when returning the drives.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Origin(Microsoft.Azure.PowerShell.Cmdlets.ImportExport.PropertyOrigin.Inlined)]
        public string ShippingInformationStateOrProvince { get => ((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IJobDetailsInternal)Property).ShippingInformationStateOrProvince; set => ((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IJobDetailsInternal)Property).ShippingInformationStateOrProvince = value; }

        /// <summary>The first line of the street address to use when returning the drives.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Origin(Microsoft.Azure.PowerShell.Cmdlets.ImportExport.PropertyOrigin.Inlined)]
        public string ShippingInformationStreetAddress1 { get => ((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IJobDetailsInternal)Property).ShippingInformationStreetAddress1; set => ((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IJobDetailsInternal)Property).ShippingInformationStreetAddress1 = value; }

        /// <summary>The second line of the street address to use when returning the drives.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Origin(Microsoft.Azure.PowerShell.Cmdlets.ImportExport.PropertyOrigin.Inlined)]
        public string ShippingInformationStreetAddress2 { get => ((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IJobDetailsInternal)Property).ShippingInformationStreetAddress2; set => ((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IJobDetailsInternal)Property).ShippingInformationStreetAddress2 = value; }

        /// <summary>Current state of the job.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Origin(Microsoft.Azure.PowerShell.Cmdlets.ImportExport.PropertyOrigin.Inlined)]
        public string State { get => ((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IJobDetailsInternal)Property).State; set => ((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IJobDetailsInternal)Property).State = value; }

        /// <summary>
        /// The resource identifier of the storage account where data will be imported to or exported from.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Origin(Microsoft.Azure.PowerShell.Cmdlets.ImportExport.PropertyOrigin.Inlined)]
        public string StorageAccountId { get => ((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IJobDetailsInternal)Property).StorageAccountId; set => ((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IJobDetailsInternal)Property).StorageAccountId = value; }

        /// <summary>Backing field for <see cref="Tag" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IJobResponseTags _tag;

        /// <summary>Specifies the tags that are assigned to the job.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Origin(Microsoft.Azure.PowerShell.Cmdlets.ImportExport.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IJobResponseTags Tag { get => (this._tag = this._tag ?? new Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.JobResponseTags()); set => this._tag = value; }

        /// <summary>Backing field for <see cref="Type" /> property.</summary>
        private string _type;

        /// <summary>Specifies the type of the job resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Origin(Microsoft.Azure.PowerShell.Cmdlets.ImportExport.PropertyOrigin.Owned)]
        public string Type { get => this._type; }

        /// <summary>Creates an new <see cref="JobResponse" /> instance.</summary>
        public JobResponse()
        {

        }
    }
    /// Contains the job information.
    public partial interface IJobResponse :
        Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Runtime.IJsonSerializable
    {
        /// <summary>
        /// Default value is false. Indicates whether the manifest files on the drives should be copied to block blobs.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Default value is false. Indicates whether the manifest files on the drives should be copied to block blobs.",
        SerializedName = @"backupDriveManifest",
        PossibleTypes = new [] { typeof(bool) })]
        bool? BackupDriveManifest { get; set; }
        /// <summary>A collection of blob-path strings.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"A collection of blob-path strings.",
        SerializedName = @"blobPath",
        PossibleTypes = new [] { typeof(string) })]
        string[] BlobListBlobPath { get; set; }
        /// <summary>A collection of blob-prefix strings.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"A collection of blob-prefix strings.",
        SerializedName = @"blobPathPrefix",
        PossibleTypes = new [] { typeof(string) })]
        string[] BlobListBlobPathPrefix { get; set; }
        /// <summary>Indicates whether a request has been submitted to cancel the job.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Indicates whether a request has been submitted to cancel the job.",
        SerializedName = @"cancelRequested",
        PossibleTypes = new [] { typeof(bool) })]
        bool? CancelRequested { get; set; }
        /// <summary>The name of the carrier that is used to ship the import or export drives.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"The name of the carrier that is used to ship the import or export drives.",
        SerializedName = @"carrierName",
        PossibleTypes = new [] { typeof(string) })]
        string DeliveryPackageCarrierName { get; set; }
        /// <summary>The number of drives included in the package.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"The number of drives included in the package.",
        SerializedName = @"driveCount",
        PossibleTypes = new [] { typeof(int) })]
        int DeliveryPackageDriveCount { get; set; }
        /// <summary>The date when the package is shipped.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"The date when the package is shipped.",
        SerializedName = @"shipDate",
        PossibleTypes = new [] { typeof(string) })]
        string DeliveryPackageShipDate { get; set; }
        /// <summary>The tracking number of the package.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"The tracking number of the package.",
        SerializedName = @"trackingNumber",
        PossibleTypes = new [] { typeof(string) })]
        string DeliveryPackageTrackingNumber { get; set; }
        /// <summary>
        /// The virtual blob directory to which the copy logs and backups of drive manifest files (if enabled) will be stored.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The virtual blob directory to which the copy logs and backups of drive manifest files (if enabled) will be stored.",
        SerializedName = @"diagnosticsPath",
        PossibleTypes = new [] { typeof(string) })]
        string DiagnosticsPath { get; set; }
        /// <summary>
        /// List of up to ten drives that comprise the job. The drive list is a required element for an import job; it is not specified
        /// for export jobs.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"List of up to ten drives that comprise the job. The drive list is a required element for an import job; it is not specified for export jobs.",
        SerializedName = @"driveList",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IDriveStatus) })]
        Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IDriveStatus[] DriveList { get; set; }
        /// <summary>
        /// The relative URI to the block blob that contains the list of blob paths or blob path prefixes as defined above, beginning
        /// with the container name. If the blob is in root container, the URI must begin with $root.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The relative URI to the block blob that contains the list of blob paths or blob path prefixes as defined above, beginning with the container name. If the blob is in root container, the URI must begin with $root. ",
        SerializedName = @"blobListblobPath",
        PossibleTypes = new [] { typeof(string) })]
        string ExportBlobListblobPath { get; set; }
        /// <summary>Specifies the resource identifier of the job.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Specifies the resource identifier of the job.",
        SerializedName = @"id",
        PossibleTypes = new [] { typeof(string) })]
        string Id { get;  }
        /// <summary>
        /// A blob path that points to a block blob containing a list of blob names that were not exported due to insufficient drive
        /// space. If all blobs were exported successfully, then this element is not included in the response.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"A blob path that points to a block blob containing a list of blob names that were not exported due to insufficient drive space. If all blobs were exported successfully, then this element is not included in the response.",
        SerializedName = @"incompleteBlobListUri",
        PossibleTypes = new [] { typeof(string) })]
        string IncompleteBlobListUri { get; set; }
        /// <summary>The type of job</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The type of job",
        SerializedName = @"jobType",
        PossibleTypes = new [] { typeof(string) })]
        string JobType { get; set; }
        /// <summary>Specifies the Azure location where the job is created.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Specifies the Azure location where the job is created.",
        SerializedName = @"location",
        PossibleTypes = new [] { typeof(string) })]
        string Location { get; set; }
        /// <summary>
        /// Default value is Error. Indicates whether error logging or verbose logging will be enabled.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Default value is Error. Indicates whether error logging or verbose logging will be enabled.",
        SerializedName = @"logLevel",
        PossibleTypes = new [] { typeof(string) })]
        string LogLevel { get; set; }
        /// <summary>Specifies the name of the job.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Specifies the name of the job.",
        SerializedName = @"name",
        PossibleTypes = new [] { typeof(string) })]
        string Name { get;  }
        /// <summary>Overall percentage completed for the job.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Overall percentage completed for the job.",
        SerializedName = @"percentComplete",
        PossibleTypes = new [] { typeof(int) })]
        int? PercentComplete { get; set; }
        /// <summary>Specifies the provisioning state of the job.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Specifies the provisioning state of the job.",
        SerializedName = @"provisioningState",
        PossibleTypes = new [] { typeof(string) })]
        string ProvisioningState { get; set; }
        /// <summary>The city name to use when returning the drives.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"The city name to use when returning the drives.",
        SerializedName = @"city",
        PossibleTypes = new [] { typeof(string) })]
        string ReturnAddressCity { get; set; }
        /// <summary>The country or region to use when returning the drives.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"The country or region to use when returning the drives. ",
        SerializedName = @"countryOrRegion",
        PossibleTypes = new [] { typeof(string) })]
        string ReturnAddressCountryOrRegion { get; set; }
        /// <summary>Email address of the recipient of the returned drives.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"Email address of the recipient of the returned drives.",
        SerializedName = @"email",
        PossibleTypes = new [] { typeof(string) })]
        string ReturnAddressEmail { get; set; }
        /// <summary>Phone number of the recipient of the returned drives.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"Phone number of the recipient of the returned drives.",
        SerializedName = @"phone",
        PossibleTypes = new [] { typeof(string) })]
        string ReturnAddressPhone { get; set; }
        /// <summary>The postal code to use when returning the drives.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"The postal code to use when returning the drives.",
        SerializedName = @"postalCode",
        PossibleTypes = new [] { typeof(string) })]
        string ReturnAddressPostalCode { get; set; }
        /// <summary>
        /// The name of the recipient who will receive the hard drives when they are returned.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"The name of the recipient who will receive the hard drives when they are returned. ",
        SerializedName = @"recipientName",
        PossibleTypes = new [] { typeof(string) })]
        string ReturnAddressRecipientName { get; set; }
        /// <summary>The state or province to use when returning the drives.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The state or province to use when returning the drives.",
        SerializedName = @"stateOrProvince",
        PossibleTypes = new [] { typeof(string) })]
        string ReturnAddressStateOrProvince { get; set; }
        /// <summary>The first line of the street address to use when returning the drives.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"The first line of the street address to use when returning the drives. ",
        SerializedName = @"streetAddress1",
        PossibleTypes = new [] { typeof(string) })]
        string ReturnAddressStreetAddress1 { get; set; }
        /// <summary>The second line of the street address to use when returning the drives.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The second line of the street address to use when returning the drives. ",
        SerializedName = @"streetAddress2",
        PossibleTypes = new [] { typeof(string) })]
        string ReturnAddressStreetAddress2 { get; set; }
        /// <summary>The name of the carrier that is used to ship the import or export drives.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"The name of the carrier that is used to ship the import or export drives.",
        SerializedName = @"carrierName",
        PossibleTypes = new [] { typeof(string) })]
        string ReturnPackageCarrierName { get; set; }
        /// <summary>The number of drives included in the package.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"The number of drives included in the package.",
        SerializedName = @"driveCount",
        PossibleTypes = new [] { typeof(int) })]
        int ReturnPackageDriveCount { get; set; }
        /// <summary>The date when the package is shipped.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"The date when the package is shipped.",
        SerializedName = @"shipDate",
        PossibleTypes = new [] { typeof(string) })]
        string ReturnPackageShipDate { get; set; }
        /// <summary>The tracking number of the package.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"The tracking number of the package.",
        SerializedName = @"trackingNumber",
        PossibleTypes = new [] { typeof(string) })]
        string ReturnPackageTrackingNumber { get; set; }
        /// <summary>The customer's account number with the carrier.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"The customer's account number with the carrier.",
        SerializedName = @"carrierAccountNumber",
        PossibleTypes = new [] { typeof(string) })]
        string ReturnShippingCarrierAccountNumber { get; set; }
        /// <summary>The carrier's name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"The carrier's name.",
        SerializedName = @"carrierName",
        PossibleTypes = new [] { typeof(string) })]
        string ReturnShippingCarrierName { get; set; }
        /// <summary>The city name to use when returning the drives.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"The city name to use when returning the drives.",
        SerializedName = @"city",
        PossibleTypes = new [] { typeof(string) })]
        string ShippingInformationCity { get; set; }
        /// <summary>The country or region to use when returning the drives.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"The country or region to use when returning the drives. ",
        SerializedName = @"countryOrRegion",
        PossibleTypes = new [] { typeof(string) })]
        string ShippingInformationCountryOrRegion { get; set; }
        /// <summary>Phone number of the recipient of the returned drives.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Phone number of the recipient of the returned drives.",
        SerializedName = @"phone",
        PossibleTypes = new [] { typeof(string) })]
        string ShippingInformationPhone { get; set; }
        /// <summary>The postal code to use when returning the drives.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"The postal code to use when returning the drives.",
        SerializedName = @"postalCode",
        PossibleTypes = new [] { typeof(string) })]
        string ShippingInformationPostalCode { get; set; }
        /// <summary>
        /// The name of the recipient who will receive the hard drives when they are returned.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"The name of the recipient who will receive the hard drives when they are returned. ",
        SerializedName = @"recipientName",
        PossibleTypes = new [] { typeof(string) })]
        string ShippingInformationRecipientName { get; set; }
        /// <summary>The state or province to use when returning the drives.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"The state or province to use when returning the drives.",
        SerializedName = @"stateOrProvince",
        PossibleTypes = new [] { typeof(string) })]
        string ShippingInformationStateOrProvince { get; set; }
        /// <summary>The first line of the street address to use when returning the drives.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"The first line of the street address to use when returning the drives. ",
        SerializedName = @"streetAddress1",
        PossibleTypes = new [] { typeof(string) })]
        string ShippingInformationStreetAddress1 { get; set; }
        /// <summary>The second line of the street address to use when returning the drives.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The second line of the street address to use when returning the drives. ",
        SerializedName = @"streetAddress2",
        PossibleTypes = new [] { typeof(string) })]
        string ShippingInformationStreetAddress2 { get; set; }
        /// <summary>Current state of the job.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Current state of the job.",
        SerializedName = @"state",
        PossibleTypes = new [] { typeof(string) })]
        string State { get; set; }
        /// <summary>
        /// The resource identifier of the storage account where data will be imported to or exported from.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The resource identifier of the storage account where data will be imported to or exported from.",
        SerializedName = @"storageAccountId",
        PossibleTypes = new [] { typeof(string) })]
        string StorageAccountId { get; set; }
        /// <summary>Specifies the tags that are assigned to the job.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Specifies the tags that are assigned to the job.",
        SerializedName = @"tags",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IJobResponseTags) })]
        Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IJobResponseTags Tag { get; set; }
        /// <summary>Specifies the type of the job resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Specifies the type of the job resource.",
        SerializedName = @"type",
        PossibleTypes = new [] { typeof(string) })]
        string Type { get;  }

    }
    /// Contains the job information.
    internal partial interface IJobResponseInternal

    {
        /// <summary>
        /// Default value is false. Indicates whether the manifest files on the drives should be copied to block blobs.
        /// </summary>
        bool? BackupDriveManifest { get; set; }
        /// <summary>A collection of blob-path strings.</summary>
        string[] BlobListBlobPath { get; set; }
        /// <summary>A collection of blob-prefix strings.</summary>
        string[] BlobListBlobPathPrefix { get; set; }
        /// <summary>Indicates whether a request has been submitted to cancel the job.</summary>
        bool? CancelRequested { get; set; }
        /// <summary>
        /// Contains information about the package being shipped by the customer to the Microsoft data center.
        /// </summary>
        Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IPackageInfomation DeliveryPackage { get; set; }
        /// <summary>The name of the carrier that is used to ship the import or export drives.</summary>
        string DeliveryPackageCarrierName { get; set; }
        /// <summary>The number of drives included in the package.</summary>
        int DeliveryPackageDriveCount { get; set; }
        /// <summary>The date when the package is shipped.</summary>
        string DeliveryPackageShipDate { get; set; }
        /// <summary>The tracking number of the package.</summary>
        string DeliveryPackageTrackingNumber { get; set; }
        /// <summary>
        /// The virtual blob directory to which the copy logs and backups of drive manifest files (if enabled) will be stored.
        /// </summary>
        string DiagnosticsPath { get; set; }
        /// <summary>
        /// List of up to ten drives that comprise the job. The drive list is a required element for an import job; it is not specified
        /// for export jobs.
        /// </summary>
        Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IDriveStatus[] DriveList { get; set; }
        /// <summary>
        /// A property containing information about the blobs to be exported for an export job. This property is included for export
        /// jobs only.
        /// </summary>
        Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IExport Export { get; set; }
        /// <summary>A list of the blobs to be exported.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IExportBlobList ExportBlobList { get; set; }
        /// <summary>
        /// The relative URI to the block blob that contains the list of blob paths or blob path prefixes as defined above, beginning
        /// with the container name. If the blob is in root container, the URI must begin with $root.
        /// </summary>
        string ExportBlobListblobPath { get; set; }
        /// <summary>Specifies the resource identifier of the job.</summary>
        string Id { get; set; }
        /// <summary>
        /// A blob path that points to a block blob containing a list of blob names that were not exported due to insufficient drive
        /// space. If all blobs were exported successfully, then this element is not included in the response.
        /// </summary>
        string IncompleteBlobListUri { get; set; }
        /// <summary>The type of job</summary>
        string JobType { get; set; }
        /// <summary>Specifies the Azure location where the job is created.</summary>
        string Location { get; set; }
        /// <summary>
        /// Default value is Error. Indicates whether error logging or verbose logging will be enabled.
        /// </summary>
        string LogLevel { get; set; }
        /// <summary>Specifies the name of the job.</summary>
        string Name { get; set; }
        /// <summary>Overall percentage completed for the job.</summary>
        int? PercentComplete { get; set; }
        /// <summary>Specifies the job properties</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IJobDetails Property { get; set; }
        /// <summary>Specifies the provisioning state of the job.</summary>
        string ProvisioningState { get; set; }
        /// <summary>Specifies the return address information for the job.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IReturnAddress ReturnAddress { get; set; }
        /// <summary>The city name to use when returning the drives.</summary>
        string ReturnAddressCity { get; set; }
        /// <summary>The country or region to use when returning the drives.</summary>
        string ReturnAddressCountryOrRegion { get; set; }
        /// <summary>Email address of the recipient of the returned drives.</summary>
        string ReturnAddressEmail { get; set; }
        /// <summary>Phone number of the recipient of the returned drives.</summary>
        string ReturnAddressPhone { get; set; }
        /// <summary>The postal code to use when returning the drives.</summary>
        string ReturnAddressPostalCode { get; set; }
        /// <summary>
        /// The name of the recipient who will receive the hard drives when they are returned.
        /// </summary>
        string ReturnAddressRecipientName { get; set; }
        /// <summary>The state or province to use when returning the drives.</summary>
        string ReturnAddressStateOrProvince { get; set; }
        /// <summary>The first line of the street address to use when returning the drives.</summary>
        string ReturnAddressStreetAddress1 { get; set; }
        /// <summary>The second line of the street address to use when returning the drives.</summary>
        string ReturnAddressStreetAddress2 { get; set; }
        /// <summary>
        /// Contains information about the package being shipped from the Microsoft data center to the customer to return the drives.
        /// The format is the same as the deliveryPackage property above. This property is not included if the drives have not yet
        /// been returned.
        /// </summary>
        Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IPackageInfomation ReturnPackage { get; set; }
        /// <summary>The name of the carrier that is used to ship the import or export drives.</summary>
        string ReturnPackageCarrierName { get; set; }
        /// <summary>The number of drives included in the package.</summary>
        int ReturnPackageDriveCount { get; set; }
        /// <summary>The date when the package is shipped.</summary>
        string ReturnPackageShipDate { get; set; }
        /// <summary>The tracking number of the package.</summary>
        string ReturnPackageTrackingNumber { get; set; }
        /// <summary>Specifies the return carrier and customer's account with the carrier.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IReturnShipping ReturnShipping { get; set; }
        /// <summary>The customer's account number with the carrier.</summary>
        string ReturnShippingCarrierAccountNumber { get; set; }
        /// <summary>The carrier's name.</summary>
        string ReturnShippingCarrierName { get; set; }
        /// <summary>
        /// Contains information about the Microsoft datacenter to which the drives should be shipped.
        /// </summary>
        Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IShippingInformation ShippingInformation { get; set; }
        /// <summary>The city name to use when returning the drives.</summary>
        string ShippingInformationCity { get; set; }
        /// <summary>The country or region to use when returning the drives.</summary>
        string ShippingInformationCountryOrRegion { get; set; }
        /// <summary>Phone number of the recipient of the returned drives.</summary>
        string ShippingInformationPhone { get; set; }
        /// <summary>The postal code to use when returning the drives.</summary>
        string ShippingInformationPostalCode { get; set; }
        /// <summary>
        /// The name of the recipient who will receive the hard drives when they are returned.
        /// </summary>
        string ShippingInformationRecipientName { get; set; }
        /// <summary>The state or province to use when returning the drives.</summary>
        string ShippingInformationStateOrProvince { get; set; }
        /// <summary>The first line of the street address to use when returning the drives.</summary>
        string ShippingInformationStreetAddress1 { get; set; }
        /// <summary>The second line of the street address to use when returning the drives.</summary>
        string ShippingInformationStreetAddress2 { get; set; }
        /// <summary>Current state of the job.</summary>
        string State { get; set; }
        /// <summary>
        /// The resource identifier of the storage account where data will be imported to or exported from.
        /// </summary>
        string StorageAccountId { get; set; }
        /// <summary>Specifies the tags that are assigned to the job.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IJobResponseTags Tag { get; set; }
        /// <summary>Specifies the type of the job resource.</summary>
        string Type { get; set; }

    }
}