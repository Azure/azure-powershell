namespace Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201
{
    using Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.PowerShell;

    /// <summary>Properties of redirect configuration of the application gateway.</summary>
    [System.ComponentModel.TypeConverter(typeof(ApplicationGatewayRedirectConfigurationPropertiesFormatTypeConverter))]
    public partial class ApplicationGatewayRedirectConfigurationPropertiesFormat
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
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ApplicationGatewayRedirectConfigurationPropertiesFormat"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        internal ApplicationGatewayRedirectConfigurationPropertiesFormat(global::System.Collections.IDictionary content)
        {
            bool returnNow = false;
            BeforeDeserializeDictionary(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IApplicationGatewayRedirectConfigurationPropertiesFormatInternal)this).TargetListener = (Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubResource) content.GetValueForProperty("TargetListener",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IApplicationGatewayRedirectConfigurationPropertiesFormatInternal)this).TargetListener, Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.SubResourceTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IApplicationGatewayRedirectConfigurationPropertiesFormatInternal)this).IncludePath = (bool?) content.GetValueForProperty("IncludePath",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IApplicationGatewayRedirectConfigurationPropertiesFormatInternal)this).IncludePath, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IApplicationGatewayRedirectConfigurationPropertiesFormatInternal)this).IncludeQueryString = (bool?) content.GetValueForProperty("IncludeQueryString",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IApplicationGatewayRedirectConfigurationPropertiesFormatInternal)this).IncludeQueryString, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IApplicationGatewayRedirectConfigurationPropertiesFormatInternal)this).PathRule = (Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubResource[]) content.GetValueForProperty("PathRule",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IApplicationGatewayRedirectConfigurationPropertiesFormatInternal)this).PathRule, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubResource>(__y, Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.SubResourceTypeConverter.ConvertFrom));
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IApplicationGatewayRedirectConfigurationPropertiesFormatInternal)this).RedirectType = (Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ApplicationGatewayRedirectType?) content.GetValueForProperty("RedirectType",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IApplicationGatewayRedirectConfigurationPropertiesFormatInternal)this).RedirectType, Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ApplicationGatewayRedirectType.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IApplicationGatewayRedirectConfigurationPropertiesFormatInternal)this).RequestRoutingRule = (Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubResource[]) content.GetValueForProperty("RequestRoutingRule",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IApplicationGatewayRedirectConfigurationPropertiesFormatInternal)this).RequestRoutingRule, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubResource>(__y, Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.SubResourceTypeConverter.ConvertFrom));
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IApplicationGatewayRedirectConfigurationPropertiesFormatInternal)this).TargetUrl = (string) content.GetValueForProperty("TargetUrl",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IApplicationGatewayRedirectConfigurationPropertiesFormatInternal)this).TargetUrl, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IApplicationGatewayRedirectConfigurationPropertiesFormatInternal)this).UrlPathMap = (Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubResource[]) content.GetValueForProperty("UrlPathMap",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IApplicationGatewayRedirectConfigurationPropertiesFormatInternal)this).UrlPathMap, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubResource>(__y, Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.SubResourceTypeConverter.ConvertFrom));
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IApplicationGatewayRedirectConfigurationPropertiesFormatInternal)this).TargetListenerId = (string) content.GetValueForProperty("TargetListenerId",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IApplicationGatewayRedirectConfigurationPropertiesFormatInternal)this).TargetListenerId, global::System.Convert.ToString);
            AfterDeserializeDictionary(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ApplicationGatewayRedirectConfigurationPropertiesFormat"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        internal ApplicationGatewayRedirectConfigurationPropertiesFormat(global::System.Management.Automation.PSObject content)
        {
            bool returnNow = false;
            BeforeDeserializePSObject(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IApplicationGatewayRedirectConfigurationPropertiesFormatInternal)this).TargetListener = (Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubResource) content.GetValueForProperty("TargetListener",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IApplicationGatewayRedirectConfigurationPropertiesFormatInternal)this).TargetListener, Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.SubResourceTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IApplicationGatewayRedirectConfigurationPropertiesFormatInternal)this).IncludePath = (bool?) content.GetValueForProperty("IncludePath",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IApplicationGatewayRedirectConfigurationPropertiesFormatInternal)this).IncludePath, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IApplicationGatewayRedirectConfigurationPropertiesFormatInternal)this).IncludeQueryString = (bool?) content.GetValueForProperty("IncludeQueryString",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IApplicationGatewayRedirectConfigurationPropertiesFormatInternal)this).IncludeQueryString, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IApplicationGatewayRedirectConfigurationPropertiesFormatInternal)this).PathRule = (Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubResource[]) content.GetValueForProperty("PathRule",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IApplicationGatewayRedirectConfigurationPropertiesFormatInternal)this).PathRule, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubResource>(__y, Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.SubResourceTypeConverter.ConvertFrom));
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IApplicationGatewayRedirectConfigurationPropertiesFormatInternal)this).RedirectType = (Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ApplicationGatewayRedirectType?) content.GetValueForProperty("RedirectType",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IApplicationGatewayRedirectConfigurationPropertiesFormatInternal)this).RedirectType, Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ApplicationGatewayRedirectType.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IApplicationGatewayRedirectConfigurationPropertiesFormatInternal)this).RequestRoutingRule = (Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubResource[]) content.GetValueForProperty("RequestRoutingRule",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IApplicationGatewayRedirectConfigurationPropertiesFormatInternal)this).RequestRoutingRule, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubResource>(__y, Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.SubResourceTypeConverter.ConvertFrom));
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IApplicationGatewayRedirectConfigurationPropertiesFormatInternal)this).TargetUrl = (string) content.GetValueForProperty("TargetUrl",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IApplicationGatewayRedirectConfigurationPropertiesFormatInternal)this).TargetUrl, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IApplicationGatewayRedirectConfigurationPropertiesFormatInternal)this).UrlPathMap = (Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubResource[]) content.GetValueForProperty("UrlPathMap",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IApplicationGatewayRedirectConfigurationPropertiesFormatInternal)this).UrlPathMap, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubResource>(__y, Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.SubResourceTypeConverter.ConvertFrom));
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IApplicationGatewayRedirectConfigurationPropertiesFormatInternal)this).TargetListenerId = (string) content.GetValueForProperty("TargetListenerId",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IApplicationGatewayRedirectConfigurationPropertiesFormatInternal)this).TargetListenerId, global::System.Convert.ToString);
            AfterDeserializePSObject(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ApplicationGatewayRedirectConfigurationPropertiesFormat"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IApplicationGatewayRedirectConfigurationPropertiesFormat"
        /// />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IApplicationGatewayRedirectConfigurationPropertiesFormat DeserializeFromDictionary(global::System.Collections.IDictionary content)
        {
            return new ApplicationGatewayRedirectConfigurationPropertiesFormat(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ApplicationGatewayRedirectConfigurationPropertiesFormat"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IApplicationGatewayRedirectConfigurationPropertiesFormat"
        /// />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IApplicationGatewayRedirectConfigurationPropertiesFormat DeserializeFromPSObject(global::System.Management.Automation.PSObject content)
        {
            return new ApplicationGatewayRedirectConfigurationPropertiesFormat(content);
        }

        /// <summary>
        /// Creates a new instance of <see cref="ApplicationGatewayRedirectConfigurationPropertiesFormat" />, deserializing the content
        /// from a json string.
        /// </summary>
        /// <param name="jsonText">a string containing a JSON serialized instance of this model.</param>
        /// <returns>an instance of the <see cref="className" /> model class.</returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IApplicationGatewayRedirectConfigurationPropertiesFormat FromJsonString(string jsonText) => FromJson(Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonNode.Parse(jsonText));

        /// <summary>Serializes this instance to a json string.</summary>

        /// <returns>a <see cref="System.String" /> containing this model serialized to JSON text.</returns>
        public string ToJsonString() => ToJson(null, Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.SerializationMode.IncludeAll)?.ToString();
    }
    /// Properties of redirect configuration of the application gateway.
    [System.ComponentModel.TypeConverter(typeof(ApplicationGatewayRedirectConfigurationPropertiesFormatTypeConverter))]
    public partial interface IApplicationGatewayRedirectConfigurationPropertiesFormat

    {

    }
}