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

using System.Management.Automation;
using Microsoft.Azure.Commands.NetworkResourceProvider.Models;

namespace Microsoft.Azure.Commands.NetworkResourceProvider
{
    [Cmdlet(VerbsCommon.New, "AzureNetworkSecurityRuleConfig"), OutputType(typeof(PSSecurityRule))]
    public class NewAzureNetworkSecurityRuleConfigCmdlet : CommonAzureNetworkSecurityRuleConfigCmdlet
    {
        [Parameter(
            Mandatory = true,
            HelpMessage = "The name of the rule")]
        [ValidateNotNullOrEmpty]
        public override string Name { get; set; }

        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();

            var rule = new PSSecurityRule();

            rule.Name = this.Name;
            rule.Properties = new PSSecurityRuleProperties();
            rule.Properties.Description = this.Description;
            rule.Properties.Protocol = this.Protocol;
            rule.Properties.SourcePortRange = this.SourcePortRange;
            rule.Properties.DestinationPortRange = this.DestinationPortRange;
            rule.Properties.SourceAddressPrefix = this.SourceAddressPrefix;
            rule.Properties.DestinationAddressPrefix = this.DestinationAddressPrefix;
            rule.Properties.Access = this.Access;
            rule.Properties.Priority = this.Priority;
            rule.Properties.Direction = this.Direction;

            WriteObject(rule);
        }
    }
}
