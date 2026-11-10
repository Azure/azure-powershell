// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.
namespace Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models
{
    using static Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.Extensions;

    /// <summary>The resolved per-replica workload inputs used for memory sizing.</summary>
    public partial class RecommendVMSkuSizingWorkload :
        Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuSizingWorkload,
        Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuSizingWorkloadInternal
    {

        /// <summary>Backing field for <see cref="ContextLength" /> property.</summary>
        private int _contextLength;

        /// <summary>
        /// The context length, in tokens, used to size the key-value cache: the sum of `promptTokens` and `maxOutputTokens` when
        /// a token budget is supplied, otherwise the service default.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Origin(Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.PropertyOrigin.Owned)]
        public int ContextLength { get => this._contextLength; set => this._contextLength = value; }

        /// <summary>Backing field for <see cref="MaxConcurrentRequestsPerReplica" /> property.</summary>
        private int _maxConcurrentRequestsPerReplica;

        /// <summary>The maximum number of simultaneous inference requests handled by each replica.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Origin(Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.PropertyOrigin.Owned)]
        public int MaxConcurrentRequestsPerReplica { get => this._maxConcurrentRequestsPerReplica; set => this._maxConcurrentRequestsPerReplica = value; }

        /// <summary>Creates an new <see cref="RecommendVMSkuSizingWorkload" /> instance.</summary>
        public RecommendVMSkuSizingWorkload()
        {

        }
    }
    /// The resolved per-replica workload inputs used for memory sizing.
    public partial interface IRecommendVMSkuSizingWorkload :
        Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.IJsonSerializable
    {
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
        int ContextLength { get; set; }
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
        int MaxConcurrentRequestsPerReplica { get; set; }

    }
    /// The resolved per-replica workload inputs used for memory sizing.
    internal partial interface IRecommendVMSkuSizingWorkloadInternal

    {
        /// <summary>
        /// The context length, in tokens, used to size the key-value cache: the sum of `promptTokens` and `maxOutputTokens` when
        /// a token budget is supplied, otherwise the service default.
        /// </summary>
        int ContextLength { get; set; }
        /// <summary>The maximum number of simultaneous inference requests handled by each replica.</summary>
        int MaxConcurrentRequestsPerReplica { get; set; }

    }
}