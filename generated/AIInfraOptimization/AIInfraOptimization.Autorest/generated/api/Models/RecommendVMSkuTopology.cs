// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.
namespace Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models
{
    using static Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.Extensions;

    /// <summary>The deployment topology for one virtual machine size option.</summary>
    public partial class RecommendVMSkuTopology :
        Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuTopology,
        Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuTopologyInternal
    {

        /// <summary>Backing field for <see cref="Accelerator" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuAccelerator _accelerator;

        /// <summary>The accelerator hardware available in each virtual machine.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Origin(Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuAccelerator Accelerator { get => (this._accelerator = this._accelerator ?? new Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.RecommendVMSkuAccelerator()); set => this._accelerator = value; }

        /// <summary>The number of accelerator devices in each virtual machine.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Origin(Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.PropertyOrigin.Inlined)]
        public int AcceleratorCountPerVM { get => ((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuAcceleratorInternal)Accelerator).CountPerVM; set => ((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuAcceleratorInternal)Accelerator).CountPerVM = value ; }

        /// <summary>The memory capacity of a single accelerator device, in gibibytes.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Origin(Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.PropertyOrigin.Inlined)]
        public int AcceleratorMemoryGiBPerAccelerator { get => ((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuAcceleratorInternal)Accelerator).MemoryGiBPerAccelerator; set => ((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuAcceleratorInternal)Accelerator).MemoryGiBPerAccelerator = value ; }

        /// <summary>The accelerator model name, for example `A100` or `H100`.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Origin(Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.PropertyOrigin.Inlined)]
        public string AcceleratorModel { get => ((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuAcceleratorInternal)Accelerator).Model; set => ((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuAcceleratorInternal)Accelerator).Model = value ; }

        /// <summary>Backing field for <see cref="EstimatedNodeCountPerReplica" /> property.</summary>
        private int _estimatedNodeCountPerReplica;

        /// <summary>The estimated number of virtual machine nodes required for a single replica.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Origin(Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.PropertyOrigin.Owned)]
        public int EstimatedNodeCountPerReplica { get => this._estimatedNodeCountPerReplica; set => this._estimatedNodeCountPerReplica = value; }

        /// <summary>Backing field for <see cref="EstimatedTotalNodeCount" /> property.</summary>
        private long _estimatedTotalNodeCount;

        /// <summary>The estimated total number of virtual machine nodes across all replicas.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Origin(Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.PropertyOrigin.Owned)]
        public long EstimatedTotalNodeCount { get => this._estimatedTotalNodeCount; set => this._estimatedTotalNodeCount = value; }

        /// <summary>Internal Acessors for Accelerator</summary>
        Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuAccelerator Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuTopologyInternal.Accelerator { get => (this._accelerator = this._accelerator ?? new Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.RecommendVMSkuAccelerator()); set { {_accelerator = value;} } }

        /// <summary>Creates an new <see cref="RecommendVMSkuTopology" /> instance.</summary>
        public RecommendVMSkuTopology()
        {

        }
    }
    /// The deployment topology for one virtual machine size option.
    public partial interface IRecommendVMSkuTopology :
        Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.IJsonSerializable
    {
        /// <summary>The number of accelerator devices in each virtual machine.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"The number of accelerator devices in each virtual machine.",
        SerializedName = @"countPerVm",
        PossibleTypes = new [] { typeof(int) })]
        int AcceleratorCountPerVM { get; set; }
        /// <summary>The memory capacity of a single accelerator device, in gibibytes.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"The memory capacity of a single accelerator device, in gibibytes.",
        SerializedName = @"memoryGiBPerAccelerator",
        PossibleTypes = new [] { typeof(int) })]
        int AcceleratorMemoryGiBPerAccelerator { get; set; }
        /// <summary>The accelerator model name, for example `A100` or `H100`.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"The accelerator model name, for example `A100` or `H100`.",
        SerializedName = @"model",
        PossibleTypes = new [] { typeof(string) })]
        string AcceleratorModel { get; set; }
        /// <summary>The estimated number of virtual machine nodes required for a single replica.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"The estimated number of virtual machine nodes required for a single replica.",
        SerializedName = @"estimatedNodeCountPerReplica",
        PossibleTypes = new [] { typeof(int) })]
        int EstimatedNodeCountPerReplica { get; set; }
        /// <summary>The estimated total number of virtual machine nodes across all replicas.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"The estimated total number of virtual machine nodes across all replicas.",
        SerializedName = @"estimatedTotalNodeCount",
        PossibleTypes = new [] { typeof(long) })]
        long EstimatedTotalNodeCount { get; set; }

    }
    /// The deployment topology for one virtual machine size option.
    internal partial interface IRecommendVMSkuTopologyInternal

    {
        /// <summary>The accelerator hardware available in each virtual machine.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuAccelerator Accelerator { get; set; }
        /// <summary>The number of accelerator devices in each virtual machine.</summary>
        int AcceleratorCountPerVM { get; set; }
        /// <summary>The memory capacity of a single accelerator device, in gibibytes.</summary>
        int AcceleratorMemoryGiBPerAccelerator { get; set; }
        /// <summary>The accelerator model name, for example `A100` or `H100`.</summary>
        string AcceleratorModel { get; set; }
        /// <summary>The estimated number of virtual machine nodes required for a single replica.</summary>
        int EstimatedNodeCountPerReplica { get; set; }
        /// <summary>The estimated total number of virtual machine nodes across all replicas.</summary>
        long EstimatedTotalNodeCount { get; set; }

    }
}