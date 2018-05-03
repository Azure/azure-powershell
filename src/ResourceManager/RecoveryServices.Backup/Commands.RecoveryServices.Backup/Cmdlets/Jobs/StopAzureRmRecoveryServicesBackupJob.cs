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
using System.Net;
using Microsoft.Azure.Commands.RecoveryServices.Backup.Cmdlets.Models;
using Microsoft.Azure.Commands.RecoveryServices.Backup.Helpers;
using Microsoft.Azure.Commands.RecoveryServices.Backup.Properties;

namespace Microsoft.Azure.Commands.RecoveryServices.Backup.Cmdlets
{
    /// <summary>
    /// Cancels a job. Returns the corresponding job object after the trigger of the cancellation finishes. 
    /// The job may not cancel successfully. The cmdlet will ensure that the service is notified that a cancellation has been triggered.
    /// </summary>
    [Cmdlet("Stop", "AzureRmRecoveryServicesBackupJob", DefaultParameterSetName = JobFilterSet,
        SupportsShouldProcess = true), OutputType(typeof(JobBase))]
    public class StopAzureRmRecoveryServicesBackupJob : RecoveryServicesBackupCmdletBase
    {
        protected const string IdFilterSet = "IdFilterSet";
        protected const string JobFilterSet = "JobFilterSet";

        /// <summary>
        /// Job which needs to be canceled.
        /// </summary>
        [Parameter(Mandatory = true, HelpMessage = ParamHelpMsgs.Job.StopJobJobFilter,
            ParameterSetName = JobFilterSet, Position = 1)]
        [ValidateNotNull]
        public JobBase Job { get; set; }

        /// <summary>
        /// ID of the job which needs to be canceled.
        /// </summary>
        [Parameter(Mandatory = true, HelpMessage = ParamHelpMsgs.Job.StopJobJobIdFilter,
            ParameterSetName = IdFilterSet, Position = 2)]
        [ValidateNotNull]
        public string JobId { get; set; }

        public override void ExecuteCmdlet()
        {
            if (ParameterSetName == JobFilterSet)
            {
                JobId = Job.JobId;
            }

            ExecutionBlock(() =>
            {
                base.ExecuteCmdlet();

                WriteDebug("Stopping job with ID: " + JobId);

                var cancelResponse = ServiceClientAdapter.CancelJob(JobId);

                var operationStatus = TrackingHelpers.GetOperationResult(
                    cancelResponse,
                    operationId => ServiceClientAdapter.GetCancelJobOperationResult(operationId));

                if (operationStatus.Response.StatusCode != HttpStatusCode.NoContent)
                {
                    throw new Exception(string.Format(Resources.JobCouldNotCancelJob,
                        cancelResponse.Response.StatusCode.ToString()));
                }
                else
                {
                    WriteObject(JobConversions.GetPSJob(ServiceClientAdapter.GetJob(JobId)));
                }
            }, ShouldProcess(JobId, "Stop"));
        }
    }
}
