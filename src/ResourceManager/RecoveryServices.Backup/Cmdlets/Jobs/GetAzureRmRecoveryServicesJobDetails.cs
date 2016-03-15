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
    [Cmdlet(VerbsCommon.Get, "AzureRmBackupJobDetails"), OutputType(typeof(AzureRmRecoveryServicesJobBase))]
    public class GetAzureRmRecoveryServicesJobDetails : RecoveryServicesBackupCmdletBase
    {
        [Parameter(Mandatory = false, HelpMessage = ParamHelpMsg.Common.Vault, ValueFromPipeline = true)]
        public ARSVault Vault { get; set; }

        [Parameter(Mandatory = true, HelpMessage = ParamHelpMsg.Job.JobIdFilter, ParameterSetName = "IdFilterSet")]
        [ValidateNotNullOrEmpty]
        public string JobId { get; set; }

        [Parameter(Mandatory = true, HelpMessage = ParamHelpMsg.Job.JobFilter, ParameterSetName = "JobFilterSet")]
        [ValidateNotNull]
        public AzureRmRecoveryServicesJobBase Job { get; set; }

        public override void ExecuteCmdlet()
        {
            ExecutionBlock(() =>
            {
                base.ExecuteCmdlet();

                if (string.IsNullOrEmpty(JobId) && Job != null)
                {
                    JobId = Job.InstanceId;
                }

                // Initialize vault object from base cmdlet
                var adapterResponse = HydraAdapter.GetJob(Vault.ResouceGroupName, Vault.Name, JobId);
                WriteObject(JobConversions.GetPSJob(adapterResponse));
            });
        }
    }
}
