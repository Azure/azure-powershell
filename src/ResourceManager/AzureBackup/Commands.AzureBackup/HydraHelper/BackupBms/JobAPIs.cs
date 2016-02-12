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

using Microsoft.Azure.Management.BackupServices.Models;
using System;
using System.Collections.Generic;

namespace Microsoft.Azure.Commands.AzureBackup.Client
{
    public partial class HydraHelper
    {
        public IEnumerable<CSMJobResponse> BackupListJobs(string resourceGroupName, string resourceName, CSMJobQueryObject queryParams)
        {
            var response = BackupBmsAdapter.Client.Job.ListAsync(
                resourceGroupName, resourceName, queryParams,
                BackupBmsAdapter.GetCustomRequestHeaders(), BackupBmsAdapter.CmdletCancellationToken).Result;
            return response.List.Value;
        }

        public CSMJobDetailsResponse BackupGetJobDetails(string resourceGroupName, string resourceName, string jobId)
        {
            var response = BackupBmsAdapter.Client.Job.GetAsync(
                resourceGroupName, resourceName, jobId,
                BackupBmsAdapter.GetCustomRequestHeaders(), BackupBmsAdapter.CmdletCancellationToken).Result;
            return response.Value;
        }

        public Guid BackupTriggerCancelJob(string resourceGroupName, string resourceName, string jobId)
        {
            var response = BackupBmsAdapter.Client.Job.StopAsync(
                resourceGroupName, resourceName, jobId,
                BackupBmsAdapter.GetCustomRequestHeaders(), BackupBmsAdapter.CmdletCancellationToken).Result.OperationId;
            return response;
        }
    }
}