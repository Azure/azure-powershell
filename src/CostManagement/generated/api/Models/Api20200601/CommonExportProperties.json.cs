namespace Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601
{
    using static Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.Extensions;

    /// <summary>The common properties of the export.</summary>
    public partial class CommonExportProperties
    {

        /// <summary>
        /// <c>AfterFromJson</c> will be called after the json deserialization has finished, allowing customization of the object
        /// before it is returned. Implement this method in a partial class to enable this behavior
        /// </summary>
        /// <param name="json">The JsonNode that should be deserialized into this object.</param>

        partial void AfterFromJson(Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.Json.JsonObject json);

        /// <summary>
        /// <c>AfterToJson</c> will be called after the json erialization has finished, allowing customization of the <see cref="Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.Json.JsonObject"
        /// /> before it is returned. Implement this method in a partial class to enable this behavior
        /// </summary>
        /// <param name="container">The JSON container that the serialization result will be placed in.</param>

        partial void AfterToJson(ref Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.Json.JsonObject container);

        /// <summary>
        /// <c>BeforeFromJson</c> will be called before the json deserialization has commenced, allowing complete customization of
        /// the object before it is deserialized.
        /// If you wish to disable the default deserialization entirely, return <c>true</c> in the <see "returnNow" /> output parameter.
        /// Implement this method in a partial class to enable this behavior.
        /// </summary>
        /// <param name="json">The JsonNode that should be deserialized into this object.</param>
        /// <param name="returnNow">Determines if the rest of the deserialization should be processed, or if the method should return
        /// instantly.</param>

        partial void BeforeFromJson(Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.Json.JsonObject json, ref bool returnNow);

        /// <summary>
        /// <c>BeforeToJson</c> will be called before the json serialization has commenced, allowing complete customization of the
        /// object before it is serialized.
        /// If you wish to disable the default serialization entirely, return <c>true</c> in the <see "returnNow" /> output parameter.
        /// Implement this method in a partial class to enable this behavior.
        /// </summary>
        /// <param name="container">The JSON container that the serialization result will be placed in.</param>
        /// <param name="returnNow">Determines if the rest of the serialization should be processed, or if the method should return
        /// instantly.</param>

        partial void BeforeToJson(ref Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.Json.JsonObject container, ref bool returnNow);

        /// <summary>
        /// Deserializes a Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.Json.JsonObject into a new instance of <see cref="CommonExportProperties" />.
        /// </summary>
        /// <param name="json">A Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.Json.JsonObject instance to deserialize from.</param>
        internal CommonExportProperties(Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.Json.JsonObject json)
        {
            bool returnNow = false;
            BeforeFromJson(json, ref returnNow);
            if (returnNow)
            {
                return;
            }
            {_deliveryInfo = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.Json.JsonObject>("deliveryInfo"), out var __jsonDeliveryInfo) ? Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.ExportDeliveryInfo.FromJson(__jsonDeliveryInfo) : DeliveryInfo;}
            {_definition = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.Json.JsonObject>("definition"), out var __jsonDefinition) ? Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.ExportDefinition.FromJson(__jsonDefinition) : Definition;}
            {_runHistory = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.Json.JsonObject>("runHistory"), out var __jsonRunHistory) ? Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.ExportExecutionListResult.FromJson(__jsonRunHistory) : RunHistory;}
            {_format = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.Json.JsonString>("format"), out var __jsonFormat) ? (string)__jsonFormat : (string)Format;}
            {_nextRunTimeEstimate = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.Json.JsonString>("nextRunTimeEstimate"), out var __jsonNextRunTimeEstimate) ? global::System.DateTime.TryParse((string)__jsonNextRunTimeEstimate, global::System.Globalization.CultureInfo.InvariantCulture, global::System.Globalization.DateTimeStyles.AdjustToUniversal, out var __jsonNextRunTimeEstimateValue) ? __jsonNextRunTimeEstimateValue : NextRunTimeEstimate : NextRunTimeEstimate;}
            AfterFromJson(json);
        }

        /// <summary>
        /// Deserializes a <see cref="Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.Json.JsonNode"/> into an instance of Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.ICommonExportProperties.
        /// </summary>
        /// <param name="node">a <see cref="Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.Json.JsonNode" /> to deserialize from.</param>
        /// <returns>
        /// an instance of Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.ICommonExportProperties.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.ICommonExportProperties FromJson(Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.Json.JsonNode node)
        {
            return node is Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.Json.JsonObject json ? new CommonExportProperties(json) : null;
        }

        /// <summary>
        /// Serializes this instance of <see cref="CommonExportProperties" /> into a <see cref="Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.Json.JsonNode" />.
        /// </summary>
        /// <param name="container">The <see cref="Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.Json.JsonObject"/> container to serialize this object into. If the caller
        /// passes in <c>null</c>, a new instance will be created and returned to the caller.</param>
        /// <param name="serializationMode">Allows the caller to choose the depth of the serialization. See <see cref="Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.SerializationMode"/>.</param>
        /// <returns>
        /// a serialized instance of <see cref="CommonExportProperties" /> as a <see cref="Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.Json.JsonNode" />.
        /// </returns>
        public Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.Json.JsonNode ToJson(Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.Json.JsonObject container, Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.SerializationMode serializationMode)
        {
            container = container ?? new Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.Json.JsonObject();

            bool returnNow = false;
            BeforeToJson(ref container, ref returnNow);
            if (returnNow)
            {
                return container;
            }
            AddIf( null != this._deliveryInfo ? (Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.Json.JsonNode) this._deliveryInfo.ToJson(null,serializationMode) : null, "deliveryInfo" ,container.Add );
            AddIf( null != this._definition ? (Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.Json.JsonNode) this._definition.ToJson(null,serializationMode) : null, "definition" ,container.Add );
            AddIf( null != this._runHistory ? (Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.Json.JsonNode) this._runHistory.ToJson(null,serializationMode) : null, "runHistory" ,container.Add );
            AddIf( null != (((object)this._format)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.Json.JsonString(this._format.ToString()) : null, "format" ,container.Add );
            if (serializationMode.HasFlag(Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.SerializationMode.IncludeReadOnly))
            {
                AddIf( null != this._nextRunTimeEstimate ? (Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.Json.JsonString(this._nextRunTimeEstimate?.ToString(@"yyyy'-'MM'-'dd'T'HH':'mm':'ss.fffffffK",global::System.Globalization.CultureInfo.InvariantCulture)) : null, "nextRunTimeEstimate" ,container.Add );
            }
            AfterToJson(ref container);
            return container;
        }
    }
}