// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.
namespace Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models
{
    using static Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.Extensions;

    /// <summary>The capacity placement evidence for one virtual machine size option.</summary>
    public partial class RecommendVMSkuPlacement :
        Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuPlacement,
        Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuPlacementInternal
    {

        /// <summary>The reason the stage did not complete.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Origin(Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.PropertyOrigin.Inlined)]
        public string Code { get => ((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuStageErrorInternal)Error).Code; set => ((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuStageErrorInternal)Error).Code = value ?? null; }

        /// <summary>Backing field for <see cref="Error" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuStageError _error;

        /// <summary>The error that prevented placement from being evaluated, if any.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Origin(Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuStageError Error { get => (this._error = this._error ?? new Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.RecommendVMSkuStageError()); set => this._error = value; }

        /// <summary>A human-readable description of the error.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Origin(Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.PropertyOrigin.Inlined)]
        public string Message { get => ((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuStageErrorInternal)Error).Message; set => ((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuStageErrorInternal)Error).Message = value ?? null; }

        /// <summary>Internal Acessors for Error</summary>
        Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuStageError Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuPlacementInternal.Error { get => (this._error = this._error ?? new Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.RecommendVMSkuStageError()); set { {_error = value;} } }

        /// <summary>Backing field for <see cref="Reason" /> property.</summary>
        private string _reason;

        /// <summary>A human-readable explanation of the placement status.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Origin(Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.PropertyOrigin.Owned)]
        public string Reason { get => this._reason; set => this._reason = value; }

        /// <summary>Backing field for <see cref="RecommendedAvailabilityZone" /> property.</summary>
        private System.Collections.Generic.List<string> _recommendedAvailabilityZone;

        /// <summary>The availability zones recommended for the deployment, in preference order.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Origin(Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.PropertyOrigin.Owned)]
        public System.Collections.Generic.List<string> RecommendedAvailabilityZone { get => this._recommendedAvailabilityZone; set => this._recommendedAvailabilityZone = value; }

        /// <summary>Backing field for <see cref="Status" /> property.</summary>
        private string _status;

        /// <summary>The outcome of the placement query.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Origin(Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.PropertyOrigin.Owned)]
        public string Status { get => this._status; set => this._status = value; }

        /// <summary>Creates an new <see cref="RecommendVMSkuPlacement" /> instance.</summary>
        public RecommendVMSkuPlacement()
        {

        }
    }
    /// The capacity placement evidence for one virtual machine size option.
    public partial interface IRecommendVMSkuPlacement :
        Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.IJsonSerializable
    {
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
        string Code { get; set; }
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
        string Message { get; set; }
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
        string Reason { get; set; }
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
        System.Collections.Generic.List<string> RecommendedAvailabilityZone { get; set; }
        /// <summary>The outcome of the placement query.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"The outcome of the placement query.",
        SerializedName = @"status",
        PossibleTypes = new [] { typeof(string) })]
        [global::Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.PSArgumentCompleterAttribute("Evaluated", "Failed", "NotEvaluated", "Unsupported")]
        string Status { get; set; }

    }
    /// The capacity placement evidence for one virtual machine size option.
    internal partial interface IRecommendVMSkuPlacementInternal

    {
        /// <summary>The reason the stage did not complete.</summary>
        [global::Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.PSArgumentCompleterAttribute("TimedOut", "Throttled", "PartitionCapacityExceeded", "DependencyError", "DataUnavailable", "EvaluationBudgetExceeded")]
        string Code { get; set; }
        /// <summary>The error that prevented placement from being evaluated, if any.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuStageError Error { get; set; }
        /// <summary>A human-readable description of the error.</summary>
        string Message { get; set; }
        /// <summary>A human-readable explanation of the placement status.</summary>
        string Reason { get; set; }
        /// <summary>The availability zones recommended for the deployment, in preference order.</summary>
        System.Collections.Generic.List<string> RecommendedAvailabilityZone { get; set; }
        /// <summary>The outcome of the placement query.</summary>
        [global::Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.PSArgumentCompleterAttribute("Evaluated", "Failed", "NotEvaluated", "Unsupported")]
        string Status { get; set; }

    }
}