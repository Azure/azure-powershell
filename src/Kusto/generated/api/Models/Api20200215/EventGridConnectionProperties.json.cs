namespace Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200215
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.Extensions;

    /// <summary>Class representing the Kusto event grid connection properties.</summary>
    public partial class EventGridConnectionProperties
    {

        /// <summary>
        /// <c>AfterFromJson</c> will be called after the json deserialization has finished, allowing customization of the object
        /// before it is returned. Implement this method in a partial class to enable this behavior
        /// </summary>
        /// <param name="json">The JsonNode that should be deserialized into this object.</param>

        partial void AfterFromJson(Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.Json.JsonObject json);

        /// <summary>
        /// <c>AfterToJson</c> will be called after the json erialization has finished, allowing customization of the <see cref="Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.Json.JsonObject"
        /// /> before it is returned. Implement this method in a partial class to enable this behavior
        /// </summary>
        /// <param name="container">The JSON container that the serialization result will be placed in.</param>

        partial void AfterToJson(ref Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.Json.JsonObject container);

        /// <summary>
        /// <c>BeforeFromJson</c> will be called before the json deserialization has commenced, allowing complete customization of
        /// the object before it is deserialized.
        /// If you wish to disable the default deserialization entirely, return <c>true</c> in the <see "returnNow" /> output parameter.
        /// Implement this method in a partial class to enable this behavior.
        /// </summary>
        /// <param name="json">The JsonNode that should be deserialized into this object.</param>
        /// <param name="returnNow">Determines if the rest of the deserialization should be processed, or if the method should return
        /// instantly.</param>

        partial void BeforeFromJson(Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.Json.JsonObject json, ref bool returnNow);

        /// <summary>
        /// <c>BeforeToJson</c> will be called before the json serialization has commenced, allowing complete customization of the
        /// object before it is serialized.
        /// If you wish to disable the default serialization entirely, return <c>true</c> in the <see "returnNow" /> output parameter.
        /// Implement this method in a partial class to enable this behavior.
        /// </summary>
        /// <param name="container">The JSON container that the serialization result will be placed in.</param>
        /// <param name="returnNow">Determines if the rest of the serialization should be processed, or if the method should return
        /// instantly.</param>

        partial void BeforeToJson(ref Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.Json.JsonObject container, ref bool returnNow);

        /// <summary>
        /// Deserializes a Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.Json.JsonObject into a new instance of <see cref="EventGridConnectionProperties" />.
        /// </summary>
        /// <param name="json">A Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.Json.JsonObject instance to deserialize from.</param>
        internal EventGridConnectionProperties(Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.Json.JsonObject json)
        {
            bool returnNow = false;
            BeforeFromJson(json, ref returnNow);
            if (returnNow)
            {
                return;
            }
            {_consumerGroup = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.Json.JsonString>("consumerGroup"), out var __jsonConsumerGroup) ? (string)__jsonConsumerGroup : (string)ConsumerGroup;}
            {_dataFormat = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.Json.JsonString>("dataFormat"), out var __jsonDataFormat) ? (string)__jsonDataFormat : (string)DataFormat;}
            {_eventHubResourceId = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.Json.JsonString>("eventHubResourceId"), out var __jsonEventHubResourceId) ? (string)__jsonEventHubResourceId : (string)EventHubResourceId;}
            {_mappingRuleName = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.Json.JsonString>("mappingRuleName"), out var __jsonMappingRuleName) ? (string)__jsonMappingRuleName : (string)MappingRuleName;}
            {_storageAccountResourceId = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.Json.JsonString>("storageAccountResourceId"), out var __jsonStorageAccountResourceId) ? (string)__jsonStorageAccountResourceId : (string)StorageAccountResourceId;}
            {_tableName = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.Json.JsonString>("tableName"), out var __jsonTableName) ? (string)__jsonTableName : (string)TableName;}
            AfterFromJson(json);
        }

        /// <summary>
        /// Deserializes a <see cref="Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.Json.JsonNode"/> into an instance of Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200215.IEventGridConnectionProperties.
        /// </summary>
        /// <param name="node">a <see cref="Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.Json.JsonNode" /> to deserialize from.</param>
        /// <returns>
        /// an instance of Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200215.IEventGridConnectionProperties.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200215.IEventGridConnectionProperties FromJson(Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.Json.JsonNode node)
        {
            return node is Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.Json.JsonObject json ? new EventGridConnectionProperties(json) : null;
        }

        /// <summary>
        /// Serializes this instance of <see cref="EventGridConnectionProperties" /> into a <see cref="Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.Json.JsonNode" />.
        /// </summary>
        /// <param name="container">The <see cref="Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.Json.JsonObject"/> container to serialize this object into. If the caller
        /// passes in <c>null</c>, a new instance will be created and returned to the caller.</param>
        /// <param name="serializationMode">Allows the caller to choose the depth of the serialization. See <see cref="Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.SerializationMode"/>.</param>
        /// <returns>
        /// a serialized instance of <see cref="EventGridConnectionProperties" /> as a <see cref="Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.Json.JsonNode" />.
        /// </returns>
        public Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.Json.JsonNode ToJson(Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.Json.JsonObject container, Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.SerializationMode serializationMode)
        {
            container = container ?? new Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.Json.JsonObject();

            bool returnNow = false;
            BeforeToJson(ref container, ref returnNow);
            if (returnNow)
            {
                return container;
            }
            AddIf( null != (((object)this._consumerGroup)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.Json.JsonString(this._consumerGroup.ToString()) : null, "consumerGroup" ,container.Add );
            AddIf( null != (((object)this._dataFormat)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.Json.JsonString(this._dataFormat.ToString()) : null, "dataFormat" ,container.Add );
            AddIf( null != (((object)this._eventHubResourceId)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.Json.JsonString(this._eventHubResourceId.ToString()) : null, "eventHubResourceId" ,container.Add );
            AddIf( null != (((object)this._mappingRuleName)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.Json.JsonString(this._mappingRuleName.ToString()) : null, "mappingRuleName" ,container.Add );
            AddIf( null != (((object)this._storageAccountResourceId)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.Json.JsonString(this._storageAccountResourceId.ToString()) : null, "storageAccountResourceId" ,container.Add );
            AddIf( null != (((object)this._tableName)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.Json.JsonString(this._tableName.ToString()) : null, "tableName" ,container.Add );
            AfterToJson(ref container);
            return container;
        }
    }
}