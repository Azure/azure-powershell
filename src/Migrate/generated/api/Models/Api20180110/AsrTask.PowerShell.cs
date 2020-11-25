namespace Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110
{
    using Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.PowerShell;

    /// <summary>Task of the Job.</summary>
    [System.ComponentModel.TypeConverter(typeof(AsrTaskTypeConverter))]
    public partial class AsrTask
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
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.AsrTask"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        internal AsrTask(global::System.Collections.IDictionary content)
        {
            bool returnNow = false;
            BeforeDeserializeDictionary(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IAsrTaskInternal)this).CustomDetail = (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.ITaskTypeDetails) content.GetValueForProperty("CustomDetail",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IAsrTaskInternal)this).CustomDetail, Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.TaskTypeDetailsTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IAsrTaskInternal)this).GroupTaskCustomDetail = (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IGroupTaskDetails) content.GetValueForProperty("GroupTaskCustomDetail",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IAsrTaskInternal)this).GroupTaskCustomDetail, Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.GroupTaskDetailsTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IAsrTaskInternal)this).TaskId = (string) content.GetValueForProperty("TaskId",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IAsrTaskInternal)this).TaskId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IAsrTaskInternal)this).Name = (string) content.GetValueForProperty("Name",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IAsrTaskInternal)this).Name, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IAsrTaskInternal)this).StartTime = (global::System.DateTime?) content.GetValueForProperty("StartTime",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IAsrTaskInternal)this).StartTime, (v) => v is global::System.DateTime _v ? _v : global::System.Xml.XmlConvert.ToDateTime( v.ToString() , global::System.Xml.XmlDateTimeSerializationMode.Unspecified));
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IAsrTaskInternal)this).EndTime = (global::System.DateTime?) content.GetValueForProperty("EndTime",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IAsrTaskInternal)this).EndTime, (v) => v is global::System.DateTime _v ? _v : global::System.Xml.XmlConvert.ToDateTime( v.ToString() , global::System.Xml.XmlDateTimeSerializationMode.Unspecified));
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IAsrTaskInternal)this).AllowedAction = (string[]) content.GetValueForProperty("AllowedAction",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IAsrTaskInternal)this).AllowedAction, __y => TypeConverterExtensions.SelectToArray<string>(__y, global::System.Convert.ToString));
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IAsrTaskInternal)this).FriendlyName = (string) content.GetValueForProperty("FriendlyName",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IAsrTaskInternal)this).FriendlyName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IAsrTaskInternal)this).State = (string) content.GetValueForProperty("State",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IAsrTaskInternal)this).State, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IAsrTaskInternal)this).StateDescription = (string) content.GetValueForProperty("StateDescription",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IAsrTaskInternal)this).StateDescription, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IAsrTaskInternal)this).TaskType = (string) content.GetValueForProperty("TaskType",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IAsrTaskInternal)this).TaskType, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IAsrTaskInternal)this).Error = (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IJobErrorDetails[]) content.GetValueForProperty("Error",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IAsrTaskInternal)this).Error, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IJobErrorDetails>(__y, Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.JobErrorDetailsTypeConverter.ConvertFrom));
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IAsrTaskInternal)this).CustomDetailInstanceType = (string) content.GetValueForProperty("CustomDetailInstanceType",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IAsrTaskInternal)this).CustomDetailInstanceType, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IAsrTaskInternal)this).GroupTaskCustomDetailInstanceType = (string) content.GetValueForProperty("GroupTaskCustomDetailInstanceType",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IAsrTaskInternal)this).GroupTaskCustomDetailInstanceType, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IAsrTaskInternal)this).GroupTaskCustomDetailChildTask = (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IAsrTask[]) content.GetValueForProperty("GroupTaskCustomDetailChildTask",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IAsrTaskInternal)this).GroupTaskCustomDetailChildTask, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IAsrTask>(__y, Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.AsrTaskTypeConverter.ConvertFrom));
            AfterDeserializeDictionary(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.AsrTask"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        internal AsrTask(global::System.Management.Automation.PSObject content)
        {
            bool returnNow = false;
            BeforeDeserializePSObject(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IAsrTaskInternal)this).CustomDetail = (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.ITaskTypeDetails) content.GetValueForProperty("CustomDetail",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IAsrTaskInternal)this).CustomDetail, Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.TaskTypeDetailsTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IAsrTaskInternal)this).GroupTaskCustomDetail = (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IGroupTaskDetails) content.GetValueForProperty("GroupTaskCustomDetail",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IAsrTaskInternal)this).GroupTaskCustomDetail, Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.GroupTaskDetailsTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IAsrTaskInternal)this).TaskId = (string) content.GetValueForProperty("TaskId",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IAsrTaskInternal)this).TaskId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IAsrTaskInternal)this).Name = (string) content.GetValueForProperty("Name",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IAsrTaskInternal)this).Name, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IAsrTaskInternal)this).StartTime = (global::System.DateTime?) content.GetValueForProperty("StartTime",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IAsrTaskInternal)this).StartTime, (v) => v is global::System.DateTime _v ? _v : global::System.Xml.XmlConvert.ToDateTime( v.ToString() , global::System.Xml.XmlDateTimeSerializationMode.Unspecified));
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IAsrTaskInternal)this).EndTime = (global::System.DateTime?) content.GetValueForProperty("EndTime",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IAsrTaskInternal)this).EndTime, (v) => v is global::System.DateTime _v ? _v : global::System.Xml.XmlConvert.ToDateTime( v.ToString() , global::System.Xml.XmlDateTimeSerializationMode.Unspecified));
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IAsrTaskInternal)this).AllowedAction = (string[]) content.GetValueForProperty("AllowedAction",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IAsrTaskInternal)this).AllowedAction, __y => TypeConverterExtensions.SelectToArray<string>(__y, global::System.Convert.ToString));
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IAsrTaskInternal)this).FriendlyName = (string) content.GetValueForProperty("FriendlyName",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IAsrTaskInternal)this).FriendlyName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IAsrTaskInternal)this).State = (string) content.GetValueForProperty("State",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IAsrTaskInternal)this).State, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IAsrTaskInternal)this).StateDescription = (string) content.GetValueForProperty("StateDescription",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IAsrTaskInternal)this).StateDescription, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IAsrTaskInternal)this).TaskType = (string) content.GetValueForProperty("TaskType",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IAsrTaskInternal)this).TaskType, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IAsrTaskInternal)this).Error = (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IJobErrorDetails[]) content.GetValueForProperty("Error",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IAsrTaskInternal)this).Error, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IJobErrorDetails>(__y, Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.JobErrorDetailsTypeConverter.ConvertFrom));
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IAsrTaskInternal)this).CustomDetailInstanceType = (string) content.GetValueForProperty("CustomDetailInstanceType",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IAsrTaskInternal)this).CustomDetailInstanceType, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IAsrTaskInternal)this).GroupTaskCustomDetailInstanceType = (string) content.GetValueForProperty("GroupTaskCustomDetailInstanceType",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IAsrTaskInternal)this).GroupTaskCustomDetailInstanceType, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IAsrTaskInternal)this).GroupTaskCustomDetailChildTask = (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IAsrTask[]) content.GetValueForProperty("GroupTaskCustomDetailChildTask",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IAsrTaskInternal)this).GroupTaskCustomDetailChildTask, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IAsrTask>(__y, Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.AsrTaskTypeConverter.ConvertFrom));
            AfterDeserializePSObject(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.AsrTask"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IAsrTask" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IAsrTask DeserializeFromDictionary(global::System.Collections.IDictionary content)
        {
            return new AsrTask(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.AsrTask"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IAsrTask" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IAsrTask DeserializeFromPSObject(global::System.Management.Automation.PSObject content)
        {
            return new AsrTask(content);
        }

        /// <summary>
        /// Creates a new instance of <see cref="AsrTask" />, deserializing the content from a json string.
        /// </summary>
        /// <param name="jsonText">a string containing a JSON serialized instance of this model.</param>
        /// <returns>an instance of the <see cref="className" /> model class.</returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IAsrTask FromJsonString(string jsonText) => FromJson(Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonNode.Parse(jsonText));

        /// <summary>Serializes this instance to a json string.</summary>

        /// <returns>a <see cref="System.String" /> containing this model serialized to JSON text.</returns>
        public string ToJsonString() => ToJson(null, Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.SerializationMode.IncludeAll)?.ToString();
    }
    /// Task of the Job.
    [System.ComponentModel.TypeConverter(typeof(AsrTaskTypeConverter))]
    public partial interface IAsrTask

    {

    }
}