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

namespace Microsoft.Azure.Commands.Cdn.Endpoint
{
    [Cmdlet(VerbsCommon.New, "AzureRmCdnEndpoint"), OutputType(typeof(PSEndpoint))]
    public class NewAzureRmCdnEndpoint : AzureCdnCmdletBase
    {
        [Parameter(Mandatory = true, HelpMessage = "Azure Cdn endpoint name.")]
        [ValidateNotNullOrEmpty]
        public string EndpointName { get; set; }

        [Parameter(Mandatory = true, HelpMessage = "Azure Cdn profile name.")]
        [ValidateNotNullOrEmpty]
        public string ProfileName { get; set; }

        [Parameter(Mandatory = true, HelpMessage = "The resource group of the Azure Cdn Profile")]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(Mandatory = true, HelpMessage = "The location of the Cdn endpoint")]
        [ValidateNotNullOrEmpty]
        public string Location { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "The origin host header of the Azure Cdn Endpoint")]
        public string OriginHostHeader { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "The origin path Azure Cdn Endpoint")]
        public string OriginPath { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "The list of mime types that need to be compressed by Cdn edge nodes")]
        public string[] ContentTypesToCompress { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Is the compression enabled for the Cdn")]
        public bool? IsCompressionEnabled { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Is the http traffic allowed for the Cdn")]
        public bool? IsHttpAllowed { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Is the https traffic allowed for the Cdn")]
        public bool? IsHttpsAllowed { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "The way Cdn handles requests with query string")]
        public PSQueryStringCachingBehavior? QueryStringCachingBehavior { get; set; }

        [Parameter(Mandatory = true, HelpMessage = "The name of the origin used to identify the origin")]
        public string OriginName { get; set; }

        [Parameter(Mandatory = true, HelpMessage = "The host name of the origin")]
        public string OriginHostName { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "The port http traffic used on the origin server")]
        public int? HttpPort { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "The port https traffic used on the origin server")]
        public int? HttpsPort { get; set; }

        [Parameter(Mandatory = false,
            HelpMessage = "The tags to associate with the Azure Cdn Endpoint")]
        public Hashtable Tags { get; set; }

        public override void ExecuteCmdlet()
        {
            try
            {
                CdnManagementClient.Endpoints.GetWithHttpMessagesAsync(EndpointName, ProfileName, ResourceGroupName)
                    .Wait();
                throw new PSArgumentException(string.Format(
                    Resources.Error_CreateExistingEndpoint, 
                    EndpointName, 
                    ProfileName,
                    ResourceGroupName));
            }
            catch (AggregateException exception)
            {
                var errorResponseException = exception.InnerException as ErrorResponseException;
                if (errorResponseException == null)
                {
                    throw;
                }

                if (errorResponseException.Response.StatusCode.Equals(HttpStatusCode.NotFound))
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
                else
                {
                    throw;
                }
            }
        }
    }
}
