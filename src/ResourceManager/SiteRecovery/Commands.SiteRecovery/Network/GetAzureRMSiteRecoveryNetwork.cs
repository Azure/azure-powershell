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
using System.Linq;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.SiteRecovery
{
    /// <summary>
    /// Retrieves Azure Site Recovery Network.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "AzureRmSiteRecoveryNetwork", DefaultParameterSetName = ASRParameterSets.Default)]
    [OutputType(typeof(IEnumerable<ASRNetwork>))]
    [Obsolete("This cmdlet has been marked for deprecation in an upcoming release. Please use the " +
        "Get-AzureRmRecoveryServicesAsrNetwork cmdlet from the AzureRm.RecoveryServices.SiteRecovery module instead.",
        false)]
    public class GetAzureRmSiteRecoveryNetwork : SiteRecoveryCmdletBase
    {
        #region Parameters

        /// <summary>
        /// Gets or sets Server object.
        /// </summary>
        [Parameter(ParameterSetName = ASRParameterSets.ByServerObject, Mandatory = true, ValueFromPipeline = true)]
        [Parameter(ParameterSetName = ASRParameterSets.ByNameLegacy, Mandatory = true, ValueFromPipeline = true)]
        [Parameter(ParameterSetName = ASRParameterSets.ByFriendlyNameLegacy, Mandatory = true, ValueFromPipeline = true)]
        [ValidateNotNullOrEmpty]
        public ASRServer Server { get; set; }

        /// <summary>
        /// Gets or sets Fabric object.
        /// </summary>
        [Parameter(ParameterSetName = ASRParameterSets.ByFabricObject, Mandatory = true, ValueFromPipeline = true)]
        [Parameter(ParameterSetName = ASRParameterSets.ByName, Mandatory = true, ValueFromPipeline = true)]
        [Parameter(ParameterSetName = ASRParameterSets.ByFriendlyName, Mandatory = true, ValueFromPipeline = true)]
        [ValidateNotNullOrEmpty]
        public ASRFabric Fabric { get; set; }

        /// <summary>
        /// Gets or sets Name of the Network.
        /// </summary>
        [Parameter(ParameterSetName = ASRParameterSets.ByName, Mandatory = true)]
        [Parameter(ParameterSetName = ASRParameterSets.ByNameLegacy, Mandatory = true, ValueFromPipeline = true)]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets Friendly Name of the Network.
        /// </summary>
        [Parameter(ParameterSetName = ASRParameterSets.ByFriendlyName, Mandatory = true)]
        [Parameter(ParameterSetName = ASRParameterSets.ByFriendlyNameLegacy, Mandatory = true, ValueFromPipeline = true)]
        [ValidateNotNullOrEmpty]
        public string FriendlyName { get; set; }

        #endregion Parameters

        /// <summary>
        /// ProcessRecord of the command.
        /// </summary>
        public override void ExecuteSiteRecoveryCmdlet()
        {
            base.ExecuteSiteRecoveryCmdlet();

            switch (this.ParameterSetName)
            {
                case ASRParameterSets.ByServerObject:
                    this.WriteWarningWithTimestamp(Properties.Resources.ParameterSetWillBeDeprecatedSoon);
                    this.GetByServer();
                    break;
                case ASRParameterSets.ByNameLegacy:
                    this.WriteWarningWithTimestamp(Properties.Resources.ParameterSetWillBeDeprecatedSoon);
                    this.GetByNameLegacy();
                    break;
                case ASRParameterSets.ByFriendlyNameLegacy:
                    this.WriteWarningWithTimestamp(Properties.Resources.ParameterSetWillBeDeprecatedSoon);
                    this.GetByFriendlyLegacy();
                    break;
                case ASRParameterSets.ByFabricObject:
                    this.GetByFabric();
                    break;
                case ASRParameterSets.ByName:
                    this.GetByName();
                    break;
                case ASRParameterSets.ByFriendlyName:
                    this.GetByFriendlyName();
                    break;
                case ASRParameterSets.Default:
                    this.WriteWarningWithTimestamp(Properties.Resources.ParameterSetWillBeDeprecatedSoon);
                    this.GetAllNetworks();
                    break;
            }
        }

        /// <summary>
        /// Queries all Networks under Server
        /// </summary>
        private void GetByServer()
        {
            NetworksListResponse networkListResponse =
                RecoveryServicesClient.GetAzureSiteRecoveryNetworks(
                Utilities.GetValueFromArmId(this.Server.ID, ARMResourceTypeConstants.ReplicationFabrics));

            this.WriteNetworks(networkListResponse.NetworksList);
        }

        /// <summary>
        /// Queries by Name
        /// </summary>
        private void GetByNameLegacy()
        {
            NetworkResponse networkResponse =
                RecoveryServicesClient.GetAzureSiteRecoveryNetwork(
                Utilities.GetValueFromArmId(this.Server.ID, ARMResourceTypeConstants.ReplicationFabrics),
                this.Name);

            this.WriteNetwork(networkResponse.Network);
        }

        /// <summary>
        /// Queries a particular Network
        /// </summary>
        private void GetByFriendlyLegacy()
        {
            NetworksListResponse networkListResponse =
                RecoveryServicesClient.GetAzureSiteRecoveryNetworks(
                Utilities.GetValueFromArmId(this.Server.ID, ARMResourceTypeConstants.ReplicationFabrics));

            foreach (Network network in networkListResponse.NetworksList)
            {
                if (0 == string.Compare(this.FriendlyName, network.Properties.FriendlyName, true))
                {
                    WriteNetwork(network);
                }
            }
        }

        /// <summary>
        /// Get all Networks
        /// </summary>
        private void GetAllNetworks()
        {
            NetworksListResponse networkListResponse =
                RecoveryServicesClient.GetAzureSiteRecoveryNetworks();

            this.WriteNetworks(networkListResponse.NetworksList);
        }

        /// <summary>
        /// Queries all Networks under Fabric
        /// </summary>
        private void GetByFabric()
        {
            NetworksListResponse networkListResponse =
                RecoveryServicesClient.GetAzureSiteRecoveryNetworks(
                this.Fabric.Name);

            this.WriteNetworks(networkListResponse.NetworksList);
        }

        /// <summary>
        /// Queries by Name
        /// </summary>
        private void GetByName()
        {
            NetworkResponse networkResponse =
                RecoveryServicesClient.GetAzureSiteRecoveryNetwork(
                this.Fabric.Name,
                this.Name);

            this.WriteNetwork(networkResponse.Network);
        }

        /// <summary>
        /// Queries a particular Network
        /// </summary>
        private void GetByFriendlyName()
        {
            NetworksListResponse networkListResponse =
                RecoveryServicesClient.GetAzureSiteRecoveryNetworks(
                this.Fabric.Name);

            foreach (Network network in networkListResponse.NetworksList)
            {
                if (0 == string.Compare(this.FriendlyName, network.Properties.FriendlyName, true))
                {
                    WriteNetwork(network);
                }
            }
        }

        /// <summary>
        /// Write Networks.
        /// </summary>
        /// <param name="networks">List of Networks</param>
        private void WriteNetworks(IList<Network> networks)
        {
            this.WriteObject(networks.Select(n => new ASRNetwork(n)), true);
        }

        /// <summary>
        /// Write Network.
        /// </summary>
        /// <param name="network">Network object</param>
        private void WriteNetwork(Network network)
        {
            this.WriteObject(new ASRNetwork(network));
        }
    }
}