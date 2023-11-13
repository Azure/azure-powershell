namespace Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301
{
    using Microsoft.Azure.PowerShell.Cmdlets.Datadog.Runtime.PowerShell;

    /// <summary>Datadog organization properties</summary>
    [System.ComponentModel.TypeConverter(typeof(DatadogOrganizationPropertiesTypeConverter))]
    public partial class DatadogOrganizationProperties
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
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.DatadogOrganizationProperties"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        internal DatadogOrganizationProperties(global::System.Collections.IDictionary content)
        {
            bool returnNow = false;
            BeforeDeserializeDictionary(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IDatadogOrganizationPropertiesInternal)this).Name = (string) content.GetValueForProperty("Name",((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IDatadogOrganizationPropertiesInternal)this).Name, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IDatadogOrganizationPropertiesInternal)this).Id = (string) content.GetValueForProperty("Id",((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IDatadogOrganizationPropertiesInternal)this).Id, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IDatadogOrganizationPropertiesInternal)this).LinkingAuthCode = (string) content.GetValueForProperty("LinkingAuthCode",((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IDatadogOrganizationPropertiesInternal)this).LinkingAuthCode, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IDatadogOrganizationPropertiesInternal)this).LinkingClientId = (string) content.GetValueForProperty("LinkingClientId",((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IDatadogOrganizationPropertiesInternal)this).LinkingClientId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IDatadogOrganizationPropertiesInternal)this).RedirectUri = (string) content.GetValueForProperty("RedirectUri",((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IDatadogOrganizationPropertiesInternal)this).RedirectUri, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IDatadogOrganizationPropertiesInternal)this).ApiKey = (string) content.GetValueForProperty("ApiKey",((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IDatadogOrganizationPropertiesInternal)this).ApiKey, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IDatadogOrganizationPropertiesInternal)this).ApplicationKey = (string) content.GetValueForProperty("ApplicationKey",((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IDatadogOrganizationPropertiesInternal)this).ApplicationKey, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IDatadogOrganizationPropertiesInternal)this).EnterpriseAppId = (string) content.GetValueForProperty("EnterpriseAppId",((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IDatadogOrganizationPropertiesInternal)this).EnterpriseAppId, global::System.Convert.ToString);
            AfterDeserializeDictionary(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.DatadogOrganizationProperties"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        internal DatadogOrganizationProperties(global::System.Management.Automation.PSObject content)
        {
            bool returnNow = false;
            BeforeDeserializePSObject(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IDatadogOrganizationPropertiesInternal)this).Name = (string) content.GetValueForProperty("Name",((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IDatadogOrganizationPropertiesInternal)this).Name, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IDatadogOrganizationPropertiesInternal)this).Id = (string) content.GetValueForProperty("Id",((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IDatadogOrganizationPropertiesInternal)this).Id, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IDatadogOrganizationPropertiesInternal)this).LinkingAuthCode = (string) content.GetValueForProperty("LinkingAuthCode",((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IDatadogOrganizationPropertiesInternal)this).LinkingAuthCode, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IDatadogOrganizationPropertiesInternal)this).LinkingClientId = (string) content.GetValueForProperty("LinkingClientId",((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IDatadogOrganizationPropertiesInternal)this).LinkingClientId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IDatadogOrganizationPropertiesInternal)this).RedirectUri = (string) content.GetValueForProperty("RedirectUri",((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IDatadogOrganizationPropertiesInternal)this).RedirectUri, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IDatadogOrganizationPropertiesInternal)this).ApiKey = (string) content.GetValueForProperty("ApiKey",((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IDatadogOrganizationPropertiesInternal)this).ApiKey, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IDatadogOrganizationPropertiesInternal)this).ApplicationKey = (string) content.GetValueForProperty("ApplicationKey",((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IDatadogOrganizationPropertiesInternal)this).ApplicationKey, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IDatadogOrganizationPropertiesInternal)this).EnterpriseAppId = (string) content.GetValueForProperty("EnterpriseAppId",((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IDatadogOrganizationPropertiesInternal)this).EnterpriseAppId, global::System.Convert.ToString);
            AfterDeserializePSObject(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.DatadogOrganizationProperties"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IDatadogOrganizationProperties"
        /// />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IDatadogOrganizationProperties DeserializeFromDictionary(global::System.Collections.IDictionary content)
        {
            return new DatadogOrganizationProperties(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.DatadogOrganizationProperties"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IDatadogOrganizationProperties"
        /// />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IDatadogOrganizationProperties DeserializeFromPSObject(global::System.Management.Automation.PSObject content)
        {
            return new DatadogOrganizationProperties(content);
        }

        /// <summary>
        /// Creates a new instance of <see cref="DatadogOrganizationProperties" />, deserializing the content from a json string.
        /// </summary>
        /// <param name="jsonText">a string containing a JSON serialized instance of this model.</param>
        /// <returns>an instance of the <see cref="className" /> model class.</returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IDatadogOrganizationProperties FromJsonString(string jsonText) => FromJson(Microsoft.Azure.PowerShell.Cmdlets.Datadog.Runtime.Json.JsonNode.Parse(jsonText));

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
    /// Datadog organization properties
    [System.ComponentModel.TypeConverter(typeof(DatadogOrganizationPropertiesTypeConverter))]
    public partial interface IDatadogOrganizationProperties

    {

    }
}