namespace Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301
{
    using Microsoft.Azure.PowerShell.Cmdlets.Datadog.Runtime.PowerShell;

    /// <summary>Definition of the properties for a TagRules resource.</summary>
    [System.ComponentModel.TypeConverter(typeof(MonitoringTagRulesPropertiesTypeConverter))]
    public partial class MonitoringTagRulesProperties
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
        /// <c>OverrideToString</c> will be called if it is implemented. Implement this method in a partial class to enable this behavior
        /// </summary>
        /// <param name="stringResult">/// instance serialized to a string, normally it is a Json</param>
        /// <param name="returnNow">/// set returnNow to true if you provide a customized OverrideToString function</param>

        partial void OverrideToString(ref string stringResult, ref bool returnNow);

        /// <summary>
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.MonitoringTagRulesProperties"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IMonitoringTagRulesProperties"
        /// />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IMonitoringTagRulesProperties DeserializeFromDictionary(global::System.Collections.IDictionary content)
        {
            return new MonitoringTagRulesProperties(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.MonitoringTagRulesProperties"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IMonitoringTagRulesProperties"
        /// />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IMonitoringTagRulesProperties DeserializeFromPSObject(global::System.Management.Automation.PSObject content)
        {
            return new MonitoringTagRulesProperties(content);
        }

        /// <summary>
        /// Creates a new instance of <see cref="MonitoringTagRulesProperties" />, deserializing the content from a json string.
        /// </summary>
        /// <param name="jsonText">a string containing a JSON serialized instance of this model.</param>
        /// <returns>an instance of the <see cref="className" /> model class.</returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IMonitoringTagRulesProperties FromJsonString(string jsonText) => FromJson(Microsoft.Azure.PowerShell.Cmdlets.Datadog.Runtime.Json.JsonNode.Parse(jsonText));

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.MonitoringTagRulesProperties"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        internal MonitoringTagRulesProperties(global::System.Management.Automation.PSObject content)
        {
            bool returnNow = false;
            BeforeDeserializePSObject(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IMonitoringTagRulesPropertiesInternal)this).LogRule = (Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.ILogRules) content.GetValueForProperty("LogRule",((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IMonitoringTagRulesPropertiesInternal)this).LogRule, Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.LogRulesTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IMonitoringTagRulesPropertiesInternal)this).MetricRule = (Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IMetricRules) content.GetValueForProperty("MetricRule",((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IMonitoringTagRulesPropertiesInternal)this).MetricRule, Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.MetricRulesTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IMonitoringTagRulesPropertiesInternal)this).ProvisioningState = (Microsoft.Azure.PowerShell.Cmdlets.Datadog.Support.ProvisioningState?) content.GetValueForProperty("ProvisioningState",((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IMonitoringTagRulesPropertiesInternal)this).ProvisioningState, Microsoft.Azure.PowerShell.Cmdlets.Datadog.Support.ProvisioningState.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IMonitoringTagRulesPropertiesInternal)this).LogRuleFilteringTag = (Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IFilteringTag[]) content.GetValueForProperty("LogRuleFilteringTag",((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IMonitoringTagRulesPropertiesInternal)this).LogRuleFilteringTag, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IFilteringTag>(__y, Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.FilteringTagTypeConverter.ConvertFrom));
            ((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IMonitoringTagRulesPropertiesInternal)this).MetricRuleFilteringTag = (Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IFilteringTag[]) content.GetValueForProperty("MetricRuleFilteringTag",((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IMonitoringTagRulesPropertiesInternal)this).MetricRuleFilteringTag, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IFilteringTag>(__y, Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.FilteringTagTypeConverter.ConvertFrom));
            ((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IMonitoringTagRulesPropertiesInternal)this).LogRuleSendAadLog = (bool?) content.GetValueForProperty("LogRuleSendAadLog",((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IMonitoringTagRulesPropertiesInternal)this).LogRuleSendAadLog, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IMonitoringTagRulesPropertiesInternal)this).LogRuleSendSubscriptionLog = (bool?) content.GetValueForProperty("LogRuleSendSubscriptionLog",((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IMonitoringTagRulesPropertiesInternal)this).LogRuleSendSubscriptionLog, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IMonitoringTagRulesPropertiesInternal)this).LogRuleSendResourceLog = (bool?) content.GetValueForProperty("LogRuleSendResourceLog",((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IMonitoringTagRulesPropertiesInternal)this).LogRuleSendResourceLog, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            AfterDeserializePSObject(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.MonitoringTagRulesProperties"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        internal MonitoringTagRulesProperties(global::System.Collections.IDictionary content)
        {
            bool returnNow = false;
            BeforeDeserializeDictionary(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IMonitoringTagRulesPropertiesInternal)this).LogRule = (Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.ILogRules) content.GetValueForProperty("LogRule",((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IMonitoringTagRulesPropertiesInternal)this).LogRule, Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.LogRulesTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IMonitoringTagRulesPropertiesInternal)this).MetricRule = (Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IMetricRules) content.GetValueForProperty("MetricRule",((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IMonitoringTagRulesPropertiesInternal)this).MetricRule, Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.MetricRulesTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IMonitoringTagRulesPropertiesInternal)this).ProvisioningState = (Microsoft.Azure.PowerShell.Cmdlets.Datadog.Support.ProvisioningState?) content.GetValueForProperty("ProvisioningState",((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IMonitoringTagRulesPropertiesInternal)this).ProvisioningState, Microsoft.Azure.PowerShell.Cmdlets.Datadog.Support.ProvisioningState.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IMonitoringTagRulesPropertiesInternal)this).LogRuleFilteringTag = (Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IFilteringTag[]) content.GetValueForProperty("LogRuleFilteringTag",((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IMonitoringTagRulesPropertiesInternal)this).LogRuleFilteringTag, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IFilteringTag>(__y, Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.FilteringTagTypeConverter.ConvertFrom));
            ((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IMonitoringTagRulesPropertiesInternal)this).MetricRuleFilteringTag = (Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IFilteringTag[]) content.GetValueForProperty("MetricRuleFilteringTag",((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IMonitoringTagRulesPropertiesInternal)this).MetricRuleFilteringTag, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IFilteringTag>(__y, Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.FilteringTagTypeConverter.ConvertFrom));
            ((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IMonitoringTagRulesPropertiesInternal)this).LogRuleSendAadLog = (bool?) content.GetValueForProperty("LogRuleSendAadLog",((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IMonitoringTagRulesPropertiesInternal)this).LogRuleSendAadLog, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IMonitoringTagRulesPropertiesInternal)this).LogRuleSendSubscriptionLog = (bool?) content.GetValueForProperty("LogRuleSendSubscriptionLog",((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IMonitoringTagRulesPropertiesInternal)this).LogRuleSendSubscriptionLog, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IMonitoringTagRulesPropertiesInternal)this).LogRuleSendResourceLog = (bool?) content.GetValueForProperty("LogRuleSendResourceLog",((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IMonitoringTagRulesPropertiesInternal)this).LogRuleSendResourceLog, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            AfterDeserializeDictionary(content);
        }

        /// <summary>Serializes this instance to a json string.</summary>

        /// <returns>a <see cref="System.String" /> containing this model serialized to JSON text.</returns>
        public string ToJsonString() => ToJson(null, Microsoft.Azure.PowerShell.Cmdlets.Datadog.Runtime.SerializationMode.IncludeAll)?.ToString();

        public override string ToString()
        {
            var returnNow = false;
            var result = global::System.String.Empty;
            OverrideToString(ref result, ref returnNow);
            if (returnNow)
            {
                return result;
            }
            return ToJsonString();
        }
    }
    /// Definition of the properties for a TagRules resource.
    [System.ComponentModel.TypeConverter(typeof(MonitoringTagRulesPropertiesTypeConverter))]
    public partial interface IMonitoringTagRulesProperties

    {

    }
}