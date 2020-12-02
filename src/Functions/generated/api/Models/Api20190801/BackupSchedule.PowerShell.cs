namespace Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801
{
    using Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.PowerShell;

    /// <summary>
    /// Description of a backup schedule. Describes how often should be the backup performed and what should be the retention
    /// policy.
    /// </summary>
    [System.ComponentModel.TypeConverter(typeof(BackupScheduleTypeConverter))]
    public partial class BackupSchedule
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
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.BackupSchedule"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        internal BackupSchedule(global::System.Collections.IDictionary content)
        {
            bool returnNow = false;
            BeforeDeserializeDictionary(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IBackupScheduleInternal)this).FrequencyInterval = (int) content.GetValueForProperty("FrequencyInterval",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IBackupScheduleInternal)this).FrequencyInterval, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IBackupScheduleInternal)this).FrequencyUnit = (Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.FrequencyUnit) content.GetValueForProperty("FrequencyUnit",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IBackupScheduleInternal)this).FrequencyUnit, Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.FrequencyUnit.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IBackupScheduleInternal)this).KeepAtLeastOneBackup = (bool) content.GetValueForProperty("KeepAtLeastOneBackup",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IBackupScheduleInternal)this).KeepAtLeastOneBackup, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IBackupScheduleInternal)this).RetentionPeriodInDay = (int) content.GetValueForProperty("RetentionPeriodInDay",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IBackupScheduleInternal)this).RetentionPeriodInDay, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IBackupScheduleInternal)this).StartTime = (global::System.DateTime?) content.GetValueForProperty("StartTime",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IBackupScheduleInternal)this).StartTime, (v) => v is global::System.DateTime _v ? _v : global::System.Xml.XmlConvert.ToDateTime( v.ToString() , global::System.Xml.XmlDateTimeSerializationMode.Unspecified));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IBackupScheduleInternal)this).LastExecutionTime = (global::System.DateTime?) content.GetValueForProperty("LastExecutionTime",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IBackupScheduleInternal)this).LastExecutionTime, (v) => v is global::System.DateTime _v ? _v : global::System.Xml.XmlConvert.ToDateTime( v.ToString() , global::System.Xml.XmlDateTimeSerializationMode.Unspecified));
            AfterDeserializeDictionary(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.BackupSchedule"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        internal BackupSchedule(global::System.Management.Automation.PSObject content)
        {
            bool returnNow = false;
            BeforeDeserializePSObject(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IBackupScheduleInternal)this).FrequencyInterval = (int) content.GetValueForProperty("FrequencyInterval",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IBackupScheduleInternal)this).FrequencyInterval, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IBackupScheduleInternal)this).FrequencyUnit = (Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.FrequencyUnit) content.GetValueForProperty("FrequencyUnit",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IBackupScheduleInternal)this).FrequencyUnit, Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.FrequencyUnit.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IBackupScheduleInternal)this).KeepAtLeastOneBackup = (bool) content.GetValueForProperty("KeepAtLeastOneBackup",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IBackupScheduleInternal)this).KeepAtLeastOneBackup, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IBackupScheduleInternal)this).RetentionPeriodInDay = (int) content.GetValueForProperty("RetentionPeriodInDay",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IBackupScheduleInternal)this).RetentionPeriodInDay, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IBackupScheduleInternal)this).StartTime = (global::System.DateTime?) content.GetValueForProperty("StartTime",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IBackupScheduleInternal)this).StartTime, (v) => v is global::System.DateTime _v ? _v : global::System.Xml.XmlConvert.ToDateTime( v.ToString() , global::System.Xml.XmlDateTimeSerializationMode.Unspecified));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IBackupScheduleInternal)this).LastExecutionTime = (global::System.DateTime?) content.GetValueForProperty("LastExecutionTime",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IBackupScheduleInternal)this).LastExecutionTime, (v) => v is global::System.DateTime _v ? _v : global::System.Xml.XmlConvert.ToDateTime( v.ToString() , global::System.Xml.XmlDateTimeSerializationMode.Unspecified));
            AfterDeserializePSObject(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.BackupSchedule"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IBackupSchedule" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IBackupSchedule DeserializeFromDictionary(global::System.Collections.IDictionary content)
        {
            return new BackupSchedule(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.BackupSchedule"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IBackupSchedule" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IBackupSchedule DeserializeFromPSObject(global::System.Management.Automation.PSObject content)
        {
            return new BackupSchedule(content);
        }

        /// <summary>
        /// Creates a new instance of <see cref="BackupSchedule" />, deserializing the content from a json string.
        /// </summary>
        /// <param name="jsonText">a string containing a JSON serialized instance of this model.</param>
        /// <returns>an instance of the <see cref="className" /> model class.</returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IBackupSchedule FromJsonString(string jsonText) => FromJson(Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonNode.Parse(jsonText));

        /// <summary>Serializes this instance to a json string.</summary>

        /// <returns>a <see cref="System.String" /> containing this model serialized to JSON text.</returns>
        public string ToJsonString() => ToJson(null, Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.SerializationMode.IncludeAll)?.ToString();
    }
    /// Description of a backup schedule. Describes how often should be the backup performed and what should be the retention
    /// policy.
    [System.ComponentModel.TypeConverter(typeof(BackupScheduleTypeConverter))]
    public partial interface IBackupSchedule

    {

    }
}