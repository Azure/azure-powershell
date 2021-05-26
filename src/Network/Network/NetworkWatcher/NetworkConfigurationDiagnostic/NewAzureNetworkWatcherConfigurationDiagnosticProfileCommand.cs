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

using Microsoft.Azure.Commands.Network.Models;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Network
{
    [Cmdlet("New", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "NetworkWatcherNetworkConfigurationDiagnosticProfile"), OutputType(typeof(PSNetworkConfigurationDiagnosticProfile))]
    public class NewNetworkWatcherNetworkConfigurationDiagnosticProfileCommand : NetworkBaseCmdlet
    {
        [Parameter(
             Mandatory = true,
             ValueFromPipeline = true,
             HelpMessage = "The direction of the traffic. Accepted values are 'Inbound' and 'Outbound'")]
        [ValidateNotNullOrEmpty]
        public string Direction { get; set; }

        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Protocol to be verified on. Accepted values are '*', TCP, UDP.")]
        [ValidateNotNullOrEmpty]
        public string Protocol { get; set; }

        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Traffic source. Accepted values are '*', IP Address/CIDR, Service Tag.")]
        [ValidateNotNullOrEmpty]
        public string Source { get; set; }

        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Traffic destination. Accepted values are: '*', IP Address/CIDR, Service Tag.")]
        [ValidateNotNullOrEmpty]
        public string Destination { get; set; }

        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Traffic destination port. Accepted values are '*', port (for example, 3389) and port range (for example, 80-100).")]
        [ValidateNotNullOrEmpty]
        public string DestinationPort { get; set; }

        public override void Execute()
        {
            base.Execute();

            var ncdPofile = new PSNetworkConfigurationDiagnosticProfile
            {
                Direction = this.Direction,
                Protocol = this.Protocol,
                Source = this.Source,
                Destination = this.Destination,
                DestinationPort = this.DestinationPort
            };

            WriteObject(ncdPofile);
        }
    }
}
