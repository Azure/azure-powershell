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
    [Cmdlet(VerbsCommon.New, "AzureTrafficManagerProfile"), OutputType(typeof(TrafficManagerProfile))]
    public class NewAzureTrafficManagerProfile : TrafficManagerBaseCmdlet
    {
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The name of the profile.")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The resource group to which the profile belongs.")]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The relative name of the profile.")]
        [ValidateNotNullOrEmpty]
        public string RelativeDnsName { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The TTL value of the DNS configurations.")]
        [ValidateNotNullOrEmpty]
        public uint Ttl { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The traffic routing method of the profile.")]
        [ValidateSet("Performance", "Weighted", "Priority", IgnoreCase = false)]
        [ValidateNotNullOrEmpty]
        public string TrafficRoutingMethod { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The protocol of the monitor.")]
        [ValidateSet("HTTP", "HTTPS", IgnoreCase = false)]
        [ValidateNotNullOrEmpty]
        public string MonitorProtocol { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The port of the monitor.")]
        [ValidateNotNullOrEmpty]
        public uint MonitorPort { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The path of the monitor.")]
        [ValidateNotNullOrEmpty]
        public string MonitorPath { get; set; }

        public override void ExecuteCmdlet()
        {
            TrafficManagerProfile profile = this.TrafficManagerClient.CreateTrafficManagerProfile(
                this.ResourceGroupName, 
                this.Name, 
                this.TrafficRoutingMethod, 
                this.RelativeDnsName, 
                this.Ttl,
                this.MonitorProtocol,
                this.MonitorPort,
                this.MonitorPath);

            this.WriteObject(profile);
        }
    }
}
