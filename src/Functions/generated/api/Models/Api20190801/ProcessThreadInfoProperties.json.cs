namespace Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Extensions;

    /// <summary>ProcessThreadInfo resource specific properties</summary>
    public partial class ProcessThreadInfoProperties
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
        /// Deserializes a <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonNode"/> into an instance of Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProcessThreadInfoProperties.
        /// </summary>
        /// <param name="node">a <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonNode" /> to deserialize from.</param>
        /// <returns>
        /// an instance of Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProcessThreadInfoProperties.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProcessThreadInfoProperties FromJson(Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonNode node)
        {
            return node is Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonObject json ? new ProcessThreadInfoProperties(json) : null;
        }

        /// <summary>
        /// Deserializes a Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonObject into a new instance of <see cref="ProcessThreadInfoProperties" />.
        /// </summary>
        /// <param name="json">A Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonObject instance to deserialize from.</param>
        internal ProcessThreadInfoProperties(Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonObject json)
        {
            bool returnNow = false;
            BeforeFromJson(json, ref returnNow);
            if (returnNow)
            {
                return;
            }
            {_identifier = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonNumber>("identifier"), out var __jsonIdentifier) ? (int?)__jsonIdentifier : Identifier;}
            {_href = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonString>("href"), out var __jsonHref) ? (string)__jsonHref : (string)Href;}
            {_process = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonString>("process"), out var __jsonProcess) ? (string)__jsonProcess : (string)Process;}
            {_startAddress = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonString>("start_address"), out var __jsonStartAddress) ? (string)__jsonStartAddress : (string)StartAddress;}
            {_currentPriority = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonNumber>("current_priority"), out var __jsonCurrentPriority) ? (int?)__jsonCurrentPriority : CurrentPriority;}
            {_priorityLevel = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonString>("priority_level"), out var __jsonPriorityLevel) ? (string)__jsonPriorityLevel : (string)PriorityLevel;}
            {_basePriority = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonNumber>("base_priority"), out var __jsonBasePriority) ? (int?)__jsonBasePriority : BasePriority;}
            {_startTime = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonString>("start_time"), out var __jsonStartTime) ? global::System.DateTime.TryParse((string)__jsonStartTime, global::System.Globalization.CultureInfo.InvariantCulture, global::System.Globalization.DateTimeStyles.AdjustToUniversal, out var __jsonStartTimeValue) ? __jsonStartTimeValue : StartTime : StartTime;}
            {_totalProcessorTime = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonString>("total_processor_time"), out var __jsonTotalProcessorTime) ? (string)__jsonTotalProcessorTime : (string)TotalProcessorTime;}
            {_userProcessorTime = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonString>("user_processor_time"), out var __jsonUserProcessorTime) ? (string)__jsonUserProcessorTime : (string)UserProcessorTime;}
            {_state = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonString>("state"), out var __jsonState) ? (string)__jsonState : (string)State;}
            {_waitReason = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonString>("wait_reason"), out var __jsonWaitReason) ? (string)__jsonWaitReason : (string)WaitReason;}
            AfterFromJson(json);
        }

        /// <summary>
        /// Serializes this instance of <see cref="ProcessThreadInfoProperties" /> into a <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonNode" />.
        /// </summary>
        /// <param name="container">The <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonObject"/> container to serialize this object into. If the caller
        /// passes in <c>null</c>, a new instance will be created and returned to the caller.</param>
        /// <param name="serializationMode">Allows the caller to choose the depth of the serialization. See <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.SerializationMode"/>.</param>
        /// <returns>
        /// a serialized instance of <see cref="ProcessThreadInfoProperties" /> as a <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonNode" />.
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
            if (serializationMode.HasFlag(Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.SerializationMode.IncludeReadOnly))
            {
                AddIf( null != this._identifier ? (Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonNode)new Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonNumber((int)this._identifier) : null, "identifier" ,container.Add );
            }
            AddIf( null != (((object)this._href)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonString(this._href.ToString()) : null, "href" ,container.Add );
            AddIf( null != (((object)this._process)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonString(this._process.ToString()) : null, "process" ,container.Add );
            AddIf( null != (((object)this._startAddress)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonString(this._startAddress.ToString()) : null, "start_address" ,container.Add );
            AddIf( null != this._currentPriority ? (Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonNode)new Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonNumber((int)this._currentPriority) : null, "current_priority" ,container.Add );
            AddIf( null != (((object)this._priorityLevel)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonString(this._priorityLevel.ToString()) : null, "priority_level" ,container.Add );
            AddIf( null != this._basePriority ? (Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonNode)new Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonNumber((int)this._basePriority) : null, "base_priority" ,container.Add );
            AddIf( null != this._startTime ? (Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonString(this._startTime?.ToString(@"yyyy'-'MM'-'dd'T'HH':'mm':'ss.fffffffK",global::System.Globalization.CultureInfo.InvariantCulture)) : null, "start_time" ,container.Add );
            AddIf( null != (((object)this._totalProcessorTime)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonString(this._totalProcessorTime.ToString()) : null, "total_processor_time" ,container.Add );
            AddIf( null != (((object)this._userProcessorTime)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonString(this._userProcessorTime.ToString()) : null, "user_processor_time" ,container.Add );
            AddIf( null != (((object)this._state)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonString(this._state.ToString()) : null, "state" ,container.Add );
            AddIf( null != (((object)this._waitReason)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonString(this._waitReason.ToString()) : null, "wait_reason" ,container.Add );
            AfterToJson(ref container);
            return container;
        }
    }
}