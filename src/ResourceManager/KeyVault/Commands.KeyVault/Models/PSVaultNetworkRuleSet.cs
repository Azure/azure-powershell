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

namespace Microsoft.Azure.Commands.KeyVault.Models
{
    public enum PSNetWorkRuleDefaultActionEnum { Allow = 0, Deny }

    public enum PSNetWorkRuleBypassEnum { None = 0, AzureServices }

    public class PSVaultNetworkRuleSet
    {
        public PSVaultNetworkRuleSet()
            : this(PSNetWorkRuleDefaultActionEnum.Allow, PSNetWorkRuleBypassEnum.AzureServices, null, null)
        {
        }

        public PSVaultNetworkRuleSet(
            PSNetWorkRuleDefaultActionEnum defaultAction,
            PSNetWorkRuleBypassEnum bypass,
            IList<string> ipAddressRanges,
            IList<string> virtualNetworkResourceId)
        {
            this.DefaultAction = defaultAction;
            this.Bypass = bypass;
            this.IpAddressRanges = ipAddressRanges;
            this.VirtualNetworkResourceIds = virtualNetworkResourceId;
        }

        public PSNetWorkRuleDefaultActionEnum DefaultAction { get; private set; }

        public PSNetWorkRuleBypassEnum Bypass { get; private set; }

        public IList<string> IpAddressRanges { get; private set; }

        public string IpAddressRangesText
        {
            get
            {
                if (this.IpAddressRanges != null && this.IpAddressRanges.Count > 0)
                    return string.Join(", ", IpAddressRanges);
                else
                    return string.Empty;
            }
        }

        public IList<string> VirtualNetworkResourceIds { get; private set; }

        public string VirtualNetworkResourceIdsText
        {
            get
            {
                if (this.VirtualNetworkResourceIds != null && this.VirtualNetworkResourceIds.Count > 0)
                    return string.Join(", ", this.VirtualNetworkResourceIds);
                else
                    return string.Empty;
            }
        }
    }
}
