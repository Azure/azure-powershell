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

using Microsoft.Azure.Commands.ResourceManager.Common.Tags;
using System.Net;
using Microsoft.Azure.Commands.Network.Models;
using Microsoft.Azure.Management.Network;
using Microsoft.Azure.Management.Network.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using AutoMapper;
using MNM = Microsoft.Azure.Management.Network.Models;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;

namespace Microsoft.Azure.Commands.Network
{
    [Cmdlet(VerbsCommon.New, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "NatGateway", SupportsShouldProcess = true), OutputType(typeof(PSNatGateway))]
    public partial class NewAzureRmNatGateway : NetworkBaseCmdlet
    {
        [Parameter(
            Mandatory = true,
            HelpMessage = "The resource group name of the nat gateway.")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Alias("ResourceName")]
        [Parameter(
            Mandatory = true,
            HelpMessage = "The name of the nat gateway.")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "The idle timeout of the nat gateway.")]
        public int IdleTimeoutInMinutes { get; set; } = 4;

        [Parameter(
            Mandatory = false,
            HelpMessage = "Name of a NAT gateway SKU.")]
        [ValidateNotNullOrEmpty]
        [PSArgumentCompleter(MNM.NatGatewaySkuName.Standard)]
        public string Sku { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "The location.")]
        [LocationCompleter("Microsoft.Network/natGateways")]
        public string Location { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "A hashtable which represents resource tags.")]
        public Hashtable Tag { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "An array of public ip addresses associated with the nat gateway resource.")]
        public PSResourceId[] PublicIpAddress { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "An array of public ip prefixes associated with the nat gateway resource.")]
        public PSResourceId[] PublicIpPrefix { get; set; }

        [Parameter(
            Mandatory = false,
             HelpMessage = "Do not ask for confirmation if you want to overwrite a resource")]
        public SwitchParameter Force { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Run cmdlet in the background")]
        public SwitchParameter AsJob { get; set; }

        public override void Execute()
        {
            base.Execute();

            // Sku
            PSNatGatewaySku vSku = null;

            if (this.Sku != null)
            {
                if (vSku == null)
                {
                    vSku = new PSNatGatewaySku();
                }
                vSku.Name = MNM.NatGatewaySkuName.Standard;
            }

            // PublicIpAddresses
            List<PSResourceId> vPublicIpAddresses = null;

            // PublicIpPrefixes
            List<PSResourceId> vPublicIpPrefixes = null;

            vPublicIpAddresses = this.PublicIpAddress?.ToList();
            vPublicIpPrefixes = this.PublicIpPrefix?.ToList();

            var vNatGateway = new PSNatGateway
            {
                IdleTimeoutInMinutes = this.IdleTimeoutInMinutes,
                Location = this.Location,
                Sku = vSku,
                PublicIpAddresses = vPublicIpAddresses,
                PublicIpPrefixes = vPublicIpPrefixes,
            };

            var vNatGatewayModel = NetworkResourceManagerProfile.Mapper.Map<MNM.NatGateway>(vNatGateway);
            vNatGatewayModel.Tags = TagsConversionHelper.CreateTagDictionary(this.Tag, validate: true);
            var present = true;
            try
            {
                this.NetworkClient.NetworkManagementClient.NatGateways.Get(this.ResourceGroupName, this.Name);
            }
            catch (Microsoft.Rest.Azure.CloudException exception)
            {
                if (exception.Response.StatusCode == HttpStatusCode.NotFound)
                {
                    // Resource is not present
                    present = false;
                }
                else
                {
                    throw;
                }
            }

            ConfirmAction(
                Force.IsPresent,
                string.Format(Properties.Resources.OverwritingResource, Name),
                Properties.Resources.CreatingResourceMessage,
                Name,
            () =>
            {
                this.NetworkClient.NetworkManagementClient.NatGateways.CreateOrUpdate(this.ResourceGroupName, this.Name, vNatGatewayModel);
                var getNatGateway = this.NetworkClient.NetworkManagementClient.NatGateways.Get(this.ResourceGroupName, this.Name);
                var psNatGateway = NetworkResourceManagerProfile.Mapper.Map<PSNatGateway>(getNatGateway);
                psNatGateway.ResourceGroupName = this.ResourceGroupName;
                psNatGateway.Tag = TagsConversionHelper.CreateTagHashtable(getNatGateway.Tags);
                WriteObject(psNatGateway, true);
            },
            () => present);
        }
    }
}