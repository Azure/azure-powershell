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
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using Microsoft.Azure.Management.SiteRecovery.Models;
using Properties = Microsoft.Azure.Commands.SiteRecovery.Properties;

namespace Microsoft.Azure.Commands.SiteRecovery
{
    /// <summary>
    /// Retrieves Azure Site Recovery Services Provider.
    /// </summary>
    [Cmdlet(VerbsCommon.Remove, "AzureRmSiteRecoveryServicesProvider", DefaultParameterSetName = ASRParameterSets.Default, SupportsShouldProcess = true)]
    [OutputType(typeof(IEnumerable<ASRJob>))]
    [Obsolete("This cmdlet has been marked for deprecation in an upcoming release. Please use the " +
        "Remove-AzureRmRecoveryServicesAsrServicesProvider cmdlet from the AzureRm.RecoveryServices.SiteRecovery module instead.",
        false)]
    public class RemoveAzureRmSiteRecoveryServicesProvider : SiteRecoveryCmdletBase
    {
        #region Parameters

        /// <summary>
        /// Gets or sets the Recovery Services Provider.
        /// </summary>
        [Parameter(ParameterSetName = ASRParameterSets.Default, Mandatory = true, ValueFromPipeline = true)]
        [ValidateNotNullOrEmpty]
        public ASRRecoveryServicesProvider ServicesProvider { get; set; }

        /// <summary>
        /// Gets or sets switch parameter. On passing, command does not ask for confirmation.
        /// </summary>
        [Parameter]
        public SwitchParameter Force { get; set; }

        #endregion Parameters

        /// <summary>
        /// ProcessRecord of the command.
        /// </summary>
        public override void ExecuteSiteRecoveryCmdlet()
        {
            base.ExecuteSiteRecoveryCmdlet();

            if (ShouldProcess(this.ServicesProvider.FriendlyName, VerbsCommon.Remove))
            {
                RemoveServiceProvider();
            }
        }

        /// <summary>
        /// Remove Server
        /// </summary>
        private void RemoveServiceProvider()
        {
            LongRunningOperationResponse response;

            if (!this.Force.IsPresent)
            {
                response =
                        RecoveryServicesClient.RemoveAzureSiteRecoveryProvider(
                        Utilities.GetValueFromArmId(this.ServicesProvider.ID, ARMResourceTypeConstants.ReplicationFabrics), this.ServicesProvider.Name);
            }
            else
            {
                response =
                        RecoveryServicesClient.PurgeAzureSiteRecoveryProvider(
                        Utilities.GetValueFromArmId(this.ServicesProvider.ID, ARMResourceTypeConstants.ReplicationFabrics), this.ServicesProvider.Name);
            }

            JobResponse jobResponse =
                RecoveryServicesClient
                .GetAzureSiteRecoveryJobDetails(PSRecoveryServicesClient.GetJobIdFromReponseLocation(response.Location));

            WriteObject(new ASRJob(jobResponse.Job));
        }
    }
}