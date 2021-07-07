namespace Microsoft.Azure.PowerShell.Cmdlets.Maps.Models.Api20210201
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Maps.Runtime.Extensions;

    /// <summary>
    /// The set of keys which can be used to access the Maps REST APIs. Two keys are provided for key rotation without interruption.
    /// </summary>
    public partial class MapsAccountKeys
    {

        /// <summary>
        /// <c>AfterFromJson</c> will be called after the json deserialization has finished, allowing customization of the object
        /// before it is returned. Implement this method in a partial class to enable this behavior
        /// </summary>
        /// <param name="json">The JsonNode that should be deserialized into this object.</param>

        partial void AfterFromJson(Microsoft.Azure.PowerShell.Cmdlets.Maps.Runtime.Json.JsonObject json);

        /// <summary>
        /// <c>AfterToJson</c> will be called after the json erialization has finished, allowing customization of the <see cref="Microsoft.Azure.PowerShell.Cmdlets.Maps.Runtime.Json.JsonObject"
        /// /> before it is returned. Implement this method in a partial class to enable this behavior
        /// </summary>
        /// <param name="container">The JSON container that the serialization result will be placed in.</param>

        partial void AfterToJson(ref Microsoft.Azure.PowerShell.Cmdlets.Maps.Runtime.Json.JsonObject container);

        /// <summary>
        /// <c>BeforeFromJson</c> will be called before the json deserialization has commenced, allowing complete customization of
        /// the object before it is deserialized.
        /// If you wish to disable the default deserialization entirely, return <c>true</c> in the <see "returnNow" /> output parameter.
        /// Implement this method in a partial class to enable this behavior.
        /// </summary>
        /// <param name="json">The JsonNode that should be deserialized into this object.</param>
        /// <param name="returnNow">Determines if the rest of the deserialization should be processed, or if the method should return
        /// instantly.</param>

        partial void BeforeFromJson(Microsoft.Azure.PowerShell.Cmdlets.Maps.Runtime.Json.JsonObject json, ref bool returnNow);

        /// <summary>
        /// <c>BeforeToJson</c> will be called before the json serialization has commenced, allowing complete customization of the
        /// object before it is serialized.
        /// If you wish to disable the default serialization entirely, return <c>true</c> in the <see "returnNow" /> output parameter.
        /// Implement this method in a partial class to enable this behavior.
        /// </summary>
        /// <param name="container">The JSON container that the serialization result will be placed in.</param>
        /// <param name="returnNow">Determines if the rest of the serialization should be processed, or if the method should return
        /// instantly.</param>

        partial void BeforeToJson(ref Microsoft.Azure.PowerShell.Cmdlets.Maps.Runtime.Json.JsonObject container, ref bool returnNow);

        /// <summary>
        /// Deserializes a <see cref="Microsoft.Azure.PowerShell.Cmdlets.Maps.Runtime.Json.JsonNode"/> into an instance of Microsoft.Azure.PowerShell.Cmdlets.Maps.Models.Api20210201.IMapsAccountKeys.
        /// </summary>
        /// <param name="node">a <see cref="Microsoft.Azure.PowerShell.Cmdlets.Maps.Runtime.Json.JsonNode" /> to deserialize from.</param>
        /// <returns>
        /// an instance of Microsoft.Azure.PowerShell.Cmdlets.Maps.Models.Api20210201.IMapsAccountKeys.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Maps.Models.Api20210201.IMapsAccountKeys FromJson(Microsoft.Azure.PowerShell.Cmdlets.Maps.Runtime.Json.JsonNode node)
        {
            return node is Microsoft.Azure.PowerShell.Cmdlets.Maps.Runtime.Json.JsonObject json ? new MapsAccountKeys(json) : null;
        }

        /// <summary>
        /// Deserializes a Microsoft.Azure.PowerShell.Cmdlets.Maps.Runtime.Json.JsonObject into a new instance of <see cref="MapsAccountKeys" />.
        /// </summary>
        /// <param name="json">A Microsoft.Azure.PowerShell.Cmdlets.Maps.Runtime.Json.JsonObject instance to deserialize from.</param>
        internal MapsAccountKeys(Microsoft.Azure.PowerShell.Cmdlets.Maps.Runtime.Json.JsonObject json)
        {
            bool returnNow = false;
            BeforeFromJson(json, ref returnNow);
            if (returnNow)
            {
                return;
            }
            {_primaryKeyLastUpdated = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Maps.Runtime.Json.JsonString>("primaryKeyLastUpdated"), out var __jsonPrimaryKeyLastUpdated) ? (string)__jsonPrimaryKeyLastUpdated : (string)PrimaryKeyLastUpdated;}
            {_primaryKey = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Maps.Runtime.Json.JsonString>("primaryKey"), out var __jsonPrimaryKey) ? (string)__jsonPrimaryKey : (string)PrimaryKey;}
            {_secondaryKey = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Maps.Runtime.Json.JsonString>("secondaryKey"), out var __jsonSecondaryKey) ? (string)__jsonSecondaryKey : (string)SecondaryKey;}
            {_secondaryKeyLastUpdated = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Maps.Runtime.Json.JsonString>("secondaryKeyLastUpdated"), out var __jsonSecondaryKeyLastUpdated) ? (string)__jsonSecondaryKeyLastUpdated : (string)SecondaryKeyLastUpdated;}
            AfterFromJson(json);
        }

        /// <summary>
        /// Serializes this instance of <see cref="MapsAccountKeys" /> into a <see cref="Microsoft.Azure.PowerShell.Cmdlets.Maps.Runtime.Json.JsonNode" />.
        /// </summary>
        /// <param name="container">The <see cref="Microsoft.Azure.PowerShell.Cmdlets.Maps.Runtime.Json.JsonObject"/> container to serialize this object into. If the caller
        /// passes in <c>null</c>, a new instance will be created and returned to the caller.</param>
        /// <param name="serializationMode">Allows the caller to choose the depth of the serialization. See <see cref="Microsoft.Azure.PowerShell.Cmdlets.Maps.Runtime.SerializationMode"/>.</param>
        /// <returns>
        /// a serialized instance of <see cref="MapsAccountKeys" /> as a <see cref="Microsoft.Azure.PowerShell.Cmdlets.Maps.Runtime.Json.JsonNode" />.
        /// </returns>
        public Microsoft.Azure.PowerShell.Cmdlets.Maps.Runtime.Json.JsonNode ToJson(Microsoft.Azure.PowerShell.Cmdlets.Maps.Runtime.Json.JsonObject container, Microsoft.Azure.PowerShell.Cmdlets.Maps.Runtime.SerializationMode serializationMode)
        {
            container = container ?? new Microsoft.Azure.PowerShell.Cmdlets.Maps.Runtime.Json.JsonObject();

            bool returnNow = false;
            BeforeToJson(ref container, ref returnNow);
            if (returnNow)
            {
                return container;
            }
            if (serializationMode.HasFlag(Microsoft.Azure.PowerShell.Cmdlets.Maps.Runtime.SerializationMode.IncludeReadOnly))
            {
                AddIf( null != (((object)this._primaryKeyLastUpdated)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.Maps.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Maps.Runtime.Json.JsonString(this._primaryKeyLastUpdated.ToString()) : null, "primaryKeyLastUpdated" ,container.Add );
            }
            if (serializationMode.HasFlag(Microsoft.Azure.PowerShell.Cmdlets.Maps.Runtime.SerializationMode.IncludeReadOnly))
            {
                AddIf( null != (((object)this._primaryKey)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.Maps.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Maps.Runtime.Json.JsonString(this._primaryKey.ToString()) : null, "primaryKey" ,container.Add );
            }
            if (serializationMode.HasFlag(Microsoft.Azure.PowerShell.Cmdlets.Maps.Runtime.SerializationMode.IncludeReadOnly))
            {
                AddIf( null != (((object)this._secondaryKey)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.Maps.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Maps.Runtime.Json.JsonString(this._secondaryKey.ToString()) : null, "secondaryKey" ,container.Add );
            }
            if (serializationMode.HasFlag(Microsoft.Azure.PowerShell.Cmdlets.Maps.Runtime.SerializationMode.IncludeReadOnly))
            {
                AddIf( null != (((object)this._secondaryKeyLastUpdated)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.Maps.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Maps.Runtime.Json.JsonString(this._secondaryKeyLastUpdated.ToString()) : null, "secondaryKeyLastUpdated" ,container.Add );
            }
            AfterToJson(ref container);
            return container;
        }
    }
}