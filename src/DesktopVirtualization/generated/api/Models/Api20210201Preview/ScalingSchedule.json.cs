namespace Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Models.Api20210201Preview
{
    using static Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Runtime.Extensions;

    /// <summary>Scaling plan schedule.</summary>
    public partial class ScalingSchedule
    {

        /// <summary>
        /// <c>AfterFromJson</c> will be called after the json deserialization has finished, allowing customization of the object
        /// before it is returned. Implement this method in a partial class to enable this behavior
        /// </summary>
        /// <param name="json">The JsonNode that should be deserialized into this object.</param>

        partial void AfterFromJson(Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Runtime.Json.JsonObject json);

        /// <summary>
        /// <c>AfterToJson</c> will be called after the json erialization has finished, allowing customization of the <see cref="Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Runtime.Json.JsonObject"
        /// /> before it is returned. Implement this method in a partial class to enable this behavior
        /// </summary>
        /// <param name="container">The JSON container that the serialization result will be placed in.</param>

        partial void AfterToJson(ref Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Runtime.Json.JsonObject container);

        /// <summary>
        /// <c>BeforeFromJson</c> will be called before the json deserialization has commenced, allowing complete customization of
        /// the object before it is deserialized.
        /// If you wish to disable the default deserialization entirely, return <c>true</c> in the <see "returnNow" /> output parameter.
        /// Implement this method in a partial class to enable this behavior.
        /// </summary>
        /// <param name="json">The JsonNode that should be deserialized into this object.</param>
        /// <param name="returnNow">Determines if the rest of the deserialization should be processed, or if the method should return
        /// instantly.</param>

        partial void BeforeFromJson(Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Runtime.Json.JsonObject json, ref bool returnNow);

        /// <summary>
        /// <c>BeforeToJson</c> will be called before the json serialization has commenced, allowing complete customization of the
        /// object before it is serialized.
        /// If you wish to disable the default serialization entirely, return <c>true</c> in the <see "returnNow" /> output parameter.
        /// Implement this method in a partial class to enable this behavior.
        /// </summary>
        /// <param name="container">The JSON container that the serialization result will be placed in.</param>
        /// <param name="returnNow">Determines if the rest of the serialization should be processed, or if the method should return
        /// instantly.</param>

        partial void BeforeToJson(ref Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Runtime.Json.JsonObject container, ref bool returnNow);

        /// <summary>
        /// Deserializes a <see cref="Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Runtime.Json.JsonNode"/> into an instance of Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Models.Api20210201Preview.IScalingSchedule.
        /// </summary>
        /// <param name="node">a <see cref="Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Runtime.Json.JsonNode" /> to deserialize from.</param>
        /// <returns>
        /// an instance of Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Models.Api20210201Preview.IScalingSchedule.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Models.Api20210201Preview.IScalingSchedule FromJson(Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Runtime.Json.JsonNode node)
        {
            return node is Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Runtime.Json.JsonObject json ? new ScalingSchedule(json) : null;
        }

        /// <summary>
        /// Deserializes a Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Runtime.Json.JsonObject into a new instance of <see cref="ScalingSchedule" />.
        /// </summary>
        /// <param name="json">A Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Runtime.Json.JsonObject instance to deserialize from.</param>
        internal ScalingSchedule(Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Runtime.Json.JsonObject json)
        {
            bool returnNow = false;
            BeforeFromJson(json, ref returnNow);
            if (returnNow)
            {
                return;
            }
            {_name = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Runtime.Json.JsonString>("name"), out var __jsonName) ? (string)__jsonName : (string)Name;}
            {_daysOfWeek = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Runtime.Json.JsonArray>("daysOfWeek"), out var __jsonDaysOfWeek) ? If( __jsonDaysOfWeek as Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Runtime.Json.JsonArray, out var __v) ? new global::System.Func<string[]>(()=> global::System.Linq.Enumerable.ToArray(global::System.Linq.Enumerable.Select(__v, (__u)=>(string) (__u is Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Runtime.Json.JsonString __t ? (string)(__t.ToString()) : null)) ))() : null : DaysOfWeek;}
            {_rampUpStartTime = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Runtime.Json.JsonString>("rampUpStartTime"), out var __jsonRampUpStartTime) ? global::System.DateTime.TryParse((string)__jsonRampUpStartTime, global::System.Globalization.CultureInfo.InvariantCulture, global::System.Globalization.DateTimeStyles.AdjustToUniversal, out var __jsonRampUpStartTimeValue) ? __jsonRampUpStartTimeValue : RampUpStartTime : RampUpStartTime;}
            {_rampUpLoadBalancingAlgorithm = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Runtime.Json.JsonString>("rampUpLoadBalancingAlgorithm"), out var __jsonRampUpLoadBalancingAlgorithm) ? (string)__jsonRampUpLoadBalancingAlgorithm : (string)RampUpLoadBalancingAlgorithm;}
            {_rampUpMinimumHostsPct = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Runtime.Json.JsonNumber>("rampUpMinimumHostsPct"), out var __jsonRampUpMinimumHostsPct) ? (int?)__jsonRampUpMinimumHostsPct : RampUpMinimumHostsPct;}
            {_rampUpCapacityThresholdPct = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Runtime.Json.JsonNumber>("rampUpCapacityThresholdPct"), out var __jsonRampUpCapacityThresholdPct) ? (int?)__jsonRampUpCapacityThresholdPct : RampUpCapacityThresholdPct;}
            {_peakStartTime = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Runtime.Json.JsonString>("peakStartTime"), out var __jsonPeakStartTime) ? global::System.DateTime.TryParse((string)__jsonPeakStartTime, global::System.Globalization.CultureInfo.InvariantCulture, global::System.Globalization.DateTimeStyles.AdjustToUniversal, out var __jsonPeakStartTimeValue) ? __jsonPeakStartTimeValue : PeakStartTime : PeakStartTime;}
            {_peakLoadBalancingAlgorithm = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Runtime.Json.JsonString>("peakLoadBalancingAlgorithm"), out var __jsonPeakLoadBalancingAlgorithm) ? (string)__jsonPeakLoadBalancingAlgorithm : (string)PeakLoadBalancingAlgorithm;}
            {_rampDownStartTime = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Runtime.Json.JsonString>("rampDownStartTime"), out var __jsonRampDownStartTime) ? global::System.DateTime.TryParse((string)__jsonRampDownStartTime, global::System.Globalization.CultureInfo.InvariantCulture, global::System.Globalization.DateTimeStyles.AdjustToUniversal, out var __jsonRampDownStartTimeValue) ? __jsonRampDownStartTimeValue : RampDownStartTime : RampDownStartTime;}
            {_rampDownLoadBalancingAlgorithm = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Runtime.Json.JsonString>("rampDownLoadBalancingAlgorithm"), out var __jsonRampDownLoadBalancingAlgorithm) ? (string)__jsonRampDownLoadBalancingAlgorithm : (string)RampDownLoadBalancingAlgorithm;}
            {_rampDownMinimumHostsPct = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Runtime.Json.JsonNumber>("rampDownMinimumHostsPct"), out var __jsonRampDownMinimumHostsPct) ? (int?)__jsonRampDownMinimumHostsPct : RampDownMinimumHostsPct;}
            {_rampDownCapacityThresholdPct = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Runtime.Json.JsonNumber>("rampDownCapacityThresholdPct"), out var __jsonRampDownCapacityThresholdPct) ? (int?)__jsonRampDownCapacityThresholdPct : RampDownCapacityThresholdPct;}
            {_rampDownForceLogoffUser = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Runtime.Json.JsonBoolean>("rampDownForceLogoffUsers"), out var __jsonRampDownForceLogoffUsers) ? (bool?)__jsonRampDownForceLogoffUsers : RampDownForceLogoffUser;}
            {_rampDownStopHostsWhen = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Runtime.Json.JsonString>("rampDownStopHostsWhen"), out var __jsonRampDownStopHostsWhen) ? (string)__jsonRampDownStopHostsWhen : (string)RampDownStopHostsWhen;}
            {_rampDownWaitTimeMinute = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Runtime.Json.JsonNumber>("rampDownWaitTimeMinutes"), out var __jsonRampDownWaitTimeMinutes) ? (int?)__jsonRampDownWaitTimeMinutes : RampDownWaitTimeMinute;}
            {_rampDownNotificationMessage = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Runtime.Json.JsonString>("rampDownNotificationMessage"), out var __jsonRampDownNotificationMessage) ? (string)__jsonRampDownNotificationMessage : (string)RampDownNotificationMessage;}
            {_offPeakStartTime = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Runtime.Json.JsonString>("offPeakStartTime"), out var __jsonOffPeakStartTime) ? global::System.DateTime.TryParse((string)__jsonOffPeakStartTime, global::System.Globalization.CultureInfo.InvariantCulture, global::System.Globalization.DateTimeStyles.AdjustToUniversal, out var __jsonOffPeakStartTimeValue) ? __jsonOffPeakStartTimeValue : OffPeakStartTime : OffPeakStartTime;}
            {_offPeakLoadBalancingAlgorithm = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Runtime.Json.JsonString>("offPeakLoadBalancingAlgorithm"), out var __jsonOffPeakLoadBalancingAlgorithm) ? (string)__jsonOffPeakLoadBalancingAlgorithm : (string)OffPeakLoadBalancingAlgorithm;}
            AfterFromJson(json);
        }

        /// <summary>
        /// Serializes this instance of <see cref="ScalingSchedule" /> into a <see cref="Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Runtime.Json.JsonNode" />.
        /// </summary>
        /// <param name="container">The <see cref="Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Runtime.Json.JsonObject"/> container to serialize this object into. If the caller
        /// passes in <c>null</c>, a new instance will be created and returned to the caller.</param>
        /// <param name="serializationMode">Allows the caller to choose the depth of the serialization. See <see cref="Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Runtime.SerializationMode"/>.</param>
        /// <returns>
        /// a serialized instance of <see cref="ScalingSchedule" /> as a <see cref="Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Runtime.Json.JsonNode" />.
        /// </returns>
        public Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Runtime.Json.JsonNode ToJson(Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Runtime.Json.JsonObject container, Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Runtime.SerializationMode serializationMode)
        {
            container = container ?? new Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Runtime.Json.JsonObject();

            bool returnNow = false;
            BeforeToJson(ref container, ref returnNow);
            if (returnNow)
            {
                return container;
            }
            AddIf( null != (((object)this._name)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Runtime.Json.JsonString(this._name.ToString()) : null, "name" ,container.Add );
            if (null != this._daysOfWeek)
            {
                var __w = new Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Runtime.Json.XNodeArray();
                foreach( var __x in this._daysOfWeek )
                {
                    AddIf(null != (((object)__x)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Runtime.Json.JsonString(__x.ToString()) : null ,__w.Add);
                }
                container.Add("daysOfWeek",__w);
            }
            AddIf( null != this._rampUpStartTime ? (Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Runtime.Json.JsonString(this._rampUpStartTime?.ToString(@"yyyy'-'MM'-'dd'T'HH':'mm':'ss.fffffffK",global::System.Globalization.CultureInfo.InvariantCulture)) : null, "rampUpStartTime" ,container.Add );
            AddIf( null != (((object)this._rampUpLoadBalancingAlgorithm)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Runtime.Json.JsonString(this._rampUpLoadBalancingAlgorithm.ToString()) : null, "rampUpLoadBalancingAlgorithm" ,container.Add );
            AddIf( null != this._rampUpMinimumHostsPct ? (Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Runtime.Json.JsonNode)new Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Runtime.Json.JsonNumber((int)this._rampUpMinimumHostsPct) : null, "rampUpMinimumHostsPct" ,container.Add );
            AddIf( null != this._rampUpCapacityThresholdPct ? (Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Runtime.Json.JsonNode)new Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Runtime.Json.JsonNumber((int)this._rampUpCapacityThresholdPct) : null, "rampUpCapacityThresholdPct" ,container.Add );
            AddIf( null != this._peakStartTime ? (Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Runtime.Json.JsonString(this._peakStartTime?.ToString(@"yyyy'-'MM'-'dd'T'HH':'mm':'ss.fffffffK",global::System.Globalization.CultureInfo.InvariantCulture)) : null, "peakStartTime" ,container.Add );
            AddIf( null != (((object)this._peakLoadBalancingAlgorithm)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Runtime.Json.JsonString(this._peakLoadBalancingAlgorithm.ToString()) : null, "peakLoadBalancingAlgorithm" ,container.Add );
            AddIf( null != this._rampDownStartTime ? (Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Runtime.Json.JsonString(this._rampDownStartTime?.ToString(@"yyyy'-'MM'-'dd'T'HH':'mm':'ss.fffffffK",global::System.Globalization.CultureInfo.InvariantCulture)) : null, "rampDownStartTime" ,container.Add );
            AddIf( null != (((object)this._rampDownLoadBalancingAlgorithm)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Runtime.Json.JsonString(this._rampDownLoadBalancingAlgorithm.ToString()) : null, "rampDownLoadBalancingAlgorithm" ,container.Add );
            AddIf( null != this._rampDownMinimumHostsPct ? (Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Runtime.Json.JsonNode)new Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Runtime.Json.JsonNumber((int)this._rampDownMinimumHostsPct) : null, "rampDownMinimumHostsPct" ,container.Add );
            AddIf( null != this._rampDownCapacityThresholdPct ? (Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Runtime.Json.JsonNode)new Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Runtime.Json.JsonNumber((int)this._rampDownCapacityThresholdPct) : null, "rampDownCapacityThresholdPct" ,container.Add );
            AddIf( null != this._rampDownForceLogoffUser ? (Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Runtime.Json.JsonNode)new Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Runtime.Json.JsonBoolean((bool)this._rampDownForceLogoffUser) : null, "rampDownForceLogoffUsers" ,container.Add );
            AddIf( null != (((object)this._rampDownStopHostsWhen)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Runtime.Json.JsonString(this._rampDownStopHostsWhen.ToString()) : null, "rampDownStopHostsWhen" ,container.Add );
            AddIf( null != this._rampDownWaitTimeMinute ? (Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Runtime.Json.JsonNode)new Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Runtime.Json.JsonNumber((int)this._rampDownWaitTimeMinute) : null, "rampDownWaitTimeMinutes" ,container.Add );
            AddIf( null != (((object)this._rampDownNotificationMessage)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Runtime.Json.JsonString(this._rampDownNotificationMessage.ToString()) : null, "rampDownNotificationMessage" ,container.Add );
            AddIf( null != this._offPeakStartTime ? (Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Runtime.Json.JsonString(this._offPeakStartTime?.ToString(@"yyyy'-'MM'-'dd'T'HH':'mm':'ss.fffffffK",global::System.Globalization.CultureInfo.InvariantCulture)) : null, "offPeakStartTime" ,container.Add );
            AddIf( null != (((object)this._offPeakLoadBalancingAlgorithm)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Runtime.Json.JsonString(this._offPeakLoadBalancingAlgorithm.ToString()) : null, "offPeakLoadBalancingAlgorithm" ,container.Add );
            AfterToJson(ref container);
            return container;
        }
    }
}