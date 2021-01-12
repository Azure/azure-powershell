namespace Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200918
{
    using Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.PowerShell;

    /// <summary>Class representing the Kusto Iot hub connection properties.</summary>
    [System.ComponentModel.TypeConverter(typeof(IotHubConnectionPropertiesTypeConverter))]
    public partial class IotHubConnectionProperties
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
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200918.IotHubConnectionProperties"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200918.IIotHubConnectionProperties" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200918.IIotHubConnectionProperties DeserializeFromDictionary(global::System.Collections.IDictionary content)
        {
            return new IotHubConnectionProperties(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200918.IotHubConnectionProperties"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200918.IIotHubConnectionProperties" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200918.IIotHubConnectionProperties DeserializeFromPSObject(global::System.Management.Automation.PSObject content)
        {
            return new IotHubConnectionProperties(content);
        }

        /// <summary>
        /// Creates a new instance of <see cref="IotHubConnectionProperties" />, deserializing the content from a json string.
        /// </summary>
        /// <param name="jsonText">a string containing a JSON serialized instance of this model.</param>
        /// <returns>an instance of the <see cref="className" /> model class.</returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200918.IIotHubConnectionProperties FromJsonString(string jsonText) => FromJson(Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.Json.JsonNode.Parse(jsonText));

        /// <summary>
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200918.IotHubConnectionProperties"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        internal IotHubConnectionProperties(global::System.Collections.IDictionary content)
        {
            bool returnNow = false;
            BeforeDeserializeDictionary(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200918.IIotHubConnectionPropertiesInternal)this).IotHubResourceId = (string) content.GetValueForProperty("IotHubResourceId",((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200918.IIotHubConnectionPropertiesInternal)this).IotHubResourceId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200918.IIotHubConnectionPropertiesInternal)this).ConsumerGroup = (string) content.GetValueForProperty("ConsumerGroup",((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200918.IIotHubConnectionPropertiesInternal)this).ConsumerGroup, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200918.IIotHubConnectionPropertiesInternal)this).TableName = (string) content.GetValueForProperty("TableName",((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200918.IIotHubConnectionPropertiesInternal)this).TableName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200918.IIotHubConnectionPropertiesInternal)this).MappingRuleName = (string) content.GetValueForProperty("MappingRuleName",((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200918.IIotHubConnectionPropertiesInternal)this).MappingRuleName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200918.IIotHubConnectionPropertiesInternal)this).DataFormat = (Microsoft.Azure.PowerShell.Cmdlets.Kusto.Support.IotHubDataFormat?) content.GetValueForProperty("DataFormat",((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200918.IIotHubConnectionPropertiesInternal)this).DataFormat, Microsoft.Azure.PowerShell.Cmdlets.Kusto.Support.IotHubDataFormat.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200918.IIotHubConnectionPropertiesInternal)this).EventSystemProperty = (string[]) content.GetValueForProperty("EventSystemProperty",((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200918.IIotHubConnectionPropertiesInternal)this).EventSystemProperty, __y => TypeConverterExtensions.SelectToArray<string>(__y, global::System.Convert.ToString));
            ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200918.IIotHubConnectionPropertiesInternal)this).SharedAccessPolicyName = (string) content.GetValueForProperty("SharedAccessPolicyName",((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200918.IIotHubConnectionPropertiesInternal)this).SharedAccessPolicyName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200918.IIotHubConnectionPropertiesInternal)this).ProvisioningState = (Microsoft.Azure.PowerShell.Cmdlets.Kusto.Support.ProvisioningState?) content.GetValueForProperty("ProvisioningState",((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200918.IIotHubConnectionPropertiesInternal)this).ProvisioningState, Microsoft.Azure.PowerShell.Cmdlets.Kusto.Support.ProvisioningState.CreateFrom);
            AfterDeserializeDictionary(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200918.IotHubConnectionProperties"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        internal IotHubConnectionProperties(global::System.Management.Automation.PSObject content)
        {
            bool returnNow = false;
            BeforeDeserializePSObject(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200918.IIotHubConnectionPropertiesInternal)this).IotHubResourceId = (string) content.GetValueForProperty("IotHubResourceId",((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200918.IIotHubConnectionPropertiesInternal)this).IotHubResourceId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200918.IIotHubConnectionPropertiesInternal)this).ConsumerGroup = (string) content.GetValueForProperty("ConsumerGroup",((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200918.IIotHubConnectionPropertiesInternal)this).ConsumerGroup, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200918.IIotHubConnectionPropertiesInternal)this).TableName = (string) content.GetValueForProperty("TableName",((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200918.IIotHubConnectionPropertiesInternal)this).TableName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200918.IIotHubConnectionPropertiesInternal)this).MappingRuleName = (string) content.GetValueForProperty("MappingRuleName",((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200918.IIotHubConnectionPropertiesInternal)this).MappingRuleName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200918.IIotHubConnectionPropertiesInternal)this).DataFormat = (Microsoft.Azure.PowerShell.Cmdlets.Kusto.Support.IotHubDataFormat?) content.GetValueForProperty("DataFormat",((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200918.IIotHubConnectionPropertiesInternal)this).DataFormat, Microsoft.Azure.PowerShell.Cmdlets.Kusto.Support.IotHubDataFormat.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200918.IIotHubConnectionPropertiesInternal)this).EventSystemProperty = (string[]) content.GetValueForProperty("EventSystemProperty",((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200918.IIotHubConnectionPropertiesInternal)this).EventSystemProperty, __y => TypeConverterExtensions.SelectToArray<string>(__y, global::System.Convert.ToString));
            ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200918.IIotHubConnectionPropertiesInternal)this).SharedAccessPolicyName = (string) content.GetValueForProperty("SharedAccessPolicyName",((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200918.IIotHubConnectionPropertiesInternal)this).SharedAccessPolicyName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200918.IIotHubConnectionPropertiesInternal)this).ProvisioningState = (Microsoft.Azure.PowerShell.Cmdlets.Kusto.Support.ProvisioningState?) content.GetValueForProperty("ProvisioningState",((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200918.IIotHubConnectionPropertiesInternal)this).ProvisioningState, Microsoft.Azure.PowerShell.Cmdlets.Kusto.Support.ProvisioningState.CreateFrom);
            AfterDeserializePSObject(content);
        }

        /// <summary>Serializes this instance to a json string.</summary>

        /// <returns>a <see cref="System.String" /> containing this model serialized to JSON text.</returns>
        public string ToJsonString() => ToJson(null, Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.SerializationMode.IncludeAll)?.ToString();
    }
    /// Class representing the Kusto Iot hub connection properties.
    [System.ComponentModel.TypeConverter(typeof(IotHubConnectionPropertiesTypeConverter))]
    public partial interface IIotHubConnectionProperties

    {

    }
}