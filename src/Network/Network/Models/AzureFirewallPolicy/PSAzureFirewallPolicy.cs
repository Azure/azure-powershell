﻿//
// Copyright (c) Microsoft.  All rights reserved.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//   http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
//

using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Net;
using Microsoft.Azure.Commands.Aks.Generated.Version2017_08_31.Models;
using Microsoft.Azure.Commands.Common;
using Microsoft.Azure.Commands.Common.Exceptions;
using Microsoft.Azure.Commands.Network.Properties;
using Microsoft.Rest;
using Newtonsoft.Json;

namespace Microsoft.Azure.Commands.Network.Models
{
    public class PSAzureFirewallPolicy : PSTopLevelResource
    {
        public PSManagedServiceIdentity Identity { get; set; }

        public string ThreatIntelMode { get; set; }

        public PSAzureFirewallPolicyThreatIntelWhitelist ThreatIntelWhitelist { get; set; }

        public Microsoft.Azure.Management.Network.Models.SubResource BasePolicy { get; set; }

        public string ProvisioningState { get; set; }

        public string Size { get; set; }

        [JsonProperty("ruleCollectionGroups")]
        public List<Microsoft.Azure.Management.Network.Models.SubResource> RuleCollectionGroups { get; set; }

        public PSAzureFirewallPolicyDnsSettings DnsSettings { get; set; }

        public PSAzureFirewallPolicySqlSetting SqlSetting { get; set; }

        public PSAzureFirewallPolicyIntrusionDetection IntrusionDetection { get; set; }

        public PSAzureFirewallPolicyTransportSecurity TransportSecurity { get; set; }

        public PSAzureFirewallPolicySku Sku { get; set; }

        public PSAzureFirewallPolicySNAT Snat { get; set; }

        public PSAzureFirewallPolicyExplicitProxy ExplicitProxy { get; set; }

        private const string IANAPrivateRanges = "IANAPrivateRanges";

        public string[] PrivateRange
        {
            get
            {
                return Snat?.PrivateRanges?.ToArray();
            }
            set
            {
                if (value != null)
                {
                    ValidatePrivateRange(value);
                    Snat = new PSAzureFirewallPolicySNAT() { PrivateRanges = value };
                }
            }
        }

        [JsonIgnore]
        public string PrivateRangeText
        {
            get { return JsonConvert.SerializeObject(PrivateRange, Formatting.Indented); }
        }

        #region Private Range Validation
        private void ValidatePrivateRange(string[] privateRange)
        {
            foreach (var ip in privateRange)
            {
                if (ip.Equals(IANAPrivateRanges, StringComparison.OrdinalIgnoreCase))
                    continue;

                if (ip.Contains("/"))
                    NetworkValidationUtils.ValidateSubnet(ip);
                else
                    NetworkValidationUtils.ValidateIpAddress(ip);
            }
        }
        #endregion
    }
}
