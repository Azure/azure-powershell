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

using System.Management.Automation;
using Microsoft.Azure.Commands.Cdn.Common;
using Microsoft.Azure.Commands.Cdn.Helpers;
using Microsoft.Azure.Commands.Cdn.Models.CustomDomain;
using Microsoft.Azure.Commands.Cdn.Properties;
using Microsoft.Azure.Management.Cdn;
using System.Linq;
using Microsoft.Azure.Commands.Cdn.Models.Endpoint;

namespace Microsoft.Azure.Commands.Cdn.CustomDomain
{
    [Cmdlet(VerbsCommon.Get, "AzureRmCdnCustomDomain", DefaultParameterSetName = FieldsParameterSet), OutputType(typeof(PSCustomDomain))]
    public class GetAzureRmCdnCustomDomain : AzureCdnCmdletBase
    {
        [Parameter(Mandatory = false, HelpMessage = "Azure CDN custom domain name.")]
        [ValidateNotNullOrEmpty]
        public string CustomDomainName { get; set; }

        [Parameter(Mandatory = true, HelpMessage = "Azure CDN endpoint name.", ParameterSetName = FieldsParameterSet)]
        [ValidateNotNullOrEmpty]
        public string EndpointName { get; set; }

        [Parameter(Mandatory = true, HelpMessage = "Azure CDN profile name.", ParameterSetName = FieldsParameterSet)]
        [ValidateNotNullOrEmpty]
        public string ProfileName { get; set; }

        [Parameter(Mandatory = true, HelpMessage = "The resource group of the Azure CDN profile.", ParameterSetName = FieldsParameterSet)]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(Mandatory = true, ValueFromPipeline = true, HelpMessage = "The CDN endpoint object.", ParameterSetName = ObjectParameterSet)]
        [ValidateNotNull]
        public PSEndpoint CdnEndpoint { get; set; }

        public override void ExecuteCmdlet()
        {
            if (ParameterSetName == ObjectParameterSet)
            {
                ResourceGroupName = CdnEndpoint.ResourceGroupName;
                ProfileName = CdnEndpoint.ProfileName;
                EndpointName = CdnEndpoint.Name;
            }

            if (CustomDomainName == null)
            {
                //List all custom domains on this endpoint
                var customDomains = CdnManagementClient.CustomDomains.ListByEndpoint(EndpointName, ProfileName, ResourceGroupName).Select(c => c.ToPsCustomDomain());
                WriteVerbose(Resources.Success);
                WriteObject(customDomains, true);
            }
            else
            {
                var customDomain = CdnManagementClient.CustomDomains.Get(
                    CustomDomainName,
                    EndpointName,
                    ProfileName,
                    ResourceGroupName);

                WriteVerbose(Resources.Success);
                WriteObject(customDomain.ToPsCustomDomain());
            }
        }
    }
}
