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
    using System.Collections;
    using System.Management.Automation;

    [Cmdlet(VerbsCommon.New, Constants.ApiManagementAuthorizationServer)]
    [OutputType(typeof(PsApiManagementOAuth2AuthrozationServer))]
    public class NewAzureApiManagementAuthorizationServer : AzureApiManagementCmdletBase
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
            HelpMessage = "Identifier of existing authorization server. This parameter is optional. ")]
        public String ServerId { get; set; }

        [Parameter(
            ValueFromPipelineByPropertyName = true,
            Mandatory = true,
            HelpMessage = "Name of new authorization server. This parameter is required.")]
        [ValidateNotNullOrEmpty]
        public String Name { get; set; }

        [Parameter(
            ValueFromPipelineByPropertyName = true,
            Mandatory = false,
            HelpMessage = "Description of new authorization server. This parameter is optional.")]
        public String Description { get; set; }

        [Parameter(
            ValueFromPipelineByPropertyName = true,
            Mandatory = true,
            HelpMessage = "Client registration endpoint is used for registering clients with the authorization server and obtaining client credentials." +
                          " This parameter is required.")]
        [ValidateNotNullOrEmpty]
        public String ClientRegistrationPageUrl { get; set; }

        [Parameter(
            ValueFromPipelineByPropertyName = true,
            Mandatory = true,
            HelpMessage = "Authorization endpoint is used to authenticate resource owners and obtain authorization grants. This parameter is required.")]
        [ValidateNotNullOrEmpty]
        public String AuthorizationEndpointUrl { get; set; }

        [Parameter(
            ValueFromPipelineByPropertyName = true,
            Mandatory = true,
            HelpMessage = "Token endpoint is used by clients to obtain access tokens in exchange for presenting authorization grants or refresh tokens." +
                          " This parameter is required.")]
        [ValidateNotNullOrEmpty]
        public String TokenEndpointUrl { get; set; }

        [Parameter(
            ValueFromPipelineByPropertyName = true,
            Mandatory = true,
            HelpMessage = "Client ID of developer console which is the client application. This parameter is required.")]
        [ValidateNotNullOrEmpty]
        public String ClientId { get; set; }

        [Parameter(
            ValueFromPipelineByPropertyName = true,
            Mandatory = false,
            HelpMessage = "Client secret of developer console which is the client application. This parameter is optional.")]
        public String ClientSecret { get; set; }

        [Parameter(
            ValueFromPipelineByPropertyName = true,
            Mandatory = false,
            HelpMessage = "Supported authorization request methods (GET, POST). This parameter is optional. Default value is GET.")]
        public PsApiManagementAuthorizationRequestMethod[] AuthorizationRequestMethods { get; set; }

        [Parameter(
            ValueFromPipelineByPropertyName = true,
            Mandatory = true,
            HelpMessage = "Supported grant types (AuthorizationCode, Implicit, ResourceOwnerPassword, ClientCredentials). This parameter is required.")]
        [ValidateNotNullOrEmpty]
        public PsApiManagementGrantType[] GrantTypes { get; set; }

        [Parameter(
            ValueFromPipelineByPropertyName = true,
            Mandatory = true,
            HelpMessage = "Supported client authentication methods (Basic, Body). This parameter is required.")]
        [ValidateNotNullOrEmpty]
        public PsApiManagementClientAuthenticationMethod[] ClientAuthenticationMethods { get; set; }

        [Parameter(
            ValueFromPipelineByPropertyName = true,
            Mandatory = false,
            HelpMessage = "Additional body parameters using application/x-www-form-urlencoded format. This parameter is optional.")]
        public Hashtable TokenBodyParameters { get; set; }

        [Parameter(
            ValueFromPipelineByPropertyName = true,
            Mandatory = false,
            HelpMessage = "Whether to support state parameter. This parameter is optional.")]
        public bool? SupportState { get; set; }

        [Parameter(
            ValueFromPipelineByPropertyName = true,
            Mandatory = false,
            HelpMessage = "Authorization server default scope. This parameter is optional.")]
        public String DefaultScope { get; set; }

        [Parameter(
            ValueFromPipelineByPropertyName = true,
            Mandatory = true,
            HelpMessage = "Supported methods of sending access token (AuthorizationHeader, Query). This parameter is required.")]
        [ValidateNotNullOrEmpty]
        public PsApiManagementAccessTokenSendingMethod[] AccessTokenSendingMethods { get; set; }

        [Parameter(
            ValueFromPipelineByPropertyName = true,
            Mandatory = false,
            HelpMessage = "Resource owner user name. This parameter is required if ‘ResourceOwnerPassword’ is present in -GrantTypes.")]
        public String ResourceOwnerUsername { get; set; }

        [Parameter(
            ValueFromPipelineByPropertyName = true,
            Mandatory = false,
            HelpMessage = "Resource owner password. This parameter is required if ‘ResourceOwnerPassword’ is present in -GrantTypes.")]
        public String ResourceOwnerPassword { get; set; }

        public override void ExecuteApiManagementCmdlet()
        {
            var serverId = this.ServerId ?? Guid.NewGuid().ToString("N");

            var server = Client.AuthorizationServerCreate(
                Context,
                serverId,
                Name,
                Description,
                ClientRegistrationPageUrl,
                AuthorizationEndpointUrl,
                TokenEndpointUrl,
                ClientId,
                ClientSecret,
                AuthorizationRequestMethods == null || AuthorizationRequestMethods.Length == 0
                    ? new[] { PsApiManagementAuthorizationRequestMethod.Get }
                    : AuthorizationRequestMethods,
                GrantTypes,
                ClientAuthenticationMethods,
                TokenBodyParameters,
                SupportState,
                DefaultScope,
                AccessTokenSendingMethods,
                ResourceOwnerUsername,
                ResourceOwnerPassword);

            WriteObject(server);
        }
    }
}
