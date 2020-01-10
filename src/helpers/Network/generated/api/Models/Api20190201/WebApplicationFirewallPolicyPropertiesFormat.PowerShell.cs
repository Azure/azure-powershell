namespace Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201
{
    using Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.PowerShell;

    /// <summary>Defines web application firewall policy properties</summary>
    [System.ComponentModel.TypeConverter(typeof(WebApplicationFirewallPolicyPropertiesFormatTypeConverter))]
    public partial class WebApplicationFirewallPolicyPropertiesFormat
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
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.WebApplicationFirewallPolicyPropertiesFormat"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IWebApplicationFirewallPolicyPropertiesFormat"
        /// />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IWebApplicationFirewallPolicyPropertiesFormat DeserializeFromDictionary(global::System.Collections.IDictionary content)
        {
            return new WebApplicationFirewallPolicyPropertiesFormat(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.WebApplicationFirewallPolicyPropertiesFormat"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IWebApplicationFirewallPolicyPropertiesFormat"
        /// />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IWebApplicationFirewallPolicyPropertiesFormat DeserializeFromPSObject(global::System.Management.Automation.PSObject content)
        {
            return new WebApplicationFirewallPolicyPropertiesFormat(content);
        }

        /// <summary>
        /// Creates a new instance of <see cref="WebApplicationFirewallPolicyPropertiesFormat" />, deserializing the content from
        /// a json string.
        /// </summary>
        /// <param name="jsonText">a string containing a JSON serialized instance of this model.</param>
        /// <returns>an instance of the <see cref="className" /> model class.</returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IWebApplicationFirewallPolicyPropertiesFormat FromJsonString(string jsonText) => FromJson(Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonNode.Parse(jsonText));

        /// <summary>Serializes this instance to a json string.</summary>

        /// <returns>a <see cref="System.String" /> containing this model serialized to JSON text.</returns>
        public string ToJsonString() => ToJson(null, Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.SerializationMode.IncludeAll)?.ToString();

        /// <summary>
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.WebApplicationFirewallPolicyPropertiesFormat"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        internal WebApplicationFirewallPolicyPropertiesFormat(global::System.Collections.IDictionary content)
        {
            bool returnNow = false;
            BeforeDeserializeDictionary(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IWebApplicationFirewallPolicyPropertiesFormatInternal)this).PolicySetting = (Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPolicySettings) content.GetValueForProperty("PolicySetting",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IWebApplicationFirewallPolicyPropertiesFormatInternal)this).PolicySetting, Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.PolicySettingsTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IWebApplicationFirewallPolicyPropertiesFormatInternal)this).ApplicationGateway = (Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IApplicationGateway[]) content.GetValueForProperty("ApplicationGateway",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IWebApplicationFirewallPolicyPropertiesFormatInternal)this).ApplicationGateway, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IApplicationGateway>(__y, Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ApplicationGatewayTypeConverter.ConvertFrom));
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IWebApplicationFirewallPolicyPropertiesFormatInternal)this).CustomRule = (Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IWebApplicationFirewallCustomRule[]) content.GetValueForProperty("CustomRule",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IWebApplicationFirewallPolicyPropertiesFormatInternal)this).CustomRule, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IWebApplicationFirewallCustomRule>(__y, Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.WebApplicationFirewallCustomRuleTypeConverter.ConvertFrom));
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IWebApplicationFirewallPolicyPropertiesFormatInternal)this).ProvisioningState = (string) content.GetValueForProperty("ProvisioningState",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IWebApplicationFirewallPolicyPropertiesFormatInternal)this).ProvisioningState, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IWebApplicationFirewallPolicyPropertiesFormatInternal)this).ResourceState = (Microsoft.Azure.PowerShell.Cmdlets.Network.Support.WebApplicationFirewallPolicyResourceState?) content.GetValueForProperty("ResourceState",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IWebApplicationFirewallPolicyPropertiesFormatInternal)this).ResourceState, Microsoft.Azure.PowerShell.Cmdlets.Network.Support.WebApplicationFirewallPolicyResourceState.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IWebApplicationFirewallPolicyPropertiesFormatInternal)this).PolicySettingEnabledState = (Microsoft.Azure.PowerShell.Cmdlets.Network.Support.WebApplicationFirewallEnabledState?) content.GetValueForProperty("PolicySettingEnabledState",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IWebApplicationFirewallPolicyPropertiesFormatInternal)this).PolicySettingEnabledState, Microsoft.Azure.PowerShell.Cmdlets.Network.Support.WebApplicationFirewallEnabledState.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IWebApplicationFirewallPolicyPropertiesFormatInternal)this).PolicySettingMode = (Microsoft.Azure.PowerShell.Cmdlets.Network.Support.WebApplicationFirewallMode?) content.GetValueForProperty("PolicySettingMode",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IWebApplicationFirewallPolicyPropertiesFormatInternal)this).PolicySettingMode, Microsoft.Azure.PowerShell.Cmdlets.Network.Support.WebApplicationFirewallMode.CreateFrom);
            AfterDeserializeDictionary(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.WebApplicationFirewallPolicyPropertiesFormat"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        internal WebApplicationFirewallPolicyPropertiesFormat(global::System.Management.Automation.PSObject content)
        {
            bool returnNow = false;
            BeforeDeserializePSObject(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IWebApplicationFirewallPolicyPropertiesFormatInternal)this).PolicySetting = (Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPolicySettings) content.GetValueForProperty("PolicySetting",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IWebApplicationFirewallPolicyPropertiesFormatInternal)this).PolicySetting, Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.PolicySettingsTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IWebApplicationFirewallPolicyPropertiesFormatInternal)this).ApplicationGateway = (Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IApplicationGateway[]) content.GetValueForProperty("ApplicationGateway",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IWebApplicationFirewallPolicyPropertiesFormatInternal)this).ApplicationGateway, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IApplicationGateway>(__y, Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ApplicationGatewayTypeConverter.ConvertFrom));
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IWebApplicationFirewallPolicyPropertiesFormatInternal)this).CustomRule = (Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IWebApplicationFirewallCustomRule[]) content.GetValueForProperty("CustomRule",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IWebApplicationFirewallPolicyPropertiesFormatInternal)this).CustomRule, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IWebApplicationFirewallCustomRule>(__y, Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.WebApplicationFirewallCustomRuleTypeConverter.ConvertFrom));
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IWebApplicationFirewallPolicyPropertiesFormatInternal)this).ProvisioningState = (string) content.GetValueForProperty("ProvisioningState",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IWebApplicationFirewallPolicyPropertiesFormatInternal)this).ProvisioningState, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IWebApplicationFirewallPolicyPropertiesFormatInternal)this).ResourceState = (Microsoft.Azure.PowerShell.Cmdlets.Network.Support.WebApplicationFirewallPolicyResourceState?) content.GetValueForProperty("ResourceState",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IWebApplicationFirewallPolicyPropertiesFormatInternal)this).ResourceState, Microsoft.Azure.PowerShell.Cmdlets.Network.Support.WebApplicationFirewallPolicyResourceState.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IWebApplicationFirewallPolicyPropertiesFormatInternal)this).PolicySettingEnabledState = (Microsoft.Azure.PowerShell.Cmdlets.Network.Support.WebApplicationFirewallEnabledState?) content.GetValueForProperty("PolicySettingEnabledState",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IWebApplicationFirewallPolicyPropertiesFormatInternal)this).PolicySettingEnabledState, Microsoft.Azure.PowerShell.Cmdlets.Network.Support.WebApplicationFirewallEnabledState.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IWebApplicationFirewallPolicyPropertiesFormatInternal)this).PolicySettingMode = (Microsoft.Azure.PowerShell.Cmdlets.Network.Support.WebApplicationFirewallMode?) content.GetValueForProperty("PolicySettingMode",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IWebApplicationFirewallPolicyPropertiesFormatInternal)this).PolicySettingMode, Microsoft.Azure.PowerShell.Cmdlets.Network.Support.WebApplicationFirewallMode.CreateFrom);
            AfterDeserializePSObject(content);
        }
    }
    /// Defines web application firewall policy properties
    [System.ComponentModel.TypeConverter(typeof(WebApplicationFirewallPolicyPropertiesFormatTypeConverter))]
    public partial interface IWebApplicationFirewallPolicyPropertiesFormat

    {

    }
}