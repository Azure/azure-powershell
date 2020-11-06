namespace Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20150501
{
    using Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.PowerShell;

    /// <summary>Properties that define an API key of an Application Insights Component.</summary>
    [System.ComponentModel.TypeConverter(typeof(ApplicationInsightsComponentApiKeyTypeConverter))]
    public partial class ApplicationInsightsComponentApiKey
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
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20150501.ApplicationInsightsComponentApiKey"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        internal ApplicationInsightsComponentApiKey(global::System.Collections.IDictionary content)
        {
            bool returnNow = false;
            BeforeDeserializeDictionary(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20150501.IApplicationInsightsComponentApiKeyInternal)this).Id = (string) content.GetValueForProperty("Id",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20150501.IApplicationInsightsComponentApiKeyInternal)this).Id, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20150501.IApplicationInsightsComponentApiKeyInternal)this).ApiKey = (string) content.GetValueForProperty("ApiKey",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20150501.IApplicationInsightsComponentApiKeyInternal)this).ApiKey, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20150501.IApplicationInsightsComponentApiKeyInternal)this).CreatedDate = (string) content.GetValueForProperty("CreatedDate",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20150501.IApplicationInsightsComponentApiKeyInternal)this).CreatedDate, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20150501.IApplicationInsightsComponentApiKeyInternal)this).Name = (string) content.GetValueForProperty("Name",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20150501.IApplicationInsightsComponentApiKeyInternal)this).Name, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20150501.IApplicationInsightsComponentApiKeyInternal)this).LinkedReadProperty = (string[]) content.GetValueForProperty("LinkedReadProperty",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20150501.IApplicationInsightsComponentApiKeyInternal)this).LinkedReadProperty, __y => TypeConverterExtensions.SelectToArray<string>(__y, global::System.Convert.ToString));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20150501.IApplicationInsightsComponentApiKeyInternal)this).LinkedWriteProperty = (string[]) content.GetValueForProperty("LinkedWriteProperty",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20150501.IApplicationInsightsComponentApiKeyInternal)this).LinkedWriteProperty, __y => TypeConverterExtensions.SelectToArray<string>(__y, global::System.Convert.ToString));
            AfterDeserializeDictionary(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20150501.ApplicationInsightsComponentApiKey"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        internal ApplicationInsightsComponentApiKey(global::System.Management.Automation.PSObject content)
        {
            bool returnNow = false;
            BeforeDeserializePSObject(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20150501.IApplicationInsightsComponentApiKeyInternal)this).Id = (string) content.GetValueForProperty("Id",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20150501.IApplicationInsightsComponentApiKeyInternal)this).Id, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20150501.IApplicationInsightsComponentApiKeyInternal)this).ApiKey = (string) content.GetValueForProperty("ApiKey",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20150501.IApplicationInsightsComponentApiKeyInternal)this).ApiKey, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20150501.IApplicationInsightsComponentApiKeyInternal)this).CreatedDate = (string) content.GetValueForProperty("CreatedDate",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20150501.IApplicationInsightsComponentApiKeyInternal)this).CreatedDate, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20150501.IApplicationInsightsComponentApiKeyInternal)this).Name = (string) content.GetValueForProperty("Name",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20150501.IApplicationInsightsComponentApiKeyInternal)this).Name, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20150501.IApplicationInsightsComponentApiKeyInternal)this).LinkedReadProperty = (string[]) content.GetValueForProperty("LinkedReadProperty",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20150501.IApplicationInsightsComponentApiKeyInternal)this).LinkedReadProperty, __y => TypeConverterExtensions.SelectToArray<string>(__y, global::System.Convert.ToString));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20150501.IApplicationInsightsComponentApiKeyInternal)this).LinkedWriteProperty = (string[]) content.GetValueForProperty("LinkedWriteProperty",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20150501.IApplicationInsightsComponentApiKeyInternal)this).LinkedWriteProperty, __y => TypeConverterExtensions.SelectToArray<string>(__y, global::System.Convert.ToString));
            AfterDeserializePSObject(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20150501.ApplicationInsightsComponentApiKey"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20150501.IApplicationInsightsComponentApiKey"
        /// />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20150501.IApplicationInsightsComponentApiKey DeserializeFromDictionary(global::System.Collections.IDictionary content)
        {
            return new ApplicationInsightsComponentApiKey(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20150501.ApplicationInsightsComponentApiKey"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20150501.IApplicationInsightsComponentApiKey"
        /// />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20150501.IApplicationInsightsComponentApiKey DeserializeFromPSObject(global::System.Management.Automation.PSObject content)
        {
            return new ApplicationInsightsComponentApiKey(content);
        }

        /// <summary>
        /// Creates a new instance of <see cref="ApplicationInsightsComponentApiKey" />, deserializing the content from a json string.
        /// </summary>
        /// <param name="jsonText">a string containing a JSON serialized instance of this model.</param>
        /// <returns>an instance of the <see cref="className" /> model class.</returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20150501.IApplicationInsightsComponentApiKey FromJsonString(string jsonText) => FromJson(Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonNode.Parse(jsonText));

        /// <summary>Serializes this instance to a json string.</summary>

        /// <returns>a <see cref="System.String" /> containing this model serialized to JSON text.</returns>
        public string ToJsonString() => ToJson(null, Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.SerializationMode.IncludeAll)?.ToString();
    }
    /// Properties that define an API key of an Application Insights Component.
    [System.ComponentModel.TypeConverter(typeof(ApplicationInsightsComponentApiKeyTypeConverter))]
    public partial interface IApplicationInsightsComponentApiKey

    {

    }
}