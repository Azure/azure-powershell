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
using System.Collections.Specialized;
using System.Web;
using CmdletModel = Microsoft.Azure.Commands.RecoveryServices.Backup.Cmdlets.Models;
using ServiceClientModel = Microsoft.Azure.Management.RecoveryServices.Backup.Models;

namespace Microsoft.Azure.Commands.RecoveryServices.Backup.Helpers
{
    /// <summary>
    /// Constants used by the service client helpers.
    /// </summary>
    public class ServiceClientConstants
    {
        public const string SkipToken = "skipToken";
    }

    /// <summary>
    /// Helper methods used by the service client adapter.
    /// </summary>
    public class ServiceClientHelpers
    {
        /// <summary>
        /// Gets the provider type with which the service client calls are to made to contact the backend service. 
        /// This can be determined by the container type in case of certain containers such as those of the type AzureVM.
        /// </summary>
        /// <param name="containerType">Type of the container</param>
        /// <returns></returns>
        public static string GetServiceClientProviderType(CmdletModel.ContainerType containerType)
        {
            string providerType = string.Empty;

            switch (containerType)
            {
                case CmdletModel.ContainerType.AzureVM:
                    providerType = ServiceClientModel.BackupManagementType.AzureIaasVM.ToString();
                    break;
                default:
                    break;
            }

            return providerType;
        }

        /// <summary>
        /// Gets the provider type with which the service client calls are to made to contact the backend service. 
        /// This is determined by the workload type in case of certain containers such as those of the type AzureVM.
        /// </summary>
        /// <param name="workloadType"></param>
        /// <returns></returns>
        public static string GetServiceClientProviderType(CmdletModel.WorkloadType workloadType)
        {
            string providerType = string.Empty;

            switch (workloadType)
            {
                case CmdletModel.WorkloadType.AzureVM:
                    providerType = ServiceClientModel.BackupManagementType.AzureIaasVM.ToString();
                    break;
                case CmdletModel.WorkloadType.AzureSQLDatabase:
                    providerType = ServiceClientModel.BackupManagementType.AzureSql.ToString();
                    break;
                case CmdletModel.WorkloadType.AzureFiles:
                    providerType = ServiceClientModel.BackupManagementType.AzureStorage.ToString();
                    break;
                case CmdletModel.WorkloadType.MSSQL:
                    providerType = ServiceClientModel.BackupManagementType.AzureWorkload.ToString();
                    break;
                default:
                    break;
            }

            return providerType;
        }

        /// <summary>
        /// Gets the provider type with which the service client calls 
        /// are to be made to contact the backend service. 
        /// This is determined by the backupmanagement type of powershell object.
        /// </summary>
        /// <param name="backupManagementType">Powershell backup management type</param>
        /// <returns>Service backup management type</returns>
        public static string
            GetServiceClientBackupManagementType(
                CmdletModel.BackupManagementType? backupManagementType)
        {
            string providerType = null;

            switch (backupManagementType)
            {
                case CmdletModel.BackupManagementType.AzureVM:
                    providerType = ServiceClientModel.BackupManagementType.AzureIaasVM.ToString();
                    break;
                case CmdletModel.BackupManagementType.AzureWorkload:
                    providerType = ServiceClientModel.BackupManagementType.AzureWorkload.ToString();
                    break;
                case CmdletModel.BackupManagementType.AzureSQL:
                    providerType = ServiceClientModel.BackupManagementType.AzureSql.ToString();
                    break;
                case CmdletModel.BackupManagementType.AzureStorage:
                    providerType = ServiceClientModel.BackupManagementType.AzureStorage.ToString();
                    break;
                case CmdletModel.BackupManagementType.MAB:
                    providerType = ServiceClientModel.BackupManagementType.MAB.ToString();
                    break;
                default:
                    break;
            }

            return providerType;
        }

        /// <summary>
        /// Gets the provider type with which the service client calls 
        /// are to be made to contact the backend service. 
        /// This is determined by the backupmanagement type of powershell object.
        /// </summary>
        /// <param name="backupManagementType"></param>
        /// <returns>service backup management type</returns>
        public static string
            GetServiceClientBackupManagementType(string backupManagementType)
        {
            string providerType = null;

            if (string.IsNullOrEmpty(backupManagementType))
            {
                return providerType;
            }

            return GetServiceClientBackupManagementType(
                backupManagementType.ToEnum<CmdletModel.BackupManagementType>());
        }

        /// <summary>
        /// Gets the job status using which the service client calls 
        /// are to be made to contact the backend service. 
        /// This is determined by the job status of powershell object.
        /// </summary>
        /// <param name="pSJobStatus">Powershell job status enum value</param>
        /// <returns>Service job status</returns>
        public static string
            GetServiceClientJobStatus(
                CmdletModel.JobStatus? pSJobStatus)
        {
            string jobStatus = null;

            switch (pSJobStatus)
            {
                case CmdletModel.JobStatus.Cancelled:
                    jobStatus = ServiceClientModel.JobStatus.Cancelled.ToString();
                    break;
                case CmdletModel.JobStatus.Cancelling:
                    jobStatus = ServiceClientModel.JobStatus.Cancelling.ToString();
                    break;
                case CmdletModel.JobStatus.Completed:
                    jobStatus = ServiceClientModel.JobStatus.Completed.ToString();
                    break;
                case CmdletModel.JobStatus.CompletedWithWarnings:
                    jobStatus = ServiceClientModel.JobStatus.CompletedWithWarnings.ToString();
                    break;
                case CmdletModel.JobStatus.Failed:
                    jobStatus = ServiceClientModel.JobStatus.Failed.ToString();
                    break;
                case CmdletModel.JobStatus.InProgress:
                    jobStatus = ServiceClientModel.JobStatus.InProgress.ToString();
                    break;
                default:
                    break;
            }

            return jobStatus;
        }

        /// <summary>
        /// Gets the retention duration type using which the service client calls 
        /// are to be made to contact the backend service. 
        /// This is determined by the retention duration type of powershell object.
        /// </summary>
        /// <param name="pSRetentionDurationType">Powershell retention duration type enum value</param>
        /// <returns>Service retention duration type</returns>
        public static string
            GetServiceClientRetentionDurationType(
                CmdletModel.RetentionDurationType? pSRetentionDurationType)
        {
            string retentionDurationtype = null;

            switch (pSRetentionDurationType)
            {
                case CmdletModel.RetentionDurationType.Days:
                    retentionDurationtype = ServiceClientModel.RetentionDurationType.Days.ToString();
                    break;
                case CmdletModel.RetentionDurationType.Weeks:
                    retentionDurationtype = ServiceClientModel.RetentionDurationType.Weeks.ToString();
                    break;
                case CmdletModel.RetentionDurationType.Months:
                    retentionDurationtype = ServiceClientModel.RetentionDurationType.Months.ToString();
                    break;
                case CmdletModel.RetentionDurationType.Years:
                    retentionDurationtype = ServiceClientModel.RetentionDurationType.Years.ToString();
                    break;
                default:
                    break;
            }

            return retentionDurationtype;
        }

        /// <summary>
        /// Gets the retention schedule format using which the service client calls 
        /// are to be made to contact the backend service. 
        /// This is determined by the retention schedule format of powershell object.
        /// </summary>
        /// <param name="pSRetentionScheduleFormat">Powershell retention schedule format enum value</param>
        /// <returns>Service retention schedule format</returns>
        public static string
            GetServiceClientRetentionScheduleFormat(
                CmdletModel.RetentionScheduleFormat? pSRetentionScheduleFormat)
        {
            string retentionScheduleFormat = null;

            switch (pSRetentionScheduleFormat)
            {
                case CmdletModel.RetentionScheduleFormat.Daily:
                    retentionScheduleFormat = ServiceClientModel.RetentionScheduleFormat.Daily.ToString();
                    break;
                case CmdletModel.RetentionScheduleFormat.Weekly:
                    retentionScheduleFormat = ServiceClientModel.RetentionScheduleFormat.Weekly.ToString();
                    break;
                default:
                    break;
            }

            return retentionScheduleFormat;
        }

        /// <summary>
        /// Gets the schedule run type using which the service client calls 
        /// are to be made to contact the backend service. 
        /// This is determined by the schedule run type of powershell object.
        /// </summary>
        /// <param name="pSScheduleRunType">Powershell schedule run type enum value</param>
        /// <returns>Service schedule run type</returns>
        public static string
            GetServiceClientScheduleRunType(
                CmdletModel.ScheduleRunType? pSScheduleRunType)
        {
            string scheduleRunType = null;

            switch (pSScheduleRunType)
            {
                case CmdletModel.ScheduleRunType.Daily:
                    scheduleRunType = ServiceClientModel.ScheduleRunType.Daily.ToString();
                    break;
                case CmdletModel.ScheduleRunType.Weekly:
                    scheduleRunType = ServiceClientModel.ScheduleRunType.Weekly.ToString();
                    break;
                case CmdletModel.ScheduleRunType.Hourly:
                    scheduleRunType = ServiceClientModel.ScheduleRunType.Hourly.ToString();
                    break;
                default:
                    break;
            }

            return scheduleRunType;
        }

        /// <summary>
        /// Gets the skip token from the next link. Usually, next link is the location uri returned as a header
        /// when an ARM call is made. When this skip token (if non-null) is used in the next call to the backend service,
        /// the next set of objects are returned.
        /// </summary>
        /// <param name="nextLink">The next link a.k.a location url</param>
        /// <param name="skipToken">The skip token extracted from the next link</param>
        public static void GetSkipTokenFromNextLink(string nextLink, out string skipToken)
        {
            if (nextLink != null)
            {
                Uri uriObj = new Uri(nextLink);
                // This is sent by service and we don't expect this to be encoded.
                // TODO: Need to make sure during testing that this is in fact true.
                NameValueCollection queryParams = HttpUtility.ParseQueryString(uriObj.Query);
                if (queryParams.Get(ServiceClientConstants.SkipToken) != null)
                {
                    skipToken = queryParams.Get(ServiceClientConstants.SkipToken);
                }
                else
                {
                    skipToken = null;
                }
            }
            else
            {
                skipToken = null;
            }
        }

        /// <summary>
        /// Use this function to get the last part of a URL.
        /// Generally this is the ID of object or OperationId.
        /// Note: This doesn't work if the string has any extra characters
        /// after slash. (CSM ID's generally don't have)
        /// </summary>
        /// <param name="fullId"></param>
        /// <returns></returns>
        public static string GetLastIdFromFullId(string fullId)
        {
            Uri fullUri = new Uri(fullId);
            fullId = fullUri.AbsolutePath;
            string[] splitArr = fullId.Split("/".ToCharArray());
            return splitArr[splitArr.Length - 1];
        }

        /// <summary>
        /// Gets the service client specific container type given the PS container type
        /// </summary>
        /// <param name="containerType">PS container type</param>
        /// <returns></returns>
        public static string GetServiceClientContainerType(CmdletModel.ContainerType containerType)
        {
            string serviceClientContainerType = string.Empty;

            switch (containerType)
            {
                case CmdletModel.ContainerType.AzureVM:
                    serviceClientContainerType = ServiceClientModel.MabServerType.IaasVMContainer.ToString();
                    break;
                default:
                    break;
            }

            return serviceClientContainerType;
        }

        /// <summary>
        /// Gets the service client specific workload type given the PS workload type
        /// </summary>
        /// <param name="workloadType"></param>
        /// <returns></returns>
        public static string GetServiceClientWorkloadType(CmdletModel.WorkloadType workloadType)
        {
            string serviceClientWorkloadType = string.Empty;

            switch (workloadType)
            {
                case CmdletModel.WorkloadType.AzureVM:
                    serviceClientWorkloadType = ServiceClientModel.WorkloadType.VM.ToString();
                    break;
                case CmdletModel.WorkloadType.MSSQL:
                    serviceClientWorkloadType = ServiceClientModel.WorkloadType.SQLDataBase.ToString();
                    break;
                default:
                    break;
            }

            return serviceClientWorkloadType;
        }
    }
}