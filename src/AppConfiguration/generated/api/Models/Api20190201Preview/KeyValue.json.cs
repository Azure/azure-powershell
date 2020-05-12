namespace Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Models.Api20190201Preview
{
    using static Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Runtime.Extensions;

    /// <summary>
    /// The result of a request to retrieve a key-value from the specified configuration store.
    /// </summary>
    public partial class KeyValue
    {

        /// <summary>
        /// <c>AfterFromJson</c> will be called after the json deserialization has finished, allowing customization of the object
        /// before it is returned. Implement this method in a partial class to enable this behavior
        /// </summary>
        /// <param name="json">The JsonNode that should be deserialized into this object.</param>

        partial void AfterFromJson(Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Runtime.Json.JsonObject json);

        /// <summary>
        /// <c>AfterToJson</c> will be called after the json erialization has finished, allowing customization of the <see cref="Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Runtime.Json.JsonObject"
        /// /> before it is returned. Implement this method in a partial class to enable this behavior
        /// </summary>
        /// <param name="container">The JSON container that the serialization result will be placed in.</param>

        partial void AfterToJson(ref Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Runtime.Json.JsonObject container);

        /// <summary>
        /// <c>BeforeFromJson</c> will be called before the json deserialization has commenced, allowing complete customization of
        /// the object before it is deserialized.
        /// If you wish to disable the default deserialization entirely, return <c>true</c> in the <see "returnNow" /> output parameter.
        /// Implement this method in a partial class to enable this behavior.
        /// </summary>
        /// <param name="json">The JsonNode that should be deserialized into this object.</param>
        /// <param name="returnNow">Determines if the rest of the deserialization should be processed, or if the method should return
        /// instantly.</param>

        partial void BeforeFromJson(Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Runtime.Json.JsonObject json, ref bool returnNow);

        /// <summary>
        /// <c>BeforeToJson</c> will be called before the json serialization has commenced, allowing complete customization of the
        /// object before it is serialized.
        /// If you wish to disable the default serialization entirely, return <c>true</c> in the <see "returnNow" /> output parameter.
        /// Implement this method in a partial class to enable this behavior.
        /// </summary>
        /// <param name="container">The JSON container that the serialization result will be placed in.</param>
        /// <param name="returnNow">Determines if the rest of the serialization should be processed, or if the method should return
        /// instantly.</param>

        partial void BeforeToJson(ref Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Runtime.Json.JsonObject container, ref bool returnNow);

        /// <summary>
        /// Deserializes a <see cref="Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Runtime.Json.JsonNode"/> into an instance of Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Models.Api20190201Preview.IKeyValue.
        /// </summary>
        /// <param name="node">a <see cref="Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Runtime.Json.JsonNode" /> to deserialize from.</param>
        /// <returns>
        /// an instance of Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Models.Api20190201Preview.IKeyValue.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Models.Api20190201Preview.IKeyValue FromJson(Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Runtime.Json.JsonNode node)
        {
            return node is Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Runtime.Json.JsonObject json ? new KeyValue(json) : null;
        }

        /// <summary>
        /// Deserializes a Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Runtime.Json.JsonObject into a new instance of <see cref="KeyValue" />.
        /// </summary>
        /// <param name="json">A Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Runtime.Json.JsonObject instance to deserialize from.</param>
        internal KeyValue(Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Runtime.Json.JsonObject json)
        {
            bool returnNow = false;
            BeforeFromJson(json, ref returnNow);
            if (returnNow)
            {
                return;
            }
            {_contentType = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Runtime.Json.JsonString>("contentType"), out var __jsonContentType) ? (string)__jsonContentType : (string)ContentType;}
            {_eTag = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Runtime.Json.JsonString>("eTag"), out var __jsonETag) ? (string)__jsonETag : (string)ETag;}
            {_key = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Runtime.Json.JsonString>("key"), out var __jsonKey) ? (string)__jsonKey : (string)Key;}
            {_label = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Runtime.Json.JsonString>("label"), out var __jsonLabel) ? (string)__jsonLabel : (string)Label;}
            {_lastModified = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Runtime.Json.JsonString>("lastModified"), out var __jsonLastModified) ? global::System.DateTime.TryParse((string)__jsonLastModified, global::System.Globalization.CultureInfo.InvariantCulture, global::System.Globalization.DateTimeStyles.AdjustToUniversal, out var __jsonLastModifiedValue) ? __jsonLastModifiedValue : LastModified : LastModified;}
            {_locked = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Runtime.Json.JsonBoolean>("locked"), out var __jsonLocked) ? (bool?)__jsonLocked : Locked;}
            {_tag = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Runtime.Json.JsonObject>("tags"), out var __jsonTags) ? Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Models.Api20190201Preview.KeyValueTags.FromJson(__jsonTags) : Tag;}
            {_value = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Runtime.Json.JsonString>("value"), out var __jsonValue) ? (string)__jsonValue : (string)Value;}
            AfterFromJson(json);
        }

        /// <summary>
        /// Serializes this instance of <see cref="KeyValue" /> into a <see cref="Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Runtime.Json.JsonNode" />.
        /// </summary>
        /// <param name="container">The <see cref="Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Runtime.Json.JsonObject"/> container to serialize this object into. If the caller
        /// passes in <c>null</c>, a new instance will be created and returned to the caller.</param>
        /// <param name="serializationMode">Allows the caller to choose the depth of the serialization. See <see cref="Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Runtime.SerializationMode"/>.</param>
        /// <returns>
        /// a serialized instance of <see cref="KeyValue" /> as a <see cref="Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Runtime.Json.JsonNode" />.
        /// </returns>
        public Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Runtime.Json.JsonNode ToJson(Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Runtime.Json.JsonObject container, Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Runtime.SerializationMode serializationMode)
        {
            container = container ?? new Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Runtime.Json.JsonObject();

            bool returnNow = false;
            BeforeToJson(ref container, ref returnNow);
            if (returnNow)
            {
                return container;
            }
            if (serializationMode.HasFlag(Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Runtime.SerializationMode.IncludeReadOnly))
            {
                AddIf( null != (((object)this._contentType)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Runtime.Json.JsonString(this._contentType.ToString()) : null, "contentType" ,container.Add );
            }
            if (serializationMode.HasFlag(Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Runtime.SerializationMode.IncludeReadOnly))
            {
                AddIf( null != (((object)this._eTag)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Runtime.Json.JsonString(this._eTag.ToString()) : null, "eTag" ,container.Add );
            }
            if (serializationMode.HasFlag(Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Runtime.SerializationMode.IncludeReadOnly))
            {
                AddIf( null != (((object)this._key)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Runtime.Json.JsonString(this._key.ToString()) : null, "key" ,container.Add );
            }
            if (serializationMode.HasFlag(Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Runtime.SerializationMode.IncludeReadOnly))
            {
                AddIf( null != (((object)this._label)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Runtime.Json.JsonString(this._label.ToString()) : null, "label" ,container.Add );
            }
            if (serializationMode.HasFlag(Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Runtime.SerializationMode.IncludeReadOnly))
            {
                AddIf( null != this._lastModified ? (Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Runtime.Json.JsonString(this._lastModified?.ToString(@"yyyy'-'MM'-'dd'T'HH':'mm':'ss.fffffffK",global::System.Globalization.CultureInfo.InvariantCulture)) : null, "lastModified" ,container.Add );
            }
            if (serializationMode.HasFlag(Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Runtime.SerializationMode.IncludeReadOnly))
            {
                AddIf( null != this._locked ? (Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Runtime.Json.JsonNode)new Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Runtime.Json.JsonBoolean((bool)this._locked) : null, "locked" ,container.Add );
            }
            if (serializationMode.HasFlag(Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Runtime.SerializationMode.IncludeReadOnly))
            {
                AddIf( null != this._tag ? (Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Runtime.Json.JsonNode) this._tag.ToJson(null,serializationMode) : null, "tags" ,container.Add );
            }
            if (serializationMode.HasFlag(Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Runtime.SerializationMode.IncludeReadOnly))
            {
                AddIf( null != (((object)this._value)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Runtime.Json.JsonString(this._value.ToString()) : null, "value" ,container.Add );
            }
            AfterToJson(ref container);
            return container;
        }
    }
}