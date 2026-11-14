// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.
namespace Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models
{
    using static Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.Extensions;

    /// <summary>The subscription-scoped lookups to include in the recommendation.</summary>
    public partial class RecommendVMSkuSubscriptionOptions :
        Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuSubscriptionOptions,
        Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuSubscriptionOptionsInternal
    {

        /// <summary>Backing field for <see cref="IncludePlacement" /> property.</summary>
        private bool? _includePlacement;

        /// <summary>
        /// Whether to query placement scores for candidate virtual machine sizes with available quota.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Origin(Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.PropertyOrigin.Owned)]
        public bool? IncludePlacement { get => this._includePlacement; set => this._includePlacement = value; }

        /// <summary>Backing field for <see cref="IncludePricing" /> property.</summary>
        private bool? _includePricing;

        /// <summary>Whether to fetch subscription-scoped virtual machine pricing.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Origin(Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.PropertyOrigin.Owned)]
        public bool? IncludePricing { get => this._includePricing; set => this._includePricing = value; }

        /// <summary>Backing field for <see cref="IncludeQuota" /> property.</summary>
        private bool? _includeQuota;

        /// <summary>Whether to evaluate subscription quota for candidate virtual machine sizes.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Origin(Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.PropertyOrigin.Owned)]
        public bool? IncludeQuota { get => this._includeQuota; set => this._includeQuota = value; }

        /// <summary>Creates an new <see cref="RecommendVMSkuSubscriptionOptions" /> instance.</summary>
        public RecommendVMSkuSubscriptionOptions()
        {

        }
    }
    /// The subscription-scoped lookups to include in the recommendation.
    public partial interface IRecommendVMSkuSubscriptionOptions :
        Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.IJsonSerializable
    {
        /// <summary>
        /// Whether to query placement scores for candidate virtual machine sizes with available quota.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"Whether to query placement scores for candidate virtual machine sizes with available quota.",
        SerializedName = @"includePlacement",
        PossibleTypes = new [] { typeof(bool) })]
        bool? IncludePlacement { get; set; }
        /// <summary>Whether to fetch subscription-scoped virtual machine pricing.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"Whether to fetch subscription-scoped virtual machine pricing.",
        SerializedName = @"includePricing",
        PossibleTypes = new [] { typeof(bool) })]
        bool? IncludePricing { get; set; }
        /// <summary>Whether to evaluate subscription quota for candidate virtual machine sizes.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"Whether to evaluate subscription quota for candidate virtual machine sizes.",
        SerializedName = @"includeQuota",
        PossibleTypes = new [] { typeof(bool) })]
        bool? IncludeQuota { get; set; }

    }
    /// The subscription-scoped lookups to include in the recommendation.
    internal partial interface IRecommendVMSkuSubscriptionOptionsInternal

    {
        /// <summary>
        /// Whether to query placement scores for candidate virtual machine sizes with available quota.
        /// </summary>
        bool? IncludePlacement { get; set; }
        /// <summary>Whether to fetch subscription-scoped virtual machine pricing.</summary>
        bool? IncludePricing { get; set; }
        /// <summary>Whether to evaluate subscription quota for candidate virtual machine sizes.</summary>
        bool? IncludeQuota { get; set; }

    }
}