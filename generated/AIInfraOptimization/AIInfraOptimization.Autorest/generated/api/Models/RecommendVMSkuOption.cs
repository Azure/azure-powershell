// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.
namespace Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models
{
    using static Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.Extensions;

    /// <summary>One ranked virtual machine size recommendation.</summary>
    public partial class RecommendVMSkuOption :
        Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuOption,
        Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuOptionInternal
    {

        /// <summary>The number of accelerator devices in each virtual machine.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Origin(Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.PropertyOrigin.Inlined)]
        public int AcceleratorCountPerVM { get => ((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuTopologyInternal)Topology).AcceleratorCountPerVM; set => ((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuTopologyInternal)Topology).AcceleratorCountPerVM = value ; }

        /// <summary>The memory capacity of a single accelerator device, in gibibytes.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Origin(Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.PropertyOrigin.Inlined)]
        public int AcceleratorMemoryGiBPerAccelerator { get => ((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuTopologyInternal)Topology).AcceleratorMemoryGiBPerAccelerator; set => ((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuTopologyInternal)Topology).AcceleratorMemoryGiBPerAccelerator = value ; }

        /// <summary>The accelerator model name, for example `A100` or `H100`.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Origin(Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.PropertyOrigin.Inlined)]
        public string AcceleratorModel { get => ((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuTopologyInternal)Topology).AcceleratorModel; set => ((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuTopologyInternal)Topology).AcceleratorModel = value ; }

        /// <summary>Backing field for <see cref="AzureMlRecommended" /> property.</summary>
        private bool? _azureMlRecommended;

        /// <summary>
        /// Whether the Azure Machine Learning model catalog recommends this virtual machine size for the model.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Origin(Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.PropertyOrigin.Owned)]
        public bool? AzureMlRecommended { get => this._azureMlRecommended; set => this._azureMlRecommended = value; }

        /// <summary>Backing field for <see cref="Benchmark" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuBenchmark _benchmark;

        /// <summary>The external benchmark evidence selected for this option.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Origin(Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuBenchmark Benchmark { get => (this._benchmark = this._benchmark ?? new Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.RecommendVMSkuBenchmark()); set => this._benchmark = value; }

        /// <summary>How closely the benchmark evidence matches the recommended topology.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Origin(Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.PropertyOrigin.Inlined)]
        public string BenchmarkLevel { get => ((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuBenchmarkInternal)Benchmark).Level; set => ((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuBenchmarkInternal)Benchmark).Level = value ?? null; }

        /// <summary>The model the benchmark was measured on.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Origin(Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.PropertyOrigin.Inlined)]
        public string BenchmarkModel { get => ((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuBenchmarkInternal)Benchmark).BenchmarkModel; set => ((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuBenchmarkInternal)Benchmark).BenchmarkModel = value ?? null; }

        /// <summary>The model size class the benchmark covers, for example `70b`.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Origin(Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.PropertyOrigin.Inlined)]
        public string BenchmarkModelClass { get => ((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuBenchmarkInternal)Benchmark).ModelClass; set => ((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuBenchmarkInternal)Benchmark).ModelClass = value ?? null; }

        /// <summary>The operating system the benchmark was measured on.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Origin(Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.PropertyOrigin.Inlined)]
        public string BenchmarkOperatingSystem { get => ((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuBenchmarkInternal)Benchmark).OperatingSystem; set => ((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuBenchmarkInternal)Benchmark).OperatingSystem = value ?? null; }

        /// <summary>
        /// The 99th-percentile time per output token observed in the benchmark, in milliseconds.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Origin(Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.PropertyOrigin.Inlined)]
        public double? BenchmarkP99TpotMS { get => ((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuBenchmarkInternal)Benchmark).P99TpotMS; set => ((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuBenchmarkInternal)Benchmark).P99TpotMS = value ?? default(double); }

        /// <summary>
        /// The 99th-percentile time to first token observed in the benchmark, in milliseconds.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Origin(Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.PropertyOrigin.Inlined)]
        public double? BenchmarkP99TtftMS { get => ((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuBenchmarkInternal)Benchmark).P99TtftMS; set => ((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuBenchmarkInternal)Benchmark).P99TtftMS = value ?? default(double); }

        /// <summary>The benchmark scenario, for example `Server` or `Offline`.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Origin(Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.PropertyOrigin.Inlined)]
        public string BenchmarkScenario { get => ((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuBenchmarkInternal)Benchmark).Scenario; set => ((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuBenchmarkInternal)Benchmark).Scenario = value ?? null; }

        /// <summary>The serving software the benchmark was measured with.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Origin(Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.PropertyOrigin.Inlined)]
        public string BenchmarkSoftware { get => ((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuBenchmarkInternal)Benchmark).Software; set => ((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuBenchmarkInternal)Benchmark).Software = value ?? null; }

        /// <summary>The identifier of the selected benchmark submission.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Origin(Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.PropertyOrigin.Inlined)]
        public string BenchmarkSubmissionId { get => ((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuBenchmarkInternal)Benchmark).SubmissionId; set => ((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuBenchmarkInternal)Benchmark).SubmissionId = value ?? null; }

        /// <summary>The organization that published the benchmark submission.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Origin(Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.PropertyOrigin.Inlined)]
        public string BenchmarkSubmitter { get => ((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuBenchmarkInternal)Benchmark).Submitter; set => ((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuBenchmarkInternal)Benchmark).Submitter = value ?? null; }

        /// <summary>The number of submitters that published results for this configuration.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Origin(Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.PropertyOrigin.Inlined)]
        public int? BenchmarkSubmitterCount { get => ((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuBenchmarkInternal)Benchmark).SubmitterCount; set => ((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuBenchmarkInternal)Benchmark).SubmitterCount = value ?? default(int); }

        /// <summary>The system the benchmark was measured on.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Origin(Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.PropertyOrigin.Inlined)]
        public string BenchmarkSystem { get => ((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuBenchmarkInternal)Benchmark).System; set => ((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuBenchmarkInternal)Benchmark).System = value ?? null; }

        /// <summary>The throughput observed in the benchmark submission.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Origin(Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.PropertyOrigin.Inlined)]
        public double? BenchmarkThroughput { get => ((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuBenchmarkInternal)Benchmark).Throughput; set => ((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuBenchmarkInternal)Benchmark).Throughput = value ?? default(double); }

        /// <summary>The unit the observed throughput is expressed in, for example `Tokens/s`.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Origin(Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.PropertyOrigin.Inlined)]
        public string BenchmarkThroughputUnit { get => ((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuBenchmarkInternal)Benchmark).ThroughputUnit; set => ((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuBenchmarkInternal)Benchmark).ThroughputUnit = value ?? null; }

        /// <summary>The weight data types used in the benchmark submission.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Origin(Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.PropertyOrigin.Inlined)]
        public string BenchmarkWeightDataType { get => ((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuBenchmarkInternal)Benchmark).WeightDataType; set => ((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuBenchmarkInternal)Benchmark).WeightDataType = value ?? null; }

        /// <summary>Backing field for <see cref="Cost" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuCost _cost;

        /// <summary>The deployment cost for this option.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Origin(Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuCost Cost { get => (this._cost = this._cost ?? new Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.RecommendVMSkuCost()); set => this._cost = value; }

        /// <summary>The ISO 4217 currency code all amounts in this object are expressed in.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Origin(Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.PropertyOrigin.Inlined)]
        public string CostCurrencyCode { get => ((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuCostInternal)Cost).CurrencyCode; set => ((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuCostInternal)Cost).CurrencyCode = value ; }

        /// <summary>The price per hour for the whole deployment, in the stated currency.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Origin(Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.PropertyOrigin.Inlined)]
        public double CostDeploymentHourly { get => ((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuCostInternal)Cost).DeploymentHourly; set => ((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuCostInternal)Cost).DeploymentHourly = value ; }

        /// <summary>The reason the stage did not complete.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Origin(Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.PropertyOrigin.Inlined)]
        public string CostErrorCode { get => ((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuCostInternal)Cost).Code; set => ((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuCostInternal)Cost).Code = value ?? null; }

        /// <summary>A human-readable description of the error.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Origin(Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.PropertyOrigin.Inlined)]
        public string CostErrorMessage { get => ((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuCostInternal)Cost).Message; set => ((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuCostInternal)Cost).Message = value ?? null; }

        /// <summary>The date and time the price was observed.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Origin(Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.PropertyOrigin.Inlined)]
        public global::System.DateTime? CostPriceAsOf { get => ((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuCostInternal)Cost).PriceAsOf; set => ((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuCostInternal)Cost).PriceAsOf = value ?? default(global::System.DateTime); }

        /// <summary>The source the price was resolved from.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Origin(Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.PropertyOrigin.Inlined)]
        public string CostSource { get => ((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuCostInternal)Cost).Source; set => ((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuCostInternal)Cost).Source = value ; }

        /// <summary>The price per hour for a single virtual machine, in the stated currency.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Origin(Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.PropertyOrigin.Inlined)]
        public double CostVMHourly { get => ((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuCostInternal)Cost).VMHourly; set => ((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuCostInternal)Cost).VMHourly = value ; }

        /// <summary>Backing field for <see cref="DocumentationUrl" /> property.</summary>
        private string _documentationUrl;

        /// <summary>A URL to the Azure documentation page for this virtual machine size.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Origin(Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.PropertyOrigin.Owned)]
        public string DocumentationUrl { get => this._documentationUrl; set => this._documentationUrl = value; }

        /// <summary>The individual quota limits that block the requested deployment.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Origin(Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.PropertyOrigin.Inlined)]
        public System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuQuotaLimit> IncreaseLimit { get => ((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuQuotaInternal)Quota).IncreaseLimit; set => ((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuQuotaInternal)Quota).IncreaseLimit = value ?? null /* arrayOf */; }

        /// <summary>A URL to the Azure portal page for submitting the quota increase.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Origin(Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.PropertyOrigin.Inlined)]
        public string IncreasePortalUrl { get => ((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuQuotaInternal)Quota).IncreasePortalUrl; set => ((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuQuotaInternal)Quota).IncreasePortalUrl = value ?? null; }

        /// <summary>Internal Acessors for Benchmark</summary>
        Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuBenchmark Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuOptionInternal.Benchmark { get => (this._benchmark = this._benchmark ?? new Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.RecommendVMSkuBenchmark()); set { {_benchmark = value;} } }

        /// <summary>Internal Acessors for Cost</summary>
        Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuCost Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuOptionInternal.Cost { get => (this._cost = this._cost ?? new Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.RecommendVMSkuCost()); set { {_cost = value;} } }

        /// <summary>Internal Acessors for CostError</summary>
        Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuStageError Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuOptionInternal.CostError { get => ((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuCostInternal)Cost).Error; set => ((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuCostInternal)Cost).Error = value ?? null /* model class */; }

        /// <summary>Internal Acessors for PerformanceEstimate</summary>
        Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuPerformanceEstimate Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuOptionInternal.PerformanceEstimate { get => (this._performanceEstimate = this._performanceEstimate ?? new Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.RecommendVMSkuPerformanceEstimate()); set { {_performanceEstimate = value;} } }

        /// <summary>Internal Acessors for Placement</summary>
        Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuPlacement Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuOptionInternal.Placement { get => (this._placement = this._placement ?? new Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.RecommendVMSkuPlacement()); set { {_placement = value;} } }

        /// <summary>Internal Acessors for PlacementError</summary>
        Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuStageError Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuOptionInternal.PlacementError { get => ((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuPlacementInternal)Placement).Error; set => ((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuPlacementInternal)Placement).Error = value ?? null /* model class */; }

        /// <summary>Internal Acessors for Quota</summary>
        Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuQuota Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuOptionInternal.Quota { get => (this._quota = this._quota ?? new Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.RecommendVMSkuQuota()); set { {_quota = value;} } }

        /// <summary>Internal Acessors for QuotaError</summary>
        Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuStageError Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuOptionInternal.QuotaError { get => ((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuQuotaInternal)Quota).Error; set => ((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuQuotaInternal)Quota).Error = value ?? null /* model class */; }

        /// <summary>Internal Acessors for QuotaIncrease</summary>
        Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuQuotaIncrease Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuOptionInternal.QuotaIncrease { get => ((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuQuotaInternal)Quota).Increase; set => ((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuQuotaInternal)Quota).Increase = value ?? null /* model class */; }

        /// <summary>Internal Acessors for Readiness</summary>
        Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuReadiness Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuOptionInternal.Readiness { get => (this._readiness = this._readiness ?? new Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.RecommendVMSkuReadiness()); set { {_readiness = value;} } }

        /// <summary>Internal Acessors for Topology</summary>
        Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuTopology Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuOptionInternal.Topology { get => (this._topology = this._topology ?? new Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.RecommendVMSkuTopology()); set { {_topology = value;} } }

        /// <summary>Internal Acessors for TopologyAccelerator</summary>
        Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuAccelerator Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuOptionInternal.TopologyAccelerator { get => ((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuTopologyInternal)Topology).Accelerator; set => ((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuTopologyInternal)Topology).Accelerator = value ?? null /* model class */; }

        /// <summary>Backing field for <see cref="PerformanceEstimate" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuPerformanceEstimate _performanceEstimate;

        /// <summary>
        /// The advisory deployment throughput and per-request latency estimate for this option.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Origin(Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuPerformanceEstimate PerformanceEstimate { get => (this._performanceEstimate = this._performanceEstimate ?? new Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.RecommendVMSkuPerformanceEstimate()); set => this._performanceEstimate = value; }

        /// <summary>
        /// The estimated number of output tokens generated per second across the whole deployment.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Origin(Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.PropertyOrigin.Inlined)]
        public double? PerformanceEstimateDeploymentOutputTokensPerSecond { get => ((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuPerformanceEstimateInternal)PerformanceEstimate).DeploymentOutputTokensPerSecond; set => ((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuPerformanceEstimateInternal)PerformanceEstimate).DeploymentOutputTokensPerSecond = value ?? default(double); }

        /// <summary>The estimated time to first token for a single request, in milliseconds.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Origin(Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.PropertyOrigin.Inlined)]
        public double? PerformanceEstimateTtftMS { get => ((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuPerformanceEstimateInternal)PerformanceEstimate).TtftMS; set => ((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuPerformanceEstimateInternal)PerformanceEstimate).TtftMS = value ?? default(double); }

        /// <summary>Backing field for <see cref="Placement" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuPlacement _placement;

        /// <summary>
        /// The capacity placement evidence for this option. Returned only when `subscriptionOptions.includePlacement` is set.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Origin(Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuPlacement Placement { get => (this._placement = this._placement ?? new Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.RecommendVMSkuPlacement()); set => this._placement = value; }

        /// <summary>The reason the stage did not complete.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Origin(Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.PropertyOrigin.Inlined)]
        public string PlacementErrorCode { get => ((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuPlacementInternal)Placement).Code; set => ((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuPlacementInternal)Placement).Code = value ?? null; }

        /// <summary>A human-readable description of the error.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Origin(Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.PropertyOrigin.Inlined)]
        public string PlacementErrorMessage { get => ((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuPlacementInternal)Placement).Message; set => ((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuPlacementInternal)Placement).Message = value ?? null; }

        /// <summary>A human-readable explanation of the placement status.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Origin(Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.PropertyOrigin.Inlined)]
        public string PlacementReason { get => ((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuPlacementInternal)Placement).Reason; set => ((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuPlacementInternal)Placement).Reason = value ?? null; }

        /// <summary>The availability zones recommended for the deployment, in preference order.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Origin(Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.PropertyOrigin.Inlined)]
        public System.Collections.Generic.List<string> PlacementRecommendedAvailabilityZone { get => ((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuPlacementInternal)Placement).RecommendedAvailabilityZone; set => ((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuPlacementInternal)Placement).RecommendedAvailabilityZone = value ?? null /* arrayOf */; }

        /// <summary>The outcome of the placement query.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Origin(Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.PropertyOrigin.Inlined)]
        public string PlacementStatus { get => ((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuPlacementInternal)Placement).Status; set => ((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuPlacementInternal)Placement).Status = value ?? null; }

        /// <summary>Backing field for <see cref="Quota" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuQuota _quota;

        /// <summary>
        /// The subscription quota evidence for this option. Returned only when `subscriptionOptions.includeQuota` is set.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Origin(Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuQuota Quota { get => (this._quota = this._quota ?? new Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.RecommendVMSkuQuota()); set => this._quota = value; }

        /// <summary>The reason the stage did not complete.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Origin(Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.PropertyOrigin.Inlined)]
        public string QuotaErrorCode { get => ((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuQuotaInternal)Quota).Code; set => ((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuQuotaInternal)Quota).Code = value ?? null; }

        /// <summary>A human-readable description of the error.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Origin(Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.PropertyOrigin.Inlined)]
        public string QuotaErrorMessage { get => ((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuQuotaInternal)Quota).Message; set => ((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuQuotaInternal)Quota).Message = value ?? null; }

        /// <summary>The maximum number of replicas that can be deployed with the available quota.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Origin(Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.PropertyOrigin.Inlined)]
        public int? QuotaMaxAvailableReplicaCount { get => ((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuQuotaInternal)Quota).MaxAvailableReplicaCount; set => ((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuQuotaInternal)Quota).MaxAvailableReplicaCount = value ?? default(int); }

        /// <summary>A human-readable explanation of the quota status.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Origin(Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.PropertyOrigin.Inlined)]
        public string QuotaReason { get => ((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuQuotaInternal)Quota).Reason; set => ((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuQuotaInternal)Quota).Reason = value ?? null; }

        /// <summary>Whether subscription quota is sufficient for the requested deployment.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Origin(Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.PropertyOrigin.Inlined)]
        public string QuotaStatus { get => ((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuQuotaInternal)Quota).Status; set => ((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuQuotaInternal)Quota).Status = value ?? null; }

        /// <summary>Backing field for <see cref="Readiness" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuReadiness _readiness;

        /// <summary>How ready this option is to deploy.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Origin(Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuReadiness Readiness { get => (this._readiness = this._readiness ?? new Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.RecommendVMSkuReadiness()); set => this._readiness = value; }

        /// <summary>A human-readable explanation of the readiness status.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Origin(Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.PropertyOrigin.Inlined)]
        public string ReadinessReason { get => ((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuReadinessInternal)Readiness).Reason; set => ((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuReadinessInternal)Readiness).Reason = value ; }

        /// <summary>The current actionability of the recommendation.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Origin(Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.PropertyOrigin.Inlined)]
        public string ReadinessStatus { get => ((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuReadinessInternal)Readiness).Status; set => ((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuReadinessInternal)Readiness).Status = value ; }

        /// <summary>Backing field for <see cref="RecommendationRank" /> property.</summary>
        private int _recommendationRank;

        /// <summary>The rank of this option within the response, where 1 is the best match.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Origin(Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.PropertyOrigin.Owned)]
        public int RecommendationRank { get => this._recommendationRank; set => this._recommendationRank = value; }

        /// <summary>Backing field for <see cref="Topology" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuTopology _topology;

        /// <summary>The deployment topology for this option.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Origin(Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuTopology Topology { get => (this._topology = this._topology ?? new Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.RecommendVMSkuTopology()); set => this._topology = value; }

        /// <summary>The estimated number of virtual machine nodes required for a single replica.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Origin(Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.PropertyOrigin.Inlined)]
        public int TopologyEstimatedNodeCountPerReplica { get => ((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuTopologyInternal)Topology).EstimatedNodeCountPerReplica; set => ((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuTopologyInternal)Topology).EstimatedNodeCountPerReplica = value ; }

        /// <summary>The estimated total number of virtual machine nodes across all replicas.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Origin(Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.PropertyOrigin.Inlined)]
        public long TopologyEstimatedTotalNodeCount { get => ((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuTopologyInternal)Topology).EstimatedTotalNodeCount; set => ((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuTopologyInternal)Topology).EstimatedTotalNodeCount = value ; }

        /// <summary>Backing field for <see cref="VMSize" /> property.</summary>
        private string _vMSize;

        /// <summary>The Azure virtual machine size name, for example `Standard_NC24ads_A100_v4`.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Origin(Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.PropertyOrigin.Owned)]
        public string VMSize { get => this._vMSize; set => this._vMSize = value; }

        /// <summary>Creates an new <see cref="RecommendVMSkuOption" /> instance.</summary>
        public RecommendVMSkuOption()
        {

        }
    }
    /// One ranked virtual machine size recommendation.
    public partial interface IRecommendVMSkuOption :
        Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.IJsonSerializable
    {
        /// <summary>The number of accelerator devices in each virtual machine.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"The number of accelerator devices in each virtual machine.",
        SerializedName = @"countPerVm",
        PossibleTypes = new [] { typeof(int) })]
        int AcceleratorCountPerVM { get; set; }
        /// <summary>The memory capacity of a single accelerator device, in gibibytes.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"The memory capacity of a single accelerator device, in gibibytes.",
        SerializedName = @"memoryGiBPerAccelerator",
        PossibleTypes = new [] { typeof(int) })]
        int AcceleratorMemoryGiBPerAccelerator { get; set; }
        /// <summary>The accelerator model name, for example `A100` or `H100`.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"The accelerator model name, for example `A100` or `H100`.",
        SerializedName = @"model",
        PossibleTypes = new [] { typeof(string) })]
        string AcceleratorModel { get; set; }
        /// <summary>
        /// Whether the Azure Machine Learning model catalog recommends this virtual machine size for the model.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"Whether the Azure Machine Learning model catalog recommends this virtual machine size for the model.",
        SerializedName = @"azureMlRecommended",
        PossibleTypes = new [] { typeof(bool) })]
        bool? AzureMlRecommended { get; set; }
        /// <summary>How closely the benchmark evidence matches the recommended topology.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"How closely the benchmark evidence matches the recommended topology.",
        SerializedName = @"level",
        PossibleTypes = new [] { typeof(string) })]
        [global::Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.PSArgumentCompleterAttribute("Benchmarked", "TopologyMatched")]
        string BenchmarkLevel { get; set; }
        /// <summary>The model the benchmark was measured on.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"The model the benchmark was measured on.",
        SerializedName = @"benchmarkModel",
        PossibleTypes = new [] { typeof(string) })]
        string BenchmarkModel { get; set; }
        /// <summary>The model size class the benchmark covers, for example `70b`.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"The model size class the benchmark covers, for example `70b`.",
        SerializedName = @"modelClass",
        PossibleTypes = new [] { typeof(string) })]
        string BenchmarkModelClass { get; set; }
        /// <summary>The operating system the benchmark was measured on.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"The operating system the benchmark was measured on.",
        SerializedName = @"operatingSystem",
        PossibleTypes = new [] { typeof(string) })]
        string BenchmarkOperatingSystem { get; set; }
        /// <summary>
        /// The 99th-percentile time per output token observed in the benchmark, in milliseconds.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"The 99th-percentile time per output token observed in the benchmark, in milliseconds.",
        SerializedName = @"p99TpotMs",
        PossibleTypes = new [] { typeof(double) })]
        double? BenchmarkP99TpotMS { get; set; }
        /// <summary>
        /// The 99th-percentile time to first token observed in the benchmark, in milliseconds.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"The 99th-percentile time to first token observed in the benchmark, in milliseconds.",
        SerializedName = @"p99TtftMs",
        PossibleTypes = new [] { typeof(double) })]
        double? BenchmarkP99TtftMS { get; set; }
        /// <summary>The benchmark scenario, for example `Server` or `Offline`.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"The benchmark scenario, for example `Server` or `Offline`.",
        SerializedName = @"scenario",
        PossibleTypes = new [] { typeof(string) })]
        string BenchmarkScenario { get; set; }
        /// <summary>The serving software the benchmark was measured with.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"The serving software the benchmark was measured with.",
        SerializedName = @"software",
        PossibleTypes = new [] { typeof(string) })]
        string BenchmarkSoftware { get; set; }
        /// <summary>The identifier of the selected benchmark submission.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"The identifier of the selected benchmark submission.",
        SerializedName = @"submissionId",
        PossibleTypes = new [] { typeof(string) })]
        string BenchmarkSubmissionId { get; set; }
        /// <summary>The organization that published the benchmark submission.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"The organization that published the benchmark submission.",
        SerializedName = @"submitter",
        PossibleTypes = new [] { typeof(string) })]
        string BenchmarkSubmitter { get; set; }
        /// <summary>The number of submitters that published results for this configuration.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"The number of submitters that published results for this configuration.",
        SerializedName = @"submitterCount",
        PossibleTypes = new [] { typeof(int) })]
        int? BenchmarkSubmitterCount { get; set; }
        /// <summary>The system the benchmark was measured on.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"The system the benchmark was measured on.",
        SerializedName = @"system",
        PossibleTypes = new [] { typeof(string) })]
        string BenchmarkSystem { get; set; }
        /// <summary>The throughput observed in the benchmark submission.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"The throughput observed in the benchmark submission.",
        SerializedName = @"throughput",
        PossibleTypes = new [] { typeof(double) })]
        double? BenchmarkThroughput { get; set; }
        /// <summary>The unit the observed throughput is expressed in, for example `Tokens/s`.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"The unit the observed throughput is expressed in, for example `Tokens/s`.",
        SerializedName = @"throughputUnit",
        PossibleTypes = new [] { typeof(string) })]
        string BenchmarkThroughputUnit { get; set; }
        /// <summary>The weight data types used in the benchmark submission.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"The weight data types used in the benchmark submission.",
        SerializedName = @"weightDataTypes",
        PossibleTypes = new [] { typeof(string) })]
        string BenchmarkWeightDataType { get; set; }
        /// <summary>The ISO 4217 currency code all amounts in this object are expressed in.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"The ISO 4217 currency code all amounts in this object are expressed in.",
        SerializedName = @"currencyCode",
        PossibleTypes = new [] { typeof(string) })]
        string CostCurrencyCode { get; set; }
        /// <summary>The price per hour for the whole deployment, in the stated currency.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"The price per hour for the whole deployment, in the stated currency.",
        SerializedName = @"deploymentHourly",
        PossibleTypes = new [] { typeof(double) })]
        double CostDeploymentHourly { get; set; }
        /// <summary>The reason the stage did not complete.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"The reason the stage did not complete.",
        SerializedName = @"code",
        PossibleTypes = new [] { typeof(string) })]
        [global::Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.PSArgumentCompleterAttribute("TimedOut", "Throttled", "PartitionCapacityExceeded", "DependencyError", "DataUnavailable", "EvaluationBudgetExceeded")]
        string CostErrorCode { get; set; }
        /// <summary>A human-readable description of the error.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"A human-readable description of the error.",
        SerializedName = @"message",
        PossibleTypes = new [] { typeof(string) })]
        string CostErrorMessage { get; set; }
        /// <summary>The date and time the price was observed.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"The date and time the price was observed.",
        SerializedName = @"priceAsOf",
        PossibleTypes = new [] { typeof(global::System.DateTime) })]
        global::System.DateTime? CostPriceAsOf { get; set; }
        /// <summary>The source the price was resolved from.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"The source the price was resolved from.",
        SerializedName = @"source",
        PossibleTypes = new [] { typeof(string) })]
        [global::Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.PSArgumentCompleterAttribute("AzureRetail", "AzureSubscription", "StaticPreview")]
        string CostSource { get; set; }
        /// <summary>The price per hour for a single virtual machine, in the stated currency.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"The price per hour for a single virtual machine, in the stated currency.",
        SerializedName = @"vmHourly",
        PossibleTypes = new [] { typeof(double) })]
        double CostVMHourly { get; set; }
        /// <summary>A URL to the Azure documentation page for this virtual machine size.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"A URL to the Azure documentation page for this virtual machine size.",
        SerializedName = @"documentationUrl",
        PossibleTypes = new [] { typeof(string) })]
        string DocumentationUrl { get; set; }
        /// <summary>The individual quota limits that block the requested deployment.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"The individual quota limits that block the requested deployment.",
        SerializedName = @"limits",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuQuotaLimit) })]
        System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuQuotaLimit> IncreaseLimit { get; set; }
        /// <summary>A URL to the Azure portal page for submitting the quota increase.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"A URL to the Azure portal page for submitting the quota increase.",
        SerializedName = @"portalUrl",
        PossibleTypes = new [] { typeof(string) })]
        string IncreasePortalUrl { get; set; }
        /// <summary>
        /// The estimated number of output tokens generated per second across the whole deployment.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"The estimated number of output tokens generated per second across the whole deployment.",
        SerializedName = @"deploymentOutputTokensPerSecond",
        PossibleTypes = new [] { typeof(double) })]
        double? PerformanceEstimateDeploymentOutputTokensPerSecond { get; set; }
        /// <summary>The estimated time to first token for a single request, in milliseconds.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"The estimated time to first token for a single request, in milliseconds.",
        SerializedName = @"ttftMs",
        PossibleTypes = new [] { typeof(double) })]
        double? PerformanceEstimateTtftMS { get; set; }
        /// <summary>The reason the stage did not complete.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"The reason the stage did not complete.",
        SerializedName = @"code",
        PossibleTypes = new [] { typeof(string) })]
        [global::Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.PSArgumentCompleterAttribute("TimedOut", "Throttled", "PartitionCapacityExceeded", "DependencyError", "DataUnavailable", "EvaluationBudgetExceeded")]
        string PlacementErrorCode { get; set; }
        /// <summary>A human-readable description of the error.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"A human-readable description of the error.",
        SerializedName = @"message",
        PossibleTypes = new [] { typeof(string) })]
        string PlacementErrorMessage { get; set; }
        /// <summary>A human-readable explanation of the placement status.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"A human-readable explanation of the placement status.",
        SerializedName = @"reason",
        PossibleTypes = new [] { typeof(string) })]
        string PlacementReason { get; set; }
        /// <summary>The availability zones recommended for the deployment, in preference order.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"The availability zones recommended for the deployment, in preference order.",
        SerializedName = @"recommendedAvailabilityZones",
        PossibleTypes = new [] { typeof(string) })]
        System.Collections.Generic.List<string> PlacementRecommendedAvailabilityZone { get; set; }
        /// <summary>The outcome of the placement query.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"The outcome of the placement query.",
        SerializedName = @"status",
        PossibleTypes = new [] { typeof(string) })]
        [global::Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.PSArgumentCompleterAttribute("Evaluated", "Failed", "NotEvaluated", "Unsupported")]
        string PlacementStatus { get; set; }
        /// <summary>The reason the stage did not complete.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"The reason the stage did not complete.",
        SerializedName = @"code",
        PossibleTypes = new [] { typeof(string) })]
        [global::Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.PSArgumentCompleterAttribute("TimedOut", "Throttled", "PartitionCapacityExceeded", "DependencyError", "DataUnavailable", "EvaluationBudgetExceeded")]
        string QuotaErrorCode { get; set; }
        /// <summary>A human-readable description of the error.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"A human-readable description of the error.",
        SerializedName = @"message",
        PossibleTypes = new [] { typeof(string) })]
        string QuotaErrorMessage { get; set; }
        /// <summary>The maximum number of replicas that can be deployed with the available quota.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"The maximum number of replicas that can be deployed with the available quota.",
        SerializedName = @"maxAvailableReplicaCount",
        PossibleTypes = new [] { typeof(int) })]
        int? QuotaMaxAvailableReplicaCount { get; set; }
        /// <summary>A human-readable explanation of the quota status.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"A human-readable explanation of the quota status.",
        SerializedName = @"reason",
        PossibleTypes = new [] { typeof(string) })]
        string QuotaReason { get; set; }
        /// <summary>Whether subscription quota is sufficient for the requested deployment.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"Whether subscription quota is sufficient for the requested deployment.",
        SerializedName = @"status",
        PossibleTypes = new [] { typeof(string) })]
        [global::Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.PSArgumentCompleterAttribute("Available", "Unavailable", "Unknown")]
        string QuotaStatus { get; set; }
        /// <summary>A human-readable explanation of the readiness status.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"A human-readable explanation of the readiness status.",
        SerializedName = @"reason",
        PossibleTypes = new [] { typeof(string) })]
        string ReadinessReason { get; set; }
        /// <summary>The current actionability of the recommendation.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"The current actionability of the recommendation.",
        SerializedName = @"status",
        PossibleTypes = new [] { typeof(string) })]
        [global::Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.PSArgumentCompleterAttribute("ReadyToAttempt", "QuotaIncreaseRequired", "VerificationRequired", "Unavailable")]
        string ReadinessStatus { get; set; }
        /// <summary>The rank of this option within the response, where 1 is the best match.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"The rank of this option within the response, where 1 is the best match.",
        SerializedName = @"recommendationRank",
        PossibleTypes = new [] { typeof(int) })]
        int RecommendationRank { get; set; }
        /// <summary>The estimated number of virtual machine nodes required for a single replica.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"The estimated number of virtual machine nodes required for a single replica.",
        SerializedName = @"estimatedNodeCountPerReplica",
        PossibleTypes = new [] { typeof(int) })]
        int TopologyEstimatedNodeCountPerReplica { get; set; }
        /// <summary>The estimated total number of virtual machine nodes across all replicas.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"The estimated total number of virtual machine nodes across all replicas.",
        SerializedName = @"estimatedTotalNodeCount",
        PossibleTypes = new [] { typeof(long) })]
        long TopologyEstimatedTotalNodeCount { get; set; }
        /// <summary>The Azure virtual machine size name, for example `Standard_NC24ads_A100_v4`.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"The Azure virtual machine size name, for example `Standard_NC24ads_A100_v4`.",
        SerializedName = @"vmSize",
        PossibleTypes = new [] { typeof(string) })]
        string VMSize { get; set; }

    }
    /// One ranked virtual machine size recommendation.
    internal partial interface IRecommendVMSkuOptionInternal

    {
        /// <summary>The number of accelerator devices in each virtual machine.</summary>
        int AcceleratorCountPerVM { get; set; }
        /// <summary>The memory capacity of a single accelerator device, in gibibytes.</summary>
        int AcceleratorMemoryGiBPerAccelerator { get; set; }
        /// <summary>The accelerator model name, for example `A100` or `H100`.</summary>
        string AcceleratorModel { get; set; }
        /// <summary>
        /// Whether the Azure Machine Learning model catalog recommends this virtual machine size for the model.
        /// </summary>
        bool? AzureMlRecommended { get; set; }
        /// <summary>The external benchmark evidence selected for this option.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuBenchmark Benchmark { get; set; }
        /// <summary>How closely the benchmark evidence matches the recommended topology.</summary>
        [global::Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.PSArgumentCompleterAttribute("Benchmarked", "TopologyMatched")]
        string BenchmarkLevel { get; set; }
        /// <summary>The model the benchmark was measured on.</summary>
        string BenchmarkModel { get; set; }
        /// <summary>The model size class the benchmark covers, for example `70b`.</summary>
        string BenchmarkModelClass { get; set; }
        /// <summary>The operating system the benchmark was measured on.</summary>
        string BenchmarkOperatingSystem { get; set; }
        /// <summary>
        /// The 99th-percentile time per output token observed in the benchmark, in milliseconds.
        /// </summary>
        double? BenchmarkP99TpotMS { get; set; }
        /// <summary>
        /// The 99th-percentile time to first token observed in the benchmark, in milliseconds.
        /// </summary>
        double? BenchmarkP99TtftMS { get; set; }
        /// <summary>The benchmark scenario, for example `Server` or `Offline`.</summary>
        string BenchmarkScenario { get; set; }
        /// <summary>The serving software the benchmark was measured with.</summary>
        string BenchmarkSoftware { get; set; }
        /// <summary>The identifier of the selected benchmark submission.</summary>
        string BenchmarkSubmissionId { get; set; }
        /// <summary>The organization that published the benchmark submission.</summary>
        string BenchmarkSubmitter { get; set; }
        /// <summary>The number of submitters that published results for this configuration.</summary>
        int? BenchmarkSubmitterCount { get; set; }
        /// <summary>The system the benchmark was measured on.</summary>
        string BenchmarkSystem { get; set; }
        /// <summary>The throughput observed in the benchmark submission.</summary>
        double? BenchmarkThroughput { get; set; }
        /// <summary>The unit the observed throughput is expressed in, for example `Tokens/s`.</summary>
        string BenchmarkThroughputUnit { get; set; }
        /// <summary>The weight data types used in the benchmark submission.</summary>
        string BenchmarkWeightDataType { get; set; }
        /// <summary>The deployment cost for this option.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuCost Cost { get; set; }
        /// <summary>The ISO 4217 currency code all amounts in this object are expressed in.</summary>
        string CostCurrencyCode { get; set; }
        /// <summary>The price per hour for the whole deployment, in the stated currency.</summary>
        double CostDeploymentHourly { get; set; }
        /// <summary>
        /// The error that prevented subscription-scoped pricing from being resolved, if any.
        /// </summary>
        Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuStageError CostError { get; set; }
        /// <summary>The reason the stage did not complete.</summary>
        [global::Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.PSArgumentCompleterAttribute("TimedOut", "Throttled", "PartitionCapacityExceeded", "DependencyError", "DataUnavailable", "EvaluationBudgetExceeded")]
        string CostErrorCode { get; set; }
        /// <summary>A human-readable description of the error.</summary>
        string CostErrorMessage { get; set; }
        /// <summary>The date and time the price was observed.</summary>
        global::System.DateTime? CostPriceAsOf { get; set; }
        /// <summary>The source the price was resolved from.</summary>
        [global::Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.PSArgumentCompleterAttribute("AzureRetail", "AzureSubscription", "StaticPreview")]
        string CostSource { get; set; }
        /// <summary>The price per hour for a single virtual machine, in the stated currency.</summary>
        double CostVMHourly { get; set; }
        /// <summary>A URL to the Azure documentation page for this virtual machine size.</summary>
        string DocumentationUrl { get; set; }
        /// <summary>The individual quota limits that block the requested deployment.</summary>
        System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuQuotaLimit> IncreaseLimit { get; set; }
        /// <summary>A URL to the Azure portal page for submitting the quota increase.</summary>
        string IncreasePortalUrl { get; set; }
        /// <summary>
        /// The advisory deployment throughput and per-request latency estimate for this option.
        /// </summary>
        Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuPerformanceEstimate PerformanceEstimate { get; set; }
        /// <summary>
        /// The estimated number of output tokens generated per second across the whole deployment.
        /// </summary>
        double? PerformanceEstimateDeploymentOutputTokensPerSecond { get; set; }
        /// <summary>The estimated time to first token for a single request, in milliseconds.</summary>
        double? PerformanceEstimateTtftMS { get; set; }
        /// <summary>
        /// The capacity placement evidence for this option. Returned only when `subscriptionOptions.includePlacement` is set.
        /// </summary>
        Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuPlacement Placement { get; set; }
        /// <summary>The error that prevented placement from being evaluated, if any.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuStageError PlacementError { get; set; }
        /// <summary>The reason the stage did not complete.</summary>
        [global::Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.PSArgumentCompleterAttribute("TimedOut", "Throttled", "PartitionCapacityExceeded", "DependencyError", "DataUnavailable", "EvaluationBudgetExceeded")]
        string PlacementErrorCode { get; set; }
        /// <summary>A human-readable description of the error.</summary>
        string PlacementErrorMessage { get; set; }
        /// <summary>A human-readable explanation of the placement status.</summary>
        string PlacementReason { get; set; }
        /// <summary>The availability zones recommended for the deployment, in preference order.</summary>
        System.Collections.Generic.List<string> PlacementRecommendedAvailabilityZone { get; set; }
        /// <summary>The outcome of the placement query.</summary>
        [global::Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.PSArgumentCompleterAttribute("Evaluated", "Failed", "NotEvaluated", "Unsupported")]
        string PlacementStatus { get; set; }
        /// <summary>
        /// The subscription quota evidence for this option. Returned only when `subscriptionOptions.includeQuota` is set.
        /// </summary>
        Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuQuota Quota { get; set; }
        /// <summary>The error that prevented quota from being evaluated, if any.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuStageError QuotaError { get; set; }
        /// <summary>The reason the stage did not complete.</summary>
        [global::Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.PSArgumentCompleterAttribute("TimedOut", "Throttled", "PartitionCapacityExceeded", "DependencyError", "DataUnavailable", "EvaluationBudgetExceeded")]
        string QuotaErrorCode { get; set; }
        /// <summary>A human-readable description of the error.</summary>
        string QuotaErrorMessage { get; set; }
        /// <summary>The quota increase required before this option can be deployed.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuQuotaIncrease QuotaIncrease { get; set; }
        /// <summary>The maximum number of replicas that can be deployed with the available quota.</summary>
        int? QuotaMaxAvailableReplicaCount { get; set; }
        /// <summary>A human-readable explanation of the quota status.</summary>
        string QuotaReason { get; set; }
        /// <summary>Whether subscription quota is sufficient for the requested deployment.</summary>
        [global::Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.PSArgumentCompleterAttribute("Available", "Unavailable", "Unknown")]
        string QuotaStatus { get; set; }
        /// <summary>How ready this option is to deploy.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuReadiness Readiness { get; set; }
        /// <summary>A human-readable explanation of the readiness status.</summary>
        string ReadinessReason { get; set; }
        /// <summary>The current actionability of the recommendation.</summary>
        [global::Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.PSArgumentCompleterAttribute("ReadyToAttempt", "QuotaIncreaseRequired", "VerificationRequired", "Unavailable")]
        string ReadinessStatus { get; set; }
        /// <summary>The rank of this option within the response, where 1 is the best match.</summary>
        int RecommendationRank { get; set; }
        /// <summary>The deployment topology for this option.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuTopology Topology { get; set; }
        /// <summary>The accelerator hardware available in each virtual machine.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuAccelerator TopologyAccelerator { get; set; }
        /// <summary>The estimated number of virtual machine nodes required for a single replica.</summary>
        int TopologyEstimatedNodeCountPerReplica { get; set; }
        /// <summary>The estimated total number of virtual machine nodes across all replicas.</summary>
        long TopologyEstimatedTotalNodeCount { get; set; }
        /// <summary>The Azure virtual machine size name, for example `Standard_NC24ads_A100_v4`.</summary>
        string VMSize { get; set; }

    }
}