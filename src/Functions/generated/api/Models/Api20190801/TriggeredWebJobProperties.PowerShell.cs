namespace Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801
{
    using Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.PowerShell;

    /// <summary>TriggeredWebJob resource specific properties</summary>
    [System.ComponentModel.TypeConverter(typeof(TriggeredWebJobPropertiesTypeConverter))]
    public partial class TriggeredWebJobProperties
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
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.TriggeredWebJobProperties"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ITriggeredWebJobProperties"
        /// />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ITriggeredWebJobProperties DeserializeFromDictionary(global::System.Collections.IDictionary content)
        {
            return new TriggeredWebJobProperties(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.TriggeredWebJobProperties"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ITriggeredWebJobProperties"
        /// />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ITriggeredWebJobProperties DeserializeFromPSObject(global::System.Management.Automation.PSObject content)
        {
            return new TriggeredWebJobProperties(content);
        }

        /// <summary>
        /// Creates a new instance of <see cref="TriggeredWebJobProperties" />, deserializing the content from a json string.
        /// </summary>
        /// <param name="jsonText">a string containing a JSON serialized instance of this model.</param>
        /// <returns>an instance of the <see cref="className" /> model class.</returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ITriggeredWebJobProperties FromJsonString(string jsonText) => FromJson(Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonNode.Parse(jsonText));

        /// <summary>Serializes this instance to a json string.</summary>

        /// <returns>a <see cref="System.String" /> containing this model serialized to JSON text.</returns>
        public string ToJsonString() => ToJson(null, Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.SerializationMode.IncludeAll)?.ToString();

        /// <summary>
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.TriggeredWebJobProperties"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        internal TriggeredWebJobProperties(global::System.Collections.IDictionary content)
        {
            bool returnNow = false;
            BeforeDeserializeDictionary(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ITriggeredWebJobPropertiesInternal)this).LatestRun = (Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ITriggeredJobRun) content.GetValueForProperty("LatestRun",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ITriggeredWebJobPropertiesInternal)this).LatestRun, Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.TriggeredJobRunTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ITriggeredWebJobPropertiesInternal)this).HistoryUrl = (string) content.GetValueForProperty("HistoryUrl",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ITriggeredWebJobPropertiesInternal)this).HistoryUrl, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ITriggeredWebJobPropertiesInternal)this).SchedulerLogsUrl = (string) content.GetValueForProperty("SchedulerLogsUrl",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ITriggeredWebJobPropertiesInternal)this).SchedulerLogsUrl, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ITriggeredWebJobPropertiesInternal)this).RunCommand = (string) content.GetValueForProperty("RunCommand",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ITriggeredWebJobPropertiesInternal)this).RunCommand, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ITriggeredWebJobPropertiesInternal)this).Url = (string) content.GetValueForProperty("Url",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ITriggeredWebJobPropertiesInternal)this).Url, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ITriggeredWebJobPropertiesInternal)this).ExtraInfoUrl = (string) content.GetValueForProperty("ExtraInfoUrl",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ITriggeredWebJobPropertiesInternal)this).ExtraInfoUrl, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ITriggeredWebJobPropertiesInternal)this).WebJobType = (Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.WebJobType?) content.GetValueForProperty("WebJobType",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ITriggeredWebJobPropertiesInternal)this).WebJobType, Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.WebJobType.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ITriggeredWebJobPropertiesInternal)this).Error = (string) content.GetValueForProperty("Error",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ITriggeredWebJobPropertiesInternal)this).Error, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ITriggeredWebJobPropertiesInternal)this).UsingSdk = (bool?) content.GetValueForProperty("UsingSdk",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ITriggeredWebJobPropertiesInternal)this).UsingSdk, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ITriggeredWebJobPropertiesInternal)this).Setting = (Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ITriggeredWebJobPropertiesSettings) content.GetValueForProperty("Setting",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ITriggeredWebJobPropertiesInternal)this).Setting, Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.TriggeredWebJobPropertiesSettingsTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ITriggeredWebJobPropertiesInternal)this).LatestRunId = (string) content.GetValueForProperty("LatestRunId",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ITriggeredWebJobPropertiesInternal)this).LatestRunId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ITriggeredWebJobPropertiesInternal)this).LatestRunKind = (string) content.GetValueForProperty("LatestRunKind",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ITriggeredWebJobPropertiesInternal)this).LatestRunKind, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ITriggeredWebJobPropertiesInternal)this).LatestRunType = (string) content.GetValueForProperty("LatestRunType",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ITriggeredWebJobPropertiesInternal)this).LatestRunType, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ITriggeredWebJobPropertiesInternal)this).LatestRunProperty = (Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ITriggeredJobRunProperties) content.GetValueForProperty("LatestRunProperty",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ITriggeredWebJobPropertiesInternal)this).LatestRunProperty, Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.TriggeredJobRunPropertiesTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ITriggeredWebJobPropertiesInternal)this).LatestRunName = (string) content.GetValueForProperty("LatestRunName",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ITriggeredWebJobPropertiesInternal)this).LatestRunName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ITriggeredWebJobPropertiesInternal)this).Duration = (string) content.GetValueForProperty("Duration",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ITriggeredWebJobPropertiesInternal)this).Duration, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ITriggeredWebJobPropertiesInternal)this).WebJobId = (string) content.GetValueForProperty("WebJobId",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ITriggeredWebJobPropertiesInternal)this).WebJobId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ITriggeredWebJobPropertiesInternal)this).Status = (Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.TriggeredWebJobStatus?) content.GetValueForProperty("Status",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ITriggeredWebJobPropertiesInternal)this).Status, Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.TriggeredWebJobStatus.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ITriggeredWebJobPropertiesInternal)this).Trigger = (string) content.GetValueForProperty("Trigger",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ITriggeredWebJobPropertiesInternal)this).Trigger, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ITriggeredWebJobPropertiesInternal)this).EndTime = (global::System.DateTime?) content.GetValueForProperty("EndTime",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ITriggeredWebJobPropertiesInternal)this).EndTime, (v) => v is global::System.DateTime _v ? _v : global::System.Xml.XmlConvert.ToDateTime( v.ToString() , global::System.Xml.XmlDateTimeSerializationMode.Unspecified));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ITriggeredWebJobPropertiesInternal)this).WebJobName = (string) content.GetValueForProperty("WebJobName",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ITriggeredWebJobPropertiesInternal)this).WebJobName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ITriggeredWebJobPropertiesInternal)this).OutputUrl = (string) content.GetValueForProperty("OutputUrl",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ITriggeredWebJobPropertiesInternal)this).OutputUrl, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ITriggeredWebJobPropertiesInternal)this).ErrorUrl = (string) content.GetValueForProperty("ErrorUrl",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ITriggeredWebJobPropertiesInternal)this).ErrorUrl, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ITriggeredWebJobPropertiesInternal)this).LatestRunPropertiesUrl = (string) content.GetValueForProperty("LatestRunPropertiesUrl",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ITriggeredWebJobPropertiesInternal)this).LatestRunPropertiesUrl, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ITriggeredWebJobPropertiesInternal)this).JobName = (string) content.GetValueForProperty("JobName",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ITriggeredWebJobPropertiesInternal)this).JobName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ITriggeredWebJobPropertiesInternal)this).StartTime = (global::System.DateTime?) content.GetValueForProperty("StartTime",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ITriggeredWebJobPropertiesInternal)this).StartTime, (v) => v is global::System.DateTime _v ? _v : global::System.Xml.XmlConvert.ToDateTime( v.ToString() , global::System.Xml.XmlDateTimeSerializationMode.Unspecified));
            AfterDeserializeDictionary(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.TriggeredWebJobProperties"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        internal TriggeredWebJobProperties(global::System.Management.Automation.PSObject content)
        {
            bool returnNow = false;
            BeforeDeserializePSObject(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ITriggeredWebJobPropertiesInternal)this).LatestRun = (Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ITriggeredJobRun) content.GetValueForProperty("LatestRun",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ITriggeredWebJobPropertiesInternal)this).LatestRun, Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.TriggeredJobRunTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ITriggeredWebJobPropertiesInternal)this).HistoryUrl = (string) content.GetValueForProperty("HistoryUrl",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ITriggeredWebJobPropertiesInternal)this).HistoryUrl, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ITriggeredWebJobPropertiesInternal)this).SchedulerLogsUrl = (string) content.GetValueForProperty("SchedulerLogsUrl",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ITriggeredWebJobPropertiesInternal)this).SchedulerLogsUrl, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ITriggeredWebJobPropertiesInternal)this).RunCommand = (string) content.GetValueForProperty("RunCommand",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ITriggeredWebJobPropertiesInternal)this).RunCommand, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ITriggeredWebJobPropertiesInternal)this).Url = (string) content.GetValueForProperty("Url",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ITriggeredWebJobPropertiesInternal)this).Url, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ITriggeredWebJobPropertiesInternal)this).ExtraInfoUrl = (string) content.GetValueForProperty("ExtraInfoUrl",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ITriggeredWebJobPropertiesInternal)this).ExtraInfoUrl, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ITriggeredWebJobPropertiesInternal)this).WebJobType = (Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.WebJobType?) content.GetValueForProperty("WebJobType",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ITriggeredWebJobPropertiesInternal)this).WebJobType, Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.WebJobType.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ITriggeredWebJobPropertiesInternal)this).Error = (string) content.GetValueForProperty("Error",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ITriggeredWebJobPropertiesInternal)this).Error, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ITriggeredWebJobPropertiesInternal)this).UsingSdk = (bool?) content.GetValueForProperty("UsingSdk",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ITriggeredWebJobPropertiesInternal)this).UsingSdk, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ITriggeredWebJobPropertiesInternal)this).Setting = (Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ITriggeredWebJobPropertiesSettings) content.GetValueForProperty("Setting",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ITriggeredWebJobPropertiesInternal)this).Setting, Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.TriggeredWebJobPropertiesSettingsTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ITriggeredWebJobPropertiesInternal)this).LatestRunId = (string) content.GetValueForProperty("LatestRunId",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ITriggeredWebJobPropertiesInternal)this).LatestRunId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ITriggeredWebJobPropertiesInternal)this).LatestRunKind = (string) content.GetValueForProperty("LatestRunKind",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ITriggeredWebJobPropertiesInternal)this).LatestRunKind, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ITriggeredWebJobPropertiesInternal)this).LatestRunType = (string) content.GetValueForProperty("LatestRunType",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ITriggeredWebJobPropertiesInternal)this).LatestRunType, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ITriggeredWebJobPropertiesInternal)this).LatestRunProperty = (Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ITriggeredJobRunProperties) content.GetValueForProperty("LatestRunProperty",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ITriggeredWebJobPropertiesInternal)this).LatestRunProperty, Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.TriggeredJobRunPropertiesTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ITriggeredWebJobPropertiesInternal)this).LatestRunName = (string) content.GetValueForProperty("LatestRunName",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ITriggeredWebJobPropertiesInternal)this).LatestRunName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ITriggeredWebJobPropertiesInternal)this).Duration = (string) content.GetValueForProperty("Duration",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ITriggeredWebJobPropertiesInternal)this).Duration, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ITriggeredWebJobPropertiesInternal)this).WebJobId = (string) content.GetValueForProperty("WebJobId",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ITriggeredWebJobPropertiesInternal)this).WebJobId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ITriggeredWebJobPropertiesInternal)this).Status = (Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.TriggeredWebJobStatus?) content.GetValueForProperty("Status",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ITriggeredWebJobPropertiesInternal)this).Status, Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.TriggeredWebJobStatus.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ITriggeredWebJobPropertiesInternal)this).Trigger = (string) content.GetValueForProperty("Trigger",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ITriggeredWebJobPropertiesInternal)this).Trigger, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ITriggeredWebJobPropertiesInternal)this).EndTime = (global::System.DateTime?) content.GetValueForProperty("EndTime",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ITriggeredWebJobPropertiesInternal)this).EndTime, (v) => v is global::System.DateTime _v ? _v : global::System.Xml.XmlConvert.ToDateTime( v.ToString() , global::System.Xml.XmlDateTimeSerializationMode.Unspecified));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ITriggeredWebJobPropertiesInternal)this).WebJobName = (string) content.GetValueForProperty("WebJobName",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ITriggeredWebJobPropertiesInternal)this).WebJobName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ITriggeredWebJobPropertiesInternal)this).OutputUrl = (string) content.GetValueForProperty("OutputUrl",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ITriggeredWebJobPropertiesInternal)this).OutputUrl, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ITriggeredWebJobPropertiesInternal)this).ErrorUrl = (string) content.GetValueForProperty("ErrorUrl",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ITriggeredWebJobPropertiesInternal)this).ErrorUrl, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ITriggeredWebJobPropertiesInternal)this).LatestRunPropertiesUrl = (string) content.GetValueForProperty("LatestRunPropertiesUrl",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ITriggeredWebJobPropertiesInternal)this).LatestRunPropertiesUrl, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ITriggeredWebJobPropertiesInternal)this).JobName = (string) content.GetValueForProperty("JobName",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ITriggeredWebJobPropertiesInternal)this).JobName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ITriggeredWebJobPropertiesInternal)this).StartTime = (global::System.DateTime?) content.GetValueForProperty("StartTime",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ITriggeredWebJobPropertiesInternal)this).StartTime, (v) => v is global::System.DateTime _v ? _v : global::System.Xml.XmlConvert.ToDateTime( v.ToString() , global::System.Xml.XmlDateTimeSerializationMode.Unspecified));
            AfterDeserializePSObject(content);
        }
    }
    /// TriggeredWebJob resource specific properties
    [System.ComponentModel.TypeConverter(typeof(TriggeredWebJobPropertiesTypeConverter))]
    public partial interface ITriggeredWebJobProperties

    {

    }
}