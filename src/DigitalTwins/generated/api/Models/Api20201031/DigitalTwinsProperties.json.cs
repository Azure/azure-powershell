namespace Microsoft.Azure.PowerShell.Cmdlets.DigitalTwins.Models.Api20201031
{
    using static Microsoft.Azure.PowerShell.Cmdlets.DigitalTwins.Runtime.Extensions;

    /// <summary>The properties of a DigitalTwinsInstance.</summary>
    public partial class DigitalTwinsProperties
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
        /// Deserializes a Microsoft.Azure.PowerShell.Cmdlets.DigitalTwins.Runtime.Json.JsonObject into a new instance of <see cref="DigitalTwinsProperties" />.
        /// </summary>
        /// <param name="json">A Microsoft.Azure.PowerShell.Cmdlets.DigitalTwins.Runtime.Json.JsonObject instance to deserialize from.</param>
        internal DigitalTwinsProperties(Microsoft.Azure.PowerShell.Cmdlets.DigitalTwins.Runtime.Json.JsonObject json)
        {
            bool returnNow = false;
            BeforeFromJson(json, ref returnNow);
            if (returnNow)
            {
                return;
            }
            {_createdTime = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.DigitalTwins.Runtime.Json.JsonString>("createdTime"), out var __jsonCreatedTime) ? global::System.DateTime.TryParse((string)__jsonCreatedTime, global::System.Globalization.CultureInfo.InvariantCulture, global::System.Globalization.DateTimeStyles.AdjustToUniversal, out var __jsonCreatedTimeValue) ? __jsonCreatedTimeValue : CreatedTime : CreatedTime;}
            {_lastUpdatedTime = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.DigitalTwins.Runtime.Json.JsonString>("lastUpdatedTime"), out var __jsonLastUpdatedTime) ? global::System.DateTime.TryParse((string)__jsonLastUpdatedTime, global::System.Globalization.CultureInfo.InvariantCulture, global::System.Globalization.DateTimeStyles.AdjustToUniversal, out var __jsonLastUpdatedTimeValue) ? __jsonLastUpdatedTimeValue : LastUpdatedTime : LastUpdatedTime;}
            {_provisioningState = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.DigitalTwins.Runtime.Json.JsonString>("provisioningState"), out var __jsonProvisioningState) ? (string)__jsonProvisioningState : (string)ProvisioningState;}
            {_hostName = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.DigitalTwins.Runtime.Json.JsonString>("hostName"), out var __jsonHostName) ? (string)__jsonHostName : (string)HostName;}
            AfterFromJson(json);
        }

        /// <summary>
        /// Deserializes a <see cref="Microsoft.Azure.PowerShell.Cmdlets.DigitalTwins.Runtime.Json.JsonNode"/> into an instance of Microsoft.Azure.PowerShell.Cmdlets.DigitalTwins.Models.Api20201031.IDigitalTwinsProperties.
        /// </summary>
        /// <param name="node">a <see cref="Microsoft.Azure.PowerShell.Cmdlets.DigitalTwins.Runtime.Json.JsonNode" /> to deserialize from.</param>
        /// <returns>
        /// an instance of Microsoft.Azure.PowerShell.Cmdlets.DigitalTwins.Models.Api20201031.IDigitalTwinsProperties.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.DigitalTwins.Models.Api20201031.IDigitalTwinsProperties FromJson(Microsoft.Azure.PowerShell.Cmdlets.DigitalTwins.Runtime.Json.JsonNode node)
        {
            return node is Microsoft.Azure.PowerShell.Cmdlets.DigitalTwins.Runtime.Json.JsonObject json ? new DigitalTwinsProperties(json) : null;
        }

        /// <summary>
        /// Serializes this instance of <see cref="DigitalTwinsProperties" /> into a <see cref="Microsoft.Azure.PowerShell.Cmdlets.DigitalTwins.Runtime.Json.JsonNode" />.
        /// </summary>
        /// <param name="container">The <see cref="Microsoft.Azure.PowerShell.Cmdlets.DigitalTwins.Runtime.Json.JsonObject"/> container to serialize this object into. If the caller
        /// passes in <c>null</c>, a new instance will be created and returned to the caller.</param>
        /// <param name="serializationMode">Allows the caller to choose the depth of the serialization. See <see cref="Microsoft.Azure.PowerShell.Cmdlets.DigitalTwins.Runtime.SerializationMode"/>.</param>
        /// <returns>
        /// a serialized instance of <see cref="DigitalTwinsProperties" /> as a <see cref="Microsoft.Azure.PowerShell.Cmdlets.DigitalTwins.Runtime.Json.JsonNode" />.
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
            if (serializationMode.HasFlag(Microsoft.Azure.PowerShell.Cmdlets.DigitalTwins.Runtime.SerializationMode.IncludeReadOnly))
            {
                AddIf( null != this._createdTime ? (Microsoft.Azure.PowerShell.Cmdlets.DigitalTwins.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.DigitalTwins.Runtime.Json.JsonString(this._createdTime?.ToString(@"yyyy'-'MM'-'dd'T'HH':'mm':'ss.fffffffK",global::System.Globalization.CultureInfo.InvariantCulture)) : null, "createdTime" ,container.Add );
            }
            if (serializationMode.HasFlag(Microsoft.Azure.PowerShell.Cmdlets.DigitalTwins.Runtime.SerializationMode.IncludeReadOnly))
            {
                AddIf( null != this._lastUpdatedTime ? (Microsoft.Azure.PowerShell.Cmdlets.DigitalTwins.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.DigitalTwins.Runtime.Json.JsonString(this._lastUpdatedTime?.ToString(@"yyyy'-'MM'-'dd'T'HH':'mm':'ss.fffffffK",global::System.Globalization.CultureInfo.InvariantCulture)) : null, "lastUpdatedTime" ,container.Add );
            }
            if (serializationMode.HasFlag(Microsoft.Azure.PowerShell.Cmdlets.DigitalTwins.Runtime.SerializationMode.IncludeReadOnly))
            {
                AddIf( null != (((object)this._provisioningState)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.DigitalTwins.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.DigitalTwins.Runtime.Json.JsonString(this._provisioningState.ToString()) : null, "provisioningState" ,container.Add );
            }
            if (serializationMode.HasFlag(Microsoft.Azure.PowerShell.Cmdlets.DigitalTwins.Runtime.SerializationMode.IncludeReadOnly))
            {
                AddIf( null != (((object)this._hostName)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.DigitalTwins.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.DigitalTwins.Runtime.Json.JsonString(this._hostName.ToString()) : null, "hostName" ,container.Add );
            }
            AfterToJson(ref container);
            return container;
        }
    }
}