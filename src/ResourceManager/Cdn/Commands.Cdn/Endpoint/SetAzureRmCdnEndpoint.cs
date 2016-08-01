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
using Microsoft.Azure.Commands.Cdn.Models.Endpoint;
using Microsoft.Azure.Commands.Cdn.Properties;
using Microsoft.Azure.Management.Cdn;
using Microsoft.Azure.Management.Cdn.Models;
using SdkQueryStringCachingBehavior = Microsoft.Azure.Management.Cdn.Models.QueryStringCachingBehavior;

namespace Microsoft.Azure.Commands.Cdn.Endpoint
{
    [Cmdlet(VerbsCommon.Set, "AzureRmCdnEndpoint", SupportsShouldProcess = true), OutputType(typeof(PSEndpoint))]
    public class SetAzureRmCdnEndpoint : AzureCdnCmdletBase
    {
        [Parameter(Mandatory = true, ValueFromPipeline = true, HelpMessage = "The CDN endpoint object.")]
        [ValidateNotNull]
        public PSEndpoint CdnEndpoint { get; set; }

        public override void ExecuteCmdlet()
        {
            ConfirmAction(MyInvocation.InvocationName,
                CdnEndpoint.Name,
                SetEndpoint);
        }

        private void SetEndpoint()
        {
            var resourceGroupName = CdnEndpoint.ResourceGroupName;
            var profileName = CdnEndpoint.ProfileName;

            var endpoint = CdnManagementClient.Endpoints.Update(CdnEndpoint.Name,
                new EndpointUpdateParameters(
                    CdnEndpoint.Tags.ToDictionaryTags(),
                    CdnEndpoint.OriginHostHeader,
                    CdnEndpoint.OriginPath,
                    CdnEndpoint.ContentTypesToCompress.ToList(),
                    CdnEndpoint.IsCompressionEnabled,
                    CdnEndpoint.IsHttpAllowed,
                    CdnEndpoint.IsHttpsAllowed,
                    CdnEndpoint.QueryStringCachingBehavior
                        .CastEnum<PSQueryStringCachingBehavior, SdkQueryStringCachingBehavior>()), profileName, resourceGroupName);

            WriteVerbose(Resources.Success);
            WriteObject(endpoint.ToPsEndpoint());
        }
    }
}
