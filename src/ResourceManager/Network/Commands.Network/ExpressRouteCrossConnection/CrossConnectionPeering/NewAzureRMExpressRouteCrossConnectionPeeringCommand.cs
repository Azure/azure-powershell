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
    using System;
    using System.Linq;

    [Cmdlet(VerbsCommon.New, "AzureRMExpressRouteCrossConnectionPeering", DefaultParameterSetName = "SetByResource", SupportsShouldProcess = true), OutputType(typeof(PSExpressRouteCrossConnectionPeering))]
    public class NewAzureRMExpressRouteCrossConnectionPeeringCommand : AzureRMExpressRouteCrossConnectionPeeringBase
    {
        [Parameter(
            Mandatory = true,
            HelpMessage = "The name of the Peering")]
        [ValidateNotNullOrEmpty]
        public override string Name { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Do not ask for confirmation if you want to overrite a resource")]
        public SwitchParameter Force { get; set; }

        public override void Execute()
        {
            base.Execute();

            ConfirmAction(
               Force.IsPresent,
               string.Format(Properties.Resources.OverwritingResource, Name),
               Properties.Resources.CreatingResourceMessage,
               Name,
               () =>
               {
                   var peering = new PSExpressRouteCrossConnectionPeering();

                   peering.Name = Name;
                   peering.PeeringType = PeeringType;
                   peering.PeerASN = PeerASN;
                   peering.VlanId = VlanId;

                   if (!string.IsNullOrEmpty(SharedKey))
                   {
                       peering.SharedKey = SharedKey;
                   }

                   if (PeerAddressType == IPv6)
                   {
                       SetIpv6PeeringParameters(peering);
                   }
                   else
                   {
                       // Set IPv4 config even if no PeerAddresType has been specified for backward compatibility
                       SetIpv4PeeringParameters(peering);
                   }

                   ConstructMicrosoftConfig(peering);

                   WriteObject(peering);
               });
        }
    }
}
