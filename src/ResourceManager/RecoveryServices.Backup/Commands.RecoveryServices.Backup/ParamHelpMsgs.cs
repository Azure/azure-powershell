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
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        }

        internal static class Common
        {
            public const string Vault = "The Azure Backup vault object which is the parent resource.";
            public const string WorkloadType = "Workload type of the resource (for example: AzureVM, WindowsServer).";
            public const string BackupManagementType = "Backup Management type of the resource (for example: MAB, DPM).";
            public const string ConfirmationMessage = "Don't ask for confirmation.";
        }

        internal static class Policy
        {
            public const string Name = "Name of the Policy that is being managed.";
            public const string RetentionPolicy = "Retention Policy object for the policy.";
            public const string SchedulePolicy = "Schedule Policy object for the policy.";
            public const string ProtectionPolicy = "Protection policy object.";
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
            public const string AzureVMName = "Azure VM Name.";
            public const string AzureVMServiceName = "Cloud Service Name for Azure Classic Compute VM.";
            public const string AzureVMResourceGroupName = "Resource Group Name for Azure Compute VM .";
            public const string ProtectedItem = "Filter value for status of job.";
            public const string ProtectionStatus = "Protection status of Item";
            public const string Status = "Status of the data source";
            public const string Container = "Container where the item resides";
            public const string RemoveProtectionOption = "If this option is used, all the backup data for this item will " + 
                "also be deleted and restoring data will not be possible.";
            public const string ExpiryDate = "Retention period for the recovery points created by this backup operaiton";
            public const string ForceOption = "Force disables backup protection (prevents confirmation dialog). This parameter is optional.";
            public const string ExpiryDateTimeUTC = "Date and time specified in UTC after which" +
                " the recovery points created by this backup will no longer be available for restore";
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
        }

        internal static class RestoreDisk
        {
            public const string RecoveryPoint = "Recovery point object to be restored";
            public const string StorageAccountName = "Storage account name where the disks need to be recovered";
            public const string StorageAccountResourceGroupName = "Resource group name of Storage account name where the disks need to be recovered";
        }
    }
}
