// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.
namespace Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models
{
    using static Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.Extensions;

    /// <summary>Model inputs used for metadata resolution and memory sizing.</summary>
    public partial class RecommendVMSkuModel :
        Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuModel,
        Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuModelInternal
    {

        /// <summary>Backing field for <see cref="HeadDim" /> property.</summary>
        private int? _headDim;

        /// <summary>
        /// The attention head dimension, used for architecture-aware key-value cache sizing. Supply all architecture fields together
        /// with a parameter count.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Origin(Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.PropertyOrigin.Owned)]
        public int? HeadDim { get => this._headDim; set => this._headDim = value; }

        /// <summary>Backing field for <see cref="HuggingFaceModelId" /> property.</summary>
        private string _huggingFaceModelId;

        /// <summary>
        /// The Hugging Face model identifier, for example `meta-llama/Llama-3.1-70B-Instruct`.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Origin(Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.PropertyOrigin.Owned)]
        public string HuggingFaceModelId { get => this._huggingFaceModelId; set => this._huggingFaceModelId = value; }

        /// <summary>Backing field for <see cref="MaxContextLength" /> property.</summary>
        private int? _maxContextLength;

        /// <summary>
        /// The maximum context length the model supports, in tokens. Used only as an upper bound for the sizing context length when
        /// Hugging Face metadata provides no usable maximum.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Origin(Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.PropertyOrigin.Owned)]
        public int? MaxContextLength { get => this._maxContextLength; set => this._maxContextLength = value; }

        /// <summary>Backing field for <see cref="NumKeyValueHead" /> property.</summary>
        private int? _numKeyValueHead;

        /// <summary>
        /// The model key-value head count, used for architecture-aware key-value cache sizing. Supply all architecture fields together
        /// with a parameter count.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Origin(Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.PropertyOrigin.Owned)]
        public int? NumKeyValueHead { get => this._numKeyValueHead; set => this._numKeyValueHead = value; }

        /// <summary>Backing field for <see cref="NumLayer" /> property.</summary>
        private int? _numLayer;

        /// <summary>
        /// The model layer count, used for architecture-aware key-value cache sizing. Supply all architecture fields together with
        /// a parameter count.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Origin(Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.PropertyOrigin.Owned)]
        public int? NumLayer { get => this._numLayer; set => this._numLayer = value; }

        /// <summary>Backing field for <see cref="ParameterCount" /> property.</summary>
        private long? _parameterCount;

        /// <summary>
        /// The logical total model parameter count, including all mixture-of-experts experts. May be supplied with or without a model
        /// identifier.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Origin(Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.PropertyOrigin.Owned)]
        public long? ParameterCount { get => this._parameterCount; set => this._parameterCount = value; }

        /// <summary>Backing field for <see cref="WeightPrecision" /> property.</summary>
        private string _weightPrecision;

        /// <summary>The precision the model weights are served at. Matched case-insensitively.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Origin(Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.PropertyOrigin.Owned)]
        public string WeightPrecision { get => this._weightPrecision; set => this._weightPrecision = value; }

        /// <summary>Creates an new <see cref="RecommendVMSkuModel" /> instance.</summary>
        public RecommendVMSkuModel()
        {

        }
    }
    /// Model inputs used for metadata resolution and memory sizing.
    public partial interface IRecommendVMSkuModel :
        Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.IJsonSerializable
    {
        /// <summary>
        /// The attention head dimension, used for architecture-aware key-value cache sizing. Supply all architecture fields together
        /// with a parameter count.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"The attention head dimension, used for architecture-aware key-value cache sizing. Supply all architecture fields together with a parameter count.",
        SerializedName = @"headDim",
        PossibleTypes = new [] { typeof(int) })]
        int? HeadDim { get; set; }
        /// <summary>
        /// The Hugging Face model identifier, for example `meta-llama/Llama-3.1-70B-Instruct`.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"The Hugging Face model identifier, for example `meta-llama/Llama-3.1-70B-Instruct`.",
        SerializedName = @"huggingFaceModelId",
        PossibleTypes = new [] { typeof(string) })]
        string HuggingFaceModelId { get; set; }
        /// <summary>
        /// The maximum context length the model supports, in tokens. Used only as an upper bound for the sizing context length when
        /// Hugging Face metadata provides no usable maximum.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"The maximum context length the model supports, in tokens. Used only as an upper bound for the sizing context length when Hugging Face metadata provides no usable maximum.",
        SerializedName = @"maxContextLength",
        PossibleTypes = new [] { typeof(int) })]
        int? MaxContextLength { get; set; }
        /// <summary>
        /// The model key-value head count, used for architecture-aware key-value cache sizing. Supply all architecture fields together
        /// with a parameter count.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"The model key-value head count, used for architecture-aware key-value cache sizing. Supply all architecture fields together with a parameter count.",
        SerializedName = @"numKeyValueHeads",
        PossibleTypes = new [] { typeof(int) })]
        int? NumKeyValueHead { get; set; }
        /// <summary>
        /// The model layer count, used for architecture-aware key-value cache sizing. Supply all architecture fields together with
        /// a parameter count.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"The model layer count, used for architecture-aware key-value cache sizing. Supply all architecture fields together with a parameter count.",
        SerializedName = @"numLayers",
        PossibleTypes = new [] { typeof(int) })]
        int? NumLayer { get; set; }
        /// <summary>
        /// The logical total model parameter count, including all mixture-of-experts experts. May be supplied with or without a model
        /// identifier.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"The logical total model parameter count, including all mixture-of-experts experts. May be supplied with or without a model identifier.",
        SerializedName = @"parameterCount",
        PossibleTypes = new [] { typeof(long) })]
        long? ParameterCount { get; set; }
        /// <summary>The precision the model weights are served at. Matched case-insensitively.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"The precision the model weights are served at. Matched case-insensitively.",
        SerializedName = @"weightPrecision",
        PossibleTypes = new [] { typeof(string) })]
        [global::Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.PSArgumentCompleterAttribute("FP32", "FP16", "BF16", "FP8", "INT8", "INT4", "FP4")]
        string WeightPrecision { get; set; }

    }
    /// Model inputs used for metadata resolution and memory sizing.
    internal partial interface IRecommendVMSkuModelInternal

    {
        /// <summary>
        /// The attention head dimension, used for architecture-aware key-value cache sizing. Supply all architecture fields together
        /// with a parameter count.
        /// </summary>
        int? HeadDim { get; set; }
        /// <summary>
        /// The Hugging Face model identifier, for example `meta-llama/Llama-3.1-70B-Instruct`.
        /// </summary>
        string HuggingFaceModelId { get; set; }
        /// <summary>
        /// The maximum context length the model supports, in tokens. Used only as an upper bound for the sizing context length when
        /// Hugging Face metadata provides no usable maximum.
        /// </summary>
        int? MaxContextLength { get; set; }
        /// <summary>
        /// The model key-value head count, used for architecture-aware key-value cache sizing. Supply all architecture fields together
        /// with a parameter count.
        /// </summary>
        int? NumKeyValueHead { get; set; }
        /// <summary>
        /// The model layer count, used for architecture-aware key-value cache sizing. Supply all architecture fields together with
        /// a parameter count.
        /// </summary>
        int? NumLayer { get; set; }
        /// <summary>
        /// The logical total model parameter count, including all mixture-of-experts experts. May be supplied with or without a model
        /// identifier.
        /// </summary>
        long? ParameterCount { get; set; }
        /// <summary>The precision the model weights are served at. Matched case-insensitively.</summary>
        [global::Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.PSArgumentCompleterAttribute("FP32", "FP16", "BF16", "FP8", "INT8", "INT4", "FP4")]
        string WeightPrecision { get; set; }

    }
}