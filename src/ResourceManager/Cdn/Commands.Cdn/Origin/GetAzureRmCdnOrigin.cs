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
using Microsoft.Azure.Commands.Cdn.Models.Origin;
using Microsoft.Azure.Commands.Cdn.Properties;
using Microsoft.Azure.Management.Cdn;
using System.Linq;
using Microsoft.Azure.Commands.Cdn.Models.Endpoint;

namespace Microsoft.Azure.Commands.Cdn.Origin
{
    [Cmdlet(VerbsCommon.Get, "AzureRmCdnOrigin", DefaultParameterSetName = FieldsParameterSet), OutputType(typeof(PSOrigin))]
    public class GetAzureRmCdnOrigin : AzureCdnCmdletBase
    {
        [Parameter(Mandatory = false, HelpMessage = "Azure CDN origin name.")]
        [ValidateNotNullOrEmpty]
        public string OriginName { get; set; }

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

            if(ParameterSetName == ObjectParameterSet)
            {
                EndpointName = CdnEndpoint.Name;
                ProfileName = CdnEndpoint.ProfileName;
                ResourceGroupName = CdnEndpoint.ResourceGroupName;
            }

            if (OriginName == null)
            {
                //list all origins on this endpoint
                var origins = CdnManagementClient.Origins.ListByEndpoint(EndpointName, ProfileName, ResourceGroupName).Select(o => o.ToPsOrigin());
                WriteVerbose(Resources.Success);
                WriteObject(origins, true);
            }
            else
            {
                var origin = CdnManagementClient.Origins.Get(OriginName, EndpointName, ProfileName, ResourceGroupName);
                WriteVerbose(Resources.Success);
                WriteObject(origin.ToPsOrigin());
            }
        }
    }
}
