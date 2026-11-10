// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.
namespace Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models
{
    using static Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.Extensions;

    /// <summary>The per-request token budget used to size the inference key-value cache.</summary>
    public partial class RecommendVMSkuTokenBudget :
        Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuTokenBudget,
        Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuTokenBudgetInternal
    {

        /// <summary>Backing field for <see cref="MaxOutputToken" /> property.</summary>
        private int? _maxOutputToken;

        /// <summary>
        /// The maximum number of generated output tokens per inference request. Must be supplied together with `promptTokens`, and
        /// the two must total from 1 through 131072.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Origin(Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.PropertyOrigin.Owned)]
        public int? MaxOutputToken { get => this._maxOutputToken; set => this._maxOutputToken = value; }

        /// <summary>Backing field for <see cref="PromptToken" /> property.</summary>
        private int? _promptToken;

        /// <summary>
        /// The number of prompt, or input, tokens per inference request. Must be supplied together with `maxOutputTokens`, and the
        /// two must total from 1 through 131072.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Origin(Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.PropertyOrigin.Owned)]
        public int? PromptToken { get => this._promptToken; set => this._promptToken = value; }

        /// <summary>Creates an new <see cref="RecommendVMSkuTokenBudget" /> instance.</summary>
        public RecommendVMSkuTokenBudget()
        {

        }
    }
    /// The per-request token budget used to size the inference key-value cache.
    public partial interface IRecommendVMSkuTokenBudget :
        Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.IJsonSerializable
    {
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
        int? MaxOutputToken { get; set; }
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
        int? PromptToken { get; set; }

    }
    /// The per-request token budget used to size the inference key-value cache.
    internal partial interface IRecommendVMSkuTokenBudgetInternal

    {
        /// <summary>
        /// The maximum number of generated output tokens per inference request. Must be supplied together with `promptTokens`, and
        /// the two must total from 1 through 131072.
        /// </summary>
        int? MaxOutputToken { get; set; }
        /// <summary>
        /// The number of prompt, or input, tokens per inference request. Must be supplied together with `maxOutputTokens`, and the
        /// two must total from 1 through 131072.
        /// </summary>
        int? PromptToken { get; set; }

    }
}