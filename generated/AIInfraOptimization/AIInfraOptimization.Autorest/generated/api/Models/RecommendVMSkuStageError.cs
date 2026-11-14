// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.
namespace Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models
{
    using static Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.Extensions;

    /// <summary>An error from an optional subscription-scoped recommendation stage.</summary>
    public partial class RecommendVMSkuStageError :
        Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuStageError,
        Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuStageErrorInternal
    {

        /// <summary>Backing field for <see cref="Code" /> property.</summary>
        private string _code;

        /// <summary>The reason the stage did not complete.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Origin(Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.PropertyOrigin.Owned)]
        public string Code { get => this._code; set => this._code = value; }

        /// <summary>Backing field for <see cref="Message" /> property.</summary>
        private string _message;

        /// <summary>A human-readable description of the error.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Origin(Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.PropertyOrigin.Owned)]
        public string Message { get => this._message; set => this._message = value; }

        /// <summary>Creates an new <see cref="RecommendVMSkuStageError" /> instance.</summary>
        public RecommendVMSkuStageError()
        {

        }
    }
    /// An error from an optional subscription-scoped recommendation stage.
    public partial interface IRecommendVMSkuStageError :
        Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.IJsonSerializable
    {
        /// <summary>The reason the stage did not complete.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"The reason the stage did not complete.",
        SerializedName = @"code",
        PossibleTypes = new [] { typeof(string) })]
        [global::Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.PSArgumentCompleterAttribute("TimedOut", "Throttled", "PartitionCapacityExceeded", "DependencyError", "DataUnavailable", "EvaluationBudgetExceeded")]
        string Code { get; set; }
        /// <summary>A human-readable description of the error.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"A human-readable description of the error.",
        SerializedName = @"message",
        PossibleTypes = new [] { typeof(string) })]
        string Message { get; set; }

    }
    /// An error from an optional subscription-scoped recommendation stage.
    internal partial interface IRecommendVMSkuStageErrorInternal

    {
        /// <summary>The reason the stage did not complete.</summary>
        [global::Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.PSArgumentCompleterAttribute("TimedOut", "Throttled", "PartitionCapacityExceeded", "DependencyError", "DataUnavailable", "EvaluationBudgetExceeded")]
        string Code { get; set; }
        /// <summary>A human-readable description of the error.</summary>
        string Message { get; set; }

    }
}