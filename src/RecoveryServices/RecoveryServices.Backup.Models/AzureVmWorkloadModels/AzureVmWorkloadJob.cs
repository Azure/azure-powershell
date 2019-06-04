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

namespace Microsoft.Azure.Commands.RecoveryServices.Backup.Cmdlets.Models
{
    /// <summary>
    /// Represents Azure Workload specific job class.
    /// </summary>
    public class AzureVmWorkloadJob : AzureJob { }

    /// <summary>
    /// Azure Workload specific job details class.
    /// </summary>
    public class AzureVmWorkloadJobDetails : AzureVmWorkloadJob
    {
        /// <summary>
        /// Context sensitive error message that might be helpful in debugging the issue. 
        /// Mostly this contains trace dumps from Workload.
        /// </summary>
        public string DynamicErrorMessage { get; set; }

        /// <summary>
        /// Property bag consisting of the some Azure Workload specific job details.
        /// </summary>
        public Dictionary<string, string> Properties { get; set; }

        /// <summary>
        /// List of sub tasks triggered as part of this job's operation.
        /// </summary>
        public List<AzureVmWorkloadJobSubTask> SubTasks { get; set; }
    }

    /// <summary>
    /// Azure Workload specific job error info class.
    /// </summary>
    public class AzureVmWorkloadJobErrorInfo : AzureJobErrorInfo { }

    /// <summary>
    /// Azure Workload specific job sub-task class.
    /// </summary>
    public class AzureVmWorkloadJobSubTask : AzureJobSubTask { }
}