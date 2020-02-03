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

using System;
using System.Management.Automation;
using System.Net;
using Microsoft.Azure.Commands.Cdn.Common;
using Microsoft.Azure.Commands.Cdn.Models.WebApplicationFirewall;
using Microsoft.Azure.Commands.Cdn.Properties;
using Microsoft.Azure.Management.Cdn;
using Microsoft.Azure.Management.Cdn.Models;
using System.Linq;
using Microsoft.Azure.Commands.Cdn.Helpers;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;

namespace Microsoft.Azure.Commands.Cdn.WebApplicationFirewall
{
    [Cmdlet("Remove", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "CdnWafPolicy", SupportsShouldProcess = true), OutputType(typeof(bool))]
    public class RemoveAzCdnWafPolicy : AzureCdnCmdletBase
    {
        [Parameter(Mandatory = true, ParameterSetName = FieldsParameterSet, HelpMessage = "The name of the CDN WAF policy.")]
        [ValidateNotNullOrEmpty]
        public string PolicyName { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = FieldsParameterSet, HelpMessage = "The resource group to which the CDN WAF policy belongs.")]
        [ResourceGroupCompleter()]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(ParameterSetName = ResourceIdParameterSet, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "ResourceId of the CDN WAF policy")]
        [ValidateNotNullOrEmpty]
        public string ResourceId { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = ObjectParameterSet, ValueFromPipeline = true, HelpMessage = "The CDN WAF policy.")]
        [ValidateNotNullOrEmpty]
        public PSPolicy CdnWafPolicy { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "Return object (if specified).")]
        public SwitchParameter PassThru { get; set; }

        [Parameter()]
        public SwitchParameter Force { get; set; }

        public override void ExecuteCmdlet()
        {
            // Use object for ObjectParameterSet
            if (ParameterSetName == ObjectParameterSet)
            {
                ResourceGroupName = CdnWafPolicy.ResourceGroupName;
                PolicyName = CdnWafPolicy.Name;
            }
            // Parse ResourceId for ResourceIdParameterSet
            else if (ParameterSetName == ResourceIdParameterSet)
            {
                var parsed = new WafPolicyResourceId(ResourceId);
                ResourceGroupName = parsed.ResourceGroupName;
                PolicyName = parsed.PolicyName;
            }

            // Verify the policy exists.
            try
            {
                var existingPolicy = CdnManagementClient.Policies.Get(ResourceGroupName, PolicyName);
            }
            catch (Management.Cdn.Models.ErrorResponseException e)
            {
                if (e.Response.StatusCode == HttpStatusCode.NotFound)
                {
                    throw new PSArgumentException(string.Format(Resources.Error_DeleteNonExistingPolicy, PolicyName, ResourceGroupName));
                }

                throw e;
            }


            ConfirmAction(Force,
                string.Format(Resources.Confirm_RemoveProfile, PolicyName),
                this.MyInvocation.InvocationName,
                PolicyName,
                () => CdnManagementClient.Policies.Delete(ResourceGroupName, PolicyName));

            if (PassThru)
            {
                WriteObject(true);
            }

        }
    }
}
