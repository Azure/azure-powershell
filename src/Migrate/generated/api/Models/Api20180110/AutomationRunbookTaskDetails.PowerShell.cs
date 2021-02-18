namespace Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110
{
    using Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.PowerShell;

    /// <summary>This class represents the task details for an automation runbook.</summary>
    [System.ComponentModel.TypeConverter(typeof(AutomationRunbookTaskDetailsTypeConverter))]
    public partial class AutomationRunbookTaskDetails
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
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.AutomationRunbookTaskDetails"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        internal AutomationRunbookTaskDetails(global::System.Collections.IDictionary content)
        {
            bool returnNow = false;
            BeforeDeserializeDictionary(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IAutomationRunbookTaskDetailsInternal)this).Name = (string) content.GetValueForProperty("Name",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IAutomationRunbookTaskDetailsInternal)this).Name, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IAutomationRunbookTaskDetailsInternal)this).CloudServiceName = (string) content.GetValueForProperty("CloudServiceName",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IAutomationRunbookTaskDetailsInternal)this).CloudServiceName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IAutomationRunbookTaskDetailsInternal)this).SubscriptionId = (string) content.GetValueForProperty("SubscriptionId",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IAutomationRunbookTaskDetailsInternal)this).SubscriptionId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IAutomationRunbookTaskDetailsInternal)this).AccountName = (string) content.GetValueForProperty("AccountName",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IAutomationRunbookTaskDetailsInternal)this).AccountName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IAutomationRunbookTaskDetailsInternal)this).RunbookId = (string) content.GetValueForProperty("RunbookId",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IAutomationRunbookTaskDetailsInternal)this).RunbookId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IAutomationRunbookTaskDetailsInternal)this).RunbookName = (string) content.GetValueForProperty("RunbookName",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IAutomationRunbookTaskDetailsInternal)this).RunbookName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IAutomationRunbookTaskDetailsInternal)this).JobId = (string) content.GetValueForProperty("JobId",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IAutomationRunbookTaskDetailsInternal)this).JobId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IAutomationRunbookTaskDetailsInternal)this).JobOutput = (string) content.GetValueForProperty("JobOutput",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IAutomationRunbookTaskDetailsInternal)this).JobOutput, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IAutomationRunbookTaskDetailsInternal)this).IsPrimarySideScript = (bool?) content.GetValueForProperty("IsPrimarySideScript",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IAutomationRunbookTaskDetailsInternal)this).IsPrimarySideScript, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.ITaskTypeDetailsInternal)this).InstanceType = (string) content.GetValueForProperty("InstanceType",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.ITaskTypeDetailsInternal)this).InstanceType, global::System.Convert.ToString);
            AfterDeserializeDictionary(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.AutomationRunbookTaskDetails"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        internal AutomationRunbookTaskDetails(global::System.Management.Automation.PSObject content)
        {
            bool returnNow = false;
            BeforeDeserializePSObject(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IAutomationRunbookTaskDetailsInternal)this).Name = (string) content.GetValueForProperty("Name",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IAutomationRunbookTaskDetailsInternal)this).Name, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IAutomationRunbookTaskDetailsInternal)this).CloudServiceName = (string) content.GetValueForProperty("CloudServiceName",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IAutomationRunbookTaskDetailsInternal)this).CloudServiceName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IAutomationRunbookTaskDetailsInternal)this).SubscriptionId = (string) content.GetValueForProperty("SubscriptionId",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IAutomationRunbookTaskDetailsInternal)this).SubscriptionId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IAutomationRunbookTaskDetailsInternal)this).AccountName = (string) content.GetValueForProperty("AccountName",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IAutomationRunbookTaskDetailsInternal)this).AccountName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IAutomationRunbookTaskDetailsInternal)this).RunbookId = (string) content.GetValueForProperty("RunbookId",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IAutomationRunbookTaskDetailsInternal)this).RunbookId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IAutomationRunbookTaskDetailsInternal)this).RunbookName = (string) content.GetValueForProperty("RunbookName",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IAutomationRunbookTaskDetailsInternal)this).RunbookName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IAutomationRunbookTaskDetailsInternal)this).JobId = (string) content.GetValueForProperty("JobId",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IAutomationRunbookTaskDetailsInternal)this).JobId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IAutomationRunbookTaskDetailsInternal)this).JobOutput = (string) content.GetValueForProperty("JobOutput",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IAutomationRunbookTaskDetailsInternal)this).JobOutput, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IAutomationRunbookTaskDetailsInternal)this).IsPrimarySideScript = (bool?) content.GetValueForProperty("IsPrimarySideScript",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IAutomationRunbookTaskDetailsInternal)this).IsPrimarySideScript, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.ITaskTypeDetailsInternal)this).InstanceType = (string) content.GetValueForProperty("InstanceType",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.ITaskTypeDetailsInternal)this).InstanceType, global::System.Convert.ToString);
            AfterDeserializePSObject(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.AutomationRunbookTaskDetails"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IAutomationRunbookTaskDetails"
        /// />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IAutomationRunbookTaskDetails DeserializeFromDictionary(global::System.Collections.IDictionary content)
        {
            return new AutomationRunbookTaskDetails(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.AutomationRunbookTaskDetails"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IAutomationRunbookTaskDetails"
        /// />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IAutomationRunbookTaskDetails DeserializeFromPSObject(global::System.Management.Automation.PSObject content)
        {
            return new AutomationRunbookTaskDetails(content);
        }

        /// <summary>
        /// Creates a new instance of <see cref="AutomationRunbookTaskDetails" />, deserializing the content from a json string.
        /// </summary>
        /// <param name="jsonText">a string containing a JSON serialized instance of this model.</param>
        /// <returns>an instance of the <see cref="className" /> model class.</returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IAutomationRunbookTaskDetails FromJsonString(string jsonText) => FromJson(Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonNode.Parse(jsonText));

        /// <summary>Serializes this instance to a json string.</summary>

        /// <returns>a <see cref="System.String" /> containing this model serialized to JSON text.</returns>
        public string ToJsonString() => ToJson(null, Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.SerializationMode.IncludeAll)?.ToString();
    }
    /// This class represents the task details for an automation runbook.
    [System.ComponentModel.TypeConverter(typeof(AutomationRunbookTaskDetailsTypeConverter))]
    public partial interface IAutomationRunbookTaskDetails

    {

    }
}