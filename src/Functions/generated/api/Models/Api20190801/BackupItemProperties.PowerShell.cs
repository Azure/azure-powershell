namespace Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801
{
    using Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.PowerShell;

    /// <summary>BackupItem resource specific properties</summary>
    [System.ComponentModel.TypeConverter(typeof(BackupItemPropertiesTypeConverter))]
    public partial class BackupItemProperties
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
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.BackupItemProperties"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        internal BackupItemProperties(global::System.Collections.IDictionary content)
        {
            bool returnNow = false;
            BeforeDeserializeDictionary(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IBackupItemPropertiesInternal)this).BackupId = (int?) content.GetValueForProperty("BackupId",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IBackupItemPropertiesInternal)this).BackupId, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IBackupItemPropertiesInternal)this).StorageAccountUrl = (string) content.GetValueForProperty("StorageAccountUrl",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IBackupItemPropertiesInternal)this).StorageAccountUrl, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IBackupItemPropertiesInternal)this).BlobName = (string) content.GetValueForProperty("BlobName",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IBackupItemPropertiesInternal)this).BlobName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IBackupItemPropertiesInternal)this).Name = (string) content.GetValueForProperty("Name",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IBackupItemPropertiesInternal)this).Name, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IBackupItemPropertiesInternal)this).Status = (Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.BackupItemStatus?) content.GetValueForProperty("Status",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IBackupItemPropertiesInternal)this).Status, Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.BackupItemStatus.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IBackupItemPropertiesInternal)this).SizeInByte = (long?) content.GetValueForProperty("SizeInByte",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IBackupItemPropertiesInternal)this).SizeInByte, (__y)=> (long) global::System.Convert.ChangeType(__y, typeof(long)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IBackupItemPropertiesInternal)this).Created = (global::System.DateTime?) content.GetValueForProperty("Created",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IBackupItemPropertiesInternal)this).Created, (v) => v is global::System.DateTime _v ? _v : global::System.Xml.XmlConvert.ToDateTime( v.ToString() , global::System.Xml.XmlDateTimeSerializationMode.Unspecified));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IBackupItemPropertiesInternal)this).Log = (string) content.GetValueForProperty("Log",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IBackupItemPropertiesInternal)this).Log, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IBackupItemPropertiesInternal)this).Database = (Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDatabaseBackupSetting[]) content.GetValueForProperty("Database",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IBackupItemPropertiesInternal)this).Database, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDatabaseBackupSetting>(__y, Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.DatabaseBackupSettingTypeConverter.ConvertFrom));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IBackupItemPropertiesInternal)this).Scheduled = (bool?) content.GetValueForProperty("Scheduled",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IBackupItemPropertiesInternal)this).Scheduled, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IBackupItemPropertiesInternal)this).LastRestoreTimeStamp = (global::System.DateTime?) content.GetValueForProperty("LastRestoreTimeStamp",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IBackupItemPropertiesInternal)this).LastRestoreTimeStamp, (v) => v is global::System.DateTime _v ? _v : global::System.Xml.XmlConvert.ToDateTime( v.ToString() , global::System.Xml.XmlDateTimeSerializationMode.Unspecified));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IBackupItemPropertiesInternal)this).FinishedTimeStamp = (global::System.DateTime?) content.GetValueForProperty("FinishedTimeStamp",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IBackupItemPropertiesInternal)this).FinishedTimeStamp, (v) => v is global::System.DateTime _v ? _v : global::System.Xml.XmlConvert.ToDateTime( v.ToString() , global::System.Xml.XmlDateTimeSerializationMode.Unspecified));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IBackupItemPropertiesInternal)this).CorrelationId = (string) content.GetValueForProperty("CorrelationId",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IBackupItemPropertiesInternal)this).CorrelationId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IBackupItemPropertiesInternal)this).WebsiteSizeInByte = (long?) content.GetValueForProperty("WebsiteSizeInByte",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IBackupItemPropertiesInternal)this).WebsiteSizeInByte, (__y)=> (long) global::System.Convert.ChangeType(__y, typeof(long)));
            AfterDeserializeDictionary(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.BackupItemProperties"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        internal BackupItemProperties(global::System.Management.Automation.PSObject content)
        {
            bool returnNow = false;
            BeforeDeserializePSObject(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IBackupItemPropertiesInternal)this).BackupId = (int?) content.GetValueForProperty("BackupId",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IBackupItemPropertiesInternal)this).BackupId, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IBackupItemPropertiesInternal)this).StorageAccountUrl = (string) content.GetValueForProperty("StorageAccountUrl",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IBackupItemPropertiesInternal)this).StorageAccountUrl, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IBackupItemPropertiesInternal)this).BlobName = (string) content.GetValueForProperty("BlobName",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IBackupItemPropertiesInternal)this).BlobName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IBackupItemPropertiesInternal)this).Name = (string) content.GetValueForProperty("Name",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IBackupItemPropertiesInternal)this).Name, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IBackupItemPropertiesInternal)this).Status = (Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.BackupItemStatus?) content.GetValueForProperty("Status",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IBackupItemPropertiesInternal)this).Status, Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.BackupItemStatus.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IBackupItemPropertiesInternal)this).SizeInByte = (long?) content.GetValueForProperty("SizeInByte",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IBackupItemPropertiesInternal)this).SizeInByte, (__y)=> (long) global::System.Convert.ChangeType(__y, typeof(long)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IBackupItemPropertiesInternal)this).Created = (global::System.DateTime?) content.GetValueForProperty("Created",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IBackupItemPropertiesInternal)this).Created, (v) => v is global::System.DateTime _v ? _v : global::System.Xml.XmlConvert.ToDateTime( v.ToString() , global::System.Xml.XmlDateTimeSerializationMode.Unspecified));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IBackupItemPropertiesInternal)this).Log = (string) content.GetValueForProperty("Log",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IBackupItemPropertiesInternal)this).Log, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IBackupItemPropertiesInternal)this).Database = (Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDatabaseBackupSetting[]) content.GetValueForProperty("Database",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IBackupItemPropertiesInternal)this).Database, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDatabaseBackupSetting>(__y, Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.DatabaseBackupSettingTypeConverter.ConvertFrom));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IBackupItemPropertiesInternal)this).Scheduled = (bool?) content.GetValueForProperty("Scheduled",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IBackupItemPropertiesInternal)this).Scheduled, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IBackupItemPropertiesInternal)this).LastRestoreTimeStamp = (global::System.DateTime?) content.GetValueForProperty("LastRestoreTimeStamp",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IBackupItemPropertiesInternal)this).LastRestoreTimeStamp, (v) => v is global::System.DateTime _v ? _v : global::System.Xml.XmlConvert.ToDateTime( v.ToString() , global::System.Xml.XmlDateTimeSerializationMode.Unspecified));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IBackupItemPropertiesInternal)this).FinishedTimeStamp = (global::System.DateTime?) content.GetValueForProperty("FinishedTimeStamp",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IBackupItemPropertiesInternal)this).FinishedTimeStamp, (v) => v is global::System.DateTime _v ? _v : global::System.Xml.XmlConvert.ToDateTime( v.ToString() , global::System.Xml.XmlDateTimeSerializationMode.Unspecified));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IBackupItemPropertiesInternal)this).CorrelationId = (string) content.GetValueForProperty("CorrelationId",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IBackupItemPropertiesInternal)this).CorrelationId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IBackupItemPropertiesInternal)this).WebsiteSizeInByte = (long?) content.GetValueForProperty("WebsiteSizeInByte",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IBackupItemPropertiesInternal)this).WebsiteSizeInByte, (__y)=> (long) global::System.Convert.ChangeType(__y, typeof(long)));
            AfterDeserializePSObject(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.BackupItemProperties"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IBackupItemProperties" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IBackupItemProperties DeserializeFromDictionary(global::System.Collections.IDictionary content)
        {
            return new BackupItemProperties(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.BackupItemProperties"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IBackupItemProperties" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IBackupItemProperties DeserializeFromPSObject(global::System.Management.Automation.PSObject content)
        {
            return new BackupItemProperties(content);
        }

        /// <summary>
        /// Creates a new instance of <see cref="BackupItemProperties" />, deserializing the content from a json string.
        /// </summary>
        /// <param name="jsonText">a string containing a JSON serialized instance of this model.</param>
        /// <returns>an instance of the <see cref="className" /> model class.</returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IBackupItemProperties FromJsonString(string jsonText) => FromJson(Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonNode.Parse(jsonText));

        /// <summary>Serializes this instance to a json string.</summary>

        /// <returns>a <see cref="System.String" /> containing this model serialized to JSON text.</returns>
        public string ToJsonString() => ToJson(null, Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.SerializationMode.IncludeAll)?.ToString();
    }
    /// BackupItem resource specific properties
    [System.ComponentModel.TypeConverter(typeof(BackupItemPropertiesTypeConverter))]
    public partial interface IBackupItemProperties

    {

    }
}