namespace Microsoft.Azure.PowerShell.Cmdlets.DigitalTwins.Models.Api20201031
{
    using static Microsoft.Azure.PowerShell.Cmdlets.DigitalTwins.Runtime.Extensions;

    /// <summary>Properties related to Digital Twins Endpoint</summary>
    public partial class DigitalTwinsEndpointResourceProperties
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
        /// Deserializes a Microsoft.Azure.PowerShell.Cmdlets.DigitalTwins.Runtime.Json.JsonObject into a new instance of <see cref="DigitalTwinsEndpointResourceProperties" />.
        /// </summary>
        /// <param name="json">A Microsoft.Azure.PowerShell.Cmdlets.DigitalTwins.Runtime.Json.JsonObject instance to deserialize from.</param>
        internal DigitalTwinsEndpointResourceProperties(Microsoft.Azure.PowerShell.Cmdlets.DigitalTwins.Runtime.Json.JsonObject json)
        {
            bool returnNow = false;
            BeforeFromJson(json, ref returnNow);
            if (returnNow)
            {
                return;
            }
            {_endpointType = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.DigitalTwins.Runtime.Json.JsonString>("endpointType"), out var __jsonEndpointType) ? (string)__jsonEndpointType : (string)EndpointType;}
            {_provisioningState = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.DigitalTwins.Runtime.Json.JsonString>("provisioningState"), out var __jsonProvisioningState) ? (string)__jsonProvisioningState : (string)ProvisioningState;}
            {_createdTime = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.DigitalTwins.Runtime.Json.JsonString>("createdTime"), out var __jsonCreatedTime) ? global::System.DateTime.TryParse((string)__jsonCreatedTime, global::System.Globalization.CultureInfo.InvariantCulture, global::System.Globalization.DateTimeStyles.AdjustToUniversal, out var __jsonCreatedTimeValue) ? __jsonCreatedTimeValue : CreatedTime : CreatedTime;}
            {_deadLetterSecret = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.DigitalTwins.Runtime.Json.JsonString>("deadLetterSecret"), out var __jsonDeadLetterSecret) ? (string)__jsonDeadLetterSecret : (string)DeadLetterSecret;}
            AfterFromJson(json);
        }

        /// <summary>
        /// Deserializes a <see cref="Microsoft.Azure.PowerShell.Cmdlets.DigitalTwins.Runtime.Json.JsonNode"/> into an instance of Microsoft.Azure.PowerShell.Cmdlets.DigitalTwins.Models.Api20201031.IDigitalTwinsEndpointResourceProperties.
        /// Note: the Microsoft.Azure.PowerShell.Cmdlets.DigitalTwins.Models.Api20201031.IDigitalTwinsEndpointResourceProperties interface
        /// is polymorphic, and the precise model class that will get deserialized is determined at runtime based on the payload.
        /// </summary>
        /// <param name="node">a <see cref="Microsoft.Azure.PowerShell.Cmdlets.DigitalTwins.Runtime.Json.JsonNode" /> to deserialize from.</param>
        /// <returns>
        /// an instance of Microsoft.Azure.PowerShell.Cmdlets.DigitalTwins.Models.Api20201031.IDigitalTwinsEndpointResourceProperties.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.DigitalTwins.Models.Api20201031.IDigitalTwinsEndpointResourceProperties FromJson(Microsoft.Azure.PowerShell.Cmdlets.DigitalTwins.Runtime.Json.JsonNode node)
        {
            if (!(node is Microsoft.Azure.PowerShell.Cmdlets.DigitalTwins.Runtime.Json.JsonObject json))
            {
                return null;
            }
            // Polymorphic type -- select the appropriate constructor using the discriminator

            switch ( json.StringProperty("endpointType") )
            {
                case "ServiceBus":
                {
                    return new ServiceBus(json);
                }
                case "EventHub":
                {
                    return new EventHub(json);
                }
                case "EventGrid":
                {
                    return new EventGrid(json);
                }
            }
            return new DigitalTwinsEndpointResourceProperties(json);
        }

        /// <summary>
        /// Serializes this instance of <see cref="DigitalTwinsEndpointResourceProperties" /> into a <see cref="Microsoft.Azure.PowerShell.Cmdlets.DigitalTwins.Runtime.Json.JsonNode"
        /// />.
        /// </summary>
        /// <param name="container">The <see cref="Microsoft.Azure.PowerShell.Cmdlets.DigitalTwins.Runtime.Json.JsonObject"/> container to serialize this object into. If the caller
        /// passes in <c>null</c>, a new instance will be created and returned to the caller.</param>
        /// <param name="serializationMode">Allows the caller to choose the depth of the serialization. See <see cref="Microsoft.Azure.PowerShell.Cmdlets.DigitalTwins.Runtime.SerializationMode"/>.</param>
        /// <returns>
        /// a serialized instance of <see cref="DigitalTwinsEndpointResourceProperties" /> as a <see cref="Microsoft.Azure.PowerShell.Cmdlets.DigitalTwins.Runtime.Json.JsonNode" />.
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
            AddIf( null != (((object)this._endpointType)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.DigitalTwins.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.DigitalTwins.Runtime.Json.JsonString(this._endpointType.ToString()) : null, "endpointType" ,container.Add );
            if (serializationMode.HasFlag(Microsoft.Azure.PowerShell.Cmdlets.DigitalTwins.Runtime.SerializationMode.IncludeReadOnly))
            {
                AddIf( null != (((object)this._provisioningState)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.DigitalTwins.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.DigitalTwins.Runtime.Json.JsonString(this._provisioningState.ToString()) : null, "provisioningState" ,container.Add );
            }
            if (serializationMode.HasFlag(Microsoft.Azure.PowerShell.Cmdlets.DigitalTwins.Runtime.SerializationMode.IncludeReadOnly))
            {
                AddIf( null != this._createdTime ? (Microsoft.Azure.PowerShell.Cmdlets.DigitalTwins.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.DigitalTwins.Runtime.Json.JsonString(this._createdTime?.ToString(@"yyyy'-'MM'-'dd'T'HH':'mm':'ss.fffffffK",global::System.Globalization.CultureInfo.InvariantCulture)) : null, "createdTime" ,container.Add );
            }
            AddIf( null != (((object)this._deadLetterSecret)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.DigitalTwins.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.DigitalTwins.Runtime.Json.JsonString(this._deadLetterSecret.ToString()) : null, "deadLetterSecret" ,container.Add );
            AfterToJson(ref container);
            return container;
        }
    }
}