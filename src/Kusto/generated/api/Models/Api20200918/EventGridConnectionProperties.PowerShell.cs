namespace Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200918
{
    using Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.PowerShell;

    /// <summary>Class representing the Kusto event grid connection properties.</summary>
    [System.ComponentModel.TypeConverter(typeof(EventGridConnectionPropertiesTypeConverter))]
    public partial class EventGridConnectionProperties
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
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200918.EventGridConnectionProperties"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200918.IEventGridConnectionProperties"
        /// />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200918.IEventGridConnectionProperties DeserializeFromDictionary(global::System.Collections.IDictionary content)
        {
            return new EventGridConnectionProperties(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200918.EventGridConnectionProperties"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200918.IEventGridConnectionProperties"
        /// />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200918.IEventGridConnectionProperties DeserializeFromPSObject(global::System.Management.Automation.PSObject content)
        {
            return new EventGridConnectionProperties(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200918.EventGridConnectionProperties"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        internal EventGridConnectionProperties(global::System.Collections.IDictionary content)
        {
            bool returnNow = false;
            BeforeDeserializeDictionary(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200918.IEventGridConnectionPropertiesInternal)this).StorageAccountResourceId = (string) content.GetValueForProperty("StorageAccountResourceId",((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200918.IEventGridConnectionPropertiesInternal)this).StorageAccountResourceId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200918.IEventGridConnectionPropertiesInternal)this).EventHubResourceId = (string) content.GetValueForProperty("EventHubResourceId",((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200918.IEventGridConnectionPropertiesInternal)this).EventHubResourceId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200918.IEventGridConnectionPropertiesInternal)this).ConsumerGroup = (string) content.GetValueForProperty("ConsumerGroup",((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200918.IEventGridConnectionPropertiesInternal)this).ConsumerGroup, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200918.IEventGridConnectionPropertiesInternal)this).TableName = (string) content.GetValueForProperty("TableName",((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200918.IEventGridConnectionPropertiesInternal)this).TableName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200918.IEventGridConnectionPropertiesInternal)this).MappingRuleName = (string) content.GetValueForProperty("MappingRuleName",((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200918.IEventGridConnectionPropertiesInternal)this).MappingRuleName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200918.IEventGridConnectionPropertiesInternal)this).DataFormat = (Microsoft.Azure.PowerShell.Cmdlets.Kusto.Support.EventGridDataFormat?) content.GetValueForProperty("DataFormat",((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200918.IEventGridConnectionPropertiesInternal)this).DataFormat, Microsoft.Azure.PowerShell.Cmdlets.Kusto.Support.EventGridDataFormat.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200918.IEventGridConnectionPropertiesInternal)this).IgnoreFirstRecord = (bool?) content.GetValueForProperty("IgnoreFirstRecord",((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200918.IEventGridConnectionPropertiesInternal)this).IgnoreFirstRecord, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200918.IEventGridConnectionPropertiesInternal)this).BlobStorageEventType = (Microsoft.Azure.PowerShell.Cmdlets.Kusto.Support.BlobStorageEventType?) content.GetValueForProperty("BlobStorageEventType",((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200918.IEventGridConnectionPropertiesInternal)this).BlobStorageEventType, Microsoft.Azure.PowerShell.Cmdlets.Kusto.Support.BlobStorageEventType.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200918.IEventGridConnectionPropertiesInternal)this).ProvisioningState = (Microsoft.Azure.PowerShell.Cmdlets.Kusto.Support.ProvisioningState?) content.GetValueForProperty("ProvisioningState",((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200918.IEventGridConnectionPropertiesInternal)this).ProvisioningState, Microsoft.Azure.PowerShell.Cmdlets.Kusto.Support.ProvisioningState.CreateFrom);
            AfterDeserializeDictionary(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200918.EventGridConnectionProperties"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        internal EventGridConnectionProperties(global::System.Management.Automation.PSObject content)
        {
            bool returnNow = false;
            BeforeDeserializePSObject(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200918.IEventGridConnectionPropertiesInternal)this).StorageAccountResourceId = (string) content.GetValueForProperty("StorageAccountResourceId",((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200918.IEventGridConnectionPropertiesInternal)this).StorageAccountResourceId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200918.IEventGridConnectionPropertiesInternal)this).EventHubResourceId = (string) content.GetValueForProperty("EventHubResourceId",((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200918.IEventGridConnectionPropertiesInternal)this).EventHubResourceId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200918.IEventGridConnectionPropertiesInternal)this).ConsumerGroup = (string) content.GetValueForProperty("ConsumerGroup",((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200918.IEventGridConnectionPropertiesInternal)this).ConsumerGroup, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200918.IEventGridConnectionPropertiesInternal)this).TableName = (string) content.GetValueForProperty("TableName",((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200918.IEventGridConnectionPropertiesInternal)this).TableName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200918.IEventGridConnectionPropertiesInternal)this).MappingRuleName = (string) content.GetValueForProperty("MappingRuleName",((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200918.IEventGridConnectionPropertiesInternal)this).MappingRuleName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200918.IEventGridConnectionPropertiesInternal)this).DataFormat = (Microsoft.Azure.PowerShell.Cmdlets.Kusto.Support.EventGridDataFormat?) content.GetValueForProperty("DataFormat",((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200918.IEventGridConnectionPropertiesInternal)this).DataFormat, Microsoft.Azure.PowerShell.Cmdlets.Kusto.Support.EventGridDataFormat.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200918.IEventGridConnectionPropertiesInternal)this).IgnoreFirstRecord = (bool?) content.GetValueForProperty("IgnoreFirstRecord",((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200918.IEventGridConnectionPropertiesInternal)this).IgnoreFirstRecord, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200918.IEventGridConnectionPropertiesInternal)this).BlobStorageEventType = (Microsoft.Azure.PowerShell.Cmdlets.Kusto.Support.BlobStorageEventType?) content.GetValueForProperty("BlobStorageEventType",((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200918.IEventGridConnectionPropertiesInternal)this).BlobStorageEventType, Microsoft.Azure.PowerShell.Cmdlets.Kusto.Support.BlobStorageEventType.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200918.IEventGridConnectionPropertiesInternal)this).ProvisioningState = (Microsoft.Azure.PowerShell.Cmdlets.Kusto.Support.ProvisioningState?) content.GetValueForProperty("ProvisioningState",((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200918.IEventGridConnectionPropertiesInternal)this).ProvisioningState, Microsoft.Azure.PowerShell.Cmdlets.Kusto.Support.ProvisioningState.CreateFrom);
            AfterDeserializePSObject(content);
        }

        /// <summary>
        /// Creates a new instance of <see cref="EventGridConnectionProperties" />, deserializing the content from a json string.
        /// </summary>
        /// <param name="jsonText">a string containing a JSON serialized instance of this model.</param>
        /// <returns>an instance of the <see cref="className" /> model class.</returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200918.IEventGridConnectionProperties FromJsonString(string jsonText) => FromJson(Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.Json.JsonNode.Parse(jsonText));

        /// <summary>Serializes this instance to a json string.</summary>

        /// <returns>a <see cref="System.String" /> containing this model serialized to JSON text.</returns>
        public string ToJsonString() => ToJson(null, Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.SerializationMode.IncludeAll)?.ToString();
    }
    /// Class representing the Kusto event grid connection properties.
    [System.ComponentModel.TypeConverter(typeof(EventGridConnectionPropertiesTypeConverter))]
    public partial interface IEventGridConnectionProperties

    {

    }
}