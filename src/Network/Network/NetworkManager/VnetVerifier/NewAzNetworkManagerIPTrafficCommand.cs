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
        public IList<string> SourceIps { get; set; }

        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The destination IPs.")]
        [ValidateNotNullOrEmpty]
        public IList<string> DestinationIps { get; set; }

        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The source ports.")]
        [ValidateNotNullOrEmpty]
        public IList<string> SourcePorts { get; set; }

        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The destination ports.")]
        [ValidateNotNullOrEmpty]
        public IList<string> DestinationPorts { get; set; }

        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The protocols (e.g., TCP, UDP).")]
        [ValidateNotNullOrEmpty]
        public IList<string> Protocols { get; set; }

        public override void Execute()
        {
            base.Execute();

            var ipTraffic = new PSIPTraffic
            {
                SourceIps = this.SourceIps,
                DestinationIps = this.DestinationIps,
                SourcePorts = this.SourcePorts,
                DestinationPorts = this.DestinationPorts,
                Protocols = this.Protocols
            };

            WriteObject(ipTraffic);
        }
       
    }
}