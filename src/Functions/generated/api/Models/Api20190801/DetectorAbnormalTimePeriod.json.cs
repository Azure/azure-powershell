namespace Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Extensions;

    /// <summary>Class representing Abnormal Time Period detected.</summary>
    public partial class DetectorAbnormalTimePeriod
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
        /// Deserializes a Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonObject into a new instance of <see cref="DetectorAbnormalTimePeriod" />.
        /// </summary>
        /// <param name="json">A Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonObject instance to deserialize from.</param>
        internal DetectorAbnormalTimePeriod(Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonObject json)
        {
            bool returnNow = false;
            BeforeFromJson(json, ref returnNow);
            if (returnNow)
            {
                return;
            }
            {_startTime = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonString>("startTime"), out var __jsonStartTime) ? global::System.DateTime.TryParse((string)__jsonStartTime, global::System.Globalization.CultureInfo.InvariantCulture, global::System.Globalization.DateTimeStyles.AdjustToUniversal, out var __jsonStartTimeValue) ? __jsonStartTimeValue : StartTime : StartTime;}
            {_endTime = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonString>("endTime"), out var __jsonEndTime) ? global::System.DateTime.TryParse((string)__jsonEndTime, global::System.Globalization.CultureInfo.InvariantCulture, global::System.Globalization.DateTimeStyles.AdjustToUniversal, out var __jsonEndTimeValue) ? __jsonEndTimeValue : EndTime : EndTime;}
            {_message = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonString>("message"), out var __jsonMessage) ? (string)__jsonMessage : (string)Message;}
            {_source = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonString>("source"), out var __jsonSource) ? (string)__jsonSource : (string)Source;}
            {_priority = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonNumber>("priority"), out var __jsonPriority) ? (double?)__jsonPriority : Priority;}
            {_metaData = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonArray>("metaData"), out var __jsonMetaData) ? If( __jsonMetaData as Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonArray, out var __u) ? new global::System.Func<Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.INameValuePair[][]>(()=> global::System.Linq.Enumerable.ToArray(global::System.Linq.Enumerable.Select(__u, (__t)=>(Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.INameValuePair[]) (If( __t as Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonArray, out var __s) ? new global::System.Func<Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.INameValuePair[]>(()=> global::System.Linq.Enumerable.ToArray(global::System.Linq.Enumerable.Select(__s, (__r)=>(Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.INameValuePair) (Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.NameValuePair.FromJson(__r) )) ))() : null /* arrayOf */)) ))() : null : MetaData;}
            {_type = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonString>("type"), out var __jsonType) ? (string)__jsonType : (string)Type;}
            {_solution = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonArray>("solutions"), out var __jsonSolutions) ? If( __jsonSolutions as Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonArray, out var __n) ? new global::System.Func<Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISolution[]>(()=> global::System.Linq.Enumerable.ToArray(global::System.Linq.Enumerable.Select(__n, (__m)=>(Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISolution) (Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.Solution.FromJson(__m) )) ))() : null : Solution;}
            AfterFromJson(json);
        }

        /// <summary>
        /// Deserializes a <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonNode"/> into an instance of Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDetectorAbnormalTimePeriod.
        /// </summary>
        /// <param name="node">a <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonNode" /> to deserialize from.</param>
        /// <returns>
        /// an instance of Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDetectorAbnormalTimePeriod.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDetectorAbnormalTimePeriod FromJson(Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonNode node)
        {
            return node is Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonObject json ? new DetectorAbnormalTimePeriod(json) : null;
        }

        /// <summary>
        /// Serializes this instance of <see cref="DetectorAbnormalTimePeriod" /> into a <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonNode" />.
        /// </summary>
        /// <param name="container">The <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonObject"/> container to serialize this object into. If the caller
        /// passes in <c>null</c>, a new instance will be created and returned to the caller.</param>
        /// <param name="serializationMode">Allows the caller to choose the depth of the serialization. See <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.SerializationMode"/>.</param>
        /// <returns>
        /// a serialized instance of <see cref="DetectorAbnormalTimePeriod" /> as a <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonNode" />.
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
            AddIf( null != this._startTime ? (Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonString(this._startTime?.ToString(@"yyyy'-'MM'-'dd'T'HH':'mm':'ss.fffffffK",global::System.Globalization.CultureInfo.InvariantCulture)) : null, "startTime" ,container.Add );
            AddIf( null != this._endTime ? (Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonString(this._endTime?.ToString(@"yyyy'-'MM'-'dd'T'HH':'mm':'ss.fffffffK",global::System.Globalization.CultureInfo.InvariantCulture)) : null, "endTime" ,container.Add );
            AddIf( null != (((object)this._message)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonString(this._message.ToString()) : null, "message" ,container.Add );
            AddIf( null != (((object)this._source)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonString(this._source.ToString()) : null, "source" ,container.Add );
            AddIf( null != this._priority ? (Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonNode)new Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonNumber((double)this._priority) : null, "priority" ,container.Add );
            if (null != this._metaData)
            {
                var __w = new Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.XNodeArray();
                foreach( var __x in this._metaData )
                {
                    AddIf(null != __x ? new Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.XNodeArray(global::System.Linq.Enumerable.ToArray(System.Linq.Enumerable.Select(__x, (__v) => __v?.ToJson(null, serializationMode)))) : null ,__w.Add);
                }
                container.Add("metaData",__w);
            }
            AddIf( null != (((object)this._type)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonString(this._type.ToString()) : null, "type" ,container.Add );
            if (null != this._solution)
            {
                var __o = new Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.XNodeArray();
                foreach( var __p in this._solution )
                {
                    AddIf(__p?.ToJson(null, serializationMode) ,__o.Add);
                }
                container.Add("solutions",__o);
            }
            AfterToJson(ref container);
            return container;
        }
    }
}