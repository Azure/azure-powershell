namespace Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801
{
    using Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.PowerShell;

    /// <summary>BackupRequest resource specific properties</summary>
    [System.ComponentModel.TypeConverter(typeof(BackupRequestPropertiesTypeConverter))]
    public partial class BackupRequestProperties
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
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.BackupRequestProperties"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        internal BackupRequestProperties(global::System.Collections.IDictionary content)
        {
            bool returnNow = false;
            BeforeDeserializeDictionary(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IBackupRequestPropertiesInternal)this).BackupSchedule = (Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IBackupSchedule) content.GetValueForProperty("BackupSchedule",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IBackupRequestPropertiesInternal)this).BackupSchedule, Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.BackupScheduleTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IBackupRequestPropertiesInternal)this).BackupName = (string) content.GetValueForProperty("BackupName",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IBackupRequestPropertiesInternal)this).BackupName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IBackupRequestPropertiesInternal)this).Database = (Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDatabaseBackupSetting[]) content.GetValueForProperty("Database",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IBackupRequestPropertiesInternal)this).Database, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDatabaseBackupSetting>(__y, Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.DatabaseBackupSettingTypeConverter.ConvertFrom));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IBackupRequestPropertiesInternal)this).Enabled = (bool?) content.GetValueForProperty("Enabled",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IBackupRequestPropertiesInternal)this).Enabled, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IBackupRequestPropertiesInternal)this).StorageAccountUrl = (string) content.GetValueForProperty("StorageAccountUrl",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IBackupRequestPropertiesInternal)this).StorageAccountUrl, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IBackupRequestPropertiesInternal)this).BackupScheduleFrequencyUnit = (Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.FrequencyUnit) content.GetValueForProperty("BackupScheduleFrequencyUnit",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IBackupRequestPropertiesInternal)this).BackupScheduleFrequencyUnit, Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.FrequencyUnit.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IBackupRequestPropertiesInternal)this).BackupScheduleStartTime = (global::System.DateTime?) content.GetValueForProperty("BackupScheduleStartTime",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IBackupRequestPropertiesInternal)this).BackupScheduleStartTime, (v) => v is global::System.DateTime _v ? _v : global::System.Xml.XmlConvert.ToDateTime( v.ToString() , global::System.Xml.XmlDateTimeSerializationMode.Unspecified));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IBackupRequestPropertiesInternal)this).BackupScheduleFrequencyInterval = (int) content.GetValueForProperty("BackupScheduleFrequencyInterval",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IBackupRequestPropertiesInternal)this).BackupScheduleFrequencyInterval, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IBackupRequestPropertiesInternal)this).BackupScheduleKeepAtLeastOneBackup = (bool) content.GetValueForProperty("BackupScheduleKeepAtLeastOneBackup",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IBackupRequestPropertiesInternal)this).BackupScheduleKeepAtLeastOneBackup, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IBackupRequestPropertiesInternal)this).BackupScheduleLastExecutionTime = (global::System.DateTime?) content.GetValueForProperty("BackupScheduleLastExecutionTime",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IBackupRequestPropertiesInternal)this).BackupScheduleLastExecutionTime, (v) => v is global::System.DateTime _v ? _v : global::System.Xml.XmlConvert.ToDateTime( v.ToString() , global::System.Xml.XmlDateTimeSerializationMode.Unspecified));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IBackupRequestPropertiesInternal)this).BackupScheduleRetentionPeriodInDay = (int) content.GetValueForProperty("BackupScheduleRetentionPeriodInDay",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IBackupRequestPropertiesInternal)this).BackupScheduleRetentionPeriodInDay, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            AfterDeserializeDictionary(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.BackupRequestProperties"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        internal BackupRequestProperties(global::System.Management.Automation.PSObject content)
        {
            bool returnNow = false;
            BeforeDeserializePSObject(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IBackupRequestPropertiesInternal)this).BackupSchedule = (Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IBackupSchedule) content.GetValueForProperty("BackupSchedule",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IBackupRequestPropertiesInternal)this).BackupSchedule, Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.BackupScheduleTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IBackupRequestPropertiesInternal)this).BackupName = (string) content.GetValueForProperty("BackupName",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IBackupRequestPropertiesInternal)this).BackupName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IBackupRequestPropertiesInternal)this).Database = (Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDatabaseBackupSetting[]) content.GetValueForProperty("Database",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IBackupRequestPropertiesInternal)this).Database, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDatabaseBackupSetting>(__y, Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.DatabaseBackupSettingTypeConverter.ConvertFrom));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IBackupRequestPropertiesInternal)this).Enabled = (bool?) content.GetValueForProperty("Enabled",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IBackupRequestPropertiesInternal)this).Enabled, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IBackupRequestPropertiesInternal)this).StorageAccountUrl = (string) content.GetValueForProperty("StorageAccountUrl",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IBackupRequestPropertiesInternal)this).StorageAccountUrl, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IBackupRequestPropertiesInternal)this).BackupScheduleFrequencyUnit = (Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.FrequencyUnit) content.GetValueForProperty("BackupScheduleFrequencyUnit",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IBackupRequestPropertiesInternal)this).BackupScheduleFrequencyUnit, Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.FrequencyUnit.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IBackupRequestPropertiesInternal)this).BackupScheduleStartTime = (global::System.DateTime?) content.GetValueForProperty("BackupScheduleStartTime",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IBackupRequestPropertiesInternal)this).BackupScheduleStartTime, (v) => v is global::System.DateTime _v ? _v : global::System.Xml.XmlConvert.ToDateTime( v.ToString() , global::System.Xml.XmlDateTimeSerializationMode.Unspecified));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IBackupRequestPropertiesInternal)this).BackupScheduleFrequencyInterval = (int) content.GetValueForProperty("BackupScheduleFrequencyInterval",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IBackupRequestPropertiesInternal)this).BackupScheduleFrequencyInterval, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IBackupRequestPropertiesInternal)this).BackupScheduleKeepAtLeastOneBackup = (bool) content.GetValueForProperty("BackupScheduleKeepAtLeastOneBackup",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IBackupRequestPropertiesInternal)this).BackupScheduleKeepAtLeastOneBackup, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IBackupRequestPropertiesInternal)this).BackupScheduleLastExecutionTime = (global::System.DateTime?) content.GetValueForProperty("BackupScheduleLastExecutionTime",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IBackupRequestPropertiesInternal)this).BackupScheduleLastExecutionTime, (v) => v is global::System.DateTime _v ? _v : global::System.Xml.XmlConvert.ToDateTime( v.ToString() , global::System.Xml.XmlDateTimeSerializationMode.Unspecified));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IBackupRequestPropertiesInternal)this).BackupScheduleRetentionPeriodInDay = (int) content.GetValueForProperty("BackupScheduleRetentionPeriodInDay",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IBackupRequestPropertiesInternal)this).BackupScheduleRetentionPeriodInDay, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            AfterDeserializePSObject(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.BackupRequestProperties"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IBackupRequestProperties" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IBackupRequestProperties DeserializeFromDictionary(global::System.Collections.IDictionary content)
        {
            return new BackupRequestProperties(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.BackupRequestProperties"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IBackupRequestProperties" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IBackupRequestProperties DeserializeFromPSObject(global::System.Management.Automation.PSObject content)
        {
            return new BackupRequestProperties(content);
        }

        /// <summary>
        /// Creates a new instance of <see cref="BackupRequestProperties" />, deserializing the content from a json string.
        /// </summary>
        /// <param name="jsonText">a string containing a JSON serialized instance of this model.</param>
        /// <returns>an instance of the <see cref="className" /> model class.</returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IBackupRequestProperties FromJsonString(string jsonText) => FromJson(Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonNode.Parse(jsonText));

        /// <summary>Serializes this instance to a json string.</summary>

        /// <returns>a <see cref="System.String" /> containing this model serialized to JSON text.</returns>
        public string ToJsonString() => ToJson(null, Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.SerializationMode.IncludeAll)?.ToString();
    }
    /// BackupRequest resource specific properties
    [System.ComponentModel.TypeConverter(typeof(BackupRequestPropertiesTypeConverter))]
    public partial interface IBackupRequestProperties

    {

    }
}