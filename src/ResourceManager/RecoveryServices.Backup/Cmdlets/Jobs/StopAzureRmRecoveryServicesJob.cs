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
using System.Management.Automation;
using System.Net;
using System.Threading;
using Microsoft.Azure.Commands.RecoveryServices.Backup.Cmdlets.Models;
using Microsoft.Azure.Commands.RecoveryServices.Backup.Helpers;
using Microsoft.Azure.Commands.RecoveryServices.Backup.Properties;

namespace Microsoft.Azure.Commands.RecoveryServices.Backup.Cmdlets
{
    [Cmdlet("Stop", "AzureRmRecoveryServicesJob", DefaultParameterSetName = JobFilterSet), OutputType(typeof(AzureRmRecoveryServicesJobBase))]
    public class StopAzureRmRecoveryServicesJob : RecoveryServicesBackupCmdletBase
    {
        protected const string IdFilterSet = "IdFilterSet";
        protected const string JobFilterSet = "JobFilterSet";

        [Parameter(Mandatory = true, HelpMessage = ParamHelpMsg.Job.StopJobJobFilter, ParameterSetName = JobFilterSet)]
        [ValidateNotNull]
        public AzureRmRecoveryServicesJobBase Job { get; set; }

        [Parameter(Mandatory = true, HelpMessage = ParamHelpMsg.Job.StopJobJobIdFilter, ParameterSetName = IdFilterSet)]
        [ValidateNotNull]
        public string JobId { get; set; }

        public override void ExecuteCmdlet()
        {
            ExecutionBlock(() =>
            {
                base.ExecuteCmdlet();

                if (ParameterSetName == JobFilterSet)
                {
                    JobId = Job.InstanceId;
                }

                WriteDebug("Stoppingjob with ID: " + JobId);

                var cancelResponse = HydraAdapter.CancelJob(JobId);
                string opId = HydraHelpers.GetLastIdFromFullId(cancelResponse.Location);
                var cancelStatus = HydraAdapter.GetJobOperationStatus(JobId, opId);

                while (cancelStatus.StatusCode == HttpStatusCode.Accepted)
                {
                    Thread.Sleep(15 * 1000);
                    cancelStatus = HydraAdapter.GetJobOperationStatus(JobId, opId);
                }

                if (cancelStatus.StatusCode != HttpStatusCode.NoContent)
                {
                    throw new Exception(string.Format(Resources.JobCouldNotCancelJob, cancelStatus.StatusCode.ToString()));
                }
                else
                {
                    WriteObject(JobConversions.GetPSJob(HydraAdapter.GetJob(JobId)));
                }
            });
        }
    }
}
