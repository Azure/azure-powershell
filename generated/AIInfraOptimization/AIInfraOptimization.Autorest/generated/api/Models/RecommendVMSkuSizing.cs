// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.
namespace Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models
{
    using static Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.Extensions;

    /// <summary>The resolved workload sizing shared by every recommended option.</summary>
    public partial class RecommendVMSkuSizing :
        Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuSizing,
        Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuSizingInternal
    {

        /// <summary>Backing field for <see cref="Basis" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuSizingBasis _basis;

        /// <summary>The sources used for the sizing calculation.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Origin(Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuSizingBasis Basis { get => (this._basis = this._basis ?? new Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.RecommendVMSkuSizingBasis()); set => this._basis = value; }

        /// <summary>Where the context length was resolved from.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Origin(Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.PropertyOrigin.Inlined)]
        public string BasisContextLengthSource { get => ((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuSizingBasisInternal)Basis).ContextLengthSource; set => ((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuSizingBasisInternal)Basis).ContextLengthSource = value ; }

        /// <summary>How the model weight memory was calculated.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Origin(Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.PropertyOrigin.Inlined)]
        public string BasisModelWeightsCalculation { get => ((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuSizingBasisInternal)Basis).ModelWeightsCalculation; set => ((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuSizingBasisInternal)Basis).ModelWeightsCalculation = value ; }

        /// <summary>Where the model parameter count was resolved from.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Origin(Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.PropertyOrigin.Inlined)]
        public string BasisParameterCountSource { get => ((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuSizingBasisInternal)Basis).ParameterCountSource; set => ((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuSizingBasisInternal)Basis).ParameterCountSource = value ; }

        /// <summary>Backing field for <see cref="Memory" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuMemory _memory;

        /// <summary>The memory calculation shared by every returned option.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Origin(Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuMemory Memory { get => (this._memory = this._memory ?? new Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.RecommendVMSkuMemory()); set => this._memory = value; }

        /// <summary>
        /// The key-value cache memory required for a single concurrent request, in gibibytes.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Origin(Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.PropertyOrigin.Inlined)]
        public double MemoryKvCacheGiBPerRequest { get => ((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuMemoryInternal)Memory).KvCacheGiBPerRequest; set => ((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuMemoryInternal)Memory).KvCacheGiBPerRequest = value ; }

        /// <summary>
        /// The key-value cache memory required for all concurrent requests on a replica, in gibibytes.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Origin(Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.PropertyOrigin.Inlined)]
        public double MemoryKvCacheGiBTotal { get => ((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuMemoryInternal)Memory).KvCacheGiBTotal; set => ((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuMemoryInternal)Memory).KvCacheGiBTotal = value ; }

        /// <summary>
        /// The combined model-weight and key-value cache memory required per replica, in gibibytes.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Origin(Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.PropertyOrigin.Inlined)]
        public double MemoryModelAndKvCacheGiB { get => ((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuMemoryInternal)Memory).ModelAndKvCacheGiB; set => ((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuMemoryInternal)Memory).ModelAndKvCacheGiB = value ; }

        /// <summary>The memory required for the model weights, in gibibytes.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Origin(Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.PropertyOrigin.Inlined)]
        public double MemoryModelWeightsGiB { get => ((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuMemoryInternal)Memory).ModelWeightsGiB; set => ((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuMemoryInternal)Memory).ModelWeightsGiB = value ; }

        /// <summary>Internal Acessors for Basis</summary>
        Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuSizingBasis Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuSizingInternal.Basis { get => (this._basis = this._basis ?? new Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.RecommendVMSkuSizingBasis()); set { {_basis = value;} } }

        /// <summary>Internal Acessors for Memory</summary>
        Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuMemory Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuSizingInternal.Memory { get => (this._memory = this._memory ?? new Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.RecommendVMSkuMemory()); set { {_memory = value;} } }

        /// <summary>Internal Acessors for Model</summary>
        Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuSizingModel Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuSizingInternal.Model { get => (this._model = this._model ?? new Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.RecommendVMSkuSizingModel()); set { {_model = value;} } }

        /// <summary>Internal Acessors for Workload</summary>
        Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuSizingWorkload Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuSizingInternal.Workload { get => (this._workload = this._workload ?? new Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.RecommendVMSkuSizingWorkload()); set { {_workload = value;} } }

        /// <summary>Backing field for <see cref="Model" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuSizingModel _model;

        /// <summary>The resolved model identity and weight precision.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Origin(Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuSizingModel Model { get => (this._model = this._model ?? new Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.RecommendVMSkuSizingModel()); set => this._model = value; }

        /// <summary>The Hugging Face model identifier the sizing metadata was resolved from.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Origin(Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.PropertyOrigin.Inlined)]
        public string ModelHuggingFaceModelId { get => ((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuSizingModelInternal)Model).HuggingFaceModelId; set => ((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuSizingModelInternal)Model).HuggingFaceModelId = value ?? null; }

        /// <summary>The logical total model parameter count used for sizing.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Origin(Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.PropertyOrigin.Inlined)]
        public long ModelParameterCount { get => ((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuSizingModelInternal)Model).ParameterCount; set => ((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuSizingModelInternal)Model).ParameterCount = value ; }

        /// <summary>The precision the model weights were sized at.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Origin(Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.PropertyOrigin.Inlined)]
        public string ModelWeightPrecision { get => ((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuSizingModelInternal)Model).WeightPrecision; set => ((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuSizingModelInternal)Model).WeightPrecision = value ; }

        /// <summary>Backing field for <see cref="Workload" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuSizingWorkload _workload;

        /// <summary>The resolved per-replica workload inputs used for memory sizing.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Origin(Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuSizingWorkload Workload { get => (this._workload = this._workload ?? new Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.RecommendVMSkuSizingWorkload()); set => this._workload = value; }

        /// <summary>
        /// The context length, in tokens, used to size the key-value cache: the sum of `promptTokens` and `maxOutputTokens` when
        /// a token budget is supplied, otherwise the service default.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Origin(Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.PropertyOrigin.Inlined)]
        public int WorkloadContextLength { get => ((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuSizingWorkloadInternal)Workload).ContextLength; set => ((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuSizingWorkloadInternal)Workload).ContextLength = value ; }

        /// <summary>The maximum number of simultaneous inference requests handled by each replica.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Origin(Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.PropertyOrigin.Inlined)]
        public int WorkloadMaxConcurrentRequestsPerReplica { get => ((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuSizingWorkloadInternal)Workload).MaxConcurrentRequestsPerReplica; set => ((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuSizingWorkloadInternal)Workload).MaxConcurrentRequestsPerReplica = value ; }

        /// <summary>Creates an new <see cref="RecommendVMSkuSizing" /> instance.</summary>
        public RecommendVMSkuSizing()
        {

        }
    }
    /// The resolved workload sizing shared by every recommended option.
    public partial interface IRecommendVMSkuSizing :
        Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.IJsonSerializable
    {
        /// <summary>Where the context length was resolved from.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"Where the context length was resolved from.",
        SerializedName = @"contextLengthSource",
        PossibleTypes = new [] { typeof(string) })]
        [global::Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.PSArgumentCompleterAttribute("Request", "Default")]
        string BasisContextLengthSource { get; set; }
        /// <summary>How the model weight memory was calculated.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"How the model weight memory was calculated.",
        SerializedName = @"modelWeightsCalculation",
        PossibleTypes = new [] { typeof(string) })]
        [global::Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.PSArgumentCompleterAttribute("ArtifactSize", "EstimatedFromParameterCount")]
        string BasisModelWeightsCalculation { get; set; }
        /// <summary>Where the model parameter count was resolved from.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"Where the model parameter count was resolved from.",
        SerializedName = @"parameterCountSource",
        PossibleTypes = new [] { typeof(string) })]
        [global::Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.PSArgumentCompleterAttribute("Request", "HuggingFace")]
        string BasisParameterCountSource { get; set; }
        /// <summary>
        /// The key-value cache memory required for a single concurrent request, in gibibytes.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"The key-value cache memory required for a single concurrent request, in gibibytes.",
        SerializedName = @"kvCacheGiBPerRequest",
        PossibleTypes = new [] { typeof(double) })]
        double MemoryKvCacheGiBPerRequest { get; set; }
        /// <summary>
        /// The key-value cache memory required for all concurrent requests on a replica, in gibibytes.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"The key-value cache memory required for all concurrent requests on a replica, in gibibytes.",
        SerializedName = @"kvCacheGiBTotal",
        PossibleTypes = new [] { typeof(double) })]
        double MemoryKvCacheGiBTotal { get; set; }
        /// <summary>
        /// The combined model-weight and key-value cache memory required per replica, in gibibytes.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"The combined model-weight and key-value cache memory required per replica, in gibibytes.",
        SerializedName = @"modelAndKvCacheGiB",
        PossibleTypes = new [] { typeof(double) })]
        double MemoryModelAndKvCacheGiB { get; set; }
        /// <summary>The memory required for the model weights, in gibibytes.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"The memory required for the model weights, in gibibytes.",
        SerializedName = @"modelWeightsGiB",
        PossibleTypes = new [] { typeof(double) })]
        double MemoryModelWeightsGiB { get; set; }
        /// <summary>The Hugging Face model identifier the sizing metadata was resolved from.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"The Hugging Face model identifier the sizing metadata was resolved from.",
        SerializedName = @"huggingFaceModelId",
        PossibleTypes = new [] { typeof(string) })]
        string ModelHuggingFaceModelId { get; set; }
        /// <summary>The logical total model parameter count used for sizing.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"The logical total model parameter count used for sizing.",
        SerializedName = @"parameterCount",
        PossibleTypes = new [] { typeof(long) })]
        long ModelParameterCount { get; set; }
        /// <summary>The precision the model weights were sized at.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"The precision the model weights were sized at.",
        SerializedName = @"weightPrecision",
        PossibleTypes = new [] { typeof(string) })]
        [global::Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.PSArgumentCompleterAttribute("FP32", "FP16", "BF16", "FP8", "INT8", "INT4", "FP4")]
        string ModelWeightPrecision { get; set; }
        /// <summary>
        /// The context length, in tokens, used to size the key-value cache: the sum of `promptTokens` and `maxOutputTokens` when
        /// a token budget is supplied, otherwise the service default.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"The context length, in tokens, used to size the key-value cache: the sum of `promptTokens` and `maxOutputTokens` when a token budget is supplied, otherwise the service default.",
        SerializedName = @"contextLength",
        PossibleTypes = new [] { typeof(int) })]
        int WorkloadContextLength { get; set; }
        /// <summary>The maximum number of simultaneous inference requests handled by each replica.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"The maximum number of simultaneous inference requests handled by each replica.",
        SerializedName = @"maxConcurrentRequestsPerReplica",
        PossibleTypes = new [] { typeof(int) })]
        int WorkloadMaxConcurrentRequestsPerReplica { get; set; }

    }
    /// The resolved workload sizing shared by every recommended option.
    internal partial interface IRecommendVMSkuSizingInternal

    {
        /// <summary>The sources used for the sizing calculation.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuSizingBasis Basis { get; set; }
        /// <summary>Where the context length was resolved from.</summary>
        [global::Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.PSArgumentCompleterAttribute("Request", "Default")]
        string BasisContextLengthSource { get; set; }
        /// <summary>How the model weight memory was calculated.</summary>
        [global::Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.PSArgumentCompleterAttribute("ArtifactSize", "EstimatedFromParameterCount")]
        string BasisModelWeightsCalculation { get; set; }
        /// <summary>Where the model parameter count was resolved from.</summary>
        [global::Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.PSArgumentCompleterAttribute("Request", "HuggingFace")]
        string BasisParameterCountSource { get; set; }
        /// <summary>The memory calculation shared by every returned option.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuMemory Memory { get; set; }
        /// <summary>
        /// The key-value cache memory required for a single concurrent request, in gibibytes.
        /// </summary>
        double MemoryKvCacheGiBPerRequest { get; set; }
        /// <summary>
        /// The key-value cache memory required for all concurrent requests on a replica, in gibibytes.
        /// </summary>
        double MemoryKvCacheGiBTotal { get; set; }
        /// <summary>
        /// The combined model-weight and key-value cache memory required per replica, in gibibytes.
        /// </summary>
        double MemoryModelAndKvCacheGiB { get; set; }
        /// <summary>The memory required for the model weights, in gibibytes.</summary>
        double MemoryModelWeightsGiB { get; set; }
        /// <summary>The resolved model identity and weight precision.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuSizingModel Model { get; set; }
        /// <summary>The Hugging Face model identifier the sizing metadata was resolved from.</summary>
        string ModelHuggingFaceModelId { get; set; }
        /// <summary>The logical total model parameter count used for sizing.</summary>
        long ModelParameterCount { get; set; }
        /// <summary>The precision the model weights were sized at.</summary>
        [global::Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.PSArgumentCompleterAttribute("FP32", "FP16", "BF16", "FP8", "INT8", "INT4", "FP4")]
        string ModelWeightPrecision { get; set; }
        /// <summary>The resolved per-replica workload inputs used for memory sizing.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuSizingWorkload Workload { get; set; }
        /// <summary>
        /// The context length, in tokens, used to size the key-value cache: the sum of `promptTokens` and `maxOutputTokens` when
        /// a token budget is supplied, otherwise the service default.
        /// </summary>
        int WorkloadContextLength { get; set; }
        /// <summary>The maximum number of simultaneous inference requests handled by each replica.</summary>
        int WorkloadMaxConcurrentRequestsPerReplica { get; set; }

    }
}