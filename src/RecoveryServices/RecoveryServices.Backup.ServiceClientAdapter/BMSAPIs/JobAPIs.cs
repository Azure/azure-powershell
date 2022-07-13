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
using Microsoft.Azure.Commands.RecoveryServices.Backup.Helpers;
using Microsoft.Azure.Management.RecoveryServices.Backup.Models;
using CrrModel = Microsoft.Azure.Management.RecoveryServices.Backup.CrossRegionRestore.Models;    
using Microsoft.Rest.Azure.OData;
using RestAzureNS = Microsoft.Rest.Azure;

namespace Microsoft.Azure.Commands.RecoveryServices.Backup.Cmdlets.ServiceClientAdapterNS
{
    public partial class ServiceClientAdapter
    {
        /// <summary>
        /// Gets a job
        /// </summary>
        /// <param name="jobId">ID of the job</param>
        /// <param name="vaultName"></param>
        /// <param name="resourceGroupName"></param>
        /// <returns>Job response returned by the service</returns>
        public JobResource GetJob(
            string jobId,
            string vaultName = null,
            string resourceGroupName = null)
        {
            return BmsAdapter.Client.JobDetails.GetWithHttpMessagesAsync(
                vaultName ?? BmsAdapter.GetResourceName(),
                resourceGroupName ?? BmsAdapter.GetResourceGroupName(),
                jobId,
                cancellationToken: BmsAdapter.CmdletCancellationToken).Result.Body;
        }

        /// <summary>
        /// Gets CRR job details
        /// </summary>
        /// <param name="secondaryRegion">secondaryRegion for the vault </param>
        /// <param name="jobRequest">JobId, ResourceId for the Job to be fetched </param>
        /// <returns>Job response returned by the service</returns>
        public CrrModel.JobResource GetCRRJobDetails(
            string secondaryRegion,
            CrrModel.CrrJobRequest jobRequest
            )
        {
            return CrrAdapter.Client.BackupCrrJobDetails.GetWithHttpMessagesAsync(secondaryRegion, jobRequest).Result.Body;
        }

        public List<CrrModel.JobResource> GetCrrJobs(string vaultId,
            string jobId,
            string status,
            string operation,
            DateTime startTime,
            DateTime endTime,
            string backupManagementType, 
            string azureRegion = null)
        {
            ODataQuery<CrrModel.JobQueryObject> queryFilter = GetQueryObjectCrr(
                backupManagementType,
                startTime,
                endTime,
                jobId,
                status, 
                operation);
            
            CrrModel.CrrJobRequest crrJobRequest = new CrrModel.CrrJobRequest();
            crrJobRequest.ResourceId = vaultId;
            
            Func<RestAzureNS.IPage<CrrModel.JobResource>> listAsync =
                () => CrrAdapter.Client.BackupCrrJobs.ListWithHttpMessagesAsync(azureRegion, crrJobRequest, queryFilter,  cancellationToken: BmsAdapter.CmdletCancellationToken).Result.Body;

            Func<string, RestAzureNS.IPage<CrrModel.JobResource>> listNextAsync =
                nextLink => CrrAdapter.Client.BackupCrrJobs.ListNextWithHttpMessagesAsync(
                    nextLink,
                    cancellationToken: BmsAdapter.CmdletCancellationToken).Result.Body;

            return HelperUtils.GetPagedListCrr(listAsync, listNextAsync);
        }

        /// <summary>
        /// Lists jobs according to the parameters
        /// </summary>
        /// <param name="jobId">ID of the job</param>
        /// <param name="status">Status of the job</param>
        /// <param name="operation">Operation represented by the job</param>
        /// <param name="startTime">Time when the job started</param>
        /// <param name="endTime">Time when the job finished</param>
        /// <param name="backupManagementType">Backup management type of the item represented by the job</param>
        /// <param name="skipToken">Skip token pagination param</param>
        /// <param name="vaultName"></param>
        /// <param name="resourceGroupName"></param>
        /// <returns>Job list response from the service</returns>
        public List<JobResource> GetJobs(
            string jobId,
            string status,
            string operation,
            DateTime startTime,
            DateTime endTime,
            string backupManagementType,
            string skipToken = null,
            string vaultName = null,
            string resourceGroupName = null)
        {
            ODataQuery<JobQueryObject> queryFilter = GetQueryObject(
                backupManagementType,
                startTime,
                endTime,
                jobId,
                status,
                operation);

            Func<RestAzureNS.IPage<JobResource>> listAsync =
                () => BmsAdapter.Client.BackupJobs.ListWithHttpMessagesAsync(
                    vaultName ?? BmsAdapter.GetResourceName(),
                    resourceGroupName ?? BmsAdapter.GetResourceGroupName(),
                    queryFilter,
                    skipToken,
                    cancellationToken: BmsAdapter.CmdletCancellationToken).Result.Body;

            Func<string, RestAzureNS.IPage<JobResource>> listNextAsync =
                nextLink => BmsAdapter.Client.BackupJobs.ListNextWithHttpMessagesAsync(
                    nextLink,
                    cancellationToken: BmsAdapter.CmdletCancellationToken).Result.Body;

            return HelperUtils.GetPagedList(listAsync, listNextAsync);
        }

        /// <summary>
        /// Cancels a job
        /// </summary>
        /// <param name="jobId">ID of the job to cancel</param>
        /// <param name="vaultName"></param>
        /// <param name="resourceGroupName"></param>
        /// <returns>Cancelled job response from the service</returns>
        public RestAzureNS.AzureOperationResponse CancelJob(
            string jobId,
            string vaultName = null,
            string resourceGroupName = null)
        {
            return BmsAdapter.Client.JobCancellations.TriggerWithHttpMessagesAsync(
                vaultName ?? BmsAdapter.GetResourceName(),
                resourceGroupName ?? BmsAdapter.GetResourceGroupName(),
                jobId,
                cancellationToken: BmsAdapter.CmdletCancellationToken).Result;
        }

        /// <summary>
        /// Gets the job operation status
        /// </summary>
        /// <param name="jobId">ID of the job</param>
        /// <param name="operationId">ID of the operation associated with the job</param>
        /// <param name="vaultName"></param>
        /// <param name="resourceGroupName"></param>
        /// <returns>Job response returned by the service</returns>
        public RestAzureNS.AzureOperationResponse GetJobOperationStatus(
            string jobId,
            string operationId,
            string vaultName = null,
            string resourceGroupName = null)
        {
            return BmsAdapter.Client.JobOperationResults.GetWithHttpMessagesAsync(
                vaultName ?? BmsAdapter.GetResourceName(),
                resourceGroupName ?? BmsAdapter.GetResourceGroupName(),
                jobId,
                operationId,
                cancellationToken: BmsAdapter.CmdletCancellationToken).Result;
        }

        #region private helpers

        /// <summary>
        /// Constructs the query object based on the input parameters
        /// </summary>
        /// <param name="backupManagementType">Backup management type of the item associated with the job</param>
        /// <param name="startTime">Time when the job started</param>
        /// <param name="endTime">Time when the job ended</param>
        /// <param name="jobId">ID of the job</param>
        /// <param name="status">Status of the job</param>
        /// <param name="operation">ID of operation associated with the job</param>
        /// <returns></returns>
        public ODataQuery<JobQueryObject> GetQueryObject(
            string backupManagementType,
            DateTime startTime,
            DateTime endTime,
            string jobId,
            string status,
            string operation)
        {
            // build query filters object.
            // currently we don't support any provider specific filters.
            // so we are initializing the object directly


            var queryFilterString = QueryBuilder.Instance.GetQueryString(new JobQueryObject()
            {
                BackupManagementType = backupManagementType,
                StartTime = startTime,
                EndTime = endTime,
                JobId = jobId,
                Status = status,
                Operation = operation
            });

            ODataQuery<JobQueryObject> queryFilter = new ODataQuery<JobQueryObject>();
            queryFilter.Filter = queryFilterString;

            return queryFilter;
        }

        /// <summary>
        /// Constructs the query object based on the input parameters
        /// </summary>
        /// <param name="backupManagementType">Backup management type of the item associated with the job</param>
        /// <param name="startTime">Time when the job started</param>
        /// <param name="endTime">Time when the job ended</param>
        /// <param name="jobId">ID of the job</param>
        /// <param name="status">Status of the job</param>
        /// <param name="operation">ID of operation associated with the job</param>
        /// <returns></returns>
        public ODataQuery<CrrModel.JobQueryObject> GetQueryObjectCrr(
            string backupManagementType,
            DateTime startTime,
            DateTime endTime,
            string jobId,
            string status,
            string operation)
        {
            // build query filters object.
            // currently we don't support any provider specific filters.
            // so we are initializing the object directly
            var queryFilterString = QueryBuilder.Instance.GetQueryString(new CrrModel.JobQueryObject()
            {
                BackupManagementType = backupManagementType,
                StartTime = startTime,
                EndTime = endTime,
                JobId = jobId,
                Status = status,
                Operation = operation
            });

            ODataQuery<CrrModel.JobQueryObject> queryFilter = new ODataQuery<CrrModel.JobQueryObject>();
            queryFilter.Filter = queryFilterString;

            return queryFilter;
        }

        #endregion
    }
}
