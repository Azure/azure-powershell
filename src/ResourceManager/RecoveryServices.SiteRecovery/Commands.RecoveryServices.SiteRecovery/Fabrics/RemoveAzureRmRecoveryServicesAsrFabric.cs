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
    ///     Creates Azure Site Recovery Policy object in memory.
    /// </summary>
    [Cmdlet(
        VerbsCommon.Remove,
        "AzureRmRecoveryServicesAsrFabric",
        DefaultParameterSetName = ASRParameterSets.Default,
        SupportsShouldProcess = true)]
    [Alias("Remove-ASRFabric")]
    [OutputType(typeof(ASRJob))]
    public class RemoveAzureRmRecoveryServicesAsrFabric : SiteRecoveryCmdletBase
    {
        /// <summary>
        ///     Gets or sets the fabric name
        /// </summary>
        [Parameter(
            ParameterSetName = ASRParameterSets.Default,
            Mandatory = true,
            ValueFromPipeline = true)]
        [ValidateNotNullOrEmpty]
        [Alias("Fabric")]
        public ASRFabric InputObject { get; set; }

        /// <summary>
        ///     Gets or sets switch parameter. On passing, command does not ask for confirmation.
        /// </summary>
        [Parameter(ParameterSetName = ASRParameterSets.Default)]
        public SwitchParameter Force { get; set; }

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
                PSSiteRecoveryLongRunningOperation response;

                if (!this.Force.IsPresent)
                {
                    response =
                        this.RecoveryServicesClient.DeleteAzureSiteRecoveryFabric(
                            this.InputObject.Name);
                }
                else
                {
                    response =
                        this.RecoveryServicesClient.PurgeAzureSiteRecoveryFabric(
                            this.InputObject.Name);
                }

                var jobResponse = this.RecoveryServicesClient.GetAzureSiteRecoveryJobDetails(
                    PSRecoveryServicesClient.GetJobIdFromReponseLocation(response.Location));

                this.WriteObject(new ASRJob(jobResponse));
            }
        }
    }
}