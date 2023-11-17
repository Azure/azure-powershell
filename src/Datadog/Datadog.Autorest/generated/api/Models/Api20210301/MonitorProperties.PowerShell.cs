namespace Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301
{
    using Microsoft.Azure.PowerShell.Cmdlets.Datadog.Runtime.PowerShell;

    /// <summary>Properties specific to the monitor resource.</summary>
    [System.ComponentModel.TypeConverter(typeof(MonitorPropertiesTypeConverter))]
    public partial class MonitorProperties
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
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.MonitorProperties"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IMonitorProperties" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IMonitorProperties DeserializeFromDictionary(global::System.Collections.IDictionary content)
        {
            return new MonitorProperties(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.MonitorProperties"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IMonitorProperties" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IMonitorProperties DeserializeFromPSObject(global::System.Management.Automation.PSObject content)
        {
            return new MonitorProperties(content);
        }

        /// <summary>
        /// Creates a new instance of <see cref="MonitorProperties" />, deserializing the content from a json string.
        /// </summary>
        /// <param name="jsonText">a string containing a JSON serialized instance of this model.</param>
        /// <returns>an instance of the <see cref="className" /> model class.</returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IMonitorProperties FromJsonString(string jsonText) => FromJson(Microsoft.Azure.PowerShell.Cmdlets.Datadog.Runtime.Json.JsonNode.Parse(jsonText));

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.MonitorProperties"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        internal MonitorProperties(global::System.Management.Automation.PSObject content)
        {
            bool returnNow = false;
            BeforeDeserializePSObject(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IMonitorPropertiesInternal)this).DatadogOrganizationProperty = (Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IDatadogOrganizationProperties) content.GetValueForProperty("DatadogOrganizationProperty",((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IMonitorPropertiesInternal)this).DatadogOrganizationProperty, Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.DatadogOrganizationPropertiesTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IMonitorPropertiesInternal)this).UserInfo = (Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IUserInfo) content.GetValueForProperty("UserInfo",((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IMonitorPropertiesInternal)this).UserInfo, Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.UserInfoTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IMonitorPropertiesInternal)this).ProvisioningState = (Microsoft.Azure.PowerShell.Cmdlets.Datadog.Support.ProvisioningState?) content.GetValueForProperty("ProvisioningState",((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IMonitorPropertiesInternal)this).ProvisioningState, Microsoft.Azure.PowerShell.Cmdlets.Datadog.Support.ProvisioningState.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IMonitorPropertiesInternal)this).MonitoringStatus = (Microsoft.Azure.PowerShell.Cmdlets.Datadog.Support.MonitoringStatus?) content.GetValueForProperty("MonitoringStatus",((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IMonitorPropertiesInternal)this).MonitoringStatus, Microsoft.Azure.PowerShell.Cmdlets.Datadog.Support.MonitoringStatus.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IMonitorPropertiesInternal)this).MarketplaceSubscriptionStatus = (Microsoft.Azure.PowerShell.Cmdlets.Datadog.Support.MarketplaceSubscriptionStatus?) content.GetValueForProperty("MarketplaceSubscriptionStatus",((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IMonitorPropertiesInternal)this).MarketplaceSubscriptionStatus, Microsoft.Azure.PowerShell.Cmdlets.Datadog.Support.MarketplaceSubscriptionStatus.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IMonitorPropertiesInternal)this).LiftrResourceCategory = (Microsoft.Azure.PowerShell.Cmdlets.Datadog.Support.LiftrResourceCategories?) content.GetValueForProperty("LiftrResourceCategory",((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IMonitorPropertiesInternal)this).LiftrResourceCategory, Microsoft.Azure.PowerShell.Cmdlets.Datadog.Support.LiftrResourceCategories.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IMonitorPropertiesInternal)this).LiftrResourcePreference = (int?) content.GetValueForProperty("LiftrResourcePreference",((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IMonitorPropertiesInternal)this).LiftrResourcePreference, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IMonitorPropertiesInternal)this).DatadogOrganizationPropertyApiKey = (string) content.GetValueForProperty("DatadogOrganizationPropertyApiKey",((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IMonitorPropertiesInternal)this).DatadogOrganizationPropertyApiKey, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IMonitorPropertiesInternal)this).DatadogOrganizationPropertyName = (string) content.GetValueForProperty("DatadogOrganizationPropertyName",((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IMonitorPropertiesInternal)this).DatadogOrganizationPropertyName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IMonitorPropertiesInternal)this).UserInfoEmailAddress = (string) content.GetValueForProperty("UserInfoEmailAddress",((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IMonitorPropertiesInternal)this).UserInfoEmailAddress, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IMonitorPropertiesInternal)this).UserInfoName = (string) content.GetValueForProperty("UserInfoName",((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IMonitorPropertiesInternal)this).UserInfoName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IMonitorPropertiesInternal)this).DatadogOrganizationPropertyRedirectUri = (string) content.GetValueForProperty("DatadogOrganizationPropertyRedirectUri",((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IMonitorPropertiesInternal)this).DatadogOrganizationPropertyRedirectUri, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IMonitorPropertiesInternal)this).DatadogOrganizationPropertyId = (string) content.GetValueForProperty("DatadogOrganizationPropertyId",((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IMonitorPropertiesInternal)this).DatadogOrganizationPropertyId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IMonitorPropertiesInternal)this).DatadogOrganizationPropertyApplicationKey = (string) content.GetValueForProperty("DatadogOrganizationPropertyApplicationKey",((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IMonitorPropertiesInternal)this).DatadogOrganizationPropertyApplicationKey, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IMonitorPropertiesInternal)this).UserInfoPhoneNumber = (string) content.GetValueForProperty("UserInfoPhoneNumber",((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IMonitorPropertiesInternal)this).UserInfoPhoneNumber, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IMonitorPropertiesInternal)this).DatadogOrganizationPropertyEnterpriseAppId = (string) content.GetValueForProperty("DatadogOrganizationPropertyEnterpriseAppId",((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IMonitorPropertiesInternal)this).DatadogOrganizationPropertyEnterpriseAppId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IMonitorPropertiesInternal)this).DatadogOrganizationPropertyLinkingClientId = (string) content.GetValueForProperty("DatadogOrganizationPropertyLinkingClientId",((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IMonitorPropertiesInternal)this).DatadogOrganizationPropertyLinkingClientId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IMonitorPropertiesInternal)this).DatadogOrganizationPropertyLinkingAuthCode = (string) content.GetValueForProperty("DatadogOrganizationPropertyLinkingAuthCode",((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IMonitorPropertiesInternal)this).DatadogOrganizationPropertyLinkingAuthCode, global::System.Convert.ToString);
            AfterDeserializePSObject(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.MonitorProperties"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        internal MonitorProperties(global::System.Collections.IDictionary content)
        {
            bool returnNow = false;
            BeforeDeserializeDictionary(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IMonitorPropertiesInternal)this).DatadogOrganizationProperty = (Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IDatadogOrganizationProperties) content.GetValueForProperty("DatadogOrganizationProperty",((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IMonitorPropertiesInternal)this).DatadogOrganizationProperty, Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.DatadogOrganizationPropertiesTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IMonitorPropertiesInternal)this).UserInfo = (Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IUserInfo) content.GetValueForProperty("UserInfo",((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IMonitorPropertiesInternal)this).UserInfo, Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.UserInfoTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IMonitorPropertiesInternal)this).ProvisioningState = (Microsoft.Azure.PowerShell.Cmdlets.Datadog.Support.ProvisioningState?) content.GetValueForProperty("ProvisioningState",((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IMonitorPropertiesInternal)this).ProvisioningState, Microsoft.Azure.PowerShell.Cmdlets.Datadog.Support.ProvisioningState.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IMonitorPropertiesInternal)this).MonitoringStatus = (Microsoft.Azure.PowerShell.Cmdlets.Datadog.Support.MonitoringStatus?) content.GetValueForProperty("MonitoringStatus",((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IMonitorPropertiesInternal)this).MonitoringStatus, Microsoft.Azure.PowerShell.Cmdlets.Datadog.Support.MonitoringStatus.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IMonitorPropertiesInternal)this).MarketplaceSubscriptionStatus = (Microsoft.Azure.PowerShell.Cmdlets.Datadog.Support.MarketplaceSubscriptionStatus?) content.GetValueForProperty("MarketplaceSubscriptionStatus",((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IMonitorPropertiesInternal)this).MarketplaceSubscriptionStatus, Microsoft.Azure.PowerShell.Cmdlets.Datadog.Support.MarketplaceSubscriptionStatus.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IMonitorPropertiesInternal)this).LiftrResourceCategory = (Microsoft.Azure.PowerShell.Cmdlets.Datadog.Support.LiftrResourceCategories?) content.GetValueForProperty("LiftrResourceCategory",((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IMonitorPropertiesInternal)this).LiftrResourceCategory, Microsoft.Azure.PowerShell.Cmdlets.Datadog.Support.LiftrResourceCategories.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IMonitorPropertiesInternal)this).LiftrResourcePreference = (int?) content.GetValueForProperty("LiftrResourcePreference",((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IMonitorPropertiesInternal)this).LiftrResourcePreference, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IMonitorPropertiesInternal)this).DatadogOrganizationPropertyApiKey = (string) content.GetValueForProperty("DatadogOrganizationPropertyApiKey",((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IMonitorPropertiesInternal)this).DatadogOrganizationPropertyApiKey, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IMonitorPropertiesInternal)this).DatadogOrganizationPropertyName = (string) content.GetValueForProperty("DatadogOrganizationPropertyName",((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IMonitorPropertiesInternal)this).DatadogOrganizationPropertyName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IMonitorPropertiesInternal)this).UserInfoEmailAddress = (string) content.GetValueForProperty("UserInfoEmailAddress",((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IMonitorPropertiesInternal)this).UserInfoEmailAddress, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IMonitorPropertiesInternal)this).UserInfoName = (string) content.GetValueForProperty("UserInfoName",((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IMonitorPropertiesInternal)this).UserInfoName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IMonitorPropertiesInternal)this).DatadogOrganizationPropertyRedirectUri = (string) content.GetValueForProperty("DatadogOrganizationPropertyRedirectUri",((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IMonitorPropertiesInternal)this).DatadogOrganizationPropertyRedirectUri, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IMonitorPropertiesInternal)this).DatadogOrganizationPropertyId = (string) content.GetValueForProperty("DatadogOrganizationPropertyId",((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IMonitorPropertiesInternal)this).DatadogOrganizationPropertyId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IMonitorPropertiesInternal)this).DatadogOrganizationPropertyApplicationKey = (string) content.GetValueForProperty("DatadogOrganizationPropertyApplicationKey",((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IMonitorPropertiesInternal)this).DatadogOrganizationPropertyApplicationKey, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IMonitorPropertiesInternal)this).UserInfoPhoneNumber = (string) content.GetValueForProperty("UserInfoPhoneNumber",((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IMonitorPropertiesInternal)this).UserInfoPhoneNumber, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IMonitorPropertiesInternal)this).DatadogOrganizationPropertyEnterpriseAppId = (string) content.GetValueForProperty("DatadogOrganizationPropertyEnterpriseAppId",((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IMonitorPropertiesInternal)this).DatadogOrganizationPropertyEnterpriseAppId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IMonitorPropertiesInternal)this).DatadogOrganizationPropertyLinkingClientId = (string) content.GetValueForProperty("DatadogOrganizationPropertyLinkingClientId",((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IMonitorPropertiesInternal)this).DatadogOrganizationPropertyLinkingClientId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IMonitorPropertiesInternal)this).DatadogOrganizationPropertyLinkingAuthCode = (string) content.GetValueForProperty("DatadogOrganizationPropertyLinkingAuthCode",((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IMonitorPropertiesInternal)this).DatadogOrganizationPropertyLinkingAuthCode, global::System.Convert.ToString);
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
    /// Properties specific to the monitor resource.
    [System.ComponentModel.TypeConverter(typeof(MonitorPropertiesTypeConverter))]
    public partial interface IMonitorProperties

    {

    }
}