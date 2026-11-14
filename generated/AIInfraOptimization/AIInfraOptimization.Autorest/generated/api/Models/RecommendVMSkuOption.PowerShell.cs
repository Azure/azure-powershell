// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.
namespace Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models
{
    using Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.PowerShell;

    /// <summary>One ranked virtual machine size recommendation.</summary>
    [System.ComponentModel.TypeConverter(typeof(RecommendVMSkuOptionTypeConverter))]
    public partial class RecommendVMSkuOption
    {

        /// <summary>
        /// <c>AfterDeserializeDictionary</c> will be called after the deserialization has finished, allowing customization of the
        /// object before it is returned. Implement this method in a partial class to enable this behavior
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>

        partial void AfterDeserializeDictionary(global::System.Collections.IDictionary content);

        /// <summary>
        /// <c>AfterDeserializePSObject</c> will be called after the deserialization has finished, allowing customization of the object
        /// before it is returned. Implement this method in a partial class to enable this behavior
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>

        partial void AfterDeserializePSObject(global::System.Management.Automation.PSObject content);

        /// <summary>
        /// <c>BeforeDeserializeDictionary</c> will be called before the deserialization has commenced, allowing complete customization
        /// of the object before it is deserialized.
        /// If you wish to disable the default deserialization entirely, return <c>true</c> in the <paramref name="returnNow" /> output
        /// parameter.
        /// Implement this method in a partial class to enable this behavior.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        /// <param name="returnNow">Determines if the rest of the serialization should be processed, or if the method should return
        /// instantly.</param>

        partial void BeforeDeserializeDictionary(global::System.Collections.IDictionary content, ref bool returnNow);

        /// <summary>
        /// <c>BeforeDeserializePSObject</c> will be called before the deserialization has commenced, allowing complete customization
        /// of the object before it is deserialized.
        /// If you wish to disable the default deserialization entirely, return <c>true</c> in the <paramref name="returnNow" /> output
        /// parameter.
        /// Implement this method in a partial class to enable this behavior.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        /// <param name="returnNow">Determines if the rest of the serialization should be processed, or if the method should return
        /// instantly.</param>

        partial void BeforeDeserializePSObject(global::System.Management.Automation.PSObject content, ref bool returnNow);

        /// <summary>
        /// <c>OverrideToString</c> will be called if it is implemented. Implement this method in a partial class to enable this behavior
        /// </summary>
        /// <param name="stringResult">/// instance serialized to a string, normally it is a Json</param>
        /// <param name="returnNow">/// set returnNow to true if you provide a customized OverrideToString function</param>

        partial void OverrideToString(ref string stringResult, ref bool returnNow);

        /// <summary>
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.RecommendVMSkuOption"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuOption" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuOption DeserializeFromDictionary(global::System.Collections.IDictionary content)
        {
            return new RecommendVMSkuOption(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.RecommendVMSkuOption"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuOption" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuOption DeserializeFromPSObject(global::System.Management.Automation.PSObject content)
        {
            return new RecommendVMSkuOption(content);
        }

        /// <summary>
        /// Creates a new instance of <see cref="RecommendVMSkuOption" />, deserializing the content from a json string.
        /// </summary>
        /// <param name="jsonText">a string containing a JSON serialized instance of this model.</param>
        /// <returns>an instance of the <see cref="RecommendVMSkuOption" /> model class.</returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuOption FromJsonString(string jsonText) => FromJson(Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.Json.JsonNode.Parse(jsonText));

        /// <summary>
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.RecommendVMSkuOption"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        internal RecommendVMSkuOption(global::System.Collections.IDictionary content)
        {
            bool returnNow = false;
            BeforeDeserializeDictionary(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            if (content.Contains("Readiness"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuOptionInternal)this).Readiness = (Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuReadiness) content.GetValueForProperty("Readiness",((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuOptionInternal)this).Readiness, Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.RecommendVMSkuReadinessTypeConverter.ConvertFrom);
            }
            if (content.Contains("Topology"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuOptionInternal)this).Topology = (Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuTopology) content.GetValueForProperty("Topology",((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuOptionInternal)this).Topology, Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.RecommendVMSkuTopologyTypeConverter.ConvertFrom);
            }
            if (content.Contains("Cost"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuOptionInternal)this).Cost = (Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuCost) content.GetValueForProperty("Cost",((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuOptionInternal)this).Cost, Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.RecommendVMSkuCostTypeConverter.ConvertFrom);
            }
            if (content.Contains("Quota"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuOptionInternal)this).Quota = (Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuQuota) content.GetValueForProperty("Quota",((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuOptionInternal)this).Quota, Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.RecommendVMSkuQuotaTypeConverter.ConvertFrom);
            }
            if (content.Contains("Placement"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuOptionInternal)this).Placement = (Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuPlacement) content.GetValueForProperty("Placement",((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuOptionInternal)this).Placement, Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.RecommendVMSkuPlacementTypeConverter.ConvertFrom);
            }
            if (content.Contains("Benchmark"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuOptionInternal)this).Benchmark = (Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuBenchmark) content.GetValueForProperty("Benchmark",((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuOptionInternal)this).Benchmark, Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.RecommendVMSkuBenchmarkTypeConverter.ConvertFrom);
            }
            if (content.Contains("PerformanceEstimate"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuOptionInternal)this).PerformanceEstimate = (Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuPerformanceEstimate) content.GetValueForProperty("PerformanceEstimate",((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuOptionInternal)this).PerformanceEstimate, Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.RecommendVMSkuPerformanceEstimateTypeConverter.ConvertFrom);
            }
            if (content.Contains("VMSize"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuOptionInternal)this).VMSize = (string) content.GetValueForProperty("VMSize",((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuOptionInternal)this).VMSize, global::System.Convert.ToString);
            }
            if (content.Contains("RecommendationRank"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuOptionInternal)this).RecommendationRank = (int) content.GetValueForProperty("RecommendationRank",((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuOptionInternal)this).RecommendationRank, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            }
            if (content.Contains("AzureMlRecommended"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuOptionInternal)this).AzureMlRecommended = (bool?) content.GetValueForProperty("AzureMlRecommended",((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuOptionInternal)this).AzureMlRecommended, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            }
            if (content.Contains("DocumentationUrl"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuOptionInternal)this).DocumentationUrl = (string) content.GetValueForProperty("DocumentationUrl",((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuOptionInternal)this).DocumentationUrl, global::System.Convert.ToString);
            }
            if (content.Contains("ReadinessStatus"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuOptionInternal)this).ReadinessStatus = (string) content.GetValueForProperty("ReadinessStatus",((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuOptionInternal)this).ReadinessStatus, global::System.Convert.ToString);
            }
            if (content.Contains("CostSource"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuOptionInternal)this).CostSource = (string) content.GetValueForProperty("CostSource",((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuOptionInternal)this).CostSource, global::System.Convert.ToString);
            }
            if (content.Contains("QuotaStatus"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuOptionInternal)this).QuotaStatus = (string) content.GetValueForProperty("QuotaStatus",((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuOptionInternal)this).QuotaStatus, global::System.Convert.ToString);
            }
            if (content.Contains("PlacementStatus"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuOptionInternal)this).PlacementStatus = (string) content.GetValueForProperty("PlacementStatus",((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuOptionInternal)this).PlacementStatus, global::System.Convert.ToString);
            }
            if (content.Contains("BenchmarkLevel"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuOptionInternal)this).BenchmarkLevel = (string) content.GetValueForProperty("BenchmarkLevel",((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuOptionInternal)this).BenchmarkLevel, global::System.Convert.ToString);
            }
            if (content.Contains("ReadinessReason"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuOptionInternal)this).ReadinessReason = (string) content.GetValueForProperty("ReadinessReason",((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuOptionInternal)this).ReadinessReason, global::System.Convert.ToString);
            }
            if (content.Contains("TopologyAccelerator"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuOptionInternal)this).TopologyAccelerator = (Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuAccelerator) content.GetValueForProperty("TopologyAccelerator",((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuOptionInternal)this).TopologyAccelerator, Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.RecommendVMSkuAcceleratorTypeConverter.ConvertFrom);
            }
            if (content.Contains("TopologyEstimatedNodeCountPerReplica"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuOptionInternal)this).TopologyEstimatedNodeCountPerReplica = (int) content.GetValueForProperty("TopologyEstimatedNodeCountPerReplica",((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuOptionInternal)this).TopologyEstimatedNodeCountPerReplica, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            }
            if (content.Contains("TopologyEstimatedTotalNodeCount"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuOptionInternal)this).TopologyEstimatedTotalNodeCount = (long) content.GetValueForProperty("TopologyEstimatedTotalNodeCount",((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuOptionInternal)this).TopologyEstimatedTotalNodeCount, (__y)=> (long) global::System.Convert.ChangeType(__y, typeof(long)));
            }
            if (content.Contains("CostError"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuOptionInternal)this).CostError = (Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuStageError) content.GetValueForProperty("CostError",((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuOptionInternal)this).CostError, Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.RecommendVMSkuStageErrorTypeConverter.ConvertFrom);
            }
            if (content.Contains("CostCurrencyCode"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuOptionInternal)this).CostCurrencyCode = (string) content.GetValueForProperty("CostCurrencyCode",((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuOptionInternal)this).CostCurrencyCode, global::System.Convert.ToString);
            }
            if (content.Contains("CostVMHourly"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuOptionInternal)this).CostVMHourly = (double) content.GetValueForProperty("CostVMHourly",((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuOptionInternal)this).CostVMHourly, (__y)=> (double) global::System.Convert.ChangeType(__y, typeof(double)));
            }
            if (content.Contains("CostDeploymentHourly"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuOptionInternal)this).CostDeploymentHourly = (double) content.GetValueForProperty("CostDeploymentHourly",((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuOptionInternal)this).CostDeploymentHourly, (__y)=> (double) global::System.Convert.ChangeType(__y, typeof(double)));
            }
            if (content.Contains("CostPriceAsOf"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuOptionInternal)this).CostPriceAsOf = (global::System.DateTime?) content.GetValueForProperty("CostPriceAsOf",((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuOptionInternal)this).CostPriceAsOf, (v) => v is global::System.DateTime _v ? _v : global::System.Xml.XmlConvert.ToDateTime( v.ToString() , global::System.Xml.XmlDateTimeSerializationMode.Unspecified));
            }
            if (content.Contains("QuotaError"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuOptionInternal)this).QuotaError = (Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuStageError) content.GetValueForProperty("QuotaError",((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuOptionInternal)this).QuotaError, Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.RecommendVMSkuStageErrorTypeConverter.ConvertFrom);
            }
            if (content.Contains("QuotaIncrease"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuOptionInternal)this).QuotaIncrease = (Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuQuotaIncrease) content.GetValueForProperty("QuotaIncrease",((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuOptionInternal)this).QuotaIncrease, Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.RecommendVMSkuQuotaIncreaseTypeConverter.ConvertFrom);
            }
            if (content.Contains("QuotaReason"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuOptionInternal)this).QuotaReason = (string) content.GetValueForProperty("QuotaReason",((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuOptionInternal)this).QuotaReason, global::System.Convert.ToString);
            }
            if (content.Contains("QuotaMaxAvailableReplicaCount"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuOptionInternal)this).QuotaMaxAvailableReplicaCount = (int?) content.GetValueForProperty("QuotaMaxAvailableReplicaCount",((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuOptionInternal)this).QuotaMaxAvailableReplicaCount, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            }
            if (content.Contains("PlacementError"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuOptionInternal)this).PlacementError = (Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuStageError) content.GetValueForProperty("PlacementError",((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuOptionInternal)this).PlacementError, Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.RecommendVMSkuStageErrorTypeConverter.ConvertFrom);
            }
            if (content.Contains("PlacementReason"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuOptionInternal)this).PlacementReason = (string) content.GetValueForProperty("PlacementReason",((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuOptionInternal)this).PlacementReason, global::System.Convert.ToString);
            }
            if (content.Contains("PlacementRecommendedAvailabilityZone"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuOptionInternal)this).PlacementRecommendedAvailabilityZone = (System.Collections.Generic.List<string>) content.GetValueForProperty("PlacementRecommendedAvailabilityZone",((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuOptionInternal)this).PlacementRecommendedAvailabilityZone, __y => TypeConverterExtensions.SelectToList<string>(__y, global::System.Convert.ToString));
            }
            if (content.Contains("BenchmarkModelClass"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuOptionInternal)this).BenchmarkModelClass = (string) content.GetValueForProperty("BenchmarkModelClass",((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuOptionInternal)this).BenchmarkModelClass, global::System.Convert.ToString);
            }
            if (content.Contains("BenchmarkScenario"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuOptionInternal)this).BenchmarkScenario = (string) content.GetValueForProperty("BenchmarkScenario",((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuOptionInternal)this).BenchmarkScenario, global::System.Convert.ToString);
            }
            if (content.Contains("BenchmarkSubmitterCount"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuOptionInternal)this).BenchmarkSubmitterCount = (int?) content.GetValueForProperty("BenchmarkSubmitterCount",((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuOptionInternal)this).BenchmarkSubmitterCount, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            }
            if (content.Contains("BenchmarkSubmissionId"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuOptionInternal)this).BenchmarkSubmissionId = (string) content.GetValueForProperty("BenchmarkSubmissionId",((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuOptionInternal)this).BenchmarkSubmissionId, global::System.Convert.ToString);
            }
            if (content.Contains("BenchmarkModel"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuOptionInternal)this).BenchmarkModel = (string) content.GetValueForProperty("BenchmarkModel",((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuOptionInternal)this).BenchmarkModel, global::System.Convert.ToString);
            }
            if (content.Contains("BenchmarkSubmitter"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuOptionInternal)this).BenchmarkSubmitter = (string) content.GetValueForProperty("BenchmarkSubmitter",((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuOptionInternal)this).BenchmarkSubmitter, global::System.Convert.ToString);
            }
            if (content.Contains("BenchmarkSystem"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuOptionInternal)this).BenchmarkSystem = (string) content.GetValueForProperty("BenchmarkSystem",((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuOptionInternal)this).BenchmarkSystem, global::System.Convert.ToString);
            }
            if (content.Contains("BenchmarkThroughput"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuOptionInternal)this).BenchmarkThroughput = (double?) content.GetValueForProperty("BenchmarkThroughput",((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuOptionInternal)this).BenchmarkThroughput, (__y)=> (double) global::System.Convert.ChangeType(__y, typeof(double)));
            }
            if (content.Contains("BenchmarkThroughputUnit"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuOptionInternal)this).BenchmarkThroughputUnit = (string) content.GetValueForProperty("BenchmarkThroughputUnit",((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuOptionInternal)this).BenchmarkThroughputUnit, global::System.Convert.ToString);
            }
            if (content.Contains("BenchmarkSoftware"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuOptionInternal)this).BenchmarkSoftware = (string) content.GetValueForProperty("BenchmarkSoftware",((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuOptionInternal)this).BenchmarkSoftware, global::System.Convert.ToString);
            }
            if (content.Contains("BenchmarkOperatingSystem"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuOptionInternal)this).BenchmarkOperatingSystem = (string) content.GetValueForProperty("BenchmarkOperatingSystem",((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuOptionInternal)this).BenchmarkOperatingSystem, global::System.Convert.ToString);
            }
            if (content.Contains("BenchmarkWeightDataType"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuOptionInternal)this).BenchmarkWeightDataType = (string) content.GetValueForProperty("BenchmarkWeightDataType",((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuOptionInternal)this).BenchmarkWeightDataType, global::System.Convert.ToString);
            }
            if (content.Contains("BenchmarkP99TtftMS"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuOptionInternal)this).BenchmarkP99TtftMS = (double?) content.GetValueForProperty("BenchmarkP99TtftMS",((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuOptionInternal)this).BenchmarkP99TtftMS, (__y)=> (double) global::System.Convert.ChangeType(__y, typeof(double)));
            }
            if (content.Contains("BenchmarkP99TpotMS"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuOptionInternal)this).BenchmarkP99TpotMS = (double?) content.GetValueForProperty("BenchmarkP99TpotMS",((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuOptionInternal)this).BenchmarkP99TpotMS, (__y)=> (double) global::System.Convert.ChangeType(__y, typeof(double)));
            }
            if (content.Contains("PerformanceEstimateDeploymentOutputTokensPerSecond"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuOptionInternal)this).PerformanceEstimateDeploymentOutputTokensPerSecond = (double?) content.GetValueForProperty("PerformanceEstimateDeploymentOutputTokensPerSecond",((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuOptionInternal)this).PerformanceEstimateDeploymentOutputTokensPerSecond, (__y)=> (double) global::System.Convert.ChangeType(__y, typeof(double)));
            }
            if (content.Contains("PerformanceEstimateTtftMS"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuOptionInternal)this).PerformanceEstimateTtftMS = (double?) content.GetValueForProperty("PerformanceEstimateTtftMS",((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuOptionInternal)this).PerformanceEstimateTtftMS, (__y)=> (double) global::System.Convert.ChangeType(__y, typeof(double)));
            }
            if (content.Contains("AcceleratorModel"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuOptionInternal)this).AcceleratorModel = (string) content.GetValueForProperty("AcceleratorModel",((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuOptionInternal)this).AcceleratorModel, global::System.Convert.ToString);
            }
            if (content.Contains("AcceleratorCountPerVM"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuOptionInternal)this).AcceleratorCountPerVM = (int) content.GetValueForProperty("AcceleratorCountPerVM",((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuOptionInternal)this).AcceleratorCountPerVM, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            }
            if (content.Contains("AcceleratorMemoryGiBPerAccelerator"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuOptionInternal)this).AcceleratorMemoryGiBPerAccelerator = (int) content.GetValueForProperty("AcceleratorMemoryGiBPerAccelerator",((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuOptionInternal)this).AcceleratorMemoryGiBPerAccelerator, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            }
            if (content.Contains("CostErrorCode"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuOptionInternal)this).CostErrorCode = (string) content.GetValueForProperty("CostErrorCode",((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuOptionInternal)this).CostErrorCode, global::System.Convert.ToString);
            }
            if (content.Contains("CostErrorMessage"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuOptionInternal)this).CostErrorMessage = (string) content.GetValueForProperty("CostErrorMessage",((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuOptionInternal)this).CostErrorMessage, global::System.Convert.ToString);
            }
            if (content.Contains("QuotaErrorCode"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuOptionInternal)this).QuotaErrorCode = (string) content.GetValueForProperty("QuotaErrorCode",((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuOptionInternal)this).QuotaErrorCode, global::System.Convert.ToString);
            }
            if (content.Contains("QuotaErrorMessage"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuOptionInternal)this).QuotaErrorMessage = (string) content.GetValueForProperty("QuotaErrorMessage",((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuOptionInternal)this).QuotaErrorMessage, global::System.Convert.ToString);
            }
            if (content.Contains("IncreaseLimit"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuOptionInternal)this).IncreaseLimit = (System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuQuotaLimit>) content.GetValueForProperty("IncreaseLimit",((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuOptionInternal)this).IncreaseLimit, __y => TypeConverterExtensions.SelectToList<Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuQuotaLimit>(__y, Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.RecommendVMSkuQuotaLimitTypeConverter.ConvertFrom));
            }
            if (content.Contains("IncreasePortalUrl"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuOptionInternal)this).IncreasePortalUrl = (string) content.GetValueForProperty("IncreasePortalUrl",((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuOptionInternal)this).IncreasePortalUrl, global::System.Convert.ToString);
            }
            if (content.Contains("PlacementErrorCode"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuOptionInternal)this).PlacementErrorCode = (string) content.GetValueForProperty("PlacementErrorCode",((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuOptionInternal)this).PlacementErrorCode, global::System.Convert.ToString);
            }
            if (content.Contains("PlacementErrorMessage"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuOptionInternal)this).PlacementErrorMessage = (string) content.GetValueForProperty("PlacementErrorMessage",((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuOptionInternal)this).PlacementErrorMessage, global::System.Convert.ToString);
            }
            AfterDeserializeDictionary(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.RecommendVMSkuOption"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        internal RecommendVMSkuOption(global::System.Management.Automation.PSObject content)
        {
            bool returnNow = false;
            BeforeDeserializePSObject(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            if (content.Contains("Readiness"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuOptionInternal)this).Readiness = (Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuReadiness) content.GetValueForProperty("Readiness",((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuOptionInternal)this).Readiness, Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.RecommendVMSkuReadinessTypeConverter.ConvertFrom);
            }
            if (content.Contains("Topology"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuOptionInternal)this).Topology = (Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuTopology) content.GetValueForProperty("Topology",((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuOptionInternal)this).Topology, Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.RecommendVMSkuTopologyTypeConverter.ConvertFrom);
            }
            if (content.Contains("Cost"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuOptionInternal)this).Cost = (Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuCost) content.GetValueForProperty("Cost",((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuOptionInternal)this).Cost, Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.RecommendVMSkuCostTypeConverter.ConvertFrom);
            }
            if (content.Contains("Quota"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuOptionInternal)this).Quota = (Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuQuota) content.GetValueForProperty("Quota",((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuOptionInternal)this).Quota, Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.RecommendVMSkuQuotaTypeConverter.ConvertFrom);
            }
            if (content.Contains("Placement"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuOptionInternal)this).Placement = (Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuPlacement) content.GetValueForProperty("Placement",((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuOptionInternal)this).Placement, Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.RecommendVMSkuPlacementTypeConverter.ConvertFrom);
            }
            if (content.Contains("Benchmark"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuOptionInternal)this).Benchmark = (Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuBenchmark) content.GetValueForProperty("Benchmark",((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuOptionInternal)this).Benchmark, Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.RecommendVMSkuBenchmarkTypeConverter.ConvertFrom);
            }
            if (content.Contains("PerformanceEstimate"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuOptionInternal)this).PerformanceEstimate = (Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuPerformanceEstimate) content.GetValueForProperty("PerformanceEstimate",((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuOptionInternal)this).PerformanceEstimate, Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.RecommendVMSkuPerformanceEstimateTypeConverter.ConvertFrom);
            }
            if (content.Contains("VMSize"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuOptionInternal)this).VMSize = (string) content.GetValueForProperty("VMSize",((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuOptionInternal)this).VMSize, global::System.Convert.ToString);
            }
            if (content.Contains("RecommendationRank"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuOptionInternal)this).RecommendationRank = (int) content.GetValueForProperty("RecommendationRank",((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuOptionInternal)this).RecommendationRank, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            }
            if (content.Contains("AzureMlRecommended"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuOptionInternal)this).AzureMlRecommended = (bool?) content.GetValueForProperty("AzureMlRecommended",((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuOptionInternal)this).AzureMlRecommended, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            }
            if (content.Contains("DocumentationUrl"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuOptionInternal)this).DocumentationUrl = (string) content.GetValueForProperty("DocumentationUrl",((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuOptionInternal)this).DocumentationUrl, global::System.Convert.ToString);
            }
            if (content.Contains("ReadinessStatus"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuOptionInternal)this).ReadinessStatus = (string) content.GetValueForProperty("ReadinessStatus",((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuOptionInternal)this).ReadinessStatus, global::System.Convert.ToString);
            }
            if (content.Contains("CostSource"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuOptionInternal)this).CostSource = (string) content.GetValueForProperty("CostSource",((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuOptionInternal)this).CostSource, global::System.Convert.ToString);
            }
            if (content.Contains("QuotaStatus"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuOptionInternal)this).QuotaStatus = (string) content.GetValueForProperty("QuotaStatus",((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuOptionInternal)this).QuotaStatus, global::System.Convert.ToString);
            }
            if (content.Contains("PlacementStatus"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuOptionInternal)this).PlacementStatus = (string) content.GetValueForProperty("PlacementStatus",((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuOptionInternal)this).PlacementStatus, global::System.Convert.ToString);
            }
            if (content.Contains("BenchmarkLevel"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuOptionInternal)this).BenchmarkLevel = (string) content.GetValueForProperty("BenchmarkLevel",((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuOptionInternal)this).BenchmarkLevel, global::System.Convert.ToString);
            }
            if (content.Contains("ReadinessReason"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuOptionInternal)this).ReadinessReason = (string) content.GetValueForProperty("ReadinessReason",((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuOptionInternal)this).ReadinessReason, global::System.Convert.ToString);
            }
            if (content.Contains("TopologyAccelerator"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuOptionInternal)this).TopologyAccelerator = (Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuAccelerator) content.GetValueForProperty("TopologyAccelerator",((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuOptionInternal)this).TopologyAccelerator, Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.RecommendVMSkuAcceleratorTypeConverter.ConvertFrom);
            }
            if (content.Contains("TopologyEstimatedNodeCountPerReplica"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuOptionInternal)this).TopologyEstimatedNodeCountPerReplica = (int) content.GetValueForProperty("TopologyEstimatedNodeCountPerReplica",((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuOptionInternal)this).TopologyEstimatedNodeCountPerReplica, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            }
            if (content.Contains("TopologyEstimatedTotalNodeCount"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuOptionInternal)this).TopologyEstimatedTotalNodeCount = (long) content.GetValueForProperty("TopologyEstimatedTotalNodeCount",((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuOptionInternal)this).TopologyEstimatedTotalNodeCount, (__y)=> (long) global::System.Convert.ChangeType(__y, typeof(long)));
            }
            if (content.Contains("CostError"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuOptionInternal)this).CostError = (Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuStageError) content.GetValueForProperty("CostError",((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuOptionInternal)this).CostError, Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.RecommendVMSkuStageErrorTypeConverter.ConvertFrom);
            }
            if (content.Contains("CostCurrencyCode"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuOptionInternal)this).CostCurrencyCode = (string) content.GetValueForProperty("CostCurrencyCode",((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuOptionInternal)this).CostCurrencyCode, global::System.Convert.ToString);
            }
            if (content.Contains("CostVMHourly"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuOptionInternal)this).CostVMHourly = (double) content.GetValueForProperty("CostVMHourly",((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuOptionInternal)this).CostVMHourly, (__y)=> (double) global::System.Convert.ChangeType(__y, typeof(double)));
            }
            if (content.Contains("CostDeploymentHourly"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuOptionInternal)this).CostDeploymentHourly = (double) content.GetValueForProperty("CostDeploymentHourly",((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuOptionInternal)this).CostDeploymentHourly, (__y)=> (double) global::System.Convert.ChangeType(__y, typeof(double)));
            }
            if (content.Contains("CostPriceAsOf"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuOptionInternal)this).CostPriceAsOf = (global::System.DateTime?) content.GetValueForProperty("CostPriceAsOf",((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuOptionInternal)this).CostPriceAsOf, (v) => v is global::System.DateTime _v ? _v : global::System.Xml.XmlConvert.ToDateTime( v.ToString() , global::System.Xml.XmlDateTimeSerializationMode.Unspecified));
            }
            if (content.Contains("QuotaError"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuOptionInternal)this).QuotaError = (Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuStageError) content.GetValueForProperty("QuotaError",((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuOptionInternal)this).QuotaError, Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.RecommendVMSkuStageErrorTypeConverter.ConvertFrom);
            }
            if (content.Contains("QuotaIncrease"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuOptionInternal)this).QuotaIncrease = (Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuQuotaIncrease) content.GetValueForProperty("QuotaIncrease",((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuOptionInternal)this).QuotaIncrease, Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.RecommendVMSkuQuotaIncreaseTypeConverter.ConvertFrom);
            }
            if (content.Contains("QuotaReason"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuOptionInternal)this).QuotaReason = (string) content.GetValueForProperty("QuotaReason",((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuOptionInternal)this).QuotaReason, global::System.Convert.ToString);
            }
            if (content.Contains("QuotaMaxAvailableReplicaCount"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuOptionInternal)this).QuotaMaxAvailableReplicaCount = (int?) content.GetValueForProperty("QuotaMaxAvailableReplicaCount",((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuOptionInternal)this).QuotaMaxAvailableReplicaCount, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            }
            if (content.Contains("PlacementError"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuOptionInternal)this).PlacementError = (Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuStageError) content.GetValueForProperty("PlacementError",((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuOptionInternal)this).PlacementError, Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.RecommendVMSkuStageErrorTypeConverter.ConvertFrom);
            }
            if (content.Contains("PlacementReason"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuOptionInternal)this).PlacementReason = (string) content.GetValueForProperty("PlacementReason",((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuOptionInternal)this).PlacementReason, global::System.Convert.ToString);
            }
            if (content.Contains("PlacementRecommendedAvailabilityZone"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuOptionInternal)this).PlacementRecommendedAvailabilityZone = (System.Collections.Generic.List<string>) content.GetValueForProperty("PlacementRecommendedAvailabilityZone",((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuOptionInternal)this).PlacementRecommendedAvailabilityZone, __y => TypeConverterExtensions.SelectToList<string>(__y, global::System.Convert.ToString));
            }
            if (content.Contains("BenchmarkModelClass"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuOptionInternal)this).BenchmarkModelClass = (string) content.GetValueForProperty("BenchmarkModelClass",((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuOptionInternal)this).BenchmarkModelClass, global::System.Convert.ToString);
            }
            if (content.Contains("BenchmarkScenario"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuOptionInternal)this).BenchmarkScenario = (string) content.GetValueForProperty("BenchmarkScenario",((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuOptionInternal)this).BenchmarkScenario, global::System.Convert.ToString);
            }
            if (content.Contains("BenchmarkSubmitterCount"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuOptionInternal)this).BenchmarkSubmitterCount = (int?) content.GetValueForProperty("BenchmarkSubmitterCount",((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuOptionInternal)this).BenchmarkSubmitterCount, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            }
            if (content.Contains("BenchmarkSubmissionId"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuOptionInternal)this).BenchmarkSubmissionId = (string) content.GetValueForProperty("BenchmarkSubmissionId",((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuOptionInternal)this).BenchmarkSubmissionId, global::System.Convert.ToString);
            }
            if (content.Contains("BenchmarkModel"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuOptionInternal)this).BenchmarkModel = (string) content.GetValueForProperty("BenchmarkModel",((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuOptionInternal)this).BenchmarkModel, global::System.Convert.ToString);
            }
            if (content.Contains("BenchmarkSubmitter"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuOptionInternal)this).BenchmarkSubmitter = (string) content.GetValueForProperty("BenchmarkSubmitter",((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuOptionInternal)this).BenchmarkSubmitter, global::System.Convert.ToString);
            }
            if (content.Contains("BenchmarkSystem"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuOptionInternal)this).BenchmarkSystem = (string) content.GetValueForProperty("BenchmarkSystem",((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuOptionInternal)this).BenchmarkSystem, global::System.Convert.ToString);
            }
            if (content.Contains("BenchmarkThroughput"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuOptionInternal)this).BenchmarkThroughput = (double?) content.GetValueForProperty("BenchmarkThroughput",((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuOptionInternal)this).BenchmarkThroughput, (__y)=> (double) global::System.Convert.ChangeType(__y, typeof(double)));
            }
            if (content.Contains("BenchmarkThroughputUnit"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuOptionInternal)this).BenchmarkThroughputUnit = (string) content.GetValueForProperty("BenchmarkThroughputUnit",((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuOptionInternal)this).BenchmarkThroughputUnit, global::System.Convert.ToString);
            }
            if (content.Contains("BenchmarkSoftware"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuOptionInternal)this).BenchmarkSoftware = (string) content.GetValueForProperty("BenchmarkSoftware",((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuOptionInternal)this).BenchmarkSoftware, global::System.Convert.ToString);
            }
            if (content.Contains("BenchmarkOperatingSystem"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuOptionInternal)this).BenchmarkOperatingSystem = (string) content.GetValueForProperty("BenchmarkOperatingSystem",((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuOptionInternal)this).BenchmarkOperatingSystem, global::System.Convert.ToString);
            }
            if (content.Contains("BenchmarkWeightDataType"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuOptionInternal)this).BenchmarkWeightDataType = (string) content.GetValueForProperty("BenchmarkWeightDataType",((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuOptionInternal)this).BenchmarkWeightDataType, global::System.Convert.ToString);
            }
            if (content.Contains("BenchmarkP99TtftMS"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuOptionInternal)this).BenchmarkP99TtftMS = (double?) content.GetValueForProperty("BenchmarkP99TtftMS",((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuOptionInternal)this).BenchmarkP99TtftMS, (__y)=> (double) global::System.Convert.ChangeType(__y, typeof(double)));
            }
            if (content.Contains("BenchmarkP99TpotMS"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuOptionInternal)this).BenchmarkP99TpotMS = (double?) content.GetValueForProperty("BenchmarkP99TpotMS",((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuOptionInternal)this).BenchmarkP99TpotMS, (__y)=> (double) global::System.Convert.ChangeType(__y, typeof(double)));
            }
            if (content.Contains("PerformanceEstimateDeploymentOutputTokensPerSecond"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuOptionInternal)this).PerformanceEstimateDeploymentOutputTokensPerSecond = (double?) content.GetValueForProperty("PerformanceEstimateDeploymentOutputTokensPerSecond",((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuOptionInternal)this).PerformanceEstimateDeploymentOutputTokensPerSecond, (__y)=> (double) global::System.Convert.ChangeType(__y, typeof(double)));
            }
            if (content.Contains("PerformanceEstimateTtftMS"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuOptionInternal)this).PerformanceEstimateTtftMS = (double?) content.GetValueForProperty("PerformanceEstimateTtftMS",((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuOptionInternal)this).PerformanceEstimateTtftMS, (__y)=> (double) global::System.Convert.ChangeType(__y, typeof(double)));
            }
            if (content.Contains("AcceleratorModel"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuOptionInternal)this).AcceleratorModel = (string) content.GetValueForProperty("AcceleratorModel",((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuOptionInternal)this).AcceleratorModel, global::System.Convert.ToString);
            }
            if (content.Contains("AcceleratorCountPerVM"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuOptionInternal)this).AcceleratorCountPerVM = (int) content.GetValueForProperty("AcceleratorCountPerVM",((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuOptionInternal)this).AcceleratorCountPerVM, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            }
            if (content.Contains("AcceleratorMemoryGiBPerAccelerator"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuOptionInternal)this).AcceleratorMemoryGiBPerAccelerator = (int) content.GetValueForProperty("AcceleratorMemoryGiBPerAccelerator",((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuOptionInternal)this).AcceleratorMemoryGiBPerAccelerator, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            }
            if (content.Contains("CostErrorCode"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuOptionInternal)this).CostErrorCode = (string) content.GetValueForProperty("CostErrorCode",((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuOptionInternal)this).CostErrorCode, global::System.Convert.ToString);
            }
            if (content.Contains("CostErrorMessage"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuOptionInternal)this).CostErrorMessage = (string) content.GetValueForProperty("CostErrorMessage",((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuOptionInternal)this).CostErrorMessage, global::System.Convert.ToString);
            }
            if (content.Contains("QuotaErrorCode"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuOptionInternal)this).QuotaErrorCode = (string) content.GetValueForProperty("QuotaErrorCode",((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuOptionInternal)this).QuotaErrorCode, global::System.Convert.ToString);
            }
            if (content.Contains("QuotaErrorMessage"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuOptionInternal)this).QuotaErrorMessage = (string) content.GetValueForProperty("QuotaErrorMessage",((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuOptionInternal)this).QuotaErrorMessage, global::System.Convert.ToString);
            }
            if (content.Contains("IncreaseLimit"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuOptionInternal)this).IncreaseLimit = (System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuQuotaLimit>) content.GetValueForProperty("IncreaseLimit",((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuOptionInternal)this).IncreaseLimit, __y => TypeConverterExtensions.SelectToList<Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuQuotaLimit>(__y, Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.RecommendVMSkuQuotaLimitTypeConverter.ConvertFrom));
            }
            if (content.Contains("IncreasePortalUrl"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuOptionInternal)this).IncreasePortalUrl = (string) content.GetValueForProperty("IncreasePortalUrl",((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuOptionInternal)this).IncreasePortalUrl, global::System.Convert.ToString);
            }
            if (content.Contains("PlacementErrorCode"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuOptionInternal)this).PlacementErrorCode = (string) content.GetValueForProperty("PlacementErrorCode",((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuOptionInternal)this).PlacementErrorCode, global::System.Convert.ToString);
            }
            if (content.Contains("PlacementErrorMessage"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuOptionInternal)this).PlacementErrorMessage = (string) content.GetValueForProperty("PlacementErrorMessage",((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuOptionInternal)this).PlacementErrorMessage, global::System.Convert.ToString);
            }
            AfterDeserializePSObject(content);
        }

        /// <summary>Serializes this instance to a json string.</summary>

        /// <returns>a <see cref="System.String" /> containing this model serialized to JSON text.</returns>
        public string ToJsonString() => ToJson(null, Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.SerializationMode.IncludeAll)?.ToString();

        public override string ToString()
        {
            var returnNow = false;
            var result = global::System.String.Empty;
            OverrideToString(ref result, ref returnNow);
            if (returnNow)
            {
                return result;
            }
            return ToJsonString();
        }
    }
    /// One ranked virtual machine size recommendation.
    [System.ComponentModel.TypeConverter(typeof(RecommendVMSkuOptionTypeConverter))]
    public partial interface IRecommendVMSkuOption

    {

    }
}