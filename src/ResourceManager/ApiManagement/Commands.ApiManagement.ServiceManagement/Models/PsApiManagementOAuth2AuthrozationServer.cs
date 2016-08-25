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

using System.Collections;

namespace Microsoft.Azure.Commands.ApiManagement.ServiceManagement.Models
{
    public class PsApiManagementOAuth2AuthrozationServer
    {
        public string ServerId { get; internal set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string ClientRegistrationPageUrl { get; set; }

        public string AuthorizationEndpointUrl { get; set; }

        public string TokenEndpointUrl { get; set; }

        public PsApiManagementAuthorizationRequestMethod[] AuthorizationRequestMethods { get; set; }

        public PsApiManagementClientAuthenticationMethod[] ClientAuthenticationMethods { get; set; }

        public Hashtable TokenBodyParameters { get; set; }

        public bool SupportState { get; set; }

        public string DefaultScope { get; set; }

        public PsApiManagementGrantType[] GrantTypes { get; set; }

        // map from BearerTokenSendingMethods
        public PsApiManagementAccessTokenSendingMethod[] AccessTokenSendingMethods { get; set; }

        public string ClientId { get; set; }

        public string ClientSecret { get; set; }

        public string ResourceOwnerUsername { get; set; }

        public string ResourceOwnerPassword { get; set; }
    }
}