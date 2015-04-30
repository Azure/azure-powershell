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

using System;
using System.Management.Automation;
using AutoMapper;
using Microsoft.Azure.Management.Network;
using Microsoft.Azure.Commands.Network.Models;
using Microsoft.Azure.Commands.Resources.Models;
using MNM = Microsoft.Azure.Management.Network.Models;
using System.Collections;
using Microsoft.Azure.Commands.Tags.Model;

namespace Microsoft.Azure.Commands.Network
{
    [Cmdlet(VerbsCommon.Resize, "AzureVirtualNetworkGateway"), OutputType(typeof(PSVirtualNetworkGateway))]
    public class ResizeAzureVirtualNetworkGatewayCommand : VirtualNetworkGatewayBaseCmdlet
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
         HelpMessage = "location.")]
        [ValidateNotNullOrEmpty]
        public string Location { get; set; }

        [Parameter(
       Mandatory = true,
       ValueFromPipelineByPropertyName = true,
       HelpMessage = "The size of this virtual network gateway.")]
        [ValidateNotNullOrEmpty]
        [ValidateSet(
            MNM.VirtualNetworkGatewaySize.Default,
            MNM.VirtualNetworkGatewaySize.HighPerformance,
            IgnoreCase = true)]
        public string GatewaySize { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "An array of hashtables which represents resource tags.")]
        public Hashtable[] Tag { get; set; }

        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();

            if (!this.IsVirtualNetworkGatewayPresent(this.ResourceGroupName, this.Name))
            {
                throw new ArgumentException(Microsoft.Azure.Commands.Network.Properties.Resources.ResourceNotFound);
            }

            var vnetGateway = new PSVirtualNetworkGateway();
            vnetGateway.Name = this.Name;
            vnetGateway.Location = this.Location;
            vnetGateway.GatewaySize = this.GatewaySize;

            // Map to the sdk object
            var vnetGatewayModel = Mapper.Map<MNM.VirtualNetworkGateway>(vnetGateway);
            vnetGatewayModel.Type = Microsoft.Azure.Commands.Network.Properties.Resources.VirtualNetworkGatewayType;
            vnetGatewayModel.Tags = TagsConversionHelper.CreateTagDictionary(this.Tag, validate: true);

            // Execute the Create VirtualNetworkGateway call
            this.VirtualNetworkGatewayClient.CreateOrUpdate(this.ResourceGroupName, this.Name, vnetGatewayModel);

            var getVirtualNetworkGateway = this.GetVirtualNetworkGateway(this.ResourceGroupName, this.Name);
            WriteObject(getVirtualNetworkGateway);
        }
    }
}
