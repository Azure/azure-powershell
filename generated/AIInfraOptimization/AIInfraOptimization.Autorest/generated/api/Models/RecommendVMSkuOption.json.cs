// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.
namespace Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models
{
    using static Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.Extensions;

    /// <summary>One ranked virtual machine size recommendation.</summary>
    public partial class RecommendVMSkuOption
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
        /// Deserializes a <see cref="Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.Json.JsonNode"/> into an instance of Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuOption.
        /// </summary>
        /// <param name="node">a <see cref="Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.Json.JsonNode" /> to deserialize from.</param>
        /// <returns>
        /// an instance of Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuOption.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuOption FromJson(Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.Json.JsonNode node)
        {
            return node is Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.Json.JsonObject json ? new RecommendVMSkuOption(json) : null;
        }

        /// <summary>
        /// Deserializes a Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.Json.JsonObject into a new instance of <see cref="RecommendVMSkuOption" />.
        /// </summary>
        /// <param name="json">A Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.Json.JsonObject instance to deserialize from.</param>
        internal RecommendVMSkuOption(Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.Json.JsonObject json)
        {
            bool returnNow = false;
            BeforeFromJson(json, ref returnNow);
            if (returnNow)
            {
                return;
            }
            {_readiness = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.Json.JsonObject>("readiness"), out var __jsonReadiness) ? Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.RecommendVMSkuReadiness.FromJson(__jsonReadiness) : _readiness;}
            {_topology = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.Json.JsonObject>("topology"), out var __jsonTopology) ? Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.RecommendVMSkuTopology.FromJson(__jsonTopology) : _topology;}
            {_cost = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.Json.JsonObject>("cost"), out var __jsonCost) ? Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.RecommendVMSkuCost.FromJson(__jsonCost) : _cost;}
            {_quota = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.Json.JsonObject>("quota"), out var __jsonQuota) ? Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.RecommendVMSkuQuota.FromJson(__jsonQuota) : _quota;}
            {_placement = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.Json.JsonObject>("placement"), out var __jsonPlacement) ? Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.RecommendVMSkuPlacement.FromJson(__jsonPlacement) : _placement;}
            {_benchmark = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.Json.JsonObject>("benchmark"), out var __jsonBenchmark) ? Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.RecommendVMSkuBenchmark.FromJson(__jsonBenchmark) : _benchmark;}
            {_performanceEstimate = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.Json.JsonObject>("performanceEstimate"), out var __jsonPerformanceEstimate) ? Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.RecommendVMSkuPerformanceEstimate.FromJson(__jsonPerformanceEstimate) : _performanceEstimate;}
            {_vMSize = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.Json.JsonString>("vmSize"), out var __jsonVMSize) ? (string)__jsonVMSize : (string)_vMSize;}
            {_recommendationRank = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.Json.JsonNumber>("recommendationRank"), out var __jsonRecommendationRank) ? (int)__jsonRecommendationRank : _recommendationRank;}
            {_azureMlRecommended = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.Json.JsonBoolean>("azureMlRecommended"), out var __jsonAzureMlRecommended) ? (bool?)__jsonAzureMlRecommended : _azureMlRecommended;}
            {_documentationUrl = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.Json.JsonString>("documentationUrl"), out var __jsonDocumentationUrl) ? (string)__jsonDocumentationUrl : (string)_documentationUrl;}
            AfterFromJson(json);
        }

        /// <summary>
        /// Serializes this instance of <see cref="RecommendVMSkuOption" /> into a <see cref="Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.Json.JsonNode" />.
        /// </summary>
        /// <param name="container">The <see cref="Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.Json.JsonObject"/> container to serialize this object into. If the caller
        /// passes in <c>null</c>, a new instance will be created and returned to the caller.</param>
        /// <param name="serializationMode">Allows the caller to choose the depth of the serialization. See <see cref="Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.SerializationMode"/>.</param>
        /// <returns>
        /// a serialized instance of <see cref="RecommendVMSkuOption" /> as a <see cref="Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.Json.JsonNode" />.
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
            AddIf( null != this._readiness ? (Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.Json.JsonNode) this._readiness.ToJson(null,serializationMode) : null, "readiness" ,container.Add );
            AddIf( null != this._topology ? (Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.Json.JsonNode) this._topology.ToJson(null,serializationMode) : null, "topology" ,container.Add );
            AddIf( null != this._cost ? (Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.Json.JsonNode) this._cost.ToJson(null,serializationMode) : null, "cost" ,container.Add );
            AddIf( null != this._quota ? (Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.Json.JsonNode) this._quota.ToJson(null,serializationMode) : null, "quota" ,container.Add );
            AddIf( null != this._placement ? (Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.Json.JsonNode) this._placement.ToJson(null,serializationMode) : null, "placement" ,container.Add );
            AddIf( null != this._benchmark ? (Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.Json.JsonNode) this._benchmark.ToJson(null,serializationMode) : null, "benchmark" ,container.Add );
            AddIf( null != this._performanceEstimate ? (Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.Json.JsonNode) this._performanceEstimate.ToJson(null,serializationMode) : null, "performanceEstimate" ,container.Add );
            AddIf( null != (((object)this._vMSize)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.Json.JsonString(this._vMSize.ToString()) : null, "vmSize" ,container.Add );
            AddIf( (Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.Json.JsonNode)new Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.Json.JsonNumber(this._recommendationRank), "recommendationRank" ,container.Add );
            AddIf( null != this._azureMlRecommended ? (Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.Json.JsonNode)new Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.Json.JsonBoolean((bool)this._azureMlRecommended) : null, "azureMlRecommended" ,container.Add );
            AddIf( null != (((object)this._documentationUrl)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.Json.JsonString(this._documentationUrl.ToString()) : null, "documentationUrl" ,container.Add );
            AfterToJson(ref container);
            return container;
        }
    }
}