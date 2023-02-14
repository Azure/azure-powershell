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

using Microsoft.Azure.Management.ContainerRegistry.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;

namespace Microsoft.Azure.Commands.ContainerRegistry.Models
{
    public class PSNetworkRuleSet
    {
        public PSNetworkRuleSet(string defaultAction, IList<PSVirtualNetworkRule> virtualNetworkRules = default(IList<PSVirtualNetworkRule>), IList<PSIPRule> ipRules = default(IList<PSIPRule>))
        {
            DefaultAction = defaultAction;
            VirtualNetworkRules = virtualNetworkRules;
            IpRules = ipRules;
        }

        public PSNetworkRuleSet(string defualtAction, IList<IPSNetworkRule> networkRules = default(IList<IPSNetworkRule>))
        {
            DefaultAction = defualtAction;
            AddNetworkRules(networkRules);
        }

        public PSNetworkRuleSet(NetworkRuleSet set)
        {
            DefaultAction = set?.DefaultAction;
            VirtualNetworkRules = set?.VirtualNetworkRules?.Select(x => new PSVirtualNetworkRule(x)).ToList();
            IpRules = set?.IpRules?.Select(x => new PSIPRule(x)).ToList();
        }

        public string DefaultAction { get; set; }

        public IList<PSVirtualNetworkRule> VirtualNetworkRules { get; set; }

        public IList<PSIPRule> IpRules { get; set; }

        public NetworkRuleSet GetNetworkRuleSet()
        {
            return new NetworkRuleSet {
                DefaultAction = DefaultAction,
                VirtualNetworkRules = VirtualNetworkRules?.Select(x => x.GetVirtualNetworkRule()).ToList(),
                IpRules = IpRules?.Select(x => x.GetIPRule()).ToList()
            };
        }

        public void AddNetworkRules(IList<IPSNetworkRule> networkRules)
        {
            if (networkRules == null)
            {
                return;
            }

            VirtualNetworkRules = VirtualNetworkRules ?? new List<PSVirtualNetworkRule>();
            IpRules = IpRules ?? new List<PSIPRule>();

            foreach (IPSNetworkRule rule in networkRules)
            {
                switch (rule.NetworkRuleType)
                {
                    case "VirtualNetworkRule":                        
                        VirtualNetworkRules.Add((PSVirtualNetworkRule)rule);
                        break;
                    case "IPRule":
                        IpRules.Add((PSIPRule)rule);
                        break;
                    default:
                        throw new PSArgumentException("Invalid network rule type");
                }
            }
        }
    }
}
