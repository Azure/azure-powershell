// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.
namespace Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models
{
    using static Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.Extensions;

    /// <summary>One quota limit that blocks the requested deployment.</summary>
    public partial class RecommendVMSkuQuotaLimit :
        Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuQuotaLimit,
        Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuQuotaLimitInternal
    {

        /// <summary>Backing field for <see cref="CurrentLimit" /> property.</summary>
        private long _currentLimit;

        /// <summary>The current quota limit.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Origin(Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.PropertyOrigin.Owned)]
        public long CurrentLimit { get => this._currentLimit; set => this._currentLimit = value; }

        /// <summary>Backing field for <see cref="CurrentUsage" /> property.</summary>
        private long _currentUsage;

        /// <summary>The current usage against the quota.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Origin(Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.PropertyOrigin.Owned)]
        public long CurrentUsage { get => this._currentUsage; set => this._currentUsage = value; }

        /// <summary>Backing field for <see cref="Name" /> property.</summary>
        private string _name;

        /// <summary>The name of the quota to raise.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Origin(Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.PropertyOrigin.Owned)]
        public string Name { get => this._name; set => this._name = value; }

        /// <summary>Backing field for <see cref="RequiredLimit" /> property.</summary>
        private long _requiredLimit;

        /// <summary>The quota limit required to deploy the workload.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Origin(Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.PropertyOrigin.Owned)]
        public long RequiredLimit { get => this._requiredLimit; set => this._requiredLimit = value; }

        /// <summary>Creates an new <see cref="RecommendVMSkuQuotaLimit" /> instance.</summary>
        public RecommendVMSkuQuotaLimit()
        {

        }
    }
    /// One quota limit that blocks the requested deployment.
    public partial interface IRecommendVMSkuQuotaLimit :
        Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.IJsonSerializable
    {
        /// <summary>The current quota limit.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"The current quota limit.",
        SerializedName = @"currentLimit",
        PossibleTypes = new [] { typeof(long) })]
        long CurrentLimit { get; set; }
        /// <summary>The current usage against the quota.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"The current usage against the quota.",
        SerializedName = @"currentUsage",
        PossibleTypes = new [] { typeof(long) })]
        long CurrentUsage { get; set; }
        /// <summary>The name of the quota to raise.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"The name of the quota to raise.",
        SerializedName = @"name",
        PossibleTypes = new [] { typeof(string) })]
        string Name { get; set; }
        /// <summary>The quota limit required to deploy the workload.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"The quota limit required to deploy the workload.",
        SerializedName = @"requiredLimit",
        PossibleTypes = new [] { typeof(long) })]
        long RequiredLimit { get; set; }

    }
    /// One quota limit that blocks the requested deployment.
    internal partial interface IRecommendVMSkuQuotaLimitInternal

    {
        /// <summary>The current quota limit.</summary>
        long CurrentLimit { get; set; }
        /// <summary>The current usage against the quota.</summary>
        long CurrentUsage { get; set; }
        /// <summary>The name of the quota to raise.</summary>
        string Name { get; set; }
        /// <summary>The quota limit required to deploy the workload.</summary>
        long RequiredLimit { get; set; }

    }
}