namespace Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Websites.Runtime.Extensions;

    /// <summary>
    /// Message envelope that contains the common Azure resource manager properties and the resource provider specific content.
    /// </summary>
    public partial class ResponseMessageEnvelopeRemotePrivateEndpointConnection
    {

        /// <summary>
        /// <c>AfterFromJson</c> will be called after the json deserialization has finished, allowing customization of the object
        /// before it is returned. Implement this method in a partial class to enable this behavior
        /// </summary>
        /// <param name="json">The JsonNode that should be deserialized into this object.</param>

        partial void AfterFromJson(Microsoft.Azure.PowerShell.Cmdlets.Websites.Runtime.Json.JsonObject json);

        /// <summary>
        /// <c>AfterToJson</c> will be called after the json erialization has finished, allowing customization of the <see cref="Microsoft.Azure.PowerShell.Cmdlets.Websites.Runtime.Json.JsonObject"
        /// /> before it is returned. Implement this method in a partial class to enable this behavior
        /// </summary>
        /// <param name="container">The JSON container that the serialization result will be placed in.</param>

        partial void AfterToJson(ref Microsoft.Azure.PowerShell.Cmdlets.Websites.Runtime.Json.JsonObject container);

        /// <summary>
        /// <c>BeforeFromJson</c> will be called before the json deserialization has commenced, allowing complete customization of
        /// the object before it is deserialized.
        /// If you wish to disable the default deserialization entirely, return <c>true</c> in the <see "returnNow" /> output parameter.
        /// Implement this method in a partial class to enable this behavior.
        /// </summary>
        /// <param name="json">The JsonNode that should be deserialized into this object.</param>
        /// <param name="returnNow">Determines if the rest of the deserialization should be processed, or if the method should return
        /// instantly.</param>

        partial void BeforeFromJson(Microsoft.Azure.PowerShell.Cmdlets.Websites.Runtime.Json.JsonObject json, ref bool returnNow);

        /// <summary>
        /// <c>BeforeToJson</c> will be called before the json serialization has commenced, allowing complete customization of the
        /// object before it is serialized.
        /// If you wish to disable the default serialization entirely, return <c>true</c> in the <see "returnNow" /> output parameter.
        /// Implement this method in a partial class to enable this behavior.
        /// </summary>
        /// <param name="container">The JSON container that the serialization result will be placed in.</param>
        /// <param name="returnNow">Determines if the rest of the serialization should be processed, or if the method should return
        /// instantly.</param>

        partial void BeforeToJson(ref Microsoft.Azure.PowerShell.Cmdlets.Websites.Runtime.Json.JsonObject container, ref bool returnNow);

        /// <summary>
        /// Deserializes a <see cref="Microsoft.Azure.PowerShell.Cmdlets.Websites.Runtime.Json.JsonNode"/> into an instance of Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IResponseMessageEnvelopeRemotePrivateEndpointConnection.
        /// </summary>
        /// <param name="node">a <see cref="Microsoft.Azure.PowerShell.Cmdlets.Websites.Runtime.Json.JsonNode" /> to deserialize from.</param>
        /// <returns>
        /// an instance of Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IResponseMessageEnvelopeRemotePrivateEndpointConnection.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IResponseMessageEnvelopeRemotePrivateEndpointConnection FromJson(Microsoft.Azure.PowerShell.Cmdlets.Websites.Runtime.Json.JsonNode node)
        {
            return node is Microsoft.Azure.PowerShell.Cmdlets.Websites.Runtime.Json.JsonObject json ? new ResponseMessageEnvelopeRemotePrivateEndpointConnection(json) : null;
        }

        /// <summary>
        /// Deserializes a Microsoft.Azure.PowerShell.Cmdlets.Websites.Runtime.Json.JsonObject into a new instance of <see cref="ResponseMessageEnvelopeRemotePrivateEndpointConnection"
        /// />.
        /// </summary>
        /// <param name="json">A Microsoft.Azure.PowerShell.Cmdlets.Websites.Runtime.Json.JsonObject instance to deserialize from.</param>
        internal ResponseMessageEnvelopeRemotePrivateEndpointConnection(Microsoft.Azure.PowerShell.Cmdlets.Websites.Runtime.Json.JsonObject json)
        {
            bool returnNow = false;
            BeforeFromJson(json, ref returnNow);
            if (returnNow)
            {
                return;
            }
            {_plan = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Websites.Runtime.Json.JsonObject>("plan"), out var __jsonPlan) ? Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.ArmPlan.FromJson(__jsonPlan) : Plan;}
            {_property = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Websites.Runtime.Json.JsonObject>("properties"), out var __jsonProperties) ? Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.RemotePrivateEndpointConnection.FromJson(__jsonProperties) : Property;}
            {_sku = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Websites.Runtime.Json.JsonObject>("sku"), out var __jsonSku) ? Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.SkuDescription.FromJson(__jsonSku) : Sku;}
            {_error = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Websites.Runtime.Json.JsonObject>("error"), out var __jsonError) ? Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.ErrorEntity.FromJson(__jsonError) : Error;}
            {_identity = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Websites.Runtime.Json.JsonObject>("identity"), out var __jsonIdentity) ? Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.ManagedServiceIdentity.FromJson(__jsonIdentity) : Identity;}
            {_id = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Websites.Runtime.Json.JsonString>("id"), out var __jsonId) ? (string)__jsonId : (string)Id;}
            {_name = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Websites.Runtime.Json.JsonString>("name"), out var __jsonName) ? (string)__jsonName : (string)Name;}
            {_type = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Websites.Runtime.Json.JsonString>("type"), out var __jsonType) ? (string)__jsonType : (string)Type;}
            {_location = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Websites.Runtime.Json.JsonString>("location"), out var __jsonLocation) ? (string)__jsonLocation : (string)Location;}
            {_tag = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Websites.Runtime.Json.JsonObject>("tags"), out var __jsonTags) ? Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.ResponseMessageEnvelopeRemotePrivateEndpointConnectionTags.FromJson(__jsonTags) : Tag;}
            {_status = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Websites.Runtime.Json.JsonString>("status"), out var __jsonStatus) ? (string)__jsonStatus : (string)Status;}
            {_zone = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Websites.Runtime.Json.JsonArray>("zones"), out var __jsonZones) ? If( __jsonZones as Microsoft.Azure.PowerShell.Cmdlets.Websites.Runtime.Json.JsonArray, out var __v) ? new global::System.Func<string[]>(()=> global::System.Linq.Enumerable.ToArray(global::System.Linq.Enumerable.Select(__v, (__u)=>(string) (__u is Microsoft.Azure.PowerShell.Cmdlets.Websites.Runtime.Json.JsonString __t ? (string)(__t.ToString()) : null)) ))() : null : Zone;}
            AfterFromJson(json);
        }

        /// <summary>
        /// Serializes this instance of <see cref="ResponseMessageEnvelopeRemotePrivateEndpointConnection" /> into a <see cref="Microsoft.Azure.PowerShell.Cmdlets.Websites.Runtime.Json.JsonNode"
        /// />.
        /// </summary>
        /// <param name="container">The <see cref="Microsoft.Azure.PowerShell.Cmdlets.Websites.Runtime.Json.JsonObject"/> container to serialize this object into. If the caller
        /// passes in <c>null</c>, a new instance will be created and returned to the caller.</param>
        /// <param name="serializationMode">Allows the caller to choose the depth of the serialization. See <see cref="Microsoft.Azure.PowerShell.Cmdlets.Websites.Runtime.SerializationMode"/>.</param>
        /// <returns>
        /// a serialized instance of <see cref="ResponseMessageEnvelopeRemotePrivateEndpointConnection" /> as a <see cref="Microsoft.Azure.PowerShell.Cmdlets.Websites.Runtime.Json.JsonNode"
        /// />.
        /// </returns>
        public Microsoft.Azure.PowerShell.Cmdlets.Websites.Runtime.Json.JsonNode ToJson(Microsoft.Azure.PowerShell.Cmdlets.Websites.Runtime.Json.JsonObject container, Microsoft.Azure.PowerShell.Cmdlets.Websites.Runtime.SerializationMode serializationMode)
        {
            container = container ?? new Microsoft.Azure.PowerShell.Cmdlets.Websites.Runtime.Json.JsonObject();

            bool returnNow = false;
            BeforeToJson(ref container, ref returnNow);
            if (returnNow)
            {
                return container;
            }
            AddIf( null != this._plan ? (Microsoft.Azure.PowerShell.Cmdlets.Websites.Runtime.Json.JsonNode) this._plan.ToJson(null,serializationMode) : null, "plan" ,container.Add );
            AddIf( null != this._property ? (Microsoft.Azure.PowerShell.Cmdlets.Websites.Runtime.Json.JsonNode) this._property.ToJson(null,serializationMode) : null, "properties" ,container.Add );
            AddIf( null != this._sku ? (Microsoft.Azure.PowerShell.Cmdlets.Websites.Runtime.Json.JsonNode) this._sku.ToJson(null,serializationMode) : null, "sku" ,container.Add );
            AddIf( null != this._error ? (Microsoft.Azure.PowerShell.Cmdlets.Websites.Runtime.Json.JsonNode) this._error.ToJson(null,serializationMode) : null, "error" ,container.Add );
            AddIf( null != this._identity ? (Microsoft.Azure.PowerShell.Cmdlets.Websites.Runtime.Json.JsonNode) this._identity.ToJson(null,serializationMode) : null, "identity" ,container.Add );
            AddIf( null != (((object)this._id)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.Websites.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Websites.Runtime.Json.JsonString(this._id.ToString()) : null, "id" ,container.Add );
            AddIf( null != (((object)this._name)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.Websites.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Websites.Runtime.Json.JsonString(this._name.ToString()) : null, "name" ,container.Add );
            AddIf( null != (((object)this._type)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.Websites.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Websites.Runtime.Json.JsonString(this._type.ToString()) : null, "type" ,container.Add );
            AddIf( null != (((object)this._location)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.Websites.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Websites.Runtime.Json.JsonString(this._location.ToString()) : null, "location" ,container.Add );
            AddIf( null != this._tag ? (Microsoft.Azure.PowerShell.Cmdlets.Websites.Runtime.Json.JsonNode) this._tag.ToJson(null,serializationMode) : null, "tags" ,container.Add );
            AddIf( null != (((object)this._status)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.Websites.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Websites.Runtime.Json.JsonString(this._status.ToString()) : null, "status" ,container.Add );
            if (null != this._zone)
            {
                var __w = new Microsoft.Azure.PowerShell.Cmdlets.Websites.Runtime.Json.XNodeArray();
                foreach( var __x in this._zone )
                {
                    AddIf(null != (((object)__x)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.Websites.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Websites.Runtime.Json.JsonString(__x.ToString()) : null ,__w.Add);
                }
                container.Add("zones",__w);
            }
            AfterToJson(ref container);
            return container;
        }
    }
}