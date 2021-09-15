namespace Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301
{
    using Microsoft.Azure.PowerShell.Cmdlets.Datadog.Runtime.PowerShell;

    /// <summary>Capture logs and metrics of Azure resources based on ARM tags.</summary>
    [System.ComponentModel.TypeConverter(typeof(MonitoringTagRulesTypeConverter))]
    public partial class MonitoringTagRules
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
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.MonitoringTagRules"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IMonitoringTagRules" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IMonitoringTagRules DeserializeFromDictionary(global::System.Collections.IDictionary content)
        {
            return new MonitoringTagRules(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.MonitoringTagRules"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IMonitoringTagRules" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IMonitoringTagRules DeserializeFromPSObject(global::System.Management.Automation.PSObject content)
        {
            return new MonitoringTagRules(content);
        }

        /// <summary>
        /// Creates a new instance of <see cref="MonitoringTagRules" />, deserializing the content from a json string.
        /// </summary>
        /// <param name="jsonText">a string containing a JSON serialized instance of this model.</param>
        /// <returns>an instance of the <see cref="className" /> model class.</returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IMonitoringTagRules FromJsonString(string jsonText) => FromJson(Microsoft.Azure.PowerShell.Cmdlets.Datadog.Runtime.Json.JsonNode.Parse(jsonText));

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.MonitoringTagRules"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        internal MonitoringTagRules(global::System.Management.Automation.PSObject content)
        {
            bool returnNow = false;
            BeforeDeserializePSObject(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IMonitoringTagRulesInternal)this).Property = (Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IMonitoringTagRulesProperties) content.GetValueForProperty("Property",((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IMonitoringTagRulesInternal)this).Property, Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.MonitoringTagRulesPropertiesTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IMonitoringTagRulesInternal)this).SystemData = (Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20.ISystemData) content.GetValueForProperty("SystemData",((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IMonitoringTagRulesInternal)this).SystemData, Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20.SystemDataTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IMonitoringTagRulesInternal)this).Name = (string) content.GetValueForProperty("Name",((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IMonitoringTagRulesInternal)this).Name, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IMonitoringTagRulesInternal)this).Id = (string) content.GetValueForProperty("Id",((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IMonitoringTagRulesInternal)this).Id, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IMonitoringTagRulesInternal)this).Type = (string) content.GetValueForProperty("Type",((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IMonitoringTagRulesInternal)this).Type, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IMonitoringTagRulesInternal)this).LogRule = (Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.ILogRules) content.GetValueForProperty("LogRule",((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IMonitoringTagRulesInternal)this).LogRule, Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.LogRulesTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IMonitoringTagRulesInternal)this).ProvisioningState = (Microsoft.Azure.PowerShell.Cmdlets.Datadog.Support.ProvisioningState?) content.GetValueForProperty("ProvisioningState",((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IMonitoringTagRulesInternal)this).ProvisioningState, Microsoft.Azure.PowerShell.Cmdlets.Datadog.Support.ProvisioningState.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IMonitoringTagRulesInternal)this).MetricRule = (Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IMetricRules) content.GetValueForProperty("MetricRule",((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IMonitoringTagRulesInternal)this).MetricRule, Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.MetricRulesTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IMonitoringTagRulesInternal)this).SystemDataCreatedBy = (string) content.GetValueForProperty("SystemDataCreatedBy",((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IMonitoringTagRulesInternal)this).SystemDataCreatedBy, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IMonitoringTagRulesInternal)this).SystemDataCreatedAt = (global::System.DateTime?) content.GetValueForProperty("SystemDataCreatedAt",((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IMonitoringTagRulesInternal)this).SystemDataCreatedAt, (v) => v is global::System.DateTime _v ? _v : global::System.Xml.XmlConvert.ToDateTime( v.ToString() , global::System.Xml.XmlDateTimeSerializationMode.Unspecified));
            ((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IMonitoringTagRulesInternal)this).SystemDataLastModifiedByType = (Microsoft.Azure.PowerShell.Cmdlets.Datadog.Support.CreatedByType?) content.GetValueForProperty("SystemDataLastModifiedByType",((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IMonitoringTagRulesInternal)this).SystemDataLastModifiedByType, Microsoft.Azure.PowerShell.Cmdlets.Datadog.Support.CreatedByType.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IMonitoringTagRulesInternal)this).SystemDataLastModifiedBy = (string) content.GetValueForProperty("SystemDataLastModifiedBy",((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IMonitoringTagRulesInternal)this).SystemDataLastModifiedBy, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IMonitoringTagRulesInternal)this).SystemDataLastModifiedAt = (global::System.DateTime?) content.GetValueForProperty("SystemDataLastModifiedAt",((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IMonitoringTagRulesInternal)this).SystemDataLastModifiedAt, (v) => v is global::System.DateTime _v ? _v : global::System.Xml.XmlConvert.ToDateTime( v.ToString() , global::System.Xml.XmlDateTimeSerializationMode.Unspecified));
            ((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IMonitoringTagRulesInternal)this).LogRuleFilteringTag = (Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IFilteringTag[]) content.GetValueForProperty("LogRuleFilteringTag",((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IMonitoringTagRulesInternal)this).LogRuleFilteringTag, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IFilteringTag>(__y, Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.FilteringTagTypeConverter.ConvertFrom));
            ((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IMonitoringTagRulesInternal)this).SystemDataCreatedByType = (Microsoft.Azure.PowerShell.Cmdlets.Datadog.Support.CreatedByType?) content.GetValueForProperty("SystemDataCreatedByType",((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IMonitoringTagRulesInternal)this).SystemDataCreatedByType, Microsoft.Azure.PowerShell.Cmdlets.Datadog.Support.CreatedByType.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IMonitoringTagRulesInternal)this).MetricRuleFilteringTag = (Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IFilteringTag[]) content.GetValueForProperty("MetricRuleFilteringTag",((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IMonitoringTagRulesInternal)this).MetricRuleFilteringTag, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IFilteringTag>(__y, Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.FilteringTagTypeConverter.ConvertFrom));
            ((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IMonitoringTagRulesInternal)this).LogRuleSendSubscriptionLog = (bool?) content.GetValueForProperty("LogRuleSendSubscriptionLog",((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IMonitoringTagRulesInternal)this).LogRuleSendSubscriptionLog, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IMonitoringTagRulesInternal)this).LogRuleSendAadLog = (bool?) content.GetValueForProperty("LogRuleSendAadLog",((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IMonitoringTagRulesInternal)this).LogRuleSendAadLog, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IMonitoringTagRulesInternal)this).LogRuleSendResourceLog = (bool?) content.GetValueForProperty("LogRuleSendResourceLog",((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IMonitoringTagRulesInternal)this).LogRuleSendResourceLog, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            AfterDeserializePSObject(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.MonitoringTagRules"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        internal MonitoringTagRules(global::System.Collections.IDictionary content)
        {
            bool returnNow = false;
            BeforeDeserializeDictionary(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IMonitoringTagRulesInternal)this).Property = (Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IMonitoringTagRulesProperties) content.GetValueForProperty("Property",((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IMonitoringTagRulesInternal)this).Property, Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.MonitoringTagRulesPropertiesTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IMonitoringTagRulesInternal)this).SystemData = (Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20.ISystemData) content.GetValueForProperty("SystemData",((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IMonitoringTagRulesInternal)this).SystemData, Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20.SystemDataTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IMonitoringTagRulesInternal)this).Name = (string) content.GetValueForProperty("Name",((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IMonitoringTagRulesInternal)this).Name, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IMonitoringTagRulesInternal)this).Id = (string) content.GetValueForProperty("Id",((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IMonitoringTagRulesInternal)this).Id, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IMonitoringTagRulesInternal)this).Type = (string) content.GetValueForProperty("Type",((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IMonitoringTagRulesInternal)this).Type, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IMonitoringTagRulesInternal)this).LogRule = (Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.ILogRules) content.GetValueForProperty("LogRule",((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IMonitoringTagRulesInternal)this).LogRule, Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.LogRulesTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IMonitoringTagRulesInternal)this).ProvisioningState = (Microsoft.Azure.PowerShell.Cmdlets.Datadog.Support.ProvisioningState?) content.GetValueForProperty("ProvisioningState",((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IMonitoringTagRulesInternal)this).ProvisioningState, Microsoft.Azure.PowerShell.Cmdlets.Datadog.Support.ProvisioningState.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IMonitoringTagRulesInternal)this).MetricRule = (Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IMetricRules) content.GetValueForProperty("MetricRule",((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IMonitoringTagRulesInternal)this).MetricRule, Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.MetricRulesTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IMonitoringTagRulesInternal)this).SystemDataCreatedBy = (string) content.GetValueForProperty("SystemDataCreatedBy",((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IMonitoringTagRulesInternal)this).SystemDataCreatedBy, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IMonitoringTagRulesInternal)this).SystemDataCreatedAt = (global::System.DateTime?) content.GetValueForProperty("SystemDataCreatedAt",((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IMonitoringTagRulesInternal)this).SystemDataCreatedAt, (v) => v is global::System.DateTime _v ? _v : global::System.Xml.XmlConvert.ToDateTime( v.ToString() , global::System.Xml.XmlDateTimeSerializationMode.Unspecified));
            ((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IMonitoringTagRulesInternal)this).SystemDataLastModifiedByType = (Microsoft.Azure.PowerShell.Cmdlets.Datadog.Support.CreatedByType?) content.GetValueForProperty("SystemDataLastModifiedByType",((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IMonitoringTagRulesInternal)this).SystemDataLastModifiedByType, Microsoft.Azure.PowerShell.Cmdlets.Datadog.Support.CreatedByType.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IMonitoringTagRulesInternal)this).SystemDataLastModifiedBy = (string) content.GetValueForProperty("SystemDataLastModifiedBy",((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IMonitoringTagRulesInternal)this).SystemDataLastModifiedBy, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IMonitoringTagRulesInternal)this).SystemDataLastModifiedAt = (global::System.DateTime?) content.GetValueForProperty("SystemDataLastModifiedAt",((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IMonitoringTagRulesInternal)this).SystemDataLastModifiedAt, (v) => v is global::System.DateTime _v ? _v : global::System.Xml.XmlConvert.ToDateTime( v.ToString() , global::System.Xml.XmlDateTimeSerializationMode.Unspecified));
            ((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IMonitoringTagRulesInternal)this).LogRuleFilteringTag = (Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IFilteringTag[]) content.GetValueForProperty("LogRuleFilteringTag",((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IMonitoringTagRulesInternal)this).LogRuleFilteringTag, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IFilteringTag>(__y, Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.FilteringTagTypeConverter.ConvertFrom));
            ((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IMonitoringTagRulesInternal)this).SystemDataCreatedByType = (Microsoft.Azure.PowerShell.Cmdlets.Datadog.Support.CreatedByType?) content.GetValueForProperty("SystemDataCreatedByType",((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IMonitoringTagRulesInternal)this).SystemDataCreatedByType, Microsoft.Azure.PowerShell.Cmdlets.Datadog.Support.CreatedByType.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IMonitoringTagRulesInternal)this).MetricRuleFilteringTag = (Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IFilteringTag[]) content.GetValueForProperty("MetricRuleFilteringTag",((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IMonitoringTagRulesInternal)this).MetricRuleFilteringTag, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IFilteringTag>(__y, Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.FilteringTagTypeConverter.ConvertFrom));
            ((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IMonitoringTagRulesInternal)this).LogRuleSendSubscriptionLog = (bool?) content.GetValueForProperty("LogRuleSendSubscriptionLog",((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IMonitoringTagRulesInternal)this).LogRuleSendSubscriptionLog, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IMonitoringTagRulesInternal)this).LogRuleSendAadLog = (bool?) content.GetValueForProperty("LogRuleSendAadLog",((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IMonitoringTagRulesInternal)this).LogRuleSendAadLog, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IMonitoringTagRulesInternal)this).LogRuleSendResourceLog = (bool?) content.GetValueForProperty("LogRuleSendResourceLog",((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IMonitoringTagRulesInternal)this).LogRuleSendResourceLog, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
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
    /// Capture logs and metrics of Azure resources based on ARM tags.
    [System.ComponentModel.TypeConverter(typeof(MonitoringTagRulesTypeConverter))]
    public partial interface IMonitoringTagRules

    {

    }
}