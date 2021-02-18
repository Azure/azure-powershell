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
<<<<<<< HEAD
using Microsoft.Azure.Commands.RecoveryServices.Backup.Properties;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;
using System;
using System.Collections.Generic;
using System.Management.Automation;
=======
using Microsoft.Azure.Commands.RecoveryServices.Backup.Helpers;
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
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a

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
<<<<<<< HEAD
        internal const string AzureFileParameterSet = "AzureFileParameterSet";
        internal const string AzureWorkloadParameterSet = "AzureWorkloadParameterSet";

=======
        internal const string AzureVMManagedDiskParameterSet = "AzureVMManagedDiskParameterSet";
        internal const string AzureVMRestoreManagedAsUnmanaged = "AzureVMRestoreManagedAsUnmanaged";
        internal const string AzureVMUnManagedDiskParameterSet = "AzureVMUnManagedDiskParameterSet";
        internal const string AzureFileShareParameterSet = "AzureFileShareParameterSet";
        internal const string AzureWorkloadParameterSet = "AzureWorkloadParameterSet";
       
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
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
<<<<<<< HEAD
            ParameterSetName = AzureFileParameterSet, HelpMessage = ParamHelpMsgs.RestoreDisk.RecoveryPoint)]
=======
            ParameterSetName = AzureFileShareParameterSet, HelpMessage = ParamHelpMsgs.RestoreDisk.RecoveryPoint)]
        [Parameter(Mandatory = true, ValueFromPipeline = true, Position = 0,
            ParameterSetName = AzureVMRestoreManagedAsUnmanaged, HelpMessage = ParamHelpMsgs.RestoreDisk.RecoveryPoint)]
        [Parameter(Mandatory = true, ValueFromPipeline = true, Position = 0,
            ParameterSetName = AzureVMManagedDiskParameterSet, HelpMessage = ParamHelpMsgs.RestoreDisk.RecoveryPoint)]
        [Parameter(Mandatory = true, ValueFromPipeline = true, Position = 0,
            ParameterSetName = AzureVMUnManagedDiskParameterSet, HelpMessage = ParamHelpMsgs.RestoreDisk.RecoveryPoint)]
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
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
<<<<<<< HEAD
=======
        [Parameter(Mandatory = true, Position = 1, ParameterSetName = AzureVMManagedDiskParameterSet,
            HelpMessage = ParamHelpMsgs.RestoreDisk.StorageAccountName)]
        [Parameter(Mandatory = true, Position = 1, ParameterSetName = AzureVMUnManagedDiskParameterSet,
            HelpMessage = ParamHelpMsgs.RestoreDisk.StorageAccountName)]
        [Parameter(Mandatory = true, Position = 1, ParameterSetName = AzureVMRestoreManagedAsUnmanaged,
            HelpMessage = ParamHelpMsgs.RestoreDisk.StorageAccountName)]
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
        [ValidateNotNullOrEmpty]
        public string StorageAccountName { get; set; }

        /// <summary>
        /// Resource group name of Storage account name where the disks need to be recovered
        /// </summary>
        [Parameter(Mandatory = true, Position = 2, ParameterSetName = AzureVMParameterSet,
            HelpMessage = ParamHelpMsgs.RestoreDisk.StorageAccountResourceGroupName)]
<<<<<<< HEAD
=======
        [Parameter(Mandatory = true, Position = 2, ParameterSetName = AzureVMUnManagedDiskParameterSet,
            HelpMessage = ParamHelpMsgs.RestoreDisk.StorageAccountResourceGroupName)]
        [Parameter(Mandatory = true, Position = 2, ParameterSetName = AzureVMManagedDiskParameterSet,
            HelpMessage = ParamHelpMsgs.RestoreDisk.StorageAccountResourceGroupName)]
        [Parameter(Mandatory = true, Position = 2, ParameterSetName = AzureVMRestoreManagedAsUnmanaged,
            HelpMessage = ParamHelpMsgs.RestoreDisk.StorageAccountResourceGroupName)]
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
        [ValidateNotNullOrEmpty]
        public string StorageAccountResourceGroupName { get; set; }

        /// <summary> 
        /// The resource group to which the managed disks are restored. This parameter is mandatory for backup of VM with managed disks.
        /// </summary>
<<<<<<< HEAD
        [Parameter(Mandatory = false, Position = 3, ParameterSetName = AzureVMParameterSet,
=======
        [Parameter(Mandatory = true, Position = 3, ParameterSetName = AzureVMManagedDiskParameterSet,
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
            HelpMessage = ParamHelpMsgs.RestoreVM.TargetResourceGroupName)]
        [ValidateNotNullOrEmpty]
        public string TargetResourceGroupName { get; set; }

        /// <summary>
        /// Resolve conflict option
        /// </summary>
<<<<<<< HEAD
        [Parameter(Mandatory = true, ParameterSetName = AzureFileParameterSet,
=======
        [Parameter(Mandatory = true, ParameterSetName = AzureFileShareParameterSet,
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
            HelpMessage = ParamHelpMsgs.RestoreFS.ResolveConflict)]
        [ValidateNotNullOrEmpty]
        public RestoreFSResolveConflictOption ResolveConflict { get; set; }

        /// <summary>
        /// Source File Path of the file to be recovered
        /// </summary>
<<<<<<< HEAD
        [Parameter(Mandatory = false, ParameterSetName = AzureFileParameterSet,
=======
        [Parameter(Mandatory = false, ParameterSetName = AzureFileShareParameterSet,
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
            HelpMessage = ParamHelpMsgs.RestoreFS.SourceFilePath)]
        [ValidateNotNullOrEmpty]
        public string SourceFilePath { get; set; }

        /// <summary>
        /// Source File Type of the file to be recovered
        /// </summary>
<<<<<<< HEAD
        [Parameter(Mandatory = false, ParameterSetName = AzureFileParameterSet,
=======
        [Parameter(Mandatory = false, ParameterSetName = AzureFileShareParameterSet,
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
            HelpMessage = ParamHelpMsgs.RestoreFS.SourceFilePath)]
        [ValidateNotNullOrEmpty]
        public SourceFileType? SourceFileType { get; set; }

        /// <summary>
        /// Target storage account name where the disks need to be recovered
        /// </summary>
<<<<<<< HEAD
        [Parameter(Mandatory = false, ParameterSetName = AzureFileParameterSet,
=======
        [Parameter(Mandatory = false, ParameterSetName = AzureFileShareParameterSet,
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
            HelpMessage = ParamHelpMsgs.RestoreFS.TargetStorageAccountName)]
        [ValidateNotNullOrEmpty]
        public string TargetStorageAccountName { get; set; }

        /// <summary> 
        /// The target file share name to which the files are restored.
        /// </summary>
<<<<<<< HEAD
        [Parameter(Mandatory = false, ParameterSetName = AzureFileParameterSet,
=======
        [Parameter(Mandatory = false, ParameterSetName = AzureFileShareParameterSet,
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
            HelpMessage = ParamHelpMsgs.RestoreFS.TargetFileShareName)]
        [ValidateNotNullOrEmpty]
        public string TargetFileShareName { get; set; }

        /// <summary> 
        /// The target folder name to which the files are restored.
        /// </summary>
<<<<<<< HEAD
        [Parameter(Mandatory = false, ParameterSetName = AzureFileParameterSet,
=======
        [Parameter(Mandatory = false, ParameterSetName = AzureFileShareParameterSet,
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
            HelpMessage = ParamHelpMsgs.RestoreFS.TargetFolder)]
        [ValidateNotNullOrEmpty]
        public string TargetFolder { get; set; }

        /// <summary>
<<<<<<< HEAD
        /// Use this switch if the disks from the recovery point are to be restored to their original storage accounts
        /// </summary>
        [Parameter(Mandatory = false, ParameterSetName = AzureVMParameterSet,
            HelpMessage = ParamHelpMsgs.RestoreVM.OsaOption)]
        public SwitchParameter UseOriginalStorageAccount { get; set; }

=======
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

>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
        public override void ExecuteCmdlet()
        {
            ExecutionBlock(() =>
            {
                base.ExecuteCmdlet();

                ResourceIdentifier resourceIdentifier = new ResourceIdentifier(VaultId);
                string vaultName = resourceIdentifier.ResourceName;
                string resourceGroupName = resourceIdentifier.ResourceGroupName;
                Dictionary<Enum, object> providerParameters = new Dictionary<Enum, object>();
<<<<<<< HEAD
=======
                
                string secondaryRegion = "";
                if (RestoreToSecondaryRegion.IsPresent)
                {
                    ARSVault vault = ServiceClientAdapter.GetVault(resourceGroupName, vaultName);
                    secondaryRegion = BackupUtils.regionMap[vault.Location];
                    providerParameters.Add(CRRParams.SecondaryRegion, secondaryRegion);
                }
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a

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
<<<<<<< HEAD
=======
                providerParameters.Add(RestoreVMBackupItemParams.RestoreDiskList, RestoreDiskList);
                providerParameters.Add(RestoreVMBackupItemParams.RestoreOnlyOSDisk, RestoreOnlyOSDisk);
                providerParameters.Add(RestoreVMBackupItemParams.RestoreAsUnmanagedDisks, RestoreAsUnmanagedDisks);
                providerParameters.Add(CRRParams.UseSecondaryRegion, RestoreToSecondaryRegion.IsPresent);

                if (DiskEncryptionSetId != null)
                {
                    AzureVmRecoveryPoint rp = (AzureVmRecoveryPoint)RecoveryPoint;

                    BackupResourceEncryptionConfigResource vaultEncryptionSettings = ServiceClientAdapter.GetVaultEncryptionConfig(resourceGroupName, vaultName);
                    
                    if ((vaultEncryptionSettings.Properties.EncryptionAtRestType == "CustomerManaged") && rp.IsManagedVirtualMachine && !(rp.EncryptionEnabled) && !(RestoreToSecondaryRegion.IsPresent))
                    {
                        providerParameters.Add(RestoreVMBackupItemParams.DiskEncryptionSetId, DiskEncryptionSetId);
                    }
                }
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a

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

<<<<<<< HEAD
=======
                if(MultipleSourceFilePath != null)
                {
                    providerParameters.Add(RestoreFSBackupItemParams.MultipleSourceFilePath, MultipleSourceFilePath);
                }

>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
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
<<<<<<< HEAD
                var jobResponse = psBackupProvider.TriggerRestore();
                WriteDebug(string.Format("Restore submitted"));
                HandleCreatedJob(
=======
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
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
                    jobResponse,
                    Resources.RestoreOperation,
                    vaultName: vaultName,
                    resourceGroupName: resourceGroupName);
<<<<<<< HEAD
=======
                }
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
            }, ShouldProcess(RecoveryPoint != null ? RecoveryPoint.ItemName : WLRecoveryConfig.ToString(), VerbsData.Restore));
        }
    }
}
