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
        /// This function returns either job object or job details object based on 
        /// what ServiceClient object contains.
        /// To elaborate, if ServiceClient job's ExtendedInfo is filled then this function will
        /// return a job details object. Otherwise it will return a job object.
        /// </summary>
        /// <param name="ServiceClientJob"></param>
        /// <returns></returns>
        public static CmdletModel.JobBase GetPSJob(JobResponse serviceClientJob)
        {
            return GetPSJob(serviceClientJob.Item);
        }

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

            return response;
        }

        /// <summary>
        /// Helper function to convert ps backup job list model from service response.
        /// </summary>
        public static void AddServiceClientJobsToPSList(JobListResponse serviceClientJobs, List<CmdletModel.JobBase> psJobs, ref int jobsCount)
        {
            if (serviceClientJobs.ItemList != null && serviceClientJobs.ItemList.Value != null)
            {
                foreach (var job in serviceClientJobs.ItemList.Value)
                {
                    CmdletModel.JobBase convertedJob = GetPSJob(job);
                    if (convertedJob != null)
                    {
                        jobsCount++;
                        psJobs.Add(convertedJob);
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
            response.StartTime = vmJob.StartTime;
            response.EndTime = vmJob.EndTime;
            response.Duration = vmJob.Duration;
            response.Status = vmJob.Status;
            response.VmVersion = vmJob.VirtualMachineVersion;
            response.WorkloadName = vmJob.EntityFriendlyName;
            response.ActivityId = vmJob.ActivityId;
            response.BackupManagementType = CmdletModel.EnumUtils.GetEnum<CmdletModel.BackupManagementType>(
                GetPSBackupManagementType(vmJob.BackupManagementType));
            response.Operation = vmJob.Operation;

            if (vmJob.ErrorDetails != null)
            {
                response.ErrorDetails = new List<CmdletModel.AzureVmJobErrorInfo>();
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

        /// <summary>
        /// Helper function to convert ps azure vm backup job error info from service response.
        /// </summary>
        private static CmdletModel.AzureVmJobErrorInfo GetPSAzureVmErrorInfo(AzureIaaSVMErrorInfo serviceClientError)
        {
            CmdletModel.AzureVmJobErrorInfo psErrorInfo = new CmdletModel.AzureVmJobErrorInfo();
            psErrorInfo.ErrorCode = serviceClientError.ErrorCode;
            psErrorInfo.ErrorMessage = serviceClientError.ErrorString;
            if (serviceClientError.Recommendations != null)
            {
                psErrorInfo.Recommendations = new List<string>();
                psErrorInfo.Recommendations.AddRange(serviceClientError.Recommendations);
            }

            return psErrorInfo;
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

        #region Enum translators


        /// <summary>
        /// Helper function to get job type from ps backup management type.
        /// </summary>
        public static string GetJobTypeForService(CmdletModel.BackupManagementType mgmtType)
        {
            switch (mgmtType)
            {
                case CmdletModel.BackupManagementType.AzureVM:
                    return BackupManagementType.AzureIaasVM.ToString();
                default:
                    throw new Exception("Invalid BackupManagementType provided: " + mgmtType);
            }
        }

        /// <summary>
        /// Helper function to get ps backup management type from job type.
        /// </summary>
        public static string GetPSBackupManagementType(string jobType)
        {
            if (jobType == BackupManagementType.AzureIaasVM.ToString())
            {
                return CmdletModel.BackupManagementType.AzureVM.ToString();
            }
            else
            {
                throw new Exception("Invalid JobType provided: " + jobType);
            }
        }
                    
        #endregion
    }
}
