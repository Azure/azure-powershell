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

namespace Microsoft.Azure.Commands.Network
{
    using AutoMapper;
    using Microsoft.Azure.Commands.Network.Models;
    using Microsoft.Azure.Commands.ResourceManager.Common.Tags;
    using Microsoft.Azure.Management.Network;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Management.Automation;
    using System.Net;
    using MNM = Microsoft.Azure.Management.Network.Models;

    public class VpnServerConfigurationPolicyGroupBaseCmdlet : VpnServerConfigurationBaseCmdlet
    {
        public IVpnServerConfigurationPolicyGroupsOperations VpnServerConfigurationPolicyGroupClient
        {
            get
            {
                return NetworkClient.NetworkManagementClient.VpnServerConfigurationPolicyGroups;
            }
        }

        public PSVpnServerConfigurationPolicyGroup ToPsVpnServerConfigurationPolicyGroup(Management.Network.Models.VpnServerConfigurationPolicyGroup vpnServerConfigurationPolicyGroup)
        {
            return NetworkResourceManagerProfile.Mapper.Map<PSVpnServerConfigurationPolicyGroup>(vpnServerConfigurationPolicyGroup);
        }

        public PSVpnServerConfigurationPolicyGroup GetVpnServerConfigurationPolicyGroup(string resourceGroupName, string parentVpnServerConfigurationName, string name)
        {
            var vpnServerConfigurationPolicyGroup = this.VpnServerConfigurationPolicyGroupClient.Get(resourceGroupName, parentVpnServerConfigurationName, name);
            return this.ToPsVpnServerConfigurationPolicyGroup(vpnServerConfigurationPolicyGroup);
        }

        public List<PSVpnServerConfigurationPolicyGroup> ListVpnServerConfigurationPolicyGroups(string resourceGroupName, string parentVpnServerConfigurationName)
        {
            List<PSVpnServerConfigurationPolicyGroup> vpnServerConfigurationPolicyGroupsToReturn = new List<PSVpnServerConfigurationPolicyGroup>();
            var vpnServerConfiguration = this.GetVpnServerConfiguration(resourceGroupName, parentVpnServerConfigurationName);

            if (vpnServerConfiguration != null)
            {
                foreach (MNM.VpnServerConfigurationPolicyGroup vpnServerConfigurationPolicyGroup in vpnServerConfiguration.ConfigurationPolicyGroups)
                {
                    vpnServerConfigurationPolicyGroupsToReturn.Add(ToPsVpnServerConfigurationPolicyGroup(vpnServerConfigurationPolicyGroup));
                }
            }

            return vpnServerConfigurationPolicyGroupsToReturn;
        }

        public bool IsVpnServerConfigurationPolicyGroupPresent(string resourceGroupName, string parentVpnServerConfigurationName, string name)
        {
            return NetworkBaseCmdlet.IsResourcePresent(() => { GetVpnServerConfigurationPolicyGroup(resourceGroupName, parentVpnServerConfigurationName, name); });
        }

        public PSVpnServerConfigurationPolicyGroup CreateOrUpdateVpnServerConfigurationPolicyGroup(string resourceGroupName, string parentVpnServerConfigurationName, string name, PSVpnServerConfigurationPolicyGroup vpnServerConfigurationPolicyGroup, Hashtable tags)
        {
            var vpnServerConfigurationPolicyGroupModel = NetworkResourceManagerProfile.Mapper.Map<MNM.VpnServerConfigurationPolicyGroup>(vpnServerConfigurationPolicyGroup);
            vpnServerConfigurationPolicyGroupModel.Tags = TagsConversionHelper.CreateTagDictionary(tags, validate: true);

            var vpnServerConfigurationPolicyGroupCreatedOrUpdated = this.VpnServerConfigurationPolicyGroupClient.CreateOrUpdate(resourceGroupName, parentVpnServerConfigurationName, name, vpnServerConfigurationPolicyGroupModel);
            PSVpnServerConfigurationPolicyGroup vpnServerConfigurationPolicyGroupToReturn = this.ToPsVpnServerConfigurationPolicyGroup(vpnServerConfigurationPolicyGroupCreatedOrUpdated);
            //vpnServerConfigurationPolicyGroupToReturn.ResourceGroupName = resourceGroupName;

            return vpnServerConfigurationPolicyGroupToReturn;
        }
    }
}
