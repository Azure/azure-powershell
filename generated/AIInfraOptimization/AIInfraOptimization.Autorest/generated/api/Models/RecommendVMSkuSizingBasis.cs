// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.
namespace Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models
{
    using static Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.Extensions;

    /// <summary>The sources used for the sizing calculation.</summary>
    public partial class RecommendVMSkuSizingBasis :
        Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuSizingBasis,
        Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuSizingBasisInternal
    {

        /// <summary>Backing field for <see cref="ContextLengthSource" /> property.</summary>
        private string _contextLengthSource;

        /// <summary>Where the context length was resolved from.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Origin(Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.PropertyOrigin.Owned)]
        public string ContextLengthSource { get => this._contextLengthSource; set => this._contextLengthSource = value; }

        /// <summary>Backing field for <see cref="ModelWeightsCalculation" /> property.</summary>
        private string _modelWeightsCalculation;

        /// <summary>How the model weight memory was calculated.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Origin(Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.PropertyOrigin.Owned)]
        public string ModelWeightsCalculation { get => this._modelWeightsCalculation; set => this._modelWeightsCalculation = value; }

        /// <summary>Backing field for <see cref="ParameterCountSource" /> property.</summary>
        private string _parameterCountSource;

        /// <summary>Where the model parameter count was resolved from.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Origin(Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.PropertyOrigin.Owned)]
        public string ParameterCountSource { get => this._parameterCountSource; set => this._parameterCountSource = value; }

        /// <summary>Creates an new <see cref="RecommendVMSkuSizingBasis" /> instance.</summary>
        public RecommendVMSkuSizingBasis()
        {

        }
    }
    /// The sources used for the sizing calculation.
    public partial interface IRecommendVMSkuSizingBasis :
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
        string ContextLengthSource { get; set; }
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
        string ModelWeightsCalculation { get; set; }
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
        string ParameterCountSource { get; set; }

    }
    /// The sources used for the sizing calculation.
    internal partial interface IRecommendVMSkuSizingBasisInternal

    {
        /// <summary>Where the context length was resolved from.</summary>
        [global::Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.PSArgumentCompleterAttribute("Request", "Default")]
        string ContextLengthSource { get; set; }
        /// <summary>How the model weight memory was calculated.</summary>
        [global::Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.PSArgumentCompleterAttribute("ArtifactSize", "EstimatedFromParameterCount")]
        string ModelWeightsCalculation { get; set; }
        /// <summary>Where the model parameter count was resolved from.</summary>
        [global::Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.PSArgumentCompleterAttribute("Request", "HuggingFace")]
        string ParameterCountSource { get; set; }

    }
}