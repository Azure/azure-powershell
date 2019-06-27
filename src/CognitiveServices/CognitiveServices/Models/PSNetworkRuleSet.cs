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

using Microsoft.WindowsAzure.Commands.Common.Attributes;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using CognitiveServicesModels = Microsoft.Azure.Management.CognitiveServices.Models;

namespace Microsoft.Azure.Commands.Management.CognitiveServices.Models
{
    public class PSNetworkRuleSet
    {
        [Ps1Xml(Label = "DefaultAction", Target = ViewControl.List, Position = 0)]
        [JsonProperty("defaultAction")]
        [JsonConverter(typeof(StringEnumConverter))]
        public PSNetWorkRuleDefaultActionEnum DefaultAction { get; set; }

        [Ps1Xml(Label = "IpRules", Target = ViewControl.List, ScriptBlock = "if (($_.ipRules -ne $null) -and ($_.ipRules.Count -ne 0)) {\"[\" + $_.ipRules[0].IPAddressOrRange + \",...]\"} else {$null}", Position = 1)]
        [JsonProperty("ipRules")]
        public PSIpRule[] IpRules { get; set; }

        [Ps1Xml(Label = "VirtualNetworkRules", Target = ViewControl.List, ScriptBlock = "if ($_.virtualNetworkRules[0] -ne $null) {\"[\" + $_.virtualNetworkRules[0].VirtualNetworkResourceId + \",...]\"} else {$null}", Position = 2)]
        [JsonProperty("virtualNetworkRules")]
        public PSVirtualNetworkRule[] VirtualNetworkRules { get; set; }

        public static PSNetworkRuleSet Create(CognitiveServicesModels.NetworkRuleSet networkRuleSet)
        {
            var result = new PSNetworkRuleSet();

            if (networkRuleSet.DefaultAction != null)
            {
                result.DefaultAction = (PSNetWorkRuleDefaultActionEnum)Enum.Parse(typeof(PSNetWorkRuleDefaultActionEnum), networkRuleSet.DefaultAction);
            }
            else
            {
                result.DefaultAction = PSNetWorkRuleDefaultActionEnum.Deny;
            }


            var ipRules = new List<PSIpRule>();
            if (networkRuleSet.IpRules != null)
            {
                foreach (var ipRule in networkRuleSet.IpRules)
                {
                    ipRules.Add(PSIpRule.Create(ipRule));
                }
            }
            result.IpRules = ipRules.ToArray();

            var virtualNetworkRules = new List<PSVirtualNetworkRule>();
            if (networkRuleSet.VirtualNetworkRules != null)
            {
                foreach (var virtualNetworkRule in networkRuleSet.VirtualNetworkRules)
                {
                    virtualNetworkRules.Add(PSVirtualNetworkRule.Create(virtualNetworkRule));
                }
            }
            result.VirtualNetworkRules = virtualNetworkRules.ToArray();

            return result;
        }

        public CognitiveServicesModels.NetworkRuleSet ToNetworkRuleSet()
        {
            var result = new CognitiveServicesModels.NetworkRuleSet();
            result.DefaultAction = this.DefaultAction.ToString();

            result.IpRules = new List<CognitiveServicesModels.IpRule>();
            if (this.IpRules != null)
            {
                foreach (var ipRule in this.IpRules)
                {
                    result.IpRules.Add(ipRule.ToIpRule());
                }
            }

            result.VirtualNetworkRules = new List<CognitiveServicesModels.VirtualNetworkRule>();
            if (this.VirtualNetworkRules != null)
            {
                foreach (var virtualNetworkRule in this.VirtualNetworkRules)
                {
                    result.VirtualNetworkRules.Add(virtualNetworkRule.ToVirtualNetworkRule());
                }
            }

            return result;
        }

        public void AddIpRule(string ipAddress)
        {
            if (this.IpRules == null)
            {
                IpRules = new PSIpRule[]
                {
                    new PSIpRule()
                    {
                        IpAddress = ipAddress
                    }
                };
            } else
            {
                var tmp = new List<PSIpRule>(IpRules);
                tmp.Add(new PSIpRule()
                {
                    IpAddress = ipAddress
                });
                IpRules = tmp.ToArray();
            }
        }
        public void AddVirtualNetworkRule(string vnetResourceId)
        {
            if (this.VirtualNetworkRules == null)
            {
                VirtualNetworkRules = new PSVirtualNetworkRule[]
                {
                    new PSVirtualNetworkRule()
                    {
                        Id = vnetResourceId
                    }
                };
            }
            else
            {
                var tmp = new List<PSVirtualNetworkRule>(VirtualNetworkRules);
                tmp.Add(new PSVirtualNetworkRule()
                {
                    Id = vnetResourceId
                });
                VirtualNetworkRules = tmp.ToArray();
            }
        }
    }

    public class PSIpRule
    {
        /// <summary>
        /// IP Address, could be IP (e.g. 123.4.5.6) or CIDR (123.4.5.6/24)
        /// </summary>
        [JsonProperty("value")]
        public string IpAddress { get; set; }

        public static PSIpRule Create(CognitiveServicesModels.IpRule ipRule)
        {
            var result = new PSIpRule();
            result.IpAddress = ipRule.Value;
            return result;
        }

        public CognitiveServicesModels.IpRule ToIpRule()
        {
            var result = new CognitiveServicesModels.IpRule();
            result.Value = this.IpAddress;
            return result;
        }
    }

    [JsonObject(NamingStrategyType = typeof(CamelCaseNamingStrategy))]
    public class PSVirtualNetworkRule
    {
        /// <summary>
        /// This is Azure Resource Id of Vnet/Subnet, e.g.
        /// </summary>
        [JsonProperty("id")]
        public string Id { get; set; }

        /// <summary>
        /// Succeeded, NetworkSourceDeleted etc.
        /// </summary>
        [JsonProperty("state")]
        public string State { get; set; }

        /// <summary>
        /// Ignore missing vnet service endpoint. 
        /// Used by RP while validating and updating TTCs
        /// </summary>
        [JsonProperty("ignoreMissingVnetServiceEndpoint")]
        public bool IgnoreMissingVnetServiceEndpoint { get; set; } = true;

        public static PSVirtualNetworkRule Create(CognitiveServicesModels.VirtualNetworkRule virtualNetworkRule)
        {
            var result = new PSVirtualNetworkRule();
            result.Id = virtualNetworkRule.Id;
            result.State = virtualNetworkRule.State;
            result.IgnoreMissingVnetServiceEndpoint = virtualNetworkRule.IgnoreMissingVnetServiceEndpoint == null?true:virtualNetworkRule.IgnoreMissingVnetServiceEndpoint.Value;
            return result;
        }

        public CognitiveServicesModels.VirtualNetworkRule ToVirtualNetworkRule()
        {
            var result = new CognitiveServicesModels.VirtualNetworkRule();
            result.Id = this.Id;
            result.State = this.State;
            result.IgnoreMissingVnetServiceEndpoint = this.IgnoreMissingVnetServiceEndpoint;
            return result;
        }
    }


    /// <summary>
    /// Network ACLs default action enumeration.
    /// </summary>
    public enum PSNetWorkRuleDefaultActionEnum
    {
        /// <summary>
        /// Seleted networks.
        /// </summary>
        Deny,
        /// <summary>
        /// All networks.
        /// </summary>
        Allow
    }
}
