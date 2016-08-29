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

using Microsoft.Azure.Management.SiteRecovery.Models;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.SiteRecovery
{
    /// <summary>
    /// Creates Azure Site Recovery Policy object in memory.
    /// </summary>
    [Cmdlet(VerbsCommon.Remove, "AzureRmSiteRecoverySite", SupportsShouldProcess = true,
        DefaultParameterSetName = ASRParameterSets.Default)]
    public class RemoveAzureSiteRecoverySite : SiteRecoveryCmdletBase
    {
        #region Parameters

        /// <summary>
        /// Gets or sets the site name
        /// </summary>
        [Parameter(Mandatory = true, ValueFromPipeline = true)]
        [ValidateNotNullOrEmpty]
        public ASRSite Site { get; set; }

        /// <summary>
        /// Gets or sets switch parameter. On passing, command does not ask for confirmation.
        /// </summary>
        [Parameter]
        public SwitchParameter Force { get; set; }

        #endregion

        /// <summary>
        /// ProcessRecord of the command.
        /// </summary>
        public override void ExecuteSiteRecoveryCmdlet()
        {
            base.ExecuteSiteRecoveryCmdlet();
            ConfirmAction(VerbsCommon.Remove, Site.FriendlyName,
                () =>
                {
                    RecoveryServicesProviderListResponse recoveryServicesProviderListResponse =
                        RecoveryServicesClient.GetAzureSiteRecoveryProvider(
                            this.Site.Name);

                    if (recoveryServicesProviderListResponse.RecoveryServicesProviders.Count != 0)
                    {
                        throw new PSInvalidOperationException(
                            Properties.Resources.SiteRemovalWithRegisteredHyperVHostsError);
                    }

                    LongRunningOperationResponse response;

                    if (!this.Force.IsPresent)
                    {
                        response =
                            RecoveryServicesClient.DeleteAzureSiteRecoveryFabric(this.Site.Name);
                    }
                    else
                    {
                        response =
                            RecoveryServicesClient.PurgeAzureSiteRecoveryFabric(this.Site.Name);
                    }

                    JobResponse jobResponse =
                        RecoveryServicesClient
                            .GetAzureSiteRecoveryJobDetails(
                                PSRecoveryServicesClient.GetJobIdFromReponseLocation(response.Location));

                    WriteObject(new ASRJob(jobResponse.Job));
                });
        }
    }
}
