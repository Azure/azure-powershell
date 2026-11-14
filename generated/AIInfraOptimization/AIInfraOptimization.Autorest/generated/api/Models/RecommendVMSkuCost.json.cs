// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.
namespace Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models
{
    using static Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.Extensions;

    /// <summary>The deployment cost for one virtual machine size option.</summary>
    public partial class RecommendVMSkuCost
    {

        /// <summary>
        /// <c>AfterFromJson</c> will be called after the json deserialization has finished, allowing customization of the object
        /// before it is returned. Implement this method in a partial class to enable this behavior
        /// </summary>
        /// <param name="json">The JsonNode that should be deserialized into this object.</param>

        partial void AfterFromJson(Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.Json.JsonObject json);

        /// <summary>
        /// <c>AfterToJson</c> will be called after the json serialization has finished, allowing customization of the <see cref="Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.Json.JsonObject"
        /// /> before it is returned. Implement this method in a partial class to enable this behavior
        /// </summary>
        /// <param name="container">The JSON container that the serialization result will be placed in.</param>

        partial void AfterToJson(ref Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.Json.JsonObject container);

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

        partial void BeforeFromJson(Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.Json.JsonObject json, ref bool returnNow);

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

        partial void BeforeToJson(ref Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.Json.JsonObject container, ref bool returnNow);

        /// <summary>
        /// Deserializes a <see cref="Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.Json.JsonNode"/> into an instance of Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuCost.
        /// </summary>
        /// <param name="node">a <see cref="Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.Json.JsonNode" /> to deserialize from.</param>
        /// <returns>
        /// an instance of Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuCost.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuCost FromJson(Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.Json.JsonNode node)
        {
            return node is Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.Json.JsonObject json ? new RecommendVMSkuCost(json) : null;
        }

        /// <summary>
        /// Deserializes a Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.Json.JsonObject into a new instance of <see cref="RecommendVMSkuCost" />.
        /// </summary>
        /// <param name="json">A Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.Json.JsonObject instance to deserialize from.</param>
        internal RecommendVMSkuCost(Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.Json.JsonObject json)
        {
            bool returnNow = false;
            BeforeFromJson(json, ref returnNow);
            if (returnNow)
            {
                return;
            }
            {_error = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.Json.JsonObject>("error"), out var __jsonError) ? Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.RecommendVMSkuStageError.FromJson(__jsonError) : _error;}
            {_currencyCode = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.Json.JsonString>("currencyCode"), out var __jsonCurrencyCode) ? (string)__jsonCurrencyCode : (string)_currencyCode;}
            {_vMHourly = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.Json.JsonNumber>("vmHourly"), out var __jsonVMHourly) ? (double)__jsonVMHourly : _vMHourly;}
            {_deploymentHourly = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.Json.JsonNumber>("deploymentHourly"), out var __jsonDeploymentHourly) ? (double)__jsonDeploymentHourly : _deploymentHourly;}
            {_source = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.Json.JsonString>("source"), out var __jsonSource) ? (string)__jsonSource : (string)_source;}
            {_priceAsOf = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.Json.JsonString>("priceAsOf"), out var __jsonPriceAsOf) ? global::System.DateTime.TryParse((string)__jsonPriceAsOf, global::System.Globalization.CultureInfo.InvariantCulture, global::System.Globalization.DateTimeStyles.AdjustToUniversal, out var __jsonPriceAsOfValue) ? __jsonPriceAsOfValue : _priceAsOf : _priceAsOf;}
            AfterFromJson(json);
        }

        /// <summary>
        /// Serializes this instance of <see cref="RecommendVMSkuCost" /> into a <see cref="Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.Json.JsonNode" />.
        /// </summary>
        /// <param name="container">The <see cref="Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.Json.JsonObject"/> container to serialize this object into. If the caller
        /// passes in <c>null</c>, a new instance will be created and returned to the caller.</param>
        /// <param name="serializationMode">Allows the caller to choose the depth of the serialization. See <see cref="Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.SerializationMode"/>.</param>
        /// <returns>
        /// a serialized instance of <see cref="RecommendVMSkuCost" /> as a <see cref="Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.Json.JsonNode" />.
        /// </returns>
        public Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.Json.JsonNode ToJson(Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.Json.JsonObject container, Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.SerializationMode serializationMode)
        {
            container = container ?? new Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.Json.JsonObject();

            bool returnNow = false;
            BeforeToJson(ref container, ref returnNow);
            if (returnNow)
            {
                return container;
            }
            AddIf( null != this._error ? (Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.Json.JsonNode) this._error.ToJson(null,serializationMode) : null, "error" ,container.Add );
            AddIf( null != (((object)this._currencyCode)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.Json.JsonString(this._currencyCode.ToString()) : null, "currencyCode" ,container.Add );
            AddIf( (Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.Json.JsonNode)new Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.Json.JsonNumber(this._vMHourly), "vmHourly" ,container.Add );
            AddIf( (Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.Json.JsonNode)new Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.Json.JsonNumber(this._deploymentHourly), "deploymentHourly" ,container.Add );
            AddIf( null != (((object)this._source)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.Json.JsonString(this._source.ToString()) : null, "source" ,container.Add );
            AddIf( null != this._priceAsOf ? (Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.Json.JsonString(this._priceAsOf?.ToString(@"yyyy'-'MM'-'dd'T'HH':'mm':'ss.fffffffK",global::System.Globalization.CultureInfo.InvariantCulture)) : null, "priceAsOf" ,container.Add );
            AfterToJson(ref container);
            return container;
        }
    }
}