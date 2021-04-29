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
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Cdn.AfdRule
{
    [Cmdlet("Get", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "FrontDoorCdnRule", DefaultParameterSetName = FieldsParameterSet), OutputType(typeof(PSAfdRule))]
    public class GetAzFrontDoorCdnRule : AzureCdnCmdletBase
    {
        [Parameter(Mandatory = true, HelpMessage = HelpMessageConstants.AfdProfileName, ParameterSetName = FieldsParameterSet)]
        [ValidateNotNullOrEmpty]
        public string ProfileName { get; set; }

        [Parameter(Mandatory = true, HelpMessage = HelpMessageConstants.ResourceGroupName, ParameterSetName = FieldsParameterSet)]
        [ResourceGroupCompleter()]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(Mandatory = true, HelpMessage = HelpMessageConstants.ResourceId, ParameterSetName = ResourceIdParameterSet)]
        [ValidateNotNullOrEmpty]
        public string ResourceId { get; set; }

        [Parameter(Mandatory = true, ValueFromPipeline = true, HelpMessage = HelpMessageConstants.AfdRuleSetObject, ParameterSetName = ObjectParameterSet)]
        [ValidateNotNullOrEmpty]
        public PSAfdRuleSet RuleSet { get; set; }

        [Parameter(Mandatory = true, HelpMessage = HelpMessageConstants.AfdRuleSetName, ParameterSetName = FieldsParameterSet)]
        [ValidateNotNullOrEmpty]
        public string RuleSetName { get; set; }

        [Parameter(Mandatory = false, HelpMessage = HelpMessageConstants.AfdRuleName, ParameterSetName = FieldsParameterSet)]
        [ValidateNotNullOrEmpty]
        public string RuleName { get; set; }

        public override void ExecuteCmdlet()
        {
            try
            {
                switch (ParameterSetName)
                {
                    case FieldsParameterSet:
                        this.FieldsParameterSetCmdlet();
                        break;
                    case ObjectParameterSet:
                        this.ObjectParameterSetCmdlet();
                        break;
                    case ResourceIdParameterSet:
                        this.ResourceIdParameterSetCmdlet();
                        break;
                }
            }
            catch (AfdErrorResponseException errorResponse)
            {
                throw new PSArgumentException(errorResponse.Response.Content);
            }
        }

        private void FieldsParameterSetCmdlet()
        {
            bool isRuleName = MyInvocation.BoundParameters.ContainsKey("RuleName");

            if (isRuleName)
            {
                PSAfdRule psAfdRule = this.CdnManagementClient.Rules.Get(this.ResourceGroupName, this.ProfileName, this.RuleSetName, this.RuleName).ToPSAfdRule();
                WriteObject(psAfdRule);
            }
            else
            {
                List<PSAfdRule> psAfdRuleList = this.CdnManagementClient.Rules.ListByRuleSet(this.ResourceGroupName, this.ProfileName, this.RuleSetName)
                                                .Select(afdRule => afdRule.ToPSAfdRule())
                                                .ToList();

                WriteObject(psAfdRuleList);
            }

        }

        private void ObjectParameterSetCmdlet()
        {
            ResourceIdentifier parsedAfdRuleSetResourceId = new ResourceIdentifier(this.RuleSet.Id);

            this.ProfileName = parsedAfdRuleSetResourceId.GetResourceName("profiles");
            this.ResourceGroupName = parsedAfdRuleSetResourceId.ResourceGroupName;
            this.RuleSetName = parsedAfdRuleSetResourceId.ResourceName;

            List<PSAfdRule> psAfdRuleList = this.CdnManagementClient.Rules.ListByRuleSet(this.ResourceGroupName, this.ProfileName, this.RuleSetName)
                                            .Select(afdRule => afdRule.ToPSAfdRule())
                                            .ToList();

            WriteObject(psAfdRuleList);

        }

        private void ResourceIdParameterSetCmdlet()
        {
            ResourceIdentifier parsedAfdRuleResourceId = new ResourceIdentifier(this.ResourceId);

            this.ProfileName = parsedAfdRuleResourceId.GetResourceName("profiles");
            this.ResourceGroupName = parsedAfdRuleResourceId.ResourceGroupName;
            this.RuleName = parsedAfdRuleResourceId.ResourceName;
            this.RuleSetName = parsedAfdRuleResourceId.GetResourceName("rulesets");

            PSAfdRule psAfdRule = this.CdnManagementClient.Rules.Get(this.ResourceGroupName, this.ProfileName, this.RuleSetName, this.RuleName).ToPSAfdRule();

            WriteObject(psAfdRule);
        }
    }
}
