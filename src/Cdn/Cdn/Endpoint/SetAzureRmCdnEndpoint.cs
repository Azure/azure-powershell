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
using System.Net;
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
    [Cmdlet("Set", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "CdnEndpoint", SupportsShouldProcess = true), OutputType(typeof(PSEndpoint))]
    public class SetAzureRmCdnEndpoint : AzureCdnCmdletBase
    {
        [Parameter(Mandatory = true, ValueFromPipeline = true, HelpMessage = "The CDN endpoint object.")]
        [ValidateNotNull]
        public PSEndpoint CdnEndpoint { get; set; }

        private Management.Cdn.Models.Endpoint existing;

        public override void ExecuteCmdlet()
        {
            try
            {
                existing = CdnManagementClient.Endpoints.Get(CdnEndpoint.ResourceGroupName, CdnEndpoint.ProfileName, CdnEndpoint.Name);
                ConfirmAction(MyInvocation.InvocationName,
                    CdnEndpoint.Name,
                    SetEndpoint);
            }
            catch (Management.Cdn.Models.ErrorResponseException e)
            {
                if (e.Response.StatusCode == HttpStatusCode.NotFound)
                {
                    throw new PSArgumentException(string.Format(Resources.Error_NonExistingEndpoint, CdnEndpoint.Name, CdnEndpoint.ProfileName, CdnEndpoint.ResourceGroupName));
                }
                else {
                    throw e;
                }

            }
        }

        private void SetEndpoint()
        {
            var resourceGroupName = CdnEndpoint.ResourceGroupName;
            var profileName = CdnEndpoint.ProfileName;
            try
            {
                // Create uses PUT method for request, which is actually a create-or-update operation and is required for the .Net SDK to allow setting WebApplicationFirewallPolicyLink to null.
                var endpoint = CdnManagementClient.Endpoints.Create(
                    resourceGroupName,
                    profileName,
                    CdnEndpoint.Name,
                    new Management.Cdn.Models.Endpoint {
                        Location = existing.Location,
                        Tags = CdnEndpoint.Tags.ToDictionaryTags(),
                        OriginHostHeader = CdnEndpoint.OriginHostHeader,
                        OriginPath = CdnEndpoint.OriginPath,
                        Origins = existing.Origins,
                        ContentTypesToCompress = CdnEndpoint.ContentTypesToCompress.ToList(),
                        IsCompressionEnabled = CdnEndpoint.IsCompressionEnabled,
                        IsHttpAllowed = CdnEndpoint.IsHttpAllowed,
                        IsHttpsAllowed = CdnEndpoint.IsHttpsAllowed,
                        QueryStringCachingBehavior = (QueryStringCachingBehavior)Enum.Parse(typeof(QueryStringCachingBehavior), CdnEndpoint.QueryStringCachingBehavior.ToString()),
                        OptimizationType = CdnEndpoint.OptimizationType,
                        ProbePath = CdnEndpoint.ProbePath,
                        GeoFilters = CdnEndpoint.GeoFilters.Select(g => g.ToSdkGeoFilter()).ToList(),
                        DeliveryPolicy = CdnEndpoint.DeliveryPolicy?.ToSdkDeliveryPolicy(),
                        WebApplicationFirewallPolicyLink = String.IsNullOrEmpty(CdnEndpoint.LinkedWafPolicyResourceId) ? null : new EndpointPropertiesUpdateParametersWebApplicationFirewallPolicyLink(CdnEndpoint.LinkedWafPolicyResourceId)
                    });

                WriteVerbose(Resources.Success);
                WriteObject(endpoint.ToPsEndpoint());
            }
            catch (Microsoft.Azure.Management.Cdn.Models.ErrorResponseException e)
            {
                throw new PSArgumentException(string.Format("Error response received.Error Message: '{0}'",
                                     e.Response.Content));
            }
        }
    }
}
