namespace Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110
{
    using Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.PowerShell;

    /// <summary>Job details.</summary>
    [System.ComponentModel.TypeConverter(typeof(JobTypeConverter))]
    public partial class Job
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
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.Job"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IJob" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IJob DeserializeFromDictionary(global::System.Collections.IDictionary content)
        {
            return new Job(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.Job"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IJob" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IJob DeserializeFromPSObject(global::System.Management.Automation.PSObject content)
        {
            return new Job(content);
        }

        /// <summary>
        /// Creates a new instance of <see cref="Job" />, deserializing the content from a json string.
        /// </summary>
        /// <param name="jsonText">a string containing a JSON serialized instance of this model.</param>
        /// <returns>an instance of the <see cref="className" /> model class.</returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IJob FromJsonString(string jsonText) => FromJson(Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonNode.Parse(jsonText));

        /// <summary>
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.Job"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        internal Job(global::System.Collections.IDictionary content)
        {
            bool returnNow = false;
            BeforeDeserializeDictionary(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IJobInternal)this).Property = (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IJobPropertiesAutoGenerated) content.GetValueForProperty("Property",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IJobInternal)this).Property, Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.JobPropertiesAutoGeneratedTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IResourceInternal)this).Id = (string) content.GetValueForProperty("Id",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IResourceInternal)this).Id, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IResourceInternal)this).Name = (string) content.GetValueForProperty("Name",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IResourceInternal)this).Name, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IResourceInternal)this).Type = (string) content.GetValueForProperty("Type",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IResourceInternal)this).Type, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IResourceInternal)this).Location = (string) content.GetValueForProperty("Location",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IResourceInternal)this).Location, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IJobInternal)this).StartTime = (global::System.DateTime?) content.GetValueForProperty("StartTime",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IJobInternal)this).StartTime, (v) => v is global::System.DateTime _v ? _v : global::System.Xml.XmlConvert.ToDateTime( v.ToString() , global::System.Xml.XmlDateTimeSerializationMode.Unspecified));
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IJobInternal)this).CustomDetail = (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IJobDetails) content.GetValueForProperty("CustomDetail",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IJobInternal)this).CustomDetail, Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.JobDetailsTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IJobInternal)this).ScenarioName = (string) content.GetValueForProperty("ScenarioName",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IJobInternal)this).ScenarioName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IJobInternal)this).FriendlyName = (string) content.GetValueForProperty("FriendlyName",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IJobInternal)this).FriendlyName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IJobInternal)this).State = (string) content.GetValueForProperty("State",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IJobInternal)this).State, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IJobInternal)this).StateDescription = (string) content.GetValueForProperty("StateDescription",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IJobInternal)this).StateDescription, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IJobInternal)this).Task = (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IAsrTask[]) content.GetValueForProperty("Task",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IJobInternal)this).Task, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IAsrTask>(__y, Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.AsrTaskTypeConverter.ConvertFrom));
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IJobInternal)this).Error = (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IJobErrorDetails[]) content.GetValueForProperty("Error",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IJobInternal)this).Error, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IJobErrorDetails>(__y, Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.JobErrorDetailsTypeConverter.ConvertFrom));
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IJobInternal)this).ActivityId = (string) content.GetValueForProperty("ActivityId",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IJobInternal)this).ActivityId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IJobInternal)this).EndTime = (global::System.DateTime?) content.GetValueForProperty("EndTime",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IJobInternal)this).EndTime, (v) => v is global::System.DateTime _v ? _v : global::System.Xml.XmlConvert.ToDateTime( v.ToString() , global::System.Xml.XmlDateTimeSerializationMode.Unspecified));
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IJobInternal)this).AllowedAction = (string[]) content.GetValueForProperty("AllowedAction",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IJobInternal)this).AllowedAction, __y => TypeConverterExtensions.SelectToArray<string>(__y, global::System.Convert.ToString));
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IJobInternal)this).TargetObjectId = (string) content.GetValueForProperty("TargetObjectId",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IJobInternal)this).TargetObjectId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IJobInternal)this).TargetObjectName = (string) content.GetValueForProperty("TargetObjectName",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IJobInternal)this).TargetObjectName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IJobInternal)this).TargetInstanceType = (string) content.GetValueForProperty("TargetInstanceType",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IJobInternal)this).TargetInstanceType, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IJobInternal)this).CustomDetailInstanceType = (string) content.GetValueForProperty("CustomDetailInstanceType",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IJobInternal)this).CustomDetailInstanceType, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IJobInternal)this).CustomDetailAffectedObjectDetail = (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IJobDetailsAffectedObjectDetails) content.GetValueForProperty("CustomDetailAffectedObjectDetail",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IJobInternal)this).CustomDetailAffectedObjectDetail, Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.JobDetailsAffectedObjectDetailsTypeConverter.ConvertFrom);
            AfterDeserializeDictionary(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.Job"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        internal Job(global::System.Management.Automation.PSObject content)
        {
            bool returnNow = false;
            BeforeDeserializePSObject(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IJobInternal)this).Property = (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IJobPropertiesAutoGenerated) content.GetValueForProperty("Property",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IJobInternal)this).Property, Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.JobPropertiesAutoGeneratedTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IResourceInternal)this).Id = (string) content.GetValueForProperty("Id",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IResourceInternal)this).Id, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IResourceInternal)this).Name = (string) content.GetValueForProperty("Name",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IResourceInternal)this).Name, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IResourceInternal)this).Type = (string) content.GetValueForProperty("Type",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IResourceInternal)this).Type, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IResourceInternal)this).Location = (string) content.GetValueForProperty("Location",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IResourceInternal)this).Location, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IJobInternal)this).StartTime = (global::System.DateTime?) content.GetValueForProperty("StartTime",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IJobInternal)this).StartTime, (v) => v is global::System.DateTime _v ? _v : global::System.Xml.XmlConvert.ToDateTime( v.ToString() , global::System.Xml.XmlDateTimeSerializationMode.Unspecified));
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IJobInternal)this).CustomDetail = (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IJobDetails) content.GetValueForProperty("CustomDetail",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IJobInternal)this).CustomDetail, Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.JobDetailsTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IJobInternal)this).ScenarioName = (string) content.GetValueForProperty("ScenarioName",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IJobInternal)this).ScenarioName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IJobInternal)this).FriendlyName = (string) content.GetValueForProperty("FriendlyName",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IJobInternal)this).FriendlyName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IJobInternal)this).State = (string) content.GetValueForProperty("State",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IJobInternal)this).State, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IJobInternal)this).StateDescription = (string) content.GetValueForProperty("StateDescription",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IJobInternal)this).StateDescription, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IJobInternal)this).Task = (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IAsrTask[]) content.GetValueForProperty("Task",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IJobInternal)this).Task, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IAsrTask>(__y, Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.AsrTaskTypeConverter.ConvertFrom));
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IJobInternal)this).Error = (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IJobErrorDetails[]) content.GetValueForProperty("Error",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IJobInternal)this).Error, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IJobErrorDetails>(__y, Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.JobErrorDetailsTypeConverter.ConvertFrom));
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IJobInternal)this).ActivityId = (string) content.GetValueForProperty("ActivityId",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IJobInternal)this).ActivityId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IJobInternal)this).EndTime = (global::System.DateTime?) content.GetValueForProperty("EndTime",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IJobInternal)this).EndTime, (v) => v is global::System.DateTime _v ? _v : global::System.Xml.XmlConvert.ToDateTime( v.ToString() , global::System.Xml.XmlDateTimeSerializationMode.Unspecified));
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IJobInternal)this).AllowedAction = (string[]) content.GetValueForProperty("AllowedAction",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IJobInternal)this).AllowedAction, __y => TypeConverterExtensions.SelectToArray<string>(__y, global::System.Convert.ToString));
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IJobInternal)this).TargetObjectId = (string) content.GetValueForProperty("TargetObjectId",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IJobInternal)this).TargetObjectId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IJobInternal)this).TargetObjectName = (string) content.GetValueForProperty("TargetObjectName",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IJobInternal)this).TargetObjectName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IJobInternal)this).TargetInstanceType = (string) content.GetValueForProperty("TargetInstanceType",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IJobInternal)this).TargetInstanceType, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IJobInternal)this).CustomDetailInstanceType = (string) content.GetValueForProperty("CustomDetailInstanceType",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IJobInternal)this).CustomDetailInstanceType, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IJobInternal)this).CustomDetailAffectedObjectDetail = (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IJobDetailsAffectedObjectDetails) content.GetValueForProperty("CustomDetailAffectedObjectDetail",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IJobInternal)this).CustomDetailAffectedObjectDetail, Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.JobDetailsAffectedObjectDetailsTypeConverter.ConvertFrom);
            AfterDeserializePSObject(content);
        }

        /// <summary>Serializes this instance to a json string.</summary>

        /// <returns>a <see cref="System.String" /> containing this model serialized to JSON text.</returns>
        public string ToJsonString() => ToJson(null, Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.SerializationMode.IncludeAll)?.ToString();
    }
    /// Job details.
    [System.ComponentModel.TypeConverter(typeof(JobTypeConverter))]
    public partial interface IJob

    {

    }
}