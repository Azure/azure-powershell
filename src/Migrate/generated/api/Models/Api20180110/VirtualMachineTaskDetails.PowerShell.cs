namespace Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110
{
    using Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.PowerShell;

    /// <summary>This class represents the virtual machine task details.</summary>
    [System.ComponentModel.TypeConverter(typeof(VirtualMachineTaskDetailsTypeConverter))]
    public partial class VirtualMachineTaskDetails
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
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.VirtualMachineTaskDetails"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IVirtualMachineTaskDetails" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IVirtualMachineTaskDetails DeserializeFromDictionary(global::System.Collections.IDictionary content)
        {
            return new VirtualMachineTaskDetails(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.VirtualMachineTaskDetails"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IVirtualMachineTaskDetails" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IVirtualMachineTaskDetails DeserializeFromPSObject(global::System.Management.Automation.PSObject content)
        {
            return new VirtualMachineTaskDetails(content);
        }

        /// <summary>
        /// Creates a new instance of <see cref="VirtualMachineTaskDetails" />, deserializing the content from a json string.
        /// </summary>
        /// <param name="jsonText">a string containing a JSON serialized instance of this model.</param>
        /// <returns>an instance of the <see cref="className" /> model class.</returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IVirtualMachineTaskDetails FromJsonString(string jsonText) => FromJson(Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonNode.Parse(jsonText));

        /// <summary>Serializes this instance to a json string.</summary>

        /// <returns>a <see cref="System.String" /> containing this model serialized to JSON text.</returns>
        public string ToJsonString() => ToJson(null, Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.SerializationMode.IncludeAll)?.ToString();

        /// <summary>
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.VirtualMachineTaskDetails"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        internal VirtualMachineTaskDetails(global::System.Collections.IDictionary content)
        {
            bool returnNow = false;
            BeforeDeserializeDictionary(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IVirtualMachineTaskDetailsInternal)this).JobTask = (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IJobEntity) content.GetValueForProperty("JobTask",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IVirtualMachineTaskDetailsInternal)this).JobTask, Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.JobEntityTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IVirtualMachineTaskDetailsInternal)this).SkippedReason = (string) content.GetValueForProperty("SkippedReason",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IVirtualMachineTaskDetailsInternal)this).SkippedReason, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IVirtualMachineTaskDetailsInternal)this).SkippedReasonString = (string) content.GetValueForProperty("SkippedReasonString",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IVirtualMachineTaskDetailsInternal)this).SkippedReasonString, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.ITaskTypeDetailsInternal)this).InstanceType = (string) content.GetValueForProperty("InstanceType",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.ITaskTypeDetailsInternal)this).InstanceType, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IVirtualMachineTaskDetailsInternal)this).JobTaskJobId = (string) content.GetValueForProperty("JobTaskJobId",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IVirtualMachineTaskDetailsInternal)this).JobTaskJobId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IVirtualMachineTaskDetailsInternal)this).JobTaskJobFriendlyName = (string) content.GetValueForProperty("JobTaskJobFriendlyName",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IVirtualMachineTaskDetailsInternal)this).JobTaskJobFriendlyName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IVirtualMachineTaskDetailsInternal)this).JobTaskTargetObjectId = (string) content.GetValueForProperty("JobTaskTargetObjectId",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IVirtualMachineTaskDetailsInternal)this).JobTaskTargetObjectId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IVirtualMachineTaskDetailsInternal)this).JobTaskTargetObjectName = (string) content.GetValueForProperty("JobTaskTargetObjectName",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IVirtualMachineTaskDetailsInternal)this).JobTaskTargetObjectName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IVirtualMachineTaskDetailsInternal)this).JobTaskTargetInstanceType = (string) content.GetValueForProperty("JobTaskTargetInstanceType",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IVirtualMachineTaskDetailsInternal)this).JobTaskTargetInstanceType, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IVirtualMachineTaskDetailsInternal)this).JobTaskJobScenarioName = (string) content.GetValueForProperty("JobTaskJobScenarioName",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IVirtualMachineTaskDetailsInternal)this).JobTaskJobScenarioName, global::System.Convert.ToString);
            AfterDeserializeDictionary(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.VirtualMachineTaskDetails"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        internal VirtualMachineTaskDetails(global::System.Management.Automation.PSObject content)
        {
            bool returnNow = false;
            BeforeDeserializePSObject(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IVirtualMachineTaskDetailsInternal)this).JobTask = (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IJobEntity) content.GetValueForProperty("JobTask",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IVirtualMachineTaskDetailsInternal)this).JobTask, Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.JobEntityTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IVirtualMachineTaskDetailsInternal)this).SkippedReason = (string) content.GetValueForProperty("SkippedReason",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IVirtualMachineTaskDetailsInternal)this).SkippedReason, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IVirtualMachineTaskDetailsInternal)this).SkippedReasonString = (string) content.GetValueForProperty("SkippedReasonString",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IVirtualMachineTaskDetailsInternal)this).SkippedReasonString, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.ITaskTypeDetailsInternal)this).InstanceType = (string) content.GetValueForProperty("InstanceType",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.ITaskTypeDetailsInternal)this).InstanceType, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IVirtualMachineTaskDetailsInternal)this).JobTaskJobId = (string) content.GetValueForProperty("JobTaskJobId",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IVirtualMachineTaskDetailsInternal)this).JobTaskJobId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IVirtualMachineTaskDetailsInternal)this).JobTaskJobFriendlyName = (string) content.GetValueForProperty("JobTaskJobFriendlyName",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IVirtualMachineTaskDetailsInternal)this).JobTaskJobFriendlyName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IVirtualMachineTaskDetailsInternal)this).JobTaskTargetObjectId = (string) content.GetValueForProperty("JobTaskTargetObjectId",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IVirtualMachineTaskDetailsInternal)this).JobTaskTargetObjectId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IVirtualMachineTaskDetailsInternal)this).JobTaskTargetObjectName = (string) content.GetValueForProperty("JobTaskTargetObjectName",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IVirtualMachineTaskDetailsInternal)this).JobTaskTargetObjectName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IVirtualMachineTaskDetailsInternal)this).JobTaskTargetInstanceType = (string) content.GetValueForProperty("JobTaskTargetInstanceType",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IVirtualMachineTaskDetailsInternal)this).JobTaskTargetInstanceType, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IVirtualMachineTaskDetailsInternal)this).JobTaskJobScenarioName = (string) content.GetValueForProperty("JobTaskJobScenarioName",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IVirtualMachineTaskDetailsInternal)this).JobTaskJobScenarioName, global::System.Convert.ToString);
            AfterDeserializePSObject(content);
        }
    }
    /// This class represents the virtual machine task details.
    [System.ComponentModel.TypeConverter(typeof(VirtualMachineTaskDetailsTypeConverter))]
    public partial interface IVirtualMachineTaskDetails

    {

    }
}