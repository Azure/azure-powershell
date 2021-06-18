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
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Cdn.AfdRuleSet
{
    [Cmdlet("Remove", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "FrontDoorCdnRuleSet", DefaultParameterSetName = FieldsParameterSet, SupportsShouldProcess = true), OutputType(typeof(bool))]
    public class RemoveAzFrontDoorCdnRuleSet : AzureCdnCmdletBase
    {
        [Parameter(Mandatory = true, ValueFromPipeline = true, HelpMessage = HelpMessageConstants.AfdRuleSetObject, ParameterSetName = ObjectParameterSet)]
        [ValidateNotNull]
        public PSAfdRuleSet RuleSet { get; set; }

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

        [Parameter(Mandatory = true, HelpMessage = HelpMessageConstants.AfdRuleSetName, ParameterSetName = FieldsParameterSet)]
        [ValidateNotNullOrEmpty]
        public string RuleSetName { get; set; }

        [Parameter(Mandatory = false)]
        public SwitchParameter PassThru { get; set; }

        public override void ExecuteCmdlet()
        {
            switch (ParameterSetName)
            {
                case ObjectParameterSet:
                    this.ObjectParameterSetCmdlet();
                    break;
                case ResourceIdParameterSet:
                    this.ResourceIdParameterSetCmdlet();
                    break;
            }

            ConfirmAction(AfdResourceProcessMessage.AfdRuleSetDeleteMessage, this.RuleSetName, this.DeleteAfdRuleSet);
        }

        private void DeleteAfdRuleSet()
        {
            try
            {
                this.CdnManagementClient.RuleSets.Delete(this.ResourceGroupName, this.ProfileName, this.RuleSetName);
            }
            catch (AfdErrorResponseException errorResponse)
            {
                throw new PSArgumentException(errorResponse.Response.Content);
            }

            if (this.PassThru.IsPresent)
            {
                WriteObject(true);
            }
        }

        private void ObjectParameterSetCmdlet()
        {
            ResourceIdentifier parsedAfdRuleSetResourceId = new ResourceIdentifier(this.RuleSet.Id);

            this.ProfileName = parsedAfdRuleSetResourceId.GetResourceName("profiles");
            this.ResourceGroupName = parsedAfdRuleSetResourceId.ResourceGroupName;
            this.RuleSetName = parsedAfdRuleSetResourceId.ResourceName;
        }

        private void ResourceIdParameterSetCmdlet()
        {
            ResourceIdentifier parsedAfdRuleSetResourceId = new ResourceIdentifier(this.ResourceId);

            this.ProfileName = parsedAfdRuleSetResourceId.GetResourceName("profiles");
            this.ResourceGroupName = parsedAfdRuleSetResourceId.ResourceGroupName;
            this.RuleSetName = parsedAfdRuleSetResourceId.ResourceName;
        }
    }
}
