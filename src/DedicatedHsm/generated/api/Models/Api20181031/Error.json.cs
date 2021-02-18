namespace Microsoft.Azure.PowerShell.Cmdlets.DedicatedHsm.Models.Api20181031
{
    using static Microsoft.Azure.PowerShell.Cmdlets.DedicatedHsm.Runtime.Extensions;

    /// <summary>The key vault server error.</summary>
    public partial class Error
    {

        /// <summary>
        /// <c>AfterFromJson</c> will be called after the json deserialization has finished, allowing customization of the object
        /// before it is returned. Implement this method in a partial class to enable this behavior
        /// </summary>
        /// <param name="json">The JsonNode that should be deserialized into this object.</param>

        partial void AfterFromJson(Microsoft.Azure.PowerShell.Cmdlets.DedicatedHsm.Runtime.Json.JsonObject json);

        /// <summary>
        /// <c>AfterToJson</c> will be called after the json erialization has finished, allowing customization of the <see cref="Microsoft.Azure.PowerShell.Cmdlets.DedicatedHsm.Runtime.Json.JsonObject"
        /// /> before it is returned. Implement this method in a partial class to enable this behavior
        /// </summary>
        /// <param name="container">The JSON container that the serialization result will be placed in.</param>

        partial void AfterToJson(ref Microsoft.Azure.PowerShell.Cmdlets.DedicatedHsm.Runtime.Json.JsonObject container);

        /// <summary>
        /// <c>BeforeFromJson</c> will be called before the json deserialization has commenced, allowing complete customization of
        /// the object before it is deserialized.
        /// If you wish to disable the default deserialization entirely, return <c>true</c> in the <see "returnNow" /> output parameter.
        /// Implement this method in a partial class to enable this behavior.
        /// </summary>
        /// <param name="json">The JsonNode that should be deserialized into this object.</param>
        /// <param name="returnNow">Determines if the rest of the deserialization should be processed, or if the method should return
        /// instantly.</param>

        partial void BeforeFromJson(Microsoft.Azure.PowerShell.Cmdlets.DedicatedHsm.Runtime.Json.JsonObject json, ref bool returnNow);

        /// <summary>
        /// <c>BeforeToJson</c> will be called before the json serialization has commenced, allowing complete customization of the
        /// object before it is serialized.
        /// If you wish to disable the default serialization entirely, return <c>true</c> in the <see "returnNow" /> output parameter.
        /// Implement this method in a partial class to enable this behavior.
        /// </summary>
        /// <param name="container">The JSON container that the serialization result will be placed in.</param>
        /// <param name="returnNow">Determines if the rest of the serialization should be processed, or if the method should return
        /// instantly.</param>

        partial void BeforeToJson(ref Microsoft.Azure.PowerShell.Cmdlets.DedicatedHsm.Runtime.Json.JsonObject container, ref bool returnNow);

        /// <summary>
        /// Deserializes a Microsoft.Azure.PowerShell.Cmdlets.DedicatedHsm.Runtime.Json.JsonObject into a new instance of <see cref="Error" />.
        /// </summary>
        /// <param name="json">A Microsoft.Azure.PowerShell.Cmdlets.DedicatedHsm.Runtime.Json.JsonObject instance to deserialize from.</param>
        internal Error(Microsoft.Azure.PowerShell.Cmdlets.DedicatedHsm.Runtime.Json.JsonObject json)
        {
            bool returnNow = false;
            BeforeFromJson(json, ref returnNow);
            if (returnNow)
            {
                return;
            }
            {_code = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.DedicatedHsm.Runtime.Json.JsonString>("code"), out var __jsonCode) ? (string)__jsonCode : (string)Code;}
            {_message = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.DedicatedHsm.Runtime.Json.JsonString>("message"), out var __jsonMessage) ? (string)__jsonMessage : (string)Message;}
            {_innerError = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.DedicatedHsm.Runtime.Json.JsonObject>("innererror"), out var __jsonInnererror) ? Microsoft.Azure.PowerShell.Cmdlets.DedicatedHsm.Models.Api20181031.Error.FromJson(__jsonInnererror) : InnerError;}
            AfterFromJson(json);
        }

        /// <summary>
        /// Deserializes a <see cref="Microsoft.Azure.PowerShell.Cmdlets.DedicatedHsm.Runtime.Json.JsonNode"/> into an instance of Microsoft.Azure.PowerShell.Cmdlets.DedicatedHsm.Models.Api20181031.IError.
        /// </summary>
        /// <param name="node">a <see cref="Microsoft.Azure.PowerShell.Cmdlets.DedicatedHsm.Runtime.Json.JsonNode" /> to deserialize from.</param>
        /// <returns>
        /// an instance of Microsoft.Azure.PowerShell.Cmdlets.DedicatedHsm.Models.Api20181031.IError.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.DedicatedHsm.Models.Api20181031.IError FromJson(Microsoft.Azure.PowerShell.Cmdlets.DedicatedHsm.Runtime.Json.JsonNode node)
        {
            return node is Microsoft.Azure.PowerShell.Cmdlets.DedicatedHsm.Runtime.Json.JsonObject json ? new Error(json) : null;
        }

        /// <summary>
        /// Serializes this instance of <see cref="Error" /> into a <see cref="Microsoft.Azure.PowerShell.Cmdlets.DedicatedHsm.Runtime.Json.JsonNode" />.
        /// </summary>
        /// <param name="container">The <see cref="Microsoft.Azure.PowerShell.Cmdlets.DedicatedHsm.Runtime.Json.JsonObject"/> container to serialize this object into. If the caller
        /// passes in <c>null</c>, a new instance will be created and returned to the caller.</param>
        /// <param name="serializationMode">Allows the caller to choose the depth of the serialization. See <see cref="Microsoft.Azure.PowerShell.Cmdlets.DedicatedHsm.Runtime.SerializationMode"/>.</param>
        /// <returns>
        /// a serialized instance of <see cref="Error" /> as a <see cref="Microsoft.Azure.PowerShell.Cmdlets.DedicatedHsm.Runtime.Json.JsonNode" />.
        /// </returns>
        public Microsoft.Azure.PowerShell.Cmdlets.DedicatedHsm.Runtime.Json.JsonNode ToJson(Microsoft.Azure.PowerShell.Cmdlets.DedicatedHsm.Runtime.Json.JsonObject container, Microsoft.Azure.PowerShell.Cmdlets.DedicatedHsm.Runtime.SerializationMode serializationMode)
        {
            container = container ?? new Microsoft.Azure.PowerShell.Cmdlets.DedicatedHsm.Runtime.Json.JsonObject();

            bool returnNow = false;
            BeforeToJson(ref container, ref returnNow);
            if (returnNow)
            {
                return container;
            }
            if (serializationMode.HasFlag(Microsoft.Azure.PowerShell.Cmdlets.DedicatedHsm.Runtime.SerializationMode.IncludeReadOnly))
            {
                AddIf( null != (((object)this._code)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.DedicatedHsm.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.DedicatedHsm.Runtime.Json.JsonString(this._code.ToString()) : null, "code" ,container.Add );
            }
            if (serializationMode.HasFlag(Microsoft.Azure.PowerShell.Cmdlets.DedicatedHsm.Runtime.SerializationMode.IncludeReadOnly))
            {
                AddIf( null != (((object)this._message)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.DedicatedHsm.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.DedicatedHsm.Runtime.Json.JsonString(this._message.ToString()) : null, "message" ,container.Add );
            }
            if (serializationMode.HasFlag(Microsoft.Azure.PowerShell.Cmdlets.DedicatedHsm.Runtime.SerializationMode.IncludeReadOnly))
            {
                AddIf( null != this._innerError ? (Microsoft.Azure.PowerShell.Cmdlets.DedicatedHsm.Runtime.Json.JsonNode) this._innerError.ToJson(null,serializationMode) : null, "innererror" ,container.Add );
            }
            AfterToJson(ref container);
            return container;
        }
    }
}