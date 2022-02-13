namespace Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview
{
    using static Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Runtime.Extensions;

    /// <summary>The properties that are associated with a streaming job.</summary>
    public partial class StreamingJobProperties
    {

        /// <summary>
        /// <c>AfterFromJson</c> will be called after the json deserialization has finished, allowing customization of the object
        /// before it is returned. Implement this method in a partial class to enable this behavior
        /// </summary>
        /// <param name="json">The JsonNode that should be deserialized into this object.</param>

        partial void AfterFromJson(Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Runtime.Json.JsonObject json);

        /// <summary>
        /// <c>AfterToJson</c> will be called after the json erialization has finished, allowing customization of the <see cref="Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Runtime.Json.JsonObject"
        /// /> before it is returned. Implement this method in a partial class to enable this behavior
        /// </summary>
        /// <param name="container">The JSON container that the serialization result will be placed in.</param>

        partial void AfterToJson(ref Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Runtime.Json.JsonObject container);

        /// <summary>
        /// <c>BeforeFromJson</c> will be called before the json deserialization has commenced, allowing complete customization of
        /// the object before it is deserialized.
        /// If you wish to disable the default deserialization entirely, return <c>true</c> in the <see "returnNow" /> output parameter.
        /// Implement this method in a partial class to enable this behavior.
        /// </summary>
        /// <param name="json">The JsonNode that should be deserialized into this object.</param>
        /// <param name="returnNow">Determines if the rest of the deserialization should be processed, or if the method should return
        /// instantly.</param>

        partial void BeforeFromJson(Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Runtime.Json.JsonObject json, ref bool returnNow);

        /// <summary>
        /// <c>BeforeToJson</c> will be called before the json serialization has commenced, allowing complete customization of the
        /// object before it is serialized.
        /// If you wish to disable the default serialization entirely, return <c>true</c> in the <see "returnNow" /> output parameter.
        /// Implement this method in a partial class to enable this behavior.
        /// </summary>
        /// <param name="container">The JSON container that the serialization result will be placed in.</param>
        /// <param name="returnNow">Determines if the rest of the serialization should be processed, or if the method should return
        /// instantly.</param>

        partial void BeforeToJson(ref Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Runtime.Json.JsonObject container, ref bool returnNow);

        /// <summary>
        /// Deserializes a <see cref="Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Runtime.Json.JsonNode"/> into an instance of Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IStreamingJobProperties.
        /// </summary>
        /// <param name="node">a <see cref="Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Runtime.Json.JsonNode" /> to deserialize from.</param>
        /// <returns>
        /// an instance of Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IStreamingJobProperties.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IStreamingJobProperties FromJson(Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Runtime.Json.JsonNode node)
        {
            return node is Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Runtime.Json.JsonObject json ? new StreamingJobProperties(json) : null;
        }

        /// <summary>
        /// Deserializes a Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Runtime.Json.JsonObject into a new instance of <see cref="StreamingJobProperties" />.
        /// </summary>
        /// <param name="json">A Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Runtime.Json.JsonObject instance to deserialize from.</param>
        internal StreamingJobProperties(Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Runtime.Json.JsonObject json)
        {
            bool returnNow = false;
            BeforeFromJson(json, ref returnNow);
            if (returnNow)
            {
                return;
            }
            {_sku = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Runtime.Json.JsonObject>("sku"), out var __jsonSku) ? Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.StreamingJobSku.FromJson(__jsonSku) : Sku;}
            {_transformation = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Runtime.Json.JsonObject>("transformation"), out var __jsonTransformation) ? Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.Transformation.FromJson(__jsonTransformation) : Transformation;}
            {_jobStorageAccount = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Runtime.Json.JsonObject>("jobStorageAccount"), out var __jsonJobStorageAccount) ? Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.JobStorageAccount.FromJson(__jsonJobStorageAccount) : JobStorageAccount;}
            {_external = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Runtime.Json.JsonObject>("externals"), out var __jsonExternals) ? Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.External.FromJson(__jsonExternals) : External;}
            {_cluster = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Runtime.Json.JsonObject>("cluster"), out var __jsonCluster) ? Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.ClusterInfo.FromJson(__jsonCluster) : Cluster;}
            {_jobId = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Runtime.Json.JsonString>("jobId"), out var __jsonJobId) ? (string)__jsonJobId : (string)JobId;}
            {_provisioningState = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Runtime.Json.JsonString>("provisioningState"), out var __jsonProvisioningState) ? (string)__jsonProvisioningState : (string)ProvisioningState;}
            {_jobState = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Runtime.Json.JsonString>("jobState"), out var __jsonJobState) ? (string)__jsonJobState : (string)JobState;}
            {_jobType = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Runtime.Json.JsonString>("jobType"), out var __jsonJobType) ? (string)__jsonJobType : (string)JobType;}
            {_outputStartMode = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Runtime.Json.JsonString>("outputStartMode"), out var __jsonOutputStartMode) ? (string)__jsonOutputStartMode : (string)OutputStartMode;}
            {_outputStartTime = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Runtime.Json.JsonString>("outputStartTime"), out var __jsonOutputStartTime) ? global::System.DateTime.TryParse((string)__jsonOutputStartTime, global::System.Globalization.CultureInfo.InvariantCulture, global::System.Globalization.DateTimeStyles.AdjustToUniversal, out var __jsonOutputStartTimeValue) ? __jsonOutputStartTimeValue : OutputStartTime : OutputStartTime;}
            {_lastOutputEventTime = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Runtime.Json.JsonString>("lastOutputEventTime"), out var __jsonLastOutputEventTime) ? global::System.DateTime.TryParse((string)__jsonLastOutputEventTime, global::System.Globalization.CultureInfo.InvariantCulture, global::System.Globalization.DateTimeStyles.AdjustToUniversal, out var __jsonLastOutputEventTimeValue) ? __jsonLastOutputEventTimeValue : LastOutputEventTime : LastOutputEventTime;}
            {_eventsOutOfOrderPolicy = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Runtime.Json.JsonString>("eventsOutOfOrderPolicy"), out var __jsonEventsOutOfOrderPolicy) ? (string)__jsonEventsOutOfOrderPolicy : (string)EventsOutOfOrderPolicy;}
            {_outputErrorPolicy = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Runtime.Json.JsonString>("outputErrorPolicy"), out var __jsonOutputErrorPolicy) ? (string)__jsonOutputErrorPolicy : (string)OutputErrorPolicy;}
            {_eventsOutOfOrderMaxDelayInSecond = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Runtime.Json.JsonNumber>("eventsOutOfOrderMaxDelayInSeconds"), out var __jsonEventsOutOfOrderMaxDelayInSeconds) ? (int?)__jsonEventsOutOfOrderMaxDelayInSeconds : EventsOutOfOrderMaxDelayInSecond;}
            {_eventsLateArrivalMaxDelayInSecond = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Runtime.Json.JsonNumber>("eventsLateArrivalMaxDelayInSeconds"), out var __jsonEventsLateArrivalMaxDelayInSeconds) ? (int?)__jsonEventsLateArrivalMaxDelayInSeconds : EventsLateArrivalMaxDelayInSecond;}
            {_dataLocale = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Runtime.Json.JsonString>("dataLocale"), out var __jsonDataLocale) ? (string)__jsonDataLocale : (string)DataLocale;}
            {_compatibilityLevel = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Runtime.Json.JsonString>("compatibilityLevel"), out var __jsonCompatibilityLevel) ? (string)__jsonCompatibilityLevel : (string)CompatibilityLevel;}
            {_createdDate = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Runtime.Json.JsonString>("createdDate"), out var __jsonCreatedDate) ? global::System.DateTime.TryParse((string)__jsonCreatedDate, global::System.Globalization.CultureInfo.InvariantCulture, global::System.Globalization.DateTimeStyles.AdjustToUniversal, out var __jsonCreatedDateValue) ? __jsonCreatedDateValue : CreatedDate : CreatedDate;}
            {_input = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Runtime.Json.JsonArray>("inputs"), out var __jsonInputs) ? If( __jsonInputs as Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Runtime.Json.JsonArray, out var __v) ? new global::System.Func<Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IInput[]>(()=> global::System.Linq.Enumerable.ToArray(global::System.Linq.Enumerable.Select(__v, (__u)=>(Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IInput) (Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.Input.FromJson(__u) )) ))() : null : Input;}
            {_output = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Runtime.Json.JsonArray>("outputs"), out var __jsonOutputs) ? If( __jsonOutputs as Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Runtime.Json.JsonArray, out var __q) ? new global::System.Func<Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IOutput[]>(()=> global::System.Linq.Enumerable.ToArray(global::System.Linq.Enumerable.Select(__q, (__p)=>(Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IOutput) (Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.Output.FromJson(__p) )) ))() : null : Output;}
            {_function = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Runtime.Json.JsonArray>("functions"), out var __jsonFunctions) ? If( __jsonFunctions as Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Runtime.Json.JsonArray, out var __l) ? new global::System.Func<Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IFunction[]>(()=> global::System.Linq.Enumerable.ToArray(global::System.Linq.Enumerable.Select(__l, (__k)=>(Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IFunction) (Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.Function.FromJson(__k) )) ))() : null : Function;}
            {_contentStoragePolicy = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Runtime.Json.JsonString>("contentStoragePolicy"), out var __jsonContentStoragePolicy) ? (string)__jsonContentStoragePolicy : (string)ContentStoragePolicy;}
            AfterFromJson(json);
        }

        /// <summary>
        /// Serializes this instance of <see cref="StreamingJobProperties" /> into a <see cref="Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Runtime.Json.JsonNode" />.
        /// </summary>
        /// <param name="container">The <see cref="Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Runtime.Json.JsonObject"/> container to serialize this object into. If the caller
        /// passes in <c>null</c>, a new instance will be created and returned to the caller.</param>
        /// <param name="serializationMode">Allows the caller to choose the depth of the serialization. See <see cref="Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Runtime.SerializationMode"/>.</param>
        /// <returns>
        /// a serialized instance of <see cref="StreamingJobProperties" /> as a <see cref="Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Runtime.Json.JsonNode" />.
        /// </returns>
        public Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Runtime.Json.JsonNode ToJson(Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Runtime.Json.JsonObject container, Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Runtime.SerializationMode serializationMode)
        {
            container = container ?? new Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Runtime.Json.JsonObject();

            bool returnNow = false;
            BeforeToJson(ref container, ref returnNow);
            if (returnNow)
            {
                return container;
            }
            AddIf( null != this._sku ? (Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Runtime.Json.JsonNode) this._sku.ToJson(null,serializationMode) : null, "sku" ,container.Add );
            AddIf( null != this._transformation ? (Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Runtime.Json.JsonNode) this._transformation.ToJson(null,serializationMode) : null, "transformation" ,container.Add );
            AddIf( null != this._jobStorageAccount ? (Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Runtime.Json.JsonNode) this._jobStorageAccount.ToJson(null,serializationMode) : null, "jobStorageAccount" ,container.Add );
            AddIf( null != this._external ? (Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Runtime.Json.JsonNode) this._external.ToJson(null,serializationMode) : null, "externals" ,container.Add );
            AddIf( null != this._cluster ? (Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Runtime.Json.JsonNode) this._cluster.ToJson(null,serializationMode) : null, "cluster" ,container.Add );
            if (serializationMode.HasFlag(Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Runtime.SerializationMode.IncludeReadOnly))
            {
                AddIf( null != (((object)this._jobId)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Runtime.Json.JsonString(this._jobId.ToString()) : null, "jobId" ,container.Add );
            }
            if (serializationMode.HasFlag(Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Runtime.SerializationMode.IncludeReadOnly))
            {
                AddIf( null != (((object)this._provisioningState)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Runtime.Json.JsonString(this._provisioningState.ToString()) : null, "provisioningState" ,container.Add );
            }
            if (serializationMode.HasFlag(Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Runtime.SerializationMode.IncludeReadOnly))
            {
                AddIf( null != (((object)this._jobState)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Runtime.Json.JsonString(this._jobState.ToString()) : null, "jobState" ,container.Add );
            }
            AddIf( null != (((object)this._jobType)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Runtime.Json.JsonString(this._jobType.ToString()) : null, "jobType" ,container.Add );
            AddIf( null != (((object)this._outputStartMode)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Runtime.Json.JsonString(this._outputStartMode.ToString()) : null, "outputStartMode" ,container.Add );
            AddIf( null != this._outputStartTime ? (Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Runtime.Json.JsonString(this._outputStartTime?.ToString(@"yyyy'-'MM'-'dd'T'HH':'mm':'ss.fffffffK",global::System.Globalization.CultureInfo.InvariantCulture)) : null, "outputStartTime" ,container.Add );
            if (serializationMode.HasFlag(Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Runtime.SerializationMode.IncludeReadOnly))
            {
                AddIf( null != this._lastOutputEventTime ? (Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Runtime.Json.JsonString(this._lastOutputEventTime?.ToString(@"yyyy'-'MM'-'dd'T'HH':'mm':'ss.fffffffK",global::System.Globalization.CultureInfo.InvariantCulture)) : null, "lastOutputEventTime" ,container.Add );
            }
            AddIf( null != (((object)this._eventsOutOfOrderPolicy)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Runtime.Json.JsonString(this._eventsOutOfOrderPolicy.ToString()) : null, "eventsOutOfOrderPolicy" ,container.Add );
            AddIf( null != (((object)this._outputErrorPolicy)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Runtime.Json.JsonString(this._outputErrorPolicy.ToString()) : null, "outputErrorPolicy" ,container.Add );
            AddIf( null != this._eventsOutOfOrderMaxDelayInSecond ? (Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Runtime.Json.JsonNode)new Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Runtime.Json.JsonNumber((int)this._eventsOutOfOrderMaxDelayInSecond) : null, "eventsOutOfOrderMaxDelayInSeconds" ,container.Add );
            AddIf( null != this._eventsLateArrivalMaxDelayInSecond ? (Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Runtime.Json.JsonNode)new Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Runtime.Json.JsonNumber((int)this._eventsLateArrivalMaxDelayInSecond) : null, "eventsLateArrivalMaxDelayInSeconds" ,container.Add );
            AddIf( null != (((object)this._dataLocale)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Runtime.Json.JsonString(this._dataLocale.ToString()) : null, "dataLocale" ,container.Add );
            AddIf( null != (((object)this._compatibilityLevel)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Runtime.Json.JsonString(this._compatibilityLevel.ToString()) : null, "compatibilityLevel" ,container.Add );
            if (serializationMode.HasFlag(Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Runtime.SerializationMode.IncludeReadOnly))
            {
                AddIf( null != this._createdDate ? (Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Runtime.Json.JsonString(this._createdDate?.ToString(@"yyyy'-'MM'-'dd'T'HH':'mm':'ss.fffffffK",global::System.Globalization.CultureInfo.InvariantCulture)) : null, "createdDate" ,container.Add );
            }
            if (null != this._input)
            {
                var __w = new Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Runtime.Json.XNodeArray();
                foreach( var __x in this._input )
                {
                    AddIf(__x?.ToJson(null, serializationMode) ,__w.Add);
                }
                container.Add("inputs",__w);
            }
            if (null != this._output)
            {
                var __r = new Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Runtime.Json.XNodeArray();
                foreach( var __s in this._output )
                {
                    AddIf(__s?.ToJson(null, serializationMode) ,__r.Add);
                }
                container.Add("outputs",__r);
            }
            if (null != this._function)
            {
                var __m = new Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Runtime.Json.XNodeArray();
                foreach( var __n in this._function )
                {
                    AddIf(__n?.ToJson(null, serializationMode) ,__m.Add);
                }
                container.Add("functions",__m);
            }
            AddIf( null != (((object)this._contentStoragePolicy)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Runtime.Json.JsonString(this._contentStoragePolicy.ToString()) : null, "contentStoragePolicy" ,container.Add );
            AfterToJson(ref container);
            return container;
        }
    }
}