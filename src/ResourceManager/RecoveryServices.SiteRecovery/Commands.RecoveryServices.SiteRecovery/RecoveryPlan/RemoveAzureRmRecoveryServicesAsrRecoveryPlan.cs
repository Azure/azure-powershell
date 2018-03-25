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

namespace Microsoft.Azure.Commands.RecoveryServices.SiteRecovery
{
    /// <summary>
    ///     Deletes the specified ASR recovery plan from Recovery Services vault.
    /// </summary>
    [Cmdlet(
        VerbsCommon.Remove,
        "AzureRmRecoveryServicesAsrRecoveryPlan",
        DefaultParameterSetName = ASRParameterSets.ByObject,
        SupportsShouldProcess = true)]
    [Alias(
        "Remove-ASRRP",
        "Remove-ASRRecoveryPlan")]
    [OutputType(typeof(ASRJob))]
    public class RemoveAzureRmRecoveryServicesAsrRecoveryPlan : SiteRecoveryCmdletBase
    {
        /// <summary>
        ///     Gets or sets the name of the recovery plan to be deleted.
        /// </summary>
        [Parameter(
            Mandatory = true,
            ParameterSetName = ASRParameterSets.ByName)]
        public string Name { get; set; }

        /// <summary>
        ///     Gets or sets recovery plan object corresponding to the recovery plan to be deleted.
        /// </summary>
        [Parameter(
            Mandatory = true,
            ParameterSetName = ASRParameterSets.ByObject,
            ValueFromPipeline = true)]
        [Alias("RecoveryPlan")]
        public ASRRecoveryPlan InputObject { get; set; }

        /// <summary>
        ///     ProcessRecord of the command.
        /// </summary>
        public override void ExecuteSiteRecoveryCmdlet()
        {
            base.ExecuteSiteRecoveryCmdlet();

            if (this.InputObject != null)
            {
                this.Name = this.InputObject.Name;
            }

            if (this.ShouldProcess(
                this.Name,
                VerbsCommon.Remove))
            {
                if (string.Compare(
                        this.ParameterSetName,
                        ASRParameterSets.ByObject,
                        StringComparison.OrdinalIgnoreCase) ==
                    0)
                {
                    this.Name = this.InputObject.Name;
                }

                var response =
                    this.RecoveryServicesClient.RemoveAzureSiteRecoveryRecoveryPlan(this.Name);

                var jobResponse = this.RecoveryServicesClient.GetAzureSiteRecoveryJobDetails(
                    PSRecoveryServicesClient.GetJobIdFromReponseLocation(response.Location));

                this.WriteObject(new ASRJob(jobResponse));
            }
        }
    }
}