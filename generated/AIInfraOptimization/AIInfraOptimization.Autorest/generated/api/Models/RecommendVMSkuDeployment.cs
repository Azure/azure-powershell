// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.
namespace Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models
{
    using static Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.Extensions;

    /// <summary>Deployment scale and procurement inputs.</summary>
    public partial class RecommendVMSkuDeployment :
        Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuDeployment,
        Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuDeploymentInternal
    {

        /// <summary>Backing field for <see cref="ProcurementOption" /> property.</summary>
        private string _procurementOption;

        /// <summary>The Azure virtual machine procurement option.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Origin(Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.PropertyOrigin.Owned)]
        public string ProcurementOption { get => this._procurementOption; set => this._procurementOption = value; }

        /// <summary>Backing field for <see cref="ReplicaCount" /> property.</summary>
        private int? _replicaCount;

        /// <summary>
        /// The number of deployment replicas used for cost, quota, and placement calculations.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Origin(Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.PropertyOrigin.Owned)]
        public int? ReplicaCount { get => this._replicaCount; set => this._replicaCount = value; }

        /// <summary>Creates an new <see cref="RecommendVMSkuDeployment" /> instance.</summary>
        public RecommendVMSkuDeployment()
        {

        }
    }
    /// Deployment scale and procurement inputs.
    public partial interface IRecommendVMSkuDeployment :
        Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.IJsonSerializable
    {
        /// <summary>The Azure virtual machine procurement option.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"The Azure virtual machine procurement option.",
        SerializedName = @"procurementOption",
        PossibleTypes = new [] { typeof(string) })]
        [global::Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.PSArgumentCompleterAttribute("OnDemand", "Spot")]
        string ProcurementOption { get; set; }
        /// <summary>
        /// The number of deployment replicas used for cost, quota, and placement calculations.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"The number of deployment replicas used for cost, quota, and placement calculations.",
        SerializedName = @"replicaCount",
        PossibleTypes = new [] { typeof(int) })]
        int? ReplicaCount { get; set; }

    }
    /// Deployment scale and procurement inputs.
    internal partial interface IRecommendVMSkuDeploymentInternal

    {
        /// <summary>The Azure virtual machine procurement option.</summary>
        [global::Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.PSArgumentCompleterAttribute("OnDemand", "Spot")]
        string ProcurementOption { get; set; }
        /// <summary>
        /// The number of deployment replicas used for cost, quota, and placement calculations.
        /// </summary>
        int? ReplicaCount { get; set; }

    }
}