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
using Microsoft.WindowsAzure.Commands.Common.CustomAttributes;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using MNM = Microsoft.Azure.Management.Network.Models;

namespace Microsoft.Azure.Commands.Network
{
    [Cmdlet("New", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "NetworkManagerRoutingRuleNextHop", SupportsShouldProcess = false), OutputType(typeof(PSNetworkManagerRoutingRuleNextHop))]
    public class NewAzNetworkManagerRoutingRuleNextHopCommand : NetworkManagerBaseCmdlet
    {
        [Parameter(
           Mandatory = false,
           ValueFromPipelineByPropertyName = true,
           HelpMessage = "NextHopAddress")]
        public string NextHopAddress { get; set; }

        [Parameter(
           Mandatory = true,
           ValueFromPipelineByPropertyName = true,
           HelpMessage = "NextHopType. Valid values include 'Internet', 'NoNextHop', 'VirtualAppliance', 'VirtualNetworkGateway', 'VnetLocal'.")]
        [ValidateSet(
            MNM.RoutingRuleNextHopType.Internet,
            MNM.RoutingRuleNextHopType.NoNextHop,
            MNM.RoutingRuleNextHopType.VirtualAppliance,
            MNM.RoutingRuleNextHopType.VirtualNetworkGateway,
            MNM.RoutingRuleNextHopType.VnetLocal,
            IgnoreCase = true)]
        public string NextHopType { get; set; }

        public override void Execute()
        {
            base.Execute();

            var psRoutingRuleNextHop = new PSNetworkManagerRoutingRuleNextHop
            {
                NextHopType = this.NextHopType,
            };

            if (string.IsNullOrEmpty(this.NextHopAddress) && string.Equals(this.NextHopType, "VirtualAppliance", StringComparison.OrdinalIgnoreCase))
            {
                    throw new PSArgumentException($"NextHopAddress is required when NextHopType is set to '{this.NextHopType}' and cannot be empty.");
            }
            else if (!string.IsNullOrEmpty(this.NextHopAddress) && !string.Equals(this.NextHopType, "VirtualAppliance", StringComparison.OrdinalIgnoreCase))
            {
                throw new PSArgumentException($"NextHopAddress is not required when NextHopType is set to '{this.NextHopType}'.");
            }
            
            if (!string.IsNullOrEmpty(this.NextHopAddress))
            {
                psRoutingRuleNextHop.NextHopAddress = this.NextHopAddress;
            }

            WriteObject(psRoutingRuleNextHop);
        }
    }
}
