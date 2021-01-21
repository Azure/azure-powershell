namespace Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110
{
    using Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.PowerShell;

    /// <summary>
    /// This class represents a task which is actually a workflow so that one can navigate to its individual drill down.
    /// </summary>
    [System.ComponentModel.TypeConverter(typeof(JobTaskDetailsTypeConverter))]
    public partial class JobTaskDetails
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
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.JobTaskDetails"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IJobTaskDetails" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IJobTaskDetails DeserializeFromDictionary(global::System.Collections.IDictionary content)
        {
            return new JobTaskDetails(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.JobTaskDetails"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IJobTaskDetails" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IJobTaskDetails DeserializeFromPSObject(global::System.Management.Automation.PSObject content)
        {
            return new JobTaskDetails(content);
        }

        /// <summary>
        /// Creates a new instance of <see cref="JobTaskDetails" />, deserializing the content from a json string.
        /// </summary>
        /// <param name="jsonText">a string containing a JSON serialized instance of this model.</param>
        /// <returns>an instance of the <see cref="className" /> model class.</returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IJobTaskDetails FromJsonString(string jsonText) => FromJson(Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonNode.Parse(jsonText));

        /// <summary>
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.JobTaskDetails"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        internal JobTaskDetails(global::System.Collections.IDictionary content)
        {
            bool returnNow = false;
            BeforeDeserializeDictionary(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IJobTaskDetailsInternal)this).JobTask = (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IJobEntity) content.GetValueForProperty("JobTask",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IJobTaskDetailsInternal)this).JobTask, Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.JobEntityTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.ITaskTypeDetailsInternal)this).InstanceType = (string) content.GetValueForProperty("InstanceType",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.ITaskTypeDetailsInternal)this).InstanceType, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IJobTaskDetailsInternal)this).JobTaskJobId = (string) content.GetValueForProperty("JobTaskJobId",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IJobTaskDetailsInternal)this).JobTaskJobId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IJobTaskDetailsInternal)this).JobTaskJobFriendlyName = (string) content.GetValueForProperty("JobTaskJobFriendlyName",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IJobTaskDetailsInternal)this).JobTaskJobFriendlyName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IJobTaskDetailsInternal)this).JobTaskTargetObjectId = (string) content.GetValueForProperty("JobTaskTargetObjectId",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IJobTaskDetailsInternal)this).JobTaskTargetObjectId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IJobTaskDetailsInternal)this).JobTaskTargetObjectName = (string) content.GetValueForProperty("JobTaskTargetObjectName",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IJobTaskDetailsInternal)this).JobTaskTargetObjectName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IJobTaskDetailsInternal)this).JobTaskTargetInstanceType = (string) content.GetValueForProperty("JobTaskTargetInstanceType",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IJobTaskDetailsInternal)this).JobTaskTargetInstanceType, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IJobTaskDetailsInternal)this).JobTaskJobScenarioName = (string) content.GetValueForProperty("JobTaskJobScenarioName",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IJobTaskDetailsInternal)this).JobTaskJobScenarioName, global::System.Convert.ToString);
            AfterDeserializeDictionary(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.JobTaskDetails"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        internal JobTaskDetails(global::System.Management.Automation.PSObject content)
        {
            bool returnNow = false;
            BeforeDeserializePSObject(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IJobTaskDetailsInternal)this).JobTask = (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IJobEntity) content.GetValueForProperty("JobTask",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IJobTaskDetailsInternal)this).JobTask, Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.JobEntityTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.ITaskTypeDetailsInternal)this).InstanceType = (string) content.GetValueForProperty("InstanceType",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.ITaskTypeDetailsInternal)this).InstanceType, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IJobTaskDetailsInternal)this).JobTaskJobId = (string) content.GetValueForProperty("JobTaskJobId",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IJobTaskDetailsInternal)this).JobTaskJobId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IJobTaskDetailsInternal)this).JobTaskJobFriendlyName = (string) content.GetValueForProperty("JobTaskJobFriendlyName",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IJobTaskDetailsInternal)this).JobTaskJobFriendlyName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IJobTaskDetailsInternal)this).JobTaskTargetObjectId = (string) content.GetValueForProperty("JobTaskTargetObjectId",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IJobTaskDetailsInternal)this).JobTaskTargetObjectId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IJobTaskDetailsInternal)this).JobTaskTargetObjectName = (string) content.GetValueForProperty("JobTaskTargetObjectName",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IJobTaskDetailsInternal)this).JobTaskTargetObjectName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IJobTaskDetailsInternal)this).JobTaskTargetInstanceType = (string) content.GetValueForProperty("JobTaskTargetInstanceType",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IJobTaskDetailsInternal)this).JobTaskTargetInstanceType, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IJobTaskDetailsInternal)this).JobTaskJobScenarioName = (string) content.GetValueForProperty("JobTaskJobScenarioName",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IJobTaskDetailsInternal)this).JobTaskJobScenarioName, global::System.Convert.ToString);
            AfterDeserializePSObject(content);
        }

        /// <summary>Serializes this instance to a json string.</summary>

        /// <returns>a <see cref="System.String" /> containing this model serialized to JSON text.</returns>
        public string ToJsonString() => ToJson(null, Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.SerializationMode.IncludeAll)?.ToString();
    }
    /// This class represents a task which is actually a workflow so that one can navigate to its individual drill down.
    [System.ComponentModel.TypeConverter(typeof(JobTaskDetailsTypeConverter))]
    public partial interface IJobTaskDetails

    {

    }
}