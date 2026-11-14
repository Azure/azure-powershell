// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.
namespace Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models
{
    using static Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.Extensions;

    /// <summary>Model inputs used for metadata resolution and memory sizing.</summary>
    public partial class RecommendVMSkuModel
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
        /// Deserializes a <see cref="Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.Json.JsonNode"/> into an instance of Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuModel.
        /// </summary>
        /// <param name="node">a <see cref="Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.Json.JsonNode" /> to deserialize from.</param>
        /// <returns>
        /// an instance of Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuModel.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuModel FromJson(Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.Json.JsonNode node)
        {
            return node is Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.Json.JsonObject json ? new RecommendVMSkuModel(json) : null;
        }

        /// <summary>
        /// Deserializes a Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.Json.JsonObject into a new instance of <see cref="RecommendVMSkuModel" />.
        /// </summary>
        /// <param name="json">A Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.Json.JsonObject instance to deserialize from.</param>
        internal RecommendVMSkuModel(Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.Json.JsonObject json)
        {
            bool returnNow = false;
            BeforeFromJson(json, ref returnNow);
            if (returnNow)
            {
                return;
            }
            {_huggingFaceModelId = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.Json.JsonString>("huggingFaceModelId"), out var __jsonHuggingFaceModelId) ? (string)__jsonHuggingFaceModelId : (string)_huggingFaceModelId;}
            {_parameterCount = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.Json.JsonNumber>("parameterCount"), out var __jsonParameterCount) ? (long?)__jsonParameterCount : _parameterCount;}
            {_weightPrecision = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.Json.JsonString>("weightPrecision"), out var __jsonWeightPrecision) ? (string)__jsonWeightPrecision : (string)_weightPrecision;}
            {_numLayer = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.Json.JsonNumber>("numLayers"), out var __jsonNumLayers) ? (int?)__jsonNumLayers : _numLayer;}
            {_numKeyValueHead = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.Json.JsonNumber>("numKeyValueHeads"), out var __jsonNumKeyValueHeads) ? (int?)__jsonNumKeyValueHeads : _numKeyValueHead;}
            {_headDim = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.Json.JsonNumber>("headDim"), out var __jsonHeadDim) ? (int?)__jsonHeadDim : _headDim;}
            {_maxContextLength = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.Json.JsonNumber>("maxContextLength"), out var __jsonMaxContextLength) ? (int?)__jsonMaxContextLength : _maxContextLength;}
            AfterFromJson(json);
        }

        /// <summary>
        /// Serializes this instance of <see cref="RecommendVMSkuModel" /> into a <see cref="Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.Json.JsonNode" />.
        /// </summary>
        /// <param name="container">The <see cref="Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.Json.JsonObject"/> container to serialize this object into. If the caller
        /// passes in <c>null</c>, a new instance will be created and returned to the caller.</param>
        /// <param name="serializationMode">Allows the caller to choose the depth of the serialization. See <see cref="Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.SerializationMode"/>.</param>
        /// <returns>
        /// a serialized instance of <see cref="RecommendVMSkuModel" /> as a <see cref="Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.Json.JsonNode" />.
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
            AddIf( null != (((object)this._huggingFaceModelId)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.Json.JsonString(this._huggingFaceModelId.ToString()) : null, "huggingFaceModelId" ,container.Add );
            AddIf( null != this._parameterCount ? (Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.Json.JsonNode)new Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.Json.JsonNumber((long)this._parameterCount) : null, "parameterCount" ,container.Add );
            AddIf( null != (((object)this._weightPrecision)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.Json.JsonString(this._weightPrecision.ToString()) : null, "weightPrecision" ,container.Add );
            AddIf( null != this._numLayer ? (Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.Json.JsonNode)new Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.Json.JsonNumber((int)this._numLayer) : null, "numLayers" ,container.Add );
            AddIf( null != this._numKeyValueHead ? (Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.Json.JsonNode)new Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.Json.JsonNumber((int)this._numKeyValueHead) : null, "numKeyValueHeads" ,container.Add );
            AddIf( null != this._headDim ? (Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.Json.JsonNode)new Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.Json.JsonNumber((int)this._headDim) : null, "headDim" ,container.Add );
            AddIf( null != this._maxContextLength ? (Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.Json.JsonNode)new Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.Json.JsonNumber((int)this._maxContextLength) : null, "maxContextLength" ,container.Add );
            AfterToJson(ref container);
            return container;
        }
    }
}