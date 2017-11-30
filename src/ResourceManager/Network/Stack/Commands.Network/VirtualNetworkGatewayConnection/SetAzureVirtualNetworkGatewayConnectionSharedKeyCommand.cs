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

using System.Collections;
using System.Collections.Generic;
using System.Management.Automation;
using AutoMapper;
using Microsoft.Azure.Management.Network;
using Microsoft.Azure.Commands.Network.Models;
using MNM = Microsoft.Azure.Management.Network.Models;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;

namespace Microsoft.Azure.Commands.Network
{
    [Cmdlet(VerbsCommon.Set, "AzureRmVirtualNetworkGatewayConnectionSharedKey"), OutputType(typeof(string))]
    public class NewAzureVirtualNetworkGatewayConnectionSharedKeyCommand : VirtualNetworkGatewayConnectionBaseCmdlet
    {
        [Alias("ResourceName")]
        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The resource name.")]
        [ValidateNotNullOrEmpty]
        public virtual string Name { get; set; }

        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The resource group name.")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public virtual string ResourceGroupName { get; set; }

        [Parameter(
         Mandatory = true,
         ValueFromPipelineByPropertyName = true,
         HelpMessage = "The virtual network connection shared key value.")]
        [ValidateNotNullOrEmpty]
        public string Value { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Do not ask for confirmation if you want to overrite a resource")]
        public SwitchParameter Force { get; set; }

        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();

            if (this.IsVirtualNetworkGatewayConnectionSharedKeyPresent(this.ResourceGroupName, this.Name))
            {
                ConfirmAction(
                    Force.IsPresent,
                    string.Format(Microsoft.Azure.Commands.Network.Properties.Resources.OverwritingResource, Name),
                    Microsoft.Azure.Commands.Network.Properties.Resources.OverwritingResourceMessage,
                    Name,
                    () => SetVirtualNetworkGatewayConnectionSharedKey());

                WriteObject(this.GetVirtualNetworkGatewayConnectionSharedKey(this.ResourceGroupName, this.Name));
            }
            else
            {
                var virtualNetworkGatewayConnectionSharedKey = SetVirtualNetworkGatewayConnectionSharedKey();

                WriteObject(virtualNetworkGatewayConnectionSharedKey);
            }
        }

        private string SetVirtualNetworkGatewayConnectionSharedKey()
        {
            var vnetGatewayConnectionSharedKey = new PSConnectionSharedKey();
            vnetGatewayConnectionSharedKey.Value = Value;

            // Map to the sdk object
            var vnetGatewayConnectionSharedKeyModel = Mapper.Map<MNM.ConnectionSharedKey>(vnetGatewayConnectionSharedKey);

            // Execute the Set VirtualNetworkConnectionSharedKey call
            this.VirtualNetworkGatewayConnectionClient.SetSharedKey(this.ResourceGroupName, this.Name, vnetGatewayConnectionSharedKeyModel);

            var getVirtualNetworkGatewayConnectionSharedKey = this.GetVirtualNetworkGatewayConnectionSharedKey(this.ResourceGroupName, this.Name);

            return getVirtualNetworkGatewayConnectionSharedKey;
        }
    }
}
