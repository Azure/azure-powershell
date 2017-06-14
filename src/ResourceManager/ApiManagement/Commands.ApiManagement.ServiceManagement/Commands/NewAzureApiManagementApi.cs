//  
// Copyright (c) Microsoft.  All rights reserved.
// 
//  Licensed under the Apache License, Version 2.0 (the "License");
//  you may not use this file except in compliance with the License.
//  You may obtain a copy of the License at
//    http://www.apache.org/licenses/LICENSE-2.0
// 
//  Unless required by applicable law or agreed to in writing, software
//  distributed under the License is distributed on an "AS IS" BASIS,
//  WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//  See the License for the specific language governing permissions and
//  limitations under the License.

namespace Microsoft.Azure.Commands.ApiManagement.ServiceManagement.Commands
{
    using Microsoft.Azure.Commands.ApiManagement.ServiceManagement.Models;
    using System;
    using System.Linq;
    using System.Management.Automation;

    [Cmdlet(VerbsCommon.New, Constants.ApiManagementApi)]
    [OutputType(typeof(PsApiManagementApi))]
    public class NewAzureApiManagementApi : AzureApiManagementCmdletBase
    {
        [Parameter(
            ValueFromPipelineByPropertyName = true,
            Mandatory = true,
            HelpMessage = "Instance of PsApiManagementContext. This parameter is required.")]
        [ValidateNotNullOrEmpty]
        public PsApiManagementContext Context { get; set; }

        [Parameter(
            ValueFromPipelineByPropertyName = true,
            Mandatory = false,
            HelpMessage = "Identifier for new API. This parameter is optional. If not specified the identifier will be generated.")]
        public String ApiId { get; set; }

        [Parameter(
            ValueFromPipelineByPropertyName = true,
            Mandatory = true,
            HelpMessage = "Web API name. Public name of the API as it would appear on the developer and admin portals. This parameter is required.")]
        [ValidateNotNullOrEmpty]
        public String Name { get; set; }

        [Parameter(
            ValueFromPipelineByPropertyName = true,
            Mandatory = false,
            HelpMessage = "Web API description. This parameter is optional.")]
        public String Description { get; set; }

        [Parameter(
            ValueFromPipelineByPropertyName = true,
            Mandatory = true,
            HelpMessage = "A URL of the web service exposing the API. This URL will be used by Azure API Management only, and will not be made public. " +
                          "Must be 1 to 2000 characters long. This parameter is required.")]
        [ValidateNotNullOrEmpty]
        public String ServiceUrl { get; set; }

        [Parameter(
            ValueFromPipelineByPropertyName = true,
            Mandatory = true,
            HelpMessage = "Web API Path. Last part of the API's public URL. This URL will be used by API consumers for sending requests to the web service." +
                          " Must be 1 to 400 characters long. This parameter is required.")]
        [ValidateNotNullOrEmpty]
        public String Path { get; set; }

        [Parameter(
            ValueFromPipelineByPropertyName = true,
            Mandatory = true,
            HelpMessage = "Web API protocols (http, https). Protocols over which API is made available. " +
                          "This parameter is required. Default value is $null.")]
        [ValidateNotNullOrEmpty]
        public PsApiManagementSchema[] Protocols { get; set; }

        [Parameter(
            ValueFromPipelineByPropertyName = true,
            Mandatory = false,
            HelpMessage = "OAuth authorization server identifier. This parameter is optional. Default value is $null." +
                          " Must be specified if AuthorizationScope specified.")]
        public String AuthorizationServerId { get; set; }

        [Parameter(
            ValueFromPipelineByPropertyName = true,
            Mandatory = false,
            HelpMessage = "OAuth operations scope. This parameter is optional. Default value is $null.")]
        public String AuthorizationScope { get; set; }

        [Parameter(
            ValueFromPipelineByPropertyName = true,
            Mandatory = false,
            HelpMessage = "Subscription key header name. This parameter is optional. Default value is $null.")]
        public String SubscriptionKeyHeaderName { get; set; }

        [Parameter(
            ValueFromPipelineByPropertyName = true,
            Mandatory = false,
            HelpMessage = "Subscription key query string parameter name. This parameter is optional. Default value is $null.")]
        public String SubscriptionKeyQueryParamName { get; set; }

        [Parameter(
            ValueFromPipelineByPropertyName = true,
            Mandatory = false,
            HelpMessage = "Array of products IDs to add the new API to. This parameter is optional.")]
        public String[] ProductIds { get; set; }

        public override void ExecuteApiManagementCmdlet()
        {
            string id = ApiId ?? Guid.NewGuid().ToString("N");

            var newApi = Client.ApiCreate(
                Context,
                id,
                Name,
                Description,
                ServiceUrl,
                Path,
                Protocols.Distinct().ToArray(),
                AuthorizationServerId,
                AuthorizationScope,
                SubscriptionKeyHeaderName,
                SubscriptionKeyQueryParamName);

            if (ProductIds != null && ProductIds.Any())
            {
                WriteProgress(new ProgressRecord(0, "New-AzureRmApiManagementApi", "New API created. Adding to products..."));

                foreach (var productId in ProductIds)
                {
                    try
                    {
                        Client.ApiAddToProduct(Context, productId, id);
                        WriteProgress(
                            new ProgressRecord(
                                0,
                                "New-AzureRmApiManagementApi",
                                string.Format("... Added to product {0}", productId))
                            );
                    }
                    catch (Exception ex)
                    {
                        WriteProgress(
                            new ProgressRecord(
                                0,
                                "New-AzureRmApiManagementApi",
                                string.Format("... Failed to add to product {0} due to: {1}", productId, ex))
                            );
                    }
                }
            }

            WriteObject(newApi);
        }
    }
}
