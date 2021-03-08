namespace Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601
{
    using static Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.Extensions;

    public partial class AlertProperties
    {

        /// <summary>
        /// <c>AfterFromJson</c> will be called after the json deserialization has finished, allowing customization of the object
        /// before it is returned. Implement this method in a partial class to enable this behavior
        /// </summary>
        /// <param name="json">The JsonNode that should be deserialized into this object.</param>

        partial void AfterFromJson(Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.Json.JsonObject json);

        /// <summary>
        /// <c>AfterToJson</c> will be called after the json erialization has finished, allowing customization of the <see cref="Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.Json.JsonObject"
        /// /> before it is returned. Implement this method in a partial class to enable this behavior
        /// </summary>
        /// <param name="container">The JSON container that the serialization result will be placed in.</param>

        partial void AfterToJson(ref Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.Json.JsonObject container);

        /// <summary>
        /// <c>BeforeFromJson</c> will be called before the json deserialization has commenced, allowing complete customization of
        /// the object before it is deserialized.
        /// If you wish to disable the default deserialization entirely, return <c>true</c> in the <see "returnNow" /> output parameter.
        /// Implement this method in a partial class to enable this behavior.
        /// </summary>
        /// <param name="json">The JsonNode that should be deserialized into this object.</param>
        /// <param name="returnNow">Determines if the rest of the deserialization should be processed, or if the method should return
        /// instantly.</param>

        partial void BeforeFromJson(Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.Json.JsonObject json, ref bool returnNow);

        /// <summary>
        /// <c>BeforeToJson</c> will be called before the json serialization has commenced, allowing complete customization of the
        /// object before it is serialized.
        /// If you wish to disable the default serialization entirely, return <c>true</c> in the <see "returnNow" /> output parameter.
        /// Implement this method in a partial class to enable this behavior.
        /// </summary>
        /// <param name="container">The JSON container that the serialization result will be placed in.</param>
        /// <param name="returnNow">Determines if the rest of the serialization should be processed, or if the method should return
        /// instantly.</param>

        partial void BeforeToJson(ref Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.Json.JsonObject container, ref bool returnNow);

        /// <summary>
        /// Deserializes a Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.Json.JsonObject into a new instance of <see cref="AlertProperties" />.
        /// </summary>
        /// <param name="json">A Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.Json.JsonObject instance to deserialize from.</param>
        internal AlertProperties(Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.Json.JsonObject json)
        {
            bool returnNow = false;
            BeforeFromJson(json, ref returnNow);
            if (returnNow)
            {
                return;
            }
            {_definition = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.Json.JsonObject>("definition"), out var __jsonDefinition) ? Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.AlertPropertiesDefinition.FromJson(__jsonDefinition) : Definition;}
            {_detail = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.Json.JsonObject>("details"), out var __jsonDetails) ? Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.AlertPropertiesDetails.FromJson(__jsonDetails) : Detail;}
            {_description = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.Json.JsonString>("description"), out var __jsonDescription) ? (string)__jsonDescription : (string)Description;}
            {_source = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.Json.JsonString>("source"), out var __jsonSource) ? (string)__jsonSource : (string)Source;}
            {_costEntityId = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.Json.JsonString>("costEntityId"), out var __jsonCostEntityId) ? (string)__jsonCostEntityId : (string)CostEntityId;}
            {_status = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.Json.JsonString>("status"), out var __jsonStatus) ? (string)__jsonStatus : (string)Status;}
            {_creationTime = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.Json.JsonString>("creationTime"), out var __jsonCreationTime) ? (string)__jsonCreationTime : (string)CreationTime;}
            {_closeTime = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.Json.JsonString>("closeTime"), out var __jsonCloseTime) ? (string)__jsonCloseTime : (string)CloseTime;}
            {_modificationTime = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.Json.JsonString>("modificationTime"), out var __jsonModificationTime) ? (string)__jsonModificationTime : (string)ModificationTime;}
            {_statusModificationUserName = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.Json.JsonString>("statusModificationUserName"), out var __jsonStatusModificationUserName) ? (string)__jsonStatusModificationUserName : (string)StatusModificationUserName;}
            {_statusModificationTime = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.Json.JsonString>("statusModificationTime"), out var __jsonStatusModificationTime) ? (string)__jsonStatusModificationTime : (string)StatusModificationTime;}
            AfterFromJson(json);
        }

        /// <summary>
        /// Deserializes a <see cref="Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.Json.JsonNode"/> into an instance of Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IAlertProperties.
        /// </summary>
        /// <param name="node">a <see cref="Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.Json.JsonNode" /> to deserialize from.</param>
        /// <returns>
        /// an instance of Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IAlertProperties.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IAlertProperties FromJson(Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.Json.JsonNode node)
        {
            return node is Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.Json.JsonObject json ? new AlertProperties(json) : null;
        }

        /// <summary>
        /// Serializes this instance of <see cref="AlertProperties" /> into a <see cref="Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.Json.JsonNode" />.
        /// </summary>
        /// <param name="container">The <see cref="Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.Json.JsonObject"/> container to serialize this object into. If the caller
        /// passes in <c>null</c>, a new instance will be created and returned to the caller.</param>
        /// <param name="serializationMode">Allows the caller to choose the depth of the serialization. See <see cref="Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.SerializationMode"/>.</param>
        /// <returns>
        /// a serialized instance of <see cref="AlertProperties" /> as a <see cref="Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.Json.JsonNode" />.
        /// </returns>
        public Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.Json.JsonNode ToJson(Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.Json.JsonObject container, Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.SerializationMode serializationMode)
        {
            container = container ?? new Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.Json.JsonObject();

            bool returnNow = false;
            BeforeToJson(ref container, ref returnNow);
            if (returnNow)
            {
                return container;
            }
            AddIf( null != this._definition ? (Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.Json.JsonNode) this._definition.ToJson(null,serializationMode) : null, "definition" ,container.Add );
            AddIf( null != this._detail ? (Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.Json.JsonNode) this._detail.ToJson(null,serializationMode) : null, "details" ,container.Add );
            AddIf( null != (((object)this._description)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.Json.JsonString(this._description.ToString()) : null, "description" ,container.Add );
            AddIf( null != (((object)this._source)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.Json.JsonString(this._source.ToString()) : null, "source" ,container.Add );
            AddIf( null != (((object)this._costEntityId)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.Json.JsonString(this._costEntityId.ToString()) : null, "costEntityId" ,container.Add );
            AddIf( null != (((object)this._status)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.Json.JsonString(this._status.ToString()) : null, "status" ,container.Add );
            AddIf( null != (((object)this._creationTime)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.Json.JsonString(this._creationTime.ToString()) : null, "creationTime" ,container.Add );
            AddIf( null != (((object)this._closeTime)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.Json.JsonString(this._closeTime.ToString()) : null, "closeTime" ,container.Add );
            AddIf( null != (((object)this._modificationTime)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.Json.JsonString(this._modificationTime.ToString()) : null, "modificationTime" ,container.Add );
            AddIf( null != (((object)this._statusModificationUserName)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.Json.JsonString(this._statusModificationUserName.ToString()) : null, "statusModificationUserName" ,container.Add );
            AddIf( null != (((object)this._statusModificationTime)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.Json.JsonString(this._statusModificationTime.ToString()) : null, "statusModificationTime" ,container.Add );
            AfterToJson(ref container);
            return container;
        }
    }
}