namespace Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101
{
    using static Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Runtime.Extensions;

    /// <summary>Specifies the properties of a UpdateJob.</summary>
    public partial class UpdateJobParametersProperties :
        Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IUpdateJobParametersProperties,
        Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IUpdateJobParametersPropertiesInternal
    {

        /// <summary>Backing field for <see cref="BackupDriveManifest" /> property.</summary>
        private bool? _backupDriveManifest;

        /// <summary>
        /// Indicates whether the manifest files on the drives should be copied to block blobs.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Origin(Microsoft.Azure.PowerShell.Cmdlets.ImportExport.PropertyOrigin.Owned)]
        public bool? BackupDriveManifest { get => this._backupDriveManifest; set => this._backupDriveManifest = value; }

        /// <summary>Backing field for <see cref="CancelRequested" /> property.</summary>
        private bool? _cancelRequested;

        /// <summary>
        /// If specified, the value must be true. The service will attempt to cancel the job.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Origin(Microsoft.Azure.PowerShell.Cmdlets.ImportExport.PropertyOrigin.Owned)]
        public bool? CancelRequested { get => this._cancelRequested; set => this._cancelRequested = value; }

        /// <summary>Backing field for <see cref="DeliveryPackage" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IPackageInfomation _deliveryPackage;

        /// <summary>
        /// Contains information about the package being shipped by the customer to the Microsoft data center.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Origin(Microsoft.Azure.PowerShell.Cmdlets.ImportExport.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IPackageInfomation DeliveryPackage { get => (this._deliveryPackage = this._deliveryPackage ?? new Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.PackageInfomation()); set => this._deliveryPackage = value; }

        /// <summary>The name of the carrier that is used to ship the import or export drives.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Origin(Microsoft.Azure.PowerShell.Cmdlets.ImportExport.PropertyOrigin.Inlined)]
        public string DeliveryPackageCarrierName { get => ((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IPackageInfomationInternal)DeliveryPackage).CarrierName; set => ((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IPackageInfomationInternal)DeliveryPackage).CarrierName = value; }

        /// <summary>The number of drives included in the package.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Origin(Microsoft.Azure.PowerShell.Cmdlets.ImportExport.PropertyOrigin.Inlined)]
        public int DeliveryPackageDriveCount { get => ((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IPackageInfomationInternal)DeliveryPackage).DriveCount; set => ((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IPackageInfomationInternal)DeliveryPackage).DriveCount = value; }

        /// <summary>The date when the package is shipped.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Origin(Microsoft.Azure.PowerShell.Cmdlets.ImportExport.PropertyOrigin.Inlined)]
        public string DeliveryPackageShipDate { get => ((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IPackageInfomationInternal)DeliveryPackage).ShipDate; set => ((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IPackageInfomationInternal)DeliveryPackage).ShipDate = value; }

        /// <summary>The tracking number of the package.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Origin(Microsoft.Azure.PowerShell.Cmdlets.ImportExport.PropertyOrigin.Inlined)]
        public string DeliveryPackageTrackingNumber { get => ((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IPackageInfomationInternal)DeliveryPackage).TrackingNumber; set => ((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IPackageInfomationInternal)DeliveryPackage).TrackingNumber = value; }

        /// <summary>Backing field for <see cref="DriveList" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IDriveStatus[] _driveList;

        /// <summary>List of drives that comprise the job.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Origin(Microsoft.Azure.PowerShell.Cmdlets.ImportExport.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IDriveStatus[] DriveList { get => this._driveList; set => this._driveList = value; }

        /// <summary>Backing field for <see cref="LogLevel" /> property.</summary>
        private string _logLevel;

        /// <summary>Indicates whether error logging or verbose logging is enabled.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Origin(Microsoft.Azure.PowerShell.Cmdlets.ImportExport.PropertyOrigin.Owned)]
        public string LogLevel { get => this._logLevel; set => this._logLevel = value; }

        /// <summary>Internal Acessors for DeliveryPackage</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IPackageInfomation Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IUpdateJobParametersPropertiesInternal.DeliveryPackage { get => (this._deliveryPackage = this._deliveryPackage ?? new Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.PackageInfomation()); set { {_deliveryPackage = value;} } }

        /// <summary>Internal Acessors for ReturnAddress</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IReturnAddress Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IUpdateJobParametersPropertiesInternal.ReturnAddress { get => (this._returnAddress = this._returnAddress ?? new Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.ReturnAddress()); set { {_returnAddress = value;} } }

        /// <summary>Internal Acessors for ReturnShipping</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IReturnShipping Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IUpdateJobParametersPropertiesInternal.ReturnShipping { get => (this._returnShipping = this._returnShipping ?? new Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.ReturnShipping()); set { {_returnShipping = value;} } }

        /// <summary>Backing field for <see cref="ReturnAddress" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IReturnAddress _returnAddress;

        /// <summary>Specifies the return address information for the job.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Origin(Microsoft.Azure.PowerShell.Cmdlets.ImportExport.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IReturnAddress ReturnAddress { get => (this._returnAddress = this._returnAddress ?? new Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.ReturnAddress()); set => this._returnAddress = value; }

        /// <summary>The city name to use when returning the drives.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Origin(Microsoft.Azure.PowerShell.Cmdlets.ImportExport.PropertyOrigin.Inlined)]
        public string ReturnAddressCity { get => ((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IReturnAddressInternal)ReturnAddress).City; set => ((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IReturnAddressInternal)ReturnAddress).City = value; }

        /// <summary>The country or region to use when returning the drives.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Origin(Microsoft.Azure.PowerShell.Cmdlets.ImportExport.PropertyOrigin.Inlined)]
        public string ReturnAddressCountryOrRegion { get => ((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IReturnAddressInternal)ReturnAddress).CountryOrRegion; set => ((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IReturnAddressInternal)ReturnAddress).CountryOrRegion = value; }

        /// <summary>Email address of the recipient of the returned drives.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Origin(Microsoft.Azure.PowerShell.Cmdlets.ImportExport.PropertyOrigin.Inlined)]
        public string ReturnAddressEmail { get => ((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IReturnAddressInternal)ReturnAddress).Email; set => ((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IReturnAddressInternal)ReturnAddress).Email = value; }

        /// <summary>Phone number of the recipient of the returned drives.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Origin(Microsoft.Azure.PowerShell.Cmdlets.ImportExport.PropertyOrigin.Inlined)]
        public string ReturnAddressPhone { get => ((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IReturnAddressInternal)ReturnAddress).Phone; set => ((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IReturnAddressInternal)ReturnAddress).Phone = value; }

        /// <summary>The postal code to use when returning the drives.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Origin(Microsoft.Azure.PowerShell.Cmdlets.ImportExport.PropertyOrigin.Inlined)]
        public string ReturnAddressPostalCode { get => ((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IReturnAddressInternal)ReturnAddress).PostalCode; set => ((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IReturnAddressInternal)ReturnAddress).PostalCode = value; }

        /// <summary>
        /// The name of the recipient who will receive the hard drives when they are returned.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Origin(Microsoft.Azure.PowerShell.Cmdlets.ImportExport.PropertyOrigin.Inlined)]
        public string ReturnAddressRecipientName { get => ((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IReturnAddressInternal)ReturnAddress).RecipientName; set => ((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IReturnAddressInternal)ReturnAddress).RecipientName = value; }

        /// <summary>The state or province to use when returning the drives.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Origin(Microsoft.Azure.PowerShell.Cmdlets.ImportExport.PropertyOrigin.Inlined)]
        public string ReturnAddressStateOrProvince { get => ((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IReturnAddressInternal)ReturnAddress).StateOrProvince; set => ((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IReturnAddressInternal)ReturnAddress).StateOrProvince = value; }

        /// <summary>The first line of the street address to use when returning the drives.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Origin(Microsoft.Azure.PowerShell.Cmdlets.ImportExport.PropertyOrigin.Inlined)]
        public string ReturnAddressStreetAddress1 { get => ((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IReturnAddressInternal)ReturnAddress).StreetAddress1; set => ((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IReturnAddressInternal)ReturnAddress).StreetAddress1 = value; }

        /// <summary>The second line of the street address to use when returning the drives.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Origin(Microsoft.Azure.PowerShell.Cmdlets.ImportExport.PropertyOrigin.Inlined)]
        public string ReturnAddressStreetAddress2 { get => ((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IReturnAddressInternal)ReturnAddress).StreetAddress2; set => ((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IReturnAddressInternal)ReturnAddress).StreetAddress2 = value; }

        /// <summary>Backing field for <see cref="ReturnShipping" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IReturnShipping _returnShipping;

        /// <summary>Specifies the return carrier and customer's account with the carrier.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Origin(Microsoft.Azure.PowerShell.Cmdlets.ImportExport.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IReturnShipping ReturnShipping { get => (this._returnShipping = this._returnShipping ?? new Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.ReturnShipping()); set => this._returnShipping = value; }

        /// <summary>The customer's account number with the carrier.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Origin(Microsoft.Azure.PowerShell.Cmdlets.ImportExport.PropertyOrigin.Inlined)]
        public string ReturnShippingCarrierAccountNumber { get => ((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IReturnShippingInternal)ReturnShipping).CarrierAccountNumber; set => ((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IReturnShippingInternal)ReturnShipping).CarrierAccountNumber = value; }

        /// <summary>The carrier's name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Origin(Microsoft.Azure.PowerShell.Cmdlets.ImportExport.PropertyOrigin.Inlined)]
        public string ReturnShippingCarrierName { get => ((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IReturnShippingInternal)ReturnShipping).CarrierName; set => ((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IReturnShippingInternal)ReturnShipping).CarrierName = value; }

        /// <summary>Backing field for <see cref="State" /> property.</summary>
        private string _state;

        /// <summary>
        /// If specified, the value must be Shipping, which tells the Import/Export service that the package for the job has been
        /// shipped. The ReturnAddress and DeliveryPackage properties must have been set either in this request or in a previous request,
        /// otherwise the request will fail.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Origin(Microsoft.Azure.PowerShell.Cmdlets.ImportExport.PropertyOrigin.Owned)]
        public string State { get => this._state; set => this._state = value; }

        /// <summary>Creates an new <see cref="UpdateJobParametersProperties" /> instance.</summary>
        public UpdateJobParametersProperties()
        {

        }
    }
    /// Specifies the properties of a UpdateJob.
    public partial interface IUpdateJobParametersProperties :
        Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Runtime.IJsonSerializable
    {
        /// <summary>
        /// Indicates whether the manifest files on the drives should be copied to block blobs.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Indicates whether the manifest files on the drives should be copied to block blobs.",
        SerializedName = @"backupDriveManifest",
        PossibleTypes = new [] { typeof(bool) })]
        bool? BackupDriveManifest { get; set; }
        /// <summary>
        /// If specified, the value must be true. The service will attempt to cancel the job.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"If specified, the value must be true. The service will attempt to cancel the job. ",
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
        /// <summary>List of drives that comprise the job.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"List of drives that comprise the job.",
        SerializedName = @"driveList",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IDriveStatus) })]
        Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IDriveStatus[] DriveList { get; set; }
        /// <summary>Indicates whether error logging or verbose logging is enabled.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Indicates whether error logging or verbose logging is enabled.",
        SerializedName = @"logLevel",
        PossibleTypes = new [] { typeof(string) })]
        string LogLevel { get; set; }
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
        /// <summary>
        /// If specified, the value must be Shipping, which tells the Import/Export service that the package for the job has been
        /// shipped. The ReturnAddress and DeliveryPackage properties must have been set either in this request or in a previous request,
        /// otherwise the request will fail.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"If specified, the value must be Shipping, which tells the Import/Export service that the package for the job has been shipped. The ReturnAddress and DeliveryPackage properties must have been set either in this request or in a previous request, otherwise the request will fail. ",
        SerializedName = @"state",
        PossibleTypes = new [] { typeof(string) })]
        string State { get; set; }

    }
    /// Specifies the properties of a UpdateJob.
    internal partial interface IUpdateJobParametersPropertiesInternal

    {
        /// <summary>
        /// Indicates whether the manifest files on the drives should be copied to block blobs.
        /// </summary>
        bool? BackupDriveManifest { get; set; }
        /// <summary>
        /// If specified, the value must be true. The service will attempt to cancel the job.
        /// </summary>
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
        /// <summary>List of drives that comprise the job.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IDriveStatus[] DriveList { get; set; }
        /// <summary>Indicates whether error logging or verbose logging is enabled.</summary>
        string LogLevel { get; set; }
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
        /// <summary>Specifies the return carrier and customer's account with the carrier.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IReturnShipping ReturnShipping { get; set; }
        /// <summary>The customer's account number with the carrier.</summary>
        string ReturnShippingCarrierAccountNumber { get; set; }
        /// <summary>The carrier's name.</summary>
        string ReturnShippingCarrierName { get; set; }
        /// <summary>
        /// If specified, the value must be Shipping, which tells the Import/Export service that the package for the job has been
        /// shipped. The ReturnAddress and DeliveryPackage properties must have been set either in this request or in a previous request,
        /// otherwise the request will fail.
        /// </summary>
        string State { get; set; }

    }
}