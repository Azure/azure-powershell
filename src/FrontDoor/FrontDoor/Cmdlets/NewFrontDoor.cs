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
using Microsoft.Azure.Commands.FrontDoor.Helpers;
using Microsoft.Azure.Commands.FrontDoor.Models;
using Microsoft.Azure.Commands.FrontDoor.Properties;
using Microsoft.Azure.Management.FrontDoor;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using System.Collections;
using System.Linq;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.FrontDoor.Cmdlets
{
    /// <summary>
    /// Defines the New-AzFrontDoor cmdlet.
    /// </summary>
    [CmdletOutputBreakingChangeAttribute(typeof(PSFrontDoor), "15.0.0", "6.0.0", ReplacementCmdletOutputTypeName = "Microsoft.Azure.PowerShell.Cmdlets.FrontDoor.Models.IFrontDoor", ChangeDescription = "no longer has output type 'Microsoft.Azure.Commands.FrontDoor.Models.PSFrontend'.")]
    [Cmdlet("New", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "FrontDoor", DefaultParameterSetName = FieldsWithBackendPoolsSettingParameterSet, SupportsShouldProcess = true), OutputType(typeof(PSFrontDoor))]
    public class NewFrontDoor : AzureFrontDoorCmdletBase
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
        [CmdletParameterBreakingChangeWithVersion("RoutingRule", "15.0.0", "6.0.0", OldParameterType = typeof(PSRoutingRule), NewParameterTypeName = "Microsoft.Azure.PowerShell.Cmdlets.FrontDoor.Models.IRoutingRule[]", ChangeDescription = "The element type for parameter 'RoutingRule' has been changed from 'Microsoft.Azure.Commands.FrontDoor.Models.PSRoutingRule' to 'Microsoft.Azure.PowerShell.Cmdlets.FrontDoor.Models.IRoutingRule'.")]
        [Parameter(Mandatory = true, HelpMessage = "Routing rules associated with this Front Door")]
        public PSRoutingRule[] RoutingRule { get; set; }

        /// <summary>
        /// Backendpools available to routing rule.
        /// </summary>
        [CmdletParameterBreakingChangeWithVersion("BackendPool", "15.0.0", "6.0.0", OldParameterType = typeof(PSBackendPool), NewParameterTypeName = "Microsoft.Azure.PowerShell.Cmdlets.FrontDoor.Models.IBackendPool[]", ChangeDescription = "The element type for parameter 'BackendPool' has been changed from 'Microsoft.Azure.Commands.FrontDoor.Models.PSBackendPool' to 'Microsoft.Azure.PowerShell.Cmdlets.FrontDoor.Models.IBackendPool'.")]
        [Parameter(Mandatory = true, HelpMessage = "Backendpools available to routing rule.")]
        public PSBackendPool[] BackendPool { get; set; }

        /// <summary>
        /// Frontend endpoints available to routing rule.
        /// </summary>
        [CmdletParameterBreakingChangeWithVersion("FrontendEndpoint", "15.0.0", "6.0.0", OldParameterType = typeof(PSFrontendEndpoint), NewParameterTypeName = "Microsoft.Azure.PowerShell.Cmdlets.FrontDoor.Models.IFrontendEndpoint[]", ChangeDescription = "The element type for parameter 'FrontendEndpoint' has been changed from 'Microsoft.Azure.Commands.FrontDoor.Models.PSFrontendEndpoint' to 'Microsoft.Azure.PowerShell.Cmdlets.FrontDoor.Models.IFrontendEndpoint'.")]
        [Parameter(Mandatory = true, HelpMessage = "Frontend endpoints available to routing rule.")]
        public PSFrontendEndpoint[] FrontendEndpoint { get; set; }

        /// <summary>
        /// Load balancing settings associated with this Front Door instance.
        /// </summary>
        [CmdletParameterBreakingChangeWithVersion("LoadBalancingSetting", "15.0.0", "6.0.0", OldParameterType = typeof(PSLoadBalancingSetting), NewParameterTypeName = "Microsoft.Azure.PowerShell.Cmdlets.FrontDoor.Models.ILoadBalancingSettingsModel[]", ChangeDescription = "The element type for parameter 'LoadBalancingSetting' has been changed from 'Microsoft.Azure.Commands.FrontDoor.Models.PSLoadBalancingSetting' to 'Microsoft.Azure.PowerShell.Cmdlets.FrontDoor.Models.ILoadBalancingSettingsModel'.")]
        [Parameter(Mandatory = true, HelpMessage = "Load balancing settings associated with this Front Door instance.")]
        public PSLoadBalancingSetting[] LoadBalancingSetting { get; set; }

        /// <summary>
        /// Health probe settings associated with this Front Door instance.
        /// </summary>
        [CmdletParameterBreakingChangeWithVersion("HealthProbeSetting", "15.0.0", "6.0.0", OldParameterType = typeof(PSHealthProbeSetting), NewParameterTypeName = "Microsoft.Azure.PowerShell.Cmdlets.FrontDoor.Models.IHealthProbeSettingsModel[]", ChangeDescription = "The element type for parameter 'HealthProbeSetting' has been changed from 'Microsoft.Azure.Commands.FrontDoor.Models.PSHealthProbeSetting' to 'Microsoft.Azure.PowerShell.Cmdlets.FrontDoor.Models.IHealthProbeSettingsModel'.")]
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
        [CmdletParameterBreakingChangeWithVersion("EnabledState", "15.0.0", "6.0.0", OldParameterType = typeof(PSEnabledState), NewParameterTypeName = "System.String", ChangeDescription = "no longer supports the type 'Microsoft.Azure.Commands.FrontDoor.Models.PSEnabledState' for parameter 'EnabledState'.")]
        [Parameter(Mandatory = false, HelpMessage = "Enabled state of the Front Door load balancer. Default value is Enabled")]
        public PSEnabledState EnabledState { get; set; }

        /// <summary>
        /// Whether to enforce certificate name check on HTTPS requests to all backend pools. No effect on non-HTTPS requests.
        /// </summary>
        [Parameter(ParameterSetName = FieldsWithCertificateNameCheckParameterSet,
            Mandatory = false, HelpMessage = "Whether to disable certificate name check on HTTPS requests to all backend pools. No effect on non-HTTPS requests.")]
        public SwitchParameter DisableCertificateNameCheck { get; set; }

        /// <summary>
        /// Settings for all backendPools
        /// </summary>
        [CmdletParameterBreakingChangeWithVersion("BackendPoolsSetting", "15.0.0", "6.0.0", OldParameterType = typeof(PSBackendPoolsSetting), NewParameterTypeName = "Microsoft.Azure.PowerShell.Cmdlets.FrontDoor.Models.IBackendPoolsSettings", ChangeDescription = "no longer supports the type 'Microsoft.Azure.Commands.FrontDoor.Models.PSBackendPoolsSetting' for parameter 'BackendPoolsSetting'.")]
        [Parameter(ParameterSetName = FieldsWithBackendPoolsSettingParameterSet,
            Mandatory = false, HelpMessage = "Settings for all backendPools")]
        public PSBackendPoolsSetting BackendPoolsSetting { get; set; }

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

            Management.FrontDoor.Models.BackendPoolsSettings backendPoolsSettings;
            switch (ParameterSetName)
            {
                case FieldsWithCertificateNameCheckParameterSet:
                    {
                        backendPoolsSettings = new Management.FrontDoor.Models.BackendPoolsSettings(
                                DisableCertificateNameCheck ? PSEnforceCertificateNameCheck.Disabled.ToString() : PSEnforceCertificateNameCheck.Enabled.ToString());
                        break;
                    }
                default:
                    {
                        backendPoolsSettings = BackendPoolsSetting?.ToSdkBackendPoolsSettings();
                        break;
                    }
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
                    enabledState: !this.IsParameterBound(c => c.EnabledState) ? "Enabled" : EnabledState.ToString(),
                    backendPoolsSettings: backendPoolsSettings
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
