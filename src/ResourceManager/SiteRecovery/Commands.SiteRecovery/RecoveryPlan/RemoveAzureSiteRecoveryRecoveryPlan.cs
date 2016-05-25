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
using System;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.SiteRecovery
{
    /// <summary>
    /// Remove Azure Site Recovery Recovery Plan.
    /// </summary>
    [Cmdlet(VerbsCommon.Remove, "AzureRmSiteRecoveryRecoveryPlan", DefaultParameterSetName = ASRParameterSets.ByObject)]
    public class RemoveAzureSiteRecoveryRecoveryPlan : SiteRecoveryCmdletBase
    {
        #region Parameters

        /// <summary>
        /// Gets or sets Name of the Recovery Plan.
        /// </summary>
        [Parameter(Mandatory = true, ParameterSetName = ASRParameterSets.ByName)]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets Name of the Recovery Plan.
        /// </summary>
        [Parameter(Mandatory = true, ParameterSetName = ASRParameterSets.ByObject, ValueFromPipeline = true)]
        public ASRRecoveryPlan RecoveryPlan { get; set; }

        #endregion Parameters

        /// <summary>
        /// ProcessRecord of the command.
        /// </summary>
        public override void ExecuteSiteRecoveryCmdlet()
        {
            base.ExecuteSiteRecoveryCmdlet();

            if (string.Compare(this.ParameterSetName, ASRParameterSets.ByObject, StringComparison.OrdinalIgnoreCase) == 0)
            {
                this.Name = this.RecoveryPlan.Name;
            }

            LongRunningOperationResponse response = RecoveryServicesClient.RemoveAzureSiteRecoveryRecoveryPlan(this.Name);

            JobResponse jobResponse =
                RecoveryServicesClient
                .GetAzureSiteRecoveryJobDetails(PSRecoveryServicesClient.GetJobIdFromReponseLocation(response.Location));

            WriteObject(new ASRJob(jobResponse.Job));
        }
    }
}
