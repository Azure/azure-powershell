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
using Microsoft.Azure.Commands.Cdn.Models.Endpoint;
using Microsoft.Azure.Commands.Cdn.Properties;
using Microsoft.Azure.Management.Cdn;
using Microsoft.Azure.Management.Cdn.Models;

namespace Microsoft.Azure.Commands.Cdn.Endpoint
{
    [Cmdlet("Set", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "CdnEndpoint", SupportsShouldProcess = true), OutputType(typeof(PSEndpoint))]
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
           
            try
            {
                EndpointUpdateParameters updatedEndpoint = new EndpointUpdateParameters();
                updatedEndpoint.Tags = CdnEndpoint.Tags.ToDictionaryTags();
                updatedEndpoint.OriginPath = CdnEndpoint.OriginPath;
                updatedEndpoint.ContentTypesToCompress = CdnEndpoint.ContentTypesToCompress.ToList();
                updatedEndpoint.OriginHostHeader = CdnEndpoint.OriginHostHeader;
                updatedEndpoint.IsCompressionEnabled = CdnEndpoint.IsCompressionEnabled;
                updatedEndpoint.IsHttpAllowed = CdnEndpoint.IsHttpAllowed;
                updatedEndpoint.IsHttpsAllowed = CdnEndpoint.IsHttpsAllowed;
                updatedEndpoint.QueryStringCachingBehavior = (QueryStringCachingBehavior)Enum.Parse(typeof(QueryStringCachingBehavior), CdnEndpoint.QueryStringCachingBehavior.ToString());
                updatedEndpoint.OptimizationType = CdnEndpoint.OptimizationType;
                updatedEndpoint.ProbePath = CdnEndpoint.ProbePath;
                updatedEndpoint.GeoFilters = CdnEndpoint.GeoFilters.Select(g => g.ToSdkGeoFilter()).ToList();
                updatedEndpoint.DeliveryPolicy = CdnEndpoint.DeliveryPolicy?.ToSdkDeliveryPolicy();
                updatedEndpoint.DefaultOriginGroup = CdnEndpoint.DefaultOriginGroup;

                var endpoint = CdnManagementClient.Endpoints.Update(resourceGroupName, profileName, CdnEndpoint.Name, updatedEndpoint);

                WriteVerbose(Resources.Success);
                WriteObject(endpoint.ToPsEndpoint());
            }
            catch (ErrorResponseException e)
            {
                throw new PSArgumentException(string.Format("Error response received.Error Message: '{0}'",
                                     e.Response.Content));
            }
        }
    }
}
