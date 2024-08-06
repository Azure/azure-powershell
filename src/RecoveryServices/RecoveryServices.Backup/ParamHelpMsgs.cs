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
using System.Configuration.Internal;
using System.Runtime.CompilerServices;

namespace Microsoft.Azure.Commands.RecoveryServices.Backup.Cmdlets
{
    /// <summary>
    /// Class enclosing the cmdlet parameter help messages
    /// </summary>
    internal static class ParamHelpMsgs
    {
        internal static class Container
        {
            public const string Name = "The name of the resource being managed by the Azure Backup service (for example: resource name of the VM).";
            public const string ResourceGroupName = "The ResourceGroup of the resource being managed by the Azure Backup service" +
                " (for example: ResourceGroup name of the VM).";
            public const string Status = "The registration status of the Azure Backup container.";
            public const string ContainerType = "The type of the Azure Backup container (for example:  Windows Server or Azure IaaS VM).";
            public const string BackupManagementType = "The class of resources being protected.";
            public const string RegisteredContainer = "The recovery services backup container.";
            public const string FriendlyName = "The name of the resource being managed by the" +
                " Azure Backup service (for example: resource name of the VM).";
            public const string ResourceId = "ID of the Azure Resource containing items to be protected by Azure Backup service. Currently, only Azure VM resource IDs are supported.";
            public const string ContainerObj = "Container object that needs to be re registered.";
            public const string ForceOption = "Force registers container (prevents confirmation dialog). This parameter is optional.";
            public const string ForceUnregister = "Force unregisters container (prevents confirmation dialog). This parameter is optional.";
        }

        internal static class Common
        {
            public const string Vault = "The Azure Backup vault object which is the parent resource.";
            public const string VaultId = "Resource ID of the Recovery Services Vault.";
            public const string WorkloadType = "Workload type of the resource. The current supported values are ";
            public const string ConfirmationMessage = "Don't ask for confirmation.";
            public const string BackupManagementType = "The class of resources being protected. Currently the values supported for this cmdlet are ";
            public const string IdentityType = "The MSI type assigned to Recovery Services Vault. Input 'None' if MSI has to be removed."; 
            public const string UseSecondaryReg = "Filters from Secondary Region for Cross Region Restore";
            public const string HybridBackupSecurity = "Optional flag ($true/$false) to disable/enable security setting for hybrid backups against accidental deletes and add additional layer of authentication for critical operations. Provide $false to enable the security.";
        }

        internal static class Policy
        {
            public const string Name = "Name of the Policy that is being managed.";
            public const string RetentionPolicy = "Retention Policy object for the policy.";
            public const string SchedulePolicy = "Schedule Policy object for the policy.";
            public const string ScheduleRunFrequency = "Schedule run frequency for the policy schedule.";
            public const string ScheduleFrequencyForRetention = "Frequency of the schedule for which base retention policy object is fetched. Acceptable values are Daily and Hourly.";
            public const string ProtectionPolicy = "Protection policy object.";
            public const string FixForInConsistentItems = "Switch Parameter indicating whether or not to retry Policy Update for failed items.";
            public const string EnableProtectionPolicy = "Protection policy object. If policy ID is not present or the backup item is not associated with any" +
                " policy, then this command will expect a policyID.";
            public const string SchedulePolicySubType = "Type of schedule policy to be fetched: Standard, Enhanced";
            public const string PolicySubType = "Type of policy to be fetched: Standard, Enhanced";
            public const string MoveToArchiveTier = "Specifies whether recovery points should be moved to archive storage by the policy or not. Allowed values are $true, $false";
            public const string IsSmartTieringEnabled = "Parameter to list policies for which smart tiering is Enabled/Disabled. Allowed values are $true, $false.";
            public const string TieringMode = "Specifies whether to move recommended or all eligible recovery points to archive";
            public const string TierAfterDuration = "Specifies the duration after which recovery points should start moving to the archive tier, value can be in days or months. Applicable only when TieringMode is TierAllEligible";
            public const string TierAfterDurationType = "Specifies whether the TierAfterDuration is in Days or Months";
            public const string AzureBackupResourceGroup = "Custom resource group name to store the instant recovery points of managed virtual machines. This is optional";
            public const string AzureBackupResourceGroupSuffix = "Custom resource group name suffix to store the instant recovery points of managed virtual machines. This is optional";
            public const string SnapshotConsistencyType = "Snapshot consistency type to be used for backup. If set to OnlyCrashConsistent, all associated items will have crash consistent snapshot. Possible values are OnlyCrashConsistent, Default";
        }

        internal static class Job
        {
            public const string FromFilter = "Beginning value of time range for which jobs have to be fetched.";
            public const string ToFilter = "Ending value of time range for which jobs have to be fetched.";
            public const string OperationFilter = "Filter value for type of job.";
            public const string StatusFilter = "Filter value for status of job.";
            public const string JobIdFilter = "Filter value for Id of job.";
            public const string JobFilter = "Job whose latest object has to be fetched.";
            public const string WaitJobOrListFilter = "Job or List of jobs until end of which the cmdlet should wait.";
            public const string WaitJobTimeoutFilter = "Maximum time to wait before aborting wait in seconds.";
            public const string StopJobJobIdFilter = "Id of Job to be stopped.";
            public const string StopJobJobFilter = "Job to be stopped.";
        }

        internal static class Item
        {
            public const string ItemName = "Specifies the name of backup item. For file share, specify the unique ID of protected file share.";
            public const string AzureVMServiceName = "Cloud Service Name for Azure Classic Compute VM.";
            public const string AzureVMResourceGroupName = "Resource Group Name for Azure Compute VM .";
            public const string ProtectedItem = "Specifies the item to be protected with the given policy.";
            public const string SuspendItem = "Specifies the item for which the backup needs to be suspended.";
            public const string ProtectableItem = "Specifies the protectable item to be protected using Azure Backup.";
            public const string ProtectionStatus = "Protection status of Item";
            public const string Status = "Status of the data source";
            public const string DeleteState = "Delete state of the item";
            public const string Container = "Container where the item resides";
            public const string RemoveProtectionOption = "If this option is used, all the recovery points for this item will also be deleted and restoring will not be possible.";
            public const string SuspendBackupOption = "If this option is used, all the recovery points for this item will expire as per the retention policy.";
            public const string ExpiryDate = "Retention period for the recovery points created by this backup operaiton";
            public const string ForceOption = "Force disables backup protection (prevents confirmation dialog). This parameter is optional.";
            public const string ForceSuspend = "Force suspends backup.";
            public const string ExpiryDateTimeUTC = "Specifies an expiry time for the Recovery point as a DateTime object, " + 
                "if nothing is given it takes the default value of  30 days. Applicable to VM, SQL (for only Copy-only-full backup type), AFS backup items.";
            public const string ProtectionPolicy = "The id of the backup policy which is used to protect the backup items";
            public const string AzureFileShareName = "Azure FileShare Name.";
            public const string AzureFileStorageAccountName = "Azure file share storage account name";
            public const string AzureFileStorageAccountResourceGroupName = "Azure file share storage account resource group name";
            public const string BackupType = "Specifies the type of backup to be taken for an on-demand backup. Allowed values are “CopyOnlyFull”, “Full”, “Differential”, “Log”.";
            public const string EnableCompression = "A switch which will specify that the requested on-demand SQL backup should be compressed.";
            public const string ParentID = "Specified the ARM ID of an Instance or AG.";
            public const string FriendlyName = "FriendlyName of the backed up item";
            public const string inclusionDiskList = "List of Disk LUNs to be included in backup and the rest are automatically excluded except OS disk.";
            public const string exclusionDiskList = "List of Disk LUNs to be excluded in backup and the rest are automatically included.";
            public const string resetExclusionSettings = "Specifies to reset disk exclusion setting associated with the item";
            public const string excludeAllDataDisks = "Option to specify to backup OS disks only";
            public const string ReprotectItem = "Specifies the backup item for which this cmdlet reverts the deletion."; 
        }

        internal static class ProtectableItem
        {
            public const string ItemType = "Specifies the type of protectable item. Applicable values: (SQLDataBase, SQLInstance, SQLAvailabilityGroup).";
            public const string ItemId = "Specifies the parent entity under which the protectable items (DBs) are to be retrieved. IDs of protectable item types SQLInstance, SQLAvailabilityGroup are applicable.";
            public const string ItemObject = "Specifies the protectable item object that can be passed as an input. The current supported value is a protectableItem object of type 'SQLInstance'." ;
            public const string Name = "Specifies the name of the Database, Instance or AvailabilityGroup.";
            public const string ServerName = "Specifies the name of the server to which the item belongs.";
            public const string ItemContainer = "Returns the container where the discovery is being triggered.";
        }

        internal static class RecoveryPoint
        {
            public const string StartDate = "Start time of Time range for which recovery point need to be fetched";
            public const string EndDate = "End time of Time range for which recovery point need to be fetched";
            public const string Item = "Protected Item object for which recovery point need to be fetched";
            public const string RecoveryPointId = "Recovery point Id for which detail is needed";
            public const string ILRRecoveryPoint = "Recovery point to be explored for file folder restore";
            public const string ILRConnect = "Initiate an iCSCI connection for file folder restore";
            public const string ILRExtend = "Extend the existing iCSCI connection for file folder restore";
            public const string ILRTerminate = "Terminate the existing iCSCI connection for file folder restore";
            public const string KeyFileDownloadLocation = "Location where the key file should be downloaded in the case of encrypted VMs";
            public const string FileDownloadLocation = "Location where the file should be downloaded in the case of file recovery. If -Path is not provided, the script file will be downloaded in the current directory";
            public const string Tier = "Filter recovery points based on tier";
            public const string IsReadyForMove = "checks whether the RP is ready to move to target tier. Use this along with target tier parameter";
            public const string TargetTier = "Target tier to check move readiness of recovery point. Currently only valid value is VaultArchive";
            public const string ArchivableRP = "Recovery Point to move to archive";
            public const string SourceTier = "Source Tier for Recovery Point move. Currently the only acceptable value is 'VaultStandard' ";
            public const string DestinationTier = "Destination Tier for Recovery Point move. Currently the only acceptable value is 'VaultArchive' ";
            public const string RehydratePriority = "Rehydration priority for an archived recovery point while triggering the restore. Acceptable values are Standard, High.";
            public const string RehydrateDuration = "Duration in days for which to keep the archived recovery point rehydrated. Value can range from 10 to 30 days, default value is 15 days.";
        }

        internal static class RestoreDisk
        {
            public const string RecoveryPoint = "Specifies the recovery point to which to restore the backup item.";
            public const string StorageAccountName = "Storage account name where the disks need to be recovered";
            public const string StorageAccountResourceGroupName = "Resource group name of Storage account name where the disks need to be recovered";
            public const string RecoveryConfig = "Recovery config";
            public const string UseSecondaryReg = "Trigger restore to secondary region (Cross Region Restore)";
        }

        internal static class RestoreVM
        {
            public const string TargetResourceGroupName = "The resource group to which the managed disks are restored. This parameter is mandatory for backup of VM with managed disks";
            public const string OsaOption = "Use this switch if the disks from the recovery point are to be restored to their original storage accounts";
            public const string RestoreOnlyOSDisk = "Use this switch to restore only OS disks of a backed up VM";
            public const string RestoreDiskList = "Specify which disks to recover of the backed up VM";
            public const string RestoreAsUnmanagedDisks = "Use this switch to specify to restore as unmanaged disks";
            public const string TargetZone = "Target zone to restore the disks";
            public const string EdgeZone = "Switch parameter to indicate edge zone VM restore. This parameter can't be used in cross region and corss subscription restore scenario";
            public const string RestoreAsManagedDisk = "Use this switch to specify to restore as managed disks.";
            public const string UseSystemAssignedIdentity = "Use this switch to trigger MSI based restore with SystemAssigned Identity";
            public const string UserAssignedIdentityId = "UserAssigned Identity Id to trigger MSI based restore with UserAssigned Identity";            
            public const string TargetVMName = "Name of the VM to which the data should be restored, in the case of Alternate Location restore to a new VM";
            public const string TargetVNetName = "Name of the VNet in which the target VM should be created, in the case of Alternate Location restore to a new VM";
            public const string TargetVNetResourceGroup = "Name of the resource group which contains the target VNet, in the case of Alternate Location restore to a new VM";
            public const string TargetSubnetName = "Name of the subnet in which the target VM should be created, in the case of Alternate Location restore to a new VM";
            public const string TargetSubscriptionId = "ID of the target subscription to which the resource should be restored. Use this parameter for Cross subscription restore";
        }

        internal static class RestoreFS
        {
            public const string SourceFilePath = "Used for a particular item restore from a file share. The path of the item to be restored within the file share.";
            public const string SourceFileType = "Whether the item to be restored is a file or a folder";
            public const string ResolveConflict = "In case the restored item also exists in the destination, use this to indicate whether to overwrite or not.";
            public const string TargetStorageAccountName = "The storage account to which the file share has to be restored to.";
            public const string TargetFileShareName = "The File Share to which the file share has to be restored to.";
            public const string TargetFolder = "The folder under which the file share has to be restored to within the targetFileShareName.Leave the variable empty to restore under root folder.";
            public const string MultipleSourceFilePath = "Used for Multiple files restore from a file share. The paths of the items to be restored within the file share.";
        }

        internal static class ProtectionCheck
        {
            public const string Name = "Name of the Azure Resource whose representative item needs to be checked if it is already protected by some Recovery Services Vault in the subscription.";
            public const string ResourceGroupName = "Name of the resource group of the Azure Resource whose representative item needs to be checked if it is already protected by some RecoveryServices Vault in the subscription.";
            public const string Type = "Type of the Azure Resource whose representative item needs to be checked if it is already protected by some Recovery Services Vault in the subscription.";
            public const string ResourceId = "ID of the Azure Resource whose representative item needs to be checked if it is already protected by some RecoveryServices Vault in the subscription.";
            public const string ProtectableObjName = "Name of the Azure Resource whose representative item needs to be checked if it is already protected by some Recovery Services Vault in the subscription.";
        }

        internal static class RecoveryPointConfig
        {
            public const string Item = "Specifies the backup item on which the restore operation is being performed.";
            public const string TargetItem = "Specifies the target on which the DB needs to be restored. For SQL restores, it needs to be of protectable item type SQLInstance only.";
            public const string OriginalWorkloadRestore = "Specifies that the backed up DB is to be overwritten with the DB information present in the recovery point.";
            public const string AlternateWorkloadRestore = "Specifies that the backed up DB should be restored as a new DB in another instance or as a new DB in the same instance";
            public const string TargetContainer = "Specifies the target machine on which DB Files need to be restored.";
            public const string RestoeAsFiles = "Specifies to restore Database as files in a machine.";
            public const string FilePath = "Specifies the filepath which is used for restore operation.";
            public const string FromFull = "Specifies the Full RecoveryPoint to which Log backups will be applied.";
        }

        internal static class DSMove
        {
            public const string SourceVault = "The source vault object to trigger data move.";
            public const string TargetVault = "The target vault object where the data has to be moved.";
            public const string ForceOption = "Forces the data move operation (prevents confirmation dialog). This parameter is optional.";
            public const string CmdletOutput = "Please monitor the operation using Get-AzRecoveryServicesBackupJob cmdlet";
            public const string RetryOnlyFailed = "Switch parameter to try data move only for containers in the source vault which are not yet moved.";
            public const string CorrelationId = "Correlation Id for triggering DS Move";
        }

        internal static class Encryption
        {
            public const string EncryptionSettings = "Get CMK vault encryption settings."; 
            public const string EncryptionKeyID = "KeyID of the encryption key to be used for CMK.";
            public const string KeyVaultSubscriptionId = "Subscription Id where the key vault is created.";
            public const string InfrastructureEncryption = "Enables infrastructure encryption on this vault. Infrastructure encryption must be enabled when configuring encryption." +
                " of the vault for the first time. Once enabled, infrastructure encryption cannot be disabled. ";
            public const string DES = "The disk encryption set is used to encrypt disks at rest when they are created from vault-based recovery points. Please ensure that the disk encryption" +
                " set also has access to the relevant key vault. For instant restores, where data is restored from snapshot recovery points, the currently active disk encryption set is automatically" +
                " used to encrypt newly created disks.";
            public const string UseSystemAssignedIdentity = "Boolean flag to indicate if SystemAssigned Identity will be used for CMK encryption";
            public const string UserAssignedIdentity = "ARM Id of UserAssigned Identity to be used for CMK encryption. Provide this parameter if UseSystemAssignedIdentity is $false";
        }

        internal static class ResourceGuard
        {
            public const string ResourceGuardMappingName = "Resource guard mapping Name to be fetched";
            public const string AuxiliaryAccessToken = "Parameter to authorize operations protected by cross tenant resource guard. Use command (Get-AzAccessToken -TenantId \"xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx\").Token to fetch authorization token for different tenant";
            public const string ResourceGuardId = "ResourceGuardId of the ResourceGuard to be mapped with RecoveryServicesVault";
        }
    }
}