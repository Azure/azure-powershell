namespace Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Extensions;

    /// <summary>Usage of the quota resource.</summary>
    public partial class CsmUsageQuota
    {

        /// <summary>
        /// <c>AfterFromJson</c> will be called after the json deserialization has finished, allowing customization of the object
        /// before it is returned. Implement this method in a partial class to enable this behavior
        /// </summary>
        /// <param name="json">The JsonNode that should be deserialized into this object.</param>

        partial void AfterFromJson(Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonObject json);

        /// <summary>
        /// <c>AfterToJson</c> will be called after the json erialization has finished, allowing customization of the <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonObject"
        /// /> before it is returned. Implement this method in a partial class to enable this behavior
        /// </summary>
        /// <param name="container">The JSON container that the serialization result will be placed in.</param>

        partial void AfterToJson(ref Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonObject container);

        /// <summary>
        /// <c>BeforeFromJson</c> will be called before the json deserialization has commenced, allowing complete customization of
        /// the object before it is deserialized.
        /// If you wish to disable the default deserialization entirely, return <c>true</c> in the <see "returnNow" /> output parameter.
        /// Implement this method in a partial class to enable this behavior.
        /// </summary>
        /// <param name="json">The JsonNode that should be deserialized into this object.</param>
        /// <param name="returnNow">Determines if the rest of the deserialization should be processed, or if the method should return
        /// instantly.</param>

        partial void BeforeFromJson(Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonObject json, ref bool returnNow);

        /// <summary>
        /// <c>BeforeToJson</c> will be called before the json serialization has commenced, allowing complete customization of the
        /// object before it is serialized.
        /// If you wish to disable the default serialization entirely, return <c>true</c> in the <see "returnNow" /> output parameter.
        /// Implement this method in a partial class to enable this behavior.
        /// </summary>
        /// <param name="container">The JSON container that the serialization result will be placed in.</param>
        /// <param name="returnNow">Determines if the rest of the serialization should be processed, or if the method should return
        /// instantly.</param>

        partial void BeforeToJson(ref Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonObject container, ref bool returnNow);

        /// <summary>
        /// Deserializes a Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonObject into a new instance of <see cref="CsmUsageQuota" />.
        /// </summary>
        /// <param name="json">A Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonObject instance to deserialize from.</param>
        internal CsmUsageQuota(Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonObject json)
        {
            bool returnNow = false;
            BeforeFromJson(json, ref returnNow);
            if (returnNow)
            {
                return;
            }
            {_name = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonObject>("name"), out var __jsonName) ? Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.LocalizableString.FromJson(__jsonName) : Name;}
            {_currentValue = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonNumber>("currentValue"), out var __jsonCurrentValue) ? (long?)__jsonCurrentValue : CurrentValue;}
            {_limit = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonNumber>("limit"), out var __jsonLimit) ? (long?)__jsonLimit : Limit;}
            {_nextResetTime = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonString>("nextResetTime"), out var __jsonNextResetTime) ? global::System.DateTime.TryParse((string)__jsonNextResetTime, global::System.Globalization.CultureInfo.InvariantCulture, global::System.Globalization.DateTimeStyles.AdjustToUniversal, out var __jsonNextResetTimeValue) ? __jsonNextResetTimeValue : NextResetTime : NextResetTime;}
            {_unit = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonString>("unit"), out var __jsonUnit) ? (string)__jsonUnit : (string)Unit;}
            AfterFromJson(json);
        }

        /// <summary>
        /// Deserializes a <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonNode"/> into an instance of Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICsmUsageQuota.
        /// </summary>
        /// <param name="node">a <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonNode" /> to deserialize from.</param>
        /// <returns>
        /// an instance of Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICsmUsageQuota.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICsmUsageQuota FromJson(Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonNode node)
        {
            return node is Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonObject json ? new CsmUsageQuota(json) : null;
        }

        /// <summary>
        /// Serializes this instance of <see cref="CsmUsageQuota" /> into a <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonNode" />.
        /// </summary>
        /// <param name="container">The <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonObject"/> container to serialize this object into. If the caller
        /// passes in <c>null</c>, a new instance will be created and returned to the caller.</param>
        /// <param name="serializationMode">Allows the caller to choose the depth of the serialization. See <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.SerializationMode"/>.</param>
        /// <returns>
        /// a serialized instance of <see cref="CsmUsageQuota" /> as a <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonNode" />.
        /// </returns>
        public Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonNode ToJson(Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonObject container, Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.SerializationMode serializationMode)
        {
            container = container ?? new Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonObject();

            bool returnNow = false;
            BeforeToJson(ref container, ref returnNow);
            if (returnNow)
            {
                return container;
            }
            AddIf( null != this._name ? (Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonNode) this._name.ToJson(null,serializationMode) : null, "name" ,container.Add );
            AddIf( null != this._currentValue ? (Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonNode)new Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonNumber((long)this._currentValue) : null, "currentValue" ,container.Add );
            AddIf( null != this._limit ? (Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonNode)new Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonNumber((long)this._limit) : null, "limit" ,container.Add );
            AddIf( null != this._nextResetTime ? (Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonString(this._nextResetTime?.ToString(@"yyyy'-'MM'-'dd'T'HH':'mm':'ss.fffffffK",global::System.Globalization.CultureInfo.InvariantCulture)) : null, "nextResetTime" ,container.Add );
            AddIf( null != (((object)this._unit)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonString(this._unit.ToString()) : null, "unit" ,container.Add );
            AfterToJson(ref container);
            return container;
        }
    }
}