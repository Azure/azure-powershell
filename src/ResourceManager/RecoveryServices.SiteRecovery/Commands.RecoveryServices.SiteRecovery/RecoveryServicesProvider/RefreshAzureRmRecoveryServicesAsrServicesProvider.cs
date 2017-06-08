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
    /// Retrieves Azure Site Recovery Services Provider.
    /// </summary>
    [Cmdlet(VerbsData.Update, "AzureRmRecoveryServicesAsrServicesProvider", DefaultParameterSetName = ASRParameterSets.Default)]
    [Alias("Update-ASRServicesProvider")]
    [OutputType(typeof(ASRJob))]
    public class UpdateAzureRmRecoveryServicesAsrServicesProvider : SiteRecoveryCmdletBase
    {
        #region Parameters

        /// <summary>
        /// Gets or sets the Recovery Services Provider.
        /// </summary>
        [Parameter(ParameterSetName = ASRParameterSets.Default, Mandatory = true, ValueFromPipeline = true)]
        [ValidateNotNullOrEmpty]
        public ASRRecoveryServicesProvider ServicesProvider { get; set; }

        #endregion Parameters

        /// <summary>
        /// ProcessRecord of the command.
        /// </summary>
        public override void ExecuteSiteRecoveryCmdlet()
        {
            base.ExecuteSiteRecoveryCmdlet();
            RefreshServicesProvider();
        }

        /// <summary>
        /// Refresh Server
        /// </summary>
        private void RefreshServicesProvider()
        {
            PSSiteRecoveryLongRunningOperation response =
                RecoveryServicesClient.RefreshAzureSiteRecoveryProvider(Utilities.GetValueFromArmId(this.ServicesProvider.ID, ARMResourceTypeConstants.ReplicationFabrics), this.ServicesProvider.Name);

            var jobResponse =
                RecoveryServicesClient
                .GetAzureSiteRecoveryJobDetails(PSRecoveryServicesClient.GetJobIdFromReponseLocation(response.Location));

            WriteObject(new ASRJob(jobResponse));
        }
    }
}
