namespace Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601
{
    using static Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.Extensions;

    /// <summary>Alert details</summary>
    public partial class AlertPropertiesDetails
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
        /// Deserializes a Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.Json.JsonObject into a new instance of <see cref="AlertPropertiesDetails" />.
        /// </summary>
        /// <param name="json">A Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.Json.JsonObject instance to deserialize from.</param>
        internal AlertPropertiesDetails(Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.Json.JsonObject json)
        {
            bool returnNow = false;
            BeforeFromJson(json, ref returnNow);
            if (returnNow)
            {
                return;
            }
            {_timeGrainType = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.Json.JsonString>("timeGrainType"), out var __jsonTimeGrainType) ? (string)__jsonTimeGrainType : (string)TimeGrainType;}
            {_periodStartDate = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.Json.JsonString>("periodStartDate"), out var __jsonPeriodStartDate) ? (string)__jsonPeriodStartDate : (string)PeriodStartDate;}
            {_triggeredBy = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.Json.JsonString>("triggeredBy"), out var __jsonTriggeredBy) ? (string)__jsonTriggeredBy : (string)TriggeredBy;}
            {_resourceGroupFilter = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.Json.JsonArray>("resourceGroupFilter"), out var __jsonResourceGroupFilter) ? If( __jsonResourceGroupFilter as Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.Json.JsonArray, out var __v) ? new global::System.Func<string[]>(()=> global::System.Linq.Enumerable.ToArray(global::System.Linq.Enumerable.Select(__v, (__u)=>(string) (__u is Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.Json.JsonString __t ? (string)(__t.ToString()) : null)) ))() : null : ResourceGroupFilter;}
            {_resourceFilter = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.Json.JsonArray>("resourceFilter"), out var __jsonResourceFilter) ? If( __jsonResourceFilter as Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.Json.JsonArray, out var __q) ? new global::System.Func<string[]>(()=> global::System.Linq.Enumerable.ToArray(global::System.Linq.Enumerable.Select(__q, (__p)=>(string) (__p is Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.Json.JsonString __o ? (string)(__o.ToString()) : null)) ))() : null : ResourceFilter;}
            {_meterFilter = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.Json.JsonArray>("meterFilter"), out var __jsonMeterFilter) ? If( __jsonMeterFilter as Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.Json.JsonArray, out var __l) ? new global::System.Func<string[]>(()=> global::System.Linq.Enumerable.ToArray(global::System.Linq.Enumerable.Select(__l, (__k)=>(string) (__k is Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.Json.JsonString __j ? (string)(__j.ToString()) : null)) ))() : null : MeterFilter;}
            {_tagFilter = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.Json.JsonObject>("tagFilter"), out var __jsonTagFilter) ? Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Any.FromJson(__jsonTagFilter) : TagFilter;}
            {_threshold = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.Json.JsonNumber>("threshold"), out var __jsonThreshold) ? (decimal?)__jsonThreshold : Threshold;}
            {_operator = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.Json.JsonString>("operator"), out var __jsonOperator) ? (string)__jsonOperator : (string)Operator;}
            {_amount = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.Json.JsonNumber>("amount"), out var __jsonAmount) ? (decimal?)__jsonAmount : Amount;}
            {_unit = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.Json.JsonString>("unit"), out var __jsonUnit) ? (string)__jsonUnit : (string)Unit;}
            {_currentSpend = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.Json.JsonNumber>("currentSpend"), out var __jsonCurrentSpend) ? (decimal?)__jsonCurrentSpend : CurrentSpend;}
            {_contactEmail = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.Json.JsonArray>("contactEmails"), out var __jsonContactEmails) ? If( __jsonContactEmails as Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.Json.JsonArray, out var __g) ? new global::System.Func<string[]>(()=> global::System.Linq.Enumerable.ToArray(global::System.Linq.Enumerable.Select(__g, (__f)=>(string) (__f is Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.Json.JsonString __e ? (string)(__e.ToString()) : null)) ))() : null : ContactEmail;}
            {_contactGroup = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.Json.JsonArray>("contactGroups"), out var __jsonContactGroups) ? If( __jsonContactGroups as Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.Json.JsonArray, out var __b) ? new global::System.Func<string[]>(()=> global::System.Linq.Enumerable.ToArray(global::System.Linq.Enumerable.Select(__b, (__a)=>(string) (__a is Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.Json.JsonString ___z ? (string)(___z.ToString()) : null)) ))() : null : ContactGroup;}
            {_contactRole = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.Json.JsonArray>("contactRoles"), out var __jsonContactRoles) ? If( __jsonContactRoles as Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.Json.JsonArray, out var ___w) ? new global::System.Func<string[]>(()=> global::System.Linq.Enumerable.ToArray(global::System.Linq.Enumerable.Select(___w, (___v)=>(string) (___v is Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.Json.JsonString ___u ? (string)(___u.ToString()) : null)) ))() : null : ContactRole;}
            {_overridingAlert = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.Json.JsonString>("overridingAlert"), out var __jsonOverridingAlert) ? (string)__jsonOverridingAlert : (string)OverridingAlert;}
            AfterFromJson(json);
        }

        /// <summary>
        /// Deserializes a <see cref="Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.Json.JsonNode"/> into an instance of Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IAlertPropertiesDetails.
        /// </summary>
        /// <param name="node">a <see cref="Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.Json.JsonNode" /> to deserialize from.</param>
        /// <returns>
        /// an instance of Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IAlertPropertiesDetails.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IAlertPropertiesDetails FromJson(Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.Json.JsonNode node)
        {
            return node is Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.Json.JsonObject json ? new AlertPropertiesDetails(json) : null;
        }

        /// <summary>
        /// Serializes this instance of <see cref="AlertPropertiesDetails" /> into a <see cref="Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.Json.JsonNode" />.
        /// </summary>
        /// <param name="container">The <see cref="Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.Json.JsonObject"/> container to serialize this object into. If the caller
        /// passes in <c>null</c>, a new instance will be created and returned to the caller.</param>
        /// <param name="serializationMode">Allows the caller to choose the depth of the serialization. See <see cref="Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.SerializationMode"/>.</param>
        /// <returns>
        /// a serialized instance of <see cref="AlertPropertiesDetails" /> as a <see cref="Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.Json.JsonNode" />.
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
            AddIf( null != (((object)this._timeGrainType)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.Json.JsonString(this._timeGrainType.ToString()) : null, "timeGrainType" ,container.Add );
            AddIf( null != (((object)this._periodStartDate)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.Json.JsonString(this._periodStartDate.ToString()) : null, "periodStartDate" ,container.Add );
            AddIf( null != (((object)this._triggeredBy)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.Json.JsonString(this._triggeredBy.ToString()) : null, "triggeredBy" ,container.Add );
            if (null != this._resourceGroupFilter)
            {
                var __w = new Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.Json.XNodeArray();
                foreach( var __x in this._resourceGroupFilter )
                {
                    AddIf(null != (((object)__x)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.Json.JsonString(__x.ToString()) : null ,__w.Add);
                }
                container.Add("resourceGroupFilter",__w);
            }
            if (null != this._resourceFilter)
            {
                var __r = new Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.Json.XNodeArray();
                foreach( var __s in this._resourceFilter )
                {
                    AddIf(null != (((object)__s)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.Json.JsonString(__s.ToString()) : null ,__r.Add);
                }
                container.Add("resourceFilter",__r);
            }
            if (null != this._meterFilter)
            {
                var __m = new Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.Json.XNodeArray();
                foreach( var __n in this._meterFilter )
                {
                    AddIf(null != (((object)__n)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.Json.JsonString(__n.ToString()) : null ,__m.Add);
                }
                container.Add("meterFilter",__m);
            }
            AddIf( null != this._tagFilter ? (Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.Json.JsonNode) this._tagFilter.ToJson(null,serializationMode) : null, "tagFilter" ,container.Add );
            AddIf( null != this._threshold ? (Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.Json.JsonNode)new Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.Json.JsonNumber((decimal)this._threshold) : null, "threshold" ,container.Add );
            AddIf( null != (((object)this._operator)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.Json.JsonString(this._operator.ToString()) : null, "operator" ,container.Add );
            AddIf( null != this._amount ? (Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.Json.JsonNode)new Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.Json.JsonNumber((decimal)this._amount) : null, "amount" ,container.Add );
            AddIf( null != (((object)this._unit)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.Json.JsonString(this._unit.ToString()) : null, "unit" ,container.Add );
            AddIf( null != this._currentSpend ? (Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.Json.JsonNode)new Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.Json.JsonNumber((decimal)this._currentSpend) : null, "currentSpend" ,container.Add );
            if (null != this._contactEmail)
            {
                var __h = new Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.Json.XNodeArray();
                foreach( var __i in this._contactEmail )
                {
                    AddIf(null != (((object)__i)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.Json.JsonString(__i.ToString()) : null ,__h.Add);
                }
                container.Add("contactEmails",__h);
            }
            if (null != this._contactGroup)
            {
                var __c = new Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.Json.XNodeArray();
                foreach( var __d in this._contactGroup )
                {
                    AddIf(null != (((object)__d)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.Json.JsonString(__d.ToString()) : null ,__c.Add);
                }
                container.Add("contactGroups",__c);
            }
            if (null != this._contactRole)
            {
                var ___x = new Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.Json.XNodeArray();
                foreach( var ___y in this._contactRole )
                {
                    AddIf(null != (((object)___y)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.Json.JsonString(___y.ToString()) : null ,___x.Add);
                }
                container.Add("contactRoles",___x);
            }
            AddIf( null != (((object)this._overridingAlert)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.Json.JsonString(this._overridingAlert.ToString()) : null, "overridingAlert" ,container.Add );
            AfterToJson(ref container);
            return container;
        }
    }
}