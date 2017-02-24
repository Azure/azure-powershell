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

using Microsoft.Azure.Commands.Cdn.Common;
using Microsoft.Azure.Commands.Cdn.Models.CustomDomain;
using Microsoft.Azure.Commands.Cdn.Properties;
using Microsoft.Azure.Management.Cdn;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Cdn.CustomDomain
{
    [Cmdlet(VerbsLifecycle.Disable, "AzureRmCdnCustomDomainHttps", DefaultParameterSetName = FieldsParameterSet), OutputType(typeof(bool))]
    public class DisableAzureRmCdnCustomDomain : AzureCdnCmdletBase
    {
        [Parameter(Mandatory = false, HelpMessage = "Azure CDN custom domain name.", ParameterSetName = FieldsParameterSet)]
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
        public PSCustomDomain CdnCustomDomain { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "Return object (if specified).")]
        public SwitchParameter PassThru { get; set; }

        public override void ExecuteCmdlet()
        {
            if (ParameterSetName == ObjectParameterSet)
            {
                CustomDomainName = CdnCustomDomain.Name;
                ResourceGroupName = CdnCustomDomain.ResourceGroupName;
                ProfileName = CdnCustomDomain.ProfileName;
                EndpointName = CdnCustomDomain.Name;
            }

            CdnManagementClient.CustomDomains.DisableCustomHttps(ResourceGroupName, ProfileName, EndpointName, CustomDomainName);

            WriteVerbose(Resources.Success);
            WriteVerbose(string.Format(Resources.Success_DisableCustomDomainHttps, CustomDomainName, EndpointName, ProfileName, ResourceGroupName));

            if (PassThru)
            {
                WriteObject(true);
            }
        }
    }
}
