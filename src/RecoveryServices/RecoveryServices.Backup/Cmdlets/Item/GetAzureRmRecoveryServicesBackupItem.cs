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
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;

namespace Microsoft.Azure.Commands.RecoveryServices.Backup.Cmdlets
{
    /// <summary>
    /// Get list of items associated with the recovery services vault 
    /// according to the filters passed via the cmdlet parameters.
    /// </summary>
    [Cmdlet("Get", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "RecoveryServicesBackupItem",DefaultParameterSetName = GetItemsForContainerParamSet), OutputType(typeof(ItemBase))]
    public class GetAzureRmRecoveryServicesBackupItem : RSBackupVaultCmdletBase
    {
        internal const string GetItemsForContainerParamSet = "GetItemsForContainer";
        internal const string GetItemsForVaultParamSet = "GetItemsForVault";
        internal const string GetItemsForPolicyParamSet = "GetItemsForPolicy";

        /// <summary>
        /// List of supported BackupManagementTypes for this cmdlet. Used in help text creation.
        /// </summary>
        private const string validBackupManagementTypes = "AzureVM, MAB, AzureStorage, AzureWorkload";

        /// <summary>
        /// List of supported WorkloadTypes for this cmdlet. Used in help text creation.
        /// </summary>
        private const string validWorkloadTypes = "AzureVM, AzureFiles, MSSQL";

        /// <summary>
        /// When this option is specified, only those items which belong to this container will be returned.
        /// </summary>
        [Parameter(
            Mandatory = true,
            Position = 1,
            HelpMessage = ParamHelpMsgs.Item.Container,
            ParameterSetName = GetItemsForContainerParamSet,
            ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public ContainerBase Container { get; set; }

        /// <summary>
        /// Backup management type of the items to be returned.
        /// </summary>
        [Parameter(Mandatory = true, Position = 1, HelpMessage = ParamHelpMsgs.Common.BackupManagementType + validBackupManagementTypes,
            ParameterSetName = GetItemsForVaultParamSet)]
        [ValidateNotNullOrEmpty]
        public BackupManagementType BackupManagementType { get; set; }

        /// <summary>
        /// The command returns the list of backup Items protected by the given policy id.
        /// </summary>
        [Parameter(Mandatory = true, Position = 1, HelpMessage = ParamHelpMsgs.Item.ProtectionPolicy,
            ParameterSetName = GetItemsForPolicyParamSet)]
        [ValidateNotNullOrEmpty]
        public PolicyBase Policy { get; set; }

        /// <summary>
        /// Friendly name of the item to be returned.
        /// </summary>
        [Parameter(Mandatory = false, Position = 2, HelpMessage = ParamHelpMsgs.Item.ItemName)]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        /// <summary>
        /// Status of protection of the item to be returned.
        /// </summary>
        [Parameter(Mandatory = false, Position = 3, HelpMessage = ParamHelpMsgs.Item.ProtectionStatus)]
        [ValidateNotNullOrEmpty]
        public ItemProtectionStatus ProtectionStatus { get; set; }

        /// <summary>
        /// State of protection of the item to be returned.
        /// </summary>
        [Parameter(Mandatory = false, Position = 4, HelpMessage = ParamHelpMsgs.Item.Status)]
        [ValidateNotNullOrEmpty]
        public ItemProtectionState ProtectionState { get; set; }

        /// <summary>
        /// Workload type of the item to be returned.
        /// </summary>
        [Parameter(Mandatory = true, Position = 5, HelpMessage = ParamHelpMsgs.Common.WorkloadType + validWorkloadTypes,
            ParameterSetName = GetItemsForVaultParamSet)]
        [Parameter(Mandatory = true, Position = 5, HelpMessage = ParamHelpMsgs.Common.WorkloadType + validWorkloadTypes,
            ParameterSetName = GetItemsForContainerParamSet)]
        [ValidateNotNullOrEmpty]
        public WorkloadType WorkloadType { get; set; }

        /// <summary>
        /// Delete state of the item
        /// </summary>
        [Parameter(Mandatory = false, Position = 6, HelpMessage = ParamHelpMsgs.Item.DeleteState)]
        [ValidateNotNullOrEmpty]
        public ItemDeleteState DeleteState { get; set; }

        /// <summary>
        /// Friendly Name of the item, Applicable only in case of Azure File Share item.
        /// </summary>
        [Parameter(Mandatory = false, HelpMessage = ParamHelpMsgs.Item.FriendlyName)]
        [ValidateNotNullOrEmpty]
        public string FriendlyName { get; set; }

        /// <summary>
        /// Fetches the VM Bakup Items from Secondary Region.
        /// </summary>
        [Parameter(Mandatory = false, HelpMessage = ParamHelpMsgs.Common.UseSecondaryReg)]
        public SwitchParameter UseSecondaryRegion;

        public override void ExecuteCmdlet()
        {
            ExecutionBlock(() =>
            {
                base.ExecuteCmdlet();

                ResourceIdentifier resourceIdentifier = new ResourceIdentifier(VaultId);
                string vaultName = resourceIdentifier.ResourceName;
                string resourceGroupName = resourceIdentifier.ResourceGroupName;

                PsBackupProviderManager providerManager =
                    new PsBackupProviderManager(new Dictionary<Enum, object>()
                    {
                        { VaultParams.VaultName, vaultName },
                        { VaultParams.ResourceGroupName, resourceGroupName },
                        { ItemParams.DeleteState, DeleteState },
                        { ItemParams.Container, Container },
                        { ItemParams.BackupManagementType, BackupManagementType },
                        { ItemParams.ItemName, Name },
                        { PolicyParams.ProtectionPolicy, Policy },
                        { ItemParams.ProtectionStatus, ProtectionStatus },
                        { ItemParams.ProtectionState, ProtectionState },
                        { ItemParams.WorkloadType, WorkloadType },
                        { ItemParams.FriendlyName, FriendlyName },
                        { CRRParams.UseSecondaryRegion, UseSecondaryRegion.IsPresent}
                    }, ServiceClientAdapter);

                IPsBackupProvider psBackupProvider = null;
                List<ItemBase> itemModels = null;
                if (BackupManagementType == BackupManagementType.MAB)
                {
                    AzureWorkloadProviderHelper provider = new AzureWorkloadProviderHelper(ServiceClientAdapter);
                    itemModels = provider.GetMABProtectedItems(vaultName, resourceGroupName);
                }
                else
                {
                    if (this.ParameterSetName == GetItemsForVaultParamSet)
                    {
                        psBackupProvider =
                            providerManager.GetProviderInstance(WorkloadType, BackupManagementType);
                    }
                    else if (this.ParameterSetName == GetItemsForContainerParamSet)
                    {
                        psBackupProvider = providerManager.GetProviderInstance(WorkloadType,
                        (Container as ManagementContext).BackupManagementType);
                    }
                    else
                    {
                        psBackupProvider = providerManager.GetProviderInstance(Policy.WorkloadType);
                    }
                    itemModels = psBackupProvider.ListProtectedItems();
                }

                WriteObject(itemModels, enumerateCollection: true);
            });
        }
    }
}
