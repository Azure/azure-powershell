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
using Microsoft.Azure.Management.Network;
using Newtonsoft.Json;
using Microsoft.Rest.Azure;
using Microsoft.Rest.Serialization;
using System.IO;
using Newtonsoft.Json.Linq;

namespace Microsoft.Azure.Commands.Network
{
    [Cmdlet(VerbsCommon.New, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "FirewallPolicyRuleGroup", SupportsShouldProcess = true), OutputType(typeof(PSAzureFirewallPolicyRuleGroup))]
    public class NewAzureFirewallPolicyRuleGroupCommand : AzureFirewallPolicyRuleGroupBaseCmdlet
    {
        [Parameter(
            Mandatory = true,
            HelpMessage = "The name of the Rule Group")]
        [ValidateNotNullOrEmpty]
        public virtual string Name { get; set; }

        [Parameter(
            Mandatory = true,
            HelpMessage = "The priority of the rule group")]
        [ValidateRange(100, 65000)]
        public uint Priority { get; set; }

        [Parameter(
            Mandatory = true,
            HelpMessage = "The list of rules")]
        [ValidateNotNullOrEmpty]
        public PSAzureFirewallPolicyBaseRule[] Rule { get; set; }

        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The resource group name.")]
        [ValidateNotNullOrEmpty]
        public virtual string ResourceGroupName { get; set; }

        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "location.")]
        [ValidateNotNullOrEmpty]
        public virtual string Location { get; set; }

        [Parameter(
                   Mandatory = true,
                   ValueFromPipelineByPropertyName = true,
                   HelpMessage = "Firewall Policy.")]
        [ValidateNotNullOrEmpty]
        public PSAzureFirewallPolicy AzureFirewallPolicy { get; set; }

        public override void Execute()
        {
            base.Execute();

            var ruleGroup = new PSAzureFirewallPolicyRuleGroup
            {
                priority = this.Priority,
                rules = this.Rule?.ToList(),
            };

            var rcWrapper = new PSAzureFirewallPolicyRuleGroupWrapper
            {
                name = this.Name,
                properties = ruleGroup,
                location = AzureFirewallPolicy.Location
            };


            //string sample = System.IO.File.ReadAllText(@"sample.txt");
            string serializedObject = JsonConvert.SerializeObject(rcWrapper);
            WriteObject(serializedObject);
            WriteObject("===================");
            var json = serializedObject.Replace("'", "\"");

            WriteObject(json);
            var deserializedruleGroup = (MNM.FirewallPolicyRuleGroup)JsonConvert.DeserializeObject(
                                        json,
                                        typeof(MNM.FirewallPolicyRuleGroup),
                                        new JsonConverter[] { new Iso8601TimeSpanConverter(), new PolymorphicJsonCustomConverter<MNM.FirewallPolicyRule, MNM.FirewallPolicyRuleCondition>("ruleType", "ruleConditionType"), new TransformationJsonConverter() });
            WriteObject("===================");
            WriteObject(deserializedruleGroup);
            this.AzureFirewallPolicyRuleGroupClient.CreateOrUpdate(this.ResourceGroupName, this.AzureFirewallPolicy.Name, deserializedruleGroup.Name, deserializedruleGroup);
            WriteObject(rcWrapper);
        }
    }
}
