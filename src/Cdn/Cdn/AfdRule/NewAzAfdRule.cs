// ----------------------------------------------------------------------------------
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

using Microsoft.Azure.Commands.Cdn.AfdHelpers;
using Microsoft.Azure.Commands.Cdn.AfdModels;
using Microsoft.Azure.Commands.Cdn.Common;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Management.Cdn;
using Microsoft.Azure.Management.Cdn.Models;
using System.Collections.Generic;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Cdn.AfdRule
{
    [Cmdlet("New", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "AfdRule", SupportsShouldProcess = true), OutputType(typeof(PSAfdRule))]
    public class NewAzAfdRule : AzureCdnCmdletBase
    {
        [Parameter(Mandatory = false, HelpMessage = HelpMessageConstants.AfdRuleCacheExpirationActionObject)]
        public PSAfdRuleCacheExpirationAction CacheExpirationAction { get; set; }

        [Parameter(Mandatory = true, HelpMessage = HelpMessageConstants.AfdProfileName)]
        [ValidateNotNullOrEmpty]
        public string ProfileName { get; set; }

        [Parameter(Mandatory = true, HelpMessage = HelpMessageConstants.ResourceGroupName)]
        [ResourceGroupCompleter()]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(Mandatory = true, HelpMessage = HelpMessageConstants.AfdRuleSetName)]
        [ValidateNotNullOrEmpty]
        public string RuleSetName { get; set; }

        [Parameter(Mandatory = true, HelpMessage = HelpMessageConstants.AfdRuleName)]
        [ValidateNotNullOrEmpty]
        public string RuleName { get; set; }

        [Parameter(Mandatory = true, HelpMessage = HelpMessageConstants.AfdRuleOrder)]
        [ValidateNotNullOrEmpty]
        public int Order { get; set; }

        [Parameter(Mandatory = false, HelpMessage = HelpMessageConstants.AfdRuleMatchProcessingBehavior)]
        [PSArgumentCompleter("Continue", "Stop")]
        [ValidateNotNullOrEmpty]
        public string MatchProcessingBehavior { get; set; }

        public override void ExecuteCmdlet()
        {
            ConfirmAction(AfdResourceProcessMessage.AfdRuleCreateMessage, this.RuleName, this.CreateAfdRule);
        }

        private void CreateAfdRule()
        {
            try
            {
                Rule afdRule = new Rule();
                afdRule.Order = this.Order;
                afdRule.Actions = new List<DeliveryRuleAction>();
                afdRule.Conditions = new List<DeliveryRuleCondition>();
                
                if (MyInvocation.BoundParameters.ContainsKey("MatchProcessingBehavior"))
                {
                    afdRule.MatchProcessingBehavior = this.MatchProcessingBehavior;
                }

                if (this.MyInvocation.BoundParameters.ContainsKey("CacheExpirationAction"))
                {
                    DeliveryRuleCacheExpirationAction cacheExpirationAction = new DeliveryRuleCacheExpirationAction
                    {
                        Parameters = new CacheExpirationActionParameters()
                    };

                    cacheExpirationAction.Parameters.CacheBehavior = this.CacheExpirationAction.CacheBehavior;
                    cacheExpirationAction.Parameters.CacheDuration = this.CacheExpirationAction.CacheDuration;
                    
                    afdRule.Actions.Add(cacheExpirationAction);
                }

                PSAfdRule psAfdRule = this.CdnManagementClient.Rules.Create(this.ResourceGroupName, this.ProfileName, this.RuleSetName, this.RuleName, afdRule).ToPSAfdRule();

                WriteObject(psAfdRule);
            }
            catch (AfdErrorResponseException errorResponse)
            {
                throw new PSArgumentException(errorResponse.Response.Content);
            }
        }
    }
}
