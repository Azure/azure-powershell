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
using Microsoft.Azure.Management.Network;
using System.Management.Automation;
using MNM = Microsoft.Azure.Management.Network.Models;

namespace Microsoft.Azure.Commands.Network
{
    [Cmdlet(VerbsCommon.Reset, "AzureRmVirtualNetworkGatewayConnectionSharedKey", SupportsShouldProcess = true),
        OutputType(typeof(string))]
    public class ResetAzureVirtualNetworkGatewayConnectionSharedKeyCommand : VirtualNetworkGatewayConnectionBaseCmdlet
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
        [ValidateNotNullOrEmpty]
        public virtual string ResourceGroupName { get; set; }

        [Parameter(
         Mandatory = true,
         ValueFromPipelineByPropertyName = true,
         HelpMessage = "The virtual network connection reset shared key length")]
        [ValidateNotNullOrEmpty]
        public uint KeyLength { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Do not ask for confirmation if you want to overrite a resource")]
        public SwitchParameter Force { get; set; }

        public override void Execute()
        {
            base.Execute();
            var present = this.IsVirtualNetworkGatewayConnectionSharedKeyPresent(this.ResourceGroupName, this.Name);            ConfirmAction(
                Force.IsPresent,
                string.Format(Properties.Resources.OverwritingResource, Name),
                Properties.Resources.ResettingResourceMessage,
                Name,
                () =>
                {
                    var virtualNetworkGatewayConnectionSharedKey = ResetVirtualNetworkGatewayConnectionSharedKey();
                    WriteObject(virtualNetworkGatewayConnectionSharedKey);
                },
                () => present);        }

        private string ResetVirtualNetworkGatewayConnectionSharedKey()
        {
            var vnetGatewayConnectionSharedKey = new PSConnectionResetSharedKey();
            vnetGatewayConnectionSharedKey.KeyLength = KeyLength;

            // Map to the sdk object
            var vnetGatewayConnectionSharedKeyModel = Mapper.Map<MNM.ConnectionResetSharedKey>(vnetGatewayConnectionSharedKey);

            // Execute the Set VirtualNetworkConnectionSharedKey call
            this.VirtualNetworkGatewayConnectionClient.ResetSharedKey(this.ResourceGroupName, this.Name, vnetGatewayConnectionSharedKeyModel);

            var getVirtualNetworkGatewayConnectionSharedKey = this.GetVirtualNetworkGatewayConnectionSharedKey(this.ResourceGroupName, this.Name);

            return getVirtualNetworkGatewayConnectionSharedKey;
        }
    }
}
