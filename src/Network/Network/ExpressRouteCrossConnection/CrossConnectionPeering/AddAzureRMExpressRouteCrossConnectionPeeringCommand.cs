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
using System;
using System.Linq;
using System.Management.Automation;
using Microsoft.Azure.Commands.ResourceManager.Common.Tags;
using Microsoft.Azure.Management.Network;

namespace Microsoft.Azure.Commands.Network
{
    [Cmdlet("Add", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "ExpressRouteCrossConnectionPeering", DefaultParameterSetName = "SetByResource", SupportsShouldProcess = true), OutputType(typeof(PSExpressRouteCrossConnection))]
    public class AddAzureRMExpressRouteCrossConnectionPeeringCommand : AzureRMExpressRouteCrossConnectionPeeringBase
    {
        [Parameter(
            Mandatory = true,
            HelpMessage = "The name of the Peering")]
        [ValidateNotNullOrEmpty]
        public override string Name { get; set; }

        [Parameter(
            Mandatory = true,
            ValueFromPipeline = true,
            HelpMessage = "The ExpressRouteCrossConnection")]
        public PSExpressRouteCrossConnection ExpressRouteCrossConnection { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Do not ask for confirmation if you want to overwrite a resource")]
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
                   var peering = this.ExpressRouteCrossConnection.Peerings.SingleOrDefault(resource => string.Equals(resource.Name, this.Name, System.StringComparison.CurrentCultureIgnoreCase));

                   if (peering != null)
                   {
                       throw new ArgumentException("Peering with the specified name already exists");
                   }

                   peering = new PSExpressRouteCrossConnectionPeering();

                   peering.Name = this.Name;
                   peering.PeeringType = this.PeeringType;
                   peering.PeerASN = this.PeerASN;
                   peering.VlanId = this.VlanId;


                   if (!string.IsNullOrEmpty(this.SharedKey))
                   {
                       peering.SharedKey = this.SharedKey;
                   }

                   if (this.PeerAddressType == IPv6)
                   {
                       this.SetIpv6PeeringParameters(peering);
                   }
                   else
                   {
                       // Set IPv4 config even if no PeerAddresType has been specified for backward compatibility
                       this.SetIpv4PeeringParameters(peering);
                   }

                   this.ConstructMicrosoftConfig(peering);

                   this.ExpressRouteCrossConnection.Peerings.Add(peering);

                   // Map to the sdk operation
                   var crossConnectionModel = NetworkResourceManagerProfile.Mapper.Map<Management.Network.Models.ExpressRouteCrossConnection>(ExpressRouteCrossConnection);
                   crossConnectionModel.Tags = TagsConversionHelper.CreateTagDictionary(ExpressRouteCrossConnection.Tag, validate: true);

                   // Execute the Update ExpressRouteCrossConnection call
                   ExpressRouteCrossConnectionClient.CreateOrUpdate(ExpressRouteCrossConnection.ResourceGroupName, ExpressRouteCrossConnection.Name, crossConnectionModel);

                   var getExpressRouteCrossConnection = GetExpressRouteCrossConnection(ExpressRouteCrossConnection.ResourceGroupName, ExpressRouteCrossConnection.Name);
                   WriteObject(getExpressRouteCrossConnection);
               });
        }
    }
}
