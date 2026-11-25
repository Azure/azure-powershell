// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.
namespace Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models
{
    using static Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.Extensions;

    /// <summary>The accelerator hardware available in each virtual machine.</summary>
    public partial class RecommendVMSkuAccelerator :
        Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuAccelerator,
        Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuAcceleratorInternal
    {

        /// <summary>Backing field for <see cref="CountPerVM" /> property.</summary>
        private int _countPerVM;

        /// <summary>The number of accelerator devices in each virtual machine.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Origin(Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.PropertyOrigin.Owned)]
        public int CountPerVM { get => this._countPerVM; set => this._countPerVM = value; }

        /// <summary>Backing field for <see cref="MemoryGiBPerAccelerator" /> property.</summary>
        private int _memoryGiBPerAccelerator;

        /// <summary>The memory capacity of a single accelerator device, in gibibytes.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Origin(Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.PropertyOrigin.Owned)]
        public int MemoryGiBPerAccelerator { get => this._memoryGiBPerAccelerator; set => this._memoryGiBPerAccelerator = value; }

        /// <summary>Backing field for <see cref="Model" /> property.</summary>
        private string _model;

        /// <summary>The accelerator model name, for example `A100` or `H100`.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Origin(Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.PropertyOrigin.Owned)]
        public string Model { get => this._model; set => this._model = value; }

        /// <summary>Creates an new <see cref="RecommendVMSkuAccelerator" /> instance.</summary>
        public RecommendVMSkuAccelerator()
        {

        }
    }
    /// The accelerator hardware available in each virtual machine.
    public partial interface IRecommendVMSkuAccelerator :
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
        int CountPerVM { get; set; }
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
        int MemoryGiBPerAccelerator { get; set; }
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
        string Model { get; set; }

    }
    /// The accelerator hardware available in each virtual machine.
    internal partial interface IRecommendVMSkuAcceleratorInternal

    {
        /// <summary>The number of accelerator devices in each virtual machine.</summary>
        int CountPerVM { get; set; }
        /// <summary>The memory capacity of a single accelerator device, in gibibytes.</summary>
        int MemoryGiBPerAccelerator { get; set; }
        /// <summary>The accelerator model name, for example `A100` or `H100`.</summary>
        string Model { get; set; }

    }
}