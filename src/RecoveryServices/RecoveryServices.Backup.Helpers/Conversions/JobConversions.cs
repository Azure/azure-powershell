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
using CrrModel = Microsoft.Azure.Management.RecoveryServices.Backup.CrossRegionRestore.Models;
using CmdletModel = Microsoft.Azure.Commands.RecoveryServices.Backup.Cmdlets.Models;
using Newtonsoft.Json;

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
            else if (serviceClientJob.Properties.GetType() == typeof(MabJob)) 
            {
                response = GetPSMabJob(serviceClientJob);
            }
            else if (serviceClientJob.Properties.GetType() == typeof(VaultJob))
            {
                response = GetPSAzureVaultJob(serviceClientJob);
            }

            return response;
        }

        /// <summary>
        /// Helper function to convert ps backup job model from service response.
        /// </summary>
        public static CmdletModel.JobBase GetPSJobCrr(CrrModel.JobResource serviceClientJob)
        {
            CmdletModel.JobBase response = null;

            // ServiceClient doesn't initialize Properties if the type of job is not known to current version of ServiceClient.
            if (serviceClientJob.Properties == null)
            {
                Logger.Instance.WriteWarning(Resources.UnsupportedJobWarning);
            }
            else if (serviceClientJob.Properties.GetType() == typeof(CrrModel.AzureIaaSVMJob))
            {
                response = GetPSAzureVmJobCrr(serviceClientJob);
            }
            else if (serviceClientJob.Properties.GetType() == typeof(CrrModel.AzureStorageJob))
            {
                response = GetPSAzureFileShareJobCrr(serviceClientJob);
            }
            else if (serviceClientJob.Properties.GetType() == typeof(CrrModel.AzureWorkloadJob))
            {
                response = GetPSAzureWorkloadJobCrr(serviceClientJob);
            }
            else if (serviceClientJob.Properties.GetType() == typeof(CrrModel.MabJob))
            {
                response = GetPSMabJobCrr(serviceClientJob);
            }
            /*else if (serviceClientJob.Properties.GetType() == typeof(VaultJob))
            {
                response = GetPSAzureVaultJob(serviceClientJob); // add Crr if needed 
            }*/
            else if (serviceClientJob.Properties.GetType() == typeof(CrrModel.Job))
            {
                response = GetPSAzureBaseJobCrr(serviceClientJob);
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

        /// <summary>
        /// Helper function to convert ps backup job list model from service response.
        /// </summary>
        public static void AddServiceClientJobsToPSListCrr(
            List<CrrModel.JobResource> serviceClientJobs,
            List<CmdletModel.JobBase> psJobs,
            ref int jobsCount)
        {
            if (serviceClientJobs != null)
            {                
                foreach (var job in serviceClientJobs)
                {
                    CmdletModel.JobBase convertedJob = GetPSJobCrr(job);
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

        #endregion

        #region Vault job private helpers


        /// <summary>
        /// Helper function to convert ps azure vm backup policy job from service response.
        /// </summary>
        private static CmdletModel.VaultJob GetPSAzureVaultJob(JobResource serviceClientJob)
        {
            CmdletModel.VaultJob response;

            VaultJob vaultJob = serviceClientJob.Properties as VaultJob;

            if (vaultJob.ExtendedInfo != null)
            {
                response = new CmdletModel.VaultJobDetails();
            }
            else
            {
                response = new CmdletModel.VaultJob();
            }

            response.JobId = GetLastIdFromFullId(serviceClientJob.Id);
            response.StartTime = GetJobStartTime(vaultJob.StartTime);
            response.EndTime = vaultJob.EndTime;
            response.Duration = GetJobDuration(vaultJob.Duration);
            response.Status = vaultJob.Status;
            response.WorkloadName = vaultJob.EntityFriendlyName;
            response.ActivityId = vaultJob.ActivityId;
            response.BackupManagementType = CmdletModel.ConversionUtils.GetPsBackupManagementType(vaultJob.BackupManagementType);
            response.Operation = vaultJob.Operation;

            if (vaultJob.ErrorDetails != null)
            {
                response.ErrorDetails = new List<CmdletModel.AzureJobErrorInfo>();
                foreach (var vaultError in vaultJob.ErrorDetails)
                {
                    response.ErrorDetails.Add(GetPSVaultErrorInfo(vaultError));
                }
            }

            if (vaultJob.ExtendedInfo != null)
            {
                CmdletModel.VaultJobDetails detailedResponse =
                    response as CmdletModel.VaultJobDetails;

                if (vaultJob.ExtendedInfo.PropertyBag != null)
                {
                    detailedResponse.Properties = new Dictionary<string, string>();
                    foreach (var key in vaultJob.ExtendedInfo.PropertyBag.Keys)
                    {
                        detailedResponse.Properties.Add(key, vaultJob.ExtendedInfo.PropertyBag[key]);
                    }
                }               
            }

            return response;
        }        

        private static CmdletModel.AzureJobErrorInfo GetPSVaultErrorInfo(VaultJobErrorInfo vaultError)
        {
            CmdletModel.VaultJobErrorInfo psErrorInfo = new CmdletModel.VaultJobErrorInfo();
            psErrorInfo.ErrorCode = GetJobErrorCode(vaultError.ErrorCode);
            psErrorInfo.ErrorMessage = vaultError.ErrorString;
            if (vaultError.Recommendations != null)
            {
                psErrorInfo.Recommendations = new List<string>();
                psErrorInfo.Recommendations.AddRange(vaultError.Recommendations);
            }

            return psErrorInfo;
        }       

        #endregion

        #region MAB job private helpers

        /// <summary>
        /// Creates the powershell MabJob object from service response.
        /// </summary>
        private static CmdletModel.JobBase GetPSMabJob(JobResource serviceClientJob)
        {
            CmdletModel.MabJob response;

            MabJob mabJob = serviceClientJob.Properties as MabJob;

            if (mabJob.ExtendedInfo != null)
            {
                response = new CmdletModel.MabJobDetails();
            }
            else
            {
                response = new CmdletModel.MabJob();
            }

            // Transfer values from service job object to powershell job object. 
            response.JobId = GetLastIdFromFullId(serviceClientJob.Id);
            response.StartTime = GetJobStartTime(mabJob.StartTime);
            response.EndTime = mabJob.EndTime;
            response.Duration = GetJobDuration(mabJob.Duration);
            response.Status = mabJob.Status;
            response.WorkloadName = mabJob.EntityFriendlyName;
            response.ActivityId = mabJob.ActivityId;
            response.BackupManagementType =
                CmdletModel.ConversionUtils.GetPsBackupManagementType(mabJob.BackupManagementType);
            response.Operation = mabJob.Operation;

            if (mabJob.ErrorDetails != null)
            {
                response.ErrorDetails = new List<CmdletModel.AzureJobErrorInfo>();
                foreach (var mabError in mabJob.ErrorDetails)
                {
                    response.ErrorDetails.Add(GetPSMabErrorInfo(mabError));
                }
            }

            // fill extended info if present
            if (mabJob.ExtendedInfo != null)
            {
                CmdletModel.MabJobDetails detailedResponse = response as CmdletModel.MabJobDetails;

                detailedResponse.DynamicErrorMessage = mabJob.ExtendedInfo.DynamicErrorMessage;
                if (mabJob.ExtendedInfo.PropertyBag != null)
                {
                    detailedResponse.Properties = new Dictionary<string, string>();
                    foreach (var key in mabJob.ExtendedInfo.PropertyBag.Keys)
                    {
                        detailedResponse.Properties.Add(key, mabJob.ExtendedInfo.PropertyBag[key]);
                    }
                }

                if (mabJob.ExtendedInfo.TasksList != null)
                {
                    detailedResponse.SubTasks = new List<CmdletModel.MabJobSubTask>();
                    foreach (var mabJobTask in mabJob.ExtendedInfo.TasksList)
                    {
                        detailedResponse.SubTasks.Add(new CmdletModel.MabJobSubTask()
                        {
                            Name = mabJobTask.TaskId,
                            Status = mabJobTask.Status
                        });
                    }
                }
            }

            return response;
        }

        /// <summary>
        /// Creates the powershell MabJob object from service response.
        /// </summary>
        private static CmdletModel.JobBase GetPSMabJobCrr(CrrModel.JobResource serviceClientJob)
        {
            CmdletModel.MabJob response;

            CrrModel.MabJob mabJob = serviceClientJob.Properties as CrrModel.MabJob;

            if (mabJob.ExtendedInfo != null)
            {
                response = new CmdletModel.MabJobDetails();
            }
            else
            {
                response = new CmdletModel.MabJob();
            }

            // Transfer values from service job object to powershell job object. 
            response.JobId = GetLastIdFromFullId(serviceClientJob.Id);
            response.StartTime = GetJobStartTime(mabJob.StartTime);
            response.EndTime = mabJob.EndTime;
            response.Duration = GetJobDuration(mabJob.Duration);
            response.Status = mabJob.Status;
            response.WorkloadName = mabJob.EntityFriendlyName;
            response.ActivityId = mabJob.ActivityId;
            response.BackupManagementType =
                CmdletModel.ConversionUtils.GetPsBackupManagementType(mabJob.BackupManagementType);
            response.Operation = mabJob.Operation;

            if (mabJob.ErrorDetails != null)
            {
                response.ErrorDetails = new List<CmdletModel.AzureJobErrorInfo>();
                foreach (var mabError in mabJob.ErrorDetails)
                {
                    response.ErrorDetails.Add(GetPSMabErrorInfoCrr(mabError));
                }
            }

            // fill extended info if present
            if (mabJob.ExtendedInfo != null)
            {
                CmdletModel.MabJobDetails detailedResponse = response as CmdletModel.MabJobDetails;

                detailedResponse.DynamicErrorMessage = mabJob.ExtendedInfo.DynamicErrorMessage;
                if (mabJob.ExtendedInfo.PropertyBag != null)
                {
                    detailedResponse.Properties = new Dictionary<string, string>();
                    foreach (var key in mabJob.ExtendedInfo.PropertyBag.Keys)
                    {
                        detailedResponse.Properties.Add(key, mabJob.ExtendedInfo.PropertyBag[key]);
                    }
                }

                if (mabJob.ExtendedInfo.TasksList != null)
                {
                    detailedResponse.SubTasks = new List<CmdletModel.MabJobSubTask>();
                    foreach (var mabJobTask in mabJob.ExtendedInfo.TasksList)
                    {
                        detailedResponse.SubTasks.Add(new CmdletModel.MabJobSubTask()
                        {
                            Name = mabJobTask.TaskId,
                            Status = mabJobTask.Status
                        });
                    }
                }
            }

            return response;
        }

        private static CmdletModel.AzureJobErrorInfo GetPSMabErrorInfo(MabErrorInfo mabError)
        {
            CmdletModel.MabJobErrorInfo psErrorInfo = new CmdletModel.MabJobErrorInfo();
            psErrorInfo.ErrorMessage = mabError.ErrorString;
            if (mabError.Recommendations != null)
            {
                psErrorInfo.Recommendations = new List<string>();
                psErrorInfo.Recommendations.AddRange(mabError.Recommendations);
            }

            return psErrorInfo;
        }

        private static CmdletModel.AzureJobErrorInfo GetPSMabErrorInfoCrr(CrrModel.MabErrorInfo mabError)
        {
            CmdletModel.MabJobErrorInfo psErrorInfo = new CmdletModel.MabJobErrorInfo();
            psErrorInfo.ErrorMessage = mabError.ErrorString;
            if (mabError.Recommendations != null)
            {
                psErrorInfo.Recommendations = new List<string>();
                psErrorInfo.Recommendations.AddRange(mabError.Recommendations);
            }

            return psErrorInfo;
        }

        #endregion

        #region AFS job private helpers

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
            response.StorageAccountName = fileShareJob.StorageAccountName;

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

        private static CmdletModel.JobBase GetPSAzureFileShareJobCrr(CrrModel.JobResource serviceClientJob)
        {
            CmdletModel.AzureFileShareJob response;

            CrrModel.AzureStorageJob fileShareJob = serviceClientJob.Properties as CrrModel.AzureStorageJob;

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
                    response.ErrorDetails.Add(GetPSAzureFileShareErrorInfoCrr(fileShareError));
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

        private static CmdletModel.AzureJobErrorInfo GetPSAzureFileShareErrorInfoCrr(CrrModel.AzureStorageErrorInfo fileShareError)
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

        #endregion

        #region Workload job private helpers

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

        private static CmdletModel.JobBase GetPSAzureWorkloadJobCrr(CrrModel.JobResource serviceClientJob)
        {
            CmdletModel.AzureVmWorkloadJob response;

            CrrModel.AzureWorkloadJob workloadJob = serviceClientJob.Properties as CrrModel.AzureWorkloadJob;

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
                    response.ErrorDetails.Add(GetPSAzureWorkloadErrorInfoCrr(workloadError));
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

        private static CmdletModel.AzureJobErrorInfo GetPSAzureWorkloadErrorInfoCrr(CrrModel.AzureWorkloadErrorInfo workloadError)
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

        #endregion

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
                            Status = vmJobTask.Status, 
                            Duration = (vmJobTask.StartTime != null && vmJobTask.EndTime != null) ? vmJobTask.Duration : null
                        });
                    }
                }
            }

            return response;
        }

        /// <summary>
        /// Helper function to convert ps azure vm backup policy job from service response.
        /// </summary>
        private static CmdletModel.AzureVmJob GetPSAzureVmJobCrr(CrrModel.JobResource serviceClientJob)
        {
            CmdletModel.AzureVmJob response;

            CrrModel.AzureIaaSVMJob vmJob = serviceClientJob.Properties as CrrModel.AzureIaaSVMJob;

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
                    response.ErrorDetails.Add(GetPSAzureVmErrorInfoCrr(vmError));
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
        /// Helper function to convert ps azure vm backup policy job from service response.
        /// </summary>
        private static CmdletModel.AzureJob GetPSAzureBaseJobCrr(CrrModel.JobResource serviceClientJob)
        {
            CrrModel.Job baseJob = serviceClientJob.Properties;
            CmdletModel.AzureJob response = new CmdletModel.AzureJob();

            response.JobId = GetLastIdFromFullId(serviceClientJob.Id);
            response.StartTime = GetJobStartTime(baseJob.StartTime);
            response.EndTime = baseJob.EndTime;            
            response.Status = baseJob.Status;            
            response.WorkloadName = baseJob.EntityFriendlyName;
            response.ActivityId = baseJob.ActivityId;
            response.BackupManagementType = CmdletModel.ConversionUtils.GetPsBackupManagementType(baseJob.BackupManagementType);
            response.Operation = baseJob.Operation;
            
            return response;
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

        /// <summary>
        /// Helper function to convert ps azure vm backup job error info from service response.
        /// </summary>
        private static CmdletModel.AzureVmJobErrorInfo GetPSAzureVmErrorInfoCrr(CrrModel.AzureIaaSVMErrorInfo serviceClientError)
        {
            CmdletModel.AzureVmJobErrorInfo psErrorInfo = new CmdletModel.AzureVmJobErrorInfo();
            psErrorInfo.ErrorCode = GetJobErrorCode(serviceClientError.ErrorCode);
            psErrorInfo.ErrorMessage = serviceClientError.ErrorString;
            psErrorInfo.Recommendations = GetJobErrorRecommendations(serviceClientError.Recommendations);

            return psErrorInfo;
        }

        #endregion

        #region generic helpers

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
                
    }
}
