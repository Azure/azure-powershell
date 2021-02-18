namespace Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801
{
    using Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.PowerShell;

    /// <summary>RestoreRequest resource specific properties</summary>
    [System.ComponentModel.TypeConverter(typeof(RestoreRequestPropertiesTypeConverter))]
    public partial class RestoreRequestProperties
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
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.RestoreRequestProperties"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IRestoreRequestProperties" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IRestoreRequestProperties DeserializeFromDictionary(global::System.Collections.IDictionary content)
        {
            return new RestoreRequestProperties(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.RestoreRequestProperties"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IRestoreRequestProperties" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IRestoreRequestProperties DeserializeFromPSObject(global::System.Management.Automation.PSObject content)
        {
            return new RestoreRequestProperties(content);
        }

        /// <summary>
        /// Creates a new instance of <see cref="RestoreRequestProperties" />, deserializing the content from a json string.
        /// </summary>
        /// <param name="jsonText">a string containing a JSON serialized instance of this model.</param>
        /// <returns>an instance of the <see cref="className" /> model class.</returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IRestoreRequestProperties FromJsonString(string jsonText) => FromJson(Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonNode.Parse(jsonText));

        /// <summary>
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.RestoreRequestProperties"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        internal RestoreRequestProperties(global::System.Collections.IDictionary content)
        {
            bool returnNow = false;
            BeforeDeserializeDictionary(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IRestoreRequestPropertiesInternal)this).StorageAccountUrl = (string) content.GetValueForProperty("StorageAccountUrl",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IRestoreRequestPropertiesInternal)this).StorageAccountUrl, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IRestoreRequestPropertiesInternal)this).BlobName = (string) content.GetValueForProperty("BlobName",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IRestoreRequestPropertiesInternal)this).BlobName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IRestoreRequestPropertiesInternal)this).Overwrite = (bool) content.GetValueForProperty("Overwrite",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IRestoreRequestPropertiesInternal)this).Overwrite, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IRestoreRequestPropertiesInternal)this).SiteName = (string) content.GetValueForProperty("SiteName",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IRestoreRequestPropertiesInternal)this).SiteName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IRestoreRequestPropertiesInternal)this).Database = (Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDatabaseBackupSetting[]) content.GetValueForProperty("Database",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IRestoreRequestPropertiesInternal)this).Database, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDatabaseBackupSetting>(__y, Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.DatabaseBackupSettingTypeConverter.ConvertFrom));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IRestoreRequestPropertiesInternal)this).IgnoreConflictingHostName = (bool?) content.GetValueForProperty("IgnoreConflictingHostName",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IRestoreRequestPropertiesInternal)this).IgnoreConflictingHostName, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IRestoreRequestPropertiesInternal)this).IgnoreDatabase = (bool?) content.GetValueForProperty("IgnoreDatabase",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IRestoreRequestPropertiesInternal)this).IgnoreDatabase, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IRestoreRequestPropertiesInternal)this).AppServicePlan = (string) content.GetValueForProperty("AppServicePlan",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IRestoreRequestPropertiesInternal)this).AppServicePlan, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IRestoreRequestPropertiesInternal)this).OperationType = (Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.BackupRestoreOperationType?) content.GetValueForProperty("OperationType",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IRestoreRequestPropertiesInternal)this).OperationType, Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.BackupRestoreOperationType.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IRestoreRequestPropertiesInternal)this).AdjustConnectionString = (bool?) content.GetValueForProperty("AdjustConnectionString",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IRestoreRequestPropertiesInternal)this).AdjustConnectionString, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IRestoreRequestPropertiesInternal)this).HostingEnvironment = (string) content.GetValueForProperty("HostingEnvironment",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IRestoreRequestPropertiesInternal)this).HostingEnvironment, global::System.Convert.ToString);
            AfterDeserializeDictionary(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.RestoreRequestProperties"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        internal RestoreRequestProperties(global::System.Management.Automation.PSObject content)
        {
            bool returnNow = false;
            BeforeDeserializePSObject(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IRestoreRequestPropertiesInternal)this).StorageAccountUrl = (string) content.GetValueForProperty("StorageAccountUrl",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IRestoreRequestPropertiesInternal)this).StorageAccountUrl, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IRestoreRequestPropertiesInternal)this).BlobName = (string) content.GetValueForProperty("BlobName",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IRestoreRequestPropertiesInternal)this).BlobName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IRestoreRequestPropertiesInternal)this).Overwrite = (bool) content.GetValueForProperty("Overwrite",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IRestoreRequestPropertiesInternal)this).Overwrite, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IRestoreRequestPropertiesInternal)this).SiteName = (string) content.GetValueForProperty("SiteName",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IRestoreRequestPropertiesInternal)this).SiteName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IRestoreRequestPropertiesInternal)this).Database = (Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDatabaseBackupSetting[]) content.GetValueForProperty("Database",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IRestoreRequestPropertiesInternal)this).Database, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDatabaseBackupSetting>(__y, Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.DatabaseBackupSettingTypeConverter.ConvertFrom));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IRestoreRequestPropertiesInternal)this).IgnoreConflictingHostName = (bool?) content.GetValueForProperty("IgnoreConflictingHostName",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IRestoreRequestPropertiesInternal)this).IgnoreConflictingHostName, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IRestoreRequestPropertiesInternal)this).IgnoreDatabase = (bool?) content.GetValueForProperty("IgnoreDatabase",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IRestoreRequestPropertiesInternal)this).IgnoreDatabase, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IRestoreRequestPropertiesInternal)this).AppServicePlan = (string) content.GetValueForProperty("AppServicePlan",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IRestoreRequestPropertiesInternal)this).AppServicePlan, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IRestoreRequestPropertiesInternal)this).OperationType = (Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.BackupRestoreOperationType?) content.GetValueForProperty("OperationType",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IRestoreRequestPropertiesInternal)this).OperationType, Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.BackupRestoreOperationType.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IRestoreRequestPropertiesInternal)this).AdjustConnectionString = (bool?) content.GetValueForProperty("AdjustConnectionString",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IRestoreRequestPropertiesInternal)this).AdjustConnectionString, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IRestoreRequestPropertiesInternal)this).HostingEnvironment = (string) content.GetValueForProperty("HostingEnvironment",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IRestoreRequestPropertiesInternal)this).HostingEnvironment, global::System.Convert.ToString);
            AfterDeserializePSObject(content);
        }

        /// <summary>Serializes this instance to a json string.</summary>

        /// <returns>a <see cref="System.String" /> containing this model serialized to JSON text.</returns>
        public string ToJsonString() => ToJson(null, Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.SerializationMode.IncludeAll)?.ToString();
    }
    /// RestoreRequest resource specific properties
    [System.ComponentModel.TypeConverter(typeof(RestoreRequestPropertiesTypeConverter))]
    public partial interface IRestoreRequestProperties

    {

    }
}