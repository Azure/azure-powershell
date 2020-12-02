namespace Microsoft.Azure.PowerShell.Cmdlets.DigitalTwins.Models.Api20201031
{
    using static Microsoft.Azure.PowerShell.Cmdlets.DigitalTwins.Runtime.Extensions;

    /// <summary>Properties related to EventGrid.</summary>
    public partial class EventGrid
    {

        /// <summary>
        /// <c>AfterFromJson</c> will be called after the json deserialization has finished, allowing customization of the object
        /// before it is returned. Implement this method in a partial class to enable this behavior
        /// </summary>
        /// <param name="json">The JsonNode that should be deserialized into this object.</param>

        partial void AfterFromJson(Microsoft.Azure.PowerShell.Cmdlets.DigitalTwins.Runtime.Json.JsonObject json);

        /// <summary>
        /// <c>AfterToJson</c> will be called after the json erialization has finished, allowing customization of the <see cref="Microsoft.Azure.PowerShell.Cmdlets.DigitalTwins.Runtime.Json.JsonObject"
        /// /> before it is returned. Implement this method in a partial class to enable this behavior
        /// </summary>
        /// <param name="container">The JSON container that the serialization result will be placed in.</param>

        partial void AfterToJson(ref Microsoft.Azure.PowerShell.Cmdlets.DigitalTwins.Runtime.Json.JsonObject container);

        /// <summary>
        /// <c>BeforeFromJson</c> will be called before the json deserialization has commenced, allowing complete customization of
        /// the object before it is deserialized.
        /// If you wish to disable the default deserialization entirely, return <c>true</c> in the <see "returnNow" /> output parameter.
        /// Implement this method in a partial class to enable this behavior.
        /// </summary>
        /// <param name="json">The JsonNode that should be deserialized into this object.</param>
        /// <param name="returnNow">Determines if the rest of the deserialization should be processed, or if the method should return
        /// instantly.</param>

        partial void BeforeFromJson(Microsoft.Azure.PowerShell.Cmdlets.DigitalTwins.Runtime.Json.JsonObject json, ref bool returnNow);

        /// <summary>
        /// <c>BeforeToJson</c> will be called before the json serialization has commenced, allowing complete customization of the
        /// object before it is serialized.
        /// If you wish to disable the default serialization entirely, return <c>true</c> in the <see "returnNow" /> output parameter.
        /// Implement this method in a partial class to enable this behavior.
        /// </summary>
        /// <param name="container">The JSON container that the serialization result will be placed in.</param>
        /// <param name="returnNow">Determines if the rest of the serialization should be processed, or if the method should return
        /// instantly.</param>

        partial void BeforeToJson(ref Microsoft.Azure.PowerShell.Cmdlets.DigitalTwins.Runtime.Json.JsonObject container, ref bool returnNow);

        /// <summary>
        /// Deserializes a Microsoft.Azure.PowerShell.Cmdlets.DigitalTwins.Runtime.Json.JsonObject into a new instance of <see cref="EventGrid" />.
        /// </summary>
        /// <param name="json">A Microsoft.Azure.PowerShell.Cmdlets.DigitalTwins.Runtime.Json.JsonObject instance to deserialize from.</param>
        internal EventGrid(Microsoft.Azure.PowerShell.Cmdlets.DigitalTwins.Runtime.Json.JsonObject json)
        {
            bool returnNow = false;
            BeforeFromJson(json, ref returnNow);
            if (returnNow)
            {
                return;
            }
            __digitalTwinsEndpointResourceProperties = new Microsoft.Azure.PowerShell.Cmdlets.DigitalTwins.Models.Api20201031.DigitalTwinsEndpointResourceProperties(json);
            {_topicEndpoint = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.DigitalTwins.Runtime.Json.JsonString>("TopicEndpoint"), out var __jsonTopicEndpoint) ? (string)__jsonTopicEndpoint : (string)TopicEndpoint;}
            {_accessKey1 = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.DigitalTwins.Runtime.Json.JsonString>("accessKey1"), out var __jsonAccessKey1) ? (string)__jsonAccessKey1 : (string)AccessKey1;}
            {_accessKey2 = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.DigitalTwins.Runtime.Json.JsonString>("accessKey2"), out var __jsonAccessKey2) ? (string)__jsonAccessKey2 : (string)AccessKey2;}
            AfterFromJson(json);
        }

        /// <summary>
        /// Deserializes a <see cref="Microsoft.Azure.PowerShell.Cmdlets.DigitalTwins.Runtime.Json.JsonNode"/> into an instance of Microsoft.Azure.PowerShell.Cmdlets.DigitalTwins.Models.Api20201031.IEventGrid.
        /// </summary>
        /// <param name="node">a <see cref="Microsoft.Azure.PowerShell.Cmdlets.DigitalTwins.Runtime.Json.JsonNode" /> to deserialize from.</param>
        /// <returns>
        /// an instance of Microsoft.Azure.PowerShell.Cmdlets.DigitalTwins.Models.Api20201031.IEventGrid.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.DigitalTwins.Models.Api20201031.IEventGrid FromJson(Microsoft.Azure.PowerShell.Cmdlets.DigitalTwins.Runtime.Json.JsonNode node)
        {
            return node is Microsoft.Azure.PowerShell.Cmdlets.DigitalTwins.Runtime.Json.JsonObject json ? new EventGrid(json) : null;
        }

        /// <summary>
        /// Serializes this instance of <see cref="EventGrid" /> into a <see cref="Microsoft.Azure.PowerShell.Cmdlets.DigitalTwins.Runtime.Json.JsonNode" />.
        /// </summary>
        /// <param name="container">The <see cref="Microsoft.Azure.PowerShell.Cmdlets.DigitalTwins.Runtime.Json.JsonObject"/> container to serialize this object into. If the caller
        /// passes in <c>null</c>, a new instance will be created and returned to the caller.</param>
        /// <param name="serializationMode">Allows the caller to choose the depth of the serialization. See <see cref="Microsoft.Azure.PowerShell.Cmdlets.DigitalTwins.Runtime.SerializationMode"/>.</param>
        /// <returns>
        /// a serialized instance of <see cref="EventGrid" /> as a <see cref="Microsoft.Azure.PowerShell.Cmdlets.DigitalTwins.Runtime.Json.JsonNode" />.
        /// </returns>
        public Microsoft.Azure.PowerShell.Cmdlets.DigitalTwins.Runtime.Json.JsonNode ToJson(Microsoft.Azure.PowerShell.Cmdlets.DigitalTwins.Runtime.Json.JsonObject container, Microsoft.Azure.PowerShell.Cmdlets.DigitalTwins.Runtime.SerializationMode serializationMode)
        {
            container = container ?? new Microsoft.Azure.PowerShell.Cmdlets.DigitalTwins.Runtime.Json.JsonObject();

            bool returnNow = false;
            BeforeToJson(ref container, ref returnNow);
            if (returnNow)
            {
                return container;
            }
            __digitalTwinsEndpointResourceProperties?.ToJson(container, serializationMode);
            AddIf( null != (((object)this._topicEndpoint)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.DigitalTwins.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.DigitalTwins.Runtime.Json.JsonString(this._topicEndpoint.ToString()) : null, "TopicEndpoint" ,container.Add );
            AddIf( null != (((object)this._accessKey1)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.DigitalTwins.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.DigitalTwins.Runtime.Json.JsonString(this._accessKey1.ToString()) : null, "accessKey1" ,container.Add );
            AddIf( null != (((object)this._accessKey2)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.DigitalTwins.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.DigitalTwins.Runtime.Json.JsonString(this._accessKey2.ToString()) : null, "accessKey2" ,container.Add );
            AfterToJson(ref container);
            return container;
        }
    }
}