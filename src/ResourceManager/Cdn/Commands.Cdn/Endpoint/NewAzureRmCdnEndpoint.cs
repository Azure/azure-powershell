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
using System.Collections;
using System.Collections.Generic;
using System.Management.Automation;
using System.Net;
using Microsoft.Azure.Commands.Cdn.Common;
using Microsoft.Azure.Commands.Cdn.Helpers;
using Microsoft.Azure.Commands.Cdn.Models.Endpoint;
using Microsoft.Azure.Commands.Cdn.Properties;
using Microsoft.Azure.Management.Cdn;
using Microsoft.Azure.Management.Cdn.Models;
using Microsoft.Azure.Commands.Cdn.Models.Profile;

namespace Microsoft.Azure.Commands.Cdn.Endpoint
{
    [Cmdlet(VerbsCommon.New, "AzureRmCdnEndpoint", SupportsShouldProcess = true, DefaultParameterSetName = FieldsParameterSet), OutputType(typeof(PSEndpoint))]
    public class NewAzureRmCdnEndpoint : AzureCdnCmdletBase
    {
        [Parameter(Mandatory = true, HelpMessage = "Azure CDN endpoint name.")]
        [ValidateNotNullOrEmpty]
        public string EndpointName { get; set; }

        [Parameter(Mandatory = true, HelpMessage = "Azure CDN profile name.", ParameterSetName = FieldsParameterSet)]
        [ValidateNotNullOrEmpty]
        public string ProfileName { get; set; }

        [Parameter(Mandatory = true, HelpMessage = "The resource group of the Azure CDN Profile.", ParameterSetName = FieldsParameterSet)]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(Mandatory = true, ValueFromPipeline = true, HelpMessage = "Azure CDN profile object.", ParameterSetName = ObjectParameterSet)]
        [ValidateNotNull]
        public PSProfile CdnProfile { get; set; }
        
        [Parameter(Mandatory = true, HelpMessage = "The location of the CDN endpoint.", ParameterSetName = FieldsParameterSet)]
        [ValidateNotNullOrEmpty]
        public string Location { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "The origin host header of the Azure CDN endpoint.")]
        public string OriginHostHeader { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "The origin path Azure CDN endpoint.")]
        public string OriginPath { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "The list of MIME types that need to be compressed by CDN edge nodes.")]
        public string[] ContentTypesToCompress { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Indiciates if compression should be enabled for this endpoint.")]
        public bool? IsCompressionEnabled { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Indicates if HTTP should be enabled for this endpoint.")]
        public bool? IsHttpAllowed { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Indicates if HTTPS should be enabled for this endpoint.")]
        public bool? IsHttpsAllowed { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Determines caching behavior for requests with query string. Valid values are IgnoreQueryString, BypassCaching, and UseQueryString.")]
        public PSQueryStringCachingBehavior? QueryStringCachingBehavior { get; set; }

        [Parameter(Mandatory = true, HelpMessage = "The name of the origin. For display only.")]
        public string OriginName { get; set; }

        [Parameter(Mandatory = true, HelpMessage = "The host name (address) of the origin.")]
        public string OriginHostName { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "The port used for HTTP traffic on the origin server.")]
        public int? HttpPort { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "The port used for HTTPS traffic on the origin server.")]
        public int? HttpsPort { get; set; }

        [Parameter(Mandatory = false,
            HelpMessage = "The tags to associate with the Azure CDN endpoint.")]
        public Hashtable Tags { get; set; }

        public override void ExecuteCmdlet()
        {
            if (ParameterSetName == ObjectParameterSet)
            {
                ProfileName = CdnProfile.Name;
                ResourceGroupName = CdnProfile.ResourceGroupName;
                Location = CdnProfile.Location;
            }

            var checkExists = CdnManagementClient.NameAvailability.CheckNameAvailability(EndpointName, ResourceType.MicrosoftCdnProfilesEndpoints);

            if (!checkExists.NameAvailable.Value)
            {
                throw new PSArgumentException(string.Format(
                    Resources.Error_CreateExistingEndpoint,
                    EndpointName));
            }

            ConfirmAction(MyInvocation.InvocationName,
                EndpointName,
                () => NewEndpoint());
          
        }

        private void NewEndpoint()
        {
            var endpoint = CdnManagementClient.Endpoints.Create(EndpointName, new EndpointCreateParameters
            {
                ContentTypesToCompress = ContentTypesToCompress,
                IsCompressionEnabled = IsCompressionEnabled,
                IsHttpAllowed = IsHttpAllowed,
                IsHttpsAllowed = IsHttpsAllowed,
                Location = Location,
                OriginHostHeader = OriginHostHeader,
                OriginPath = OriginPath,
                Origins = new List<DeepCreatedOrigin> { new DeepCreatedOrigin(OriginName, OriginHostName, HttpPort, HttpsPort) },
                QueryStringCachingBehavior = QueryStringCachingBehavior != null ?
                            QueryStringCachingBehavior.Value.CastEnum<PSQueryStringCachingBehavior, QueryStringCachingBehavior>() :
                            (QueryStringCachingBehavior?)null,
                Tags = Tags.ToDictionaryTags()
            }, ProfileName, ResourceGroupName);

            WriteVerbose(Resources.Success);
            WriteObject(endpoint.ToPsEndpoint());
        }
    }
}
