// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.
namespace Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models
{
    using static Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.Extensions;

    /// <summary>
    /// The parameters used to request an Azure virtual machine size recommendation for an AI workload.
    /// </summary>
    public partial class RecommendVMSkuRequest
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
        /// Deserializes a <see cref="Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.Json.JsonNode"/> into an instance of Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuRequest.
        /// </summary>
        /// <param name="node">a <see cref="Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.Json.JsonNode" /> to deserialize from.</param>
        /// <returns>
        /// an instance of Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuRequest.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuRequest FromJson(Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.Json.JsonNode node)
        {
            return node is Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.Json.JsonObject json ? new RecommendVMSkuRequest(json) : null;
        }

        /// <summary>
        /// Deserializes a Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.Json.JsonObject into a new instance of <see cref="RecommendVMSkuRequest" />.
        /// </summary>
        /// <param name="json">A Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.Json.JsonObject instance to deserialize from.</param>
        internal RecommendVMSkuRequest(Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.Json.JsonObject json)
        {
            bool returnNow = false;
            BeforeFromJson(json, ref returnNow);
            if (returnNow)
            {
                return;
            }
            {_model = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.Json.JsonObject>("model"), out var __jsonModel) ? Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.RecommendVMSkuModel.FromJson(__jsonModel) : _model;}
            {_workload = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.Json.JsonObject>("workload"), out var __jsonWorkload) ? Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.RecommendVMSkuWorkload.FromJson(__jsonWorkload) : _workload;}
            {_deployment = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.Json.JsonObject>("deployment"), out var __jsonDeployment) ? Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.RecommendVMSkuDeployment.FromJson(__jsonDeployment) : _deployment;}
            {_optimization = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.Json.JsonObject>("optimization"), out var __jsonOptimization) ? Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.RecommendVMSkuOptimization.FromJson(__jsonOptimization) : _optimization;}
            {_subscriptionOption = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.Json.JsonObject>("subscriptionOptions"), out var __jsonSubscriptionOptions) ? Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.RecommendVMSkuSubscriptionOptions.FromJson(__jsonSubscriptionOptions) : _subscriptionOption;}
            {_targetVMSize = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.Json.JsonArray>("targetVmSizes"), out var __jsonTargetVMSizes) ? If( __jsonTargetVMSizes as Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.Json.JsonArray, out var __v) ? new global::System.Func<System.Collections.Generic.List<string>>(()=> global::System.Linq.Enumerable.ToList(global::System.Linq.Enumerable.Select(__v, (__u)=>(string) (__u is Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.Json.JsonString __t ? (string)(__t.ToString()) : null)) ))() : null : _targetVMSize;}
            AfterFromJson(json);
        }

        /// <summary>
        /// Serializes this instance of <see cref="RecommendVMSkuRequest" /> into a <see cref="Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.Json.JsonNode" />.
        /// </summary>
        /// <param name="container">The <see cref="Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.Json.JsonObject"/> container to serialize this object into. If the caller
        /// passes in <c>null</c>, a new instance will be created and returned to the caller.</param>
        /// <param name="serializationMode">Allows the caller to choose the depth of the serialization. See <see cref="Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.SerializationMode"/>.</param>
        /// <returns>
        /// a serialized instance of <see cref="RecommendVMSkuRequest" /> as a <see cref="Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.Json.JsonNode" />.
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
            AddIf( null != this._model ? (Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.Json.JsonNode) this._model.ToJson(null,serializationMode) : null, "model" ,container.Add );
            AddIf( null != this._workload ? (Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.Json.JsonNode) this._workload.ToJson(null,serializationMode) : null, "workload" ,container.Add );
            AddIf( null != this._deployment ? (Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.Json.JsonNode) this._deployment.ToJson(null,serializationMode) : null, "deployment" ,container.Add );
            AddIf( null != this._optimization ? (Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.Json.JsonNode) this._optimization.ToJson(null,serializationMode) : null, "optimization" ,container.Add );
            AddIf( null != this._subscriptionOption ? (Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.Json.JsonNode) this._subscriptionOption.ToJson(null,serializationMode) : null, "subscriptionOptions" ,container.Add );
            if (null != this._targetVMSize)
            {
                var __w = new Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.Json.XNodeArray();
                foreach( var __x in this._targetVMSize )
                {
                    AddIf(null != (((object)__x)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.Json.JsonString(__x.ToString()) : null ,__w.Add);
                }
                container.Add("targetVmSizes",__w);
            }
            AfterToJson(ref container);
            return container;
        }
    }
}