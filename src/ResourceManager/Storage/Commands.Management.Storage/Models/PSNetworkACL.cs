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
    //Wrapper of NetworkACL property Bypass 
    [Flags]
    public enum PSNetWorkACLBypassEnum
    {
        None = 0,
        Logging = 1,
        Metrics = 2,
        AzureServices = 4
    }

    //Wrapper of NetworkACL property DefaultAction 
    public enum PSNetWorkACLDefaultActionEnum
    {
        Deny = 0,
        Allow = 1
    }

    //Wrapper of NetworkACL Rule property Action 
    public enum PSNetWorkACLRuleActionEnum
    {
        Allow = 0
    }

    //Wrapper of NetworkACL property IpRule 
    public struct PSIpRule
    {
        public PSNetWorkACLRuleActionEnum? Action;
        public string IPAddressOrRange;
    }

    //Wrapper of NetworkACL property NetworkRule 
    public struct PSVirtualNetworkRule
    {
        public PSNetWorkACLRuleActionEnum? Action;
        public string VirtualNetworkResourceId;
        public string State;
    }

    //Wrapper of NetworkACL  
    public class PSNetworkACL
    {
        public PSIpRule[] IpRules { get; set; }

        public PSVirtualNetworkRule[] VirtualNetworkRules { get; set; }

        public PSNetWorkACLBypassEnum? Bypass { get; set; }

        public PSNetWorkACLDefaultActionEnum DefaultAction { get; set; }


        //Parse NetworkACL rule property Action in SDK to wrapped property PSNetWorkACLRuleActionEnum
        public static PSNetWorkACLRuleActionEnum? ParsePSNetworkACLRuleAction(Microsoft.Azure.Management.Storage.Models.Action? action)
        {
            if (action == null)
            {
                return null;
            }

            if (action.Value == Microsoft.Azure.Management.Storage.Models.Action.Allow)
            {
                return PSNetWorkACLRuleActionEnum.Allow;
            }

            return PSNetWorkACLRuleActionEnum.Allow;
        }


        //Parse wrapped property PSNetWorkACLRuleActionEnum to NetworkACL rule property Action in SDK 
        public static Microsoft.Azure.Management.Storage.Models.Action? ParseStorageNetworkACLRuleAction(PSNetWorkACLRuleActionEnum? action)
        {
            if (action == null)
            {
                return null;
            }

            if (action == PSNetWorkACLRuleActionEnum.Allow)
            {
                return Microsoft.Azure.Management.Storage.Models.Action.Allow;
            }
            return Microsoft.Azure.Management.Storage.Models.Action.Allow;
        }

        //Parse NetworkACL property Bypass in SDK to wrapped property PSNetWorkACLBypassEnum
        public static PSNetWorkACLBypassEnum? ParsePSNetworkACLBypass(string bypass)
        {
            if (bypass == null)
            {
                return null;
            }

            PSNetWorkACLBypassEnum returnBypass = PSNetWorkACLBypassEnum.None;

            if (bypass.ToLower().Contains(PSNetWorkACLBypassEnum.Logging.ToString().ToLower()))
                returnBypass = returnBypass | PSNetWorkACLBypassEnum.Logging;
            if (bypass.ToLower().Contains(PSNetWorkACLBypassEnum.Metrics.ToString().ToLower()))
                returnBypass = returnBypass | PSNetWorkACLBypassEnum.Metrics;
            if (bypass.ToLower().Contains(PSNetWorkACLBypassEnum.AzureServices.ToString().ToLower()))
                returnBypass = returnBypass | PSNetWorkACLBypassEnum.AzureServices;

            return returnBypass;
        }

        //Parse wrapped property PSNetWorkACLBypassEnum to NetworkACL property Bypass in SDK
        public static string ParseStorageNetworkACLBypass(PSNetWorkACLBypassEnum? bypass)
        {
            if (bypass == null)
            {
                return null;
            }

            string returnBypass = string.Empty;

            //Build the Bypass string for input of SDK, format "[value1],[value2],...", e.g: "Metrics,AzureServices"
            if ((bypass & PSNetWorkACLBypassEnum.Logging) == PSNetWorkACLBypassEnum.Logging)
            {
                returnBypass += PSNetWorkACLBypassEnum.Logging.ToString() + ",";
            }
            if ((bypass & PSNetWorkACLBypassEnum.Metrics) == PSNetWorkACLBypassEnum.Metrics)
            {
                returnBypass += PSNetWorkACLBypassEnum.Metrics.ToString() + ",";
            }
            if ((bypass & PSNetWorkACLBypassEnum.AzureServices) == PSNetWorkACLBypassEnum.AzureServices)
            {
                returnBypass += PSNetWorkACLBypassEnum.AzureServices.ToString() + ",";
            }

            if (returnBypass == string.Empty)
            {
                returnBypass = PSNetWorkACLBypassEnum.None.ToString();
            }
            else
            {
                //remove the last ","
                returnBypass = returnBypass.Substring(0, returnBypass.Length - 1);
            }

            return returnBypass;
        }

        //Parse NetworkACL property DefaultAction in SDK to wrapped property PSNetWorkACLDefaultActionEnum
        public static PSNetWorkACLDefaultActionEnum ParsePSNetworkACLDefaultAction(DefaultAction defaultAction)
        {
            if (defaultAction == Microsoft.Azure.Management.Storage.Models.DefaultAction.Allow)
            {
                return PSNetWorkACLDefaultActionEnum.Allow;
            }
            else
            {
                return PSNetWorkACLDefaultActionEnum.Deny;
            }
        }

        //Parse wrapped property PSNetWorkACLDefaultActionEnum to NetworkACL property DefaultAction in SDK
        public static DefaultAction ParseStorageNetworkACLDefaultAction(PSNetWorkACLDefaultActionEnum defaultAction)
        {
            if (defaultAction == PSNetWorkACLDefaultActionEnum.Allow)
            {
                return Microsoft.Azure.Management.Storage.Models.DefaultAction.Allow;
            }
            else
            {
                return Microsoft.Azure.Management.Storage.Models.DefaultAction.Deny;
            }
        }

        //Parse single NetworkACL IpRule in SDK to wrapped property PSIpRule
        public static PSIpRule ParsePSNetworkACLIPRule(IPRule ipRule)
        {
            PSIpRule returnRule = new PSIpRule();
            returnRule.Action = ParsePSNetworkACLRuleAction(ipRule.Action);
            returnRule.IPAddressOrRange = ipRule.IPAddressOrRange;
            return returnRule;
        }

        //Parse wrapped property PSIpRule to single NetworkACL IpRule in SDK
        public static IPRule ParseStorageNetworkACLIPRule(PSIpRule ipRule)
        {
            IPRule returnRule = new IPRule();
            returnRule.Action = ParseStorageNetworkACLRuleAction(ipRule.Action);
            returnRule.IPAddressOrRange = ipRule.IPAddressOrRange;
            return returnRule;
        }

        //Parse single NetworkACL VirtualNetworkRule in SDK to wrapped property PSVirtualNetworkRule
        public static PSVirtualNetworkRule ParsePSNetworkACLVirtualNetworkRule(VirtualNetworkRule virtualNetworkRule)
        {
            PSVirtualNetworkRule returnRule = new PSVirtualNetworkRule();
            returnRule.Action = ParsePSNetworkACLRuleAction(virtualNetworkRule.Action);
            returnRule.VirtualNetworkResourceId = virtualNetworkRule.VirtualNetworkResourceId;
            returnRule.State = virtualNetworkRule.State.ToString();

            return returnRule;
        }

        //Parse wrapped property PSVirtualNetworkRule to single NetworkACL VirtualNetworkRule in SDK
        public static VirtualNetworkRule ParseStorageNetworkACLVirtualNetworkRule(PSVirtualNetworkRule virtualNetworkRule)
        {
            VirtualNetworkRule returnRule = new VirtualNetworkRule();
            returnRule.Action = ParseStorageNetworkACLRuleAction(virtualNetworkRule.Action);
            returnRule.VirtualNetworkResourceId = virtualNetworkRule.VirtualNetworkResourceId;

            return returnRule;
        }

        //Parse NetworkACL object in SDK to wrapped PSNetworkACL
        public static PSNetworkACL ParsePSNetworkACL(StorageNetworkAcls rules)
        {
            if (rules == null)
            {
                return null;
            }
            PSNetworkACL returnRules = new PSNetworkACL();
            returnRules.Bypass = ParsePSNetworkACLBypass(rules.Bypass);
            returnRules.DefaultAction = ParsePSNetworkACLDefaultAction(rules.DefaultAction);

            List<PSIpRule> ipRuleList = new List<PSIpRule>();
            if (rules.IpRules != null)
            {
                foreach (var ipRule in rules.IpRules)
                {
                    ipRuleList.Add(ParsePSNetworkACLIPRule(ipRule));
                }
                returnRules.IpRules = ipRuleList.ToArray();
            }

            List<PSVirtualNetworkRule> virtualNetworkList = new List<PSVirtualNetworkRule>();
            if (rules.VirtualNetworkRules != null)
            {
                foreach (var virtualNetworkRule in rules.VirtualNetworkRules)
                {
                    virtualNetworkList.Add(ParsePSNetworkACLVirtualNetworkRule(virtualNetworkRule));
                }
                returnRules.VirtualNetworkRules = virtualNetworkList.ToArray();
            }

            return returnRules;
        }

        //Parse wrapped PSNetworkACL to NetworkACL object in SDK
        public static StorageNetworkAcls ParseStorageNetworkACL(PSNetworkACL rules)
        {
            if (rules == null)
            {
                return null;
            }
            StorageNetworkAcls returnRules = new StorageNetworkAcls();
            returnRules.Bypass = ParseStorageNetworkACLBypass(rules.Bypass);
            returnRules.DefaultAction = ParseStorageNetworkACLDefaultAction(rules.DefaultAction);

            List<IPRule> ipRuleList = new List<IPRule>();
            if (rules.IpRules != null)
            {
                foreach (var ipRule in rules.IpRules)
                {
                    ipRuleList.Add(ParseStorageNetworkACLIPRule(ipRule));
                }
                returnRules.IpRules = ipRuleList.ToArray();
            }

            List<VirtualNetworkRule> virtualNetworkList = new List<VirtualNetworkRule>();
            if (rules.VirtualNetworkRules != null)
            {
                foreach (var virtualNetworkRule in rules.VirtualNetworkRules)
                {
                    virtualNetworkList.Add(ParseStorageNetworkACLVirtualNetworkRule(virtualNetworkRule));
                }
                returnRules.VirtualNetworkRules = virtualNetworkList.ToArray();
            }

            return returnRules;
        }
    }
}
