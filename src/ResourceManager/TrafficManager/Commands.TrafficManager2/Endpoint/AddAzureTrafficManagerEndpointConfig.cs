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

using System.Management.Automation;
using Microsoft.Azure.Commands.TrafficManager.Models;
using Microsoft.Azure.Commands.TrafficManager.Utilities;

namespace Microsoft.Azure.Commands.TrafficManager
{
    [Cmdlet(VerbsCommon.Add, "AzureTrafficManagerEndpointConfig"), OutputType(typeof(TrafficManagerProfile))]
    public class AddAzureTrafficManagerEndpointConfig : TrafficManagerBaseCmdlet
    {
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The name of the endpoint.")]
        [ValidateNotNullOrEmpty]
        public string EndpointName { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The profile.")]
        [ValidateNotNullOrEmpty]
        public new TrafficManagerProfile Profile { get; set; }

        // TODO: add parameters

        public override void ExecuteCmdlet()
        {
            // TODO: 
            /*TrafficManagerProfile profile = this.TrafficManagerClient.CreateTrafficManagerProfile(
                this.ResourceGroupName, 
                this.Name, 
                this.TrafficRoutingMethod, 
                this.RelativeDnsName, 
                this.Ttl,
                this.MonitorProtocol,
                this.MonitorPort,
                this.MonitorPath);

            this.WriteObject(profile);*/
        }
    }
}
