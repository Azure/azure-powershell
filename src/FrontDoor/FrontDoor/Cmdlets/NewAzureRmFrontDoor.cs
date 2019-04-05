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
using System.Collections;
using System.Management.Automation;
using System.Net;
using Microsoft.Azure.Commands.FrontDoor.Common;
using Microsoft.Azure.Commands.FrontDoor.Helpers;
using Microsoft.Azure.Commands.FrontDoor.Models;
using Microsoft.Azure.Commands.FrontDoor.Properties;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using Microsoft.Azure.Management.FrontDoor;
using System.Linq;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;

namespace Microsoft.Azure.Commands.FrontDoor.Cmdlets
{
    /// <summary>
    /// Defines the New-AzFrontDoor cmdlet.
    /// </summary>
    [Cmdlet("New", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "FrontDoor", SupportsShouldProcess = true), OutputType(typeof(PSFrontDoor))]
    public class NewAzureRmFrontDoor : AzureFrontDoorCmdletBase
    {
        /// <summary>
        /// The resource group name of the Front Door.
        /// </summary>
        [Parameter(Mandatory = true, HelpMessage = "The resource group name that the Front Door will be created in.")]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        /// <summary>
        /// The Front Door name.
        /// </summary>
        [Parameter(Mandatory = true, HelpMessage = "Front Door name.")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        /// <summary>
        /// Routing rules associated with this Front Door
        /// </summary>
        [Parameter(Mandatory = true, HelpMessage = "Routing rules associated with this Front Door")]
        public PSRoutingRule[] RoutingRule { get; set; }

        /// <summary>
        /// Backendpools available to routing rule.
        /// </summary>
        [Parameter(Mandatory = true, HelpMessage = "Backendpools available to routing rule.")]
        public PSBackendPool[] BackendPool { get; set; }

        /// <summary>
        /// Frontend endpoints available to routing rule.
        /// </summary>
        [Parameter(Mandatory = true, HelpMessage = "Frontend endpoints available to routing rule.")]
        public PSFrontendEndpoint[] FrontendEndpoint { get; set; }

        /// <summary>
        /// Load balancing settings associated with this Front Door instance.
        /// </summary>
        [Parameter(Mandatory = true, HelpMessage = "Load balancing settings associated with this Front Door instance.")]
        public PSLoadBalancingSetting[] LoadBalancingSetting { get; set; }

        /// <summary>
        /// Health probe settings associated with this Front Door instance.
        /// </summary>
        [Parameter(Mandatory = true, HelpMessage = "Health probe settings associated with this Front Door instance.")]
        public PSHealthProbeSetting[] HealthProbeSetting { get; set; }

        /// <summary>
        /// The tags to associate with the Front Door.
        /// </summary>
        [Parameter(Mandatory = false, HelpMessage = "The tags associate with the Front Door.")]
        public Hashtable Tag { get; set; }

        /// <summary>
        /// Enabled state of the Front Door load balancer.
        /// </summary>
        [Parameter(Mandatory = false, HelpMessage = "Enabled state of the Front Door load balancer. Default value is Enabled")]
        public PSEnabledState EnabledState { get; set; }

        /// <summary>
        /// Whether to enforce certificate name check on HTTPS requests to all backend pools. No effect on non-HTTPS requests.
        /// </summary>
        [Parameter(Mandatory = false, HelpMessage = "Whether to disable certificate name check on HTTPS requests to all backend pools. No effect on non-HTTPS requests.")]
        public SwitchParameter DisableCertificateNameCheck { get; set; }

        public override void ExecuteCmdlet()
        {
            var existingProfile = FrontDoorManagementClient.FrontDoors.ListByResourceGroup(ResourceGroupName)
                .Where(p => p.Name.ToLower() == Name.ToLower());

            if (existingProfile.Count() != 0)
            {
                throw new PSArgumentException(string.Format(Resources.Error_CreateExistingFrontDoor, 
                                Name,
                                ResourceGroupName));
            }
            var updateParameters = new Management.FrontDoor.Models.FrontDoorModel(
                    id: null,
                    name: Name,
                    type: null,
                    location: "global",
                    tags: Tag.ToDictionaryTags(),
                    friendlyName: Name,
                    routingRules: RoutingRule?.Select(x => x.ToSdkRoutingRule()).ToList(),
                    loadBalancingSettings: LoadBalancingSetting?.Select(x => x.ToSdkLoadBalancingSetting()).ToList(),
                    healthProbeSettings: HealthProbeSetting?.Select(x => x.ToSdkHealthProbeSetting()).ToList(),
                    backendPools: BackendPool?.Select(x => x.ToSdkBackendPool()).ToList(),
                    frontendEndpoints: FrontendEndpoint?.Select(x => x.ToSdkFrontendEndpoints()).ToList(),
                    enabledState: !this.IsParameterBound(c => c.EnabledState)? "Enabled" : EnabledState.ToString(),
                    backendPoolsSettings : new Management.FrontDoor.Models.BackendPoolsSettings(
                        DisableCertificateNameCheck ? PSEnforceCertificateNameCheck.Disabled.ToString() : PSEnforceCertificateNameCheck.Enabled.ToString())
                    );
            updateParameters.ToPSFrontDoor().ValidateFrontDoor(ResourceGroupName, this.DefaultContext.Subscription.Id);
            if (ShouldProcess(Resources.FrontDoorTarget, string.Format(Resources.CreateFrontDoor, Name)))
            {
                try
                {
                    var frontDoor = FrontDoorManagementClient.FrontDoors.CreateOrUpdate(
                                    ResourceGroupName,
                                    Name,
                                    updateParameters
                                    );
                    WriteObject(frontDoor.ToPSFrontDoor());
                }
                catch (Microsoft.Azure.Management.FrontDoor.Models.ErrorResponseException e)
                {
                    throw new PSArgumentException(string.Format(Resources.Error_ErrorResponseFromServer,
                                         e.Response.Content));
                }
            }
        }
    }
}
