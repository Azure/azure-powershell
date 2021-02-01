namespace Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api10
{
    using static Microsoft.Azure.PowerShell.Cmdlets.VMware.Runtime.Extensions;

    /// <summary>
    /// Common error response for all Azure Resource Manager APIs to return error details for failed operations. (This also follows
    /// the OData error response format.)
    /// </summary>
    public partial class ErrorResponse
    {

        /// <summary>
        /// <c>AfterFromJson</c> will be called after the json deserialization has finished, allowing customization of the object
        /// before it is returned. Implement this method in a partial class to enable this behavior
        /// </summary>
        /// <param name="json">The JsonNode that should be deserialized into this object.</param>

        partial void AfterFromJson(Microsoft.Azure.PowerShell.Cmdlets.VMware.Runtime.Json.JsonObject json);

        /// <summary>
        /// <c>AfterToJson</c> will be called after the json erialization has finished, allowing customization of the <see cref="Microsoft.Azure.PowerShell.Cmdlets.VMware.Runtime.Json.JsonObject"
        /// /> before it is returned. Implement this method in a partial class to enable this behavior
        /// </summary>
        /// <param name="container">The JSON container that the serialization result will be placed in.</param>

        partial void AfterToJson(ref Microsoft.Azure.PowerShell.Cmdlets.VMware.Runtime.Json.JsonObject container);

        /// <summary>
        /// <c>BeforeFromJson</c> will be called before the json deserialization has commenced, allowing complete customization of
        /// the object before it is deserialized.
        /// If you wish to disable the default deserialization entirely, return <c>true</c> in the <see "returnNow" /> output parameter.
        /// Implement this method in a partial class to enable this behavior.
        /// </summary>
        /// <param name="json">The JsonNode that should be deserialized into this object.</param>
        /// <param name="returnNow">Determines if the rest of the deserialization should be processed, or if the method should return
        /// instantly.</param>

        partial void BeforeFromJson(Microsoft.Azure.PowerShell.Cmdlets.VMware.Runtime.Json.JsonObject json, ref bool returnNow);

        /// <summary>
        /// <c>BeforeToJson</c> will be called before the json serialization has commenced, allowing complete customization of the
        /// object before it is serialized.
        /// If you wish to disable the default serialization entirely, return <c>true</c> in the <see "returnNow" /> output parameter.
        /// Implement this method in a partial class to enable this behavior.
        /// </summary>
        /// <param name="container">The JSON container that the serialization result will be placed in.</param>
        /// <param name="returnNow">Determines if the rest of the serialization should be processed, or if the method should return
        /// instantly.</param>

        partial void BeforeToJson(ref Microsoft.Azure.PowerShell.Cmdlets.VMware.Runtime.Json.JsonObject container, ref bool returnNow);

        /// <summary>
        /// Deserializes a Microsoft.Azure.PowerShell.Cmdlets.VMware.Runtime.Json.JsonObject into a new instance of <see cref="ErrorResponse" />.
        /// </summary>
        /// <param name="json">A Microsoft.Azure.PowerShell.Cmdlets.VMware.Runtime.Json.JsonObject instance to deserialize from.</param>
        internal ErrorResponse(Microsoft.Azure.PowerShell.Cmdlets.VMware.Runtime.Json.JsonObject json)
        {
            bool returnNow = false;
            BeforeFromJson(json, ref returnNow);
            if (returnNow)
            {
                return;
            }
            {_code = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.VMware.Runtime.Json.JsonString>("code"), out var __jsonCode) ? (string)__jsonCode : (string)Code;}
            {_message = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.VMware.Runtime.Json.JsonString>("message"), out var __jsonMessage) ? (string)__jsonMessage : (string)Message;}
            {_target = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.VMware.Runtime.Json.JsonString>("target"), out var __jsonTarget) ? (string)__jsonTarget : (string)Target;}
            {_detail = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.VMware.Runtime.Json.JsonArray>("details"), out var __jsonDetails) ? If( __jsonDetails as Microsoft.Azure.PowerShell.Cmdlets.VMware.Runtime.Json.JsonArray, out var __v) ? new global::System.Func<Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api10.IErrorResponse[]>(()=> global::System.Linq.Enumerable.ToArray(global::System.Linq.Enumerable.Select(__v, (__u)=>(Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api10.IErrorResponse) (Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api10.ErrorResponse.FromJson(__u) )) ))() : null : Detail;}
            {_additionalInfo = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.VMware.Runtime.Json.JsonArray>("additionalInfo"), out var __jsonAdditionalInfo) ? If( __jsonAdditionalInfo as Microsoft.Azure.PowerShell.Cmdlets.VMware.Runtime.Json.JsonArray, out var __q) ? new global::System.Func<Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api10.IErrorAdditionalInfo[]>(()=> global::System.Linq.Enumerable.ToArray(global::System.Linq.Enumerable.Select(__q, (__p)=>(Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api10.IErrorAdditionalInfo) (Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api10.ErrorAdditionalInfo.FromJson(__p) )) ))() : null : AdditionalInfo;}
            AfterFromJson(json);
        }

        /// <summary>
        /// Deserializes a <see cref="Microsoft.Azure.PowerShell.Cmdlets.VMware.Runtime.Json.JsonNode"/> into an instance of Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api10.IErrorResponse.
        /// </summary>
        /// <param name="node">a <see cref="Microsoft.Azure.PowerShell.Cmdlets.VMware.Runtime.Json.JsonNode" /> to deserialize from.</param>
        /// <returns>
        /// an instance of Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api10.IErrorResponse.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api10.IErrorResponse FromJson(Microsoft.Azure.PowerShell.Cmdlets.VMware.Runtime.Json.JsonNode node)
        {
            return node is Microsoft.Azure.PowerShell.Cmdlets.VMware.Runtime.Json.JsonObject json ? new ErrorResponse(json) : null;
        }

        /// <summary>
        /// Serializes this instance of <see cref="ErrorResponse" /> into a <see cref="Microsoft.Azure.PowerShell.Cmdlets.VMware.Runtime.Json.JsonNode" />.
        /// </summary>
        /// <param name="container">The <see cref="Microsoft.Azure.PowerShell.Cmdlets.VMware.Runtime.Json.JsonObject"/> container to serialize this object into. If the caller
        /// passes in <c>null</c>, a new instance will be created and returned to the caller.</param>
        /// <param name="serializationMode">Allows the caller to choose the depth of the serialization. See <see cref="Microsoft.Azure.PowerShell.Cmdlets.VMware.Runtime.SerializationMode"/>.</param>
        /// <returns>
        /// a serialized instance of <see cref="ErrorResponse" /> as a <see cref="Microsoft.Azure.PowerShell.Cmdlets.VMware.Runtime.Json.JsonNode" />.
        /// </returns>
        public Microsoft.Azure.PowerShell.Cmdlets.VMware.Runtime.Json.JsonNode ToJson(Microsoft.Azure.PowerShell.Cmdlets.VMware.Runtime.Json.JsonObject container, Microsoft.Azure.PowerShell.Cmdlets.VMware.Runtime.SerializationMode serializationMode)
        {
            container = container ?? new Microsoft.Azure.PowerShell.Cmdlets.VMware.Runtime.Json.JsonObject();

            bool returnNow = false;
            BeforeToJson(ref container, ref returnNow);
            if (returnNow)
            {
                return container;
            }
            if (serializationMode.HasFlag(Microsoft.Azure.PowerShell.Cmdlets.VMware.Runtime.SerializationMode.IncludeReadOnly))
            {
                AddIf( null != (((object)this._code)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.VMware.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.VMware.Runtime.Json.JsonString(this._code.ToString()) : null, "code" ,container.Add );
            }
            if (serializationMode.HasFlag(Microsoft.Azure.PowerShell.Cmdlets.VMware.Runtime.SerializationMode.IncludeReadOnly))
            {
                AddIf( null != (((object)this._message)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.VMware.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.VMware.Runtime.Json.JsonString(this._message.ToString()) : null, "message" ,container.Add );
            }
            if (serializationMode.HasFlag(Microsoft.Azure.PowerShell.Cmdlets.VMware.Runtime.SerializationMode.IncludeReadOnly))
            {
                AddIf( null != (((object)this._target)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.VMware.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.VMware.Runtime.Json.JsonString(this._target.ToString()) : null, "target" ,container.Add );
            }
            if (serializationMode.HasFlag(Microsoft.Azure.PowerShell.Cmdlets.VMware.Runtime.SerializationMode.IncludeReadOnly))
            {
                if (null != this._detail)
                {
                    var __w = new Microsoft.Azure.PowerShell.Cmdlets.VMware.Runtime.Json.XNodeArray();
                    foreach( var __x in this._detail )
                    {
                        AddIf(__x?.ToJson(null, serializationMode) ,__w.Add);
                    }
                    container.Add("details",__w);
                }
            }
            if (serializationMode.HasFlag(Microsoft.Azure.PowerShell.Cmdlets.VMware.Runtime.SerializationMode.IncludeReadOnly))
            {
                if (null != this._additionalInfo)
                {
                    var __r = new Microsoft.Azure.PowerShell.Cmdlets.VMware.Runtime.Json.XNodeArray();
                    foreach( var __s in this._additionalInfo )
                    {
                        AddIf(__s?.ToJson(null, serializationMode) ,__r.Add);
                    }
                    container.Add("additionalInfo",__r);
                }
            }
            AfterToJson(ref container);
            return container;
        }
    }
}