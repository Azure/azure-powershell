namespace Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Extensions;

    /// <summary>class to define the summary of the health error details.</summary>
    public partial class HealthErrorSummary
    {

        /// <summary>
        /// <c>AfterFromJson</c> will be called after the json deserialization has finished, allowing customization of the object
        /// before it is returned. Implement this method in a partial class to enable this behavior
        /// </summary>
        /// <param name="json">The JsonNode that should be deserialized into this object.</param>

        partial void AfterFromJson(Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonObject json);

        /// <summary>
        /// <c>AfterToJson</c> will be called after the json erialization has finished, allowing customization of the <see cref="Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonObject"
        /// /> before it is returned. Implement this method in a partial class to enable this behavior
        /// </summary>
        /// <param name="container">The JSON container that the serialization result will be placed in.</param>

        partial void AfterToJson(ref Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonObject container);

        /// <summary>
        /// <c>BeforeFromJson</c> will be called before the json deserialization has commenced, allowing complete customization of
        /// the object before it is deserialized.
        /// If you wish to disable the default deserialization entirely, return <c>true</c> in the <see "returnNow" /> output parameter.
        /// Implement this method in a partial class to enable this behavior.
        /// </summary>
        /// <param name="json">The JsonNode that should be deserialized into this object.</param>
        /// <param name="returnNow">Determines if the rest of the deserialization should be processed, or if the method should return
        /// instantly.</param>

        partial void BeforeFromJson(Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonObject json, ref bool returnNow);

        /// <summary>
        /// <c>BeforeToJson</c> will be called before the json serialization has commenced, allowing complete customization of the
        /// object before it is serialized.
        /// If you wish to disable the default serialization entirely, return <c>true</c> in the <see "returnNow" /> output parameter.
        /// Implement this method in a partial class to enable this behavior.
        /// </summary>
        /// <param name="container">The JSON container that the serialization result will be placed in.</param>
        /// <param name="returnNow">Determines if the rest of the serialization should be processed, or if the method should return
        /// instantly.</param>

        partial void BeforeToJson(ref Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonObject container, ref bool returnNow);

        /// <summary>
        /// Deserializes a <see cref="Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonNode"/> into an instance of Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IHealthErrorSummary.
        /// </summary>
        /// <param name="node">a <see cref="Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonNode" /> to deserialize from.</param>
        /// <returns>
        /// an instance of Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IHealthErrorSummary.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IHealthErrorSummary FromJson(Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonNode node)
        {
            return node is Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonObject json ? new HealthErrorSummary(json) : null;
        }

        /// <summary>
        /// Deserializes a Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonObject into a new instance of <see cref="HealthErrorSummary" />.
        /// </summary>
        /// <param name="json">A Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonObject instance to deserialize from.</param>
        internal HealthErrorSummary(Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonObject json)
        {
            bool returnNow = false;
            BeforeFromJson(json, ref returnNow);
            if (returnNow)
            {
                return;
            }
            {_summaryCode = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonString>("summaryCode"), out var __jsonSummaryCode) ? (string)__jsonSummaryCode : (string)SummaryCode;}
            {_category = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonString>("category"), out var __jsonCategory) ? (string)__jsonCategory : (string)Category;}
            {_severity = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonString>("severity"), out var __jsonSeverity) ? (string)__jsonSeverity : (string)Severity;}
            {_summaryMessage = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonString>("summaryMessage"), out var __jsonSummaryMessage) ? (string)__jsonSummaryMessage : (string)SummaryMessage;}
            {_affectedResourceType = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonString>("affectedResourceType"), out var __jsonAffectedResourceType) ? (string)__jsonAffectedResourceType : (string)AffectedResourceType;}
            {_affectedResourceSubtype = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonString>("affectedResourceSubtype"), out var __jsonAffectedResourceSubtype) ? (string)__jsonAffectedResourceSubtype : (string)AffectedResourceSubtype;}
            {_affectedResourceCorrelationId = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonArray>("affectedResourceCorrelationIds"), out var __jsonAffectedResourceCorrelationIds) ? If( __jsonAffectedResourceCorrelationIds as Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonArray, out var __v) ? new global::System.Func<string[]>(()=> global::System.Linq.Enumerable.ToArray(global::System.Linq.Enumerable.Select(__v, (__u)=>(string) (__u is Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonString __t ? (string)(__t.ToString()) : null)) ))() : null : AffectedResourceCorrelationId;}
            AfterFromJson(json);
        }

        /// <summary>
        /// Serializes this instance of <see cref="HealthErrorSummary" /> into a <see cref="Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonNode" />.
        /// </summary>
        /// <param name="container">The <see cref="Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonObject"/> container to serialize this object into. If the caller
        /// passes in <c>null</c>, a new instance will be created and returned to the caller.</param>
        /// <param name="serializationMode">Allows the caller to choose the depth of the serialization. See <see cref="Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.SerializationMode"/>.</param>
        /// <returns>
        /// a serialized instance of <see cref="HealthErrorSummary" /> as a <see cref="Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonNode" />.
        /// </returns>
        public Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonNode ToJson(Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonObject container, Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.SerializationMode serializationMode)
        {
            container = container ?? new Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonObject();

            bool returnNow = false;
            BeforeToJson(ref container, ref returnNow);
            if (returnNow)
            {
                return container;
            }
            AddIf( null != (((object)this._summaryCode)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonString(this._summaryCode.ToString()) : null, "summaryCode" ,container.Add );
            AddIf( null != (((object)this._category)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonString(this._category.ToString()) : null, "category" ,container.Add );
            AddIf( null != (((object)this._severity)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonString(this._severity.ToString()) : null, "severity" ,container.Add );
            AddIf( null != (((object)this._summaryMessage)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonString(this._summaryMessage.ToString()) : null, "summaryMessage" ,container.Add );
            AddIf( null != (((object)this._affectedResourceType)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonString(this._affectedResourceType.ToString()) : null, "affectedResourceType" ,container.Add );
            AddIf( null != (((object)this._affectedResourceSubtype)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonString(this._affectedResourceSubtype.ToString()) : null, "affectedResourceSubtype" ,container.Add );
            if (null != this._affectedResourceCorrelationId)
            {
                var __w = new Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.XNodeArray();
                foreach( var __x in this._affectedResourceCorrelationId )
                {
                    AddIf(null != (((object)__x)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonString(__x.ToString()) : null ,__w.Add);
                }
                container.Add("affectedResourceCorrelationIds",__w);
            }
            AfterToJson(ref container);
            return container;
        }
    }
}