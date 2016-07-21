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
using Microsoft.Azure.Commands.Cdn.Models.Endpoint;
using Microsoft.Azure.Commands.Cdn.Properties;
using Microsoft.Azure.Management.Cdn;
using System.Linq;

namespace Microsoft.Azure.Commands.Cdn.Endpoint
{
    [Cmdlet(VerbsCommon.Get, "AzureRmCdnEndpoint"), OutputType(typeof(PSEndpoint))]
    public class GetAzureRmCdnEndpoint : AzureCdnCmdletBase
    {
        [Parameter(Mandatory = false, HelpMessage = "Azure CDN endpoint name.")]
        [ValidateNotNullOrEmpty]
        public string EndpointName { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "Azure CDN profile name.")]
        [Alias("Name")] //For pipeline compatibility with PSProfileName, which calls its name property "Name"
        [ValidateNotNullOrEmpty]
        public string ProfileName { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The resource group of the Azure CDN profile.")]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        public override void ExecuteCmdlet()
        {
            if (EndpointName != null)
            {
                var endpoint = CdnManagementClient.Endpoints.Get(EndpointName, ProfileName, ResourceGroupName);
                WriteVerbose(Resources.Success);
                WriteObject(endpoint.ToPsEndpoint());
            }
            else
            {
                var endpoints = CdnManagementClient.Endpoints.ListByProfile(ProfileName, ResourceGroupName).Select(e => e.ToPsEndpoint());
                WriteVerbose(Resources.Success);
                WriteObject(endpoints);
            }
        }
    }
}
