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
using Microsoft.Azure.Commands.RecoveryServices.SiteRecovery;
using Microsoft.WindowsAzure.Management.SiteRecovery.Models;

namespace Microsoft.Azure.Commands.RecoveryServices
{
    /// <summary>
    /// Retrieves Azure Site Recovery Network mappings.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "AzureSiteRecoveryNetworkMapping")]
    [OutputType(typeof(IEnumerable<ASRNetworkMapping>))]
    public class GetAzureSiteRecoveryNetworkMapping : RecoveryServicesCmdletBase
    {
        #region Parameters
        /// <summary>
        /// Gets or sets Primary Server object.
        /// </summary>
        [Parameter(ParameterSetName = ASRParameterSets.EnterpriseToEnterprise, Mandatory = true)]
        [Parameter(ParameterSetName = ASRParameterSets.EnterpriseToAzure, Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public ASRServer PrimaryServer { get; set; }

        /// <summary>
        /// Gets or sets Recovery Server object.
        /// </summary>
        [Parameter(ParameterSetName = ASRParameterSets.EnterpriseToEnterprise, Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public ASRServer RecoveryServer { get; set; }

        /// <summary>
        /// Gets or sets switch parameter. On passing, command sets target as Azure.
        /// </summary>
        [Parameter(ParameterSetName = ASRParameterSets.EnterpriseToAzure, Mandatory = true)]
        public SwitchParameter Azure { get; set; }
        #endregion Parameters

        /// <summary>
        /// ProcessRecord of the command.
        /// </summary>
        public override void ExecuteCmdlet()
        {
            try
            {
                this.WriteWarningWithTimestamp(
                    string.Format(
                        Properties.Resources.CmdletWillBeDeprecatedSoon,
                        this.MyInvocation.MyCommand.Name));

                string primaryServerId = this.PrimaryServer.ID;
                string recoveryServerId = string.Empty;

                switch (this.ParameterSetName)
                {
                    case ASRParameterSets.EnterpriseToEnterprise:
                        recoveryServerId = this.RecoveryServer.ID;
                        break;
                    case ASRParameterSets.EnterpriseToAzure:
                        recoveryServerId = Constants.AzureFabricId;
                        break;
                }

                NetworkMappingListResponse networkMappingListResponse =
                    RecoveryServicesClient
                    .GetAzureSiteRecoveryNetworkMappings(primaryServerId, recoveryServerId);

                this.WriteNetworkMappings(networkMappingListResponse.NetworkMappings);
            }
            catch (Exception exception)
            {
                this.HandleException(exception);
            }
        }

        /// <summary>
        /// Write Network mappings.
        /// </summary>
        /// <param name="networkMappings">List of Network mappings</param>
        private void WriteNetworkMappings(IList<NetworkMapping> networkMappings)
        {
            this.WriteObject(networkMappings.Select(nm => new ASRNetworkMapping(nm)), true);
        }
    }
}