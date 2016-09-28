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
    /// Used to initiate a commit operation.
    /// </summary>
    [Cmdlet(VerbsData.Update, "AzureSiteRecoveryProtectionEntity")]
    [OutputType(typeof(ASRJob))]
    public class UpdateAzureSiteRecoveryProtectionEntity : RecoveryServicesCmdletBase
    {
        #region Parameters

        /// <summary>
        /// ID of the PE object to Update user information on.
        /// </summary>
        private string protectionEntityId;

        /// <summary>
        /// Protection container ID of the object to Update user information on.
        /// </summary>
        private string protectionContainerId;

        /// <summary>
        /// Job response.
        /// </summary>
        private JobResponse jobResponse = null;

        /// <summary>
        /// Gets or sets Protection Entity object.
        /// </summary>
        [Parameter(Mandatory = true, ValueFromPipeline = true)]
        [ValidateNotNullOrEmpty]
        public ASRProtectionEntity ProtectionEntity
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets switch parameter. This is required to wait for job completion.
        /// </summary>
        [Parameter]
        public SwitchParameter WaitForCompletion
        {
            get;
            set;
        }

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

                this.protectionContainerId = this.ProtectionEntity.ProtectionContainerId;
                this.protectionEntityId = this.ProtectionEntity.ID;
                this.SyncOwnerInformationOnPE();
            }
            catch (Exception exception)
            {
                this.HandleException(exception);
            }
        }

        /// <summary>
        /// Handles interrupts.
        /// </summary>
        protected override void StopProcessing()
        {
            // Ctrl + C and etc
            base.StopProcessing();
            this.StopProcessingFlag = true;
        }

        /// <summary>
        /// Syncs the owner information.
        /// </summary>
        private void SyncOwnerInformationOnPE()
        {
            this.jobResponse = RecoveryServicesClient.UpdateAzureSiteRecoveryProtectionEntity(
                this.protectionContainerId,
                this.protectionEntityId);

            this.WriteJob(this.jobResponse.Job);

            if (this.WaitForCompletion)
            {
                this.WaitForJobCompletion(this.jobResponse.Job.ID);
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