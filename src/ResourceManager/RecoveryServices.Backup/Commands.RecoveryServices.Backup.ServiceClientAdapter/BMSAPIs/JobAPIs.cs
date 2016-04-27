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
using Microsoft.Azure.Management.RecoveryServices.Backup.Models;

namespace Microsoft.Azure.Commands.RecoveryServices.Backup.Cmdlets.ServiceClientAdapterNS
{
    public partial class ServiceClientAdapter
    {
        public JobResponse GetJob(string jobId)
        {
            string resourceName = BmsAdapter.GetResourceName();
            string resourceGroupName = BmsAdapter.GetResourceGroupName();

            return BmsAdapter.Client.Jobs.GetAsync(
                resourceGroupName,
                resourceName,
                jobId,
                BmsAdapter.GetCustomRequestHeaders(),
                BmsAdapter.CmdletCancellationToken).Result;
        }

        public JobListResponse GetJobs(
            string jobId,
            string status,
            string operation,
            DateTime startTime,
            DateTime endTime,
            string backupManagementType,
            int? top = null,
            string skipToken = null)
        {
            string resourceName = BmsAdapter.GetResourceName();
            string resourceGroupName = BmsAdapter.GetResourceGroupName();

            // build pagination request
            PaginationRequest pagReq = new PaginationRequest()
            {
                SkipToken = skipToken
            };
            // respecting top if provided
            if (top.HasValue)
            {
                pagReq.Top = top.ToString();
            }

            CommonJobQueryFilters commonFilters = GetQueryObject(
                backupManagementType,
                startTime,
                endTime,
                jobId,
                status,
                operation);

            return BmsAdapter.Client.Jobs.ListAsync(
                resourceGroupName,
                resourceName,
                commonFilters,
                pagReq,
                BmsAdapter.GetCustomRequestHeaders(),
                BmsAdapter.CmdletCancellationToken).Result;
        }

        public BaseRecoveryServicesJobResponse CancelJob(string jobId)
        {
            string resourceName = BmsAdapter.GetResourceName();
            string resourceGroupName = BmsAdapter.GetResourceGroupName();

            return BmsAdapter.Client.Jobs.CancelJobAsync(
                resourceGroupName,
                resourceName,
                jobId,
                BmsAdapter.GetCustomRequestHeaders(),
                BmsAdapter.CmdletCancellationToken).Result;
        }

        public JobResponse GetJobOperationStatus(string jobId, string operationId)
        {
            string resourceName = BmsAdapter.GetResourceName();
            string resourceGroupName = BmsAdapter.GetResourceGroupName();

            return BmsAdapter.Client.Jobs.GetOperationResultAsync(
                resourceGroupName,
                resourceName,
                jobId,
                operationId,
                BmsAdapter.GetCustomRequestHeaders(),
                BmsAdapter.CmdletCancellationToken).Result;
        }

        #region private helpers

        public CommonJobQueryFilters GetQueryObject(
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
            CommonJobQueryFilters commonFilters = new CommonJobQueryFilters()
            {
                BackupManagementType = backupManagementType,
                StartTime = CommonHelpers.GetDateTimeStringForService(startTime),
                EndTime = CommonHelpers.GetDateTimeStringForService(endTime),
                JobId = jobId,
                Status = status,
                Operation = operation
            };

            return commonFilters;
        }

        #endregion
    }
}
