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
using Microsoft.Azure.Management.FrontDoor;
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using System.Linq;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Commands.ResourceManager;
using SdkFrontDoor = Microsoft.Azure.Management.FrontDoor.Models.FrontDoorModel;

namespace Microsoft.Azure.Commands.FrontDoor.Cmdlets
{
    /// <summary>
    /// Defines the Set-AzFrontDoor cmdlet.
    /// </summary>
    [Cmdlet("Set", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "FrontDoor", SupportsShouldProcess = true, DefaultParameterSetName = FieldsParameterSet), OutputType(typeof(PSFrontDoor))]
    public class SetAzureRmFrontDoor : AzureFrontDoorCmdletBase
    {
        /// <summary>
        /// The resource group to which the Front Door belongs.
        /// </summary>
        [Parameter(Mandatory = true, ParameterSetName = FieldsParameterSet, HelpMessage = "The resource group to which the Front Door belongs.")]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }  

        /// <summary>
        /// The name of the Front Door to update.
        /// </summary>
        [Parameter(Mandatory = true, ParameterSetName = FieldsParameterSet, HelpMessage = "The name of the Front Door to update.")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        /// <summary>
        ///The Front Door object to update.
        /// </summary>
        [Parameter(Mandatory = true, ParameterSetName = ObjectParameterSet, ValueFromPipeline = true, HelpMessage = "The Front Door object to update.")]
        [ValidateNotNullOrEmpty]
        public PSFrontDoor InputObject { get; set; }

        /// <summary>
        /// Resource Id of the Front Door to update
        /// </summary>
        [Parameter(Mandatory = true, ParameterSetName = ResourceIdParameterSet, ValueFromPipelineByPropertyName = true, HelpMessage = "Resource Id of the Front Door to update")]
        [ValidateNotNullOrEmpty]
        public string ResourceId { get; set; }
        
        /// <summary>
        /// Routing rules associated with this Front Door
        /// </summary>
        [Parameter(Mandatory = false, HelpMessage = "Routing rules associated with this Front Door")]
        public PSRoutingRule[] RoutingRule { get; set; }

        /// <summary>
        /// Backendpools available to routing rule.
        /// </summary>
        [Parameter(Mandatory = false, HelpMessage = "Backendpools available to routing rule.")]
        public PSBackendPool[] BackendPool { get; set; }

        /// <summary>
        /// Frontend endpoints available to routing rule.
        /// </summary>
        [Parameter(Mandatory = false, HelpMessage = "Frontend endpoints available to routing rule.")]
        public PSFrontendEndpoint[] FrontendEndpoint { get; set; }

        /// <summary>
        /// Load balancing settings associated with this Front Door instance.
        /// </summary>
        [Parameter(Mandatory = false, HelpMessage = "Load balancing settings associated with this Front Door instance.")]
        public PSLoadBalancingSetting[] LoadBalancingSetting { get; set; }

        /// <summary>
        /// Health probe settings associated with this Front Door instance.
        /// </summary>
        [Parameter(Mandatory = false, HelpMessage = "Health probe settings associated with this Front Door instance.")]
        public PSHealthProbeSetting[] HealthProbeSetting { get; set; }

        /// <summary>
        /// The tags to associate with the Front Door.
        /// </summary>
        [Parameter(Mandatory = false, HelpMessage = "The tags associate with the Front Door.")]
        public Hashtable Tag { get; set; }

        /// <summary>
        /// Whether to enable use of this rule.
        /// </summary>
        [Parameter(Mandatory = false, HelpMessage = "Operational status of the Front Door load balancer. Default value is Enabled")]
        public PSEnabledState EnabledState { get; set; }

        /// <summary>
        /// Whether to enforce certificate name check on HTTPS requests to all backend pools. No effect on non-HTTPS requests.
        /// </summary>
        [Parameter(Mandatory = false, HelpMessage = "Whether to disable certificate name check on HTTPS requests to all backend pools. No effect on non-HTTPS requests.")]
        public SwitchParameter DisableCertificateNameCheck { get; set; }

        public override void ExecuteCmdlet()
        {
            if (ParameterSetName == ObjectParameterSet)
            {
                ResourceIdentifier identifier = new ResourceIdentifier(InputObject.Id);
                ResourceGroupName = identifier.ResourceGroupName;
                Name = InputObject.Name;
            }
            else if (ParameterSetName == ResourceIdParameterSet)
            {
                ResourceIdentifier identifier = new ResourceIdentifier(ResourceId);
                ResourceGroupName = identifier.ResourceGroupName;
                Name = InputObject.Name;
            }


            var existingFrontDoor = FrontDoorManagementClient.FrontDoors.ListByResourceGroup(ResourceGroupName)
                .FirstOrDefault(fd => fd.Name.ToLower() == Name.ToLower());
                

            if (existingFrontDoor == null)
            {
                throw new PSArgumentException(string.Format(
                    Resources.Error_FrontDoorNotFound,
                    Name,
                    ResourceGroupName));
            }

            PSFrontDoor updateParameters;
            if (ParameterSetName == ObjectParameterSet)
            {
                updateParameters = InputObject;
            }
            else
            {
                updateParameters = existingFrontDoor.ToPSFrontDoor();
            }

            // update each field based on optional input.
            if (this.IsParameterBound(c => c.RoutingRule))
            {
                updateParameters.RoutingRules = RoutingRule.ToList();
            }

            if (this.IsParameterBound(c => c.FrontendEndpoint))
            {
                updateParameters.FrontendEndpoints = FrontendEndpoint.ToList();
            }

            if (this.IsParameterBound(c => c.HealthProbeSetting))
            {
                updateParameters.HealthProbeSettings = HealthProbeSetting.ToList();
            }

            if (this.IsParameterBound(c => c.LoadBalancingSetting))
            {
                updateParameters.LoadBalancingSettings = LoadBalancingSetting.ToList();
            }

            if (this.IsParameterBound(c => c.BackendPool))
            {
                updateParameters.BackendPools = BackendPool.ToList();
            }

            if (this.IsParameterBound(c => c.Tag))
            {
                updateParameters.Tags = Tag;
            }

            if (this.IsParameterBound(c => c.EnabledState))
            {
                updateParameters.EnabledState = EnabledState;
            }

            if (this.IsParameterBound(c => c.DisableCertificateNameCheck))
            {
                updateParameters.EnforceCertificateNameCheck = DisableCertificateNameCheck ? PSEnforceCertificateNameCheck.Disabled : PSEnforceCertificateNameCheck.Enabled;
            }

            updateParameters.ValidateFrontDoor(ResourceGroupName, this.DefaultContext.Subscription.Id);
            if (ShouldProcess(Resources.FrontDoorTarget, string.Format(Resources.FrontDoorChangeWarning, Name)))
            {
                try
                {
                    var frontDoor = FrontDoorManagementClient.FrontDoors.CreateOrUpdate(
                                    ResourceGroupName,
                                    Name,
                                    updateParameters.ToSdkFrontDoor()
                                    );
                    WriteObject(frontDoor.ToPSFrontDoor());
                }
                catch (Microsoft.Azure.Management.FrontDoor.Models.ErrorResponseException e)
                {
                    throw new PSArgumentException(string.Format(
                        Resources.Error_ErrorResponseFromServer,
                        e.Response.Content));
                }
            }
        }
    }
    
}
