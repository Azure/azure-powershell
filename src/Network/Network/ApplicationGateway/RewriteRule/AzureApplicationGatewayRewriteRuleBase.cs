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

using Microsoft.Azure.Commands.Network.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Network
{
    public class AzureApplicationGatewayRewriteRuleBase : NetworkBaseCmdlet
    {
        [Parameter(
                Mandatory = true,
                HelpMessage = "The name of the RewriteRule")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(
            Mandatory = true,
            HelpMessage = "ActionSet of the rewrite rule")]
        [ValidateNotNullOrEmpty]
        public PSApplicationGatewayRewriteRuleActionSet ActionSet { get; set; }

        [Parameter(
        Mandatory = false,
        HelpMessage = "The rule ordering of this rewrite rule in the rewrite rule set")]
        public int RuleSequence { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Condition for the rewrite rule to execute")]
        public PSApplicationGatewayRewriteRuleCondition[] Condition { get; set; }

        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();
        }

        public PSApplicationGatewayRewriteRule NewObject()
        {
            var rewriteRule = new PSApplicationGatewayRewriteRule
            {
                Name = this.Name,
                ActionSet = this.ActionSet,
                RuleSequence = (this.RuleSequence == 0) ? 100 : this.RuleSequence,
                Conditions = this.Condition?.ToList()
            };
            return rewriteRule;
        }
    }
}
