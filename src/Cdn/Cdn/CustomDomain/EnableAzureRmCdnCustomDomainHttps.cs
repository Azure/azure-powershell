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
using System.Linq;
using System.Management.Automation;
using Microsoft.Azure.Commands.Cdn.Common;
using Microsoft.Azure.Commands.Cdn.Helpers;
using Microsoft.Azure.Commands.Cdn.Models.CustomDomain;
using Microsoft.Azure.Commands.Cdn.Properties;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Management.Cdn;
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;

namespace Microsoft.Azure.Commands.Cdn.CustomDomain
{
    [Cmdlet("Enable", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "CdnCustomDomainHttps", DefaultParameterSetName = FieldsParameterSet, SupportsShouldProcess = true), OutputType(typeof(bool))]
    public class EnableAzureRmCdnCustomDomainHttps : AzureCdnCmdletBase
    {
        [Parameter(Mandatory = true, ParameterSetName = FieldsParameterSet, HelpMessage = "Azure CDN custom domain display name.")]
        [ValidateNotNullOrEmpty]
        public string CustomDomainName { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = FieldsParameterSet, HelpMessage = "Azure CDN endpoint name.")]
        [ValidateNotNullOrEmpty]
        public string EndpointName { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = FieldsParameterSet, HelpMessage = "Azure CDN profile name.")]
        [ValidateNotNullOrEmpty]
        public string ProfileName { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = FieldsParameterSet, HelpMessage = "The resource group of the Azure CDN profile")]
        [ResourceGroupCompleter()]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(Mandatory = true, ValueFromPipeline = true, HelpMessage = "The custom domain object.", ParameterSetName = ObjectParameterSet)]
        [ValidateNotNull]
        public PSCustomDomain InputObject { get; set; }

        [Parameter(ParameterSetName = ResourceIdParameterSet, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "ResourceId")]
        [ValidateNotNullOrEmpty]
        public string ResourceId { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "Return object if specified.")]
        public SwitchParameter PassThru { get; set; }

        public override void ExecuteCmdlet()
        {
            if (ParameterSetName == ObjectParameterSet)
            {
                EndpointName = InputObject.EndpointName;
                ProfileName = InputObject.ProfileName;
                ResourceGroupName = InputObject.ResourceGroupName;
                CustomDomainName = InputObject.Name;
            }

            if (ParameterSetName.Equals(ResourceIdParameterSet, StringComparison.OrdinalIgnoreCase))
            {
                var parsedResourceId = new ResourceIdentifier(ResourceId);
                ResourceGroupName = parsedResourceId.ResourceGroupName;
                ProfileName = parsedResourceId.GetProfileName();
                EndpointName = parsedResourceId.GetEndpointName();
                CustomDomainName = parsedResourceId.ResourceName;
            }

            var existingCustomDomain = CdnManagementClient.CustomDomains
                .ListByEndpoint(ResourceGroupName, ProfileName, EndpointName)
                .FirstOrDefault(cd => cd.Name.ToLower() == CustomDomainName.ToLower());

            if (existingCustomDomain == null)
            {
                throw new PSArgumentException(string.Format(Resources.Error_NonExistingCustomDomain,
                    CustomDomainName,
                    EndpointName,
                    ProfileName,
                    ResourceGroupName));
            }

            ConfirmAction(MyInvocation.InvocationName,
                String.Format("{0} ({1})", existingCustomDomain.Name, existingCustomDomain.HostName),
                () => CdnManagementClient.CustomDomains.EnableCustomHttps(
                    ResourceGroupName,
                    ProfileName,
                    EndpointName,
                    CustomDomainName));

            if (PassThru)
            {
                WriteObject(true);
            }
        }
    }
}