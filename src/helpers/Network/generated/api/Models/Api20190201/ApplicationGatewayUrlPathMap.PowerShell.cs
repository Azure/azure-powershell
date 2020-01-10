namespace Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201
{
    using Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.PowerShell;

    /// <summary>
    /// UrlPathMaps give a url path to the backend mapping information for PathBasedRouting.
    /// </summary>
    [System.ComponentModel.TypeConverter(typeof(ApplicationGatewayUrlPathMapTypeConverter))]
    public partial class ApplicationGatewayUrlPathMap
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
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ApplicationGatewayUrlPathMap"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        internal ApplicationGatewayUrlPathMap(global::System.Collections.IDictionary content)
        {
            bool returnNow = false;
            BeforeDeserializeDictionary(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IApplicationGatewayUrlPathMapInternal)this).Property = (Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IApplicationGatewayUrlPathMapPropertiesFormat) content.GetValueForProperty("Property",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IApplicationGatewayUrlPathMapInternal)this).Property, Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ApplicationGatewayUrlPathMapPropertiesFormatTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IApplicationGatewayUrlPathMapInternal)this).Name = (string) content.GetValueForProperty("Name",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IApplicationGatewayUrlPathMapInternal)this).Name, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IApplicationGatewayUrlPathMapInternal)this).Type = (string) content.GetValueForProperty("Type",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IApplicationGatewayUrlPathMapInternal)this).Type, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IApplicationGatewayUrlPathMapInternal)this).Etag = (string) content.GetValueForProperty("Etag",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IApplicationGatewayUrlPathMapInternal)this).Etag, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubResourceInternal)this).Id = (string) content.GetValueForProperty("Id",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubResourceInternal)this).Id, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IApplicationGatewayUrlPathMapInternal)this).DefaultBackendAddressPool = (Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubResource) content.GetValueForProperty("DefaultBackendAddressPool",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IApplicationGatewayUrlPathMapInternal)this).DefaultBackendAddressPool, Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.SubResourceTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IApplicationGatewayUrlPathMapInternal)this).DefaultBackendHttpSetting = (Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubResource) content.GetValueForProperty("DefaultBackendHttpSetting",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IApplicationGatewayUrlPathMapInternal)this).DefaultBackendHttpSetting, Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.SubResourceTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IApplicationGatewayUrlPathMapInternal)this).DefaultRedirectConfiguration = (Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubResource) content.GetValueForProperty("DefaultRedirectConfiguration",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IApplicationGatewayUrlPathMapInternal)this).DefaultRedirectConfiguration, Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.SubResourceTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IApplicationGatewayUrlPathMapInternal)this).DefaultRewriteRuleSet = (Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubResource) content.GetValueForProperty("DefaultRewriteRuleSet",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IApplicationGatewayUrlPathMapInternal)this).DefaultRewriteRuleSet, Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.SubResourceTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IApplicationGatewayUrlPathMapInternal)this).PathRule = (Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IApplicationGatewayPathRule[]) content.GetValueForProperty("PathRule",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IApplicationGatewayUrlPathMapInternal)this).PathRule, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IApplicationGatewayPathRule>(__y, Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ApplicationGatewayPathRuleTypeConverter.ConvertFrom));
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IApplicationGatewayUrlPathMapInternal)this).ProvisioningState = (string) content.GetValueForProperty("ProvisioningState",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IApplicationGatewayUrlPathMapInternal)this).ProvisioningState, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IApplicationGatewayUrlPathMapInternal)this).DefaultBackendAddressPoolId = (string) content.GetValueForProperty("DefaultBackendAddressPoolId",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IApplicationGatewayUrlPathMapInternal)this).DefaultBackendAddressPoolId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IApplicationGatewayUrlPathMapInternal)this).DefaultBackendHttpSettingId = (string) content.GetValueForProperty("DefaultBackendHttpSettingId",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IApplicationGatewayUrlPathMapInternal)this).DefaultBackendHttpSettingId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IApplicationGatewayUrlPathMapInternal)this).DefaultRedirectConfigurationId = (string) content.GetValueForProperty("DefaultRedirectConfigurationId",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IApplicationGatewayUrlPathMapInternal)this).DefaultRedirectConfigurationId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IApplicationGatewayUrlPathMapInternal)this).DefaultRewriteRuleSetId = (string) content.GetValueForProperty("DefaultRewriteRuleSetId",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IApplicationGatewayUrlPathMapInternal)this).DefaultRewriteRuleSetId, global::System.Convert.ToString);
            AfterDeserializeDictionary(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ApplicationGatewayUrlPathMap"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        internal ApplicationGatewayUrlPathMap(global::System.Management.Automation.PSObject content)
        {
            bool returnNow = false;
            BeforeDeserializePSObject(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IApplicationGatewayUrlPathMapInternal)this).Property = (Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IApplicationGatewayUrlPathMapPropertiesFormat) content.GetValueForProperty("Property",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IApplicationGatewayUrlPathMapInternal)this).Property, Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ApplicationGatewayUrlPathMapPropertiesFormatTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IApplicationGatewayUrlPathMapInternal)this).Name = (string) content.GetValueForProperty("Name",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IApplicationGatewayUrlPathMapInternal)this).Name, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IApplicationGatewayUrlPathMapInternal)this).Type = (string) content.GetValueForProperty("Type",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IApplicationGatewayUrlPathMapInternal)this).Type, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IApplicationGatewayUrlPathMapInternal)this).Etag = (string) content.GetValueForProperty("Etag",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IApplicationGatewayUrlPathMapInternal)this).Etag, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubResourceInternal)this).Id = (string) content.GetValueForProperty("Id",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubResourceInternal)this).Id, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IApplicationGatewayUrlPathMapInternal)this).DefaultBackendAddressPool = (Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubResource) content.GetValueForProperty("DefaultBackendAddressPool",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IApplicationGatewayUrlPathMapInternal)this).DefaultBackendAddressPool, Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.SubResourceTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IApplicationGatewayUrlPathMapInternal)this).DefaultBackendHttpSetting = (Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubResource) content.GetValueForProperty("DefaultBackendHttpSetting",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IApplicationGatewayUrlPathMapInternal)this).DefaultBackendHttpSetting, Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.SubResourceTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IApplicationGatewayUrlPathMapInternal)this).DefaultRedirectConfiguration = (Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubResource) content.GetValueForProperty("DefaultRedirectConfiguration",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IApplicationGatewayUrlPathMapInternal)this).DefaultRedirectConfiguration, Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.SubResourceTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IApplicationGatewayUrlPathMapInternal)this).DefaultRewriteRuleSet = (Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubResource) content.GetValueForProperty("DefaultRewriteRuleSet",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IApplicationGatewayUrlPathMapInternal)this).DefaultRewriteRuleSet, Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.SubResourceTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IApplicationGatewayUrlPathMapInternal)this).PathRule = (Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IApplicationGatewayPathRule[]) content.GetValueForProperty("PathRule",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IApplicationGatewayUrlPathMapInternal)this).PathRule, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IApplicationGatewayPathRule>(__y, Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ApplicationGatewayPathRuleTypeConverter.ConvertFrom));
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IApplicationGatewayUrlPathMapInternal)this).ProvisioningState = (string) content.GetValueForProperty("ProvisioningState",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IApplicationGatewayUrlPathMapInternal)this).ProvisioningState, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IApplicationGatewayUrlPathMapInternal)this).DefaultBackendAddressPoolId = (string) content.GetValueForProperty("DefaultBackendAddressPoolId",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IApplicationGatewayUrlPathMapInternal)this).DefaultBackendAddressPoolId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IApplicationGatewayUrlPathMapInternal)this).DefaultBackendHttpSettingId = (string) content.GetValueForProperty("DefaultBackendHttpSettingId",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IApplicationGatewayUrlPathMapInternal)this).DefaultBackendHttpSettingId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IApplicationGatewayUrlPathMapInternal)this).DefaultRedirectConfigurationId = (string) content.GetValueForProperty("DefaultRedirectConfigurationId",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IApplicationGatewayUrlPathMapInternal)this).DefaultRedirectConfigurationId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IApplicationGatewayUrlPathMapInternal)this).DefaultRewriteRuleSetId = (string) content.GetValueForProperty("DefaultRewriteRuleSetId",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IApplicationGatewayUrlPathMapInternal)this).DefaultRewriteRuleSetId, global::System.Convert.ToString);
            AfterDeserializePSObject(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ApplicationGatewayUrlPathMap"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IApplicationGatewayUrlPathMap"
        /// />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IApplicationGatewayUrlPathMap DeserializeFromDictionary(global::System.Collections.IDictionary content)
        {
            return new ApplicationGatewayUrlPathMap(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ApplicationGatewayUrlPathMap"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IApplicationGatewayUrlPathMap"
        /// />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IApplicationGatewayUrlPathMap DeserializeFromPSObject(global::System.Management.Automation.PSObject content)
        {
            return new ApplicationGatewayUrlPathMap(content);
        }

        /// <summary>
        /// Creates a new instance of <see cref="ApplicationGatewayUrlPathMap" />, deserializing the content from a json string.
        /// </summary>
        /// <param name="jsonText">a string containing a JSON serialized instance of this model.</param>
        /// <returns>an instance of the <see cref="className" /> model class.</returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IApplicationGatewayUrlPathMap FromJsonString(string jsonText) => FromJson(Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonNode.Parse(jsonText));

        /// <summary>Serializes this instance to a json string.</summary>

        /// <returns>a <see cref="System.String" /> containing this model serialized to JSON text.</returns>
        public string ToJsonString() => ToJson(null, Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.SerializationMode.IncludeAll)?.ToString();
    }
    /// UrlPathMaps give a url path to the backend mapping information for PathBasedRouting.
    [System.ComponentModel.TypeConverter(typeof(ApplicationGatewayUrlPathMapTypeConverter))]
    public partial interface IApplicationGatewayUrlPathMap

    {

    }
}