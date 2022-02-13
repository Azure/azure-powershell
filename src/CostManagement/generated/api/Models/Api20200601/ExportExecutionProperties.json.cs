namespace Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601
{
    using static Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.Extensions;

    /// <summary>The properties of the export execution.</summary>
    public partial class ExportExecutionProperties
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
        /// Deserializes a Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.Json.JsonObject into a new instance of <see cref="ExportExecutionProperties" />.
        /// </summary>
        /// <param name="json">A Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.Json.JsonObject instance to deserialize from.</param>
        internal ExportExecutionProperties(Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.Json.JsonObject json)
        {
            bool returnNow = false;
            BeforeFromJson(json, ref returnNow);
            if (returnNow)
            {
                return;
            }
            {_runSetting = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.Json.JsonObject>("runSettings"), out var __jsonRunSettings) ? Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.CommonExportProperties.FromJson(__jsonRunSettings) : RunSetting;}
            {_error = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.Json.JsonObject>("error"), out var __jsonError) ? Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.ErrorDetails.FromJson(__jsonError) : Error;}
            {_executionType = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.Json.JsonString>("executionType"), out var __jsonExecutionType) ? (string)__jsonExecutionType : (string)ExecutionType;}
            {_status = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.Json.JsonString>("status"), out var __jsonStatus) ? (string)__jsonStatus : (string)Status;}
            {_submittedBy = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.Json.JsonString>("submittedBy"), out var __jsonSubmittedBy) ? (string)__jsonSubmittedBy : (string)SubmittedBy;}
            {_submittedTime = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.Json.JsonString>("submittedTime"), out var __jsonSubmittedTime) ? global::System.DateTime.TryParse((string)__jsonSubmittedTime, global::System.Globalization.CultureInfo.InvariantCulture, global::System.Globalization.DateTimeStyles.AdjustToUniversal, out var __jsonSubmittedTimeValue) ? __jsonSubmittedTimeValue : SubmittedTime : SubmittedTime;}
            {_processingStartTime = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.Json.JsonString>("processingStartTime"), out var __jsonProcessingStartTime) ? global::System.DateTime.TryParse((string)__jsonProcessingStartTime, global::System.Globalization.CultureInfo.InvariantCulture, global::System.Globalization.DateTimeStyles.AdjustToUniversal, out var __jsonProcessingStartTimeValue) ? __jsonProcessingStartTimeValue : ProcessingStartTime : ProcessingStartTime;}
            {_processingEndTime = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.Json.JsonString>("processingEndTime"), out var __jsonProcessingEndTime) ? global::System.DateTime.TryParse((string)__jsonProcessingEndTime, global::System.Globalization.CultureInfo.InvariantCulture, global::System.Globalization.DateTimeStyles.AdjustToUniversal, out var __jsonProcessingEndTimeValue) ? __jsonProcessingEndTimeValue : ProcessingEndTime : ProcessingEndTime;}
            {_fileName = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.Json.JsonString>("fileName"), out var __jsonFileName) ? (string)__jsonFileName : (string)FileName;}
            AfterFromJson(json);
        }

        /// <summary>
        /// Deserializes a <see cref="Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.Json.JsonNode"/> into an instance of Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportExecutionProperties.
        /// </summary>
        /// <param name="node">a <see cref="Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.Json.JsonNode" /> to deserialize from.</param>
        /// <returns>
        /// an instance of Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportExecutionProperties.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportExecutionProperties FromJson(Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.Json.JsonNode node)
        {
            return node is Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.Json.JsonObject json ? new ExportExecutionProperties(json) : null;
        }

        /// <summary>
        /// Serializes this instance of <see cref="ExportExecutionProperties" /> into a <see cref="Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.Json.JsonNode" />.
        /// </summary>
        /// <param name="container">The <see cref="Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.Json.JsonObject"/> container to serialize this object into. If the caller
        /// passes in <c>null</c>, a new instance will be created and returned to the caller.</param>
        /// <param name="serializationMode">Allows the caller to choose the depth of the serialization. See <see cref="Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.SerializationMode"/>.</param>
        /// <returns>
        /// a serialized instance of <see cref="ExportExecutionProperties" /> as a <see cref="Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.Json.JsonNode" />.
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
            AddIf( null != this._runSetting ? (Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.Json.JsonNode) this._runSetting.ToJson(null,serializationMode) : null, "runSettings" ,container.Add );
            AddIf( null != this._error ? (Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.Json.JsonNode) this._error.ToJson(null,serializationMode) : null, "error" ,container.Add );
            AddIf( null != (((object)this._executionType)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.Json.JsonString(this._executionType.ToString()) : null, "executionType" ,container.Add );
            AddIf( null != (((object)this._status)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.Json.JsonString(this._status.ToString()) : null, "status" ,container.Add );
            AddIf( null != (((object)this._submittedBy)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.Json.JsonString(this._submittedBy.ToString()) : null, "submittedBy" ,container.Add );
            AddIf( null != this._submittedTime ? (Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.Json.JsonString(this._submittedTime?.ToString(@"yyyy'-'MM'-'dd'T'HH':'mm':'ss.fffffffK",global::System.Globalization.CultureInfo.InvariantCulture)) : null, "submittedTime" ,container.Add );
            AddIf( null != this._processingStartTime ? (Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.Json.JsonString(this._processingStartTime?.ToString(@"yyyy'-'MM'-'dd'T'HH':'mm':'ss.fffffffK",global::System.Globalization.CultureInfo.InvariantCulture)) : null, "processingStartTime" ,container.Add );
            AddIf( null != this._processingEndTime ? (Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.Json.JsonString(this._processingEndTime?.ToString(@"yyyy'-'MM'-'dd'T'HH':'mm':'ss.fffffffK",global::System.Globalization.CultureInfo.InvariantCulture)) : null, "processingEndTime" ,container.Add );
            AddIf( null != (((object)this._fileName)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.Json.JsonString(this._fileName.ToString()) : null, "fileName" ,container.Add );
            AfterToJson(ref container);
            return container;
        }
    }
}