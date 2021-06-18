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
using Microsoft.Azure.Commands.RecoveryServices.Backup.Properties;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;
using Microsoft.Azure.Management.RecoveryServices.Backup.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using BackupManagementType = Microsoft.Azure.Commands.RecoveryServices.Backup.Cmdlets.Models.BackupManagementType;
using WorkloadType = Microsoft.Azure.Commands.RecoveryServices.Backup.Cmdlets.Models.WorkloadType;

namespace Microsoft.Azure.Commands.RecoveryServices.Backup.Cmdlets
{
    /// <summary>
    /// Restores an item using the recovery point provided within the recovery services vault
    /// </summary>
    [Cmdlet("Restore", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "RecoveryServicesBackupItem",
        DefaultParameterSetName = AzureVMParameterSet, SupportsShouldProcess = true), OutputType(typeof(JobBase))]
    public class RestoreAzureRmRecoveryServicesBackupItem : RSBackupVaultCmdletBase
    {
        internal const string AzureVMParameterSet = "AzureVMParameterSet";
        internal const string AzureVMManagedDiskParameterSet = "AzureVMManagedDiskParameterSet";
        internal const string AzureVMRestoreManagedAsUnmanaged = "AzureVMRestoreManagedAsUnmanaged";
        internal const string AzureVMRestoreUnmanagedAsManaged = "AzureVMRestoreUnmanagedAsManaged";
        internal const string AzureVMUnManagedDiskParameterSet = "AzureVMUnManagedDiskParameterSet";
        internal const string AzureFileShareParameterSet = "AzureFileShareParameterSet";
        internal const string AzureWorkloadParameterSet = "AzureWorkloadParameterSet";
       
        /// <summary>
        /// Location of the Recovery Services Vault.
        /// </summary>
        [Parameter(Mandatory = false, HelpMessage = "Location of the Recovery Services Vault.",
            ValueFromPipeline = true)]
        [LocationCompleter("Microsoft.RecoveryServices/vaults")]
        [ValidateNotNullOrEmpty]
        public string VaultLocation { get; set; }

        /// <summary>
        /// Recovery point of the item to be restored
        /// </summary>
        [Parameter(Mandatory = true, ValueFromPipeline = true, Position = 0,
            ParameterSetName = AzureVMParameterSet, HelpMessage = ParamHelpMsgs.RestoreDisk.RecoveryPoint)]
        [Parameter(Mandatory = true, ValueFromPipeline = true, Position = 0,
            ParameterSetName = AzureFileShareParameterSet, HelpMessage = ParamHelpMsgs.RestoreDisk.RecoveryPoint)]
        [Parameter(Mandatory = true, ValueFromPipeline = true, Position = 0,
            ParameterSetName = AzureVMRestoreManagedAsUnmanaged, HelpMessage = ParamHelpMsgs.RestoreDisk.RecoveryPoint)]
        [Parameter(Mandatory = true, ValueFromPipeline = true, Position = 0,
            ParameterSetName = AzureVMManagedDiskParameterSet, HelpMessage = ParamHelpMsgs.RestoreDisk.RecoveryPoint)]
        [Parameter(Mandatory = true, ValueFromPipeline = true, Position = 0,
            ParameterSetName = AzureVMUnManagedDiskParameterSet, HelpMessage = ParamHelpMsgs.RestoreDisk.RecoveryPoint)]
        [Parameter(Mandatory = true, ValueFromPipeline = true, Position = 0,
            ParameterSetName = AzureVMRestoreUnmanagedAsManaged, HelpMessage = ParamHelpMsgs.RestoreDisk.RecoveryPoint)]
        [ValidateNotNullOrEmpty]
        public RecoveryPointBase RecoveryPoint { get; set; }

        /// <summary>
        /// Recovery point of the item to be restored
        /// </summary>
        [Parameter(Mandatory = true, ValueFromPipeline = true, Position = 0,
            ParameterSetName = AzureWorkloadParameterSet, HelpMessage = ParamHelpMsgs.RestoreDisk.RecoveryConfig)]
        [ValidateNotNullOrEmpty]
        public RecoveryConfigBase WLRecoveryConfig { get; set; }

        /// <summary>
        /// Storage account name where the disks need to be recovered
        /// </summary>
        [Parameter(Mandatory = true, Position = 1, ParameterSetName = AzureVMParameterSet,
            HelpMessage = ParamHelpMsgs.RestoreDisk.StorageAccountName)]
        [Parameter(Mandatory = true, Position = 1, ParameterSetName = AzureVMManagedDiskParameterSet,
            HelpMessage = ParamHelpMsgs.RestoreDisk.StorageAccountName)]
        [Parameter(Mandatory = true, Position = 1, ParameterSetName = AzureVMUnManagedDiskParameterSet,
            HelpMessage = ParamHelpMsgs.RestoreDisk.StorageAccountName)]
        [Parameter(Mandatory = true, Position = 1, ParameterSetName = AzureVMRestoreManagedAsUnmanaged,
            HelpMessage = ParamHelpMsgs.RestoreDisk.StorageAccountName)]
        [Parameter(Mandatory = true, Position = 1, ParameterSetName = AzureVMRestoreUnmanagedAsManaged,
            HelpMessage = ParamHelpMsgs.RestoreDisk.StorageAccountName)]
        [ValidateNotNullOrEmpty]
        public string StorageAccountName { get; set; }

        /// <summary>
        /// Resource group name of Storage account name where the disks need to be recovered
        /// </summary>
        [Parameter(Mandatory = true, Position = 2, ParameterSetName = AzureVMParameterSet,
            HelpMessage = ParamHelpMsgs.RestoreDisk.StorageAccountResourceGroupName)]
        [Parameter(Mandatory = true, Position = 2, ParameterSetName = AzureVMUnManagedDiskParameterSet,
            HelpMessage = ParamHelpMsgs.RestoreDisk.StorageAccountResourceGroupName)]
        [Parameter(Mandatory = true, Position = 2, ParameterSetName = AzureVMManagedDiskParameterSet,
            HelpMessage = ParamHelpMsgs.RestoreDisk.StorageAccountResourceGroupName)]
        [Parameter(Mandatory = true, Position = 2, ParameterSetName = AzureVMRestoreManagedAsUnmanaged,
            HelpMessage = ParamHelpMsgs.RestoreDisk.StorageAccountResourceGroupName)]
        [Parameter(Mandatory = true, Position = 2, ParameterSetName = AzureVMRestoreUnmanagedAsManaged,
            HelpMessage = ParamHelpMsgs.RestoreDisk.StorageAccountResourceGroupName)]
        [ValidateNotNullOrEmpty]
        public string StorageAccountResourceGroupName { get; set; }

        /// <summary> 
        /// The resource group to which the managed disks are restored. This parameter is mandatory for backup of VM with managed disks.
        /// </summary>
        [Parameter(Mandatory = true, Position = 3, ParameterSetName = AzureVMManagedDiskParameterSet,
            HelpMessage = ParamHelpMsgs.RestoreVM.TargetResourceGroupName)]
        [Parameter(Mandatory = true, Position = 3, ParameterSetName = AzureVMRestoreUnmanagedAsManaged,
            HelpMessage = ParamHelpMsgs.RestoreVM.TargetResourceGroupName)]
        [ValidateNotNullOrEmpty]
        public string TargetResourceGroupName { get; set; }

        /// <summary>
        /// Resolve conflict option
        /// </summary>
        [Parameter(Mandatory = true, ParameterSetName = AzureFileShareParameterSet,
            HelpMessage = ParamHelpMsgs.RestoreFS.ResolveConflict)]
        [ValidateNotNullOrEmpty]
        public RestoreFSResolveConflictOption ResolveConflict { get; set; }

        /// <summary>
        /// Source File Path of the file to be recovered
        /// </summary>
        [Parameter(Mandatory = false, ParameterSetName = AzureFileShareParameterSet,
            HelpMessage = ParamHelpMsgs.RestoreFS.SourceFilePath)]
        [ValidateNotNullOrEmpty]
        public string SourceFilePath { get; set; }

        /// <summary>
        /// Source File Type of the file to be recovered
        /// </summary>
        [Parameter(Mandatory = false, ParameterSetName = AzureFileShareParameterSet,
            HelpMessage = ParamHelpMsgs.RestoreFS.SourceFilePath)]
        [ValidateNotNullOrEmpty]
        public SourceFileType? SourceFileType { get; set; }

        /// <summary>
        /// Target storage account name where the disks need to be recovered
        /// </summary>
        [Parameter(Mandatory = false, ParameterSetName = AzureFileShareParameterSet,
            HelpMessage = ParamHelpMsgs.RestoreFS.TargetStorageAccountName)]
        [ValidateNotNullOrEmpty]
        public string TargetStorageAccountName { get; set; }

        /// <summary> 
        /// The target file share name to which the files are restored.
        /// </summary>
        [Parameter(Mandatory = false, ParameterSetName = AzureFileShareParameterSet,
            HelpMessage = ParamHelpMsgs.RestoreFS.TargetFileShareName)]
        [ValidateNotNullOrEmpty]
        public string TargetFileShareName { get; set; }

        /// <summary> 
        /// The target folder name to which the files are restored.
        /// </summary>
        [Parameter(Mandatory = false, ParameterSetName = AzureFileShareParameterSet,
            HelpMessage = ParamHelpMsgs.RestoreFS.TargetFolder)]
        [ValidateNotNullOrEmpty]
        public string TargetFolder { get; set; }

        /// <summary>
        /// Array of source file paths to be recovered
        /// </summary>
        [Parameter(Mandatory = false, ParameterSetName = AzureFileShareParameterSet,
            HelpMessage = ParamHelpMsgs.RestoreFS.MultipleSourceFilePath)]
        public string[] MultipleSourceFilePath { get; set; }

        /// <summary>
        /// Use this switch if the disks from the recovery point are to be restored to their original storage accounts
        /// </summary>
        [Parameter(Mandatory = true, ParameterSetName = AzureVMUnManagedDiskParameterSet,
            HelpMessage = ParamHelpMsgs.RestoreVM.OsaOption)]
        [Parameter(Mandatory = false, ParameterSetName = AzureVMRestoreUnmanagedAsManaged,
            HelpMessage = ParamHelpMsgs.RestoreVM.OsaOption)]
        public SwitchParameter UseOriginalStorageAccount { get; set; }

        /// <summary>
        /// Use this switch to restore only OS disks of the backed up VM
        /// </summary>
        [Parameter(Mandatory = false, ParameterSetName = AzureVMParameterSet,
            HelpMessage = ParamHelpMsgs.RestoreVM.RestoreOnlyOSDisk)]
        [Parameter(Mandatory = false, ParameterSetName = AzureVMManagedDiskParameterSet,
            HelpMessage = ParamHelpMsgs.RestoreVM.RestoreOnlyOSDisk)]
        [Parameter(Mandatory = false, ParameterSetName = AzureVMRestoreManagedAsUnmanaged,
            HelpMessage = ParamHelpMsgs.RestoreVM.RestoreOnlyOSDisk)]
        [Parameter(Mandatory = false, ParameterSetName = AzureVMUnManagedDiskParameterSet,
            HelpMessage = ParamHelpMsgs.RestoreVM.RestoreOnlyOSDisk)]
        [Parameter(Mandatory = false, ParameterSetName = AzureVMRestoreUnmanagedAsManaged,
            HelpMessage = ParamHelpMsgs.RestoreVM.RestoreOnlyOSDisk)]
        public SwitchParameter RestoreOnlyOSDisk { get; set; }

        /// <summary>
        /// Specify which disks to recover of the backed up VM
        /// </summary>
        [Parameter(Mandatory = false, ParameterSetName = AzureVMParameterSet,
            HelpMessage = ParamHelpMsgs.RestoreVM.RestoreDiskList)]
        [Parameter(Mandatory = false, ParameterSetName = AzureVMUnManagedDiskParameterSet,
            HelpMessage = ParamHelpMsgs.RestoreVM.RestoreDiskList)]
        [Parameter(Mandatory = false, ParameterSetName = AzureVMManagedDiskParameterSet,
            HelpMessage = ParamHelpMsgs.RestoreVM.RestoreDiskList)]
        [Parameter(Mandatory = false, ParameterSetName = AzureVMRestoreManagedAsUnmanaged,
            HelpMessage = ParamHelpMsgs.RestoreVM.RestoreDiskList)]
        [Parameter(Mandatory = false, ParameterSetName = AzureVMRestoreUnmanagedAsManaged,
            HelpMessage = ParamHelpMsgs.RestoreVM.RestoreDiskList)]
        public string[] RestoreDiskList { get; set; }

        /// <summary>
        /// Use this switch to specify to restore as unmanaged disks
        /// </summary>
        [Parameter(Mandatory = true, ParameterSetName = AzureVMRestoreManagedAsUnmanaged,
            HelpMessage = ParamHelpMsgs.RestoreVM.RestoreAsUnmanagedDisks)]
        public SwitchParameter RestoreAsUnmanagedDisks { get; set; }

        /// <summary>
        /// Disk Encryption Set to encrypt the restored VM
        /// </summary>
        [Parameter(Mandatory = false, ParameterSetName = AzureVMParameterSet, 
            HelpMessage = ParamHelpMsgs.Encryption.DES)]
        [Parameter(Mandatory = false, ParameterSetName = AzureVMManagedDiskParameterSet,
            HelpMessage = ParamHelpMsgs.Encryption.DES)]
        public string DiskEncryptionSetId { get; set; }

        /// <summary>
        /// Switch param to trigger restore to secondary region (Cross Region Restore).
        /// </summary>
        [Parameter(Mandatory = false, HelpMessage = ParamHelpMsgs.RestoreDisk.UseSecondaryReg)]
        [ValidateNotNullOrEmpty]
        public SwitchParameter RestoreToSecondaryRegion { get; set; }

        /// <summary>
        /// Target Zone Number to restore the VM disks
        /// </summary>
        [Parameter(Mandatory = false, ParameterSetName = AzureVMParameterSet,
            HelpMessage = ParamHelpMsgs.RestoreVM.TargetZone)]
        [Parameter(Mandatory = false, ParameterSetName = AzureVMManagedDiskParameterSet,
            HelpMessage = ParamHelpMsgs.RestoreVM.TargetZone)]
        public int? TargetZoneNumber { get; set; }

        /// <summary>
        /// Switch param to restore a backed up unmanaged vm as managed disks.
        /// </summary>
        [Parameter(Mandatory = true, ParameterSetName = AzureVMRestoreUnmanagedAsManaged, HelpMessage = ParamHelpMsgs.RestoreVM.RestoreAsManagedDisk)]
        [ValidateNotNullOrEmpty]
        public SwitchParameter RestoreAsManagedDisk { get; set; }

        public override void ExecuteCmdlet()
        {
            ExecutionBlock(() =>
            {
                base.ExecuteCmdlet();

                ResourceIdentifier resourceIdentifier = new ResourceIdentifier(VaultId);
                string vaultName = resourceIdentifier.ResourceName;
                string resourceGroupName = resourceIdentifier.ResourceGroupName;
                Dictionary<Enum, object> providerParameters = new Dictionary<Enum, object>();
                
                string secondaryRegion = "";
                if (RestoreToSecondaryRegion.IsPresent)
                {
                    ARSVault vault = ServiceClientAdapter.GetVault(resourceGroupName, vaultName);
                    secondaryRegion = BackupUtils.regionMap[vault.Location];
                    providerParameters.Add(CRRParams.SecondaryRegion, secondaryRegion);
                }

                providerParameters.Add(VaultParams.VaultName, vaultName);
                providerParameters.Add(VaultParams.ResourceGroupName, resourceGroupName);
                providerParameters.Add(VaultParams.VaultLocation, VaultLocation);
                providerParameters.Add(RestoreBackupItemParams.RecoveryPoint, RecoveryPoint);
                providerParameters.Add(RestoreVMBackupItemParams.OsaOption, UseOriginalStorageAccount.IsPresent);
                providerParameters.Add(RestoreFSBackupItemParams.ResolveConflict, ResolveConflict.ToString());
                providerParameters.Add(RestoreFSBackupItemParams.SourceFilePath, SourceFilePath);
                providerParameters.Add(RestoreFSBackupItemParams.TargetStorageAccountName, TargetStorageAccountName);
                providerParameters.Add(RestoreFSBackupItemParams.TargetFileShareName, TargetFileShareName);
                providerParameters.Add(RestoreFSBackupItemParams.TargetFolder, TargetFolder);
                providerParameters.Add(RestoreWLBackupItemParams.WLRecoveryConfig, WLRecoveryConfig);
                providerParameters.Add(RestoreVMBackupItemParams.RestoreDiskList, RestoreDiskList);
                providerParameters.Add(RestoreVMBackupItemParams.RestoreOnlyOSDisk, RestoreOnlyOSDisk);
                providerParameters.Add(RestoreVMBackupItemParams.RestoreAsUnmanagedDisks, RestoreAsUnmanagedDisks);
                providerParameters.Add(CRRParams.UseSecondaryRegion, RestoreToSecondaryRegion.IsPresent);
                providerParameters.Add(RestoreVMBackupItemParams.RestoreAsManagedDisk, RestoreAsManagedDisk.IsPresent);

                if (DiskEncryptionSetId != null)
                {
                    AzureVmRecoveryPoint rp = (AzureVmRecoveryPoint)RecoveryPoint;

                    BackupResourceEncryptionConfigResource vaultEncryptionSettings = ServiceClientAdapter.GetVaultEncryptionConfig(resourceGroupName, vaultName);
                    
                    if ((vaultEncryptionSettings.Properties.EncryptionAtRestType == "CustomerManaged") && rp.IsManagedVirtualMachine && !(rp.EncryptionEnabled) && !(RestoreToSecondaryRegion.IsPresent))
                    {
                        providerParameters.Add(RestoreVMBackupItemParams.DiskEncryptionSetId, DiskEncryptionSetId);
                    }
                }

                if (TargetZoneNumber != null)
                {   
                    // get storage type 
                    BackupResourceConfigResource getStorageResponse = ServiceClientAdapter.GetVaultStorageType(resourceGroupName, vaultName);
                    string storageType = getStorageResponse.Properties.StorageType;
                    bool crrEnabled = (bool)getStorageResponse.Properties.CrossRegionRestoreFlag;

                    if (storageType == AzureRmRecoveryServicesBackupStorageRedundancyType.ZoneRedundant.ToString() ||
                    (storageType == AzureRmRecoveryServicesBackupStorageRedundancyType.GeoRedundant.ToString() && crrEnabled))
                    {
                        AzureVmRecoveryPoint rp = (AzureVmRecoveryPoint)RecoveryPoint;
                        if (rp.RecoveryPointTier == RecoveryPointTier.VaultStandard)  // RP recovery type should be vault only
                        {
                            if (rp.Zones != null)
                            {
                                //target region should support Zones 
                                /*if (RestoreToSecondaryRegion.IsPresent)
                                {
                                    FeatureSupportRequest iaasvmFeatureRequest = new FeatureSupportRequest();
                                    ServiceClientAdapter.BmsAdapter.Client.FeatureSupport.ValidateWithHttpMessagesAsync(secondaryRegion, iaasvmFeatureRequest);
                                }*/
                                providerParameters.Add(RecoveryPointParams.TargetZone, TargetZoneNumber);
                            }
                            else
                            {
                                throw new ArgumentException(string.Format(Resources.RecoveryPointZonePinnedException));
                            }
                        }
                        else
                        {
                            throw new ArgumentException(string.Format(Resources.RecoveryPointVaultRecoveryTypeException));
                        }
                    }
                    else
                    {
                        throw new ArgumentException(string.Format(Resources.ZonalRestoreVaultStorageRedundancyException));
                    }
                }

                if (StorageAccountName != null)
                {
                    providerParameters.Add(RestoreBackupItemParams.StorageAccountName, StorageAccountName);
                }

                if (StorageAccountResourceGroupName != null)
                {
                    providerParameters.Add(RestoreBackupItemParams.StorageAccountResourceGroupName, StorageAccountResourceGroupName);
                }

                if (TargetResourceGroupName != null)
                {
                    providerParameters.Add(RestoreVMBackupItemParams.TargetResourceGroupName, TargetResourceGroupName);
                }

                if (SourceFileType != null)
                {
                    providerParameters.Add(RestoreFSBackupItemParams.SourceFileType, SourceFileType.ToString());
                }

                if(MultipleSourceFilePath != null)
                {
                    providerParameters.Add(RestoreFSBackupItemParams.MultipleSourceFilePath, MultipleSourceFilePath);
                }

                PsBackupProviderManager providerManager =
                    new PsBackupProviderManager(providerParameters, ServiceClientAdapter);
                IPsBackupProvider psBackupProvider = null;
                if (string.Compare(ParameterSetName, AzureWorkloadParameterSet) != 0)
                {
                    psBackupProvider = providerManager.GetProviderInstance(
                        RecoveryPoint.WorkloadType, RecoveryPoint.BackupManagementType);
                }
                else
                {
                    psBackupProvider = providerManager.GetProviderInstance(
                        WorkloadType.MSSQL, BackupManagementType.AzureWorkload);
                }
                var jobResponse = psBackupProvider.TriggerRestore();

                if (RestoreToSecondaryRegion.IsPresent)
                {
                    var operationId = jobResponse.Request.RequestUri.Segments.Last();
                    var response = ServiceClientAdapter.GetCrrOperationStatus(secondaryRegion, operationId);

                    string jobIDJson = JsonConvert.SerializeObject(response.Body.Properties);
                    string[] jobSplits = jobIDJson.Split(new char[] { '\"' });
                    string jobID = jobSplits[jobSplits.Length - 2];
                    WriteObject(GetCrrJobObject(secondaryRegion, VaultId, jobID));
                }
                else
                {
                    HandleCreatedJob(
                    jobResponse,
                    Resources.RestoreOperation,
                    vaultName: vaultName,
                    resourceGroupName: resourceGroupName);
                }
            }, ShouldProcess(RecoveryPoint != null ? RecoveryPoint.ItemName : WLRecoveryConfig.ToString(), VerbsData.Restore));
        }
    }
}
