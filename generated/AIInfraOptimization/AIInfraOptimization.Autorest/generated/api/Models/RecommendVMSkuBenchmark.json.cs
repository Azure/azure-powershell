// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.
namespace Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models
{
    using static Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.Extensions;

    /// <summary>The external benchmark evidence selected for one virtual machine size option.</summary>
    public partial class RecommendVMSkuBenchmark
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
        /// Deserializes a <see cref="Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.Json.JsonNode"/> into an instance of Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuBenchmark.
        /// </summary>
        /// <param name="node">a <see cref="Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.Json.JsonNode" /> to deserialize from.</param>
        /// <returns>
        /// an instance of Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuBenchmark.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuBenchmark FromJson(Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.Json.JsonNode node)
        {
            return node is Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.Json.JsonObject json ? new RecommendVMSkuBenchmark(json) : null;
        }

        /// <summary>
        /// Deserializes a Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.Json.JsonObject into a new instance of <see cref="RecommendVMSkuBenchmark" />.
        /// </summary>
        /// <param name="json">A Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.Json.JsonObject instance to deserialize from.</param>
        internal RecommendVMSkuBenchmark(Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.Json.JsonObject json)
        {
            bool returnNow = false;
            BeforeFromJson(json, ref returnNow);
            if (returnNow)
            {
                return;
            }
            {_level = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.Json.JsonString>("level"), out var __jsonLevel) ? (string)__jsonLevel : (string)_level;}
            {_modelClass = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.Json.JsonString>("modelClass"), out var __jsonModelClass) ? (string)__jsonModelClass : (string)_modelClass;}
            {_scenario = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.Json.JsonString>("scenario"), out var __jsonScenario) ? (string)__jsonScenario : (string)_scenario;}
            {_submitterCount = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.Json.JsonNumber>("submitterCount"), out var __jsonSubmitterCount) ? (int)__jsonSubmitterCount : _submitterCount;}
            {_submissionId = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.Json.JsonString>("submissionId"), out var __jsonSubmissionId) ? (string)__jsonSubmissionId : (string)_submissionId;}
            {_benchmarkModel = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.Json.JsonString>("benchmarkModel"), out var __jsonBenchmarkModel) ? (string)__jsonBenchmarkModel : (string)_benchmarkModel;}
            {_submitter = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.Json.JsonString>("submitter"), out var __jsonSubmitter) ? (string)__jsonSubmitter : (string)_submitter;}
            {_system = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.Json.JsonString>("system"), out var __jsonSystem) ? (string)__jsonSystem : (string)_system;}
            {_throughput = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.Json.JsonNumber>("throughput"), out var __jsonThroughput) ? (double?)__jsonThroughput : _throughput;}
            {_throughputUnit = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.Json.JsonString>("throughputUnit"), out var __jsonThroughputUnit) ? (string)__jsonThroughputUnit : (string)_throughputUnit;}
            {_software = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.Json.JsonString>("software"), out var __jsonSoftware) ? (string)__jsonSoftware : (string)_software;}
            {_operatingSystem = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.Json.JsonString>("operatingSystem"), out var __jsonOperatingSystem) ? (string)__jsonOperatingSystem : (string)_operatingSystem;}
            {_weightDataType = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.Json.JsonString>("weightDataTypes"), out var __jsonWeightDataTypes) ? (string)__jsonWeightDataTypes : (string)_weightDataType;}
            {_p99TtftMS = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.Json.JsonNumber>("p99TtftMs"), out var __jsonP99TtftMS) ? (double?)__jsonP99TtftMS : _p99TtftMS;}
            {_p99TpotMS = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.Json.JsonNumber>("p99TpotMs"), out var __jsonP99TpotMS) ? (double?)__jsonP99TpotMS : _p99TpotMS;}
            AfterFromJson(json);
        }

        /// <summary>
        /// Serializes this instance of <see cref="RecommendVMSkuBenchmark" /> into a <see cref="Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.Json.JsonNode" />.
        /// </summary>
        /// <param name="container">The <see cref="Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.Json.JsonObject"/> container to serialize this object into. If the caller
        /// passes in <c>null</c>, a new instance will be created and returned to the caller.</param>
        /// <param name="serializationMode">Allows the caller to choose the depth of the serialization. See <see cref="Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.SerializationMode"/>.</param>
        /// <returns>
        /// a serialized instance of <see cref="RecommendVMSkuBenchmark" /> as a <see cref="Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.Json.JsonNode" />.
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
            AddIf( null != (((object)this._level)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.Json.JsonString(this._level.ToString()) : null, "level" ,container.Add );
            AddIf( null != (((object)this._modelClass)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.Json.JsonString(this._modelClass.ToString()) : null, "modelClass" ,container.Add );
            AddIf( null != (((object)this._scenario)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.Json.JsonString(this._scenario.ToString()) : null, "scenario" ,container.Add );
            AddIf( (Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.Json.JsonNode)new Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.Json.JsonNumber(this._submitterCount), "submitterCount" ,container.Add );
            AddIf( null != (((object)this._submissionId)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.Json.JsonString(this._submissionId.ToString()) : null, "submissionId" ,container.Add );
            AddIf( null != (((object)this._benchmarkModel)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.Json.JsonString(this._benchmarkModel.ToString()) : null, "benchmarkModel" ,container.Add );
            AddIf( null != (((object)this._submitter)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.Json.JsonString(this._submitter.ToString()) : null, "submitter" ,container.Add );
            AddIf( null != (((object)this._system)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.Json.JsonString(this._system.ToString()) : null, "system" ,container.Add );
            AddIf( null != this._throughput ? (Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.Json.JsonNode)new Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.Json.JsonNumber((double)this._throughput) : null, "throughput" ,container.Add );
            AddIf( null != (((object)this._throughputUnit)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.Json.JsonString(this._throughputUnit.ToString()) : null, "throughputUnit" ,container.Add );
            AddIf( null != (((object)this._software)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.Json.JsonString(this._software.ToString()) : null, "software" ,container.Add );
            AddIf( null != (((object)this._operatingSystem)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.Json.JsonString(this._operatingSystem.ToString()) : null, "operatingSystem" ,container.Add );
            AddIf( null != (((object)this._weightDataType)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.Json.JsonString(this._weightDataType.ToString()) : null, "weightDataTypes" ,container.Add );
            AddIf( null != this._p99TtftMS ? (Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.Json.JsonNode)new Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.Json.JsonNumber((double)this._p99TtftMS) : null, "p99TtftMs" ,container.Add );
            AddIf( null != this._p99TpotMS ? (Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.Json.JsonNode)new Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.Json.JsonNumber((double)this._p99TpotMS) : null, "p99TpotMs" ,container.Add );
            AfterToJson(ref container);
            return container;
        }
    }
}