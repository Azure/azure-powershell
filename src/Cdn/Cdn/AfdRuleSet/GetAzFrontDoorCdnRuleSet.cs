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

namespace Microsoft.Azure.Commands.Cdn.AfdRuleSet
{
    [Cmdlet("Get", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "FrontDoorCdnRuleSet", DefaultParameterSetName = FieldsParameterSet), OutputType(typeof(PSAfdRuleSet))]
    public class GetAzFrontDoorCdnRuleSet : AzureCdnCmdletBase
    {
        [Parameter(Mandatory = true, ValueFromPipeline = true, HelpMessage = HelpMessageConstants.AfdProfileObject, ParameterSetName = ObjectParameterSet)]
        [ValidateNotNull]
        public PSAfdProfile Profile { get; set; }

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

        [Parameter(Mandatory = false, HelpMessage = HelpMessageConstants.AfdRuleSetName, ParameterSetName = FieldsParameterSet)]
        [ValidateNotNullOrEmpty]
        public string RuleSetName { get; set; }

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
                        this.ResourceIdSetCmdlet();
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
            bool isRuleSetName = this.MyInvocation.BoundParameters.ContainsKey("RuleSetName");

            if (isRuleSetName)
            {
                PSAfdRuleSet psAfdRuleSet = this.CdnManagementClient.RuleSets.Get(this.ResourceGroupName, this.ProfileName, this.RuleSetName).ToPSAfdRuleSet();

                WriteObject(psAfdRuleSet);
            }
            else
            {
                List<PSAfdRuleSet> psAfdRuleSetList = this.CdnManagementClient.RuleSets.ListByProfile(this.ResourceGroupName, this.ProfileName)
                                                      .Select(afdRuleSet => afdRuleSet.ToPSAfdRuleSet())
                                                      .ToList();

                WriteObject(psAfdRuleSetList);
            }
        }

        private void ObjectParameterSetCmdlet()
        {
            ResourceIdentifier parsedAfdProfileResourceId = new ResourceIdentifier(this.Profile.Id);

            this.ProfileName = parsedAfdProfileResourceId.ResourceName;
            this.ResourceGroupName = parsedAfdProfileResourceId.ResourceGroupName;

            List<PSAfdRuleSet> psAfdRuleSetList = this.CdnManagementClient.RuleSets.ListByProfile(this.ResourceGroupName, this.ProfileName)
                                                  .Select(afdRuleSet => afdRuleSet.ToPSAfdRuleSet())
                                                  .ToList();

            WriteObject(psAfdRuleSetList);
        }

        private void ResourceIdSetCmdlet()
        {
            ResourceIdentifier parsedAfdRuleSetResourceId = new ResourceIdentifier(this.ResourceId);

            this.ProfileName = parsedAfdRuleSetResourceId.GetResourceName("profiles");
            this.ResourceGroupName = parsedAfdRuleSetResourceId.ResourceGroupName;
            this.RuleSetName = parsedAfdRuleSetResourceId.ResourceName;

            PSAfdRuleSet psAfdRuleSet = this.CdnManagementClient.RuleSets.Get(this.ResourceGroupName, this.ProfileName, this.RuleSetName).ToPSAfdRuleSet();

            WriteObject(psAfdRuleSet);
        }
    }
}
