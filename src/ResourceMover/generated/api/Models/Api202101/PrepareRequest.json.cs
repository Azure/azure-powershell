namespace Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101
{
    using static Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Runtime.Extensions;

    /// <summary>Defines the request body for initiate prepare operation.</summary>
    public partial class PrepareRequest
    {

        /// <summary>
        /// <c>AfterFromJson</c> will be called after the json deserialization has finished, allowing customization of the object
        /// before it is returned. Implement this method in a partial class to enable this behavior
        /// </summary>
        /// <param name="json">The JsonNode that should be deserialized into this object.</param>

        partial void AfterFromJson(Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Runtime.Json.JsonObject json);

        /// <summary>
        /// <c>AfterToJson</c> will be called after the json erialization has finished, allowing customization of the <see cref="Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Runtime.Json.JsonObject"
        /// /> before it is returned. Implement this method in a partial class to enable this behavior
        /// </summary>
        /// <param name="container">The JSON container that the serialization result will be placed in.</param>

        partial void AfterToJson(ref Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Runtime.Json.JsonObject container);

        /// <summary>
        /// <c>BeforeFromJson</c> will be called before the json deserialization has commenced, allowing complete customization of
        /// the object before it is deserialized.
        /// If you wish to disable the default deserialization entirely, return <c>true</c> in the <see "returnNow" /> output parameter.
        /// Implement this method in a partial class to enable this behavior.
        /// </summary>
        /// <param name="json">The JsonNode that should be deserialized into this object.</param>
        /// <param name="returnNow">Determines if the rest of the deserialization should be processed, or if the method should return
        /// instantly.</param>

        partial void BeforeFromJson(Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Runtime.Json.JsonObject json, ref bool returnNow);

        /// <summary>
        /// <c>BeforeToJson</c> will be called before the json serialization has commenced, allowing complete customization of the
        /// object before it is serialized.
        /// If you wish to disable the default serialization entirely, return <c>true</c> in the <see "returnNow" /> output parameter.
        /// Implement this method in a partial class to enable this behavior.
        /// </summary>
        /// <param name="container">The JSON container that the serialization result will be placed in.</param>
        /// <param name="returnNow">Determines if the rest of the serialization should be processed, or if the method should return
        /// instantly.</param>

        partial void BeforeToJson(ref Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Runtime.Json.JsonObject container, ref bool returnNow);

        /// <summary>
        /// Deserializes a <see cref="Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Runtime.Json.JsonNode"/> into an instance of Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.IPrepareRequest.
        /// </summary>
        /// <param name="node">a <see cref="Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Runtime.Json.JsonNode" /> to deserialize from.</param>
        /// <returns>
        /// an instance of Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.IPrepareRequest.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.IPrepareRequest FromJson(Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Runtime.Json.JsonNode node)
        {
            return node is Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Runtime.Json.JsonObject json ? new PrepareRequest(json) : null;
        }

        /// <summary>
        /// Deserializes a Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Runtime.Json.JsonObject into a new instance of <see cref="PrepareRequest" />.
        /// </summary>
        /// <param name="json">A Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Runtime.Json.JsonObject instance to deserialize from.</param>
        internal PrepareRequest(Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Runtime.Json.JsonObject json)
        {
            bool returnNow = false;
            BeforeFromJson(json, ref returnNow);
            if (returnNow)
            {
                return;
            }
            {_validateOnly = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Runtime.Json.JsonBoolean>("validateOnly"), out var __jsonValidateOnly) ? (bool?)__jsonValidateOnly : ValidateOnly;}
            {_moveResource = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Runtime.Json.JsonArray>("moveResources"), out var __jsonMoveResources) ? If( __jsonMoveResources as Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Runtime.Json.JsonArray, out var __v) ? new global::System.Func<string[]>(()=> global::System.Linq.Enumerable.ToArray(global::System.Linq.Enumerable.Select(__v, (__u)=>(string) (__u is Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Runtime.Json.JsonString __t ? (string)(__t.ToString()) : null)) ))() : null : MoveResource;}
            {_moveResourceInputType = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Runtime.Json.JsonString>("moveResourceInputType"), out var __jsonMoveResourceInputType) ? (string)__jsonMoveResourceInputType : (string)MoveResourceInputType;}
            AfterFromJson(json);
        }

        /// <summary>
        /// Serializes this instance of <see cref="PrepareRequest" /> into a <see cref="Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Runtime.Json.JsonNode" />.
        /// </summary>
        /// <param name="container">The <see cref="Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Runtime.Json.JsonObject"/> container to serialize this object into. If the caller
        /// passes in <c>null</c>, a new instance will be created and returned to the caller.</param>
        /// <param name="serializationMode">Allows the caller to choose the depth of the serialization. See <see cref="Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Runtime.SerializationMode"/>.</param>
        /// <returns>
        /// a serialized instance of <see cref="PrepareRequest" /> as a <see cref="Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Runtime.Json.JsonNode" />.
        /// </returns>
        public Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Runtime.Json.JsonNode ToJson(Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Runtime.Json.JsonObject container, Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Runtime.SerializationMode serializationMode)
        {
            container = container ?? new Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Runtime.Json.JsonObject();

            bool returnNow = false;
            BeforeToJson(ref container, ref returnNow);
            if (returnNow)
            {
                return container;
            }
            AddIf( null != this._validateOnly ? (Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Runtime.Json.JsonNode)new Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Runtime.Json.JsonBoolean((bool)this._validateOnly) : null, "validateOnly" ,container.Add );
            if (null != this._moveResource)
            {
                var __w = new Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Runtime.Json.XNodeArray();
                foreach( var __x in this._moveResource )
                {
                    AddIf(null != (((object)__x)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Runtime.Json.JsonString(__x.ToString()) : null ,__w.Add);
                }
                container.Add("moveResources",__w);
            }
            AddIf( null != (((object)this._moveResourceInputType)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Runtime.Json.JsonString(this._moveResourceInputType.ToString()) : null, "moveResourceInputType" ,container.Add );
            AfterToJson(ref container);
            return container;
        }
    }
}