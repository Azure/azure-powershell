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
    [Cmdlet(VerbsCommon.Remove, "AzureRmTrafficManagerEndpointConfig"), OutputType(typeof(TrafficManagerProfile))]
    public class RemoveAzureTrafficManagerEndpointConfig : TrafficManagerBaseCmdlet
    {
        [Parameter(Mandatory = true, HelpMessage = "The name of the endpoint.")]
        [ValidateNotNullOrEmpty]
        public string EndpointName { get; set; }

        [Parameter(Mandatory = true, ValueFromPipeline = true, HelpMessage = "The profile.")]
        [ValidateNotNullOrEmpty]
        public TrafficManagerProfile TrafficManagerProfile { get; set; }

        public override void ExecuteCmdlet()
        {
            if (this.TrafficManagerProfile.Endpoints == null)
            {
                throw new PSArgumentException(string.Format(ProjectResources.Error_EndpointNotFound, this.EndpointName));
            }

            int endpointsRemoved = this.TrafficManagerProfile.Endpoints.RemoveAll(endpoint => string.Equals(this.EndpointName, endpoint.Name));

            if (endpointsRemoved == 0)
            {
                throw new PSArgumentException(string.Format(ProjectResources.Error_EndpointNotFound, this.EndpointName));
            }

            this.WriteVerbose(ProjectResources.Success);
            this.WriteObject(this.TrafficManagerProfile);
        }
    }
}
