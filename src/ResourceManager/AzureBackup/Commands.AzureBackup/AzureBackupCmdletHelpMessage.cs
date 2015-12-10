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

namespace Microsoft.Azure.Commands.AzureBackup.Cmdlets
{
    internal static class AzureBackupCmdletHelpMessage
    {
        /* Unidentified strings - not scrubbed */
        public const string ResourceTags = "A hash table which represents resource tags.";
        public const string ContainerId = "A unique identifier for the Azure Backup container object.";
        public const string VirtualMachine = "Virtual Machine.";
        public const string BackupType = "Type of backup.";
        public const string RetentionType = "Unit of retention for the recovery point.";
        public const string RententionDuration = "Specifies how long a recovery point will be retained, for a given RetentionType.";

        /* Get-AzureRmBackupVault */
        public const string ResourceGroupName = "The ResourceGroup in which the Azure resource is placed.";
        public const string ResourceName = "The name of the Azure resource.";

        /* New-AzureRmBackupVault */
        //public const string ResourceGroupName
        //public const string ResourceName
        public const string Location = "The Azure region where the Backup vault is located.";
        public const string StorageType = "The storage redundancy for the backup data stored in the vault. The currently supported storage redundancy options are Locally Redundant Storage (LRS) and Geo-Redundant Storage (GRS).";

        /*  Set-AzureRmBackupVault */
        //public const string Vault
        //public const string StorageType

        /* Get-AzureRmBackupVaultCredentials */
        //public const string Vault
        public const string TargetLocation = "The directory where the vault credentials file will be saved. This must be specified as an absolute path.";

        /* Get-AzureRmBackupContainer */
        public const string ManagedResourceName = "The name of the resource being managed by the Azure Backup service (for example: resource name of the VM).";
        public const string ManagedResourceGroupName = "The ResourceGroup of the resource being managed by the Azure Backup service (for example: ResourceGroup name of the VM).";
        public const string ContainerRegistrationStatus = "The registration status of the Azure Backup container.";
        public const string ContainerType = "The type of the Azure Backup container. This can be a Windows Server, an Azure IaaS VM, or a Data Protection Manager server.";
        //public const string Vault

        /* Get-AzureRmBackupItem */
        public const string AzureBackupContainer = "The Azure Backup container object which is the parent resource for the Azure Backup Item. The container can be a Windows Server, an Azure IaaS VM, or a Data Protection Manager server.";
        public const string ProtectionStatus = "Protection Status of the azure backup item.";
        public const string Status = "Status of Azure Backup Item";
        public const string Type = "Type of Azure Backup Item.";

        /* Enable-AzureRmBackupProtection */
        public const string AzureBackupItemEnable = "The Azure Backup item that is being enabled for protection.";
        public const string PolicyObject = "The Protection Policy object that contains all the scheduling information for backup and retention. This policy will be associated with the backup item provided as input.";

        /* Enable-AzureRmBackupContainerReregistration */
        public const string AzureBackupContainerToReregister = "The Azure Backup container to be unregistered. For this commandlet, the container cannot be of type AzureVM. Use the Get-AzureRmBackupContainer to get a list of containers.";

        /* Disable-AzureRmBackupProtection */
        public const string RemoveProtectionOption = "If this option is used, all the backup data for this item will also be deleted and restoring data will not be possible.";
        public const string AzureBackupItemDisable = "Azure Backup item for which the protection is being disabled.";
        public const string Reason = "User-specified reason for removing protection.";
        public const string Comments = "User-specified comments provided at the time of removing protection.";

        /* Get-AzureRmBackupJob */
        public const string JobFilterJobIdHelpMessage = "The unique identifier is used as a filtering criterion. It provides details to fetch the latest information about a job.";
        public const string JobFilterJobHelpMessage = "The job object is used as a filtering criterion. It provides details to fetch the latest information about a job.";
        public const string JobFilterStartTimeHelpMessage = "For the time range that is used as a filtering critetion, this parameter provides the starting boundary.";
        public const string JobFilterEndTimeHelpMessage = "For the time range that is used as a filtering critetion, this parameter provides the ending boundary.";
        public const string JobFilterOperationHelpMessage = "The operation name of the job is used as a filtering criterion.";
        public const string JobFilterStatusHelpMessage = "The status of the job is used as a filtering criterion.";
        public const string JobFitlerVaultHelpMessage = "The Azure Backup vault which is the parent of the jobs being queried. This is needed only when the -Job parameter is not being used.";
        public const string JobFilterTypeHelpMessage = "The type of workload is used as a filtering criterion.";

        /* Get-AzureRmBackupJobDetails */
        public const string JobDetailsFilterJobIdHelpMessage = "The unique identifier for the job whose full details are being requested";
        public const string JobDetailsFilterVaultHelpMessage = "The Azure Backup vault which is the parent resource of the job";
        public const string JobDetailsFilterJobHelpMessage = "The object that represents the job whose full details are being requested";

        /* Stop-AzureRmBackupJob */
        public const string StopJobFilterJobIdHelpMessage = "The unique identifier for the job that needs to be stopped";
        public const string StopJobFilterVaultHelpMessage = "The Azure Backup vault which is the parent resource of the job";
        public const string StopJobFilterJobHelpMessage = "The object that represents the job that needs be stopped";

        /* Wait-AzureRmBackupJob */
        public const string WaitJobFilterJobIdHelpMessage = "The unique identifier for the job on which the commandlet will wait for completion";
        public const string WaitJobFilterVaultHelpMessage = "The Azure Backup vault which is the parent resource of the job";
        public const string WaitJobFilterJobHelpMessage = "The object that represents the job on which the commandlet will wait for completion";
        public const string WaitJobFilterTimeoutHelpMessage = "If the commandlet should not wait infinitely for the job to finish, then this timeout value needs to be specified. The parameter specifies the maximum number of seconds for which the commandlet should wait before returning.";

        /* Register-AzureRmBackupContainer */
        public const string VMName = "The name of the Azure VM that will be registered with the service.";
        public const string ServiceName = "The Cloud Service name of Azure VM";
        public const string RGName = "The ResourceGroup name of Azure VM";
        public const string Vault = "The Azure Backup vault object which is the parent resource.";

        /* Unregister-AzureRmBackupContainer */
        public const string AzureBackupContainerToUnregister = "The Azure Backup container to be unregistered. This can be a Windows Server, an Azure IaaS VM, or a Data Protection Manager server. Use the Get-AzureRmBackupContainer to get a list of containers.";

        /* New-AzureRmBackupProtectionPolicy */
        public const string PolicyName = "The name of the Azure Backup protection policy. The name of the policy should be unique within a backup vault";
        public const string WorkloadType = "Workload type for which the protection policy is defined.";
        public const string DailyScheduleType = "Switch parameter to choose a daily backup schedule.";
        public const string WeeklyScheduleType = "Switch parameter to choose a weekly backup schedule.";
        public const string ScheduleRunDays = "Days of week on which the backup will be triggered. Required when specifying a weekly backup schedule.";
        public const string ScheduleRunTimes = "Times of day in UTC for running backup.";
        public const string RetentionPolicyList = "List of Retention Policies to be associated with protection policy. You can use a combination of Daily, Weekly, Monthly, and Yearly retention policies but not more than 1 of each.";
        public const string PolicyVault = "The Azure Backup vault which is the parent resource for the protection policy.";

        /* Set-AzureRmBackupProtectionPolicy */
        public const string PolicyNewName = "The new name to be given to this policy. Note that the policy name is unique to a backup vault and you need to ensure that you pick a name that does not conflict with existing names.";
        public const string AzureBackupPolicy = "Azure Backup protection policy object that contains the complete policy information.";

        /* New-AzureRmBackupRetentionPolicyObject */
        public const string DailyRetention = "Switch paramater to signal that this policy is being used for Daily Retention";
        public const string WeeklyRetention = "Switch parameter to signal that this policy is being used for Weekly Retention";
        public const string MonthlyRetentionInDailyFormat = "Allows the user to specify the Monthly retention policy based on specific days of the month";
        public const string MonthlyRetentionInWeeklyFormat = "Allows the user to specify the Monthly retention policy based on specific weeks of the month";
        public const string YearlyRetentionInDailyFormat = "Allows the user to specify the Yearly retention policy based on specific days of the year";
        public const string YearlyRetentionInWeeklyFormat = "Allows the user to specify the Yearly retention policy based on specific weeks of the year";
        public const string DaysOfWeek = "Specifies the days of the week that will be used in the policy";
        public const string DaysOfMonth = "Specifies the days of the month that will be used in the policy";
        public const string WeekNumber = "Specifies the week number of the month that will be used in the policy";
        public const string MonthsOfYear = "Specifies the months of the year that will be used in the policy";
        public const string Retention = "Specifies the duration of the retention policy";

        /* Backup-AzureRmBackupItem */
        public const string AzureBackupItem = "The Azure Backup item that is being configured for backup.";

        /* Get-AzureRmBackupRecoveryPoint */
        public const string AzureBackupItemGet = "The Azure Backup item for which the recovery points are being fetched.";
        public const string RecoveryPointId = "The unique identifier for the recovery point that is being fetched.";

        /* Restore-AzureRmBackupItem */
        public const string AzureBackUpRecoveryPoint = "The PowerShell object that refers to the recovery point. Use Get-AzureRmBackupRecoveryPoint to get the PowerShell object to be used as input to this commandlet.";
        public const string StorageAccountName = "The destination storage account where the restored disks and config information will be stored.";
    }
}
