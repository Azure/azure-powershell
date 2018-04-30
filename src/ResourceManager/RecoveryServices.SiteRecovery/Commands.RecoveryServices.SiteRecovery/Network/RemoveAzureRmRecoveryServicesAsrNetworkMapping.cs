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
    ///     Deletes the specified ASR network mapping from the Recovery Services vault.
    /// </summary>
    [Cmdlet(
        VerbsCommon.Remove,
        "AzureRmRecoveryServicesAsrNetworkMapping",
        SupportsShouldProcess = true)]
    [Alias("Remove-ASRNetworkMapping")]
    [OutputType(typeof(ASRJob))]
    public class RemoveAzureRmRecoveryServicesAsrNetworkMapping : SiteRecoveryCmdletBase
    {
        /// <summary>
        ///     Gets or sets network mapping object corresponding to the ASR network mapping to be deleted.
        /// </summary>
        [Parameter(
            Mandatory = true,
            ValueFromPipeline = true)]
        [ValidateNotNullOrEmpty]
        [Alias("NetworkMapping")]
        public ASRNetworkMapping InputObject { get; set; }

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
                var response = this.RecoveryServicesClient.RemoveAzureSiteRecoveryNetworkMapping(
                    Utilities.GetValueFromArmId(
                        this.InputObject.ID,
                        ARMResourceTypeConstants.ReplicationFabrics),
                    Utilities.GetValueFromArmId(
                        this.InputObject.ID,
                        "replicationNetworks"),
                    Utilities.GetValueFromArmId(
                        this.InputObject.ID,
                        "replicationNetworkMappings"));

                var jobResponse = this.RecoveryServicesClient.GetAzureSiteRecoveryJobDetails(
                    PSRecoveryServicesClient.GetJobIdFromReponseLocation(response.Location));

                this.WriteObject(new ASRJob(jobResponse));
            }
        }
    }
}