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

using Microsoft.Azure.Commands.FrontDoor.Common;
using Microsoft.Azure.Commands.FrontDoor.Models;
using System.Linq;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.FrontDoor.Cmdlets
{
    /// <summary>
    /// Defines the New-AzFrontDoorBackendPoolObject cmdlet.
    /// </summary>
    [Cmdlet("New", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "FrontDoorBackendPoolObject"), OutputType(typeof(PSBackendPool))]
    public class NewFrontDoorBackendPoolObject : AzureFrontDoorCmdletBase
    {
        /// <summary>
        /// The resource group name that the RoutingRule will be created in.
        /// </summary>
        [Parameter(Mandatory = true, HelpMessage = "The resource group name that the RoutingRule will be created in.")]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        /// <summary>
        /// Gets or sets the RoutingRule name.
        /// </summary>
        [Parameter(Mandatory = true, HelpMessage = "BackendPool name.")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        /// <summary>
        /// Front Door name.
        /// </summary>
        [Parameter(Mandatory = true, HelpMessage = "The name of the Front Door to which this routing rule belongs.")]
        [ValidateNotNullOrEmpty]
        public string FrontDoorName { get; set; }

        /// <summary>
        /// The set of backends for this pool.
        /// </summary>
        [Parameter(Mandatory = true, HelpMessage = "The set of backends for this pool.")]
        [ValidateNotNullOrEmpty]
        public PSBackend[] Backend { get; set; }

        /// <summary>
        /// The name of the load balancing settings for this backend pool
        /// </summary>
        [Parameter(Mandatory = true, HelpMessage = "The name of the load balancing settings for this backend pool")]
        [ValidateNotNullOrEmpty]
        public string LoadBalancingSettingsName { get; set; }

        /// <summary>
        /// The name of the health probe settings for this backend pool
        /// </summary>
        [Parameter(Mandatory = true, HelpMessage = "The name of the health probe settings for this backend pool")]
        [ValidateNotNullOrEmpty]
        public string HealthProbeSettingsName { get; set; }

        public override void ExecuteCmdlet()
        {
            string subid = DefaultContext.Subscription.Id;
            string LoadBalancingSettingsId = string.Format("/subscriptions/{0}/resourceGroups/{1}/providers/Microsoft.Network/frontDoors/{2}/LoadBalancingSettings/{3}",
                  subid, ResourceGroupName, FrontDoorName, LoadBalancingSettingsName);
            string HealthProbeSettingsId = string.Format("/subscriptions/{0}/resourceGroups/{1}/providers/Microsoft.Network/frontDoors/{2}/HealthProbeSettings/{3}",
                  subid, ResourceGroupName, FrontDoorName, HealthProbeSettingsName);
            var backendPool = new PSBackendPool
            {
                Name = Name,
                Backends = Backend.ToList(),
                LoadBalancingSettingRef = LoadBalancingSettingsId,
                HealthProbeSettingRef = HealthProbeSettingsId,
            };
            WriteObject(backendPool);
        }

    }
}
