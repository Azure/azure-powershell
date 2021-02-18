namespace Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101
{
    using Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Runtime.PowerShell;

    /// <summary>Specifies the job properties</summary>
    [System.ComponentModel.TypeConverter(typeof(JobDetailsTypeConverter))]
    public partial class JobDetails
    {

        /// <summary>
        /// <c>AfterDeserializeDictionary</c> will be called after the deserialization has finished, allowing customization of the
        /// object before it is returned. Implement this method in a partial class to enable this behavior
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>

        partial void AfterDeserializeDictionary(global::System.Collections.IDictionary content);

        /// <summary>
        /// <c>AfterDeserializePSObject</c> will be called after the deserialization has finished, allowing customization of the object
        /// before it is returned. Implement this method in a partial class to enable this behavior
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>

        partial void AfterDeserializePSObject(global::System.Management.Automation.PSObject content);

        /// <summary>
        /// <c>BeforeDeserializeDictionary</c> will be called before the deserialization has commenced, allowing complete customization
        /// of the object before it is deserialized.
        /// If you wish to disable the default deserialization entirely, return <c>true</c> in the <see "returnNow" /> output parameter.
        /// Implement this method in a partial class to enable this behavior.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        /// <param name="returnNow">Determines if the rest of the serialization should be processed, or if the method should return
        /// instantly.</param>

        partial void BeforeDeserializeDictionary(global::System.Collections.IDictionary content, ref bool returnNow);

        /// <summary>
        /// <c>BeforeDeserializePSObject</c> will be called before the deserialization has commenced, allowing complete customization
        /// of the object before it is deserialized.
        /// If you wish to disable the default deserialization entirely, return <c>true</c> in the <see "returnNow" /> output parameter.
        /// Implement this method in a partial class to enable this behavior.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        /// <param name="returnNow">Determines if the rest of the serialization should be processed, or if the method should return
        /// instantly.</param>

        partial void BeforeDeserializePSObject(global::System.Management.Automation.PSObject content, ref bool returnNow);

        /// <summary>
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.JobDetails"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IJobDetails" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IJobDetails DeserializeFromDictionary(global::System.Collections.IDictionary content)
        {
            return new JobDetails(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.JobDetails"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IJobDetails" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IJobDetails DeserializeFromPSObject(global::System.Management.Automation.PSObject content)
        {
            return new JobDetails(content);
        }

        /// <summary>
        /// Creates a new instance of <see cref="JobDetails" />, deserializing the content from a json string.
        /// </summary>
        /// <param name="jsonText">a string containing a JSON serialized instance of this model.</param>
        /// <returns>an instance of the <see cref="className" /> model class.</returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IJobDetails FromJsonString(string jsonText) => FromJson(Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Runtime.Json.JsonNode.Parse(jsonText));

        /// <summary>
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.JobDetails"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        internal JobDetails(global::System.Collections.IDictionary content)
        {
            bool returnNow = false;
            BeforeDeserializeDictionary(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IJobDetailsInternal)this).DeliveryPackage = (Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IPackageInfomation) content.GetValueForProperty("DeliveryPackage",((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IJobDetailsInternal)this).DeliveryPackage, Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.PackageInfomationTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IJobDetailsInternal)this).Export = (Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IExport) content.GetValueForProperty("Export",((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IJobDetailsInternal)this).Export, Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.ExportTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IJobDetailsInternal)this).ReturnAddress = (Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IReturnAddress) content.GetValueForProperty("ReturnAddress",((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IJobDetailsInternal)this).ReturnAddress, Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.ReturnAddressTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IJobDetailsInternal)this).ReturnPackage = (Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IPackageInfomation) content.GetValueForProperty("ReturnPackage",((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IJobDetailsInternal)this).ReturnPackage, Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.PackageInfomationTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IJobDetailsInternal)this).ReturnShipping = (Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IReturnShipping) content.GetValueForProperty("ReturnShipping",((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IJobDetailsInternal)this).ReturnShipping, Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.ReturnShippingTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IJobDetailsInternal)this).ShippingInformation = (Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IShippingInformation) content.GetValueForProperty("ShippingInformation",((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IJobDetailsInternal)this).ShippingInformation, Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.ShippingInformationTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IJobDetailsInternal)this).BackupDriveManifest = (bool?) content.GetValueForProperty("BackupDriveManifest",((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IJobDetailsInternal)this).BackupDriveManifest, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            ((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IJobDetailsInternal)this).CancelRequested = (bool?) content.GetValueForProperty("CancelRequested",((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IJobDetailsInternal)this).CancelRequested, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            ((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IJobDetailsInternal)this).DiagnosticsPath = (string) content.GetValueForProperty("DiagnosticsPath",((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IJobDetailsInternal)this).DiagnosticsPath, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IJobDetailsInternal)this).DriveList = (Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IDriveStatus[]) content.GetValueForProperty("DriveList",((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IJobDetailsInternal)this).DriveList, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IDriveStatus>(__y, Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.DriveStatusTypeConverter.ConvertFrom));
            ((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IJobDetailsInternal)this).IncompleteBlobListUri = (string) content.GetValueForProperty("IncompleteBlobListUri",((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IJobDetailsInternal)this).IncompleteBlobListUri, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IJobDetailsInternal)this).JobType = (string) content.GetValueForProperty("JobType",((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IJobDetailsInternal)this).JobType, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IJobDetailsInternal)this).LogLevel = (string) content.GetValueForProperty("LogLevel",((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IJobDetailsInternal)this).LogLevel, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IJobDetailsInternal)this).PercentComplete = (int?) content.GetValueForProperty("PercentComplete",((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IJobDetailsInternal)this).PercentComplete, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            ((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IJobDetailsInternal)this).ProvisioningState = (string) content.GetValueForProperty("ProvisioningState",((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IJobDetailsInternal)this).ProvisioningState, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IJobDetailsInternal)this).State = (string) content.GetValueForProperty("State",((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IJobDetailsInternal)this).State, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IJobDetailsInternal)this).StorageAccountId = (string) content.GetValueForProperty("StorageAccountId",((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IJobDetailsInternal)this).StorageAccountId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IJobDetailsInternal)this).ReturnAddressPostalCode = (string) content.GetValueForProperty("ReturnAddressPostalCode",((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IJobDetailsInternal)this).ReturnAddressPostalCode, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IJobDetailsInternal)this).ReturnAddressStreetAddress1 = (string) content.GetValueForProperty("ReturnAddressStreetAddress1",((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IJobDetailsInternal)this).ReturnAddressStreetAddress1, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IJobDetailsInternal)this).ShippingInformationStreetAddress1 = (string) content.GetValueForProperty("ShippingInformationStreetAddress1",((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IJobDetailsInternal)this).ShippingInformationStreetAddress1, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IJobDetailsInternal)this).ReturnAddressCity = (string) content.GetValueForProperty("ReturnAddressCity",((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IJobDetailsInternal)this).ReturnAddressCity, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IJobDetailsInternal)this).ReturnAddressEmail = (string) content.GetValueForProperty("ReturnAddressEmail",((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IJobDetailsInternal)this).ReturnAddressEmail, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IJobDetailsInternal)this).ReturnAddressPhone = (string) content.GetValueForProperty("ReturnAddressPhone",((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IJobDetailsInternal)this).ReturnAddressPhone, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IJobDetailsInternal)this).ExportBlobList = (Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IExportBlobList) content.GetValueForProperty("ExportBlobList",((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IJobDetailsInternal)this).ExportBlobList, Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.ExportBlobListTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IJobDetailsInternal)this).ReturnAddressRecipientName = (string) content.GetValueForProperty("ReturnAddressRecipientName",((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IJobDetailsInternal)this).ReturnAddressRecipientName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IJobDetailsInternal)this).ReturnShippingCarrierName = (string) content.GetValueForProperty("ReturnShippingCarrierName",((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IJobDetailsInternal)this).ReturnShippingCarrierName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IJobDetailsInternal)this).ShippingInformationCity = (string) content.GetValueForProperty("ShippingInformationCity",((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IJobDetailsInternal)this).ShippingInformationCity, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IJobDetailsInternal)this).ShippingInformationPhone = (string) content.GetValueForProperty("ShippingInformationPhone",((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IJobDetailsInternal)this).ShippingInformationPhone, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IJobDetailsInternal)this).ShippingInformationPostalCode = (string) content.GetValueForProperty("ShippingInformationPostalCode",((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IJobDetailsInternal)this).ShippingInformationPostalCode, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IJobDetailsInternal)this).ShippingInformationRecipientName = (string) content.GetValueForProperty("ShippingInformationRecipientName",((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IJobDetailsInternal)this).ShippingInformationRecipientName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IJobDetailsInternal)this).DeliveryPackageShipDate = (string) content.GetValueForProperty("DeliveryPackageShipDate",((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IJobDetailsInternal)this).DeliveryPackageShipDate, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IJobDetailsInternal)this).ReturnAddressStateOrProvince = (string) content.GetValueForProperty("ReturnAddressStateOrProvince",((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IJobDetailsInternal)this).ReturnAddressStateOrProvince, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IJobDetailsInternal)this).DeliveryPackageDriveCount = (int) content.GetValueForProperty("DeliveryPackageDriveCount",((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IJobDetailsInternal)this).DeliveryPackageDriveCount, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            ((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IJobDetailsInternal)this).ReturnAddressStreetAddress2 = (string) content.GetValueForProperty("ReturnAddressStreetAddress2",((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IJobDetailsInternal)this).ReturnAddressStreetAddress2, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IJobDetailsInternal)this).ReturnPackageCarrierName = (string) content.GetValueForProperty("ReturnPackageCarrierName",((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IJobDetailsInternal)this).ReturnPackageCarrierName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IJobDetailsInternal)this).ReturnPackageDriveCount = (int) content.GetValueForProperty("ReturnPackageDriveCount",((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IJobDetailsInternal)this).ReturnPackageDriveCount, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            ((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IJobDetailsInternal)this).ReturnPackageShipDate = (string) content.GetValueForProperty("ReturnPackageShipDate",((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IJobDetailsInternal)this).ReturnPackageShipDate, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IJobDetailsInternal)this).ReturnPackageTrackingNumber = (string) content.GetValueForProperty("ReturnPackageTrackingNumber",((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IJobDetailsInternal)this).ReturnPackageTrackingNumber, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IJobDetailsInternal)this).ReturnShippingCarrierAccountNumber = (string) content.GetValueForProperty("ReturnShippingCarrierAccountNumber",((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IJobDetailsInternal)this).ReturnShippingCarrierAccountNumber, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IJobDetailsInternal)this).DeliveryPackageTrackingNumber = (string) content.GetValueForProperty("DeliveryPackageTrackingNumber",((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IJobDetailsInternal)this).DeliveryPackageTrackingNumber, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IJobDetailsInternal)this).ReturnAddressCountryOrRegion = (string) content.GetValueForProperty("ReturnAddressCountryOrRegion",((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IJobDetailsInternal)this).ReturnAddressCountryOrRegion, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IJobDetailsInternal)this).ShippingInformationCountryOrRegion = (string) content.GetValueForProperty("ShippingInformationCountryOrRegion",((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IJobDetailsInternal)this).ShippingInformationCountryOrRegion, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IJobDetailsInternal)this).DeliveryPackageCarrierName = (string) content.GetValueForProperty("DeliveryPackageCarrierName",((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IJobDetailsInternal)this).DeliveryPackageCarrierName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IJobDetailsInternal)this).ExportBlobListblobPath = (string) content.GetValueForProperty("ExportBlobListblobPath",((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IJobDetailsInternal)this).ExportBlobListblobPath, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IJobDetailsInternal)this).BlobListBlobPath = (string[]) content.GetValueForProperty("BlobListBlobPath",((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IJobDetailsInternal)this).BlobListBlobPath, __y => TypeConverterExtensions.SelectToArray<string>(__y, global::System.Convert.ToString));
            ((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IJobDetailsInternal)this).ShippingInformationStateOrProvince = (string) content.GetValueForProperty("ShippingInformationStateOrProvince",((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IJobDetailsInternal)this).ShippingInformationStateOrProvince, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IJobDetailsInternal)this).ShippingInformationStreetAddress2 = (string) content.GetValueForProperty("ShippingInformationStreetAddress2",((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IJobDetailsInternal)this).ShippingInformationStreetAddress2, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IJobDetailsInternal)this).BlobListBlobPathPrefix = (string[]) content.GetValueForProperty("BlobListBlobPathPrefix",((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IJobDetailsInternal)this).BlobListBlobPathPrefix, __y => TypeConverterExtensions.SelectToArray<string>(__y, global::System.Convert.ToString));
            AfterDeserializeDictionary(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.JobDetails"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        internal JobDetails(global::System.Management.Automation.PSObject content)
        {
            bool returnNow = false;
            BeforeDeserializePSObject(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IJobDetailsInternal)this).DeliveryPackage = (Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IPackageInfomation) content.GetValueForProperty("DeliveryPackage",((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IJobDetailsInternal)this).DeliveryPackage, Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.PackageInfomationTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IJobDetailsInternal)this).Export = (Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IExport) content.GetValueForProperty("Export",((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IJobDetailsInternal)this).Export, Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.ExportTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IJobDetailsInternal)this).ReturnAddress = (Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IReturnAddress) content.GetValueForProperty("ReturnAddress",((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IJobDetailsInternal)this).ReturnAddress, Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.ReturnAddressTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IJobDetailsInternal)this).ReturnPackage = (Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IPackageInfomation) content.GetValueForProperty("ReturnPackage",((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IJobDetailsInternal)this).ReturnPackage, Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.PackageInfomationTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IJobDetailsInternal)this).ReturnShipping = (Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IReturnShipping) content.GetValueForProperty("ReturnShipping",((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IJobDetailsInternal)this).ReturnShipping, Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.ReturnShippingTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IJobDetailsInternal)this).ShippingInformation = (Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IShippingInformation) content.GetValueForProperty("ShippingInformation",((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IJobDetailsInternal)this).ShippingInformation, Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.ShippingInformationTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IJobDetailsInternal)this).BackupDriveManifest = (bool?) content.GetValueForProperty("BackupDriveManifest",((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IJobDetailsInternal)this).BackupDriveManifest, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            ((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IJobDetailsInternal)this).CancelRequested = (bool?) content.GetValueForProperty("CancelRequested",((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IJobDetailsInternal)this).CancelRequested, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            ((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IJobDetailsInternal)this).DiagnosticsPath = (string) content.GetValueForProperty("DiagnosticsPath",((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IJobDetailsInternal)this).DiagnosticsPath, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IJobDetailsInternal)this).DriveList = (Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IDriveStatus[]) content.GetValueForProperty("DriveList",((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IJobDetailsInternal)this).DriveList, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IDriveStatus>(__y, Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.DriveStatusTypeConverter.ConvertFrom));
            ((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IJobDetailsInternal)this).IncompleteBlobListUri = (string) content.GetValueForProperty("IncompleteBlobListUri",((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IJobDetailsInternal)this).IncompleteBlobListUri, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IJobDetailsInternal)this).JobType = (string) content.GetValueForProperty("JobType",((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IJobDetailsInternal)this).JobType, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IJobDetailsInternal)this).LogLevel = (string) content.GetValueForProperty("LogLevel",((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IJobDetailsInternal)this).LogLevel, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IJobDetailsInternal)this).PercentComplete = (int?) content.GetValueForProperty("PercentComplete",((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IJobDetailsInternal)this).PercentComplete, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            ((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IJobDetailsInternal)this).ProvisioningState = (string) content.GetValueForProperty("ProvisioningState",((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IJobDetailsInternal)this).ProvisioningState, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IJobDetailsInternal)this).State = (string) content.GetValueForProperty("State",((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IJobDetailsInternal)this).State, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IJobDetailsInternal)this).StorageAccountId = (string) content.GetValueForProperty("StorageAccountId",((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IJobDetailsInternal)this).StorageAccountId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IJobDetailsInternal)this).ReturnAddressPostalCode = (string) content.GetValueForProperty("ReturnAddressPostalCode",((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IJobDetailsInternal)this).ReturnAddressPostalCode, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IJobDetailsInternal)this).ReturnAddressStreetAddress1 = (string) content.GetValueForProperty("ReturnAddressStreetAddress1",((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IJobDetailsInternal)this).ReturnAddressStreetAddress1, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IJobDetailsInternal)this).ShippingInformationStreetAddress1 = (string) content.GetValueForProperty("ShippingInformationStreetAddress1",((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IJobDetailsInternal)this).ShippingInformationStreetAddress1, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IJobDetailsInternal)this).ReturnAddressCity = (string) content.GetValueForProperty("ReturnAddressCity",((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IJobDetailsInternal)this).ReturnAddressCity, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IJobDetailsInternal)this).ReturnAddressEmail = (string) content.GetValueForProperty("ReturnAddressEmail",((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IJobDetailsInternal)this).ReturnAddressEmail, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IJobDetailsInternal)this).ReturnAddressPhone = (string) content.GetValueForProperty("ReturnAddressPhone",((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IJobDetailsInternal)this).ReturnAddressPhone, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IJobDetailsInternal)this).ExportBlobList = (Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IExportBlobList) content.GetValueForProperty("ExportBlobList",((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IJobDetailsInternal)this).ExportBlobList, Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.ExportBlobListTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IJobDetailsInternal)this).ReturnAddressRecipientName = (string) content.GetValueForProperty("ReturnAddressRecipientName",((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IJobDetailsInternal)this).ReturnAddressRecipientName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IJobDetailsInternal)this).ReturnShippingCarrierName = (string) content.GetValueForProperty("ReturnShippingCarrierName",((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IJobDetailsInternal)this).ReturnShippingCarrierName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IJobDetailsInternal)this).ShippingInformationCity = (string) content.GetValueForProperty("ShippingInformationCity",((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IJobDetailsInternal)this).ShippingInformationCity, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IJobDetailsInternal)this).ShippingInformationPhone = (string) content.GetValueForProperty("ShippingInformationPhone",((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IJobDetailsInternal)this).ShippingInformationPhone, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IJobDetailsInternal)this).ShippingInformationPostalCode = (string) content.GetValueForProperty("ShippingInformationPostalCode",((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IJobDetailsInternal)this).ShippingInformationPostalCode, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IJobDetailsInternal)this).ShippingInformationRecipientName = (string) content.GetValueForProperty("ShippingInformationRecipientName",((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IJobDetailsInternal)this).ShippingInformationRecipientName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IJobDetailsInternal)this).DeliveryPackageShipDate = (string) content.GetValueForProperty("DeliveryPackageShipDate",((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IJobDetailsInternal)this).DeliveryPackageShipDate, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IJobDetailsInternal)this).ReturnAddressStateOrProvince = (string) content.GetValueForProperty("ReturnAddressStateOrProvince",((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IJobDetailsInternal)this).ReturnAddressStateOrProvince, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IJobDetailsInternal)this).DeliveryPackageDriveCount = (int) content.GetValueForProperty("DeliveryPackageDriveCount",((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IJobDetailsInternal)this).DeliveryPackageDriveCount, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            ((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IJobDetailsInternal)this).ReturnAddressStreetAddress2 = (string) content.GetValueForProperty("ReturnAddressStreetAddress2",((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IJobDetailsInternal)this).ReturnAddressStreetAddress2, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IJobDetailsInternal)this).ReturnPackageCarrierName = (string) content.GetValueForProperty("ReturnPackageCarrierName",((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IJobDetailsInternal)this).ReturnPackageCarrierName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IJobDetailsInternal)this).ReturnPackageDriveCount = (int) content.GetValueForProperty("ReturnPackageDriveCount",((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IJobDetailsInternal)this).ReturnPackageDriveCount, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            ((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IJobDetailsInternal)this).ReturnPackageShipDate = (string) content.GetValueForProperty("ReturnPackageShipDate",((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IJobDetailsInternal)this).ReturnPackageShipDate, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IJobDetailsInternal)this).ReturnPackageTrackingNumber = (string) content.GetValueForProperty("ReturnPackageTrackingNumber",((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IJobDetailsInternal)this).ReturnPackageTrackingNumber, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IJobDetailsInternal)this).ReturnShippingCarrierAccountNumber = (string) content.GetValueForProperty("ReturnShippingCarrierAccountNumber",((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IJobDetailsInternal)this).ReturnShippingCarrierAccountNumber, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IJobDetailsInternal)this).DeliveryPackageTrackingNumber = (string) content.GetValueForProperty("DeliveryPackageTrackingNumber",((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IJobDetailsInternal)this).DeliveryPackageTrackingNumber, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IJobDetailsInternal)this).ReturnAddressCountryOrRegion = (string) content.GetValueForProperty("ReturnAddressCountryOrRegion",((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IJobDetailsInternal)this).ReturnAddressCountryOrRegion, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IJobDetailsInternal)this).ShippingInformationCountryOrRegion = (string) content.GetValueForProperty("ShippingInformationCountryOrRegion",((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IJobDetailsInternal)this).ShippingInformationCountryOrRegion, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IJobDetailsInternal)this).DeliveryPackageCarrierName = (string) content.GetValueForProperty("DeliveryPackageCarrierName",((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IJobDetailsInternal)this).DeliveryPackageCarrierName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IJobDetailsInternal)this).ExportBlobListblobPath = (string) content.GetValueForProperty("ExportBlobListblobPath",((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IJobDetailsInternal)this).ExportBlobListblobPath, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IJobDetailsInternal)this).BlobListBlobPath = (string[]) content.GetValueForProperty("BlobListBlobPath",((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IJobDetailsInternal)this).BlobListBlobPath, __y => TypeConverterExtensions.SelectToArray<string>(__y, global::System.Convert.ToString));
            ((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IJobDetailsInternal)this).ShippingInformationStateOrProvince = (string) content.GetValueForProperty("ShippingInformationStateOrProvince",((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IJobDetailsInternal)this).ShippingInformationStateOrProvince, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IJobDetailsInternal)this).ShippingInformationStreetAddress2 = (string) content.GetValueForProperty("ShippingInformationStreetAddress2",((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IJobDetailsInternal)this).ShippingInformationStreetAddress2, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IJobDetailsInternal)this).BlobListBlobPathPrefix = (string[]) content.GetValueForProperty("BlobListBlobPathPrefix",((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IJobDetailsInternal)this).BlobListBlobPathPrefix, __y => TypeConverterExtensions.SelectToArray<string>(__y, global::System.Convert.ToString));
            AfterDeserializePSObject(content);
        }

        /// <summary>Serializes this instance to a json string.</summary>

        /// <returns>a <see cref="System.String" /> containing this model serialized to JSON text.</returns>
        public string ToJsonString() => ToJson(null, Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Runtime.SerializationMode.IncludeAll)?.ToString();
    }
    /// Specifies the job properties
    [System.ComponentModel.TypeConverter(typeof(JobDetailsTypeConverter))]
    public partial interface IJobDetails

    {

    }
}