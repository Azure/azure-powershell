﻿// ----------------------------------------------------------------------------------
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
using System.Management.Automation;
using Microsoft.Azure.Commands.Network.Models;

namespace Microsoft.Azure.Commands.Network
{
    [Cmdlet(VerbsCommon.New, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "FirewallPolicyThreatIntelWhitelist"), OutputType(typeof(PSAzureFirewallPolicyThreatIntelWhitelist))]
    [Alias("New-AzFirewallThreatIntelWhitelistObject")]
    public class NewAzureFirewallPolicyThreatIntelWhitelistCommand : NetworkBaseCmdlet
    {
        [Parameter(
            Mandatory = false,
            HelpMessage = "The FQDNs of the Threat Intel Whitelist")]
        [ValidateNotNull]
        public string[] FQDN { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "The IP Addresses of the Threat Intel Whitelist")]
        [ValidateNotNull]
        public string[] IpAddress { get; set; }

        public override void Execute()
        {
            base.Execute();

            var threatIntelWhitelist = new PSAzureFirewallPolicyThreatIntelWhitelist
            {
                FQDNs = this.FQDN?.Select(str => str.Trim()).ToArray(),
                IpAddresses = this.IpAddress?.Select(str => str.Trim()).ToArray(),
            };
            WriteObject(threatIntelWhitelist);
        }
    }
}
