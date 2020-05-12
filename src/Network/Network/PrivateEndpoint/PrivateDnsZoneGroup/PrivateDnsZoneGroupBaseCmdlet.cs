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
using Microsoft.Azure.Management.Network;
using Microsoft.Azure.Management.Network.Models;
using System.Collections.Generic;
using System.Net;

namespace Microsoft.Azure.Commands.Network
{
    public abstract class PrivateDnsZoneGroupBaseCmdlet : NetworkBaseCmdlet
    {
        public IPrivateDnsZoneGroupsOperations PrivateDnsZoneGroupClient
        {
            get
            {
                return NetworkClient.NetworkManagementClient.PrivateDnsZoneGroups;
            }
        }

        public bool IsPrivateDnsZoneGroupPresent(string resourceGroupName, string privateEndpointName, string privateDnsZoneGroupName)
        {
            try
            {
                var group = GetPrivateDnsZoneGroup(resourceGroupName, privateEndpointName, privateDnsZoneGroupName);
                return (group != null);
            }
            catch (ErrorException exception)
            {
                if (exception.Response.StatusCode == HttpStatusCode.NotFound)
                {
                    return false;
                }
                throw;
            }
        }

        public PSPrivateDnsZoneGroup GetPrivateDnsZoneGroup(string resourceGroupName, string privateEndpointName, string privateDnsZoneGroupName)
        {
            var privateDnsZoneGroup = this.PrivateDnsZoneGroupClient.Get(resourceGroupName, privateEndpointName, privateDnsZoneGroupName);
            if(privateDnsZoneGroup == null)
            {
                return null;
            }
            var psPrivateDnsZoneGroup = ToPsPrivateDnsZoneGroup(privateDnsZoneGroup);
            return psPrivateDnsZoneGroup;
        }

        public PSPrivateDnsZoneGroup ToPsPrivateDnsZoneGroup(PrivateDnsZoneGroup privateDnsZoneGroup)
        {
            var psPrivateDnsZoneGroup = NetworkResourceManagerProfile.Mapper.Map<PSPrivateDnsZoneGroup>(privateDnsZoneGroup);
            psPrivateDnsZoneGroup.ProvisioningState = privateDnsZoneGroup.ProvisioningState;
            if(privateDnsZoneGroup.PrivateDnsZoneConfigs != null)
            {
                psPrivateDnsZoneGroup.PrivateDnsZoneConfigs = new List<PSPrivateDnsZoneConfig>();
                foreach(var config in privateDnsZoneGroup.PrivateDnsZoneConfigs)
                {
                    psPrivateDnsZoneGroup.PrivateDnsZoneConfigs.Add(ToPsPrivateDnsZoneConfig(config));
                }
            }
            return psPrivateDnsZoneGroup;
        }

        public PSPrivateDnsZoneConfig ToPsPrivateDnsZoneConfig(PrivateDnsZoneConfig privateDnsZoneConfig)
        {
            var psConfig = NetworkResourceManagerProfile.Mapper.Map<PSPrivateDnsZoneConfig>(privateDnsZoneConfig);
            return psConfig;
        }

    }
}
