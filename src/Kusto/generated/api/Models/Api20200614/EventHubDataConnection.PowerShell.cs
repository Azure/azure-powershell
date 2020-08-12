namespace Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614
{
    using Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.PowerShell;

    /// <summary>Class representing an event hub data connection.</summary>
    [System.ComponentModel.TypeConverter(typeof(EventHubDataConnectionTypeConverter))]
    public partial class EventHubDataConnection
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
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.EventHubDataConnection"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IEventHubDataConnection" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IEventHubDataConnection DeserializeFromDictionary(global::System.Collections.IDictionary content)
        {
            return new EventHubDataConnection(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.EventHubDataConnection"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IEventHubDataConnection" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IEventHubDataConnection DeserializeFromPSObject(global::System.Management.Automation.PSObject content)
        {
            return new EventHubDataConnection(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.EventHubDataConnection"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        internal EventHubDataConnection(global::System.Collections.IDictionary content)
        {
            bool returnNow = false;
            BeforeDeserializeDictionary(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IEventHubDataConnectionInternal)this).Property = (Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IEventHubConnectionProperties) content.GetValueForProperty("Property",((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IEventHubDataConnectionInternal)this).Property, Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.EventHubConnectionPropertiesTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api10.IResourceInternal)this).Name = (string) content.GetValueForProperty("Name",((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api10.IResourceInternal)this).Name, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api10.IResourceInternal)this).Type = (string) content.GetValueForProperty("Type",((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api10.IResourceInternal)this).Type, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api10.IResourceInternal)this).Id = (string) content.GetValueForProperty("Id",((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api10.IResourceInternal)this).Id, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IDataConnectionInternal)this).Kind = (Microsoft.Azure.PowerShell.Cmdlets.Kusto.Support.Kind) content.GetValueForProperty("Kind",((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IDataConnectionInternal)this).Kind, Microsoft.Azure.PowerShell.Cmdlets.Kusto.Support.Kind.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IDataConnectionInternal)this).Location = (string) content.GetValueForProperty("Location",((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IDataConnectionInternal)this).Location, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IEventHubDataConnectionInternal)this).Compression = (Microsoft.Azure.PowerShell.Cmdlets.Kusto.Support.Compression?) content.GetValueForProperty("Compression",((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IEventHubDataConnectionInternal)this).Compression, Microsoft.Azure.PowerShell.Cmdlets.Kusto.Support.Compression.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IEventHubDataConnectionInternal)this).ConsumerGroup = (string) content.GetValueForProperty("ConsumerGroup",((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IEventHubDataConnectionInternal)this).ConsumerGroup, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IEventHubDataConnectionInternal)this).DataFormat = (Microsoft.Azure.PowerShell.Cmdlets.Kusto.Support.EventHubDataFormat?) content.GetValueForProperty("DataFormat",((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IEventHubDataConnectionInternal)this).DataFormat, Microsoft.Azure.PowerShell.Cmdlets.Kusto.Support.EventHubDataFormat.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IEventHubDataConnectionInternal)this).EventHubResourceId = (string) content.GetValueForProperty("EventHubResourceId",((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IEventHubDataConnectionInternal)this).EventHubResourceId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IEventHubDataConnectionInternal)this).EventSystemProperty = (string[]) content.GetValueForProperty("EventSystemProperty",((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IEventHubDataConnectionInternal)this).EventSystemProperty, __y => TypeConverterExtensions.SelectToArray<string>(__y, global::System.Convert.ToString));
            ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IEventHubDataConnectionInternal)this).MappingRuleName = (string) content.GetValueForProperty("MappingRuleName",((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IEventHubDataConnectionInternal)this).MappingRuleName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IEventHubDataConnectionInternal)this).TableName = (string) content.GetValueForProperty("TableName",((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IEventHubDataConnectionInternal)this).TableName, global::System.Convert.ToString);
            AfterDeserializeDictionary(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.EventHubDataConnection"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        internal EventHubDataConnection(global::System.Management.Automation.PSObject content)
        {
            bool returnNow = false;
            BeforeDeserializePSObject(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IEventHubDataConnectionInternal)this).Property = (Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IEventHubConnectionProperties) content.GetValueForProperty("Property",((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IEventHubDataConnectionInternal)this).Property, Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.EventHubConnectionPropertiesTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api10.IResourceInternal)this).Name = (string) content.GetValueForProperty("Name",((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api10.IResourceInternal)this).Name, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api10.IResourceInternal)this).Type = (string) content.GetValueForProperty("Type",((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api10.IResourceInternal)this).Type, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api10.IResourceInternal)this).Id = (string) content.GetValueForProperty("Id",((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api10.IResourceInternal)this).Id, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IDataConnectionInternal)this).Kind = (Microsoft.Azure.PowerShell.Cmdlets.Kusto.Support.Kind) content.GetValueForProperty("Kind",((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IDataConnectionInternal)this).Kind, Microsoft.Azure.PowerShell.Cmdlets.Kusto.Support.Kind.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IDataConnectionInternal)this).Location = (string) content.GetValueForProperty("Location",((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IDataConnectionInternal)this).Location, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IEventHubDataConnectionInternal)this).Compression = (Microsoft.Azure.PowerShell.Cmdlets.Kusto.Support.Compression?) content.GetValueForProperty("Compression",((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IEventHubDataConnectionInternal)this).Compression, Microsoft.Azure.PowerShell.Cmdlets.Kusto.Support.Compression.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IEventHubDataConnectionInternal)this).ConsumerGroup = (string) content.GetValueForProperty("ConsumerGroup",((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IEventHubDataConnectionInternal)this).ConsumerGroup, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IEventHubDataConnectionInternal)this).DataFormat = (Microsoft.Azure.PowerShell.Cmdlets.Kusto.Support.EventHubDataFormat?) content.GetValueForProperty("DataFormat",((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IEventHubDataConnectionInternal)this).DataFormat, Microsoft.Azure.PowerShell.Cmdlets.Kusto.Support.EventHubDataFormat.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IEventHubDataConnectionInternal)this).EventHubResourceId = (string) content.GetValueForProperty("EventHubResourceId",((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IEventHubDataConnectionInternal)this).EventHubResourceId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IEventHubDataConnectionInternal)this).EventSystemProperty = (string[]) content.GetValueForProperty("EventSystemProperty",((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IEventHubDataConnectionInternal)this).EventSystemProperty, __y => TypeConverterExtensions.SelectToArray<string>(__y, global::System.Convert.ToString));
            ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IEventHubDataConnectionInternal)this).MappingRuleName = (string) content.GetValueForProperty("MappingRuleName",((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IEventHubDataConnectionInternal)this).MappingRuleName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IEventHubDataConnectionInternal)this).TableName = (string) content.GetValueForProperty("TableName",((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IEventHubDataConnectionInternal)this).TableName, global::System.Convert.ToString);
            AfterDeserializePSObject(content);
        }

        /// <summary>
        /// Creates a new instance of <see cref="EventHubDataConnection" />, deserializing the content from a json string.
        /// </summary>
        /// <param name="jsonText">a string containing a JSON serialized instance of this model.</param>
        /// <returns>an instance of the <see cref="className" /> model class.</returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IEventHubDataConnection FromJsonString(string jsonText) => FromJson(Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.Json.JsonNode.Parse(jsonText));

        /// <summary>Serializes this instance to a json string.</summary>

        /// <returns>a <see cref="System.String" /> containing this model serialized to JSON text.</returns>
        public string ToJsonString() => ToJson(null, Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.SerializationMode.IncludeAll)?.ToString();
    }
    /// Class representing an event hub data connection.
    [System.ComponentModel.TypeConverter(typeof(EventHubDataConnectionTypeConverter))]
    public partial interface IEventHubDataConnection

    {

    }
}