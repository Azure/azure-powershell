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
using System.Diagnostics;
using System.Management.Automation;
using System.Threading;
using Microsoft.Azure.Commands.RecoveryServices.SiteRecovery;
using Microsoft.WindowsAzure.Management.SiteRecovery.Models;

namespace Microsoft.Azure.Commands.RecoveryServices
{
    /// <summary>
    /// Remove a Recovery Plan from the current Azure Site Recovery Vault.
    /// </summary>
    [Cmdlet(VerbsCommon.Remove, "AzureSiteRecoveryRecoveryPlan", DefaultParameterSetName = ASRParameterSets.ByRPObject, SupportsShouldProcess = true)]
    [OutputType(typeof(ASRJob))]
    public class RemoveAzureSiteRecoveryRecoveryPlan : RecoveryServicesCmdletBase
    {
        #region Parameters
        /// <summary>
        /// Job response.
        /// </summary>
        private JobResponse jobResponse = null;

        /// <summary>
        /// Holds either Name (if object is passed) or ID (if IDs are passed) of the PE.
        /// </summary>
        private string targetNameOrId = string.Empty;

        /// <summary>
        /// Gets or sets ID of the Recovery Plan.
        /// </summary>
        [Parameter(ParameterSetName = ASRParameterSets.ById, Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets Recovery Plan object.
        /// </summary>
        [Parameter(ParameterSetName = ASRParameterSets.ByRPObject, Mandatory = true, ValueFromPipeline = true)]
        [ValidateNotNullOrEmpty]
        public ASRRecoveryPlan RecoveryPlan { get; set; }

        /// <summary>
        /// Gets or sets switch parameter. This is required to wait for job completion.
        /// </summary>
        [Parameter]
        public SwitchParameter WaitForCompletion { get; set; }

        /// <summary>
        /// Gets or sets switch parameter. On passing, command does not ask for confirmation.
        /// </summary>
        [Parameter(Mandatory = false)]
        public SwitchParameter Force { get; set; }
        #endregion Parameters

        /// <summary>
        /// ProcessRecord of the command.
        /// </summary>
        public override void ExecuteCmdlet()
        {
            this.WriteWarningWithTimestamp(
                string.Format(
                    Properties.Resources.CmdletWillBeDeprecatedSoon,
                    this.MyInvocation.MyCommand.Name));

            switch (this.ParameterSetName)
            {
                case ASRParameterSets.ByRPObject:
                    this.Id = this.RecoveryPlan.ID;
                    this.targetNameOrId = this.RecoveryPlan.Name;
                    break;
                case ASRParameterSets.ById:
                    this.targetNameOrId = this.Id;
                    break;
            }

            this.ConfirmAction(
                this.Force.IsPresent,
                string.Format(Properties.Resources.RemoveRPWarning, this.targetNameOrId),
                Properties.Resources.RemoveRPWhatIfMessage,
                this.targetNameOrId,
                () =>
                {
                    try
                    {
                        this.jobResponse = RecoveryServicesClient.RemoveAzureSiteRecoveryRecoveryPlan(
                           this.Id);
                        this.WriteJob(this.jobResponse.Job);

                        string jobId = this.jobResponse.Job.ID;
                        if (this.WaitForCompletion.IsPresent)
                        {
                            this.WaitForJobCompletion(this.jobResponse.Job.ID);
                        }
                    }
                    catch (Exception exception)
                    {
                        this.HandleException(exception);
                    }
                });
        }

        /// <summary>
        /// Writes Job
        /// </summary>
        /// <param name="job">Job object</param>
        private void WriteJob(Microsoft.WindowsAzure.Management.SiteRecovery.Models.Job job)
        {
            this.WriteObject(new ASRJob(job));
        }
    }
}