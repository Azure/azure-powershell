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
    using System.Collections.Generic;
    using System.Linq;

    [Cmdlet(VerbsCommon.Add, "AzureRmTrafficManagerEndpointConfig"), OutputType(typeof(TrafficManagerProfile))]
    public class AddAzureTrafficManagerEndpointConfig : TrafficManagerBaseCmdlet
    {
        [Parameter(Mandatory = true, HelpMessage = "The name of the endpoint.")]
        [ValidateNotNullOrEmpty]
        public string EndpointName { get; set; }

        [Parameter(Mandatory = true, ValueFromPipeline = true, HelpMessage = "The profile.")]
        [ValidateNotNullOrEmpty]
        public TrafficManagerProfile TrafficManagerProfile { get; set; }

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
            if (this.TrafficManagerProfile.Endpoints == null)
            {
                this.TrafficManagerProfile.Endpoints = new List<TrafficManagerEndpoint>();
            }

            if (this.TrafficManagerProfile.Endpoints.Any(endpoint => string.Equals(this.EndpointName, endpoint.Name)))
            {
                throw new PSArgumentException(string.Format(ProjectResources.Error_AddExistingEndpoint, this.EndpointName));
            }

            this.TrafficManagerProfile.Endpoints.Add(
                new TrafficManagerEndpoint
                {
                    Name = this.EndpointName,
                    Type = this.Type,
                    TargetResourceId = this.TargetResourceId,
                    Target = this.Target,
                    EndpointStatus = this.EndpointStatus,
                    Weight = this.Weight,
                    Priority = this.Priority,
                    Location = this.EndpointLocation,
                    MinChildEndpoints = this.MinChildEndpoints,
                });

            this.WriteVerbose(ProjectResources.Success);
            this.WriteObject(this.TrafficManagerProfile);
        }
    }
}
