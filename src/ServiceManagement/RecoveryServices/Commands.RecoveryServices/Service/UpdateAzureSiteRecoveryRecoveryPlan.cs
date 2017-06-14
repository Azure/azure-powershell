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
    /// Used to initiate a recovery plan update operation.
    /// </summary>
    [Cmdlet(VerbsData.Update, "AzureSiteRecoveryRecoveryPlan")]
    [OutputType(typeof(ASRJob))]
    public class UpdateAzureSiteRecoveryRecoveryPlan : RecoveryServicesCmdletBase
    {
        #region Parameters
        /// <summary>
        /// Job response.
        /// </summary>
        private JobResponse jobResponse = null;

        /// <summary>
        /// Gets or sets XML file path of the Recovery Plan.
        /// </summary>
        [Parameter(Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public string File { get; set; }

        /// <summary>
        /// Gets or sets switch parameter. This is required to wait for job completion.
        /// </summary>
        [Parameter]
        public SwitchParameter WaitForCompletion { get; set; }
        #endregion Parameters

        /// <summary>
        /// ProcessRecord of the command.
        /// </summary>
        public override void ExecuteCmdlet()
        {
            try
            {
                this.WriteWarningWithTimestamp(
                    string.Format(
                        Properties.Resources.CmdletWillBeDeprecatedSoon,
                        this.MyInvocation.MyCommand.Name));

                string recoveryPlanXml = System.IO.File.ReadAllText(this.File);

                this.jobResponse = RecoveryServicesClient.UpdateAzureSiteRecoveryRecoveryPlan(
                    recoveryPlanXml);
                this.WriteJob(this.jobResponse.Job);

                if (this.WaitForCompletion.IsPresent)
                {
                    this.WaitForJobCompletion(this.jobResponse.Job.ID);
                }
            }
            catch (Exception exception)
            {
                this.HandleException(exception);
            }
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