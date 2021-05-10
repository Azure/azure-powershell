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

namespace Microsoft.Azure.Commands.Cdn.AfdSecurityPolicy
{
    [Cmdlet("Remove", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "FrontDoorCdnSecurityPolicy", DefaultParameterSetName = FieldsParameterSet, SupportsShouldProcess = true), OutputType(typeof(bool))]
    public class RemoveAzFrontDoorCdnSecurityPolicy : AzureCdnCmdletBase
    {
        [Parameter(Mandatory = true, HelpMessage = HelpMessageConstants.AfdProfileName, ParameterSetName = FieldsParameterSet)]
        [ValidateNotNullOrEmpty]
        public string ProfileName { get; set; }

        [Parameter(Mandatory = true, HelpMessage = HelpMessageConstants.ResourceGroupName, ParameterSetName = FieldsParameterSet)]
        [ValidateNotNullOrEmpty]
        [ResourceGroupCompleter()]
        public string ResourceGroupName { get; set; }

        [Parameter(Mandatory = true, HelpMessage = HelpMessageConstants.ResourceId, ParameterSetName = ResourceIdParameterSet)]
        [ValidateNotNullOrEmpty]
        public string ResourceId { get; set; }

        [Parameter(Mandatory = true, ValueFromPipeline = true, HelpMessage = HelpMessageConstants.AfdSecurityPolicyObject, ParameterSetName = ObjectParameterSet)]
        public PSAfdSecurityPolicy SecurityPolicy { get; set; }

        [Parameter(Mandatory = true, HelpMessage = HelpMessageConstants.AfdSecurityPolicyName, ParameterSetName = FieldsParameterSet)]
        public string SecurityPolicyName { get; set; }

        [Parameter(Mandatory = false, HelpMessage = HelpMessageConstants.PassThruParameter)]
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

            ConfirmAction(AfdResourceProcessMessage.AfdSecurityPolicyDeleteMessage, this.SecurityPolicyName, this.DeleteAfdSecurityPolicy);
        }

        private void DeleteAfdSecurityPolicy()
        {
            try
            {
                this.CdnManagementClient.SecurityPolicies.Delete(this.ResourceGroupName, this.ProfileName, this.SecurityPolicyName);
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
            ResourceIdentifier parsedAfdSecurityPolicyResourceId = new ResourceIdentifier(this.SecurityPolicy.Id);

            this.ProfileName = parsedAfdSecurityPolicyResourceId.GetResourceName("profiles");
            this.ResourceGroupName = parsedAfdSecurityPolicyResourceId.ResourceGroupName;
            this.SecurityPolicyName = parsedAfdSecurityPolicyResourceId.ResourceName;
        }

        private void ResourceIdParameterSetCmdlet()
        {
            ResourceIdentifier parsedAfdSecurityPolicyResourceId = new ResourceIdentifier(this.ResourceId);

            this.ProfileName = parsedAfdSecurityPolicyResourceId.GetResourceName("profiles");
            this.ResourceGroupName = parsedAfdSecurityPolicyResourceId.ResourceGroupName;
            this.SecurityPolicyName = parsedAfdSecurityPolicyResourceId.ResourceName;
        }
    }
}
