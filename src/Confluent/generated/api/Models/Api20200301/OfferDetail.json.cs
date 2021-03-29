namespace Microsoft.Azure.PowerShell.Cmdlets.Confluent.Models.Api20200301
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Confluent.Runtime.Extensions;

    /// <summary>Confluent Offer detail</summary>
    public partial class OfferDetail
    {

        /// <summary>
        /// <c>AfterFromJson</c> will be called after the json deserialization has finished, allowing customization of the object
        /// before it is returned. Implement this method in a partial class to enable this behavior
        /// </summary>
        /// <param name="json">The JsonNode that should be deserialized into this object.</param>

        partial void AfterFromJson(Microsoft.Azure.PowerShell.Cmdlets.Confluent.Runtime.Json.JsonObject json);

        /// <summary>
        /// <c>AfterToJson</c> will be called after the json erialization has finished, allowing customization of the <see cref="Microsoft.Azure.PowerShell.Cmdlets.Confluent.Runtime.Json.JsonObject"
        /// /> before it is returned. Implement this method in a partial class to enable this behavior
        /// </summary>
        /// <param name="container">The JSON container that the serialization result will be placed in.</param>

        partial void AfterToJson(ref Microsoft.Azure.PowerShell.Cmdlets.Confluent.Runtime.Json.JsonObject container);

        /// <summary>
        /// <c>BeforeFromJson</c> will be called before the json deserialization has commenced, allowing complete customization of
        /// the object before it is deserialized.
        /// If you wish to disable the default deserialization entirely, return <c>true</c> in the <see "returnNow" /> output parameter.
        /// Implement this method in a partial class to enable this behavior.
        /// </summary>
        /// <param name="json">The JsonNode that should be deserialized into this object.</param>
        /// <param name="returnNow">Determines if the rest of the deserialization should be processed, or if the method should return
        /// instantly.</param>

        partial void BeforeFromJson(Microsoft.Azure.PowerShell.Cmdlets.Confluent.Runtime.Json.JsonObject json, ref bool returnNow);

        /// <summary>
        /// <c>BeforeToJson</c> will be called before the json serialization has commenced, allowing complete customization of the
        /// object before it is serialized.
        /// If you wish to disable the default serialization entirely, return <c>true</c> in the <see "returnNow" /> output parameter.
        /// Implement this method in a partial class to enable this behavior.
        /// </summary>
        /// <param name="container">The JSON container that the serialization result will be placed in.</param>
        /// <param name="returnNow">Determines if the rest of the serialization should be processed, or if the method should return
        /// instantly.</param>

        partial void BeforeToJson(ref Microsoft.Azure.PowerShell.Cmdlets.Confluent.Runtime.Json.JsonObject container, ref bool returnNow);

        /// <summary>
        /// Deserializes a <see cref="Microsoft.Azure.PowerShell.Cmdlets.Confluent.Runtime.Json.JsonNode"/> into an instance of Microsoft.Azure.PowerShell.Cmdlets.Confluent.Models.Api20200301.IOfferDetail.
        /// </summary>
        /// <param name="node">a <see cref="Microsoft.Azure.PowerShell.Cmdlets.Confluent.Runtime.Json.JsonNode" /> to deserialize from.</param>
        /// <returns>
        /// an instance of Microsoft.Azure.PowerShell.Cmdlets.Confluent.Models.Api20200301.IOfferDetail.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Confluent.Models.Api20200301.IOfferDetail FromJson(Microsoft.Azure.PowerShell.Cmdlets.Confluent.Runtime.Json.JsonNode node)
        {
            return node is Microsoft.Azure.PowerShell.Cmdlets.Confluent.Runtime.Json.JsonObject json ? new OfferDetail(json) : null;
        }

        /// <summary>
        /// Deserializes a Microsoft.Azure.PowerShell.Cmdlets.Confluent.Runtime.Json.JsonObject into a new instance of <see cref="OfferDetail" />.
        /// </summary>
        /// <param name="json">A Microsoft.Azure.PowerShell.Cmdlets.Confluent.Runtime.Json.JsonObject instance to deserialize from.</param>
        internal OfferDetail(Microsoft.Azure.PowerShell.Cmdlets.Confluent.Runtime.Json.JsonObject json)
        {
            bool returnNow = false;
            BeforeFromJson(json, ref returnNow);
            if (returnNow)
            {
                return;
            }
            {_publisherId = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Confluent.Runtime.Json.JsonString>("publisherId"), out var __jsonPublisherId) ? (string)__jsonPublisherId : (string)PublisherId;}
            {_id = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Confluent.Runtime.Json.JsonString>("id"), out var __jsonId) ? (string)__jsonId : (string)Id;}
            {_planId = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Confluent.Runtime.Json.JsonString>("planId"), out var __jsonPlanId) ? (string)__jsonPlanId : (string)PlanId;}
            {_planName = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Confluent.Runtime.Json.JsonString>("planName"), out var __jsonPlanName) ? (string)__jsonPlanName : (string)PlanName;}
            {_termUnit = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Confluent.Runtime.Json.JsonString>("termUnit"), out var __jsonTermUnit) ? (string)__jsonTermUnit : (string)TermUnit;}
            {_status = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Confluent.Runtime.Json.JsonString>("status"), out var __jsonStatus) ? (string)__jsonStatus : (string)Status;}
            AfterFromJson(json);
        }

        /// <summary>
        /// Serializes this instance of <see cref="OfferDetail" /> into a <see cref="Microsoft.Azure.PowerShell.Cmdlets.Confluent.Runtime.Json.JsonNode" />.
        /// </summary>
        /// <param name="container">The <see cref="Microsoft.Azure.PowerShell.Cmdlets.Confluent.Runtime.Json.JsonObject"/> container to serialize this object into. If the caller
        /// passes in <c>null</c>, a new instance will be created and returned to the caller.</param>
        /// <param name="serializationMode">Allows the caller to choose the depth of the serialization. See <see cref="Microsoft.Azure.PowerShell.Cmdlets.Confluent.Runtime.SerializationMode"/>.</param>
        /// <returns>
        /// a serialized instance of <see cref="OfferDetail" /> as a <see cref="Microsoft.Azure.PowerShell.Cmdlets.Confluent.Runtime.Json.JsonNode" />.
        /// </returns>
        public Microsoft.Azure.PowerShell.Cmdlets.Confluent.Runtime.Json.JsonNode ToJson(Microsoft.Azure.PowerShell.Cmdlets.Confluent.Runtime.Json.JsonObject container, Microsoft.Azure.PowerShell.Cmdlets.Confluent.Runtime.SerializationMode serializationMode)
        {
            container = container ?? new Microsoft.Azure.PowerShell.Cmdlets.Confluent.Runtime.Json.JsonObject();

            bool returnNow = false;
            BeforeToJson(ref container, ref returnNow);
            if (returnNow)
            {
                return container;
            }
            AddIf( null != (((object)this._publisherId)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.Confluent.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Confluent.Runtime.Json.JsonString(this._publisherId.ToString()) : null, "publisherId" ,container.Add );
            AddIf( null != (((object)this._id)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.Confluent.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Confluent.Runtime.Json.JsonString(this._id.ToString()) : null, "id" ,container.Add );
            AddIf( null != (((object)this._planId)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.Confluent.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Confluent.Runtime.Json.JsonString(this._planId.ToString()) : null, "planId" ,container.Add );
            AddIf( null != (((object)this._planName)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.Confluent.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Confluent.Runtime.Json.JsonString(this._planName.ToString()) : null, "planName" ,container.Add );
            AddIf( null != (((object)this._termUnit)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.Confluent.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Confluent.Runtime.Json.JsonString(this._termUnit.ToString()) : null, "termUnit" ,container.Add );
            AddIf( null != (((object)this._status)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.Confluent.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Confluent.Runtime.Json.JsonString(this._status.ToString()) : null, "status" ,container.Add );
            AfterToJson(ref container);
            return container;
        }
    }
}