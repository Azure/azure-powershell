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

using System.Linq;
using System.Management.Automation;
using Microsoft.Azure.Commands.Cdn.Common;
using Microsoft.Azure.Commands.Cdn.Helpers;
using Microsoft.Azure.Commands.Cdn.Models.WebApplicationFirewall;
using Microsoft.Azure.Commands.Cdn.Properties;
using Microsoft.Azure.Management.Cdn;
using System;
using System.Net;
using Microsoft.Azure.Management.Cdn.Models;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;


namespace Microsoft.Azure.Commands.Cdn.WebApplicationFirewall
{
    /// <summary>
    /// Defines the Get-AzCdnWafPolicy cmdlet.
    /// </summary>
    [Cmdlet("Get", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "CdnWafPolicy"), OutputType(typeof(PSPolicy))]
    public class GetAzCdnWafPolicy : AzureCdnCmdletBase
    {
        /// <summary>
        /// Gets or sets the policy name.
        /// </summary>
        [Parameter(ParameterSetName = FieldsParameterSet, Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "Azure CDN WAF Policy name.")]
        [Alias("Name")]
        [ValidateNotNullOrEmpty]
        public string PolicyName { get; set; }

        /// <summary>
        /// The resource group name of the policy.
        /// </summary>
        [Parameter(ParameterSetName = FieldsParameterSet, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The resource group of the Azure CDN WAF policy.")]
        [ResourceGroupCompleter()]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(ParameterSetName = ResourceIdParameterSet, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "ResourceId of the CDN WAF policy")]
        [ValidateNotNullOrEmpty]
        public string ResourceId { get; set; }


        public override void ExecuteCmdlet()
        {
            // Parse ResourceId for ResourceIdParameterSet
            if (ParameterSetName == ResourceIdParameterSet)
            {
                var parsed = new WafPolicyResourceId(ResourceId);
                ResourceGroupName = parsed.ResourceGroupName;
                PolicyName = parsed.PolicyName;
            }

            if (PolicyName == null && ResourceGroupName != null)
            {
                // List by Resource Group name.
                var policies =
                    CdnManagementClient.Policies.List(ResourceGroupName).Select(p => p.ToPsPolicy());
                WriteVerbose(Resources.Success);
                WriteObject(policies.ToArray(), true);
                return;
            }
            
            try
            {
                // Get by Policy Name.
                var profile = CdnManagementClient.Profiles.Get(ResourceGroupName, PolicyName);
                WriteVerbose(Resources.Success);
                WriteObject(profile.ToPsProfile());
            }
            catch(ErrorResponseException ex)
            {
                if (ex.Response.StatusCode.Equals(HttpStatusCode.NotFound))
                {
                    throw new PSArgumentException(string.Format(
                        Resources.Error_WafPolicyNotFound,
                        PolicyName,
                        ResourceGroupName));
                }
            }
        }
    }
}
