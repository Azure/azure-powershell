namespace Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101
{
    using Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Runtime.PowerShell;

    /// <summary>Update Job parameters</summary>
    [System.ComponentModel.TypeConverter(typeof(UpdateJobParametersTypeConverter))]
    public partial class UpdateJobParameters
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
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.UpdateJobParameters"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IUpdateJobParameters" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IUpdateJobParameters DeserializeFromDictionary(global::System.Collections.IDictionary content)
        {
            return new UpdateJobParameters(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.UpdateJobParameters"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IUpdateJobParameters" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IUpdateJobParameters DeserializeFromPSObject(global::System.Management.Automation.PSObject content)
        {
            return new UpdateJobParameters(content);
        }

        /// <summary>
        /// Creates a new instance of <see cref="UpdateJobParameters" />, deserializing the content from a json string.
        /// </summary>
        /// <param name="jsonText">a string containing a JSON serialized instance of this model.</param>
        /// <returns>an instance of the <see cref="className" /> model class.</returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IUpdateJobParameters FromJsonString(string jsonText) => FromJson(Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Runtime.Json.JsonNode.Parse(jsonText));

        /// <summary>Serializes this instance to a json string.</summary>

        /// <returns>a <see cref="System.String" /> containing this model serialized to JSON text.</returns>
        public string ToJsonString() => ToJson(null, Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Runtime.SerializationMode.IncludeAll)?.ToString();

        /// <summary>
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.UpdateJobParameters"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        internal UpdateJobParameters(global::System.Collections.IDictionary content)
        {
            bool returnNow = false;
            BeforeDeserializeDictionary(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IUpdateJobParametersInternal)this).Property = (Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IUpdateJobParametersProperties) content.GetValueForProperty("Property",((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IUpdateJobParametersInternal)this).Property, Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.UpdateJobParametersPropertiesTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IUpdateJobParametersInternal)this).Tag = (Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IUpdateJobParametersTags) content.GetValueForProperty("Tag",((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IUpdateJobParametersInternal)this).Tag, Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.UpdateJobParametersTagsTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IUpdateJobParametersInternal)this).ReturnShipping = (Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IReturnShipping) content.GetValueForProperty("ReturnShipping",((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IUpdateJobParametersInternal)this).ReturnShipping, Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.ReturnShippingTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IUpdateJobParametersInternal)this).ReturnAddress = (Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IReturnAddress) content.GetValueForProperty("ReturnAddress",((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IUpdateJobParametersInternal)this).ReturnAddress, Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.ReturnAddressTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IUpdateJobParametersInternal)this).ReturnAddressRecipientName = (string) content.GetValueForProperty("ReturnAddressRecipientName",((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IUpdateJobParametersInternal)this).ReturnAddressRecipientName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IUpdateJobParametersInternal)this).BackupDriveManifest = (bool?) content.GetValueForProperty("BackupDriveManifest",((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IUpdateJobParametersInternal)this).BackupDriveManifest, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            ((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IUpdateJobParametersInternal)this).CancelRequested = (bool?) content.GetValueForProperty("CancelRequested",((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IUpdateJobParametersInternal)this).CancelRequested, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            ((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IUpdateJobParametersInternal)this).DriveList = (Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IDriveStatus[]) content.GetValueForProperty("DriveList",((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IUpdateJobParametersInternal)this).DriveList, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IDriveStatus>(__y, Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.DriveStatusTypeConverter.ConvertFrom));
            ((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IUpdateJobParametersInternal)this).LogLevel = (string) content.GetValueForProperty("LogLevel",((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IUpdateJobParametersInternal)this).LogLevel, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IUpdateJobParametersInternal)this).State = (string) content.GetValueForProperty("State",((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IUpdateJobParametersInternal)this).State, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IUpdateJobParametersInternal)this).ReturnAddressPhone = (string) content.GetValueForProperty("ReturnAddressPhone",((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IUpdateJobParametersInternal)this).ReturnAddressPhone, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IUpdateJobParametersInternal)this).ReturnShippingCarrierName = (string) content.GetValueForProperty("ReturnShippingCarrierName",((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IUpdateJobParametersInternal)this).ReturnShippingCarrierName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IUpdateJobParametersInternal)this).ReturnAddressStreetAddress1 = (string) content.GetValueForProperty("ReturnAddressStreetAddress1",((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IUpdateJobParametersInternal)this).ReturnAddressStreetAddress1, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IUpdateJobParametersInternal)this).DeliveryPackage = (Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IPackageInfomation) content.GetValueForProperty("DeliveryPackage",((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IUpdateJobParametersInternal)this).DeliveryPackage, Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.PackageInfomationTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IUpdateJobParametersInternal)this).ReturnAddressCity = (string) content.GetValueForProperty("ReturnAddressCity",((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IUpdateJobParametersInternal)this).ReturnAddressCity, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IUpdateJobParametersInternal)this).ReturnAddressPostalCode = (string) content.GetValueForProperty("ReturnAddressPostalCode",((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IUpdateJobParametersInternal)this).ReturnAddressPostalCode, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IUpdateJobParametersInternal)this).ReturnAddressEmail = (string) content.GetValueForProperty("ReturnAddressEmail",((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IUpdateJobParametersInternal)this).ReturnAddressEmail, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IUpdateJobParametersInternal)this).DeliveryPackageDriveCount = (int) content.GetValueForProperty("DeliveryPackageDriveCount",((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IUpdateJobParametersInternal)this).DeliveryPackageDriveCount, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            ((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IUpdateJobParametersInternal)this).ReturnAddressCountryOrRegion = (string) content.GetValueForProperty("ReturnAddressCountryOrRegion",((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IUpdateJobParametersInternal)this).ReturnAddressCountryOrRegion, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IUpdateJobParametersInternal)this).DeliveryPackageTrackingNumber = (string) content.GetValueForProperty("DeliveryPackageTrackingNumber",((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IUpdateJobParametersInternal)this).DeliveryPackageTrackingNumber, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IUpdateJobParametersInternal)this).ReturnAddressStateOrProvince = (string) content.GetValueForProperty("ReturnAddressStateOrProvince",((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IUpdateJobParametersInternal)this).ReturnAddressStateOrProvince, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IUpdateJobParametersInternal)this).DeliveryPackageShipDate = (string) content.GetValueForProperty("DeliveryPackageShipDate",((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IUpdateJobParametersInternal)this).DeliveryPackageShipDate, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IUpdateJobParametersInternal)this).ReturnAddressStreetAddress2 = (string) content.GetValueForProperty("ReturnAddressStreetAddress2",((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IUpdateJobParametersInternal)this).ReturnAddressStreetAddress2, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IUpdateJobParametersInternal)this).ReturnShippingCarrierAccountNumber = (string) content.GetValueForProperty("ReturnShippingCarrierAccountNumber",((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IUpdateJobParametersInternal)this).ReturnShippingCarrierAccountNumber, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IUpdateJobParametersInternal)this).DeliveryPackageCarrierName = (string) content.GetValueForProperty("DeliveryPackageCarrierName",((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IUpdateJobParametersInternal)this).DeliveryPackageCarrierName, global::System.Convert.ToString);
            AfterDeserializeDictionary(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.UpdateJobParameters"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        internal UpdateJobParameters(global::System.Management.Automation.PSObject content)
        {
            bool returnNow = false;
            BeforeDeserializePSObject(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IUpdateJobParametersInternal)this).Property = (Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IUpdateJobParametersProperties) content.GetValueForProperty("Property",((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IUpdateJobParametersInternal)this).Property, Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.UpdateJobParametersPropertiesTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IUpdateJobParametersInternal)this).Tag = (Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IUpdateJobParametersTags) content.GetValueForProperty("Tag",((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IUpdateJobParametersInternal)this).Tag, Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.UpdateJobParametersTagsTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IUpdateJobParametersInternal)this).ReturnShipping = (Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IReturnShipping) content.GetValueForProperty("ReturnShipping",((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IUpdateJobParametersInternal)this).ReturnShipping, Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.ReturnShippingTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IUpdateJobParametersInternal)this).ReturnAddress = (Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IReturnAddress) content.GetValueForProperty("ReturnAddress",((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IUpdateJobParametersInternal)this).ReturnAddress, Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.ReturnAddressTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IUpdateJobParametersInternal)this).ReturnAddressRecipientName = (string) content.GetValueForProperty("ReturnAddressRecipientName",((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IUpdateJobParametersInternal)this).ReturnAddressRecipientName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IUpdateJobParametersInternal)this).BackupDriveManifest = (bool?) content.GetValueForProperty("BackupDriveManifest",((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IUpdateJobParametersInternal)this).BackupDriveManifest, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            ((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IUpdateJobParametersInternal)this).CancelRequested = (bool?) content.GetValueForProperty("CancelRequested",((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IUpdateJobParametersInternal)this).CancelRequested, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            ((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IUpdateJobParametersInternal)this).DriveList = (Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IDriveStatus[]) content.GetValueForProperty("DriveList",((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IUpdateJobParametersInternal)this).DriveList, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IDriveStatus>(__y, Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.DriveStatusTypeConverter.ConvertFrom));
            ((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IUpdateJobParametersInternal)this).LogLevel = (string) content.GetValueForProperty("LogLevel",((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IUpdateJobParametersInternal)this).LogLevel, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IUpdateJobParametersInternal)this).State = (string) content.GetValueForProperty("State",((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IUpdateJobParametersInternal)this).State, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IUpdateJobParametersInternal)this).ReturnAddressPhone = (string) content.GetValueForProperty("ReturnAddressPhone",((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IUpdateJobParametersInternal)this).ReturnAddressPhone, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IUpdateJobParametersInternal)this).ReturnShippingCarrierName = (string) content.GetValueForProperty("ReturnShippingCarrierName",((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IUpdateJobParametersInternal)this).ReturnShippingCarrierName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IUpdateJobParametersInternal)this).ReturnAddressStreetAddress1 = (string) content.GetValueForProperty("ReturnAddressStreetAddress1",((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IUpdateJobParametersInternal)this).ReturnAddressStreetAddress1, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IUpdateJobParametersInternal)this).DeliveryPackage = (Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IPackageInfomation) content.GetValueForProperty("DeliveryPackage",((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IUpdateJobParametersInternal)this).DeliveryPackage, Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.PackageInfomationTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IUpdateJobParametersInternal)this).ReturnAddressCity = (string) content.GetValueForProperty("ReturnAddressCity",((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IUpdateJobParametersInternal)this).ReturnAddressCity, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IUpdateJobParametersInternal)this).ReturnAddressPostalCode = (string) content.GetValueForProperty("ReturnAddressPostalCode",((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IUpdateJobParametersInternal)this).ReturnAddressPostalCode, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IUpdateJobParametersInternal)this).ReturnAddressEmail = (string) content.GetValueForProperty("ReturnAddressEmail",((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IUpdateJobParametersInternal)this).ReturnAddressEmail, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IUpdateJobParametersInternal)this).DeliveryPackageDriveCount = (int) content.GetValueForProperty("DeliveryPackageDriveCount",((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IUpdateJobParametersInternal)this).DeliveryPackageDriveCount, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            ((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IUpdateJobParametersInternal)this).ReturnAddressCountryOrRegion = (string) content.GetValueForProperty("ReturnAddressCountryOrRegion",((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IUpdateJobParametersInternal)this).ReturnAddressCountryOrRegion, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IUpdateJobParametersInternal)this).DeliveryPackageTrackingNumber = (string) content.GetValueForProperty("DeliveryPackageTrackingNumber",((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IUpdateJobParametersInternal)this).DeliveryPackageTrackingNumber, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IUpdateJobParametersInternal)this).ReturnAddressStateOrProvince = (string) content.GetValueForProperty("ReturnAddressStateOrProvince",((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IUpdateJobParametersInternal)this).ReturnAddressStateOrProvince, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IUpdateJobParametersInternal)this).DeliveryPackageShipDate = (string) content.GetValueForProperty("DeliveryPackageShipDate",((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IUpdateJobParametersInternal)this).DeliveryPackageShipDate, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IUpdateJobParametersInternal)this).ReturnAddressStreetAddress2 = (string) content.GetValueForProperty("ReturnAddressStreetAddress2",((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IUpdateJobParametersInternal)this).ReturnAddressStreetAddress2, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IUpdateJobParametersInternal)this).ReturnShippingCarrierAccountNumber = (string) content.GetValueForProperty("ReturnShippingCarrierAccountNumber",((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IUpdateJobParametersInternal)this).ReturnShippingCarrierAccountNumber, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IUpdateJobParametersInternal)this).DeliveryPackageCarrierName = (string) content.GetValueForProperty("DeliveryPackageCarrierName",((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IUpdateJobParametersInternal)this).DeliveryPackageCarrierName, global::System.Convert.ToString);
            AfterDeserializePSObject(content);
        }
    }
    /// Update Job parameters
    [System.ComponentModel.TypeConverter(typeof(UpdateJobParametersTypeConverter))]
    public partial interface IUpdateJobParameters

    {

    }
}