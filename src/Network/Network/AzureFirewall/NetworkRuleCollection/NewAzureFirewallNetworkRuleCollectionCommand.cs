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
using System.Management.Automation;
using Microsoft.Azure.Commands.Network.Models;
using MNM = Microsoft.Azure.Management.Network.Models;

namespace Microsoft.Azure.Commands.Network
{

    [Cmdlet(VerbsCommon.New, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "FirewallNetworkRuleCollection", SupportsShouldProcess = true), OutputType(typeof(PSAzureFirewallNetworkRuleCollection))]
    public class NewAzureFirewallNetworkRuleCollectionCommand : NetworkBaseCmdlet
    {
        [Parameter(
            Mandatory = true,
            HelpMessage = "The name of the Network Rule Collection")]
        [ValidateNotNullOrEmpty]
        public virtual string Name { get; set; }

        [Parameter(
            Mandatory = true,
            HelpMessage = "The priority of the rule collection")]
        [ValidateRange(100, 65000)]
        public uint Priority { get; set; }

        [Parameter(
            Mandatory = true,
            HelpMessage = "The list of network rules")]
        [ValidateNotNullOrEmpty]
        public PSAzureFirewallNetworkRule[] Rule { get; set; }

        [Parameter(
            Mandatory = true,
            HelpMessage = "The type of the rule action")]
        [ValidateNotNullOrEmpty]
        [ValidateSet(
            MNM.AzureFirewallRCActionType.Allow,
            MNM.AzureFirewallRCActionType.Deny,
            IgnoreCase = false)]
        public string ActionType { get; set; }

        public override void Execute()
        {
            base.Execute();
            
            var networkRuleCollection = new PSAzureFirewallNetworkRuleCollection
            {
                Name = this.Name,
                Priority = this.Priority,
                Rules = this.Rule?.ToList(),
                Action = new PSAzureFirewallRCAction { Type = ActionType }
            };

            WriteObject(networkRuleCollection);
        }
    }
}
