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

    [Cmdlet("Set", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "ApiManagementApi", DefaultParameterSetName = ExpandedParameterSet)]
    [OutputType(typeof(PsApiManagementApi), ParameterSetName = new[] { ExpandedParameterSet, ByInputObjectParameterSet })]
    public class SetAzureApiManagementApi : AzureApiManagementCmdletBase
    {
        #region Parameter Set Names

        protected const string ExpandedParameterSet = "ExpandedParameter";
        protected const string ByInputObjectParameterSet = "ByInputObject";

        #endregion

        [Parameter(
            ParameterSetName = ExpandedParameterSet,
            ValueFromPipelineByPropertyName = true,
            ValueFromPipeline = true,
            Mandatory = true,
            HelpMessage = "Instance of PsApiManagementContext. This parameter is required.")]
        [ValidateNotNullOrEmpty]
        public PsApiManagementContext Context { get; set; }

        [Parameter(
            ParameterSetName = ExpandedParameterSet,
            ValueFromPipelineByPropertyName = true,
            Mandatory = true,
            HelpMessage = "Identifier of existing API. This parameter is required.")]
        [ValidateNotNullOrEmpty]
        public String ApiId { get; set; }

        [Parameter(
            ParameterSetName = ByInputObjectParameterSet,
            ValueFromPipeline = true,
            Mandatory = true,
            HelpMessage = "Instance of PsApiManagementApi. This parameter is required.")]
        [ValidateNotNullOrEmpty]
        public PsApiManagementApi InputObject { get; set; }

        [Parameter(
            ValueFromPipelineByPropertyName = true,
            Mandatory = false,
            HelpMessage = "Web API name. Public name of the API as it would appear on the developer and admin portals. " +
                          "This parameter is optional.")]
        [ValidateNotNullOrEmpty]
        public String Name { get; set; }

        [Parameter(
            ValueFromPipelineByPropertyName = true,
            Mandatory = false,
            HelpMessage = "Web API description. This parameter is optional.")]
        public String Description { get; set; }

        [Parameter(
            ValueFromPipelineByPropertyName = true,
            Mandatory = false,
            HelpMessage = "A URL of the web service exposing the API. " +
                          "This URL will be used by Azure API Management only, and will not be made public." +
                          " Must be 1 to 2000 characters long. This parameter is optional.")]
        public String ServiceUrl { get; set; }

        [Parameter(
            ValueFromPipelineByPropertyName = true,
            Mandatory = false,
            HelpMessage = "Web API Path. Last part of the API's public URL." +
                          " This URL will be used by API consumers for sending requests to the web service." +
                          " Must be 1 to 400 characters long. This parameter is optional. Default value is $null.")]
        public String Path { get; set; }

        [Parameter(
            ValueFromPipelineByPropertyName = true,
            Mandatory = false,
            HelpMessage = "Web API protocols (http, https). Protocols over which API is made available." +
                          " This parameter is optional. Default value is $null.")]
        public PsApiManagementSchema[] Protocols { get; set; }

        [Parameter(
            ValueFromPipelineByPropertyName = true,
            Mandatory = false,
            HelpMessage = "OAuth authorization server identifier. This parameter is optional. Default value is $null. " +
                          "Must be specified if AuthorizationScope specified.")]
        public String AuthorizationServerId { get; set; }

        [Parameter(
            ValueFromPipelineByPropertyName = true,
            Mandatory = false,
            HelpMessage = "OAuth operations scope. This parameter is optional. Default value is $null.")]
        public String AuthorizationScope { get; set; }

        [Parameter(
            ValueFromPipelineByPropertyName = true,
            Mandatory = false,
            HelpMessage = "OpenId authorization server identifier. This parameter is optional. Default value is $null." +
            " Must be specified if BearerTokenSendingMethods is specified.")]
        public String OpenIdProviderId { get; set; }

        [Parameter(
            ValueFromPipelineByPropertyName = true,
            Mandatory = false,
            HelpMessage = "OpenId authorization server mechanism by which access token is passed to the API. " +
            "Refer to http://tools.ietf.org/html/rfc6749#section-4. This parameter is optional. Default value is $null.")]
        public string[] BearerTokenSendingMethod { get; set; }

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
            HelpMessage = "Flag to enforce SubscriptionRequired for requests to the Api. This parameter is optional.")]
        public SwitchParameter SubscriptionRequired { get; set; }

        [Parameter(
            ValueFromPipelineByPropertyName = true,
            Mandatory = false,
            HelpMessage = "If specified then instance of" +
                          " Microsoft.Azure.Commands.ApiManagement.ServiceManagement.Models.PsApiManagementApi type " +
                          "representing the set API.")]
        public SwitchParameter PassThru { get; set; }

        [Parameter(
            ValueFromPipelineByPropertyName = true,
            Mandatory = false,
            HelpMessage = "Type of API to create. This parameter is optional.")]
        public String ApiType { get; set; }

        [Parameter(
            ValueFromPipelineByPropertyName = true,
            Mandatory = false,
            HelpMessage = "A URL to the Terms of Service for the API. This parameter is optional.")]
        public String TermsOfServiceUrl { get; set; }

        [Parameter(
            ValueFromPipelineByPropertyName = true,
            Mandatory = false,
            HelpMessage = "The identifying name of the contact person/organization. This parameter is optional.")]
        public String ContactName { get; set; }

        [Parameter(
            ValueFromPipelineByPropertyName = true,
            Mandatory = false,
            HelpMessage = "The URL pointing to the contact information. MUST be in the format of a URL. This parameter is optional.")]
        public String ContactUrl { get; set; }

        [Parameter(
            ValueFromPipelineByPropertyName = true,
            Mandatory = false,
            HelpMessage = "The email address of the contact person/organization. MUST be in the format of an email address. This parameter is optional.")]
        public String ContactEmail { get; set; }

        [Parameter(
            ValueFromPipelineByPropertyName = true,
            Mandatory = false,
            HelpMessage = "The license name used for the API. This parameter is optional.")]
        public String LicenseName { get; set; }

        [Parameter(
            ValueFromPipelineByPropertyName = true,
            Mandatory = false,
            HelpMessage = "A URL to the Terms of Service for the API. This parameter is optional.")]
        public String LicenseUrl { get; set; }

        public override void ExecuteApiManagementCmdlet()
        {
            string resourcegroupName;
            string serviceName;
            string apiId;

            if (ParameterSetName.Equals(ByInputObjectParameterSet))
            {
                resourcegroupName = InputObject.ResourceGroupName;
                serviceName = InputObject.ServiceName;
                apiId = InputObject.ApiId;
            }
            else
            {
                resourcegroupName = Context.ResourceGroupName;
                serviceName = Context.ServiceName;
                apiId = ApiId;
            }

            var updatedApi = Client.ApiSet(
                resourcegroupName,
                serviceName,
                apiId,
                Name,
                Description,
                ServiceUrl,
                Path,
                SubscriptionRequired.IsPresent,
                Protocols,
                AuthorizationServerId,
                AuthorizationScope,
                SubscriptionKeyHeaderName,
                SubscriptionKeyQueryParamName,
                OpenIdProviderId,
                BearerTokenSendingMethod,
                InputObject,
                ApiType,
                TermsOfServiceUrl,
                ContactName,
                ContactUrl,
                ContactEmail,
                LicenseName,
                LicenseUrl);

            if (PassThru.IsPresent)
            {
                WriteObject(updatedApi);
            }
        }
    }
}
