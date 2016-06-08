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

using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.WindowsAzure.Management.Network.Models;

namespace Microsoft.WindowsAzure.Commands.ServiceManagement.Network.NetworkSecurityGroup.Model
{
    public class NetworkSecurityGroupWithRules : SimpleNetworkSecurityGroup
    {
        private List<NetworkSecurityRule> rules = new List<NetworkSecurityRule>();

        public IEnumerable<NetworkSecurityRule> Rules
        {
            get { return this.rules; }
            set { this.rules = value.ToList(); }
        }

        public NetworkSecurityGroupWithRules(NetworkSecurityGroupGetResponse networkSecurityGroupAsGetResponse)
            : base(networkSecurityGroupAsGetResponse)
        {
            Mapper.CreateMap<Microsoft.WindowsAzure.Management.Network.Models.NetworkSecurityRule, NetworkSecurityRule>();
            if (networkSecurityGroupAsGetResponse.Rules != null)
            {
                rules.AddRange(networkSecurityGroupAsGetResponse.Rules.Select(Mapper.Map<NetworkSecurityRule>));
            }
        }
    }
}
