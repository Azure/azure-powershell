// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.
namespace Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models
{
    using static Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.Extensions;

    /// <summary>
    /// The recommended Azure virtual machine sizes for the workload, with the sizing calculation they were derived from.
    /// </summary>
    public partial class RecommendVMSkuResponse :
        Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuResponse,
        Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuResponseInternal
    {

        /// <summary>Where the context length was resolved from.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Origin(Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.PropertyOrigin.Inlined)]
        public string BasisContextLengthSource { get => ((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuSizingInternal)Sizing).BasisContextLengthSource; set => ((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuSizingInternal)Sizing).BasisContextLengthSource = value ; }

        /// <summary>How the model weight memory was calculated.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Origin(Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.PropertyOrigin.Inlined)]
        public string BasisModelWeightsCalculation { get => ((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuSizingInternal)Sizing).BasisModelWeightsCalculation; set => ((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuSizingInternal)Sizing).BasisModelWeightsCalculation = value ; }

        /// <summary>Where the model parameter count was resolved from.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Origin(Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.PropertyOrigin.Inlined)]
        public string BasisParameterCountSource { get => ((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuSizingInternal)Sizing).BasisParameterCountSource; set => ((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuSizingInternal)Sizing).BasisParameterCountSource = value ; }

        /// <summary>
        /// The key-value cache memory required for a single concurrent request, in gibibytes.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Origin(Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.PropertyOrigin.Inlined)]
        public double MemoryKvCacheGiBPerRequest { get => ((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuSizingInternal)Sizing).MemoryKvCacheGiBPerRequest; set => ((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuSizingInternal)Sizing).MemoryKvCacheGiBPerRequest = value ; }

        /// <summary>
        /// The key-value cache memory required for all concurrent requests on a replica, in gibibytes.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Origin(Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.PropertyOrigin.Inlined)]
        public double MemoryKvCacheGiBTotal { get => ((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuSizingInternal)Sizing).MemoryKvCacheGiBTotal; set => ((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuSizingInternal)Sizing).MemoryKvCacheGiBTotal = value ; }

        /// <summary>
        /// The combined model-weight and key-value cache memory required per replica, in gibibytes.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Origin(Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.PropertyOrigin.Inlined)]
        public double MemoryModelAndKvCacheGiB { get => ((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuSizingInternal)Sizing).MemoryModelAndKvCacheGiB; set => ((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuSizingInternal)Sizing).MemoryModelAndKvCacheGiB = value ; }

        /// <summary>The memory required for the model weights, in gibibytes.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Origin(Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.PropertyOrigin.Inlined)]
        public double MemoryModelWeightsGiB { get => ((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuSizingInternal)Sizing).MemoryModelWeightsGiB; set => ((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuSizingInternal)Sizing).MemoryModelWeightsGiB = value ; }

        /// <summary>Internal Acessors for Sizing</summary>
        Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuSizing Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuResponseInternal.Sizing { get => (this._sizing = this._sizing ?? new Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.RecommendVMSkuSizing()); set { {_sizing = value;} } }

        /// <summary>Internal Acessors for SizingBasis</summary>
        Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuSizingBasis Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuResponseInternal.SizingBasis { get => ((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuSizingInternal)Sizing).Basis; set => ((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuSizingInternal)Sizing).Basis = value ?? null /* model class */; }

        /// <summary>Internal Acessors for SizingMemory</summary>
        Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuMemory Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuResponseInternal.SizingMemory { get => ((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuSizingInternal)Sizing).Memory; set => ((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuSizingInternal)Sizing).Memory = value ?? null /* model class */; }

        /// <summary>Internal Acessors for SizingModel</summary>
        Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuSizingModel Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuResponseInternal.SizingModel { get => ((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuSizingInternal)Sizing).Model; set => ((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuSizingInternal)Sizing).Model = value ?? null /* model class */; }

        /// <summary>Internal Acessors for SizingWorkload</summary>
        Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuSizingWorkload Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuResponseInternal.SizingWorkload { get => ((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuSizingInternal)Sizing).Workload; set => ((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuSizingInternal)Sizing).Workload = value ?? null /* model class */; }

        /// <summary>The Hugging Face model identifier the sizing metadata was resolved from.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Origin(Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.PropertyOrigin.Inlined)]
        public string ModelHuggingFaceModelId { get => ((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuSizingInternal)Sizing).ModelHuggingFaceModelId; set => ((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuSizingInternal)Sizing).ModelHuggingFaceModelId = value ?? null; }

        /// <summary>The logical total model parameter count used for sizing.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Origin(Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.PropertyOrigin.Inlined)]
        public long ModelParameterCount { get => ((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuSizingInternal)Sizing).ModelParameterCount; set => ((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuSizingInternal)Sizing).ModelParameterCount = value ; }

        /// <summary>The precision the model weights were sized at.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Origin(Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.PropertyOrigin.Inlined)]
        public string ModelWeightPrecision { get => ((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuSizingInternal)Sizing).ModelWeightPrecision; set => ((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuSizingInternal)Sizing).ModelWeightPrecision = value ; }

        /// <summary>Backing field for <see cref="Option" /> property.</summary>
        private System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuOption> _option;

        /// <summary>
        /// The recommended virtual machine size options, ordered from the best to the worst match.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Origin(Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.PropertyOrigin.Owned)]
        public System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuOption> Option { get => this._option; set => this._option = value; }

        /// <summary>Backing field for <see cref="Sizing" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuSizing _sizing;

        /// <summary>The resolved workload sizing shared by every option.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Origin(Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuSizing Sizing { get => (this._sizing = this._sizing ?? new Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.RecommendVMSkuSizing()); set => this._sizing = value; }

        /// <summary>
        /// The context length, in tokens, used to size the key-value cache: the sum of `promptTokens` and `maxOutputTokens` when
        /// a token budget is supplied, otherwise the service default.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Origin(Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.PropertyOrigin.Inlined)]
        public int WorkloadContextLength { get => ((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuSizingInternal)Sizing).WorkloadContextLength; set => ((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuSizingInternal)Sizing).WorkloadContextLength = value ; }

        /// <summary>The maximum number of simultaneous inference requests handled by each replica.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Origin(Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.PropertyOrigin.Inlined)]
        public int WorkloadMaxConcurrentRequestsPerReplica { get => ((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuSizingInternal)Sizing).WorkloadMaxConcurrentRequestsPerReplica; set => ((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuSizingInternal)Sizing).WorkloadMaxConcurrentRequestsPerReplica = value ; }

        /// <summary>Creates an new <see cref="RecommendVMSkuResponse" /> instance.</summary>
        public RecommendVMSkuResponse()
        {

        }
    }
    /// The recommended Azure virtual machine sizes for the workload, with the sizing calculation they were derived from.
    public partial interface IRecommendVMSkuResponse :
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
        /// The recommended virtual machine size options, ordered from the best to the worst match.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"The recommended virtual machine size options, ordered from the best to the worst match.",
        SerializedName = @"options",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuOption) })]
        System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuOption> Option { get; set; }
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
    /// The recommended Azure virtual machine sizes for the workload, with the sizing calculation they were derived from.
    internal partial interface IRecommendVMSkuResponseInternal

    {
        /// <summary>Where the context length was resolved from.</summary>
        [global::Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.PSArgumentCompleterAttribute("Request", "Default")]
        string BasisContextLengthSource { get; set; }
        /// <summary>How the model weight memory was calculated.</summary>
        [global::Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.PSArgumentCompleterAttribute("ArtifactSize", "EstimatedFromParameterCount")]
        string BasisModelWeightsCalculation { get; set; }
        /// <summary>Where the model parameter count was resolved from.</summary>
        [global::Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.PSArgumentCompleterAttribute("Request", "HuggingFace")]
        string BasisParameterCountSource { get; set; }
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
        /// <summary>The Hugging Face model identifier the sizing metadata was resolved from.</summary>
        string ModelHuggingFaceModelId { get; set; }
        /// <summary>The logical total model parameter count used for sizing.</summary>
        long ModelParameterCount { get; set; }
        /// <summary>The precision the model weights were sized at.</summary>
        [global::Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.PSArgumentCompleterAttribute("FP32", "FP16", "BF16", "FP8", "INT8", "INT4", "FP4")]
        string ModelWeightPrecision { get; set; }
        /// <summary>
        /// The recommended virtual machine size options, ordered from the best to the worst match.
        /// </summary>
        System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuOption> Option { get; set; }
        /// <summary>The resolved workload sizing shared by every option.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuSizing Sizing { get; set; }
        /// <summary>The sources used for the sizing calculation.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuSizingBasis SizingBasis { get; set; }
        /// <summary>The memory calculation shared by every returned option.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuMemory SizingMemory { get; set; }
        /// <summary>The resolved model identity and weight precision.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuSizingModel SizingModel { get; set; }
        /// <summary>The resolved per-replica workload inputs used for memory sizing.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuSizingWorkload SizingWorkload { get; set; }
        /// <summary>
        /// The context length, in tokens, used to size the key-value cache: the sum of `promptTokens` and `maxOutputTokens` when
        /// a token budget is supplied, otherwise the service default.
        /// </summary>
        int WorkloadContextLength { get; set; }
        /// <summary>The maximum number of simultaneous inference requests handled by each replica.</summary>
        int WorkloadMaxConcurrentRequestsPerReplica { get; set; }

    }
}