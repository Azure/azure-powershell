﻿// ----------------------------------------------------------------------------------
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

using System.Linq;
using System.Management.Automation;
using Microsoft.Azure.Commands.Network.Models;

namespace Microsoft.Azure.Commands.Network
{
    public class AzureApplicationGatewayPrivateLinkConfigurationBase : NetworkBaseCmdlet
    {
        [Parameter(
                Mandatory = true,
                HelpMessage = "The name of the privateLink configuration")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(
             Mandatory = true,
             ValueFromPipelineByPropertyName = true,
             HelpMessage = "The list of ipConfiguration")]
        [ValidateNotNullOrEmpty]
        public PSApplicationGatewayPrivateLinkIpConfiguration[] IpConfiguration { get; set; }

        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();
        }

        public PSApplicationGatewayPrivateLinkConfiguration NewObject()
        {
            var privateLinkConfiguration = new PSApplicationGatewayPrivateLinkConfiguration();

            privateLinkConfiguration.Name = this.Name;
            privateLinkConfiguration.IpConfigurations = this.IpConfiguration?.ToList();

            privateLinkConfiguration.Id = ApplicationGatewayChildResourceHelper.GetResourceNotSetId(
                        this.NetworkClient.NetworkManagementClient.SubscriptionId,
                        Microsoft.Azure.Commands.Network.Properties.Resources.ApplicationGatewayPrivateLinkConfigurationName,
                        this.Name);

            return privateLinkConfiguration;
        }
    }
}
