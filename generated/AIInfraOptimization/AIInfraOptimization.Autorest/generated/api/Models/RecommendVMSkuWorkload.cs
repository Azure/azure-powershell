// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.
namespace Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models
{
    using static Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.Extensions;

    /// <summary>Inference workload assumptions that affect memory sizing.</summary>
    public partial class RecommendVMSkuWorkload :
        Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuWorkload,
        Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuWorkloadInternal
    {

        /// <summary>Backing field for <see cref="MaxConcurrentRequestsPerReplica" /> property.</summary>
        private int? _maxConcurrentRequestsPerReplica;

        /// <summary>
        /// The maximum number of simultaneous inference requests handled by each deployment replica.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Origin(Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.PropertyOrigin.Owned)]
        public int? MaxConcurrentRequestsPerReplica { get => this._maxConcurrentRequestsPerReplica; set => this._maxConcurrentRequestsPerReplica = value; }

        /// <summary>Internal Acessors for TokenBudget</summary>
        Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuTokenBudget Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuWorkloadInternal.TokenBudget { get => (this._tokenBudget = this._tokenBudget ?? new Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.RecommendVMSkuTokenBudget()); set { {_tokenBudget = value;} } }

        /// <summary>Backing field for <see cref="TokenBudget" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuTokenBudget _tokenBudget;

        /// <summary>The prompt and output token budget used for key-value cache sizing.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Origin(Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuTokenBudget TokenBudget { get => (this._tokenBudget = this._tokenBudget ?? new Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.RecommendVMSkuTokenBudget()); set => this._tokenBudget = value; }

        /// <summary>
        /// The maximum number of generated output tokens per inference request. Must be supplied together with `promptTokens`, and
        /// the two must total from 1 through 131072.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Origin(Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.PropertyOrigin.Inlined)]
        public int? TokenBudgetMaxOutputToken { get => ((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuTokenBudgetInternal)TokenBudget).MaxOutputToken; set => ((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuTokenBudgetInternal)TokenBudget).MaxOutputToken = value ?? default(int); }

        /// <summary>
        /// The number of prompt, or input, tokens per inference request. Must be supplied together with `maxOutputTokens`, and the
        /// two must total from 1 through 131072.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Origin(Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.PropertyOrigin.Inlined)]
        public int? TokenBudgetPromptToken { get => ((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuTokenBudgetInternal)TokenBudget).PromptToken; set => ((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuTokenBudgetInternal)TokenBudget).PromptToken = value ?? default(int); }

        /// <summary>Creates an new <see cref="RecommendVMSkuWorkload" /> instance.</summary>
        public RecommendVMSkuWorkload()
        {

        }
    }
    /// Inference workload assumptions that affect memory sizing.
    public partial interface IRecommendVMSkuWorkload :
        Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.IJsonSerializable
    {
        /// <summary>
        /// The maximum number of simultaneous inference requests handled by each deployment replica.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"The maximum number of simultaneous inference requests handled by each deployment replica.",
        SerializedName = @"maxConcurrentRequestsPerReplica",
        PossibleTypes = new [] { typeof(int) })]
        int? MaxConcurrentRequestsPerReplica { get; set; }
        /// <summary>
        /// The maximum number of generated output tokens per inference request. Must be supplied together with `promptTokens`, and
        /// the two must total from 1 through 131072.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"The maximum number of generated output tokens per inference request. Must be supplied together with `promptTokens`, and the two must total from 1 through 131072.",
        SerializedName = @"maxOutputTokens",
        PossibleTypes = new [] { typeof(int) })]
        int? TokenBudgetMaxOutputToken { get; set; }
        /// <summary>
        /// The number of prompt, or input, tokens per inference request. Must be supplied together with `maxOutputTokens`, and the
        /// two must total from 1 through 131072.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"The number of prompt, or input, tokens per inference request. Must be supplied together with `maxOutputTokens`, and the two must total from 1 through 131072.",
        SerializedName = @"promptTokens",
        PossibleTypes = new [] { typeof(int) })]
        int? TokenBudgetPromptToken { get; set; }

    }
    /// Inference workload assumptions that affect memory sizing.
    internal partial interface IRecommendVMSkuWorkloadInternal

    {
        /// <summary>
        /// The maximum number of simultaneous inference requests handled by each deployment replica.
        /// </summary>
        int? MaxConcurrentRequestsPerReplica { get; set; }
        /// <summary>The prompt and output token budget used for key-value cache sizing.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuTokenBudget TokenBudget { get; set; }
        /// <summary>
        /// The maximum number of generated output tokens per inference request. Must be supplied together with `promptTokens`, and
        /// the two must total from 1 through 131072.
        /// </summary>
        int? TokenBudgetMaxOutputToken { get; set; }
        /// <summary>
        /// The number of prompt, or input, tokens per inference request. Must be supplied together with `maxOutputTokens`, and the
        /// two must total from 1 through 131072.
        /// </summary>
        int? TokenBudgetPromptToken { get; set; }

    }
}