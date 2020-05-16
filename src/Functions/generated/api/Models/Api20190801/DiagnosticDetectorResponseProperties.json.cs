namespace Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Extensions;

    /// <summary>DiagnosticDetectorResponse resource specific properties</summary>
    public partial class DiagnosticDetectorResponseProperties
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
        /// Deserializes a Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonObject into a new instance of <see cref="DiagnosticDetectorResponseProperties" />.
        /// </summary>
        /// <param name="json">A Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonObject instance to deserialize from.</param>
        internal DiagnosticDetectorResponseProperties(Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonObject json)
        {
            bool returnNow = false;
            BeforeFromJson(json, ref returnNow);
            if (returnNow)
            {
                return;
            }
            {_detectorDefinition = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonObject>("detectorDefinition"), out var __jsonDetectorDefinition) ? Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.DetectorDefinition.FromJson(__jsonDetectorDefinition) : DetectorDefinition;}
            {_responseMetaData = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonObject>("responseMetaData"), out var __jsonResponseMetaData) ? Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ResponseMetaData.FromJson(__jsonResponseMetaData) : ResponseMetaData;}
            {_abnormalTimePeriod = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonArray>("abnormalTimePeriods"), out var __jsonAbnormalTimePeriods) ? If( __jsonAbnormalTimePeriods as Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonArray, out var __v) ? new global::System.Func<Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDetectorAbnormalTimePeriod[]>(()=> global::System.Linq.Enumerable.ToArray(global::System.Linq.Enumerable.Select(__v, (__u)=>(Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDetectorAbnormalTimePeriod) (Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.DetectorAbnormalTimePeriod.FromJson(__u) )) ))() : null : AbnormalTimePeriod;}
            {_data = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonArray>("data"), out var __jsonData) ? If( __jsonData as Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonArray, out var __p) ? new global::System.Func<Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.INameValuePair[][]>(()=> global::System.Linq.Enumerable.ToArray(global::System.Linq.Enumerable.Select(__p, (__o)=>(Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.INameValuePair[]) (If( __o as Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonArray, out var __n) ? new global::System.Func<Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.INameValuePair[]>(()=> global::System.Linq.Enumerable.ToArray(global::System.Linq.Enumerable.Select(__n, (__m)=>(Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.INameValuePair) (Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.NameValuePair.FromJson(__m) )) ))() : null /* arrayOf */)) ))() : null : Data;}
            {_endTime = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonString>("endTime"), out var __jsonEndTime) ? global::System.DateTime.TryParse((string)__jsonEndTime, global::System.Globalization.CultureInfo.InvariantCulture, global::System.Globalization.DateTimeStyles.AdjustToUniversal, out var __jsonEndTimeValue) ? __jsonEndTimeValue : EndTime : EndTime;}
            {_issueDetected = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonBoolean>("issueDetected"), out var __jsonIssueDetected) ? (bool?)__jsonIssueDetected : IssueDetected;}
            {_metric = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonArray>("metrics"), out var __jsonMetrics) ? If( __jsonMetrics as Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonArray, out var __i) ? new global::System.Func<Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDiagnosticMetricSet[]>(()=> global::System.Linq.Enumerable.ToArray(global::System.Linq.Enumerable.Select(__i, (__h)=>(Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDiagnosticMetricSet) (Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.DiagnosticMetricSet.FromJson(__h) )) ))() : null : Metric;}
            {_startTime = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonString>("startTime"), out var __jsonStartTime) ? global::System.DateTime.TryParse((string)__jsonStartTime, global::System.Globalization.CultureInfo.InvariantCulture, global::System.Globalization.DateTimeStyles.AdjustToUniversal, out var __jsonStartTimeValue) ? __jsonStartTimeValue : StartTime : StartTime;}
            AfterFromJson(json);
        }

        /// <summary>
        /// Deserializes a <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonNode"/> into an instance of Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDiagnosticDetectorResponseProperties.
        /// </summary>
        /// <param name="node">a <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonNode" /> to deserialize from.</param>
        /// <returns>
        /// an instance of Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDiagnosticDetectorResponseProperties.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDiagnosticDetectorResponseProperties FromJson(Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonNode node)
        {
            return node is Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonObject json ? new DiagnosticDetectorResponseProperties(json) : null;
        }

        /// <summary>
        /// Serializes this instance of <see cref="DiagnosticDetectorResponseProperties" /> into a <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonNode"
        /// />.
        /// </summary>
        /// <param name="container">The <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonObject"/> container to serialize this object into. If the caller
        /// passes in <c>null</c>, a new instance will be created and returned to the caller.</param>
        /// <param name="serializationMode">Allows the caller to choose the depth of the serialization. See <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.SerializationMode"/>.</param>
        /// <returns>
        /// a serialized instance of <see cref="DiagnosticDetectorResponseProperties" /> as a <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonNode" />.
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
            AddIf( null != this._detectorDefinition ? (Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonNode) this._detectorDefinition.ToJson(null,serializationMode) : null, "detectorDefinition" ,container.Add );
            AddIf( null != this._responseMetaData ? (Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonNode) this._responseMetaData.ToJson(null,serializationMode) : null, "responseMetaData" ,container.Add );
            if (null != this._abnormalTimePeriod)
            {
                var __w = new Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.XNodeArray();
                foreach( var __x in this._abnormalTimePeriod )
                {
                    AddIf(__x?.ToJson(null, serializationMode) ,__w.Add);
                }
                container.Add("abnormalTimePeriods",__w);
            }
            if (null != this._data)
            {
                var __r = new Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.XNodeArray();
                foreach( var __s in this._data )
                {
                    AddIf(null != __s ? new Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.XNodeArray(global::System.Linq.Enumerable.ToArray(System.Linq.Enumerable.Select(__s, (__q) => __q?.ToJson(null, serializationMode)))) : null ,__r.Add);
                }
                container.Add("data",__r);
            }
            AddIf( null != this._endTime ? (Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonString(this._endTime?.ToString(@"yyyy'-'MM'-'dd'T'HH':'mm':'ss.fffffffK",global::System.Globalization.CultureInfo.InvariantCulture)) : null, "endTime" ,container.Add );
            AddIf( null != this._issueDetected ? (Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonNode)new Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonBoolean((bool)this._issueDetected) : null, "issueDetected" ,container.Add );
            if (null != this._metric)
            {
                var __j = new Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.XNodeArray();
                foreach( var __k in this._metric )
                {
                    AddIf(__k?.ToJson(null, serializationMode) ,__j.Add);
                }
                container.Add("metrics",__j);
            }
            AddIf( null != this._startTime ? (Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonString(this._startTime?.ToString(@"yyyy'-'MM'-'dd'T'HH':'mm':'ss.fffffffK",global::System.Globalization.CultureInfo.InvariantCulture)) : null, "startTime" ,container.Add );
            AfterToJson(ref container);
            return container;
        }
    }
}