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

using Microsoft.Azure.Management.Storage.Models;
using System;
using System.Collections.Generic;

namespace Microsoft.Azure.Commands.Management.Storage.Models
{
    //Wrapper of NetworkRuleSet property Bypass 
    [Flags]
    public enum PSNetWorkRuleBypassEnum
    {
        None = 0,
        Logging = 1,
        Metrics = 2,
        AzureServices = 4
    }

    //Wrapper of NetworkRuleSet property DefaultAction 
    public enum PSNetWorkRuleDefaultActionEnum
    {
        Deny = 0,
        Allow = 1
    }

    //Wrapper of NetworkRule property Action 
    public enum PSNetworkRuleActionEnum
    {
        Allow = 0
    }

    //Wrapper of NetworkRuleSet property IpRule 
    public struct PSIpRule
    {
        public PSNetworkRuleActionEnum? Action;
        public string IPAddressOrRange;
    }

    //Wrapper of NetworkRuleSet property NetworkRule 
    public struct PSVirtualNetworkRule
    {
        public PSNetworkRuleActionEnum? Action;
        public string VirtualNetworkResourceId;
        public string State;
    }

    //Wrapper of NetworkRuleSet  
    public class PSNetworkRuleSet
    {
        public PSIpRule[] IpRules { get; set; }

        public PSVirtualNetworkRule[] VirtualNetworkRules { get; set; }

        public PSNetWorkRuleBypassEnum? Bypass { get; set; }

        public PSNetWorkRuleDefaultActionEnum DefaultAction { get; set; }


        //Parse NetworkRule property Action in SDK to wrapped property PSNetworkRuleActionEnum
        public static PSNetworkRuleActionEnum? ParsePSNetworkRuleAction(Microsoft.Azure.Management.Storage.Models.Action? action)
        {
            if (action == null)
            {
                return null;
            }

            if (action.Value == Microsoft.Azure.Management.Storage.Models.Action.Allow)
            {
                return PSNetworkRuleActionEnum.Allow;
            }

            return PSNetworkRuleActionEnum.Allow;
        }


        //Parse wrapped property PSNetworkRuleActionEnum to NetworkRule rule property Action in SDK 
        public static Microsoft.Azure.Management.Storage.Models.Action? ParseStorageNetworkRuleAction(PSNetworkRuleActionEnum? action)
        {
            if (action == null)
            {
                return null;
            }

            if (action == PSNetworkRuleActionEnum.Allow)
            {
                return Microsoft.Azure.Management.Storage.Models.Action.Allow;
            }
            return Microsoft.Azure.Management.Storage.Models.Action.Allow;
        }

        //Parse NetworkRule property Bypass in SDK to wrapped property PSNetworkRuleBypassEnum
        public static PSNetWorkRuleBypassEnum? ParsePSNetworkRuleBypass(string bypass)
        {
            if (bypass == null)
            {
                return null;
            }

            PSNetWorkRuleBypassEnum returnBypass = PSNetWorkRuleBypassEnum.None;

            if (bypass.ToLower().Contains(PSNetWorkRuleBypassEnum.Logging.ToString().ToLower()))
                returnBypass = returnBypass | PSNetWorkRuleBypassEnum.Logging;
            if (bypass.ToLower().Contains(PSNetWorkRuleBypassEnum.Metrics.ToString().ToLower()))
                returnBypass = returnBypass | PSNetWorkRuleBypassEnum.Metrics;
            if (bypass.ToLower().Contains(PSNetWorkRuleBypassEnum.AzureServices.ToString().ToLower()))
                returnBypass = returnBypass | PSNetWorkRuleBypassEnum.AzureServices;

            return returnBypass;
        }

        //Parse wrapped property PSNetworkRuleBypassEnum to NetworkRule property Bypass in SDK
        public static string ParseStorageNetworkRuleBypass(PSNetWorkRuleBypassEnum? bypass)
        {
            if (bypass == null)
            {
                return null;
            }

            string returnBypass = string.Empty;

            //Build the Bypass string for input of SDK, format "[value1],[value2],...", e.g: "Metrics,AzureServices"
            if ((bypass & PSNetWorkRuleBypassEnum.Logging) == PSNetWorkRuleBypassEnum.Logging)
            {
                returnBypass += PSNetWorkRuleBypassEnum.Logging.ToString() + ",";
            }
            if ((bypass & PSNetWorkRuleBypassEnum.Metrics) == PSNetWorkRuleBypassEnum.Metrics)
            {
                returnBypass += PSNetWorkRuleBypassEnum.Metrics.ToString() + ",";
            }
            if ((bypass & PSNetWorkRuleBypassEnum.AzureServices) == PSNetWorkRuleBypassEnum.AzureServices)
            {
                returnBypass += PSNetWorkRuleBypassEnum.AzureServices.ToString() + ",";
            }

            if (returnBypass == string.Empty)
            {
                returnBypass = PSNetWorkRuleBypassEnum.None.ToString();
            }
            else
            {
                //remove the last ","
                returnBypass = returnBypass.Substring(0, returnBypass.Length - 1);
            }

            return returnBypass;
        }

        //Parse NetworkRule property DefaultAction in SDK to wrapped property PSNetworkRuleDefaultActionEnum
        public static PSNetWorkRuleDefaultActionEnum ParsePSNetworkRuleDefaultAction(DefaultAction defaultAction)
        {
            if (defaultAction == Microsoft.Azure.Management.Storage.Models.DefaultAction.Allow)
            {
                return PSNetWorkRuleDefaultActionEnum.Allow;
            }
            else
            {
                return PSNetWorkRuleDefaultActionEnum.Deny;
            }
        }

        //Parse wrapped property PSNetworkRuleDefaultActionEnum to NetworkRule property DefaultAction in SDK
        public static DefaultAction ParseStorageNetworkRuleDefaultAction(PSNetWorkRuleDefaultActionEnum defaultAction)
        {
            if (defaultAction == PSNetWorkRuleDefaultActionEnum.Allow)
            {
                return Microsoft.Azure.Management.Storage.Models.DefaultAction.Allow;
            }
            else
            {
                return Microsoft.Azure.Management.Storage.Models.DefaultAction.Deny;
            }
        }

        //Parse single NetworkRule IpRule in SDK to wrapped property PSIpRule
        public static PSIpRule ParsePSNetworkRuleIPRule(IPRule ipRule)
        {
            PSIpRule returnRule = new PSIpRule();
            returnRule.Action = ParsePSNetworkRuleAction(ipRule.Action);
            returnRule.IPAddressOrRange = ipRule.IPAddressOrRange;
            return returnRule;
        }

        //Parse wrapped property PSIpRule to single NetworkRule IpRule in SDK
        public static IPRule ParseStorageNetworkRuleIPRule(PSIpRule ipRule)
        {
            IPRule returnRule = new IPRule();
            returnRule.Action = ParseStorageNetworkRuleAction(ipRule.Action);
            returnRule.IPAddressOrRange = ipRule.IPAddressOrRange;
            return returnRule;
        }

        //Parse single NetworkRule VirtualNetworkRule in SDK to wrapped property PSVirtualNetworkRule
        public static PSVirtualNetworkRule ParsePSNetworkRuleVirtualNetworkRule(VirtualNetworkRule virtualNetworkRule)
        {
            PSVirtualNetworkRule returnRule = new PSVirtualNetworkRule();
            returnRule.Action = ParsePSNetworkRuleAction(virtualNetworkRule.Action);
            returnRule.VirtualNetworkResourceId = virtualNetworkRule.VirtualNetworkResourceId;
            returnRule.State = virtualNetworkRule.State.ToString();

            return returnRule;
        }

        //Parse wrapped property PSVirtualNetworkRule to single NetworkRule VirtualNetworkRule in SDK
        public static VirtualNetworkRule ParseStorageNetworkRuleVirtualNetworkRule(PSVirtualNetworkRule virtualNetworkRule)
        {
            VirtualNetworkRule returnRule = new VirtualNetworkRule();
            returnRule.Action = ParseStorageNetworkRuleAction(virtualNetworkRule.Action);
            returnRule.VirtualNetworkResourceId = virtualNetworkRule.VirtualNetworkResourceId;

            return returnRule;
        }

        //Parse Storage NetworkRule object in SDK to wrapped PSNetworkRuleSet
        public static PSNetworkRuleSet ParsePSNetworkRule(NetworkRuleSet rules)
        {
            if (rules == null)
            {
                return null;
            }
            PSNetworkRuleSet returnRules = new PSNetworkRuleSet();
            returnRules.Bypass = ParsePSNetworkRuleBypass(rules.Bypass);
            returnRules.DefaultAction = ParsePSNetworkRuleDefaultAction(rules.DefaultAction);

            List<PSIpRule> ipRuleList = new List<PSIpRule>();
            if (rules.IpRules != null)
            {
                foreach (var ipRule in rules.IpRules)
                {
                    ipRuleList.Add(ParsePSNetworkRuleIPRule(ipRule));
                }
                returnRules.IpRules = ipRuleList.ToArray();
            }

            List<PSVirtualNetworkRule> virtualNetworkList = new List<PSVirtualNetworkRule>();
            if (rules.VirtualNetworkRules != null)
            {
                foreach (var virtualNetworkRule in rules.VirtualNetworkRules)
                {
                    virtualNetworkList.Add(ParsePSNetworkRuleVirtualNetworkRule(virtualNetworkRule));
                }
                returnRules.VirtualNetworkRules = virtualNetworkList.ToArray();
            }

            return returnRules;
        }

        //Parse wrapped PSNetworkRuleSet to storage NetworkRule object in SDK
        public static NetworkRuleSet ParseStorageNetworkRule(PSNetworkRuleSet rules)
        {
            if (rules == null)
            {
                return null;
            }
            NetworkRuleSet returnRules = new NetworkRuleSet();
            returnRules.Bypass = ParseStorageNetworkRuleBypass(rules.Bypass);
            returnRules.DefaultAction = ParseStorageNetworkRuleDefaultAction(rules.DefaultAction);

            List<IPRule> ipRuleList = new List<IPRule>();
            if (rules.IpRules != null)
            {
                foreach (var ipRule in rules.IpRules)
                {
                    ipRuleList.Add(ParseStorageNetworkRuleIPRule(ipRule));
                }
                returnRules.IpRules = ipRuleList.ToArray();
            }

            List<VirtualNetworkRule> virtualNetworkList = new List<VirtualNetworkRule>();
            if (rules.VirtualNetworkRules != null)
            {
                foreach (var virtualNetworkRule in rules.VirtualNetworkRules)
                {
                    virtualNetworkList.Add(ParseStorageNetworkRuleVirtualNetworkRule(virtualNetworkRule));
                }
                returnRules.VirtualNetworkRules = virtualNetworkList.ToArray();
            }

            return returnRules;
        }
    }
}
