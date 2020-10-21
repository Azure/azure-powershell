namespace Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801
{
    using Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.PowerShell;

    /// <summary>TriggeredJobRun resource specific properties</summary>
    [System.ComponentModel.TypeConverter(typeof(TriggeredJobRunPropertiesTypeConverter))]
    public partial class TriggeredJobRunProperties
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
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.TriggeredJobRunProperties"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ITriggeredJobRunProperties"
        /// />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ITriggeredJobRunProperties DeserializeFromDictionary(global::System.Collections.IDictionary content)
        {
            return new TriggeredJobRunProperties(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.TriggeredJobRunProperties"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ITriggeredJobRunProperties"
        /// />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ITriggeredJobRunProperties DeserializeFromPSObject(global::System.Management.Automation.PSObject content)
        {
            return new TriggeredJobRunProperties(content);
        }

        /// <summary>
        /// Creates a new instance of <see cref="TriggeredJobRunProperties" />, deserializing the content from a json string.
        /// </summary>
        /// <param name="jsonText">a string containing a JSON serialized instance of this model.</param>
        /// <returns>an instance of the <see cref="className" /> model class.</returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ITriggeredJobRunProperties FromJsonString(string jsonText) => FromJson(Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonNode.Parse(jsonText));

        /// <summary>Serializes this instance to a json string.</summary>

        /// <returns>a <see cref="System.String" /> containing this model serialized to JSON text.</returns>
        public string ToJsonString() => ToJson(null, Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.SerializationMode.IncludeAll)?.ToString();

        /// <summary>
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.TriggeredJobRunProperties"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        internal TriggeredJobRunProperties(global::System.Collections.IDictionary content)
        {
            bool returnNow = false;
            BeforeDeserializeDictionary(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ITriggeredJobRunPropertiesInternal)this).WebJobId = (string) content.GetValueForProperty("WebJobId",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ITriggeredJobRunPropertiesInternal)this).WebJobId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ITriggeredJobRunPropertiesInternal)this).WebJobName = (string) content.GetValueForProperty("WebJobName",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ITriggeredJobRunPropertiesInternal)this).WebJobName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ITriggeredJobRunPropertiesInternal)this).Status = (Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.TriggeredWebJobStatus?) content.GetValueForProperty("Status",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ITriggeredJobRunPropertiesInternal)this).Status, Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.TriggeredWebJobStatus.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ITriggeredJobRunPropertiesInternal)this).StartTime = (global::System.DateTime?) content.GetValueForProperty("StartTime",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ITriggeredJobRunPropertiesInternal)this).StartTime, (v) => v is global::System.DateTime _v ? _v : global::System.Xml.XmlConvert.ToDateTime( v.ToString() , global::System.Xml.XmlDateTimeSerializationMode.Unspecified));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ITriggeredJobRunPropertiesInternal)this).EndTime = (global::System.DateTime?) content.GetValueForProperty("EndTime",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ITriggeredJobRunPropertiesInternal)this).EndTime, (v) => v is global::System.DateTime _v ? _v : global::System.Xml.XmlConvert.ToDateTime( v.ToString() , global::System.Xml.XmlDateTimeSerializationMode.Unspecified));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ITriggeredJobRunPropertiesInternal)this).Duration = (string) content.GetValueForProperty("Duration",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ITriggeredJobRunPropertiesInternal)this).Duration, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ITriggeredJobRunPropertiesInternal)this).OutputUrl = (string) content.GetValueForProperty("OutputUrl",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ITriggeredJobRunPropertiesInternal)this).OutputUrl, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ITriggeredJobRunPropertiesInternal)this).ErrorUrl = (string) content.GetValueForProperty("ErrorUrl",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ITriggeredJobRunPropertiesInternal)this).ErrorUrl, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ITriggeredJobRunPropertiesInternal)this).Url = (string) content.GetValueForProperty("Url",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ITriggeredJobRunPropertiesInternal)this).Url, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ITriggeredJobRunPropertiesInternal)this).JobName = (string) content.GetValueForProperty("JobName",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ITriggeredJobRunPropertiesInternal)this).JobName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ITriggeredJobRunPropertiesInternal)this).Trigger = (string) content.GetValueForProperty("Trigger",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ITriggeredJobRunPropertiesInternal)this).Trigger, global::System.Convert.ToString);
            AfterDeserializeDictionary(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.TriggeredJobRunProperties"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        internal TriggeredJobRunProperties(global::System.Management.Automation.PSObject content)
        {
            bool returnNow = false;
            BeforeDeserializePSObject(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ITriggeredJobRunPropertiesInternal)this).WebJobId = (string) content.GetValueForProperty("WebJobId",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ITriggeredJobRunPropertiesInternal)this).WebJobId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ITriggeredJobRunPropertiesInternal)this).WebJobName = (string) content.GetValueForProperty("WebJobName",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ITriggeredJobRunPropertiesInternal)this).WebJobName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ITriggeredJobRunPropertiesInternal)this).Status = (Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.TriggeredWebJobStatus?) content.GetValueForProperty("Status",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ITriggeredJobRunPropertiesInternal)this).Status, Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.TriggeredWebJobStatus.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ITriggeredJobRunPropertiesInternal)this).StartTime = (global::System.DateTime?) content.GetValueForProperty("StartTime",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ITriggeredJobRunPropertiesInternal)this).StartTime, (v) => v is global::System.DateTime _v ? _v : global::System.Xml.XmlConvert.ToDateTime( v.ToString() , global::System.Xml.XmlDateTimeSerializationMode.Unspecified));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ITriggeredJobRunPropertiesInternal)this).EndTime = (global::System.DateTime?) content.GetValueForProperty("EndTime",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ITriggeredJobRunPropertiesInternal)this).EndTime, (v) => v is global::System.DateTime _v ? _v : global::System.Xml.XmlConvert.ToDateTime( v.ToString() , global::System.Xml.XmlDateTimeSerializationMode.Unspecified));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ITriggeredJobRunPropertiesInternal)this).Duration = (string) content.GetValueForProperty("Duration",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ITriggeredJobRunPropertiesInternal)this).Duration, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ITriggeredJobRunPropertiesInternal)this).OutputUrl = (string) content.GetValueForProperty("OutputUrl",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ITriggeredJobRunPropertiesInternal)this).OutputUrl, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ITriggeredJobRunPropertiesInternal)this).ErrorUrl = (string) content.GetValueForProperty("ErrorUrl",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ITriggeredJobRunPropertiesInternal)this).ErrorUrl, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ITriggeredJobRunPropertiesInternal)this).Url = (string) content.GetValueForProperty("Url",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ITriggeredJobRunPropertiesInternal)this).Url, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ITriggeredJobRunPropertiesInternal)this).JobName = (string) content.GetValueForProperty("JobName",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ITriggeredJobRunPropertiesInternal)this).JobName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ITriggeredJobRunPropertiesInternal)this).Trigger = (string) content.GetValueForProperty("Trigger",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ITriggeredJobRunPropertiesInternal)this).Trigger, global::System.Convert.ToString);
            AfterDeserializePSObject(content);
        }
    }
    /// TriggeredJobRun resource specific properties
    [System.ComponentModel.TypeConverter(typeof(TriggeredJobRunPropertiesTypeConverter))]
    public partial interface ITriggeredJobRunProperties

    {

    }
}