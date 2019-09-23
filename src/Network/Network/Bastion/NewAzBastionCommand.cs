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

namespace Microsoft.Azure.Commands.Network.Bastion
{
    using Microsoft.Azure.Commands.Network.Models;
    using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
    using Microsoft.Azure.Commands.ResourceManager.Common.Tags;
    using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;
    using Microsoft.Azure.Management.Network;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Management.Automation;
    using MNM = Microsoft.Azure.Management.Network.Models;

    [Cmdlet(VerbsCommon.New,
       ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "Bastion",
       DefaultParameterSetName = BastionParameterSetNames.ByResourceGroupName + BastionParameterSetNames.ByName + BastionParameterSetNames.ByIpObject + BastionParameterSetNames.ByVNObject,
       SupportsShouldProcess = true),
       OutputType(typeof(PSBastion))]

    public class NewAzBastionCommand : BastionBaseCmdlet
    {
        [Parameter(
            Mandatory = true,
            HelpMessage = "The resource group name.")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Alias("ResourceName", "BastionName")]
        [Parameter(
            Mandatory = true,
            HelpMessage = "The resource name.")]
        [ValidateNotNullOrEmpty]
        [ResourceNameCompleter("Microsoft.Network/bastionHosts", "ResourceGroupName")]
        public string Name { get; set; }

        [Alias("PublicIpAddressObject")]
        [Parameter(
            Mandatory = true,
             ParameterSetName = BastionParameterSetNames.ByIpObject + BastionParameterSetNames.ByVNObject,
            HelpMessage = "The public IP address object.")]
        [Parameter(
            Mandatory = true,
             ParameterSetName = BastionParameterSetNames.ByIpObject + BastionParameterSetNames.ByVNRGName + BastionParameterSetNames.ByVNName,
            HelpMessage = "The public IP address object.")]
        [Parameter(
            Mandatory = true,
             ParameterSetName = BastionParameterSetNames.ByIpObject + BastionParameterSetNames.ByVNResourceId,
            HelpMessage = "The public IP address object.")]
        [ValidateNotNull]
        public PSPublicIpAddress PublicIpAddress { get; set; }

        [Alias("PublicIpAddressResourceId")]
        [Parameter(
            Mandatory = true,
             ParameterSetName = BastionParameterSetNames.ByIpResourceId + BastionParameterSetNames.ByVNObject,
            HelpMessage = "The public Ip address Id.")]
        [Parameter(
            Mandatory = true,
             ParameterSetName = BastionParameterSetNames.ByIpResourceId + BastionParameterSetNames.ByVNRGName + BastionParameterSetNames.ByVNName,
            HelpMessage = "The public Ip address Id.")]
        [Parameter(
            Mandatory = true,
             ParameterSetName = BastionParameterSetNames.ByIpResourceId + BastionParameterSetNames.ByVNResourceId,
            HelpMessage = "The public Ip address Id.")]
        [ValidateNotNullOrEmpty]
        public string PublicIpAddressId { get; set; }

        [Alias("PublicIpAddressResourceGroupName")]
        [Parameter(
            Mandatory = true,
             ParameterSetName = BastionParameterSetNames.ByIpRGName + BastionParameterSetNames.ByIpName + BastionParameterSetNames.ByVNObject,
            HelpMessage = "The public Ip address resource group name.")]
        [Parameter(
            Mandatory = true,
             ParameterSetName = BastionParameterSetNames.ByIpRGName + BastionParameterSetNames.ByIpName + BastionParameterSetNames.ByVNRGName + BastionParameterSetNames.ByVNName,
            HelpMessage = "The public Ip address resource group name.")]
        [Parameter(
            Mandatory = true,
             ParameterSetName = BastionParameterSetNames.ByIpRGName + BastionParameterSetNames.ByIpName + BastionParameterSetNames.ByVNResourceId,
            HelpMessage = "The public Ip address resource group name.")]
        [ValidateNotNullOrEmpty]
        public string PublicIpAddressRgName { get; set; }

        [Parameter(
            Mandatory = true,
             ParameterSetName = BastionParameterSetNames.ByIpRGName + BastionParameterSetNames.ByIpName + BastionParameterSetNames.ByVNObject,
            HelpMessage = "The public Ip address resource name.")]
        [Parameter(
            Mandatory = true,
             ParameterSetName = BastionParameterSetNames.ByIpRGName + BastionParameterSetNames.ByIpName + BastionParameterSetNames.ByVNRGName + BastionParameterSetNames.ByVNName,
            HelpMessage = "The public Ip address resource name.")]
        [Parameter(
            Mandatory = true,
             ParameterSetName = BastionParameterSetNames.ByIpRGName + BastionParameterSetNames.ByIpName + BastionParameterSetNames.ByVNResourceId,
            HelpMessage = "The public Ip address resource name.")]
        [ValidateNotNullOrEmpty]
        public string PublicIpAddressName { get; set; }

        [Alias("VirtualNetworkObject")]
        [Parameter(
            Mandatory = true,
             ParameterSetName = BastionParameterSetNames.ByIpObject + BastionParameterSetNames.ByVNObject,
            HelpMessage = "The virtual network object.")]
        [Parameter(
            Mandatory = true,
             ParameterSetName = BastionParameterSetNames.ByIpRGName + BastionParameterSetNames.ByIpName + BastionParameterSetNames.ByVNObject,
            HelpMessage = "The virtual network name.")]
        [Parameter(
            Mandatory = true,
             ParameterSetName = BastionParameterSetNames.ByIpResourceId + BastionParameterSetNames.ByVNObject,
            HelpMessage = "The virtual network name.")]
        [ValidateNotNull]
        public PSVirtualNetwork VirtualNetwork { get; set; }

        [Alias("VirtualNetworkResourceId")]
        [Parameter(
           Mandatory = true,
            ParameterSetName = BastionParameterSetNames.ByIpObject + BastionParameterSetNames.ByVNResourceId,
           HelpMessage = "The virtual network resource Id.")]
        [Parameter(
           Mandatory = true,
            ParameterSetName = BastionParameterSetNames.ByIpRGName + BastionParameterSetNames.ByIpName + BastionParameterSetNames.ByVNResourceId,
           HelpMessage = "The virtual network resource Id.")]
        [Parameter(
           Mandatory = true,
            ParameterSetName = BastionParameterSetNames.ByIpResourceId + BastionParameterSetNames.ByVNResourceId,
           HelpMessage = "The virtual network resource Id.")]
        [ValidateNotNullOrEmpty]
        public string VirtualNetworkId { get; set; }

        [Alias("VirtualNetworkResourceGroupName")]
        [Parameter(
            Mandatory = true,
             ParameterSetName = BastionParameterSetNames.ByIpObject + BastionParameterSetNames.ByVNRGName + BastionParameterSetNames.ByVNName,
            HelpMessage = "The virtual network resource group name.")]
        [Parameter(
            Mandatory = true,
             ParameterSetName = BastionParameterSetNames.ByIpRGName + BastionParameterSetNames.ByIpName + BastionParameterSetNames.ByVNRGName + BastionParameterSetNames.ByVNName,
            HelpMessage = "The virtual network resource group name.")]
        [Parameter(
            Mandatory = true,
             ParameterSetName = BastionParameterSetNames.ByIpResourceId + BastionParameterSetNames.ByVNRGName + BastionParameterSetNames.ByVNName,
            HelpMessage = "The virtual network resource group name.")]
        [ValidateNotNullOrEmpty]
        public string VirtualNetworkRgName { get; set; }

        [Parameter(
           Mandatory = true,
            ParameterSetName = BastionParameterSetNames.ByIpObject + BastionParameterSetNames.ByVNRGName + BastionParameterSetNames.ByVNName,
           HelpMessage = "The virtual network resource name.")]
        [Parameter(
           Mandatory = true,
            ParameterSetName = BastionParameterSetNames.ByIpRGName + BastionParameterSetNames.ByIpName + BastionParameterSetNames.ByVNRGName + BastionParameterSetNames.ByVNName,
           HelpMessage = "The virtual network resource name.")]
        [Parameter(
           Mandatory = true,
            ParameterSetName = BastionParameterSetNames.ByIpResourceId + BastionParameterSetNames.ByVNRGName + BastionParameterSetNames.ByVNName,
           HelpMessage = "The virtual network resource name.")]
        [ValidateNotNullOrEmpty]
        public string VirtualNetworkName { get; set; }

        [Parameter(
           Mandatory = false,
           HelpMessage = "Do not ask for confirmation if you want to overwrite a resource")]
        public SwitchParameter Force { get; set; }

        [Parameter(
             Mandatory = false,
             ValueFromPipelineByPropertyName = true,
             HelpMessage = "A hashtable which represents resource tags.")]
        public Hashtable Tag { get; set; }

        public override void Execute()
        {
            if (ParameterSetName.Contains(BastionParameterSetNames.ByIpResourceId))
            {
                var parsedResourceId = new ResourceIdentifier(this.PublicIpAddressId);
                this.PublicIpAddressRgName = parsedResourceId.ResourceGroupName;
                this.PublicIpAddressName = parsedResourceId.ResourceName;
            }

            if(PublicIpAddress == null)
            {
                var publicIp = this.PublicIPAddressesClient.Get(this.PublicIpAddressRgName, this.PublicIpAddressName);
                this.PublicIpAddress = NetworkResourceManagerProfile.Mapper.Map<PSPublicIpAddress>(publicIp);
            }
            else
            {
                this.PublicIpAddress = PublicIpAddress;
            }

            if(this.PublicIpAddress == null)
            {
                throw new ArgumentException(string.Format(Microsoft.Azure.Commands.Network.Properties.Resources.ResourceNotFound, this.PublicIpAddressName));
            }

            if (ParameterSetName.Contains(BastionParameterSetNames.ByVNResourceId))
            {
                var parsedResourceId = new ResourceIdentifier(this.VirtualNetworkId);
                this.VirtualNetworkRgName = parsedResourceId.ResourceGroupName;
                this.VirtualNetworkName = parsedResourceId.ResourceName;
            }
            if (this.VirtualNetwork == null)
            {
                var vnet = this.VirtualNetworkClient.Get(this.VirtualNetworkRgName, VirtualNetworkName);
                this.VirtualNetwork = NetworkResourceManagerProfile.Mapper.Map<PSVirtualNetwork>(vnet);

            }
            if (this.VirtualNetwork == null)
            {
                throw new ArgumentException(string.Format(Microsoft.Azure.Commands.Network.Properties.Resources.ResourceNotFound, this.VirtualNetworkName));
            }

            base.Execute();

            var present = this.IsBastionPresent(this.ResourceGroupName, this.Name);
            ConfirmAction(
                Force.IsPresent,
                string.Format(Properties.Resources.OverwritingResource, Name),
                Properties.Resources.CreatingResourceMessage,
                Name,
                () => WriteObject(this.CreateBastion()),
                () => present);
        }

        private PSBastion CreateBastion()
        {
            var bastion = new PSBastion()
            {
                Name = this.Name,
                ResourceGroupName = this.ResourceGroupName,
                Location = this.VirtualNetwork.Location
            };

            if (this.VirtualNetwork != null)
            {
                bastion.Allocate(this.VirtualNetwork, this.PublicIpAddress);
            }

            //// Map to the sdk object
            var BastionModel = NetworkResourceManagerProfile.Mapper.Map<MNM.BastionHost>(bastion);
            BastionModel.Tags = TagsConversionHelper.CreateTagDictionary(this.Tag, validate: true);

            //// Execute the Create bastion call
            this.BastionClient.CreateOrUpdate(this.ResourceGroupName, this.Name, BastionModel);

            return this.GetBastion(this.ResourceGroupName, this.Name);
        }
    }
}
