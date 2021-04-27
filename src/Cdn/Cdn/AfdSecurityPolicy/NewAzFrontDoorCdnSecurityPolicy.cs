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

namespace Microsoft.Azure.Commands.Cdn.AfdSecurityPolicy
{
    [Cmdlet("New", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "FrontDoorCdnSecurityPolicy", DefaultParameterSetName = FieldsParameterSet, SupportsShouldProcess = true), OutputType(typeof(PSAfdSecurityPolicy))]
    public class NewAzFrontDoorCdnSecurityPolicy : AzureCdnCmdletBase
    {
        [Parameter(Mandatory = true, HelpMessage = HelpMessageConstants.AfdProfileName, ParameterSetName = FieldsParameterSet)]
        [ValidateNotNullOrEmpty]
        public string ProfileName { get; set; }

        [Parameter(Mandatory = true, HelpMessage = HelpMessageConstants.ResourceGroupName, ParameterSetName = FieldsParameterSet)]
        [ValidateNotNullOrEmpty]
        [ResourceGroupCompleter()]
        public string ResourceGroupName { get; set; }

        [Parameter(Mandatory = true, HelpMessage = HelpMessageConstants.AfdSecurityPolicyName, ParameterSetName = FieldsParameterSet)]
        public string SecurityPolicyName { get; set; }

        [Parameter(Mandatory = true, HelpMessage = HelpMessageConstants.AfdSecurityPolicyWafPolicyId, ParameterSetName = FieldsParameterSet)]
        public string WafPolicyId { get; set; }

        [Parameter(Mandatory = true, HelpMessage = HelpMessageConstants.AfdSecurityPolicyDomainIds, ParameterSetName = FieldsParameterSet)]
        public List<string> DomainId { get; set; } 

        public override void ExecuteCmdlet()
        {
            ConfirmAction(AfdResourceProcessMessage.AfdSecurityPolicyCreateMessage, this.SecurityPolicyName, this.CreateAfdSecurityPolicy);
        }

        private void CreateAfdSecurityPolicy()
        {
            try
            {
                SecurityPolicyWebApplicationFirewallParameters securityPolicyParameters = new SecurityPolicyWebApplicationFirewallParameters();
                securityPolicyParameters.WafPolicy = new ResourceReference(this.WafPolicyId);
                securityPolicyParameters.Associations = new List<SecurityPolicyWebApplicationFirewallAssociation>();

                SecurityPolicyWebApplicationFirewallAssociation securityPolicyWebApplicationFirewallAssociation = new SecurityPolicyWebApplicationFirewallAssociation();
                securityPolicyWebApplicationFirewallAssociation.Domains = new List<ResourceReference>();
                securityPolicyWebApplicationFirewallAssociation.PatternsToMatch = new List<string>
                {
                    "/*",
                };

                foreach (string domainId in this.DomainId)
                {
                    ResourceReference resourceReference = new ResourceReference(domainId);
                    securityPolicyWebApplicationFirewallAssociation.Domains.Add(resourceReference);
                }

                securityPolicyParameters.Associations.Add(securityPolicyWebApplicationFirewallAssociation);
                
                PSAfdSecurityPolicy psAfdSecurityPolicy = this.CdnManagementClient.SecurityPolicies.Create(this.ResourceGroupName, this.ProfileName, this.SecurityPolicyName, securityPolicyParameters).ToPSAfdSecurityPolicy();

                WriteObject(psAfdSecurityPolicy);
            }
            catch (AfdErrorResponseException errorResponse)
            {
                throw new PSArgumentException(errorResponse.Response.Content);
            }
        }
    }
}
