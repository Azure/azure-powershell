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

using Microsoft.Azure.Commands.TrafficManager.Models;
using Microsoft.Azure.Commands.TrafficManager.Utilities;
using System.Management.Automation;
using ProjectResources = Microsoft.Azure.Commands.TrafficManager.Properties.Resources;

namespace Microsoft.Azure.Commands.TrafficManager
{
    [Cmdlet(VerbsLifecycle.Disable, "AzureRmTrafficManagerEndpoint", SupportsShouldProcess = true), 
        OutputType(typeof(bool))]
    public class DisableAzureTrafficManagerEndpoint : TrafficManagerBaseCmdlet
    {
        [Parameter(Mandatory = true, HelpMessage = "The name of the endpoint.", ParameterSetName = "Fields")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(Mandatory = true, HelpMessage = "The type of the endpoint.", ParameterSetName = "Fields")]
        [ValidateSet(Constants.AzureEndpoint, Constants.ExternalEndpoint, Constants.NestedEndpoint, IgnoreCase = false)]
        [ValidateNotNullOrEmpty]
        public string Type { get; set; }

        [Parameter(Mandatory = true, HelpMessage = "The name of the endpoint.", ParameterSetName = "Fields")]
        [ValidateNotNullOrEmpty]
        public string ProfileName { get; set; }

        [Parameter(Mandatory = true, HelpMessage = "The resource group to which the profile belongs.", ParameterSetName = "Fields")]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(Mandatory = true, ValueFromPipeline = true, HelpMessage = "The endpoint.", ParameterSetName = "Object")]
        [ValidateNotNullOrEmpty]
        public TrafficManagerEndpoint TrafficManagerEndpoint { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Do not ask for confirmation.")]
        public SwitchParameter Force { get; set; }

        public override void ExecuteCmdlet()
        {
            var disabled = false;
            TrafficManagerEndpoint endpointToDisable = null;

            if (this.ParameterSetName == "Fields")
            {
                endpointToDisable = new TrafficManagerEndpoint
                {
                    Name = this.Name,
                    Type = this.Type,
                    ProfileName = this.ProfileName,
                    ResourceGroupName = this.ResourceGroupName
                };
            }
            else if (this.ParameterSetName == "Object")
            {
                endpointToDisable = this.TrafficManagerEndpoint;
            }

            this.ConfirmAction(
                this.Force.IsPresent,
                string.Format(ProjectResources.Confirm_DisableEndpoint, endpointToDisable.Name, endpointToDisable.ProfileName),
                ProjectResources.Progress_DisablingEndpoint,
                this.Name,
                () =>
                {
                    disabled = this.TrafficManagerClient.EnableDisableTrafficManagerEndpoint(endpointToDisable, shouldEnableEndpointStatus: false);
                    if (disabled)
                    {
                        this.WriteVerbose(ProjectResources.Success);
                        this.WriteVerbose(string.Format(ProjectResources.Success_DisableEndpoint, endpointToDisable.Name, endpointToDisable.Name, endpointToDisable.ResourceGroupName));
                    }

                    this.WriteObject(disabled);
                });
        }
    }
}
