// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.
namespace Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models
{
    using static Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.Extensions;

    /// <summary>The quota limits to raise before retrying a deployment.</summary>
    public partial class RecommendVMSkuQuotaIncrease :
        Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuQuotaIncrease,
        Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuQuotaIncreaseInternal
    {

        /// <summary>Backing field for <see cref="Limit" /> property.</summary>
        private System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuQuotaLimit> _limit;

        /// <summary>The individual quota limits that block the requested deployment.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Origin(Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.PropertyOrigin.Owned)]
        public System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuQuotaLimit> Limit { get => this._limit; set => this._limit = value; }

        /// <summary>Backing field for <see cref="PortalUrl" /> property.</summary>
        private string _portalUrl;

        /// <summary>A URL to the Azure portal page for submitting the quota increase.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Origin(Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.PropertyOrigin.Owned)]
        public string PortalUrl { get => this._portalUrl; set => this._portalUrl = value; }

        /// <summary>Creates an new <see cref="RecommendVMSkuQuotaIncrease" /> instance.</summary>
        public RecommendVMSkuQuotaIncrease()
        {

        }
    }
    /// The quota limits to raise before retrying a deployment.
    public partial interface IRecommendVMSkuQuotaIncrease :
        Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.IJsonSerializable
    {
        /// <summary>The individual quota limits that block the requested deployment.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"The individual quota limits that block the requested deployment.",
        SerializedName = @"limits",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuQuotaLimit) })]
        System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuQuotaLimit> Limit { get; set; }
        /// <summary>A URL to the Azure portal page for submitting the quota increase.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"A URL to the Azure portal page for submitting the quota increase.",
        SerializedName = @"portalUrl",
        PossibleTypes = new [] { typeof(string) })]
        string PortalUrl { get; set; }

    }
    /// The quota limits to raise before retrying a deployment.
    internal partial interface IRecommendVMSkuQuotaIncreaseInternal

    {
        /// <summary>The individual quota limits that block the requested deployment.</summary>
        System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuQuotaLimit> Limit { get; set; }
        /// <summary>A URL to the Azure portal page for submitting the quota increase.</summary>
        string PortalUrl { get; set; }

    }
}