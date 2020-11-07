namespace Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801
{
    using Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.PowerShell;

    /// <summary>Rules that can be defined for auto-heal.</summary>
    [System.ComponentModel.TypeConverter(typeof(AutoHealRulesTypeConverter))]
    public partial class AutoHealRules
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
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.AutoHealRules"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        internal AutoHealRules(global::System.Collections.IDictionary content)
        {
            bool returnNow = false;
            BeforeDeserializeDictionary(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAutoHealRulesInternal)this).Action = (Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAutoHealActions) content.GetValueForProperty("Action",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAutoHealRulesInternal)this).Action, Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.AutoHealActionsTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAutoHealRulesInternal)this).Trigger = (Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAutoHealTriggers) content.GetValueForProperty("Trigger",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAutoHealRulesInternal)this).Trigger, Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.AutoHealTriggersTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAutoHealRulesInternal)this).TriggerPrivateBytesInKb = (int?) content.GetValueForProperty("TriggerPrivateBytesInKb",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAutoHealRulesInternal)this).TriggerPrivateBytesInKb, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAutoHealRulesInternal)this).ActionCustomAction = (Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAutoHealCustomAction) content.GetValueForProperty("ActionCustomAction",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAutoHealRulesInternal)this).ActionCustomAction, Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.AutoHealCustomActionTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAutoHealRulesInternal)this).ActionMinProcessExecutionTime = (string) content.GetValueForProperty("ActionMinProcessExecutionTime",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAutoHealRulesInternal)this).ActionMinProcessExecutionTime, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAutoHealRulesInternal)this).TriggerStatusCode = (Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IStatusCodesBasedTrigger[]) content.GetValueForProperty("TriggerStatusCode",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAutoHealRulesInternal)this).TriggerStatusCode, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IStatusCodesBasedTrigger>(__y, Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.StatusCodesBasedTriggerTypeConverter.ConvertFrom));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAutoHealRulesInternal)this).ActionType = (Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.AutoHealActionType?) content.GetValueForProperty("ActionType",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAutoHealRulesInternal)this).ActionType, Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.AutoHealActionType.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAutoHealRulesInternal)this).TriggerRequest = (Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IRequestsBasedTrigger) content.GetValueForProperty("TriggerRequest",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAutoHealRulesInternal)this).TriggerRequest, Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.RequestsBasedTriggerTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAutoHealRulesInternal)this).TriggerSlowRequest = (Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISlowRequestsBasedTrigger) content.GetValueForProperty("TriggerSlowRequest",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAutoHealRulesInternal)this).TriggerSlowRequest, Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.SlowRequestsBasedTriggerTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAutoHealRulesInternal)this).CustomActionParameter = (string) content.GetValueForProperty("CustomActionParameter",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAutoHealRulesInternal)this).CustomActionParameter, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAutoHealRulesInternal)this).CustomActionExe = (string) content.GetValueForProperty("CustomActionExe",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAutoHealRulesInternal)this).CustomActionExe, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAutoHealRulesInternal)this).RequestCount = (int?) content.GetValueForProperty("RequestCount",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAutoHealRulesInternal)this).RequestCount, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAutoHealRulesInternal)this).RequestTimeInterval = (string) content.GetValueForProperty("RequestTimeInterval",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAutoHealRulesInternal)this).RequestTimeInterval, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAutoHealRulesInternal)this).SlowRequestCount = (int?) content.GetValueForProperty("SlowRequestCount",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAutoHealRulesInternal)this).SlowRequestCount, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAutoHealRulesInternal)this).SlowRequestTimeInterval = (string) content.GetValueForProperty("SlowRequestTimeInterval",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAutoHealRulesInternal)this).SlowRequestTimeInterval, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAutoHealRulesInternal)this).SlowRequestTimeTaken = (string) content.GetValueForProperty("SlowRequestTimeTaken",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAutoHealRulesInternal)this).SlowRequestTimeTaken, global::System.Convert.ToString);
            AfterDeserializeDictionary(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.AutoHealRules"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        internal AutoHealRules(global::System.Management.Automation.PSObject content)
        {
            bool returnNow = false;
            BeforeDeserializePSObject(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAutoHealRulesInternal)this).Action = (Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAutoHealActions) content.GetValueForProperty("Action",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAutoHealRulesInternal)this).Action, Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.AutoHealActionsTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAutoHealRulesInternal)this).Trigger = (Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAutoHealTriggers) content.GetValueForProperty("Trigger",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAutoHealRulesInternal)this).Trigger, Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.AutoHealTriggersTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAutoHealRulesInternal)this).TriggerPrivateBytesInKb = (int?) content.GetValueForProperty("TriggerPrivateBytesInKb",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAutoHealRulesInternal)this).TriggerPrivateBytesInKb, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAutoHealRulesInternal)this).ActionCustomAction = (Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAutoHealCustomAction) content.GetValueForProperty("ActionCustomAction",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAutoHealRulesInternal)this).ActionCustomAction, Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.AutoHealCustomActionTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAutoHealRulesInternal)this).ActionMinProcessExecutionTime = (string) content.GetValueForProperty("ActionMinProcessExecutionTime",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAutoHealRulesInternal)this).ActionMinProcessExecutionTime, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAutoHealRulesInternal)this).TriggerStatusCode = (Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IStatusCodesBasedTrigger[]) content.GetValueForProperty("TriggerStatusCode",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAutoHealRulesInternal)this).TriggerStatusCode, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IStatusCodesBasedTrigger>(__y, Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.StatusCodesBasedTriggerTypeConverter.ConvertFrom));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAutoHealRulesInternal)this).ActionType = (Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.AutoHealActionType?) content.GetValueForProperty("ActionType",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAutoHealRulesInternal)this).ActionType, Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.AutoHealActionType.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAutoHealRulesInternal)this).TriggerRequest = (Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IRequestsBasedTrigger) content.GetValueForProperty("TriggerRequest",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAutoHealRulesInternal)this).TriggerRequest, Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.RequestsBasedTriggerTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAutoHealRulesInternal)this).TriggerSlowRequest = (Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISlowRequestsBasedTrigger) content.GetValueForProperty("TriggerSlowRequest",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAutoHealRulesInternal)this).TriggerSlowRequest, Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.SlowRequestsBasedTriggerTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAutoHealRulesInternal)this).CustomActionParameter = (string) content.GetValueForProperty("CustomActionParameter",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAutoHealRulesInternal)this).CustomActionParameter, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAutoHealRulesInternal)this).CustomActionExe = (string) content.GetValueForProperty("CustomActionExe",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAutoHealRulesInternal)this).CustomActionExe, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAutoHealRulesInternal)this).RequestCount = (int?) content.GetValueForProperty("RequestCount",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAutoHealRulesInternal)this).RequestCount, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAutoHealRulesInternal)this).RequestTimeInterval = (string) content.GetValueForProperty("RequestTimeInterval",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAutoHealRulesInternal)this).RequestTimeInterval, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAutoHealRulesInternal)this).SlowRequestCount = (int?) content.GetValueForProperty("SlowRequestCount",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAutoHealRulesInternal)this).SlowRequestCount, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAutoHealRulesInternal)this).SlowRequestTimeInterval = (string) content.GetValueForProperty("SlowRequestTimeInterval",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAutoHealRulesInternal)this).SlowRequestTimeInterval, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAutoHealRulesInternal)this).SlowRequestTimeTaken = (string) content.GetValueForProperty("SlowRequestTimeTaken",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAutoHealRulesInternal)this).SlowRequestTimeTaken, global::System.Convert.ToString);
            AfterDeserializePSObject(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.AutoHealRules"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAutoHealRules" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAutoHealRules DeserializeFromDictionary(global::System.Collections.IDictionary content)
        {
            return new AutoHealRules(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.AutoHealRules"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAutoHealRules" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAutoHealRules DeserializeFromPSObject(global::System.Management.Automation.PSObject content)
        {
            return new AutoHealRules(content);
        }

        /// <summary>
        /// Creates a new instance of <see cref="AutoHealRules" />, deserializing the content from a json string.
        /// </summary>
        /// <param name="jsonText">a string containing a JSON serialized instance of this model.</param>
        /// <returns>an instance of the <see cref="className" /> model class.</returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAutoHealRules FromJsonString(string jsonText) => FromJson(Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonNode.Parse(jsonText));

        /// <summary>Serializes this instance to a json string.</summary>

        /// <returns>a <see cref="System.String" /> containing this model serialized to JSON text.</returns>
        public string ToJsonString() => ToJson(null, Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.SerializationMode.IncludeAll)?.ToString();
    }
    /// Rules that can be defined for auto-heal.
    [System.ComponentModel.TypeConverter(typeof(AutoHealRulesTypeConverter))]
    public partial interface IAutoHealRules

    {

    }
}