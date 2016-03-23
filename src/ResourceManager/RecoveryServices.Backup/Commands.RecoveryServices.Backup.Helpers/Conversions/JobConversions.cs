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

using System.Collections.Generic;
using Microsoft.Azure.Commands.RecoveryServices.Backup.Cmdlets.Models;
using Microsoft.Azure.Management.RecoveryServices.Backup.Models;

namespace Microsoft.Azure.Commands.RecoveryServices.Backup.Helpers
{
    public class JobConversions
    {
        #region Hydra to PS convertors

        /// <summary>
        /// This function returns either job object or job details object based on 
        /// what hydra object contains.
        /// To elaborate, if hydra job's ExtendedInfo is filled then this function will
        /// return a job details object. Otherwise it will return a job object.
        /// </summary>
        /// <param name="hydraJob"></param>
        /// <returns></returns>
        public static AzureRmRecoveryServicesJobBase GetPSJob(JobResponse hydraJob)
        {
            return GetPSJob(hydraJob.Item);
        }

        public static AzureRmRecoveryServicesJobBase GetPSJob(JobResource hydraJob)
        {
            AzureRmRecoveryServicesJobBase response = null;

            // hydra doesn't initialize Properties if the type of job is not known to current version of hydra.
            if (hydraJob.Properties == null)
            {
                // unsupported job type.
            }
            else if (hydraJob.Properties.GetType() == typeof(AzureIaaSVMJob))
            {
                response = GetPSAzureVmJob(hydraJob);
            }

            return response;
        }

        public static void AddHydraJobsToPSList(JobListResponse hydraJobs, List<AzureRmRecoveryServicesJobBase> psJobs, ref int jobsCount)
        {
            if (hydraJobs.ItemList != null && hydraJobs.ItemList.Value != null)
            {
                foreach (var job in hydraJobs.ItemList.Value)
                {
                    AzureRmRecoveryServicesJobBase convertedJob = GetPSJob(job);
                    if (convertedJob != null)
                    {
                        jobsCount++;
                        psJobs.Add(convertedJob);
                    }
                }
            }
        }

        #region AzureVm job private helpers

        private static AzureRmRecoveryServicesAzureVmJob GetPSAzureVmJob(JobResource hydraJob)
        {
            AzureRmRecoveryServicesAzureVmJob response;

            AzureIaaSVMJob vmJob = hydraJob.Properties as AzureIaaSVMJob;

            if (vmJob.ExtendedInfo != null)
            {
                response = new AzureRmRecoveryServicesAzureVmJobDetails();
            }
            else
            {
                response = new AzureRmRecoveryServicesAzureVmJob();
            }

            response.InstanceId = hydraJob.Id;
            response.StartTime = vmJob.StartTime;
            response.EndTime = vmJob.EndTime;
            response.Duration = vmJob.Duration;
            response.Status = vmJob.Status;
            response.VmVersion = vmJob.VirtualMachineVersion;
            response.WorkloadName = vmJob.EntityFriendlyName;
            response.ActivityId = vmJob.ActivityId;
            response.BackupManagementType = EnumUtils.GetEnum<BackupManagementType>(vmJob.BackupManagementType);
            response.Operation = vmJob.Operation;

            if (vmJob.ErrorDetails != null)
            {
                response.ErrorDetails = new List<AzureRmRecoveryServicesAzureVmJobErrorInfo>();
                foreach (var vmError in vmJob.ErrorDetails)
                {
                    response.ErrorDetails.Add(GetPSAzureVmErrorInfo(vmError));
                }
            }

            // fill extended info if present
            if (vmJob.ExtendedInfo != null)
            {
                AzureRmRecoveryServicesAzureVmJobDetails detailedResponse =
                    response as AzureRmRecoveryServicesAzureVmJobDetails;

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
                    detailedResponse.SubTasks = new List<AzureRmRecoveryServicesAzureVmJobSubTask>();
                    foreach (var vmJobTask in vmJob.ExtendedInfo.TasksList)
                    {
                        detailedResponse.SubTasks.Add(new AzureRmRecoveryServicesAzureVmJobSubTask()
                        {
                            Name = vmJobTask.TaskId,
                            Status = vmJobTask.Status
                        });
                    }
                }
            }

            return response;
        }

        private static AzureRmRecoveryServicesAzureVmJobErrorInfo GetPSAzureVmErrorInfo(AzureIaaSVMErrorInfo hydraError)
        {
            AzureRmRecoveryServicesAzureVmJobErrorInfo psErrorInfo = new AzureRmRecoveryServicesAzureVmJobErrorInfo();
            psErrorInfo.ErrorCode = hydraError.ErrorCode;
            psErrorInfo.ErrorMessage = hydraError.ErrorString;
            if (hydraError.Recommendations != null)
            {
                psErrorInfo.Recommendations = new List<string>();
                psErrorInfo.Recommendations.AddRange(hydraError.Recommendations);
            }

            return psErrorInfo;
        }

        #endregion

        #endregion
    }
}
