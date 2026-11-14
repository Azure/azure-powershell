// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.
namespace Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models
{
    using static Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.Extensions;

    /// <summary>The resolved model identity and weight precision.</summary>
    public partial class RecommendVMSkuSizingModel :
        Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuSizingModel,
        Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuSizingModelInternal
    {

        /// <summary>Backing field for <see cref="HuggingFaceModelId" /> property.</summary>
        private string _huggingFaceModelId;

        /// <summary>The Hugging Face model identifier the sizing metadata was resolved from.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Origin(Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.PropertyOrigin.Owned)]
        public string HuggingFaceModelId { get => this._huggingFaceModelId; set => this._huggingFaceModelId = value; }

        /// <summary>Backing field for <see cref="ParameterCount" /> property.</summary>
        private long _parameterCount;

        /// <summary>The logical total model parameter count used for sizing.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Origin(Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.PropertyOrigin.Owned)]
        public long ParameterCount { get => this._parameterCount; set => this._parameterCount = value; }

        /// <summary>Backing field for <see cref="WeightPrecision" /> property.</summary>
        private string _weightPrecision;

        /// <summary>The precision the model weights were sized at.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Origin(Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.PropertyOrigin.Owned)]
        public string WeightPrecision { get => this._weightPrecision; set => this._weightPrecision = value; }

        /// <summary>Creates an new <see cref="RecommendVMSkuSizingModel" /> instance.</summary>
        public RecommendVMSkuSizingModel()
        {

        }
    }
    /// The resolved model identity and weight precision.
    public partial interface IRecommendVMSkuSizingModel :
        Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.IJsonSerializable
    {
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
        string HuggingFaceModelId { get; set; }
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
        long ParameterCount { get; set; }
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
        string WeightPrecision { get; set; }

    }
    /// The resolved model identity and weight precision.
    internal partial interface IRecommendVMSkuSizingModelInternal

    {
        /// <summary>The Hugging Face model identifier the sizing metadata was resolved from.</summary>
        string HuggingFaceModelId { get; set; }
        /// <summary>The logical total model parameter count used for sizing.</summary>
        long ParameterCount { get; set; }
        /// <summary>The precision the model weights were sized at.</summary>
        [global::Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.PSArgumentCompleterAttribute("FP32", "FP16", "BF16", "FP8", "INT8", "INT4", "FP4")]
        string WeightPrecision { get; set; }

    }
}