namespace Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101
{
    using Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Runtime.PowerShell;

    /// <summary>Specifies the properties of a UpdateJob.</summary>
    [System.ComponentModel.TypeConverter(typeof(UpdateJobParametersPropertiesTypeConverter))]
    public partial class UpdateJobParametersProperties
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
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.UpdateJobParametersProperties"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IUpdateJobParametersProperties"
        /// />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IUpdateJobParametersProperties DeserializeFromDictionary(global::System.Collections.IDictionary content)
        {
            return new UpdateJobParametersProperties(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.UpdateJobParametersProperties"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IUpdateJobParametersProperties"
        /// />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IUpdateJobParametersProperties DeserializeFromPSObject(global::System.Management.Automation.PSObject content)
        {
            return new UpdateJobParametersProperties(content);
        }

        /// <summary>
        /// Creates a new instance of <see cref="UpdateJobParametersProperties" />, deserializing the content from a json string.
        /// </summary>
        /// <param name="jsonText">a string containing a JSON serialized instance of this model.</param>
        /// <returns>an instance of the <see cref="className" /> model class.</returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IUpdateJobParametersProperties FromJsonString(string jsonText) => FromJson(Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Runtime.Json.JsonNode.Parse(jsonText));

        /// <summary>Serializes this instance to a json string.</summary>

        /// <returns>a <see cref="System.String" /> containing this model serialized to JSON text.</returns>
        public string ToJsonString() => ToJson(null, Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Runtime.SerializationMode.IncludeAll)?.ToString();

        /// <summary>
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.UpdateJobParametersProperties"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        internal UpdateJobParametersProperties(global::System.Collections.IDictionary content)
        {
            bool returnNow = false;
            BeforeDeserializeDictionary(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IUpdateJobParametersPropertiesInternal)this).DeliveryPackage = (Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IPackageInfomation) content.GetValueForProperty("DeliveryPackage",((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IUpdateJobParametersPropertiesInternal)this).DeliveryPackage, Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.PackageInfomationTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IUpdateJobParametersPropertiesInternal)this).ReturnAddress = (Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IReturnAddress) content.GetValueForProperty("ReturnAddress",((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IUpdateJobParametersPropertiesInternal)this).ReturnAddress, Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.ReturnAddressTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IUpdateJobParametersPropertiesInternal)this).ReturnShipping = (Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IReturnShipping) content.GetValueForProperty("ReturnShipping",((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IUpdateJobParametersPropertiesInternal)this).ReturnShipping, Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.ReturnShippingTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IUpdateJobParametersPropertiesInternal)this).BackupDriveManifest = (bool?) content.GetValueForProperty("BackupDriveManifest",((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IUpdateJobParametersPropertiesInternal)this).BackupDriveManifest, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            ((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IUpdateJobParametersPropertiesInternal)this).CancelRequested = (bool?) content.GetValueForProperty("CancelRequested",((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IUpdateJobParametersPropertiesInternal)this).CancelRequested, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            ((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IUpdateJobParametersPropertiesInternal)this).DriveList = (Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IDriveStatus[]) content.GetValueForProperty("DriveList",((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IUpdateJobParametersPropertiesInternal)this).DriveList, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IDriveStatus>(__y, Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.DriveStatusTypeConverter.ConvertFrom));
            ((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IUpdateJobParametersPropertiesInternal)this).LogLevel = (string) content.GetValueForProperty("LogLevel",((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IUpdateJobParametersPropertiesInternal)this).LogLevel, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IUpdateJobParametersPropertiesInternal)this).State = (string) content.GetValueForProperty("State",((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IUpdateJobParametersPropertiesInternal)this).State, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IUpdateJobParametersPropertiesInternal)this).ReturnAddressPhone = (string) content.GetValueForProperty("ReturnAddressPhone",((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IUpdateJobParametersPropertiesInternal)this).ReturnAddressPhone, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IUpdateJobParametersPropertiesInternal)this).ReturnShippingCarrierName = (string) content.GetValueForProperty("ReturnShippingCarrierName",((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IUpdateJobParametersPropertiesInternal)this).ReturnShippingCarrierName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IUpdateJobParametersPropertiesInternal)this).ReturnAddressStreetAddress1 = (string) content.GetValueForProperty("ReturnAddressStreetAddress1",((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IUpdateJobParametersPropertiesInternal)this).ReturnAddressStreetAddress1, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IUpdateJobParametersPropertiesInternal)this).ReturnAddressRecipientName = (string) content.GetValueForProperty("ReturnAddressRecipientName",((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IUpdateJobParametersPropertiesInternal)this).ReturnAddressRecipientName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IUpdateJobParametersPropertiesInternal)this).ReturnAddressCity = (string) content.GetValueForProperty("ReturnAddressCity",((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IUpdateJobParametersPropertiesInternal)this).ReturnAddressCity, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IUpdateJobParametersPropertiesInternal)this).ReturnAddressPostalCode = (string) content.GetValueForProperty("ReturnAddressPostalCode",((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IUpdateJobParametersPropertiesInternal)this).ReturnAddressPostalCode, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IUpdateJobParametersPropertiesInternal)this).ReturnAddressEmail = (string) content.GetValueForProperty("ReturnAddressEmail",((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IUpdateJobParametersPropertiesInternal)this).ReturnAddressEmail, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IUpdateJobParametersPropertiesInternal)this).DeliveryPackageDriveCount = (int) content.GetValueForProperty("DeliveryPackageDriveCount",((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IUpdateJobParametersPropertiesInternal)this).DeliveryPackageDriveCount, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            ((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IUpdateJobParametersPropertiesInternal)this).ReturnAddressCountryOrRegion = (string) content.GetValueForProperty("ReturnAddressCountryOrRegion",((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IUpdateJobParametersPropertiesInternal)this).ReturnAddressCountryOrRegion, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IUpdateJobParametersPropertiesInternal)this).DeliveryPackageTrackingNumber = (string) content.GetValueForProperty("DeliveryPackageTrackingNumber",((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IUpdateJobParametersPropertiesInternal)this).DeliveryPackageTrackingNumber, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IUpdateJobParametersPropertiesInternal)this).ReturnAddressStateOrProvince = (string) content.GetValueForProperty("ReturnAddressStateOrProvince",((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IUpdateJobParametersPropertiesInternal)this).ReturnAddressStateOrProvince, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IUpdateJobParametersPropertiesInternal)this).DeliveryPackageShipDate = (string) content.GetValueForProperty("DeliveryPackageShipDate",((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IUpdateJobParametersPropertiesInternal)this).DeliveryPackageShipDate, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IUpdateJobParametersPropertiesInternal)this).ReturnAddressStreetAddress2 = (string) content.GetValueForProperty("ReturnAddressStreetAddress2",((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IUpdateJobParametersPropertiesInternal)this).ReturnAddressStreetAddress2, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IUpdateJobParametersPropertiesInternal)this).ReturnShippingCarrierAccountNumber = (string) content.GetValueForProperty("ReturnShippingCarrierAccountNumber",((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IUpdateJobParametersPropertiesInternal)this).ReturnShippingCarrierAccountNumber, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IUpdateJobParametersPropertiesInternal)this).DeliveryPackageCarrierName = (string) content.GetValueForProperty("DeliveryPackageCarrierName",((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IUpdateJobParametersPropertiesInternal)this).DeliveryPackageCarrierName, global::System.Convert.ToString);
            AfterDeserializeDictionary(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.UpdateJobParametersProperties"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        internal UpdateJobParametersProperties(global::System.Management.Automation.PSObject content)
        {
            bool returnNow = false;
            BeforeDeserializePSObject(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IUpdateJobParametersPropertiesInternal)this).DeliveryPackage = (Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IPackageInfomation) content.GetValueForProperty("DeliveryPackage",((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IUpdateJobParametersPropertiesInternal)this).DeliveryPackage, Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.PackageInfomationTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IUpdateJobParametersPropertiesInternal)this).ReturnAddress = (Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IReturnAddress) content.GetValueForProperty("ReturnAddress",((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IUpdateJobParametersPropertiesInternal)this).ReturnAddress, Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.ReturnAddressTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IUpdateJobParametersPropertiesInternal)this).ReturnShipping = (Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IReturnShipping) content.GetValueForProperty("ReturnShipping",((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IUpdateJobParametersPropertiesInternal)this).ReturnShipping, Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.ReturnShippingTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IUpdateJobParametersPropertiesInternal)this).BackupDriveManifest = (bool?) content.GetValueForProperty("BackupDriveManifest",((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IUpdateJobParametersPropertiesInternal)this).BackupDriveManifest, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            ((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IUpdateJobParametersPropertiesInternal)this).CancelRequested = (bool?) content.GetValueForProperty("CancelRequested",((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IUpdateJobParametersPropertiesInternal)this).CancelRequested, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            ((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IUpdateJobParametersPropertiesInternal)this).DriveList = (Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IDriveStatus[]) content.GetValueForProperty("DriveList",((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IUpdateJobParametersPropertiesInternal)this).DriveList, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IDriveStatus>(__y, Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.DriveStatusTypeConverter.ConvertFrom));
            ((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IUpdateJobParametersPropertiesInternal)this).LogLevel = (string) content.GetValueForProperty("LogLevel",((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IUpdateJobParametersPropertiesInternal)this).LogLevel, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IUpdateJobParametersPropertiesInternal)this).State = (string) content.GetValueForProperty("State",((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IUpdateJobParametersPropertiesInternal)this).State, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IUpdateJobParametersPropertiesInternal)this).ReturnAddressPhone = (string) content.GetValueForProperty("ReturnAddressPhone",((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IUpdateJobParametersPropertiesInternal)this).ReturnAddressPhone, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IUpdateJobParametersPropertiesInternal)this).ReturnShippingCarrierName = (string) content.GetValueForProperty("ReturnShippingCarrierName",((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IUpdateJobParametersPropertiesInternal)this).ReturnShippingCarrierName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IUpdateJobParametersPropertiesInternal)this).ReturnAddressStreetAddress1 = (string) content.GetValueForProperty("ReturnAddressStreetAddress1",((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IUpdateJobParametersPropertiesInternal)this).ReturnAddressStreetAddress1, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IUpdateJobParametersPropertiesInternal)this).ReturnAddressRecipientName = (string) content.GetValueForProperty("ReturnAddressRecipientName",((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IUpdateJobParametersPropertiesInternal)this).ReturnAddressRecipientName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IUpdateJobParametersPropertiesInternal)this).ReturnAddressCity = (string) content.GetValueForProperty("ReturnAddressCity",((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IUpdateJobParametersPropertiesInternal)this).ReturnAddressCity, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IUpdateJobParametersPropertiesInternal)this).ReturnAddressPostalCode = (string) content.GetValueForProperty("ReturnAddressPostalCode",((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IUpdateJobParametersPropertiesInternal)this).ReturnAddressPostalCode, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IUpdateJobParametersPropertiesInternal)this).ReturnAddressEmail = (string) content.GetValueForProperty("ReturnAddressEmail",((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IUpdateJobParametersPropertiesInternal)this).ReturnAddressEmail, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IUpdateJobParametersPropertiesInternal)this).DeliveryPackageDriveCount = (int) content.GetValueForProperty("DeliveryPackageDriveCount",((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IUpdateJobParametersPropertiesInternal)this).DeliveryPackageDriveCount, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            ((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IUpdateJobParametersPropertiesInternal)this).ReturnAddressCountryOrRegion = (string) content.GetValueForProperty("ReturnAddressCountryOrRegion",((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IUpdateJobParametersPropertiesInternal)this).ReturnAddressCountryOrRegion, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IUpdateJobParametersPropertiesInternal)this).DeliveryPackageTrackingNumber = (string) content.GetValueForProperty("DeliveryPackageTrackingNumber",((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IUpdateJobParametersPropertiesInternal)this).DeliveryPackageTrackingNumber, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IUpdateJobParametersPropertiesInternal)this).ReturnAddressStateOrProvince = (string) content.GetValueForProperty("ReturnAddressStateOrProvince",((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IUpdateJobParametersPropertiesInternal)this).ReturnAddressStateOrProvince, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IUpdateJobParametersPropertiesInternal)this).DeliveryPackageShipDate = (string) content.GetValueForProperty("DeliveryPackageShipDate",((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IUpdateJobParametersPropertiesInternal)this).DeliveryPackageShipDate, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IUpdateJobParametersPropertiesInternal)this).ReturnAddressStreetAddress2 = (string) content.GetValueForProperty("ReturnAddressStreetAddress2",((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IUpdateJobParametersPropertiesInternal)this).ReturnAddressStreetAddress2, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IUpdateJobParametersPropertiesInternal)this).ReturnShippingCarrierAccountNumber = (string) content.GetValueForProperty("ReturnShippingCarrierAccountNumber",((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IUpdateJobParametersPropertiesInternal)this).ReturnShippingCarrierAccountNumber, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IUpdateJobParametersPropertiesInternal)this).DeliveryPackageCarrierName = (string) content.GetValueForProperty("DeliveryPackageCarrierName",((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IUpdateJobParametersPropertiesInternal)this).DeliveryPackageCarrierName, global::System.Convert.ToString);
            AfterDeserializePSObject(content);
        }
    }
    /// Specifies the properties of a UpdateJob.
    [System.ComponentModel.TypeConverter(typeof(UpdateJobParametersPropertiesTypeConverter))]
    public partial interface IUpdateJobParametersProperties

    {

    }
}