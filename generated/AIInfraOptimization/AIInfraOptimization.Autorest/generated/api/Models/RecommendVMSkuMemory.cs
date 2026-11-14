// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.
namespace Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models
{
    using static Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.Extensions;

    /// <summary>The memory calculation shared by every returned option.</summary>
    public partial class RecommendVMSkuMemory :
        Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuMemory,
        Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuMemoryInternal
    {

        /// <summary>Backing field for <see cref="KvCacheGiBPerRequest" /> property.</summary>
        private double _kvCacheGiBPerRequest;

        /// <summary>
        /// The key-value cache memory required for a single concurrent request, in gibibytes.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Origin(Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.PropertyOrigin.Owned)]
        public double KvCacheGiBPerRequest { get => this._kvCacheGiBPerRequest; set => this._kvCacheGiBPerRequest = value; }

        /// <summary>Backing field for <see cref="KvCacheGiBTotal" /> property.</summary>
        private double _kvCacheGiBTotal;

        /// <summary>
        /// The key-value cache memory required for all concurrent requests on a replica, in gibibytes.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Origin(Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.PropertyOrigin.Owned)]
        public double KvCacheGiBTotal { get => this._kvCacheGiBTotal; set => this._kvCacheGiBTotal = value; }

        /// <summary>Backing field for <see cref="ModelAndKvCacheGiB" /> property.</summary>
        private double _modelAndKvCacheGiB;

        /// <summary>
        /// The combined model-weight and key-value cache memory required per replica, in gibibytes.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Origin(Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.PropertyOrigin.Owned)]
        public double ModelAndKvCacheGiB { get => this._modelAndKvCacheGiB; set => this._modelAndKvCacheGiB = value; }

        /// <summary>Backing field for <see cref="ModelWeightsGiB" /> property.</summary>
        private double _modelWeightsGiB;

        /// <summary>The memory required for the model weights, in gibibytes.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Origin(Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.PropertyOrigin.Owned)]
        public double ModelWeightsGiB { get => this._modelWeightsGiB; set => this._modelWeightsGiB = value; }

        /// <summary>Creates an new <see cref="RecommendVMSkuMemory" /> instance.</summary>
        public RecommendVMSkuMemory()
        {

        }
    }
    /// The memory calculation shared by every returned option.
    public partial interface IRecommendVMSkuMemory :
        Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.IJsonSerializable
    {
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
        double KvCacheGiBPerRequest { get; set; }
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
        double KvCacheGiBTotal { get; set; }
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
        double ModelAndKvCacheGiB { get; set; }
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
        double ModelWeightsGiB { get; set; }

    }
    /// The memory calculation shared by every returned option.
    internal partial interface IRecommendVMSkuMemoryInternal

    {
        /// <summary>
        /// The key-value cache memory required for a single concurrent request, in gibibytes.
        /// </summary>
        double KvCacheGiBPerRequest { get; set; }
        /// <summary>
        /// The key-value cache memory required for all concurrent requests on a replica, in gibibytes.
        /// </summary>
        double KvCacheGiBTotal { get; set; }
        /// <summary>
        /// The combined model-weight and key-value cache memory required per replica, in gibibytes.
        /// </summary>
        double ModelAndKvCacheGiB { get; set; }
        /// <summary>The memory required for the model weights, in gibibytes.</summary>
        double ModelWeightsGiB { get; set; }

    }
}