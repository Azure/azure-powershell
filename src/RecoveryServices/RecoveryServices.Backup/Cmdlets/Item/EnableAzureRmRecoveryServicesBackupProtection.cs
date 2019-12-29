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

using Microsoft.Azure.Commands.RecoveryServices.Backup.Cmdlets.Models;
using Microsoft.Azure.Commands.RecoveryServices.Backup.Cmdlets.ProviderModel;
using Microsoft.Azure.Commands.RecoveryServices.Backup.Helpers;
using Microsoft.Azure.Commands.RecoveryServices.Backup.Properties;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;
using Microsoft.Azure.Management.RecoveryServices.Backup.Models;
using Microsoft.Rest.Azure.OData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.RecoveryServices.Backup.Cmdlets
{
    /// <summary>
    /// Enable protection of an item with the recovery services vault. 
    /// Returns the corresponding job created in the service to track this operation.
    /// </summary>
    [Cmdlet("Enable", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "RecoveryServicesBackupProtection", DefaultParameterSetName = AzureVMComputeParameterSet, SupportsShouldProcess = true), OutputType(typeof(JobBase))]
    public class EnableAzureRmRecoveryServicesBackupProtection : RSBackupVaultCmdletBase
    {
        internal const string AzureVMClassicComputeParameterSet = "AzureVMClassicComputeEnableProtection";
        internal const string AzureVMComputeParameterSet = "AzureVMComputeEnableProtection";
        internal const string AzureFileShareParameterSet = "AzureFileShareEnableProtection";
        internal const string AzureWorkloadParameterSet = "AzureWorkloadEnableProtection";
        internal const string ModifyProtectionWithPolicy = "ModifyProtectionPolicy";
        internal const string ModifyProtectionWithDiskExclusion = "ModifyProtectionDiskExclusion";
        internal const string ModifyProtectionWithDiskInclusion = "ModifyProtectionDiskInclusion";
        //internal const string ModifyWithDiskExclusion = "DiskExclusion";
        // internal const string DiskInclusionParameterSet = "DiskInclusion";
        internal const string ModifyProtectionWithDiskReset = "ModifyProtectionDiskReset";

        /// <summary>
        /// Policy to be associated with this item as part of the protection operation.
        /// </summary>
        // [Parameter(Position = 1, Mandatory = true, HelpMessage = ParamHelpMsgs.Policy.ProtectionPolicy)]
        [Parameter(Position = 1, Mandatory = true, ParameterSetName = AzureVMClassicComputeParameterSet, 
            HelpMessage = ParamHelpMsgs.Policy.ProtectionPolicy)]
        
        [Parameter(Mandatory = true, ParameterSetName = AzureVMComputeParameterSet,
            HelpMessage = ParamHelpMsgs.Policy.ProtectionPolicy)]
        [Parameter(Mandatory = true, ParameterSetName = AzureFileShareParameterSet,
            HelpMessage = ParamHelpMsgs.Policy.ProtectionPolicy)]
        [Parameter(Mandatory = true, ParameterSetName = AzureWorkloadParameterSet,
            HelpMessage = ParamHelpMsgs.Policy.ProtectionPolicy)]
        [Parameter(Mandatory = true, ParameterSetName = ModifyProtectionWithPolicy,
            HelpMessage = ParamHelpMsgs.Policy.ProtectionPolicy)]
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

        [Parameter(Position = 2, Mandatory = true, ParameterSetName = AzureWorkloadParameterSet,
            HelpMessage = ParamHelpMsgs.Item.ProtectedItem, ValueFromPipeline = true)]
        [ValidateNotNullOrEmpty]
        public ProtectableItemBase ProtectableItem { get; set; }

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
        [Parameter(Position = 4, Mandatory = true, ParameterSetName = ModifyProtectionWithPolicy,
            HelpMessage = ParamHelpMsgs.Item.ProtectedItem, ValueFromPipeline = true)]
        [Parameter(Mandatory = true, ParameterSetName = ModifyProtectionWithDiskInclusion)]
        [Parameter(Mandatory = true, ParameterSetName = ModifyProtectionWithDiskExclusion)]
        [Parameter(Mandatory = true, ParameterSetName = ModifyProtectionWithDiskReset)]
        [ValidateNotNullOrEmpty]
        public ItemBase Item { get; set; }

        // [Parameter(Mandatory = false, ParameterSetName = DiskExclusionParameterSet)]
        [Parameter(Mandatory = false, ParameterSetName = AzureVMClassicComputeParameterSet)]
        [Parameter(Mandatory = false, ParameterSetName = AzureVMComputeParameterSet)]
        [Parameter(Mandatory = false, ParameterSetName = ModifyProtectionWithDiskInclusion)]
        public string[] InclusionDisksList { get; set; }

        // [Parameter(Mandatory = false, ParameterSetName = DiskExclusionParameterSet)]
        [Parameter(Mandatory = false, ParameterSetName = AzureVMClassicComputeParameterSet)]
        [Parameter(Mandatory = false, ParameterSetName = AzureVMComputeParameterSet)]
        [Parameter(Mandatory = false, ParameterSetName = ModifyProtectionWithDiskExclusion)]
        public string[] ExclusionDisksList { get; set; }

        // [Parameter(Mandatory = true, ParameterSetName = DiskExclusionResetParameterSet)]
        [Parameter(Mandatory = true, ParameterSetName = ModifyProtectionWithDiskReset)]
        public SwitchParameter ResetExclusionSettings { get; set; }

        public override void ExecuteCmdlet()
        {
            ExecutionBlock(() =>
            {
                base.ExecuteCmdlet();

                ResourceIdentifier resourceIdentifier = new ResourceIdentifier(VaultId);
                string vaultName = resourceIdentifier.ResourceName;
                string resourceGroupName = resourceIdentifier.ResourceGroupName;

                string shouldProcessName = Name;
                if (ParameterSetName.Contains("Modify"))
                {
                    shouldProcessName = Item.Name;
                }

                if (ShouldProcess(shouldProcessName, VerbsLifecycle.Enable))
                {
                    if (ParameterSetName == AzureWorkloadParameterSet &&
                    (string.Compare(((AzureWorkloadProtectableItem)ProtectableItem).ProtectableItemType,
                    ProtectableItemType.SQLAvailabilityGroup.ToString()) == 0 ||
                    string.Compare(((AzureWorkloadProtectableItem)ProtectableItem).ProtectableItemType,
                    ProtectableItemType.SQLInstance.ToString()) == 0))
                    {
                        string backupManagementType = ProtectableItem.BackupManagementType.ToString();
                        string workloadType = ConversionUtils.GetServiceClientWorkloadType(ProtectableItem.WorkloadType.ToString());
                        string containerName = "VMAppContainer;" + ((AzureWorkloadProtectableItem)ProtectableItem).ContainerName;
                        ODataQuery<BMSPOQueryObject> queryParam = new ODataQuery<BMSPOQueryObject>(
                        q => q.BackupManagementType
                             == backupManagementType &&
                             q.WorkloadType == workloadType &&
                             q.ContainerName == containerName);

                        WriteDebug("going to query service to get list of protectable items");
                        List<WorkloadProtectableItemResource> protectableItems =
                            ServiceClientAdapter.ListProtectableItem(
                                queryParam,
                                vaultName: vaultName,
                                resourceGroupName: resourceGroupName);
                        WriteDebug("Successfully got response from service");
                        List<ProtectableItemBase> itemModels = ConversionHelpers.GetProtectableItemModelList(protectableItems);
                        for (int protitemindex = 0; protitemindex < itemModels.Count(); protitemindex++)
                        {
                            if (string.Compare(((AzureWorkloadProtectableItem)itemModels[protitemindex]).Name,
                                ProtectableItem.Name) == 0 &&
                            string.Compare(((AzureWorkloadProtectableItem)itemModels[protitemindex]).ServerName,
                            ((AzureWorkloadProtectableItem)ProtectableItem).ServerName) == 0 &&
                            string.Compare(((AzureWorkloadProtectableItem)itemModels[protitemindex]).ProtectableItemType,
                            ((AzureWorkloadProtectableItem)ProtectableItem).ProtectableItemType) == 0 &&
                            ((AzureWorkloadProtectableItem)itemModels[protitemindex]).Subinquireditemcount > 0)
                            {
                                for (int index = protitemindex + 1;
                                index <= protitemindex + ((AzureWorkloadProtectableItem)ProtectableItem).Subinquireditemcount;
                                index++)
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
                                                                    { ItemParams.ProtectableItem, itemModels[index] },
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
                                break;
                            }
                        }
                    }
                    else
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
                                { ItemParams.ProtectableItem, ProtectableItem  },
                                { ItemParams.ParameterSetName, this.ParameterSetName },
                                { ItemParams.InclusionDisksList, InclusionDisksList },
                                { ItemParams.ExclusionDisksList, ExclusionDisksList },
                                { ItemParams.ResetExclusionSettings, ResetExclusionSettings }
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
                }
            });
        }
    }
}
