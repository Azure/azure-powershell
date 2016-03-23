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
using Microsoft.Azure.Commands.RecoveryServices.Backup.Cmdlets.Models;
using Microsoft.Azure.Commands.RecoveryServices.Backup.Helpers;

namespace Microsoft.Azure.Commands.RecoveryServices.Backup.Cmdlets
{
    [Cmdlet("Stop", "AzureRmBackupJob", DefaultParameterSetName = JobFilterSet), OutputType(typeof(AzureRmRecoveryServicesJobBase))]
    public class StopAzureRmRecoveryServicesJob : RecoveryServicesBackupCmdletBase
    {
        protected const string IdFilterSet = "IdFilterSet";
        protected const string JobFilterSet = "JobFilterSet";

        [Parameter(Mandatory = true, HelpMessage = ParamHelpMsg.Job.StopJobJobFilter, ParameterSetName = IdFilterSet)]
        [ValidateNotNull]
        public AzureRmRecoveryServicesJobBase Job { get; set; }

        [Parameter(Mandatory = true, HelpMessage = ParamHelpMsg.Job.StopJobJobIdFilter, ParameterSetName = JobFilterSet)]
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

                var cancelResponse = HydraAdapter.CancelJob(JobId);

                while (cancelResponse.StatusCode == System.Net.HttpStatusCode.Accepted)
                {

                }

                var adapterResponse = HydraAdapter.GetJob(JobId);
                WriteObject(JobConversions.GetPSJob(adapterResponse));
            });
        }
    }
}
