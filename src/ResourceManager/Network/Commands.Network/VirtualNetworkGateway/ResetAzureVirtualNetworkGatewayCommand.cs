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
using Microsoft.Azure.Commands.ResourceManager.Common.Tags;
using Microsoft.Azure.Management.Network;
using System;
using System.Management.Automation;
using MNM = Microsoft.Azure.Management.Network.Models;

namespace Microsoft.Azure.Commands.Network
{
    [Cmdlet(VerbsCommon.Reset, "AzureRmVirtualNetworkGateway"), OutputType(typeof(PSVirtualNetworkGateway))]
    public class ResetAzureVirtualNetworkGatewayCommand : VirtualNetworkGatewayBaseCmdlet
    {
        [Parameter(
            Mandatory = true,
            ValueFromPipeline = true,
            HelpMessage = "The virtualNetworkGateway")]
        [ValidateNotNull]
        public PSVirtualNetworkGateway VirtualNetworkGateway { get; set; }

        public override void Execute()
        {
            base.Execute();
            if (!this.IsVirtualNetworkGatewayPresent(this.VirtualNetworkGateway.ResourceGroupName, this.VirtualNetworkGateway.Name))
            {
                throw new ArgumentException(Microsoft.Azure.Commands.Network.Properties.Resources.ResourceNotFound);
            }

            // Map to the sdk object
            var vnetGatewayModel = Mapper.Map<MNM.VirtualNetworkGateway>(this.VirtualNetworkGateway);
            vnetGatewayModel.Tags = TagsConversionHelper.CreateTagDictionary(this.VirtualNetworkGateway.Tag, validate: true);

            this.VirtualNetworkGatewayClient.Reset(this.VirtualNetworkGateway.ResourceGroupName, this.VirtualNetworkGateway.Name, vnetGatewayModel);

            var getVirtualNetworkGateway = this.GetVirtualNetworkGateway(this.VirtualNetworkGateway.ResourceGroupName, this.VirtualNetworkGateway.Name);
            WriteObject(getVirtualNetworkGateway);
        }
    }
}
