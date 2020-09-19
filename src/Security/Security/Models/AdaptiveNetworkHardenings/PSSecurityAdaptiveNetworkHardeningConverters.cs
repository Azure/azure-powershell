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
using Microsoft.Azure.Management.Security.Models;

namespace Microsoft.Azure.Commands.SecurityCenter.Models.AdaptiveNetworkHardening
{
    public static class PSSecurityAdaptiveNetworkHardeningsConverters
    {
        public static PSSecurityAdaptiveNetworkHardenings ConvertToPSType(this Management.Security.Models.AdaptiveNetworkHardening value)
        {
            return new PSSecurityAdaptiveNetworkHardenings()
            {
                Id = value.Id,
                Name = value.Name,
                Type = value.Type,
                Properties = new PSSecurityAdaptiveNetworkHardeningsProperties()
                {
                    RulesCalculationTime = value.RulesCalculationTime,
                    EffectiveNetworkSecurityGroups = value.EffectiveNetworkSecurityGroups.ConvertToPSType(),
                    Rules = value.Rules.ConvertToPSType()
                }
            };
        }


        public static List<PSSecurityAdaptiveNetworkHardenings> ConvertToPSType(this IEnumerable<Management.Security.Models.AdaptiveNetworkHardening> value)
        {
            return value.Select(anh => anh.ConvertToPSType()).ToList();
        }

        public static PSSecurityAdaptiveNetworkHardeningsEffectiveNetworkSecurityGroups ConvertToPSType(
            this EffectiveNetworkSecurityGroups value)
        {
            return new PSSecurityAdaptiveNetworkHardeningsEffectiveNetworkSecurityGroups()
            {
                NetworkInterface = value.NetworkInterface,
                NetworkSecurityGroups = value.NetworkSecurityGroups
            };
        }

        public static List<PSSecurityAdaptiveNetworkHardeningsEffectiveNetworkSecurityGroups> ConvertToPSType(this IEnumerable<EffectiveNetworkSecurityGroups> value)
        {
            return value.Select(effectiveNsg => effectiveNsg.ConvertToPSType()).ToList();
        }

        public static PSSecurityAdaptiveNetworkHardeningsRule ConvertToPSType(this Rule value)
        {
            return new PSSecurityAdaptiveNetworkHardeningsRule()
            {
                DestinationPort = value.DestinationPort,
                Direction = value.Direction,
                IpAddresses = value.IpAddresses,
                Name = value.Name,
                Protocols = value.Protocols
            };
        }

        public static List<PSSecurityAdaptiveNetworkHardeningsRule> ConvertToPSType(this IEnumerable<Rule> value)
        {
            return value.Select(rule => rule.ConvertToPSType()).ToList();
        }
    }
}
