namespace Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Models.Api20171201
{
    using static Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Runtime.Extensions;

    /// <summary>The properties of a configuration.</summary>
    public partial class ConfigurationProperties
    {

        /// <summary>
        /// <c>AfterFromJson</c> will be called after the json deserialization has finished, allowing customization of the object
        /// before it is returned. Implement this method in a partial class to enable this behavior
        /// </summary>
        /// <param name="json">The JsonNode that should be deserialized into this object.</param>

        partial void AfterFromJson(Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Runtime.Json.JsonObject json);

        /// <summary>
        /// <c>AfterToJson</c> will be called after the json erialization has finished, allowing customization of the <see cref="Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Runtime.Json.JsonObject"
        /// /> before it is returned. Implement this method in a partial class to enable this behavior
        /// </summary>
        /// <param name="container">The JSON container that the serialization result will be placed in.</param>

        partial void AfterToJson(ref Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Runtime.Json.JsonObject container);

        /// <summary>
        /// <c>BeforeFromJson</c> will be called before the json deserialization has commenced, allowing complete customization of
        /// the object before it is deserialized.
        /// If you wish to disable the default deserialization entirely, return <c>true</c> in the <see "returnNow" /> output parameter.
        /// Implement this method in a partial class to enable this behavior.
        /// </summary>
        /// <param name="json">The JsonNode that should be deserialized into this object.</param>
        /// <param name="returnNow">Determines if the rest of the deserialization should be processed, or if the method should return
        /// instantly.</param>

        partial void BeforeFromJson(Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Runtime.Json.JsonObject json, ref bool returnNow);

        /// <summary>
        /// <c>BeforeToJson</c> will be called before the json serialization has commenced, allowing complete customization of the
        /// object before it is serialized.
        /// If you wish to disable the default serialization entirely, return <c>true</c> in the <see "returnNow" /> output parameter.
        /// Implement this method in a partial class to enable this behavior.
        /// </summary>
        /// <param name="container">The JSON container that the serialization result will be placed in.</param>
        /// <param name="returnNow">Determines if the rest of the serialization should be processed, or if the method should return
        /// instantly.</param>

        partial void BeforeToJson(ref Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Runtime.Json.JsonObject container, ref bool returnNow);

        /// <summary>
        /// Deserializes a Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Runtime.Json.JsonObject into a new instance of <see cref="ConfigurationProperties" />.
        /// </summary>
        /// <param name="json">A Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Runtime.Json.JsonObject instance to deserialize from.</param>
        internal ConfigurationProperties(Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Runtime.Json.JsonObject json)
        {
            bool returnNow = false;
            BeforeFromJson(json, ref returnNow);
            if (returnNow)
            {
                return;
            }
            {_value = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Runtime.Json.JsonString>("value"), out var __jsonValue) ? (string)__jsonValue : (string)Value;}
            {_description = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Runtime.Json.JsonString>("description"), out var __jsonDescription) ? (string)__jsonDescription : (string)Description;}
            {_defaultValue = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Runtime.Json.JsonString>("defaultValue"), out var __jsonDefaultValue) ? (string)__jsonDefaultValue : (string)DefaultValue;}
            {_dataType = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Runtime.Json.JsonString>("dataType"), out var __jsonDataType) ? (string)__jsonDataType : (string)DataType;}
            {_allowedValue = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Runtime.Json.JsonString>("allowedValues"), out var __jsonAllowedValues) ? (string)__jsonAllowedValues : (string)AllowedValue;}
            {_source = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Runtime.Json.JsonString>("source"), out var __jsonSource) ? (string)__jsonSource : (string)Source;}
            AfterFromJson(json);
        }

        /// <summary>
        /// Deserializes a <see cref="Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Runtime.Json.JsonNode"/> into an instance of Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Models.Api20171201.IConfigurationProperties.
        /// </summary>
        /// <param name="node">a <see cref="Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Runtime.Json.JsonNode" /> to deserialize from.</param>
        /// <returns>
        /// an instance of Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Models.Api20171201.IConfigurationProperties.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Models.Api20171201.IConfigurationProperties FromJson(Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Runtime.Json.JsonNode node)
        {
            return node is Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Runtime.Json.JsonObject json ? new ConfigurationProperties(json) : null;
        }

        /// <summary>
        /// Serializes this instance of <see cref="ConfigurationProperties" /> into a <see cref="Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Runtime.Json.JsonNode" />.
        /// </summary>
        /// <param name="container">The <see cref="Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Runtime.Json.JsonObject"/> container to serialize this object into. If the caller
        /// passes in <c>null</c>, a new instance will be created and returned to the caller.</param>
        /// <param name="serializationMode">Allows the caller to choose the depth of the serialization. See <see cref="Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Runtime.SerializationMode"/>.</param>
        /// <returns>
        /// a serialized instance of <see cref="ConfigurationProperties" /> as a <see cref="Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Runtime.Json.JsonNode" />.
        /// </returns>
        public Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Runtime.Json.JsonNode ToJson(Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Runtime.Json.JsonObject container, Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Runtime.SerializationMode serializationMode)
        {
            container = container ?? new Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Runtime.Json.JsonObject();

            bool returnNow = false;
            BeforeToJson(ref container, ref returnNow);
            if (returnNow)
            {
                return container;
            }
            AddIf( null != (((object)this._value)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Runtime.Json.JsonString(this._value.ToString()) : null, "value" ,container.Add );
            if (serializationMode.HasFlag(Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Runtime.SerializationMode.IncludeReadOnly))
            {
                AddIf( null != (((object)this._description)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Runtime.Json.JsonString(this._description.ToString()) : null, "description" ,container.Add );
            }
            if (serializationMode.HasFlag(Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Runtime.SerializationMode.IncludeReadOnly))
            {
                AddIf( null != (((object)this._defaultValue)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Runtime.Json.JsonString(this._defaultValue.ToString()) : null, "defaultValue" ,container.Add );
            }
            if (serializationMode.HasFlag(Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Runtime.SerializationMode.IncludeReadOnly))
            {
                AddIf( null != (((object)this._dataType)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Runtime.Json.JsonString(this._dataType.ToString()) : null, "dataType" ,container.Add );
            }
            if (serializationMode.HasFlag(Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Runtime.SerializationMode.IncludeReadOnly))
            {
                AddIf( null != (((object)this._allowedValue)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Runtime.Json.JsonString(this._allowedValue.ToString()) : null, "allowedValues" ,container.Add );
            }
            AddIf( null != (((object)this._source)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Runtime.Json.JsonString(this._source.ToString()) : null, "source" ,container.Add );
            AfterToJson(ref container);
            return container;
        }
    }
}