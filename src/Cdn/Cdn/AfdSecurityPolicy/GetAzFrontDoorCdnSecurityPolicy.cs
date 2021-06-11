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

namespace Microsoft.Azure.Commands.Cdn.AfdSecurityPolicy
{
    [Cmdlet("Get", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "FrontDoorCdnSecurityPolicy", DefaultParameterSetName = FieldsParameterSet), OutputType(typeof(PSAfdSecurityPolicy))]
    public class GetAzFrontDoorCdnSecurityPolicy : AzureCdnCmdletBase
    {
        [Parameter(Mandatory = true, ValueFromPipeline = true, HelpMessage = HelpMessageConstants.AfdProfileObject, ParameterSetName = ObjectParameterSet)]
        [ValidateNotNull]
        public PSAfdProfile Profile { get; set; }

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

        [Parameter(Mandatory = false, HelpMessage = HelpMessageConstants.AfdSecurityPolicyName, ParameterSetName = FieldsParameterSet)]
        public string SecurityPolicyName { get; set; }

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
            bool isSecurityPolicyName = this.MyInvocation.BoundParameters.ContainsKey("SecurityPolicyName");

            if (isSecurityPolicyName)
            {
                PSAfdSecurityPolicy psAfdSecurityPolicy = this.CdnManagementClient.SecurityPolicies.Get(this.ResourceGroupName, this.ProfileName, this.SecurityPolicyName).ToPSAfdSecurityPolicy();

                WriteObject(psAfdSecurityPolicy);
            }
            else
            {
                List<PSAfdSecurityPolicy> psAfdSecurityPolicyList = this.CdnManagementClient.SecurityPolicies.ListByProfile(this.ResourceGroupName, this.ProfileName)
                                                                    .Select(afdSecurityPolicy => afdSecurityPolicy.ToPSAfdSecurityPolicy())
                                                                    .ToList();

                WriteObject(psAfdSecurityPolicyList);
            }
        }

        private void ObjectParameterSetCmdlet()
        {
            ResourceIdentifier parsedAfdProfileResourceId = new ResourceIdentifier(this.Profile.Id);

            this.ProfileName = parsedAfdProfileResourceId.ResourceName;
            this.ResourceGroupName = parsedAfdProfileResourceId.ResourceGroupName;

            List<PSAfdSecurityPolicy> psAfdSecurityPolicyList = this.CdnManagementClient.SecurityPolicies.ListByProfile(this.ResourceGroupName, this.ProfileName)
                                                                    .Select(afdSecurityPolicy => afdSecurityPolicy.ToPSAfdSecurityPolicy())
                                                                    .ToList();

            WriteObject(psAfdSecurityPolicyList);
        }

        private void ResourceIdParameterSetCmdlet()
        {
            ResourceIdentifier parsedAfdSecurityPolicyResourceId = new ResourceIdentifier(this.ResourceId);

            this.ProfileName = parsedAfdSecurityPolicyResourceId.GetResourceName("profiles");
            this.ResourceGroupName = parsedAfdSecurityPolicyResourceId.ResourceGroupName;
            this.SecurityPolicyName = parsedAfdSecurityPolicyResourceId.ResourceName;

            PSAfdSecurityPolicy psAfdSecurityPolicy = this.CdnManagementClient.SecurityPolicies.Get(this.ResourceGroupName, this.ProfileName, this.SecurityPolicyName).ToPSAfdSecurityPolicy();
            
            WriteObject(psAfdSecurityPolicy);
        }
    }
}
