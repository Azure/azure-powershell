namespace Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200918
{
    using Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.PowerShell;

    /// <summary>Class representing the Kusto event hub connection properties.</summary>
    [System.ComponentModel.TypeConverter(typeof(EventHubConnectionPropertiesTypeConverter))]
    public partial class EventHubConnectionProperties
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
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200918.EventHubConnectionProperties"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200918.IEventHubConnectionProperties" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200918.IEventHubConnectionProperties DeserializeFromDictionary(global::System.Collections.IDictionary content)
        {
            return new EventHubConnectionProperties(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200918.EventHubConnectionProperties"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200918.IEventHubConnectionProperties" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200918.IEventHubConnectionProperties DeserializeFromPSObject(global::System.Management.Automation.PSObject content)
        {
            return new EventHubConnectionProperties(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200918.EventHubConnectionProperties"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        internal EventHubConnectionProperties(global::System.Collections.IDictionary content)
        {
            bool returnNow = false;
            BeforeDeserializeDictionary(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200918.IEventHubConnectionPropertiesInternal)this).EventHubResourceId = (string) content.GetValueForProperty("EventHubResourceId",((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200918.IEventHubConnectionPropertiesInternal)this).EventHubResourceId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200918.IEventHubConnectionPropertiesInternal)this).ConsumerGroup = (string) content.GetValueForProperty("ConsumerGroup",((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200918.IEventHubConnectionPropertiesInternal)this).ConsumerGroup, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200918.IEventHubConnectionPropertiesInternal)this).TableName = (string) content.GetValueForProperty("TableName",((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200918.IEventHubConnectionPropertiesInternal)this).TableName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200918.IEventHubConnectionPropertiesInternal)this).MappingRuleName = (string) content.GetValueForProperty("MappingRuleName",((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200918.IEventHubConnectionPropertiesInternal)this).MappingRuleName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200918.IEventHubConnectionPropertiesInternal)this).DataFormat = (Microsoft.Azure.PowerShell.Cmdlets.Kusto.Support.EventHubDataFormat?) content.GetValueForProperty("DataFormat",((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200918.IEventHubConnectionPropertiesInternal)this).DataFormat, Microsoft.Azure.PowerShell.Cmdlets.Kusto.Support.EventHubDataFormat.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200918.IEventHubConnectionPropertiesInternal)this).EventSystemProperty = (string[]) content.GetValueForProperty("EventSystemProperty",((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200918.IEventHubConnectionPropertiesInternal)this).EventSystemProperty, __y => TypeConverterExtensions.SelectToArray<string>(__y, global::System.Convert.ToString));
            ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200918.IEventHubConnectionPropertiesInternal)this).Compression = (Microsoft.Azure.PowerShell.Cmdlets.Kusto.Support.Compression?) content.GetValueForProperty("Compression",((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200918.IEventHubConnectionPropertiesInternal)this).Compression, Microsoft.Azure.PowerShell.Cmdlets.Kusto.Support.Compression.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200918.IEventHubConnectionPropertiesInternal)this).ProvisioningState = (Microsoft.Azure.PowerShell.Cmdlets.Kusto.Support.ProvisioningState?) content.GetValueForProperty("ProvisioningState",((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200918.IEventHubConnectionPropertiesInternal)this).ProvisioningState, Microsoft.Azure.PowerShell.Cmdlets.Kusto.Support.ProvisioningState.CreateFrom);
            AfterDeserializeDictionary(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200918.EventHubConnectionProperties"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        internal EventHubConnectionProperties(global::System.Management.Automation.PSObject content)
        {
            bool returnNow = false;
            BeforeDeserializePSObject(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200918.IEventHubConnectionPropertiesInternal)this).EventHubResourceId = (string) content.GetValueForProperty("EventHubResourceId",((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200918.IEventHubConnectionPropertiesInternal)this).EventHubResourceId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200918.IEventHubConnectionPropertiesInternal)this).ConsumerGroup = (string) content.GetValueForProperty("ConsumerGroup",((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200918.IEventHubConnectionPropertiesInternal)this).ConsumerGroup, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200918.IEventHubConnectionPropertiesInternal)this).TableName = (string) content.GetValueForProperty("TableName",((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200918.IEventHubConnectionPropertiesInternal)this).TableName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200918.IEventHubConnectionPropertiesInternal)this).MappingRuleName = (string) content.GetValueForProperty("MappingRuleName",((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200918.IEventHubConnectionPropertiesInternal)this).MappingRuleName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200918.IEventHubConnectionPropertiesInternal)this).DataFormat = (Microsoft.Azure.PowerShell.Cmdlets.Kusto.Support.EventHubDataFormat?) content.GetValueForProperty("DataFormat",((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200918.IEventHubConnectionPropertiesInternal)this).DataFormat, Microsoft.Azure.PowerShell.Cmdlets.Kusto.Support.EventHubDataFormat.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200918.IEventHubConnectionPropertiesInternal)this).EventSystemProperty = (string[]) content.GetValueForProperty("EventSystemProperty",((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200918.IEventHubConnectionPropertiesInternal)this).EventSystemProperty, __y => TypeConverterExtensions.SelectToArray<string>(__y, global::System.Convert.ToString));
            ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200918.IEventHubConnectionPropertiesInternal)this).Compression = (Microsoft.Azure.PowerShell.Cmdlets.Kusto.Support.Compression?) content.GetValueForProperty("Compression",((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200918.IEventHubConnectionPropertiesInternal)this).Compression, Microsoft.Azure.PowerShell.Cmdlets.Kusto.Support.Compression.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200918.IEventHubConnectionPropertiesInternal)this).ProvisioningState = (Microsoft.Azure.PowerShell.Cmdlets.Kusto.Support.ProvisioningState?) content.GetValueForProperty("ProvisioningState",((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200918.IEventHubConnectionPropertiesInternal)this).ProvisioningState, Microsoft.Azure.PowerShell.Cmdlets.Kusto.Support.ProvisioningState.CreateFrom);
            AfterDeserializePSObject(content);
        }

        /// <summary>
        /// Creates a new instance of <see cref="EventHubConnectionProperties" />, deserializing the content from a json string.
        /// </summary>
        /// <param name="jsonText">a string containing a JSON serialized instance of this model.</param>
        /// <returns>an instance of the <see cref="className" /> model class.</returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200918.IEventHubConnectionProperties FromJsonString(string jsonText) => FromJson(Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.Json.JsonNode.Parse(jsonText));

        /// <summary>Serializes this instance to a json string.</summary>

        /// <returns>a <see cref="System.String" /> containing this model serialized to JSON text.</returns>
        public string ToJsonString() => ToJson(null, Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.SerializationMode.IncludeAll)?.ToString();
    }
    /// Class representing the Kusto event hub connection properties.
    [System.ComponentModel.TypeConverter(typeof(EventHubConnectionPropertiesTypeConverter))]
    public partial interface IEventHubConnectionProperties

    {

    }
}