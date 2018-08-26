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

using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Commands.TrafficManager.Models;
using Microsoft.Azure.Commands.TrafficManager.Utilities;
using System.Management.Automation;
using ProjectResources = Microsoft.Azure.Commands.TrafficManager.Properties.Resources;

namespace Microsoft.Azure.Commands.TrafficManager
{
    [Cmdlet("Remove", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "TrafficManagerEndpoint", SupportsShouldProcess = true),OutputType(typeof(bool))]
    public class RemoveAzureTrafficManagerEndpoint : TrafficManagerBaseCmdlet
    {
        [Parameter(Mandatory = true, HelpMessage = "The name of the endpoint.", ParameterSetName = "Fields")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(Mandatory = true, HelpMessage = "The type of the endpoint.", ParameterSetName = "Fields")]
        [ValidateSet(Constants.AzureEndpoint, Constants.ExternalEndpoint, Constants.NestedEndpoint, IgnoreCase = true)]
        [ValidateNotNullOrEmpty]
        public string Type { get; set; }

        [Parameter(Mandatory = true, HelpMessage = "The name of the profile.", ParameterSetName = "Fields")]
        [ValidateNotNullOrEmpty]
        public string ProfileName { get; set; }

        [Parameter(Mandatory = true, HelpMessage = "The resource group to which the profile belongs.", ParameterSetName = "Fields")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(Mandatory = true, ValueFromPipeline = true, HelpMessage = "The endpoint.", ParameterSetName = "Object")]
        [ValidateNotNullOrEmpty]
        public TrafficManagerEndpoint TrafficManagerEndpoint { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Do not ask for confirmation.")]
        public SwitchParameter Force { get; set; }

        public override void ExecuteCmdlet()
        {
            var deleted = false;
            TrafficManagerEndpoint trafficManagerEndpointToDelete = null;

            if (this.ParameterSetName == "Fields")
            {
                trafficManagerEndpointToDelete = new TrafficManagerEndpoint
                {
                    Name = this.Name,
                    ProfileName = this.ProfileName,
                    ResourceGroupName = this.ResourceGroupName,
                    Type = this.Type
                };
            }
            else if (this.ParameterSetName == "Object")
            {
                trafficManagerEndpointToDelete = this.TrafficManagerEndpoint;
            }

            this.ConfirmAction(
                this.Force.IsPresent,
                string.Format(ProjectResources.Confirm_RemoveEndpoint, trafficManagerEndpointToDelete.Name, trafficManagerEndpointToDelete.ProfileName, trafficManagerEndpointToDelete.ResourceGroupName),
                ProjectResources.Progress_RemovingEndpoint,
                this.Name,
                () =>
                {
                    deleted = this.TrafficManagerClient.DeleteTrafficManagerEndpoint(trafficManagerEndpointToDelete);
                    if (deleted)
                    {
                        this.WriteVerbose(ProjectResources.Success);
                        this.WriteVerbose(string.Format(ProjectResources.Success_RemoveEndpoint, trafficManagerEndpointToDelete.Name, trafficManagerEndpointToDelete.ProfileName, trafficManagerEndpointToDelete.ResourceGroupName));
                    }

                    this.WriteObject(deleted);
                });
        }
    }
}
