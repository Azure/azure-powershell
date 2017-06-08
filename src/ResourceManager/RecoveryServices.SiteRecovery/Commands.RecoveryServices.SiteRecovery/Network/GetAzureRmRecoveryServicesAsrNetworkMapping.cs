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

using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using Microsoft.Azure.Management.RecoveryServices.SiteRecovery.Models;

namespace Microsoft.Azure.Commands.RecoveryServices.SiteRecovery
{
    /// <summary>
    /// Retrieves Azure Site Recovery Network mappings.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "AzureRmRecoveryServicesAsrNetworkMapping", DefaultParameterSetName = ASRParameterSets.ByObject)]
    [Alias("Get-ASRNetworkMapping")]
    [OutputType(typeof(IEnumerable<ASRNetworkMapping>))]
    public class GetAzureRmRecoveryServicesAsrNetworkMapping : SiteRecoveryCmdletBase
    {
        #region Parameters

        /// <summary>
        /// Gets or sets Azure VM Network Id.
        /// </summary>
        [Parameter(ParameterSetName = ASRParameterSets.ByObjectWithName, Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets Primary Network object.
        /// </summary>
        [Parameter(ParameterSetName = ASRParameterSets.ByObjectWithName, Mandatory = true, ValueFromPipeline = true)]
        [Parameter(ParameterSetName = ASRParameterSets.ByObject, Mandatory = true, ValueFromPipeline = true)]
        [ValidateNotNullOrEmpty]
        public ASRNetwork Network { get; set; }

        #endregion Parameters

        /// <summary>
        /// ProcessRecord of the command.
        /// </summary>
        public override void ExecuteSiteRecoveryCmdlet()
        {
            base.ExecuteSiteRecoveryCmdlet();

            switch (this.ParameterSetName)
            {
                case ASRParameterSets.ByObjectWithName:
                    this.ByObjectWithName();
                    break;
                case ASRParameterSets.ByObject:
                    this.ByObject();
                    break;
            }
        }

        /// <summary>
        /// Get network mapping by name.
        /// </summary>
        private void ByObjectWithName()
        {
            var networkMapping = RecoveryServicesClient.GetAzureSiteRecoveryNetworkMappings(
               Utilities.GetValueFromArmId(this.Network.ID, ARMResourceTypeConstants.ReplicationFabrics),
               this.Network.Name,
               this.Name);

            WriteNetworkMapping(networkMapping);
        }

        /// <summary>
        /// Get network mapping by network object.
        /// </summary>
        private void ByObject()
        {
            var networkMappingList = RecoveryServicesClient.GetAzureSiteRecoveryNetworkMappings(
               Utilities.GetValueFromArmId(this.Network.ID, ARMResourceTypeConstants.ReplicationFabrics),
               this.Network.Name);

            WriteNetworkMappings(networkMappingList);
        }

        /// <summary>
        /// Write Network mappings.
        /// </summary>
        /// <param name="networkMappings">List of Network mappings</param>
        private void WriteNetworkMappings(IList<NetworkMapping> networkMappings)
        {
            this.WriteObject(networkMappings.Select(nm => new ASRNetworkMapping(nm)), true);
        }

        /// <summary>
        /// Write Network mapping.
        /// </summary>
        /// <param name="networkMapping">Network mapping</param>
        private void WriteNetworkMapping(NetworkMapping networkMapping)
        {
            this.WriteObject(new ASRNetworkMapping(networkMapping));
        }
    }
}
