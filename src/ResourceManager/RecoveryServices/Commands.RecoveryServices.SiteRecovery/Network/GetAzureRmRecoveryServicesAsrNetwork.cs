﻿// ----------------------------------------------------------------------------------
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

using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using Microsoft.Azure.Management.RecoveryServices.SiteRecovery.Models;

namespace Microsoft.Azure.Commands.RecoveryServices.SiteRecovery
{
    /// <summary>
    ///     Retrieves Azure Site Recovery Network.
    /// </summary>
    [Cmdlet("Get", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "RecoveryServicesAsrNetwork",DefaultParameterSetName = ASRParameterSets.ByFabricObject)]
    [Alias("Get-ASRNetwork")]
    [OutputType(typeof(ASRNetwork))]
    public class GetAzureRmRecoveryServicesAsrNetwork : SiteRecoveryCmdletBase
    {
        /// <summary>
        ///     Gets or sets Fabric object.
        /// </summary>
        [Parameter(
            ParameterSetName = ASRParameterSets.ByFabricObject,
            Mandatory = true,
            ValueFromPipeline = true)]
        [Parameter(
            ParameterSetName = ASRParameterSets.ByName,
            Mandatory = true,
            ValueFromPipeline = true)]
        [Parameter(
            ParameterSetName = ASRParameterSets.ByFriendlyName,
            Mandatory = true,
            ValueFromPipeline = true)]
        [ValidateNotNullOrEmpty]
        public ASRFabric Fabric { get; set; }

        /// <summary>
        ///     Gets or sets Name of the Network.
        /// </summary>
        [Parameter(
            ParameterSetName = ASRParameterSets.ByName,
            Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        /// <summary>
        ///     Gets or sets Friendly Name of the Network.
        /// </summary>
        [Parameter(
            ParameterSetName = ASRParameterSets.ByFriendlyName,
            Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public string FriendlyName { get; set; }

        /// <summary>
        ///     ProcessRecord of the command.
        /// </summary>
        public override void ExecuteSiteRecoveryCmdlet()
        {
            base.ExecuteSiteRecoveryCmdlet();

            switch (this.ParameterSetName)
            {
                case ASRParameterSets.ByFabricObject:
                    this.GetByFabric();
                    break;
                case ASRParameterSets.ByName:
                    this.GetByName();
                    break;
                case ASRParameterSets.ByFriendlyName:
                    this.GetByFriendlyName();
                    break;
            }
        }

        /// <summary>
        ///     Queries all Networks under Fabric
        /// </summary>
        private void GetByFabric()
        {
            var networkListResponse =
                this.RecoveryServicesClient.GetAzureSiteRecoveryNetworks(this.Fabric.Name);

            this.WriteNetworks(networkListResponse);
        }

        /// <summary>
        ///     Queries a particular Network
        /// </summary>
        private void GetByFriendlyName()
        {
            var networkListResponse =
                this.RecoveryServicesClient.GetAzureSiteRecoveryNetworks(this.Fabric.Name);

            foreach (var network in networkListResponse)
            {
                if (0 ==
                    string.Compare(
                        this.FriendlyName,
                        network.Properties.FriendlyName,
                        true))
                {
                    this.WriteNetwork(network);
                }
            }
        }

        /// <summary>
        ///     Queries by Name
        /// </summary>
        private void GetByName()
        {
            var networkResponse = this.RecoveryServicesClient.GetAzureSiteRecoveryNetwork(
                this.Fabric.Name,
                this.Name);

            this.WriteNetwork(networkResponse);
        }

        /// <summary>
        ///     Write Network.
        /// </summary>
        /// <param name="network">Network object</param>
        private void WriteNetwork(
            Network network)
        {
            this.WriteObject(new ASRNetwork(network));
        }

        /// <summary>
        ///     Write Networks.
        /// </summary>
        /// <param name="networks">List of Networks</param>
        private void WriteNetworks(
            IList<Network> networks)
        {
            this.WriteObject(
                networks.Select(n => new ASRNetwork(n)),
                true);
        }
    }
}
