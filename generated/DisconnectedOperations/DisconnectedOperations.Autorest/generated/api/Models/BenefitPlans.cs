// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.
namespace Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models
{
    using static Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Extensions;

    /// <summary>The benefit plans</summary>
    public partial class BenefitPlans :
        Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IBenefitPlans,
        Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IBenefitPlansInternal
    {

        /// <summary>Backing field for <see cref="AzureHybridWindowsServerBenefit" /> property.</summary>
        private string _azureHybridWindowsServerBenefit;

        /// <summary>Azure Hybrid Windows Server Benefit plan</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Origin(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.PropertyOrigin.Owned)]
        public string AzureHybridWindowsServerBenefit { get => this._azureHybridWindowsServerBenefit; set => this._azureHybridWindowsServerBenefit = value; }

        /// <summary>Backing field for <see cref="WindowsServerVMCount" /> property.</summary>
        private int? _windowsServerVMCount;

        /// <summary>Number of Windows Server VMs to license under the Azure Hybrid Benefit plan</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Origin(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.PropertyOrigin.Owned)]
        public int? WindowsServerVMCount { get => this._windowsServerVMCount; set => this._windowsServerVMCount = value; }

        /// <summary>Creates an new <see cref="BenefitPlans" /> instance.</summary>
        public BenefitPlans()
        {

        }
    }
    /// The benefit plans
    public partial interface IBenefitPlans :
        Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.IJsonSerializable
    {
        /// <summary>Azure Hybrid Windows Server Benefit plan</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"Azure Hybrid Windows Server Benefit plan",
        SerializedName = @"azureHybridWindowsServerBenefit",
        PossibleTypes = new [] { typeof(string) })]
        [global::Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.PSArgumentCompleterAttribute("Enabled", "Disabled")]
        string AzureHybridWindowsServerBenefit { get; set; }
        /// <summary>Number of Windows Server VMs to license under the Azure Hybrid Benefit plan</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"Number of Windows Server VMs to license under the Azure Hybrid Benefit plan",
        SerializedName = @"windowsServerVmCount",
        PossibleTypes = new [] { typeof(int) })]
        int? WindowsServerVMCount { get; set; }

    }
    /// The benefit plans
    internal partial interface IBenefitPlansInternal

    {
        /// <summary>Azure Hybrid Windows Server Benefit plan</summary>
        [global::Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.PSArgumentCompleterAttribute("Enabled", "Disabled")]
        string AzureHybridWindowsServerBenefit { get; set; }
        /// <summary>Number of Windows Server VMs to license under the Azure Hybrid Benefit plan</summary>
        int? WindowsServerVMCount { get; set; }

    }
}