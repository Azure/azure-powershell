// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.
namespace Microsoft.Azure.PowerShell.Cmdlets.Policy.Models
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Policy.Runtime.Extensions;

    /// <summary>The external evaluation endpoint invocation results.</summary>
    public partial class ExternalEvaluationEndpointInvocationResult
    {

        /// <summary>
        /// <c>AfterFromJson</c> will be called after the json deserialization has finished, allowing customization of the object
        /// before it is returned. Implement this method in a partial class to enable this behavior
        /// </summary>
        /// <param name="json">The JsonNode that should be deserialized into this object.</param>

        partial void AfterFromJson(Microsoft.Azure.PowerShell.Cmdlets.Policy.Runtime.Json.JsonObject json);

        /// <summary>
        /// <c>AfterToJson</c> will be called after the json serialization has finished, allowing customization of the <see cref="Microsoft.Azure.PowerShell.Cmdlets.Policy.Runtime.Json.JsonObject"
        /// /> before it is returned. Implement this method in a partial class to enable this behavior
        /// </summary>
        /// <param name="container">The JSON container that the serialization result will be placed in.</param>

        partial void AfterToJson(ref Microsoft.Azure.PowerShell.Cmdlets.Policy.Runtime.Json.JsonObject container);

        /// <summary>
        /// <c>BeforeFromJson</c> will be called before the json deserialization has commenced, allowing complete customization of
        /// the object before it is deserialized.
        /// If you wish to disable the default deserialization entirely, return <c>true</c> in the <paramref name= "returnNow" />
        /// output parameter.
        /// Implement this method in a partial class to enable this behavior.
        /// </summary>
        /// <param name="json">The JsonNode that should be deserialized into this object.</param>
        /// <param name="returnNow">Determines if the rest of the deserialization should be processed, or if the method should return
        /// instantly.</param>

        partial void BeforeFromJson(Microsoft.Azure.PowerShell.Cmdlets.Policy.Runtime.Json.JsonObject json, ref bool returnNow);

        /// <summary>
        /// <c>BeforeToJson</c> will be called before the json serialization has commenced, allowing complete customization of the
        /// object before it is serialized.
        /// If you wish to disable the default serialization entirely, return <c>true</c> in the <paramref name="returnNow" /> output
        /// parameter.
        /// Implement this method in a partial class to enable this behavior.
        /// </summary>
        /// <param name="container">The JSON container that the serialization result will be placed in.</param>
        /// <param name="returnNow">Determines if the rest of the serialization should be processed, or if the method should return
        /// instantly.</param>

        partial void BeforeToJson(ref Microsoft.Azure.PowerShell.Cmdlets.Policy.Runtime.Json.JsonObject container, ref bool returnNow);

        /// <summary>
        /// Deserializes a Microsoft.Azure.PowerShell.Cmdlets.Policy.Runtime.Json.JsonObject into a new instance of <see cref="ExternalEvaluationEndpointInvocationResult" />.
        /// </summary>
        /// <param name="json">A Microsoft.Azure.PowerShell.Cmdlets.Policy.Runtime.Json.JsonObject instance to deserialize from.</param>
        internal ExternalEvaluationEndpointInvocationResult(Microsoft.Azure.PowerShell.Cmdlets.Policy.Runtime.Json.JsonObject json)
        {
            bool returnNow = false;
            BeforeFromJson(json, ref returnNow);
            if (returnNow)
            {
                return;
            }
            {_policyInfo = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Policy.Runtime.Json.JsonObject>("policyInfo"), out var __jsonPolicyInfo) ? Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.PolicyLogInfo.FromJson(__jsonPolicyInfo) : _policyInfo;}
            {_result = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Policy.Runtime.Json.JsonString>("result"), out var __jsonResult) ? (string)__jsonResult : (string)_result;}
            {_endpointKind = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Policy.Runtime.Json.JsonString>("endpointKind"), out var __jsonEndpointKind) ? (string)__jsonEndpointKind : (string)_endpointKind;}
            {_message = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Policy.Runtime.Json.JsonString>("message"), out var __jsonMessage) ? (string)__jsonMessage : (string)_message;}
            {_retryAfter = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Policy.Runtime.Json.JsonString>("retryAfter"), out var __jsonRetryAfter) ? global::System.DateTime.TryParse((string)__jsonRetryAfter, global::System.Globalization.CultureInfo.InvariantCulture, global::System.Globalization.DateTimeStyles.AdjustToUniversal, out var __jsonRetryAfterValue) ? __jsonRetryAfterValue : _retryAfter : _retryAfter;}
            {_claim = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Policy.Runtime.Json.JsonObject>("claims"), out var __jsonClaims) ? Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.Any.FromJson(__jsonClaims) : _claim;}
            {_policyAction = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Policy.Runtime.Json.JsonString>("policyAction"), out var __jsonPolicyAction) ? (string)__jsonPolicyAction : (string)_policyAction;}
            {_policyEvaluationDetail = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Policy.Runtime.Json.JsonObject>("policyEvaluationDetails"), out var __jsonPolicyEvaluationDetails) ? Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.Any.FromJson(__jsonPolicyEvaluationDetails) : _policyEvaluationDetail;}
            {_additionalInfo = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Policy.Runtime.Json.JsonObject>("additionalInfo"), out var __jsonAdditionalInfo) ? Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.Any.FromJson(__jsonAdditionalInfo) : _additionalInfo;}
            {_expiration = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Policy.Runtime.Json.JsonString>("expiration"), out var __jsonExpiration) ? global::System.DateTime.TryParse((string)__jsonExpiration, global::System.Globalization.CultureInfo.InvariantCulture, global::System.Globalization.DateTimeStyles.AdjustToUniversal, out var __jsonExpirationValue) ? __jsonExpirationValue : _expiration : _expiration;}
            AfterFromJson(json);
        }

        /// <summary>
        /// Deserializes a <see cref="Microsoft.Azure.PowerShell.Cmdlets.Policy.Runtime.Json.JsonNode"/> into an instance of Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IExternalEvaluationEndpointInvocationResult.
        /// </summary>
        /// <param name="node">a <see cref="Microsoft.Azure.PowerShell.Cmdlets.Policy.Runtime.Json.JsonNode" /> to deserialize from.</param>
        /// <returns>
        /// an instance of Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IExternalEvaluationEndpointInvocationResult.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IExternalEvaluationEndpointInvocationResult FromJson(Microsoft.Azure.PowerShell.Cmdlets.Policy.Runtime.Json.JsonNode node)
        {
            return node is Microsoft.Azure.PowerShell.Cmdlets.Policy.Runtime.Json.JsonObject json ? new ExternalEvaluationEndpointInvocationResult(json) : null;
        }

        /// <summary>
        /// Serializes this instance of <see cref="ExternalEvaluationEndpointInvocationResult" /> into a <see cref="Microsoft.Azure.PowerShell.Cmdlets.Policy.Runtime.Json.JsonNode"
        /// />.
        /// </summary>
        /// <param name="container">The <see cref="Microsoft.Azure.PowerShell.Cmdlets.Policy.Runtime.Json.JsonObject"/> container to serialize this object into. If the caller
        /// passes in <c>null</c>, a new instance will be created and returned to the caller.</param>
        /// <param name="serializationMode">Allows the caller to choose the depth of the serialization. See <see cref="Microsoft.Azure.PowerShell.Cmdlets.Policy.Runtime.SerializationMode"/>.</param>
        /// <returns>
        /// a serialized instance of <see cref="ExternalEvaluationEndpointInvocationResult" /> as a <see cref="Microsoft.Azure.PowerShell.Cmdlets.Policy.Runtime.Json.JsonNode"
        /// />.
        /// </returns>
        public Microsoft.Azure.PowerShell.Cmdlets.Policy.Runtime.Json.JsonNode ToJson(Microsoft.Azure.PowerShell.Cmdlets.Policy.Runtime.Json.JsonObject container, Microsoft.Azure.PowerShell.Cmdlets.Policy.Runtime.SerializationMode serializationMode)
        {
            container = container ?? new Microsoft.Azure.PowerShell.Cmdlets.Policy.Runtime.Json.JsonObject();

            bool returnNow = false;
            BeforeToJson(ref container, ref returnNow);
            if (returnNow)
            {
                return container;
            }
            AddIf( null != this._policyInfo ? (Microsoft.Azure.PowerShell.Cmdlets.Policy.Runtime.Json.JsonNode) this._policyInfo.ToJson(null,serializationMode) : null, "policyInfo" ,container.Add );
            AddIf( null != (((object)this._result)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.Policy.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Policy.Runtime.Json.JsonString(this._result.ToString()) : null, "result" ,container.Add );
            AddIf( null != (((object)this._endpointKind)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.Policy.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Policy.Runtime.Json.JsonString(this._endpointKind.ToString()) : null, "endpointKind" ,container.Add );
            AddIf( null != (((object)this._message)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.Policy.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Policy.Runtime.Json.JsonString(this._message.ToString()) : null, "message" ,container.Add );
            AddIf( null != this._retryAfter ? (Microsoft.Azure.PowerShell.Cmdlets.Policy.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Policy.Runtime.Json.JsonString(this._retryAfter?.ToString(@"yyyy'-'MM'-'dd'T'HH':'mm':'ss.fffffffK",global::System.Globalization.CultureInfo.InvariantCulture)) : null, "retryAfter" ,container.Add );
            AddIf( null != this._claim ? (Microsoft.Azure.PowerShell.Cmdlets.Policy.Runtime.Json.JsonNode) this._claim.ToJson(null,serializationMode) : null, "claims" ,container.Add );
            AddIf( null != (((object)this._policyAction)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.Policy.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Policy.Runtime.Json.JsonString(this._policyAction.ToString()) : null, "policyAction" ,container.Add );
            AddIf( null != this._policyEvaluationDetail ? (Microsoft.Azure.PowerShell.Cmdlets.Policy.Runtime.Json.JsonNode) this._policyEvaluationDetail.ToJson(null,serializationMode) : null, "policyEvaluationDetails" ,container.Add );
            AddIf( null != this._additionalInfo ? (Microsoft.Azure.PowerShell.Cmdlets.Policy.Runtime.Json.JsonNode) this._additionalInfo.ToJson(null,serializationMode) : null, "additionalInfo" ,container.Add );
            AddIf( null != this._expiration ? (Microsoft.Azure.PowerShell.Cmdlets.Policy.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Policy.Runtime.Json.JsonString(this._expiration?.ToString(@"yyyy'-'MM'-'dd'T'HH':'mm':'ss.fffffffK",global::System.Globalization.CultureInfo.InvariantCulture)) : null, "expiration" ,container.Add );
            AfterToJson(ref container);
            return container;
        }
    }
}