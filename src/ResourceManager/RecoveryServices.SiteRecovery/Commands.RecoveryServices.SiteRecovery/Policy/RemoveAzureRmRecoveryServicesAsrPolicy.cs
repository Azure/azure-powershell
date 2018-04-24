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

namespace Microsoft.Azure.Commands.RecoveryServices.SiteRecovery
{
    /// <summary>
    ///     Deletes the specified ASR replication policy from the Recovery Services vault.
    /// </summary>
    [Cmdlet(
        VerbsCommon.Remove,
        "AzureRmRecoveryServicesAsrPolicy",
        SupportsShouldProcess = true)]
    [Alias("Remove-ASRPolicy")]
    [OutputType(typeof(ASRJob))]
    public class RemoveAzureRmRecoveryServicesAsrPolicy : SiteRecoveryCmdletBase
    {
        /// <summary>
        ///     Gets or sets replication policy object corresponding to the replication policy to be deleted.
        /// </summary>
        [Parameter(
            Mandatory = true,
            ValueFromPipeline = true)]
        [Alias("Policy")]
        public ASRPolicy InputObject { get; set; }

        /// <summary>
        ///     ProcessRecord of the command.
        /// </summary>
        public override void ExecuteSiteRecoveryCmdlet()
        {
            base.ExecuteSiteRecoveryCmdlet();

            if (this.ShouldProcess(
                this.InputObject.FriendlyName,
                VerbsCommon.Remove))
            {
                var responseBlue = this.RecoveryServicesClient.DeletePolicy(this.InputObject.Name);

                var jobResponseBlue = this.RecoveryServicesClient.GetAzureSiteRecoveryJobDetails(
                    PSRecoveryServicesClient.GetJobIdFromReponseLocation(responseBlue.Location));

                this.WriteObject(new ASRJob(jobResponseBlue));
            }
        }
    }
}