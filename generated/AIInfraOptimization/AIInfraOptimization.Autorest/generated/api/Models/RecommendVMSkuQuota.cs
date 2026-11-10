// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.
namespace Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models
{
    using static Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.Extensions;

    /// <summary>The subscription quota evidence for one virtual machine size option.</summary>
    public partial class RecommendVMSkuQuota :
        Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuQuota,
        Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuQuotaInternal
    {

        /// <summary>The reason the stage did not complete.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Origin(Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.PropertyOrigin.Inlined)]
        public string Code { get => ((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuStageErrorInternal)Error).Code; set => ((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuStageErrorInternal)Error).Code = value ?? null; }

        /// <summary>Backing field for <see cref="Error" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuStageError _error;

        /// <summary>The error that prevented quota from being evaluated, if any.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Origin(Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuStageError Error { get => (this._error = this._error ?? new Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.RecommendVMSkuStageError()); set => this._error = value; }

        /// <summary>Backing field for <see cref="Increase" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuQuotaIncrease _increase;

        /// <summary>The quota increase required before this option can be deployed.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Origin(Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuQuotaIncrease Increase { get => (this._increase = this._increase ?? new Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.RecommendVMSkuQuotaIncrease()); set => this._increase = value; }

        /// <summary>The individual quota limits that block the requested deployment.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Origin(Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.PropertyOrigin.Inlined)]
        public System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuQuotaLimit> IncreaseLimit { get => ((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuQuotaIncreaseInternal)Increase).Limit; set => ((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuQuotaIncreaseInternal)Increase).Limit = value ?? null /* arrayOf */; }

        /// <summary>A URL to the Azure portal page for submitting the quota increase.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Origin(Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.PropertyOrigin.Inlined)]
        public string IncreasePortalUrl { get => ((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuQuotaIncreaseInternal)Increase).PortalUrl; set => ((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuQuotaIncreaseInternal)Increase).PortalUrl = value ?? null; }

        /// <summary>Backing field for <see cref="MaxAvailableReplicaCount" /> property.</summary>
        private int? _maxAvailableReplicaCount;

        /// <summary>The maximum number of replicas that can be deployed with the available quota.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Origin(Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.PropertyOrigin.Owned)]
        public int? MaxAvailableReplicaCount { get => this._maxAvailableReplicaCount; set => this._maxAvailableReplicaCount = value; }

        /// <summary>A human-readable description of the error.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Origin(Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.PropertyOrigin.Inlined)]
        public string Message { get => ((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuStageErrorInternal)Error).Message; set => ((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuStageErrorInternal)Error).Message = value ?? null; }

        /// <summary>Internal Acessors for Error</summary>
        Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuStageError Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuQuotaInternal.Error { get => (this._error = this._error ?? new Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.RecommendVMSkuStageError()); set { {_error = value;} } }

        /// <summary>Internal Acessors for Increase</summary>
        Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuQuotaIncrease Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuQuotaInternal.Increase { get => (this._increase = this._increase ?? new Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.RecommendVMSkuQuotaIncrease()); set { {_increase = value;} } }

        /// <summary>Backing field for <see cref="Reason" /> property.</summary>
        private string _reason;

        /// <summary>A human-readable explanation of the quota status.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Origin(Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.PropertyOrigin.Owned)]
        public string Reason { get => this._reason; set => this._reason = value; }

        /// <summary>Backing field for <see cref="Status" /> property.</summary>
        private string _status;

        /// <summary>Whether subscription quota is sufficient for the requested deployment.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Origin(Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.PropertyOrigin.Owned)]
        public string Status { get => this._status; set => this._status = value; }

        /// <summary>Creates an new <see cref="RecommendVMSkuQuota" /> instance.</summary>
        public RecommendVMSkuQuota()
        {

        }
    }
    /// The subscription quota evidence for one virtual machine size option.
    public partial interface IRecommendVMSkuQuota :
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
        int? MaxAvailableReplicaCount { get; set; }
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
        string Reason { get; set; }
        /// <summary>Whether subscription quota is sufficient for the requested deployment.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"Whether subscription quota is sufficient for the requested deployment.",
        SerializedName = @"status",
        PossibleTypes = new [] { typeof(string) })]
        [global::Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.PSArgumentCompleterAttribute("Available", "Unavailable", "Unknown")]
        string Status { get; set; }

    }
    /// The subscription quota evidence for one virtual machine size option.
    internal partial interface IRecommendVMSkuQuotaInternal

    {
        /// <summary>The reason the stage did not complete.</summary>
        [global::Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.PSArgumentCompleterAttribute("TimedOut", "Throttled", "PartitionCapacityExceeded", "DependencyError", "DataUnavailable", "EvaluationBudgetExceeded")]
        string Code { get; set; }
        /// <summary>The error that prevented quota from being evaluated, if any.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuStageError Error { get; set; }
        /// <summary>The quota increase required before this option can be deployed.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuQuotaIncrease Increase { get; set; }
        /// <summary>The individual quota limits that block the requested deployment.</summary>
        System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuQuotaLimit> IncreaseLimit { get; set; }
        /// <summary>A URL to the Azure portal page for submitting the quota increase.</summary>
        string IncreasePortalUrl { get; set; }
        /// <summary>The maximum number of replicas that can be deployed with the available quota.</summary>
        int? MaxAvailableReplicaCount { get; set; }
        /// <summary>A human-readable description of the error.</summary>
        string Message { get; set; }
        /// <summary>A human-readable explanation of the quota status.</summary>
        string Reason { get; set; }
        /// <summary>Whether subscription quota is sufficient for the requested deployment.</summary>
        [global::Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.PSArgumentCompleterAttribute("Available", "Unavailable", "Unknown")]
        string Status { get; set; }

    }
}