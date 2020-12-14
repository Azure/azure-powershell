namespace Microsoft.Azure.PowerShell.Cmdlets.Communication.Models.Api20200820Preview
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Communication.Runtime.Extensions;

    /// <summary>The current status of an async operation</summary>
    public partial class OperationStatus
    {

        /// <summary>
        /// <c>AfterFromJson</c> will be called after the json deserialization has finished, allowing customization of the object
        /// before it is returned. Implement this method in a partial class to enable this behavior
        /// </summary>
        /// <param name="json">The JsonNode that should be deserialized into this object.</param>

        partial void AfterFromJson(Microsoft.Azure.PowerShell.Cmdlets.Communication.Runtime.Json.JsonObject json);

        /// <summary>
        /// <c>AfterToJson</c> will be called after the json erialization has finished, allowing customization of the <see cref="Microsoft.Azure.PowerShell.Cmdlets.Communication.Runtime.Json.JsonObject"
        /// /> before it is returned. Implement this method in a partial class to enable this behavior
        /// </summary>
        /// <param name="container">The JSON container that the serialization result will be placed in.</param>

        partial void AfterToJson(ref Microsoft.Azure.PowerShell.Cmdlets.Communication.Runtime.Json.JsonObject container);

        /// <summary>
        /// <c>BeforeFromJson</c> will be called before the json deserialization has commenced, allowing complete customization of
        /// the object before it is deserialized.
        /// If you wish to disable the default deserialization entirely, return <c>true</c> in the <see "returnNow" /> output parameter.
        /// Implement this method in a partial class to enable this behavior.
        /// </summary>
        /// <param name="json">The JsonNode that should be deserialized into this object.</param>
        /// <param name="returnNow">Determines if the rest of the deserialization should be processed, or if the method should return
        /// instantly.</param>

        partial void BeforeFromJson(Microsoft.Azure.PowerShell.Cmdlets.Communication.Runtime.Json.JsonObject json, ref bool returnNow);

        /// <summary>
        /// <c>BeforeToJson</c> will be called before the json serialization has commenced, allowing complete customization of the
        /// object before it is serialized.
        /// If you wish to disable the default serialization entirely, return <c>true</c> in the <see "returnNow" /> output parameter.
        /// Implement this method in a partial class to enable this behavior.
        /// </summary>
        /// <param name="container">The JSON container that the serialization result will be placed in.</param>
        /// <param name="returnNow">Determines if the rest of the serialization should be processed, or if the method should return
        /// instantly.</param>

        partial void BeforeToJson(ref Microsoft.Azure.PowerShell.Cmdlets.Communication.Runtime.Json.JsonObject container, ref bool returnNow);

        /// <summary>
        /// Deserializes a <see cref="Microsoft.Azure.PowerShell.Cmdlets.Communication.Runtime.Json.JsonNode"/> into an instance of Microsoft.Azure.PowerShell.Cmdlets.Communication.Models.Api20200820Preview.IOperationStatus.
        /// </summary>
        /// <param name="node">a <see cref="Microsoft.Azure.PowerShell.Cmdlets.Communication.Runtime.Json.JsonNode" /> to deserialize from.</param>
        /// <returns>
        /// an instance of Microsoft.Azure.PowerShell.Cmdlets.Communication.Models.Api20200820Preview.IOperationStatus.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Communication.Models.Api20200820Preview.IOperationStatus FromJson(Microsoft.Azure.PowerShell.Cmdlets.Communication.Runtime.Json.JsonNode node)
        {
            return node is Microsoft.Azure.PowerShell.Cmdlets.Communication.Runtime.Json.JsonObject json ? new OperationStatus(json) : null;
        }

        /// <summary>
        /// Deserializes a Microsoft.Azure.PowerShell.Cmdlets.Communication.Runtime.Json.JsonObject into a new instance of <see cref="OperationStatus" />.
        /// </summary>
        /// <param name="json">A Microsoft.Azure.PowerShell.Cmdlets.Communication.Runtime.Json.JsonObject instance to deserialize from.</param>
        internal OperationStatus(Microsoft.Azure.PowerShell.Cmdlets.Communication.Runtime.Json.JsonObject json)
        {
            bool returnNow = false;
            BeforeFromJson(json, ref returnNow);
            if (returnNow)
            {
                return;
            }
            {_error = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Communication.Runtime.Json.JsonObject>("error"), out var __jsonError) ? Microsoft.Azure.PowerShell.Cmdlets.Communication.Models.Api20200820Preview.ErrorResponse.FromJson(__jsonError) : Error;}
            {_id = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Communication.Runtime.Json.JsonString>("id"), out var __jsonId) ? (string)__jsonId : (string)Id;}
            {_status = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Communication.Runtime.Json.JsonString>("status"), out var __jsonStatus) ? (string)__jsonStatus : (string)Status;}
            {_startTime = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Communication.Runtime.Json.JsonString>("startTime"), out var __jsonStartTime) ? global::System.DateTime.TryParse((string)__jsonStartTime, global::System.Globalization.CultureInfo.InvariantCulture, global::System.Globalization.DateTimeStyles.AdjustToUniversal, out var __jsonStartTimeValue) ? __jsonStartTimeValue : StartTime : StartTime;}
            {_endTime = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Communication.Runtime.Json.JsonString>("endTime"), out var __jsonEndTime) ? global::System.DateTime.TryParse((string)__jsonEndTime, global::System.Globalization.CultureInfo.InvariantCulture, global::System.Globalization.DateTimeStyles.AdjustToUniversal, out var __jsonEndTimeValue) ? __jsonEndTimeValue : EndTime : EndTime;}
            {_percentComplete = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Communication.Runtime.Json.JsonNumber>("percentComplete"), out var __jsonPercentComplete) ? (float?)__jsonPercentComplete : PercentComplete;}
            AfterFromJson(json);
        }

        /// <summary>
        /// Serializes this instance of <see cref="OperationStatus" /> into a <see cref="Microsoft.Azure.PowerShell.Cmdlets.Communication.Runtime.Json.JsonNode" />.
        /// </summary>
        /// <param name="container">The <see cref="Microsoft.Azure.PowerShell.Cmdlets.Communication.Runtime.Json.JsonObject"/> container to serialize this object into. If the caller
        /// passes in <c>null</c>, a new instance will be created and returned to the caller.</param>
        /// <param name="serializationMode">Allows the caller to choose the depth of the serialization. See <see cref="Microsoft.Azure.PowerShell.Cmdlets.Communication.Runtime.SerializationMode"/>.</param>
        /// <returns>
        /// a serialized instance of <see cref="OperationStatus" /> as a <see cref="Microsoft.Azure.PowerShell.Cmdlets.Communication.Runtime.Json.JsonNode" />.
        /// </returns>
        public Microsoft.Azure.PowerShell.Cmdlets.Communication.Runtime.Json.JsonNode ToJson(Microsoft.Azure.PowerShell.Cmdlets.Communication.Runtime.Json.JsonObject container, Microsoft.Azure.PowerShell.Cmdlets.Communication.Runtime.SerializationMode serializationMode)
        {
            container = container ?? new Microsoft.Azure.PowerShell.Cmdlets.Communication.Runtime.Json.JsonObject();

            bool returnNow = false;
            BeforeToJson(ref container, ref returnNow);
            if (returnNow)
            {
                return container;
            }
            AddIf( null != this._error ? (Microsoft.Azure.PowerShell.Cmdlets.Communication.Runtime.Json.JsonNode) this._error.ToJson(null,serializationMode) : null, "error" ,container.Add );
            if (serializationMode.HasFlag(Microsoft.Azure.PowerShell.Cmdlets.Communication.Runtime.SerializationMode.IncludeReadOnly))
            {
                AddIf( null != (((object)this._id)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.Communication.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Communication.Runtime.Json.JsonString(this._id.ToString()) : null, "id" ,container.Add );
            }
            if (serializationMode.HasFlag(Microsoft.Azure.PowerShell.Cmdlets.Communication.Runtime.SerializationMode.IncludeReadOnly))
            {
                AddIf( null != (((object)this._status)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.Communication.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Communication.Runtime.Json.JsonString(this._status.ToString()) : null, "status" ,container.Add );
            }
            if (serializationMode.HasFlag(Microsoft.Azure.PowerShell.Cmdlets.Communication.Runtime.SerializationMode.IncludeReadOnly))
            {
                AddIf( null != this._startTime ? (Microsoft.Azure.PowerShell.Cmdlets.Communication.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Communication.Runtime.Json.JsonString(this._startTime?.ToString(@"yyyy'-'MM'-'dd'T'HH':'mm':'ss.fffffffK",global::System.Globalization.CultureInfo.InvariantCulture)) : null, "startTime" ,container.Add );
            }
            if (serializationMode.HasFlag(Microsoft.Azure.PowerShell.Cmdlets.Communication.Runtime.SerializationMode.IncludeReadOnly))
            {
                AddIf( null != this._endTime ? (Microsoft.Azure.PowerShell.Cmdlets.Communication.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Communication.Runtime.Json.JsonString(this._endTime?.ToString(@"yyyy'-'MM'-'dd'T'HH':'mm':'ss.fffffffK",global::System.Globalization.CultureInfo.InvariantCulture)) : null, "endTime" ,container.Add );
            }
            if (serializationMode.HasFlag(Microsoft.Azure.PowerShell.Cmdlets.Communication.Runtime.SerializationMode.IncludeReadOnly))
            {
                AddIf( null != this._percentComplete ? (Microsoft.Azure.PowerShell.Cmdlets.Communication.Runtime.Json.JsonNode)new Microsoft.Azure.PowerShell.Cmdlets.Communication.Runtime.Json.JsonNumber((float)this._percentComplete) : null, "percentComplete" ,container.Add );
            }
            AfterToJson(ref container);
            return container;
        }
    }
}