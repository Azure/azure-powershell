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
using Microsoft.Azure.Commands.RecoveryServices.Backup.Cmdlets.ServiceClientAdapterNS;
using Microsoft.Azure.Commands.RecoveryServices.Backup.Helpers;
using Microsoft.Azure.Commands.RecoveryServices.Backup.Properties;
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;
using Microsoft.Rest.Azure.OData;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using ServiceClientModel = Microsoft.Azure.Management.RecoveryServices.Backup.Models;


namespace Microsoft.Azure.Commands.RecoveryServices.Backup.Cmdlets
{
    /// <summary>
    /// Reconfigure protection for an item protected by the recovery services vault.
    /// Combines stop protection, unregister container, and configure backup steps.
    /// </summary>
    [Cmdlet("Redo", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "RecoveryServicesBackupProtection", SupportsShouldProcess = true), OutputType(typeof(JobBase))]
    public class RedoAzureRmRecoveryServicesBackupProtection : RSBackupVaultCmdletBase
    {
        [Parameter(Position = 1, Mandatory = true, HelpMessage = ParamHelpMsgs.Item.ProtectedItem, ValueFromPipeline = true)]
        [ValidateNotNullOrEmpty]
        public ItemBase Item { get; set; }

        [Parameter(Position = 2, Mandatory = true, HelpMessage = "Target Recovery Services vault ID where the item will be reconfigured")]
        [ValidateNotNullOrEmpty]
        public string TargetVaultId { get; set; }

        [Parameter(Position = 3, Mandatory = true, HelpMessage = "Backup policy to be applied in the target vault")]
        [ValidateNotNullOrEmpty]
        public PolicyBase TargetPolicy { get; set; }

        [Parameter(Position = 4, Mandatory = false, HelpMessage = ParamHelpMsgs.Item.SuspendBackupOption)]
        public SwitchParameter RetainRecoveryPointsAsPerPolicy { get; set; }

        [Parameter(Mandatory = false, HelpMessage = ParamHelpMsgs.ResourceGuard.AuxiliaryAccessToken, ValueFromPipeline = false)]
        [ValidateNotNullOrEmpty]
        public System.Security.SecureString SecureToken;

        [Parameter(Mandatory = false, HelpMessage = ParamHelpMsgs.Item.ForceOption)]
        public SwitchParameter Force { get; set; }

        public override void ExecuteCmdlet()
        {
            ExecutionBlock(() =>
            {
                base.ExecuteCmdlet();
                PsBackupProviderManager providerManager;
                JobBase jobObj = null;
                                
                // chck with nandini, source vault is default and can we name targetvault ? 
                ResourceIdentifier resourceIdentifier = new ResourceIdentifier(VaultId);
                string vaultName = resourceIdentifier.ResourceName;
                string resourceGroupName = resourceIdentifier.ResourceGroupName;

                // Step 1: Stop protection
                ConfirmAction(
                    Force.IsPresent,
                    string.Format(Resources.DisableProtectionWarning, Item.Name),
                    Resources.DisableProtectionMessage,
                    Item.Name, () =>
                    {
                        string plainToken = HelperUtils.GetPlainToken(null, SecureToken);

                        providerManager =
                            new PsBackupProviderManager(new Dictionary<System.Enum, object>()
                            {
                                { VaultParams.VaultName, vaultName },
                                { VaultParams.ResourceGroupName, resourceGroupName },
                                { ItemParams.Item, Item },
                                { ResourceGuardParams.Token, plainToken },
                            }, ServiceClientAdapter);

                        IPsBackupProvider psBackupProvider =
                            providerManager.GetProviderInstance(Item.WorkloadType, Item.BackupManagementType);
                        
                        if (RetainRecoveryPointsAsPerPolicy.IsPresent)
                        {
                            var itemResponse = psBackupProvider.SuspendBackup();
                            Logger.Instance.WriteDebug("Suspend backup response " + JsonConvert.SerializeObject(itemResponse));
                            jobObj = HandleCreatedJob(
                                itemResponse,
                                Resources.DisableProtectionOperation,
                                vaultName: vaultName,
                                resourceGroupName: resourceGroupName,
                                returnJobObject: true);
                        }
                        else
                        {
                            var itemResponse = psBackupProvider.DisableProtection();
                            Logger.Instance.WriteDebug("Stop protection with retain data forever response " + JsonConvert.SerializeObject(itemResponse));
                                                        
                            jobObj = HandleCreatedJob(
                                itemResponse,
                                Resources.DisableProtectionOperation,
                                vaultName: vaultName,
                                resourceGroupName: resourceGroupName, 
                                returnJobObject: true);
                        }

                        // Wait for job completion and ensure it succeeded
                        CmdletHelper.EnsureJobCompletedOrThrow(jobObj, vaultName, resourceGroupName, "disable protection", this);
                        WriteVerbose("Disabled protection successfully");
                    }
                );

                // Parse target vault information
                ResourceIdentifier targetResourceIdentifier = new ResourceIdentifier(TargetVaultId);
                string targetVaultName = targetResourceIdentifier.ResourceName;
                string targetResourceGroupName = targetResourceIdentifier.ResourceGroupName;

                // Step 2: Unregister/register container (only for supported workloads)
                ProtectableItemBase protectableItem = null;
                if (CmdletHelper.IsContainerUnregistrationRequired(Item.ContainerType, Item.BackupManagementType))
                {
                    var unregisterJobObj = CmdletHelper.UnregisterContainer(Item, vaultName, resourceGroupName, ServiceClientAdapter, this);
                    CmdletHelper.EnsureJobCompletedOrThrow(unregisterJobObj, vaultName, resourceGroupName, "container unregistration", this);

                    // After registration, trigger inquiry if needed to discover protectable items
                    if (Item.BackupManagementType == BackupManagementType.AzureWorkload)
                    {
                        // Register container in target vault using provider pattern
                        WriteVerbose("Registering container in target vault...");
                        CmdletHelper.RegisterContainerInTargetVault(Item, targetVaultName, targetResourceGroupName, ServiceClientAdapter);

                        WriteVerbose($"Triggering inquiry to discover {Item.WorkloadType} protectable items...");
                        protectableItem = CmdletHelper.TriggerInquiryAndGetProtectableItem(Item, targetVaultName, targetResourceGroupName, ServiceClientAdapter);
                    }
                }

                // Step 3: Configure backup in target vault
                WriteVerbose("Configuring backup in target vault now");
                // chck : switch context to the target vault's subscription

                // Create provider manager for target vault with workload-specific parameters
                Dictionary<Enum, object> targetProviderParams = new Dictionary<Enum, object>()
                {
                    { VaultParams.VaultName, targetVaultName },
                    { VaultParams.ResourceGroupName, targetResourceGroupName },
                    { ItemParams.Policy, TargetPolicy },
                    { ResourceGuardParams.IsMUAOperation, false }
                };

                // Add workload-specific parameters based on item type
                if (Item.WorkloadType == WorkloadType.AzureVM)
                {
                    // For VM: extract VM name and resource group from VirtualMachineId
                    AzureVmItem vmItem = (AzureVmItem)Item;
                    string vmName = BackupUtils.ExtractVmNameFromVmId(vmItem.VirtualMachineId); // chck if we should use sourceresourceid here

                    Logger.Instance.WriteDebug($"Reconfiguring Azure VM protection - SourceResourceId: {vmItem.SourceResourceId}, VirtualMachineId: {vmItem.VirtualMachineId}");

                    string vmResourceGroupName = BackupUtils.ExtractVmResourceGroupFromVmId(vmItem.VirtualMachineId);
                    
                    targetProviderParams.Add(ItemParams.ItemName, vmName);
                    targetProviderParams.Add(ItemParams.AzureVMResourceGroupName, vmResourceGroupName);
                    targetProviderParams.Add(ItemParams.ParameterSetName, "AzureVMComputeEnableProtection");
                    if ((bool)vmItem.IsInclusionList) {
                        targetProviderParams.Add(ItemParams.InclusionDisksList, vmItem.DiskLunList);
                    }
                    else targetProviderParams.Add(ItemParams.ExclusionDisksList, vmItem.DiskLunList);

                    // chck handling for ItemParams.AzureVMCloudServiceName, { ItemParams.ResetExclusionSettings, ResetExclusionSettings },
                                //{ ItemParams.ExcludeAllDataDisks, ExcludeAllDataDisks.IsPresent },
                                //{ ResourceGuardParams.Token, plainToken },
                                //{ ResourceGuardParams.IsMUAOperation, isMUAOperation },
                }
                else if (Item.WorkloadType == WorkloadType.MSSQL )
                {
                    // For AzureWorkload: need to get protectable item                    
                    targetProviderParams.Add(ItemParams.ProtectableItem, protectableItem);
                    targetProviderParams.Add(ItemParams.ParameterSetName, "AzureWorkloadParameterSet");
                }
                else if (Item.WorkloadType == WorkloadType.AzureFiles)
                {
                    // For AzureFiles: extract file share name and storage account name
                    AzureFileShareItem afsItem = (AzureFileShareItem)Item;
                    string fileShareName = afsItem.FriendlyName; // chck : do we need name here?
                    string storageAccountName = BackupUtils.GetStorageAccountNameFromContainerName(afsItem.ContainerName);
                    
                    targetProviderParams.Add(ItemParams.ItemName, fileShareName);
                    targetProviderParams.Add(ItemParams.StorageAccountName, storageAccountName);
                    targetProviderParams.Add(ItemParams.ParameterSetName, "AzureFileShareParameterSet");
                }

                PsBackupProviderManager targetProviderManager = new PsBackupProviderManager(targetProviderParams, ServiceClientAdapter);

                WriteVerbose("Initialized provider manager for target vault");

                IPsBackupProvider targetPsBackupProvider = targetProviderManager.GetProviderInstance(Item.WorkloadType, Item.BackupManagementType);
                
                var enableResponse = targetPsBackupProvider.EnableProtection();

                WriteVerbose("Enabled protection successfully in target vault, tracking the job");

                // Track Response and display job details
                var enableProtectionJob = HandleCreatedJob(
                    enableResponse,
                    Resources.EnableProtectionOperation,
                    vaultName: targetVaultName,
                    resourceGroupName: targetResourceGroupName, returnJobObject: true);

                enableProtectionJob = CmdletHelper.EnsureJobCompletedOrThrow(enableProtectionJob, targetVaultName, targetResourceGroupName, "enable protection", this);
                WriteObject(enableProtectionJob);
                WriteVerbose("Reconfigure backup protection operation completed successfully.");

            }, ShouldProcess(Item.Name, "Reconfigure"));
        }
    }
}