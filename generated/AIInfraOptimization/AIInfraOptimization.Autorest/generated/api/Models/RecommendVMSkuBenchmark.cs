// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.
namespace Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models
{
    using static Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.Extensions;

    /// <summary>The external benchmark evidence selected for one virtual machine size option.</summary>
    public partial class RecommendVMSkuBenchmark :
        Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuBenchmark,
        Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuBenchmarkInternal
    {

        /// <summary>Backing field for <see cref="BenchmarkModel" /> property.</summary>
        private string _benchmarkModel;

        /// <summary>The model the benchmark was measured on.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Origin(Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.PropertyOrigin.Owned)]
        public string BenchmarkModel { get => this._benchmarkModel; set => this._benchmarkModel = value; }

        /// <summary>Backing field for <see cref="Level" /> property.</summary>
        private string _level;

        /// <summary>How closely the benchmark evidence matches the recommended topology.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Origin(Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.PropertyOrigin.Owned)]
        public string Level { get => this._level; set => this._level = value; }

        /// <summary>Backing field for <see cref="ModelClass" /> property.</summary>
        private string _modelClass;

        /// <summary>The model size class the benchmark covers, for example `70b`.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Origin(Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.PropertyOrigin.Owned)]
        public string ModelClass { get => this._modelClass; set => this._modelClass = value; }

        /// <summary>Backing field for <see cref="OperatingSystem" /> property.</summary>
        private string _operatingSystem;

        /// <summary>The operating system the benchmark was measured on.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Origin(Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.PropertyOrigin.Owned)]
        public string OperatingSystem { get => this._operatingSystem; set => this._operatingSystem = value; }

        /// <summary>Backing field for <see cref="P99TpotMS" /> property.</summary>
        private double? _p99TpotMS;

        /// <summary>
        /// The 99th-percentile time per output token observed in the benchmark, in milliseconds.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Origin(Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.PropertyOrigin.Owned)]
        public double? P99TpotMS { get => this._p99TpotMS; set => this._p99TpotMS = value; }

        /// <summary>Backing field for <see cref="P99TtftMS" /> property.</summary>
        private double? _p99TtftMS;

        /// <summary>
        /// The 99th-percentile time to first token observed in the benchmark, in milliseconds.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Origin(Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.PropertyOrigin.Owned)]
        public double? P99TtftMS { get => this._p99TtftMS; set => this._p99TtftMS = value; }

        /// <summary>Backing field for <see cref="Scenario" /> property.</summary>
        private string _scenario;

        /// <summary>The benchmark scenario, for example `Server` or `Offline`.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Origin(Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.PropertyOrigin.Owned)]
        public string Scenario { get => this._scenario; set => this._scenario = value; }

        /// <summary>Backing field for <see cref="Software" /> property.</summary>
        private string _software;

        /// <summary>The serving software the benchmark was measured with.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Origin(Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.PropertyOrigin.Owned)]
        public string Software { get => this._software; set => this._software = value; }

        /// <summary>Backing field for <see cref="SubmissionId" /> property.</summary>
        private string _submissionId;

        /// <summary>The identifier of the selected benchmark submission.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Origin(Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.PropertyOrigin.Owned)]
        public string SubmissionId { get => this._submissionId; set => this._submissionId = value; }

        /// <summary>Backing field for <see cref="Submitter" /> property.</summary>
        private string _submitter;

        /// <summary>The organization that published the benchmark submission.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Origin(Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.PropertyOrigin.Owned)]
        public string Submitter { get => this._submitter; set => this._submitter = value; }

        /// <summary>Backing field for <see cref="SubmitterCount" /> property.</summary>
        private int _submitterCount;

        /// <summary>The number of submitters that published results for this configuration.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Origin(Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.PropertyOrigin.Owned)]
        public int SubmitterCount { get => this._submitterCount; set => this._submitterCount = value; }

        /// <summary>Backing field for <see cref="System" /> property.</summary>
        private string _system;

        /// <summary>The system the benchmark was measured on.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Origin(Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.PropertyOrigin.Owned)]
        public string System { get => this._system; set => this._system = value; }

        /// <summary>Backing field for <see cref="Throughput" /> property.</summary>
        private double? _throughput;

        /// <summary>The throughput observed in the benchmark submission.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Origin(Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.PropertyOrigin.Owned)]
        public double? Throughput { get => this._throughput; set => this._throughput = value; }

        /// <summary>Backing field for <see cref="ThroughputUnit" /> property.</summary>
        private string _throughputUnit;

        /// <summary>The unit the observed throughput is expressed in, for example `Tokens/s`.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Origin(Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.PropertyOrigin.Owned)]
        public string ThroughputUnit { get => this._throughputUnit; set => this._throughputUnit = value; }

        /// <summary>Backing field for <see cref="WeightDataType" /> property.</summary>
        private string _weightDataType;

        /// <summary>The weight data types used in the benchmark submission.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Origin(Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.PropertyOrigin.Owned)]
        public string WeightDataType { get => this._weightDataType; set => this._weightDataType = value; }

        /// <summary>Creates an new <see cref="RecommendVMSkuBenchmark" /> instance.</summary>
        public RecommendVMSkuBenchmark()
        {

        }
    }
    /// The external benchmark evidence selected for one virtual machine size option.
    public partial interface IRecommendVMSkuBenchmark :
        Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.IJsonSerializable
    {
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
        /// <summary>How closely the benchmark evidence matches the recommended topology.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"How closely the benchmark evidence matches the recommended topology.",
        SerializedName = @"level",
        PossibleTypes = new [] { typeof(string) })]
        [global::Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.PSArgumentCompleterAttribute("Benchmarked", "TopologyMatched")]
        string Level { get; set; }
        /// <summary>The model size class the benchmark covers, for example `70b`.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"The model size class the benchmark covers, for example `70b`.",
        SerializedName = @"modelClass",
        PossibleTypes = new [] { typeof(string) })]
        string ModelClass { get; set; }
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
        string OperatingSystem { get; set; }
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
        double? P99TpotMS { get; set; }
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
        double? P99TtftMS { get; set; }
        /// <summary>The benchmark scenario, for example `Server` or `Offline`.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"The benchmark scenario, for example `Server` or `Offline`.",
        SerializedName = @"scenario",
        PossibleTypes = new [] { typeof(string) })]
        string Scenario { get; set; }
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
        string Software { get; set; }
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
        string SubmissionId { get; set; }
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
        string Submitter { get; set; }
        /// <summary>The number of submitters that published results for this configuration.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"The number of submitters that published results for this configuration.",
        SerializedName = @"submitterCount",
        PossibleTypes = new [] { typeof(int) })]
        int SubmitterCount { get; set; }
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
        string System { get; set; }
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
        double? Throughput { get; set; }
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
        string ThroughputUnit { get; set; }
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
        string WeightDataType { get; set; }

    }
    /// The external benchmark evidence selected for one virtual machine size option.
    internal partial interface IRecommendVMSkuBenchmarkInternal

    {
        /// <summary>The model the benchmark was measured on.</summary>
        string BenchmarkModel { get; set; }
        /// <summary>How closely the benchmark evidence matches the recommended topology.</summary>
        [global::Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.PSArgumentCompleterAttribute("Benchmarked", "TopologyMatched")]
        string Level { get; set; }
        /// <summary>The model size class the benchmark covers, for example `70b`.</summary>
        string ModelClass { get; set; }
        /// <summary>The operating system the benchmark was measured on.</summary>
        string OperatingSystem { get; set; }
        /// <summary>
        /// The 99th-percentile time per output token observed in the benchmark, in milliseconds.
        /// </summary>
        double? P99TpotMS { get; set; }
        /// <summary>
        /// The 99th-percentile time to first token observed in the benchmark, in milliseconds.
        /// </summary>
        double? P99TtftMS { get; set; }
        /// <summary>The benchmark scenario, for example `Server` or `Offline`.</summary>
        string Scenario { get; set; }
        /// <summary>The serving software the benchmark was measured with.</summary>
        string Software { get; set; }
        /// <summary>The identifier of the selected benchmark submission.</summary>
        string SubmissionId { get; set; }
        /// <summary>The organization that published the benchmark submission.</summary>
        string Submitter { get; set; }
        /// <summary>The number of submitters that published results for this configuration.</summary>
        int SubmitterCount { get; set; }
        /// <summary>The system the benchmark was measured on.</summary>
        string System { get; set; }
        /// <summary>The throughput observed in the benchmark submission.</summary>
        double? Throughput { get; set; }
        /// <summary>The unit the observed throughput is expressed in, for example `Tokens/s`.</summary>
        string ThroughputUnit { get; set; }
        /// <summary>The weight data types used in the benchmark submission.</summary>
        string WeightDataType { get; set; }

    }
}