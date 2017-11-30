
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
using System.Net;
using System.Collections;
using System.Collections.Generic;
using Microsoft.Azure.Management.Network.Models;

namespace Microsoft.Azure.Commands.Network
{
    public abstract class NetworkSecurityGroupBaseCmdlet : NetworkBaseCmdlet
    {
        public INetworkSecurityGroupsOperations NetworkSecurityGroupClient
        {
            get
            {
                return NetworkClient.NetworkManagementClient.NetworkSecurityGroups;
            }
        }

        public bool IsNetworkSecurityGroupPresent(string resourceGroupName, string name)
        {
            try
            {
                GetNetworkSecurityGroup(resourceGroupName, name);
            }
            catch (Microsoft.Rest.Azure.CloudException exception)
            {
                if (exception.Response.StatusCode == HttpStatusCode.NotFound)
                {
                    // Resource is not present
                    return false;
                }

                throw;
            }

            return true;
        }

        public PSNetworkSecurityGroup GetNetworkSecurityGroup(string resourceGroupName, string name, string expandResource = null)
        {
            var nsg = this.NetworkSecurityGroupClient.Get(resourceGroupName, name, expandResource);

            var psNetworkSecurityGroup = NetworkResourceManagerProfile.Mapper.Map<PSNetworkSecurityGroup>(nsg);
            psNetworkSecurityGroup.ResourceGroupName = resourceGroupName;

            psNetworkSecurityGroup.Tag = TagsConversionHelper.CreateTagHashtable(nsg.Tags);

            return psNetworkSecurityGroup;
        }

		// Temporary - to be removed
		public void NullifyApplicationSecurityGroupsIfAbsent(NetworkSecurityGroup nsg)
		{
			if (nsg == null)
			{
				return;
			}

            this.NullifyApplicationSecurityRulesIfAbsent(nsg.DefaultSecurityRules);
            this.NullifyApplicationSecurityRulesIfAbsent(nsg.SecurityRules);
        }

        public void NullifyApplicationSecurityRulesIfAbsent(IList<SecurityRule> rules)
        {
            if (rules == null)
            {
                return;
            }

            foreach (var rule in rules)
            {
                if (rule.SourceApplicationSecurityGroups != null && rule.SourceApplicationSecurityGroups.Count == 0)
                {
                    rule.SourceApplicationSecurityGroups = null;
                }

                if (rule.DestinationApplicationSecurityGroups != null && rule.DestinationApplicationSecurityGroups.Count == 0)
                {
                    rule.DestinationApplicationSecurityGroups = null;
                }
            }
        }

        public PSNetworkSecurityGroup ToPsNetworkSecurityGroup(NetworkSecurityGroup nsg)
        {
            var psNsg = NetworkResourceManagerProfile.Mapper.Map<PSNetworkSecurityGroup>(nsg);

            psNsg.Tag = TagsConversionHelper.CreateTagHashtable(nsg.Tags);

            return psNsg;
        }
    }
}