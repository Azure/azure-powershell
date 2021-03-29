namespace Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20210201Preview
{
    using static Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Extensions;

    /// <summary>The resource management error response.</summary>
    public partial class Error
    {

        /// <summary>
        /// <c>AfterFromJson</c> will be called after the json deserialization has finished, allowing customization of the object
        /// before it is returned. Implement this method in a partial class to enable this behavior
        /// </summary>
        /// <param name="json">The JsonNode that should be deserialized into this object.</param>

        partial void AfterFromJson(Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Json.JsonObject json);

        /// <summary>
        /// <c>AfterToJson</c> will be called after the json erialization has finished, allowing customization of the <see cref="Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Json.JsonObject"
        /// /> before it is returned. Implement this method in a partial class to enable this behavior
        /// </summary>
        /// <param name="container">The JSON container that the serialization result will be placed in.</param>

        partial void AfterToJson(ref Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Json.JsonObject container);

        /// <summary>
        /// <c>BeforeFromJson</c> will be called before the json deserialization has commenced, allowing complete customization of
        /// the object before it is deserialized.
        /// If you wish to disable the default deserialization entirely, return <c>true</c> in the <see "returnNow" /> output parameter.
        /// Implement this method in a partial class to enable this behavior.
        /// </summary>
        /// <param name="json">The JsonNode that should be deserialized into this object.</param>
        /// <param name="returnNow">Determines if the rest of the deserialization should be processed, or if the method should return
        /// instantly.</param>

        partial void BeforeFromJson(Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Json.JsonObject json, ref bool returnNow);

        /// <summary>
        /// <c>BeforeToJson</c> will be called before the json serialization has commenced, allowing complete customization of the
        /// object before it is serialized.
        /// If you wish to disable the default serialization entirely, return <c>true</c> in the <see "returnNow" /> output parameter.
        /// Implement this method in a partial class to enable this behavior.
        /// </summary>
        /// <param name="container">The JSON container that the serialization result will be placed in.</param>
        /// <param name="returnNow">Determines if the rest of the serialization should be processed, or if the method should return
        /// instantly.</param>

        partial void BeforeToJson(ref Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Json.JsonObject container, ref bool returnNow);

        /// <summary>
        /// Deserializes a Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Json.JsonObject into a new instance of <see cref="Error" />.
        /// </summary>
        /// <param name="json">A Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Json.JsonObject instance to deserialize from.</param>
        internal Error(Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Json.JsonObject json)
        {
            bool returnNow = false;
            BeforeFromJson(json, ref returnNow);
            if (returnNow)
            {
                return;
            }
            {_additionalInfo = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Json.JsonArray>("additionalInfo"), out var __jsonAdditionalInfo) ? If( __jsonAdditionalInfo as Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Json.JsonArray, out var __v) ? new global::System.Func<Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20210201Preview.IErrorAdditionalInfo[]>(()=> global::System.Linq.Enumerable.ToArray(global::System.Linq.Enumerable.Select(__v, (__u)=>(Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20210201Preview.IErrorAdditionalInfo) (Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20210201Preview.ErrorAdditionalInfo.FromJson(__u) )) ))() : null : AdditionalInfo;}
            {_code = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Json.JsonString>("code"), out var __jsonCode) ? (string)__jsonCode : (string)Code;}
            {_detail = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Json.JsonArray>("details"), out var __jsonDetails) ? If( __jsonDetails as Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Json.JsonArray, out var __q) ? new global::System.Func<Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20210201Preview.IError[]>(()=> global::System.Linq.Enumerable.ToArray(global::System.Linq.Enumerable.Select(__q, (__p)=>(Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20210201Preview.IError) (Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20210201Preview.Error.FromJson(__p) )) ))() : null : Detail;}
            {_message = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Json.JsonString>("message"), out var __jsonMessage) ? (string)__jsonMessage : (string)Message;}
            {_target = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Json.JsonString>("target"), out var __jsonTarget) ? (string)__jsonTarget : (string)Target;}
            AfterFromJson(json);
        }

        /// <summary>
        /// Deserializes a <see cref="Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Json.JsonNode"/> into an instance of Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20210201Preview.IError.
        /// </summary>
        /// <param name="node">a <see cref="Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Json.JsonNode" /> to deserialize from.</param>
        /// <returns>
        /// an instance of Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20210201Preview.IError.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20210201Preview.IError FromJson(Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Json.JsonNode node)
        {
            return node is Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Json.JsonObject json ? new Error(json) : null;
        }

        /// <summary>
        /// Serializes this instance of <see cref="Error" /> into a <see cref="Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Json.JsonNode" />.
        /// </summary>
        /// <param name="container">The <see cref="Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Json.JsonObject"/> container to serialize this object into. If the caller
        /// passes in <c>null</c>, a new instance will be created and returned to the caller.</param>
        /// <param name="serializationMode">Allows the caller to choose the depth of the serialization. See <see cref="Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.SerializationMode"/>.</param>
        /// <returns>
        /// a serialized instance of <see cref="Error" /> as a <see cref="Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Json.JsonNode" />.
        /// </returns>
        public Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Json.JsonNode ToJson(Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Json.JsonObject container, Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.SerializationMode serializationMode)
        {
            container = container ?? new Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Json.JsonObject();

            bool returnNow = false;
            BeforeToJson(ref container, ref returnNow);
            if (returnNow)
            {
                return container;
            }
            if (serializationMode.HasFlag(Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.SerializationMode.IncludeReadOnly))
            {
                if (null != this._additionalInfo)
                {
                    var __w = new Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Json.XNodeArray();
                    foreach( var __x in this._additionalInfo )
                    {
                        AddIf(__x?.ToJson(null, serializationMode) ,__w.Add);
                    }
                    container.Add("additionalInfo",__w);
                }
            }
            if (serializationMode.HasFlag(Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.SerializationMode.IncludeReadOnly))
            {
                AddIf( null != (((object)this._code)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Json.JsonString(this._code.ToString()) : null, "code" ,container.Add );
            }
            if (serializationMode.HasFlag(Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.SerializationMode.IncludeReadOnly))
            {
                if (null != this._detail)
                {
                    var __r = new Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Json.XNodeArray();
                    foreach( var __s in this._detail )
                    {
                        AddIf(__s?.ToJson(null, serializationMode) ,__r.Add);
                    }
                    container.Add("details",__r);
                }
            }
            if (serializationMode.HasFlag(Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.SerializationMode.IncludeReadOnly))
            {
                AddIf( null != (((object)this._message)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Json.JsonString(this._message.ToString()) : null, "message" ,container.Add );
            }
            if (serializationMode.HasFlag(Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.SerializationMode.IncludeReadOnly))
            {
                AddIf( null != (((object)this._target)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Json.JsonString(this._target.ToString()) : null, "target" ,container.Add );
            }
            AfterToJson(ref container);
            return container;
        }
    }
}