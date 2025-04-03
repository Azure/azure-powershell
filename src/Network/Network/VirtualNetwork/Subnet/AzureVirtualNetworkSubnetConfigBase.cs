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
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.WindowsAzure.Commands.Common.CustomAttributes;
using System.Collections.Generic;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Network
{
    public class AzureVirtualNetworkSubnetConfigBase : NetworkBaseCmdlet
    {
        [Parameter(
            Mandatory = false,
            HelpMessage = "The name of the subnet")]
        [ValidateNotNullOrEmpty]
        public virtual string Name { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "The address prefixes of the subnet")]
        public string[] AddressPrefix { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "IpamPool to auto allocate from for subnet address prefixes.")]
        public PSIpamPoolPrefixAllocation[] IpamPoolPrefixAllocation { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            ParameterSetName = "SetByResourceId",
            HelpMessage = "NetworkSecurityGroupId")]
        public string NetworkSecurityGroupId { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            ParameterSetName = "SetByResource",
            HelpMessage = "NetworkSecurityGroup")]
        public PSNetworkSecurityGroup NetworkSecurityGroup { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            ParameterSetName = "SetByResourceId",
            HelpMessage = "RouteTableId")]
        public string RouteTableId { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            ParameterSetName = "SetByResource",
            HelpMessage = "RouteTable")]
        public PSRouteTable RouteTable { get; set; }

        [Alias("NatGatewayId")]
        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            ParameterSetName = "SetByResourceId",
            HelpMessage = "Specifies the Id of NAT Gateway resource associated with the subnet configuration")]
        public string ResourceId { get; set; }

        [Alias("NatGateway")]
        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            ParameterSetName = "SetByResource",
            HelpMessage = "Specifies the nat gateway associated with the subnet configuration")]
        public PSNatGateway InputObject { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Service Endpoint Value")]
        [PSArgumentCompleter(
            "Microsoft.Storage",
            "Microsoft.Sql",
            "Microsoft.AzureActiveDirectory",
            "Microsoft.AzureCosmosDB",
            "Microsoft.Web",
            "Microsoft.NetworkServiceEndpointTest",
            "Microsoft.KeyVault",
            "Microsoft.EventHub",
            "Microsoft.ServiceBus"
        )]
        public string[] ServiceEndpoint { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "NetworkIdentifier Value for ServiceEndpoint")]
        public PSResourceId NetworkIdentifier { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Service Endpoint with NetworkIdentifier Value")]
        public PSServiceEndpoint[] ServiceEndpointConfig { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Service Endpoint Policies")]
        public PSServiceEndpointPolicy[] ServiceEndpointPolicy { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Delegations")]
        public PSDelegation[] Delegation { get; set; }

        [Parameter(
           Mandatory = false,
           HelpMessage = "The flag to control enable/disable network policies on private endpoint",
           ValueFromPipelineByPropertyName = true)]
        [PSArgumentCompleter("Enabled", "Disabled")]
        public string PrivateEndpointNetworkPoliciesFlag { get; set; }

        [Parameter(
           Mandatory = false,
           HelpMessage = "The flag to control enable/disable network policies on private link service",
           ValueFromPipelineByPropertyName = true)]
        [PSArgumentCompleter("Enabled", "Disabled")]
        public string PrivateLinkServiceNetworkPoliciesFlag { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "IpAllocation")]
        public PSIpAllocation[] IpAllocation { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Default outbound connectivity for all VMs in the subnet")]
        public bool? DefaultOutboundAccess { get; set; }
    }
}