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
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Cdn.AfdSecurityPolicy
{
    [Cmdlet("Set", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "FrontDoorCdnSecurityPolicy", DefaultParameterSetName = FieldsParameterSet, SupportsShouldProcess = true), OutputType(typeof(PSAfdSecurityPolicy))]
    public class SetAzFrontDoorCdnSecurityPolicy : AzureCdnCmdletBase
    {
        [Parameter(Mandatory = false, HelpMessage = HelpMessageConstants.AfdSecurityPolicyDomainIds, ParameterSetName = FieldsParameterSet)]
        public List<string> DomainId { get; set; }

        [Parameter(Mandatory = true, HelpMessage = HelpMessageConstants.AfdProfileName, ParameterSetName = FieldsParameterSet)]
        [ValidateNotNullOrEmpty]
        public string ProfileName { get; set; }

        [Parameter(Mandatory = true, HelpMessage = HelpMessageConstants.ResourceGroupName, ParameterSetName = FieldsParameterSet)]
        [ValidateNotNullOrEmpty]
        [ResourceGroupCompleter()]
        public string ResourceGroupName { get; set; }

        [Parameter(Mandatory = true, ValueFromPipeline = true, HelpMessage = HelpMessageConstants.AfdSecurityPolicyObject, ParameterSetName = ObjectParameterSet)]
        public PSAfdSecurityPolicy SecurityPolicy { get; set; }

        [Parameter(Mandatory = true, HelpMessage = HelpMessageConstants.AfdSecurityPolicyName, ParameterSetName = FieldsParameterSet)]
        public string SecurityPolicyName { get; set; }

        [Parameter(Mandatory = false, HelpMessage = HelpMessageConstants.AfdSecurityPolicyWafPolicyId, ParameterSetName = FieldsParameterSet)]
        public string WafPolicyId { get; set; }

        public override void ExecuteCmdlet()
        {
            switch (ParameterSetName)
            {
                case ObjectParameterSet:
                    this.ObjectParameterSetCmdlet();
                    break;
            }

            ConfirmAction(AfdResourceProcessMessage.AfdSecurityPolicyUpdateMessage, this.SecurityPolicyName, this.UpdateAfdSecurityPolicy);
        }

        private void UpdateAfdSecurityPolicy()
        {
            try
            {
                PSAfdSecurityPolicy currentPsAfdSecurityPolicy = this.CdnManagementClient.SecurityPolicies.Get(this.ResourceGroupName, this.ProfileName, this.SecurityPolicyName).ToPSAfdSecurityPolicy();

                SecurityPolicyWebApplicationFirewallParameters securityPolicyWafParameters = new SecurityPolicyWebApplicationFirewallParameters();

                if (ParameterSetName == ObjectParameterSet)
                {
                    securityPolicyWafParameters = this.CreateSecurityPolicyWafParametersByObject(currentPsAfdSecurityPolicy);
                }

                if (ParameterSetName == FieldsParameterSet)
                {
                    securityPolicyWafParameters = this.CreateSecurityPolicyWafParametersByFields(currentPsAfdSecurityPolicy);
                }

                this.CdnManagementClient.SecurityPolicies.Patch(this.ResourceGroupName, this.ProfileName, this.SecurityPolicyName, securityPolicyWafParameters);
            }
            catch (AfdErrorResponseException errorResponse)
            {
                throw new PSArgumentException(errorResponse.Response.Content);
            }
        }

        private void ObjectParameterSetCmdlet()
        {
            ResourceIdentifier parsedAfdSecurityPolicyResourceId = new ResourceIdentifier(this.SecurityPolicy.Id);

            this.ProfileName = parsedAfdSecurityPolicyResourceId.GetResourceName("profiles");
            this.ResourceGroupName = parsedAfdSecurityPolicyResourceId.ResourceGroupName;
            this.SecurityPolicyName = parsedAfdSecurityPolicyResourceId.ResourceName;
        }

        private SecurityPolicyWebApplicationFirewallParameters CreateSecurityPolicyWafParametersByObject(PSAfdSecurityPolicy currentSecurityPolicy)
        {
            SecurityPolicyWebApplicationFirewallParameters securityPolicyWafParameters = new SecurityPolicyWebApplicationFirewallParameters
            {
                WafPolicy = new ResourceReference(currentSecurityPolicy.WafPolicyId),
                Associations = new List<SecurityPolicyWebApplicationFirewallAssociation>()
            };

            SecurityPolicyWebApplicationFirewallAssociation securityPolicyWafAssociation = new SecurityPolicyWebApplicationFirewallAssociation();
            securityPolicyWafAssociation.Domains = currentSecurityPolicy.Domains;
            securityPolicyWafAssociation.PatternsToMatch = currentSecurityPolicy.PatternsToMatch;

            securityPolicyWafParameters.Associations.Add(securityPolicyWafAssociation);

            if (currentSecurityPolicy.WafPolicyId != this.SecurityPolicy.WafPolicyId)
            {
                securityPolicyWafParameters.WafPolicy = new ResourceReference(this.SecurityPolicy.WafPolicyId);
            }

            return securityPolicyWafParameters;
        }

        private SecurityPolicyWebApplicationFirewallParameters CreateSecurityPolicyWafParametersByFields(PSAfdSecurityPolicy currentSecurityPolicy)
        {
            bool isWafPolicy = this.MyInvocation.BoundParameters.ContainsKey("WafPolicyId");
            bool isDomainIds = this.MyInvocation.BoundParameters.ContainsKey("DomainId");

            SecurityPolicyWebApplicationFirewallParameters securityPolicyWafParameters = new SecurityPolicyWebApplicationFirewallParameters
            {
                WafPolicy = new ResourceReference(currentSecurityPolicy.WafPolicyId),
                Associations = new List<SecurityPolicyWebApplicationFirewallAssociation>()
            };

            SecurityPolicyWebApplicationFirewallAssociation securityPolicyWafAssociation = new SecurityPolicyWebApplicationFirewallAssociation();
            securityPolicyWafAssociation.Domains = currentSecurityPolicy.Domains;
            securityPolicyWafAssociation.PatternsToMatch = currentSecurityPolicy.PatternsToMatch;

            securityPolicyWafParameters.Associations.Add(securityPolicyWafAssociation);

            if (isWafPolicy)
            {
                securityPolicyWafParameters.WafPolicy = new ResourceReference(this.WafPolicyId);
            }
            
            if (isDomainIds)
            {
                securityPolicyWafAssociation.Domains = new List<ResourceReference>();

                foreach (string domainId in this.DomainId)
                {
                    securityPolicyWafAssociation.Domains.Add(new ResourceReference(domainId));
                }

                //securityPolicyWafParameters.Associations = securityPolicyWafAssociation;
            }

            return securityPolicyWafParameters;
        }
    }
}
