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
using Microsoft.Azure.Commands.ResourceManager.Common.Tags;
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;
using Microsoft.Azure.Management.Network;
using System;
using System.Management.Automation;
using MNM = Microsoft.Azure.Management.Network.Models;
using Microsoft.Azure.Commands.Network.VirtualNetworkGateway;

namespace Microsoft.Azure.Commands.Network
{
    [Cmdlet(VerbsCommon.Remove, "AzureRmVpnClientIpsecParameter", DefaultParameterSetName = "ByFactoryName", SupportsShouldProcess = true), 
        OutputType(typeof(bool))]
    public class RemoveAzureVpnClientIpsecParametersCommand : VirtualNetworkGatewayBaseCmdlet
    {
        [Parameter(
            ParameterSetName = ParameterSetNames.ByFactoryName,
            Mandatory = true,
            HelpMessage = "The virtual network gateway name.")]
        [ValidateNotNullOrEmpty]
        public virtual string VirtualNetworkGatewayName { get; set; }

        [Parameter(
            ParameterSetName = ParameterSetNames.ByFactoryName,
            Mandatory = true,
            HelpMessage = "The resource group name.")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public virtual string ResourceGroupName { get; set; }

        [Parameter(
            ParameterSetName = ParameterSetNames.ByFactoryObject,
            Mandatory = true,
            ValueFromPipeline = true,
            HelpMessage = "The virtual network gateaway object")]
        [ValidateNotNullOrEmpty]
        public PSVirtualNetworkGateway InputObject { get; set; }

        [Parameter(
            ParameterSetName = ParameterSetNames.ByResourceId,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The Azure resource ID.")]
        [ValidateNotNullOrEmpty]
        public string ResourceId { get; set; }

        public override void Execute()
        {
            if (ParameterSetName.Equals(ParameterSetNames.ByFactoryObject, StringComparison.OrdinalIgnoreCase))
            {
                VirtualNetworkGatewayName = InputObject.Name;
                ResourceGroupName = InputObject.ResourceGroupName;
            }
            else if (ParameterSetName.Equals(ParameterSetNames.ByResourceId, StringComparison.OrdinalIgnoreCase))
            {
                var parsedResourceId = new ResourceIdentifier(ResourceId);
                VirtualNetworkGatewayName = parsedResourceId.ResourceName;
                ResourceGroupName = parsedResourceId.ResourceGroupName;
            }

            base.Execute();

            if (ShouldProcess(VirtualNetworkGatewayName, Properties.Resources.RemoveResourceMessage + Properties.Resources.VirtualNetworkGatewayName))
            {
                if (!this.IsVirtualNetworkGatewayPresent(ResourceGroupName, VirtualNetworkGatewayName))
                {
                    throw new ArgumentException(Microsoft.Azure.Commands.Network.Properties.Resources.ResourceNotFound);
                }

                var vnetGateway = this.GetVirtualNetworkGateway(this.ResourceGroupName, this.VirtualNetworkGatewayName);

                if (vnetGateway.VpnClientConfiguration == null || vnetGateway.VpnClientConfiguration.VpnClientIpsecPolicies == null)
                {
                    throw new ArgumentException("There are no any vpn client ipsec parameters specified on Gateway!");
                }

                // Make sure the vpn client ipsec parameters are present on Gateway before calling to Remove it.
                if (vnetGateway.VpnClientConfiguration.VpnClientIpsecPolicies.Count == 0)
                {
                    throw new ArgumentException("There are no any vpn client ipsec parameters specified on Gateway! So, can not proceed with removing it!");
                }

                vnetGateway.VpnClientConfiguration.VpnClientIpsecPolicies.Clear();

                // Map to the sdk object
                var virtualnetGatewayModel = NetworkResourceManagerProfile.Mapper.Map<MNM.VirtualNetworkGateway>(vnetGateway);
                virtualnetGatewayModel.Tags = TagsConversionHelper.CreateTagDictionary(vnetGateway.Tag, validate: true);

                this.VirtualNetworkGatewayClient.CreateOrUpdate(ResourceGroupName, VirtualNetworkGatewayName, virtualnetGatewayModel);

                WriteObject(true);
            }
        }
    }
}
