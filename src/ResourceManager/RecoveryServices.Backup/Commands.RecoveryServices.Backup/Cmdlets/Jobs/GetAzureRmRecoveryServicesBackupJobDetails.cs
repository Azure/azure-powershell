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

using System.Management.Automation;
using Microsoft.Azure.Commands.RecoveryServices.Backup.Cmdlets.Models;
using Microsoft.Azure.Commands.RecoveryServices.Backup.Helpers;

namespace Microsoft.Azure.Commands.RecoveryServices.Backup.Cmdlets
{
    /// <summary>
    /// Gets detailed information about a particular job.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "AzureRmRecoveryServicesBackupJobDetails", 
        DefaultParameterSetName = JobFilterSet), OutputType(typeof(JobBase))]
    public class GetAzureRmRecoveryServicesBackupJobDetails : RecoveryServicesBackupCmdletBase
    {
        protected const string IdFilterSet = "IdFilterSet";
        protected const string JobFilterSet = "JobFilterSet";

        /// <summary>
        /// Job whose details are to be fetched.
        /// </summary>
        [Parameter(Mandatory = true, HelpMessage = ParamHelpMsgs.Job.JobFilter, 
            ParameterSetName = JobFilterSet, Position = 1)]
        [ValidateNotNull]
        public JobBase Job { get; set; }

        /// <summary>
        /// ID of job whose details are to be fetched.
        /// </summary>
        [Parameter(Mandatory = true, HelpMessage = ParamHelpMsgs.Job.JobIdFilter,
            ParameterSetName = IdFilterSet, Position = 2)]
        [ValidateNotNullOrEmpty]
        public string JobId { get; set; }

        public override void ExecuteCmdlet()
        {
            ExecutionBlock(() =>
            {
                base.ExecuteCmdlet();

                if (ParameterSetName == JobFilterSet)
                {
                    JobId = Job.JobId;
                }

                WriteDebug("Fetching job with ID: " + JobId);

                var adapterResponse = ServiceClientAdapter.GetJob(JobId);
                WriteObject(JobConversions.GetPSJob(adapterResponse));
            });
        }
    }
}
