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

using AutoMapper;
using Microsoft.Azure.Commands.Network.Models;
using Microsoft.Azure.Commands.Network.Models.NetworkManager;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Commands.ResourceManager.Common.Tags;
using Microsoft.Azure.Management.Network;
using Microsoft.Azure.Management.Network.Models;
using Microsoft.WindowsAzure.Commands.Common.CustomAttributes;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using MNM = Microsoft.Azure.Management.Network.Models;

namespace Microsoft.Azure.Commands.Network
{
    [Cmdlet("New", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "NetworkManagerIPTraffic", SupportsShouldProcess = true), OutputType(typeof(PSIPTraffic))]
    public class NewAzNetworkManagerIPTrafficCommand : ReachabilityAnalysisIntentBaseCmdlet
    {
        [Parameter(
           Mandatory = true,
           ValueFromPipelineByPropertyName = true,
           HelpMessage = "The source IPs.")]
        [ValidateNotNullOrEmpty]
        public List<string> SourceIp { get; set; }

        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The destination IPs.")]
        [ValidateNotNullOrEmpty]
        public List<string> DestinationIp { get; set; }

        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The source ports.")]
        [ValidateNotNullOrEmpty]
        public List<string> SourcePort { get; set; }

        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The destination ports.")]
        [ValidateNotNullOrEmpty]
        public List<string> DestinationPort { get; set; }

        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The protocols (e.g., TCP, UDP).")]
        [ValidateNotNullOrEmpty]
        public List<string> Protocol { get; set; }

        public override void Execute()
        {
            base.Execute();

            var ipTraffic = new PSIPTraffic
            {
                SourceIps = this.SourceIp,
                DestinationIps = this.DestinationIp,
                SourcePorts = this.SourcePort,
                DestinationPorts = this.DestinationPort,
                Protocols = this.Protocol
            };

            WriteObject(ipTraffic);
        }
       
    }
}