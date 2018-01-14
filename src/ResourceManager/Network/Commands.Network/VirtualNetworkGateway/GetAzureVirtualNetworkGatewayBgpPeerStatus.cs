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
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Management.Network;
using System.Collections.Generic;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Network
{
    [Cmdlet(VerbsCommon.Get, "AzureRmVirtualNetworkGatewayBGPPeerStatus"), OutputType(typeof(PSBGPPeerStatus[]))]
    public class GetAzureVirtualNetworkGatewayBGPPeerStatus : VirtualNetworkGatewayBaseCmdlet
    {
        [Alias("ResourceName")]
        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Virtual network gateway name")]
        [ValidateNotNullOrEmpty]
        public virtual string VirtualNetworkGatewayName { get; set; }

        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Virtual network gateway resource group's name")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public virtual string ResourceGroupName { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "IP of the peer to retrieve status for")]
        public virtual string Peer { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Run cmdlet in the background")]
        public SwitchParameter AsJob { get; set; }

        public override void Execute()
        {
            base.Execute();

            List<PSBGPPeerStatus> peerStatuses = new List<PSBGPPeerStatus>();
            foreach (var peerStatus in this.VirtualNetworkGatewayClient.GetBgpPeerStatus(this.ResourceGroupName, this.VirtualNetworkGatewayName, this.Peer).Value)
            {
                peerStatuses.Add(NetworkResourceManagerProfile.Mapper.Map<PSBGPPeerStatus>(peerStatus));
            }

            WriteObject(peerStatuses, true);
        }
    }
}
