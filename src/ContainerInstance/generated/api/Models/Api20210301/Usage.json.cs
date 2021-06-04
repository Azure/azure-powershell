namespace Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301
{
    using static Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.Extensions;

    /// <summary>A single usage result</summary>
    public partial class Usage
    {

        /// <summary>
        /// <c>AfterFromJson</c> will be called after the json deserialization has finished, allowing customization of the object
        /// before it is returned. Implement this method in a partial class to enable this behavior
        /// </summary>
        /// <param name="json">The JsonNode that should be deserialized into this object.</param>

        partial void AfterFromJson(Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.Json.JsonObject json);

        /// <summary>
        /// <c>AfterToJson</c> will be called after the json erialization has finished, allowing customization of the <see cref="Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.Json.JsonObject"
        /// /> before it is returned. Implement this method in a partial class to enable this behavior
        /// </summary>
        /// <param name="container">The JSON container that the serialization result will be placed in.</param>

        partial void AfterToJson(ref Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.Json.JsonObject container);

        /// <summary>
        /// <c>BeforeFromJson</c> will be called before the json deserialization has commenced, allowing complete customization of
        /// the object before it is deserialized.
        /// If you wish to disable the default deserialization entirely, return <c>true</c> in the <see "returnNow" /> output parameter.
        /// Implement this method in a partial class to enable this behavior.
        /// </summary>
        /// <param name="json">The JsonNode that should be deserialized into this object.</param>
        /// <param name="returnNow">Determines if the rest of the deserialization should be processed, or if the method should return
        /// instantly.</param>

        partial void BeforeFromJson(Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.Json.JsonObject json, ref bool returnNow);

        /// <summary>
        /// <c>BeforeToJson</c> will be called before the json serialization has commenced, allowing complete customization of the
        /// object before it is serialized.
        /// If you wish to disable the default serialization entirely, return <c>true</c> in the <see "returnNow" /> output parameter.
        /// Implement this method in a partial class to enable this behavior.
        /// </summary>
        /// <param name="container">The JSON container that the serialization result will be placed in.</param>
        /// <param name="returnNow">Determines if the rest of the serialization should be processed, or if the method should return
        /// instantly.</param>

        partial void BeforeToJson(ref Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.Json.JsonObject container, ref bool returnNow);

        /// <summary>
        /// Deserializes a <see cref="Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.Json.JsonNode"/> into an instance of Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IUsage.
        /// </summary>
        /// <param name="node">a <see cref="Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.Json.JsonNode" /> to deserialize from.</param>
        /// <returns>
        /// an instance of Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IUsage.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IUsage FromJson(Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.Json.JsonNode node)
        {
            return node is Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.Json.JsonObject json ? new Usage(json) : null;
        }

        /// <summary>
        /// Serializes this instance of <see cref="Usage" /> into a <see cref="Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.Json.JsonNode" />.
        /// </summary>
        /// <param name="container">The <see cref="Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.Json.JsonObject"/> container to serialize this object into. If the caller
        /// passes in <c>null</c>, a new instance will be created and returned to the caller.</param>
        /// <param name="serializationMode">Allows the caller to choose the depth of the serialization. See <see cref="Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.SerializationMode"/>.</param>
        /// <returns>
        /// a serialized instance of <see cref="Usage" /> as a <see cref="Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.Json.JsonNode" />.
        /// </returns>
        public Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.Json.JsonNode ToJson(Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.Json.JsonObject container, Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.SerializationMode serializationMode)
        {
            container = container ?? new Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.Json.JsonObject();

            bool returnNow = false;
            BeforeToJson(ref container, ref returnNow);
            if (returnNow)
            {
                return container;
            }
            if (serializationMode.HasFlag(Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.SerializationMode.IncludeReadOnly))
            {
                AddIf( null != this._name ? (Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.Json.JsonNode) this._name.ToJson(null,serializationMode) : null, "name" ,container.Add );
            }
            if (serializationMode.HasFlag(Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.SerializationMode.IncludeReadOnly))
            {
                AddIf( null != (((object)this._unit)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.Json.JsonString(this._unit.ToString()) : null, "unit" ,container.Add );
            }
            if (serializationMode.HasFlag(Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.SerializationMode.IncludeReadOnly))
            {
                AddIf( null != this._currentValue ? (Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.Json.JsonNode)new Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.Json.JsonNumber((int)this._currentValue) : null, "currentValue" ,container.Add );
            }
            if (serializationMode.HasFlag(Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.SerializationMode.IncludeReadOnly))
            {
                AddIf( null != this._limit ? (Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.Json.JsonNode)new Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.Json.JsonNumber((int)this._limit) : null, "limit" ,container.Add );
            }
            AfterToJson(ref container);
            return container;
        }

        /// <summary>
        /// Deserializes a Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.Json.JsonObject into a new instance of <see cref="Usage" />.
        /// </summary>
        /// <param name="json">A Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.Json.JsonObject instance to deserialize from.</param>
        internal Usage(Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.Json.JsonObject json)
        {
            bool returnNow = false;
            BeforeFromJson(json, ref returnNow);
            if (returnNow)
            {
                return;
            }
            {_name = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.Json.JsonObject>("name"), out var __jsonName) ? Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.UsageName.FromJson(__jsonName) : Name;}
            {_unit = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.Json.JsonString>("unit"), out var __jsonUnit) ? (string)__jsonUnit : (string)Unit;}
            {_currentValue = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.Json.JsonNumber>("currentValue"), out var __jsonCurrentValue) ? (int?)__jsonCurrentValue : CurrentValue;}
            {_limit = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.Json.JsonNumber>("limit"), out var __jsonLimit) ? (int?)__jsonLimit : Limit;}
            AfterFromJson(json);
        }
    }
}