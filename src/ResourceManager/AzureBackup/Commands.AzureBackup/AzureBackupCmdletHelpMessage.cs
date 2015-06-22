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
        public const string Vault = "The vault details";
        public const string PolicyName = "The protection policy name.";
        public const string ResourceGroupName = "The ResourceGroup name.";
        public const string ResourceName = "The Resource name.";
        public const string Location = "Location.";
        public const string TargetLocation = "The directory where the credentials file will be saved. This must be an absolute path.";
        public const string ContainerResourceName = "The container resource name aka friendly name.";
        public const string ContainerId = "The container ID.";
        public const string ContainerRegistrationStatus = "The container registration status.";
        public const string ContainerType = "The container type.";

        public const string JobFilterJobIdHelpMessage = "The job ID to filter jobs";
        public const string JobFilterJobHelpMessage = "The job for filtering";
        public const string JobFilterStartTimeHelpMessage = "The start time of query range";
        public const string JobFilterEndTimeHelpMessage = "The end time of query range";
        public const string JobFilterOperationHelpMessage = "The operation for filtering jos";
        public const string JobFilterStatusHelpMessage = "The status for filtering jobs";
        public const string JobFitlerVaultHelpMessage = "The vault of which jobs have to be filtered";
        public const string JobFilterTypeHelpMessage = "The type of workload whose jobs have to be filtered";

        public const string JobDetailsFilterJobIdHelpMessage = "The job ID to get details";
        public const string JobDetailsFilterVaultHelpMessage = "The vault of which job details should be fetched";
        public const string JobDetailsFilterJobHelpMessage = "The job whose full details should be fetched";

        public const string StopJobFilterJobIdHelpMessage = "The job ID to stop job";
        public const string StopJobFilterVaultHelpMessage = "The vault of which a job has to be stopped";
        public const string StopJobFilterJobHelpMessage = "The job which should be stopped";

        public const string WaitJobFilterJobIdHelpMessage = "The job ID to stop job";
        public const string WaitJobFilterVaultHelpMessage = "The vault of which a job has to be stopped";
        public const string WaitJobFilterJobHelpMessage = "The job which should be stopped";
        public const string WaitJobFilterTimeoutHelpMessage = "Maximum number of seconds for which cmdlet should wait before job(s) complete running.";

        public const string VirtualMachine = "Virtual Machine.";
        public const string ContainerResourceGroupName = "The container resource group name.";
        public const string ProtectionStatus = "Protection Status of the azure backup item.";
        public const string AzureBackUpItem = "Azure BackUp Item.";
        public const string RecoveryPointId = "Recovery Point Id.";
        public const string StorageType = "The vault back-end storage type.";
        public const string Type = "Type of Azure Backup Item.";
        public const string Status = "Status of Azure Backup Item";
        public const string AzureBackupContainer = "Azure Backup Container for Azure Backup Item.";
        public const string AzureBackupItem = "Azure Backup Item for enabling protection";
        public const string RemoveProtectionOption = "Remove Protection Option";
        public const string Reason = "Reson for removing protection";
        public const string Comments = "Comments for for removing protection";
        public const string WorkloadType = "Workload type for which the policy is defined.";
        public const string BackupType = "Type of backup.";
        public const string DailyScheduleType = "Switch parameter for daily backup schedule.";
        public const string WeeklyScheduleType = "Switch parameter for weekly backup schedule.";
        public const string ScheduleRunDays = "Days of week for running backup, required for weekly schedule.";
        public const string ScheduleRunTimes = "Times of day in UTC for running backup.";
        public const string RetentionType = "Unit of retention for the recovery point.";
        public const string RententionDuration = "Duration of retention for the recovery point in units specified by RetentionType.";
        public const string PolicyNewName = "Policy new name";
        public const string AzureBackupPolicy = "Azure Backup protection policy";
    }
}
