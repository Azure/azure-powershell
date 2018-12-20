// ----------------------------------------------------------------------------------
//
// Copyright Microsoft Corporation
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// http://www.apache.org/licenses/LICENSE-2.0
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// ----------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Management.Automation;
using Microsoft.Azure.Commands.RecoveryServices.Backup.Cmdlets.Models;
using Microsoft.Azure.Commands.RecoveryServices.Backup.Cmdlets.ProviderModel;
using Microsoft.Azure.Commands.RecoveryServices.Backup.Properties;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;

namespace Microsoft.Azure.Commands.RecoveryServices.Backup.Cmdlets
{
    /// <summary>
    /// Enable protection of an item with the recovery services vault. 
    /// Returns the corresponding job created in the service to track this operation.
    /// </summary>
    [Cmdlet("Enable", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "RecoveryServicesBackupProtection",DefaultParameterSetName = AzureVMComputeParameterSet, SupportsShouldProcess = true),OutputType(typeof(JobBase))]
    public class EnableAzureRmRecoveryServicesBackupProtection : RSBackupVaultCmdletBase
    {
        internal const string AzureVMClassicComputeParameterSet = "AzureVMClassicComputeEnableProtection";
        internal const string AzureVMComputeParameterSet = "AzureVMComputeEnableProtection";
        internal const string AzureFileShareParameterSet = "AzureFileShareEnableProtection";
        internal const string ModifyProtectionParameterSet = "ModifyProtection";

        /// <summary>
        /// Policy to be associated with this item as part of the protection operation.
        /// </summary>
        [Parameter(Position = 1, Mandatory = true, HelpMessage = ParamHelpMsgs.Policy.ProtectionPolicy)]
        [ValidateNotNullOrEmpty]
        public PolicyBase Policy { get; set; }

        /// <summary>
        /// Name of the Azure VM whose representative item needs to be protected.
        /// </summary>
        [Parameter(Position = 2, Mandatory = true, ValueFromPipelineByPropertyName = true,
            ParameterSetName = AzureVMClassicComputeParameterSet, HelpMessage = ParamHelpMsgs.Item.ItemName)]
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true,
            ParameterSetName = AzureVMComputeParameterSet, HelpMessage = ParamHelpMsgs.Item.ItemName)]
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true,
            ParameterSetName = AzureFileShareParameterSet, HelpMessage = ParamHelpMsgs.Item.ItemName)]
        public string Name { get; set; }

        /// <summary>
        /// Service name of the classic Azure VM whose representative item needs to be protected.
        /// </summary>
        [Parameter(Position = 3, Mandatory = true, ValueFromPipelineByPropertyName = true,
            ParameterSetName = AzureVMClassicComputeParameterSet,
            HelpMessage = ParamHelpMsgs.Item.AzureVMServiceName)]
        public string ServiceName { get; set; }

        /// <summary>
        /// Resource group name of the compute Azure VM whose representative item needs to be protected.
        /// </summary>
        [Parameter(Position = 3, Mandatory = true, ValueFromPipelineByPropertyName = true,
            ParameterSetName = AzureVMComputeParameterSet,
            HelpMessage = ParamHelpMsgs.Item.AzureVMResourceGroupName)]
        [ResourceGroupCompleter]
        public string ResourceGroupName { get; set; }

        /// <summary>
        /// Storage account name of the Azure Files whose representative item needs to be protected.
        /// </summary>
        [Parameter(Position = 3, Mandatory = true, ValueFromPipelineByPropertyName = true,
            ParameterSetName = AzureFileShareParameterSet,
            HelpMessage = ParamHelpMsgs.Item.AzureFileStorageAccountName)]
        [ResourceGroupCompleter]
        public string StorageAccountName { get; set; }

        /// <summary>
        /// Item whose protection needs to be modified.
        /// </summary>
        [Parameter(Position = 4, Mandatory = true, ParameterSetName = ModifyProtectionParameterSet,
            HelpMessage = ParamHelpMsgs.Item.ProtectedItem, ValueFromPipeline = true)]
        [ValidateNotNullOrEmpty]
        public ItemBase Item { get; set; }

        public override void ExecuteCmdlet()
        {
            ExecutionBlock(() =>
            {
                base.ExecuteCmdlet();

                ResourceIdentifier resourceIdentifier = new ResourceIdentifier(VaultId);
                string vaultName = resourceIdentifier.ResourceName;
                string resourceGroupName = resourceIdentifier.ResourceGroupName;

                string shouldProcessName = Name;
                if (ParameterSetName == ModifyProtectionParameterSet)
                {
                    shouldProcessName = Item.Name;
                }

                if (ShouldProcess(shouldProcessName, VerbsLifecycle.Enable))
                {
                    PsBackupProviderManager providerManager =
                        new PsBackupProviderManager(new Dictionary<Enum, object>()
                        {
                            { VaultParams.VaultName, vaultName },
                            { VaultParams.ResourceGroupName, resourceGroupName },
                            { ItemParams.StorageAccountName, StorageAccountName },
                            { ItemParams.ItemName, Name },
                            { ItemParams.AzureVMCloudServiceName, ServiceName },
                            { ItemParams.AzureVMResourceGroupName, ResourceGroupName },
                            { ItemParams.Policy, Policy },
                            { ItemParams.Item, Item },
                            { ItemParams.ParameterSetName, this.ParameterSetName },
                        }, ServiceClientAdapter);

                    IPsBackupProvider psBackupProvider = (Item != null) ?
                        providerManager.GetProviderInstance(Item.WorkloadType, Item.BackupManagementType)
                        : providerManager.GetProviderInstance(Policy.WorkloadType);

                    var itemResponse = psBackupProvider.EnableProtection();

                    // Track Response and display job details
                    HandleCreatedJob(
                        itemResponse,
                        Resources.EnableProtectionOperation,
                        vaultName: vaultName,
                        resourceGroupName: resourceGroupName);
                }
            });
        }
    }
}
