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
using System.Collections.Generic;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.SiteRecovery
{
    /// <summary>
    /// Retrieves Azure Site Recovery Server.
    /// </summary>
    [Cmdlet(VerbsCommon.Remove, "AzureRmSiteRecoveryServer", SupportsShouldProcess = true,
        DefaultParameterSetName = ASRParameterSets.Default)]
    [OutputType(typeof(IEnumerable<ASRServer>))]
    [Obsolete("This cmdlet has been marked for deprecation in an upcoming release. Please use the " +
        "Remove-AzureRmRecoveryServicesAsrServicesProvider / Remove-AzureRmRecoveryServicesAsrFabric cmdlet from the "
        + "AzureRm.RecoveryServices.SiteRecovery module instead.",
        false)]
    public class RemoveAzureSiteRecoveryServer : SiteRecoveryCmdletBase
    {
        #region Parameters

        /// <summary>
        /// Gets or sets the Server.
        /// </summary>
        [Parameter(Mandatory = true, ValueFromPipeline = true)]
        [ValidateNotNullOrEmpty]
        public ASRServer Server { get; set; }

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
            if (ShouldProcess(this.Server.FriendlyName, VerbsCommon.Remove))
            {
                base.ExecuteSiteRecoveryCmdlet();

                this.WriteWarningWithTimestamp(
                    string.Format(Properties.Resources.CmdletWillBeDeprecatedSoon,
                        this.MyInvocation.MyCommand.Name,
                        "Remove-AzureRmSiteRecoveryServicesProvider"));

                RemoveServer();
            }
        }

        /// <summary>
        /// Remove Server
        /// </summary>
        private void RemoveServer()
        {
            if ((String.Compare(this.Server.FabricType, Constants.VMM) != 0 && String.Compare(this.Server.FabricType, Constants.HyperVSite) != 0))
            {
                throw new PSInvalidOperationException(Properties.Resources.InvalidServerType);
            }

            LongRunningOperationResponse response;

            if (!this.Force.IsPresent)
            {
                response =
                        RecoveryServicesClient.RemoveAzureSiteRecoveryProvider(Utilities.GetValueFromArmId(this.Server.ID, ARMResourceTypeConstants.ReplicationFabrics), this.Server.Name);
            }
            else
            {
                response =
                        RecoveryServicesClient.PurgeAzureSiteRecoveryProvider(Utilities.GetValueFromArmId(this.Server.ID, ARMResourceTypeConstants.ReplicationFabrics), this.Server.Name);
            }

            JobResponse jobResponse =
                RecoveryServicesClient
                .GetAzureSiteRecoveryJobDetails(PSRecoveryServicesClient.GetJobIdFromReponseLocation(response.Location));

            WriteObject(new ASRJob(jobResponse.Job));
        }
    }
}