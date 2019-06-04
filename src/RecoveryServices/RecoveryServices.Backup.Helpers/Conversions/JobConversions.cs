// ----------------------------------------------------------------------------------
//
// Copyright Microsoft CorporationMicrosoft.Azure.Managemen
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
using Microsoft.Azure.Commands.RecoveryServices.Backup.Properties;
using Microsoft.Azure.Management.RecoveryServices.Backup.Models;
using CmdletModel = Microsoft.Azure.Commands.RecoveryServices.Backup.Cmdlets.Models;

namespace Microsoft.Azure.Commands.RecoveryServices.Backup.Helpers
{
    /// <summary>
    /// Job conversions helper.
    /// </summary>
    public class JobConversions
    {
        #region ServiceClient to PS convertors

        /// <summary>
        /// Helper function to convert ps backup job model from service response.
        /// </summary>
        public static CmdletModel.JobBase GetPSJob(JobResource serviceClientJob)
        {
            CmdletModel.JobBase response = null;

            // ServiceClient doesn't initialize Properties if the type of job is not known to current version of ServiceClient.
            if (serviceClientJob.Properties == null)
            {
                Logger.Instance.WriteWarning(Resources.UnsupportedJobWarning);
            }
            else if (serviceClientJob.Properties.GetType() == typeof(AzureIaaSVMJob))
            {
                response = GetPSAzureVmJob(serviceClientJob);
            }
            else if (serviceClientJob.Properties.GetType() == typeof(AzureStorageJob))
            {
                response = GetPSAzureFileShareJob(serviceClientJob);
            }
            else if (serviceClientJob.Properties.GetType() == typeof(AzureWorkloadJob))
            {
                response = GetPSAzureWorkloadJob(serviceClientJob);
            }

            return response;
        }

        /// <summary>
        /// Helper function to convert ps backup job list model from service response.
        /// </summary>
        public static void AddServiceClientJobsToPSList(
            List<JobResource> serviceClientJobs,
            List<CmdletModel.JobBase> psJobs,
            ref int jobsCount)
        {
            if (serviceClientJobs != null)
            {
                foreach (var job in serviceClientJobs)
                {
                    CmdletModel.JobBase convertedJob = GetPSJob(job);
                    if (convertedJob != null)
                    {
                        jobsCount++;
                        psJobs.Add(convertedJob);
                    }
                    else
                    {
                        Logger.Instance.WriteDebug(
                            "Ignoring some of the unexpected job while conversion");
                    }
                }
            }
        }

        #region AzureVm job private helpers

        /// <summary>
        /// Helper function to convert ps azure vm backup policy job from service response.
        /// </summary>
        private static CmdletModel.AzureVmJob GetPSAzureVmJob(JobResource serviceClientJob)
        {
            CmdletModel.AzureVmJob response;

            AzureIaaSVMJob vmJob = serviceClientJob.Properties as AzureIaaSVMJob;

            if (vmJob.ExtendedInfo != null)
            {
                response = new CmdletModel.AzureVmJobDetails();
            }
            else
            {
                response = new CmdletModel.AzureVmJob();
            }

            response.JobId = GetLastIdFromFullId(serviceClientJob.Id);
            response.StartTime = GetJobStartTime(vmJob.StartTime);
            response.EndTime = vmJob.EndTime;
            response.Duration = GetJobDuration(vmJob.Duration);
            response.Status = vmJob.Status;
            response.VmVersion = vmJob.VirtualMachineVersion;
            response.WorkloadName = vmJob.EntityFriendlyName;
            response.ActivityId = vmJob.ActivityId;
            response.BackupManagementType =
                CmdletModel.ConversionUtils.GetPsBackupManagementType(vmJob.BackupManagementType);
            response.Operation = vmJob.Operation;

            if (vmJob.ErrorDetails != null)
            {
                response.ErrorDetails = new List<CmdletModel.AzureJobErrorInfo>();
                foreach (var vmError in vmJob.ErrorDetails)
                {
                    response.ErrorDetails.Add(GetPSAzureVmErrorInfo(vmError));
                }
            }

            // fill extended info if present
            if (vmJob.ExtendedInfo != null)
            {
                CmdletModel.AzureVmJobDetails detailedResponse =
                    response as CmdletModel.AzureVmJobDetails;

                detailedResponse.DynamicErrorMessage = vmJob.ExtendedInfo.DynamicErrorMessage;
                if (vmJob.ExtendedInfo.PropertyBag != null)
                {
                    detailedResponse.Properties = new Dictionary<string, string>();
                    foreach (var key in vmJob.ExtendedInfo.PropertyBag.Keys)
                    {
                        detailedResponse.Properties.Add(key, vmJob.ExtendedInfo.PropertyBag[key]);
                    }
                }

                if (vmJob.ExtendedInfo.TasksList != null)
                {
                    detailedResponse.SubTasks = new List<CmdletModel.AzureVmJobSubTask>();
                    foreach (var vmJobTask in vmJob.ExtendedInfo.TasksList)
                    {
                        detailedResponse.SubTasks.Add(new CmdletModel.AzureVmJobSubTask()
                        {
                            Name = vmJobTask.TaskId,
                            Status = vmJobTask.Status
                        });
                    }
                }
            }

            return response;
        }

        private static CmdletModel.JobBase GetPSAzureFileShareJob(JobResource serviceClientJob)
        {
            CmdletModel.AzureFileShareJob response;

            AzureStorageJob fileShareJob = serviceClientJob.Properties as AzureStorageJob;

            if (fileShareJob.ExtendedInfo != null)
            {
                response = new CmdletModel.AzureFileShareJobDetails();
            }
            else
            {
                response = new CmdletModel.AzureFileShareJob();
            }

            response.JobId = GetLastIdFromFullId(serviceClientJob.Id);
            response.StartTime = GetJobStartTime(fileShareJob.StartTime);
            response.EndTime = fileShareJob.EndTime;
            response.Duration = GetJobDuration(fileShareJob.Duration);
            response.Status = fileShareJob.Status;
            response.WorkloadName = fileShareJob.EntityFriendlyName;
            response.ActivityId = fileShareJob.ActivityId;
            response.BackupManagementType =
                CmdletModel.ConversionUtils.GetPsBackupManagementType(fileShareJob.BackupManagementType);
            response.Operation = fileShareJob.Operation;

            if (fileShareJob.ErrorDetails != null)
            {
                response.ErrorDetails = new List<CmdletModel.AzureJobErrorInfo>();
                foreach (var fileShareError in fileShareJob.ErrorDetails)
                {
                    response.ErrorDetails.Add(GetPSAzureFileShareErrorInfo(fileShareError));
                }
            }

            // fill extended info if present
            if (fileShareJob.ExtendedInfo != null)
            {
                CmdletModel.AzureFileShareJobDetails detailedResponse =
                    response as CmdletModel.AzureFileShareJobDetails;

                detailedResponse.DynamicErrorMessage = fileShareJob.ExtendedInfo.DynamicErrorMessage;
                if (fileShareJob.ExtendedInfo.PropertyBag != null)
                {
                    detailedResponse.Properties = new Dictionary<string, string>();
                    foreach (var key in fileShareJob.ExtendedInfo.PropertyBag.Keys)
                    {
                        detailedResponse.Properties.Add(key, fileShareJob.ExtendedInfo.PropertyBag[key]);
                    }
                }

                if (fileShareJob.ExtendedInfo.TasksList != null)
                {
                    detailedResponse.SubTasks = new List<CmdletModel.AzureFileShareJobSubTask>();
                    foreach (var fileShareJobTask in fileShareJob.ExtendedInfo.TasksList)
                    {
                        detailedResponse.SubTasks.Add(new CmdletModel.AzureFileShareJobSubTask()
                        {
                            Name = fileShareJobTask.TaskId,
                            Status = fileShareJobTask.Status
                        });
                    }
                }
            }

            return response;
        }

        private static CmdletModel.AzureJobErrorInfo GetPSAzureFileShareErrorInfo(AzureStorageErrorInfo fileShareError)
        {
            CmdletModel.AzureFileShareJobErrorInfo psErrorInfo = new CmdletModel.AzureFileShareJobErrorInfo();
            psErrorInfo.ErrorCode = GetJobErrorCode(fileShareError.ErrorCode);
            psErrorInfo.ErrorMessage = fileShareError.ErrorString;
            if (fileShareError.Recommendations != null)
            {
                psErrorInfo.Recommendations = new List<string>();
                psErrorInfo.Recommendations.AddRange(fileShareError.Recommendations);
            }

            return psErrorInfo;
        }

        private static CmdletModel.JobBase GetPSAzureWorkloadJob(JobResource serviceClientJob)
        {
            CmdletModel.AzureVmWorkloadJob response;

            AzureWorkloadJob workloadJob = serviceClientJob.Properties as AzureWorkloadJob;

            if (workloadJob.ExtendedInfo != null)
            {
                response = new CmdletModel.AzureVmWorkloadJobDetails();
            }
            else
            {
                response = new CmdletModel.AzureVmWorkloadJob();
            }

            response.JobId = GetLastIdFromFullId(serviceClientJob.Id);
            response.StartTime = GetJobStartTime(workloadJob.StartTime);
            response.EndTime = workloadJob.EndTime;
            response.Duration = GetJobDuration(workloadJob.Duration);
            response.Status = workloadJob.Status;
            response.WorkloadName = workloadJob.EntityFriendlyName;
            response.ActivityId = workloadJob.ActivityId;
            response.BackupManagementType =
                CmdletModel.ConversionUtils.GetPsBackupManagementType(workloadJob.BackupManagementType);
            response.Operation = workloadJob.Operation;

            if (workloadJob.ErrorDetails != null)
            {
                response.ErrorDetails = new List<CmdletModel.AzureJobErrorInfo>();
                foreach (var workloadError in workloadJob.ErrorDetails)
                {
                    response.ErrorDetails.Add(GetPSAzureWorkloadErrorInfo(workloadError));
                }
            }

            // fill extended info if present
            if (workloadJob.ExtendedInfo != null)
            {
                CmdletModel.AzureVmWorkloadJobDetails detailedResponse =
                    response as CmdletModel.AzureVmWorkloadJobDetails;

                detailedResponse.DynamicErrorMessage = workloadJob.ExtendedInfo.DynamicErrorMessage;
                if (workloadJob.ExtendedInfo.PropertyBag != null)
                {
                    detailedResponse.Properties = new Dictionary<string, string>();
                    foreach (var key in workloadJob.ExtendedInfo.PropertyBag.Keys)
                    {
                        detailedResponse.Properties.Add(key, workloadJob.ExtendedInfo.PropertyBag[key]);
                    }
                }

                if (workloadJob.ExtendedInfo.TasksList != null)
                {
                    detailedResponse.SubTasks = new List<CmdletModel.AzureVmWorkloadJobSubTask>();
                    foreach (var workloadJobTask in workloadJob.ExtendedInfo.TasksList)
                    {
                        detailedResponse.SubTasks.Add(new CmdletModel.AzureVmWorkloadJobSubTask()
                        {
                            Name = workloadJobTask.TaskId,
                            Status = workloadJobTask.Status
                        });
                    }
                }
            }

            return response;
        }

        private static CmdletModel.AzureJobErrorInfo GetPSAzureWorkloadErrorInfo(AzureWorkloadErrorInfo workloadError)
        {
            CmdletModel.AzureVmWorkloadJobErrorInfo psErrorInfo = new CmdletModel.AzureVmWorkloadJobErrorInfo();
            psErrorInfo.ErrorCode = GetJobErrorCode(workloadError.ErrorCode);
            psErrorInfo.ErrorMessage = workloadError.ErrorString;
            if (workloadError.Recommendations != null)
            {
                psErrorInfo.Recommendations = new List<string>();
                psErrorInfo.Recommendations.AddRange(workloadError.Recommendations);
            }

            return psErrorInfo;
        }

        private static int GetJobErrorCode(int? errorCode)
        {
            return errorCode ?? default(int);
        }

        private static TimeSpan GetJobDuration(TimeSpan? duration)
        {
            return duration.HasValue ? (TimeSpan)duration : default(TimeSpan);
        }

        private static DateTime GetJobStartTime(DateTime? startTime)
        {
            if (startTime.HasValue)
            {
                return (DateTime)startTime;
            }
            else
            {
                throw new ArgumentNullException("Job Start Time is null");
            }
        }

        /// <summary>
        /// Helper function to convert ps azure vm backup job error info from service response.
        /// </summary>
        private static CmdletModel.AzureVmJobErrorInfo GetPSAzureVmErrorInfo(AzureIaaSVMErrorInfo serviceClientError)
        {
            CmdletModel.AzureVmJobErrorInfo psErrorInfo = new CmdletModel.AzureVmJobErrorInfo();
            psErrorInfo.ErrorCode = GetJobErrorCode(serviceClientError.ErrorCode);
            psErrorInfo.ErrorMessage = serviceClientError.ErrorString;
            psErrorInfo.Recommendations = GetJobErrorRecommendations(serviceClientError.Recommendations);

            return psErrorInfo;
        }

        private static List<string> GetJobErrorRecommendations(IList<string> recommendations)
        {
            if (recommendations != null)
            {
                var psRecommendations = new List<string>();
                psRecommendations.AddRange(recommendations);
                return psRecommendations;
            }

            return null;
        }

        /// <summary>
        /// Helper function to get last index value from full id.
        /// </summary>
        public static string GetLastIdFromFullId(string fullId)
        {
            string[] splitArr = fullId.Split("/".ToCharArray());
            return splitArr[splitArr.Length - 1];
        }

        #endregion

        #endregion
    }
}
