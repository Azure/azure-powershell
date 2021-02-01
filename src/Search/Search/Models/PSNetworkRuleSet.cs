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

using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Azure.Management.Search.Models;

namespace Microsoft.Azure.Commands.Management.Search.Models
{
    public class PSNetworkRuleSet
    {
        public IList<PSIpRule> IpRules { get; set; }

        public static explicit operator NetworkRuleSet(PSNetworkRuleSet v)
        {
            if (v == null)
            {
                return null;
            }
            return new NetworkRuleSet(ipRules: v.IpRules.Select(ipRule => (IpRule)ipRule).ToList());
        }

        public static explicit operator PSNetworkRuleSet(NetworkRuleSet v)
        {
            if (v == null)
            {
                return null;
            }
            return new PSNetworkRuleSet()
            {
                IpRules = v.IpRules.Select(ipRule => (PSIpRule)ipRule).ToList()
            };
        }

        public static implicit operator PSNetworkRuleSet(object[] v)
        {
            if (v == null)
            {
                return null;
            }
            if (v.Any(rule => !(rule is string || rule is PSIpRule)))
            {
                throw new ArgumentException();
            }
            return new PSNetworkRuleSet()
            {
                IpRules = v.Select(ipRule => (PSIpRule)ipRule).ToList()
            };
        }
    }
}