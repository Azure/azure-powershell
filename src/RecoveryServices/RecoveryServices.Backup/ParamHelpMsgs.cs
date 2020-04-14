﻿// ----------------------------------------------------------------------------------
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

using System.Configuration.Internal;

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
            public const string BackupManagementType = "The backup management type of the Azure Backup container";
            public const string RegisteredContainer = "The recovery services backup container.";
            public const string FriendlyName = "The name of the resource being managed by the" +
                " Azure Backup service (for example: resource name of the VM).";
            public const string ResourceId = "ID of the Azure Resource containing items to be protected by Azure Backup service. Currently, only Azure VM resource IDs are supported.";
            public const string ContainerObj = "Container object that needs to be re registered.";
            public const string ForceOption = "Force registers container (prevents confirmation dialog). This parameter is optional.";
        }

        internal static class Common
        {
            public const string Vault = "The Azure Backup vault object which is the parent resource.";
            public const string VaultId = "Resource ID of the Recovery Services Vault.";
            public const string WorkloadType = "Workload type of the resource (for example: AzureVM, WindowsServer, AzureFiles, MSSQL).";
            public const string BackupManagementType = "Backup Management type of the resource (for example: MAB, DPM, AzureWorkload).";
            public const string ConfirmationMessage = "Don't ask for confirmation.";
        }

        internal static class Policy
        {
            public const string Name = "Name of the Policy that is being managed.";
            public const string RetentionPolicy = "Retention Policy object for the policy.";
            public const string SchedulePolicy = "Schedule Policy object for the policy.";
            public const string ProtectionPolicy = "Protection policy object.";
            public const string FixForInConsistentItems = "Switch Parameter indicating whether or not to retry Policy Update for failed items.";
        }

        internal static class Job
        {
            public const string FromFilter = "Beginning value of time range for which jobs have to be fetched.";
            public const string ToFilter = "Ending value of time range for which jobs have to be fetched.";
            public const string OperationFilter = "Filter value for type of job.";
            public const string StatusFilter = "Filter value for status of job.";
            public const string BackupManagementTypeFilter = "Filter value for Backup Management Type of job.";
            public const string JobIdFilter = "Filter value for Id of job.";
            public const string JobFilter = "Job whose latest object has to be fetched.";
            public const string WaitJobOrListFilter = "Job or List of jobs until end of which the cmdlet should wait.";
            public const string WaitJobTimeoutFilter = "Maximum time to wait before aborting wait in seconds.";
            public const string StopJobJobIdFilter = "Id of Job to be stopped.";
            public const string StopJobJobFilter = "Job to be stopped.";
        }

        internal static class Item
        {
            public const string ItemName = "UniqueName of the backed up item.";
            public const string AzureVMServiceName = "Cloud Service Name for Azure Classic Compute VM.";
            public const string AzureVMResourceGroupName = "Resource Group Name for Azure Compute VM .";
            public const string ProtectedItem = "Filter value for status of job.";
            public const string ProtectableItem = "Specifies the protectable item to be protected using Azure Backup.";
            public const string ProtectionStatus = "Protection status of Item";
            public const string Status = "Status of the data source";
            public const string DeleteState = "Delete state of the item";
            public const string Container = "Container where the item resides";
            public const string RemoveProtectionOption = "If this option is used, all the backup data for this item will " +
                "also be deleted and restoring data will not be possible.";
            public const string ExpiryDate = "Retention period for the recovery points created by this backup operaiton";
            public const string ForceOption = "Force disables backup protection (prevents confirmation dialog). This parameter is optional.";
            public const string ExpiryDateTimeUTC = "Date and time specified in UTC after which" +
                " the recovery points created by this backup will no longer be available for restore";
            public const string ProtectionPolicy = "The id of the backup policy which is used to protect the backup items";
            public const string AzureFileShareName = "Azure FileShare Name.";
            public const string AzureFileStorageAccountName = "Azure file share storage account name";
            public const string AzureFileStorageAccountResourceGroupName = "Azure file share storage account resource group name";
            public const string BackupType = "Specifies the type of backup to be taken for an on-demand backup. Allowed values are “CopyOnlyFull”, “Full”, “Differential”, “Log”.";
            public const string EnableCompression = "A switch which will specify that the requested on-demand SQL backup should be compressed.";
            public const string ParentID = "Specified the ARM ID of an Instance or AG.";
            public const string FriendlyName = "FriendlyName of the backed up item";
            public const string inclusionDiskList = "List of Disk LUNs to include in backup";
            public const string exclusionDiskList = "List of Disk LUNs to exclude in backup";
            public const string resetExclusionSettings = "Specifies to reset disk exclusion setting associated with the item";
            public const string excludeAllDataDisks = "Option to specify to backup OS disks only";
        }

        internal static class ProtectableItem
        {
            public const string ItemType = "Specifies the type of protectable item. Applicable values: (SQLDataBase, SQLInstance, SQLAvailabilityGroup).";
            public const string ItemId = "Specifies the parent entity under which the protectable items (DBs) are to be retrieved. IDs of protectable item types SQLInstance, SQLAvailabilityGroup are applicable.";
            public const string ItemObject = "Specifies the protectable item object that can be passed as an input.";
            public const string Name = "Specifies the name of the Database, Instance or AvailabilityGroup.";
            public const string ServerName = "Specifies the name of the server to which the item belongs.";
        }

        internal static class RecoveryPoint
        {
            public const string StartDate = "Start time of Time range for which recovery point need to be fetched";
            public const string EndDate = "End time of Time range for which recovery point need to be fetched";
            public const string Item = "Protected Item object for which recovery point need to be fetched";
            public const string RecoveryPointId = "Recovery point Id for which detail is needed";
            public const string ILRRecoveryPoint =
                "Recovery point to be explored for file folder restore";
            public const string ILRConnect =
                "Initiate an iCSCI connection for file folder restore";
            public const string ILRExtend =
                "Extend the existing iCSCI connection for file folder restore";
            public const string ILRTerminate =
                "Terminate the existing iCSCI connection for file folder restore";
            public const string KeyFileDownloadLocation =
                "Location where the key file should be downloaded in the case of encrypted VMs.";
            public const string FileDownloadLocation =
                "Location where the file should be downloaded in the case of file recovery. If -Path is not provided, the script file will be downloaded in the current directory.";
        }

        internal static class RestoreDisk
        {
            public const string RecoveryPoint = "Recovery point object to be restored";
            public const string StorageAccountName = "Storage account name where the disks need to be recovered";
            public const string StorageAccountResourceGroupName = "Resource group name of Storage account name where the disks need to be recovered";
            public const string RecoveryConfig = "Recovery config";
        }

        internal static class RestoreVM
        {
            public const string TargetResourceGroupName = "The resource group to which the managed disks are restored. This parameter is mandatory for backup of VM with managed disks";
            public const string OsaOption = "Use this switch if the disks from the recovery point are to be restored to their original storage accounts";
            public const string RestoreOnlyOSDisk = "Use this switch to restore only OS disks of a backed up VM";
            public const string RestoreDiskList = "Specify which disks to recover of the backed up VM";
            public const string RestoreAsUnmanagedDisks = "Use this switch to specify to restore as unmanaged disks";
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
            public const string Type = "Name of the Azure Resource whose representative item needs to be checked if it is already protected by some Recovery Services Vault in the subscription.";
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
            public const string FilePath = "Specifies the filepath for restore operation.";
            public const string FromFull = "Specifies the Full RecoveryPoint to which Log backups will be applied.";
        }
    }
}