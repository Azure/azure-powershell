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
    using Hyak.Common;
    using System.Net;

    [Cmdlet(VerbsCommon.New, "AzureRmTrafficManagerEndpoint"), OutputType(typeof(TrafficManagerEndpoint))]
    public class NewAzureTrafficManagerEndpoint : TrafficManagerBaseCmdlet
    {
        [Parameter(Mandatory = true, HelpMessage = "The name of the endpoint.")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(Mandatory = true, HelpMessage = "The name of the profile that contains the endpoint.")]
        [ValidateNotNullOrEmpty]
        public string ProfileName { get; set; }

        [Parameter(Mandatory = true, HelpMessage = "The resource group to which the profile belongs.")]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(Mandatory = true, HelpMessage = "The type of the endpoint.")]
        [ValidateSet(Constants.AzureEndpoint, Constants.ExternalEndpoint, Constants.NestedEndpoint, IgnoreCase = false)]
        [ValidateNotNullOrEmpty]
        public string Type { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "The resource id of the endpoint.")]
        [ValidateNotNullOrEmpty]
        public string TargetResourceId { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "The target of the endpoint.")]
        [ValidateNotNullOrEmpty]
        public string Target { get; set; }

        [Parameter(Mandatory = true, HelpMessage = "The status of the endpoint.")]
        [ValidateSet(Constants.StatusEnabled, Constants.StatusDisabled, IgnoreCase = false)]
        [ValidateNotNullOrEmpty]
        public string EndpointStatus { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "The weight of the endpoint.")]
        [ValidateNotNullOrEmpty]
        public uint? Weight { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "The priority of the endpoint.")]
        [ValidateNotNullOrEmpty]
        public uint? Priority { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "The location of the endpoint.")]
        [ValidateNotNullOrEmpty]
        public string EndpointLocation { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "The minimum number of endpoints that must be available in the child profile in order for the Nested Endpoint in the parent profile to be considered available. Only applicable to endpoint of type 'NestedEndpoints'.")]
        [ValidateNotNullOrEmpty]
        public uint? MinChildEndpoints { get; set; }

        public override void ExecuteCmdlet()
        {
            // We are not supporting etags yet, NewAzureTrafficManagerEndpoint should not overwrite any existing endpoint.
            // Since our create operation is implemented using PUT, it will overwrite by default.
            // Therefore, we need to check whether the Profile exists before we actually try to create it.
            try
            {
                this.TrafficManagerClient.GetTrafficManagerEndpoint(this.ResourceGroupName, this.ProfileName, this.Type, this.Name);

                throw new PSArgumentException(string.Format(ProjectResources.Error_CreateExistingEndpoint, this.Name, this.ProfileName, this.ResourceGroupName));
            }
            catch (CloudException exception)
            {
                if (exception.Response.StatusCode.Equals(HttpStatusCode.NotFound))
                {
                    TrafficManagerEndpoint trafficManagerEndpoint = this.TrafficManagerClient.CreateTrafficManagerEndpoint(
                        this.ResourceGroupName,
                        this.ProfileName,
                        this.Type,
                        this.Name,
                        this.TargetResourceId,
                        this.Target,
                        this.EndpointStatus,
                        this.Weight,
                        this.Priority,
                        this.EndpointLocation,
                        this.MinChildEndpoints);

                    this.WriteVerbose(ProjectResources.Success);
                    this.WriteObject(trafficManagerEndpoint);
                }
                else
                {
                    throw;
                }
            }
        }
    }
}
