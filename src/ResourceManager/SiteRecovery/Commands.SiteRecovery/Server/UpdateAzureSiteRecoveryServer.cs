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
    /// Retrieves Azure Site Recovery Server.
    /// </summary>
    [Cmdlet(VerbsData.Update, "AzureRmSiteRecoveryServer", DefaultParameterSetName = ASRParameterSets.Default)]
    public class UpdateAzureRmSiteRecoveryServer : SiteRecoveryCmdletBase
    {
        #region Parameters

        /// <summary>
        /// Gets or sets the Server.
        /// </summary>
        [Parameter(Mandatory = true, ValueFromPipeline = true)]
        [ValidateNotNullOrEmpty]
        public ASRServer Server { get; set; }

        #endregion Parameters

        /// <summary>
        /// ProcessRecord of the command.
        /// </summary>
        public override void ExecuteSiteRecoveryCmdlet()
        {
            base.ExecuteSiteRecoveryCmdlet();
            RefreshServer();
        }

        /// <summary>
        /// Refresh Server
        /// </summary>
        private void RefreshServer()
        {
            if ((String.Compare(this.Server.FabricType, Constants.VMM) != 0 && String.Compare(this.Server.FabricType, Constants.HyperVSite) != 0))
            {
                throw new PSInvalidOperationException(Properties.Resources.InvalidServerType);
            }

            LongRunningOperationResponse response =
                RecoveryServicesClient.RefreshAzureSiteRecoveryProvider(Utilities.GetValueFromArmId(this.Server.ID, ARMResourceTypeConstants.ReplicationFabrics), this.Server.Name);

            JobResponse jobResponse =
                RecoveryServicesClient
                .GetAzureSiteRecoveryJobDetails(PSRecoveryServicesClient.GetJobIdFromReponseLocation(response.Location));

            WriteObject(new ASRJob(jobResponse.Job));
        }
    }
}