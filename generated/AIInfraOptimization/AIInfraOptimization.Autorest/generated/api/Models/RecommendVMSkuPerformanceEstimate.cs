// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.
namespace Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models
{
    using static Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.Extensions;

    /// <summary>An advisory deployment throughput and per-request latency estimate.</summary>
    public partial class RecommendVMSkuPerformanceEstimate :
        Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuPerformanceEstimate,
        Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuPerformanceEstimateInternal
    {

        /// <summary>Backing field for <see cref="DeploymentOutputTokensPerSecond" /> property.</summary>
        private double _deploymentOutputTokensPerSecond;

        /// <summary>
        /// The estimated number of output tokens generated per second across the whole deployment.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Origin(Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.PropertyOrigin.Owned)]
        public double DeploymentOutputTokensPerSecond { get => this._deploymentOutputTokensPerSecond; set => this._deploymentOutputTokensPerSecond = value; }

        /// <summary>Backing field for <see cref="TtftMS" /> property.</summary>
        private double _ttftMS;

        /// <summary>The estimated time to first token for a single request, in milliseconds.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Origin(Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.PropertyOrigin.Owned)]
        public double TtftMS { get => this._ttftMS; set => this._ttftMS = value; }

        /// <summary>Creates an new <see cref="RecommendVMSkuPerformanceEstimate" /> instance.</summary>
        public RecommendVMSkuPerformanceEstimate()
        {

        }
    }
    /// An advisory deployment throughput and per-request latency estimate.
    public partial interface IRecommendVMSkuPerformanceEstimate :
        Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.IJsonSerializable
    {
        /// <summary>
        /// The estimated number of output tokens generated per second across the whole deployment.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"The estimated number of output tokens generated per second across the whole deployment.",
        SerializedName = @"deploymentOutputTokensPerSecond",
        PossibleTypes = new [] { typeof(double) })]
        double DeploymentOutputTokensPerSecond { get; set; }
        /// <summary>The estimated time to first token for a single request, in milliseconds.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"The estimated time to first token for a single request, in milliseconds.",
        SerializedName = @"ttftMs",
        PossibleTypes = new [] { typeof(double) })]
        double TtftMS { get; set; }

    }
    /// An advisory deployment throughput and per-request latency estimate.
    internal partial interface IRecommendVMSkuPerformanceEstimateInternal

    {
        /// <summary>
        /// The estimated number of output tokens generated per second across the whole deployment.
        /// </summary>
        double DeploymentOutputTokensPerSecond { get; set; }
        /// <summary>The estimated time to first token for a single request, in milliseconds.</summary>
        double TtftMS { get; set; }

    }
}