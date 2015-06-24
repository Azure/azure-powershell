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
using System.Management.Automation;
using System.Collections.Generic;
using System.Xml;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using Microsoft.Azure.Common.Authentication;
using Microsoft.Azure.Common.Authentication.Models;
using System.Threading;
using Hyak.Common;
using Microsoft.Azure.Commands.AzureBackup.Properties;
using System.Net;
using Microsoft.WindowsAzure.Management.Scheduler;
using Microsoft.Azure.Management.BackupServices;
using Microsoft.Azure.Management.BackupServices.Models;
using Mgmt = Microsoft.Azure.Management.BackupServices.Models;

namespace Microsoft.Azure.Commands.AzureBackup.ClientAdapter
{
    public partial class AzureBackupClientAdapter
    {
        public IEnumerable<Mgmt.Job> ListJobs(JobQueryParameter queryParams)
        {
            var response = AzureBackupClient.Job.ListAsync(queryParams, GetCustomRequestHeaders(), CmdletCancellationToken).Result;
            return response.Jobs.Objects;
        }

        public Mgmt.JobByIdResponse GetJobDetails(string jobId)
        {
            var response = AzureBackupClient.Job.GetAsync(jobId, GetCustomRequestHeaders(), CmdletCancellationToken).Result;
            return response;
        }

        public Guid TriggerCancelJob(string jobId)
        {
            var response = AzureBackupClient.Job.StopAsync(jobId, GetCustomRequestHeaders(), CmdletCancellationToken).Result.OperationId;
            return response;
        }
    }
}