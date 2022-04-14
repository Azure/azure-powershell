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

namespace Microsoft.Azure.Commands.ApiManagement.ServiceManagement.Models
{
    public class PsApiManagementApi : PsApiManagementArmResource
    {
        public string ApiId { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        /// <summary>
        /// Gets or sets absolute URL of the backend service implementing this
        /// API. Cannot be more than 2000 characters long.
        /// </summary>
        public string ServiceUrl { get; set; }

        /// <summary>
        /// Gets or sets relative URL uniquely identifying this API and all of
        /// its resource paths within the API Management service instance. It
        /// is appended to the API endpoint base URL specified during the
        /// service instance creation to form a public URL for this API.
        /// </summary>
        public string Path { get; set; }

        public string ApiType { get; set; }

        /// <summary>
        /// Gets or sets describes on which protocols the operations in this
        /// API can be invoked.
        /// </summary>
        public PsApiManagementSchema[] Protocols { get; set; }

        // map from AuthenticationSettings.OAuth2.AuthorizationServerId
        public string AuthorizationServerId { get; set; }

        // map from AuthenticationSettings.OAuth2.Scope
        public string AuthorizationScope { get; set; }

        /// <summary>
        /// Gets or sets oAuth authorization server identifier.
        /// map from AuthenticationSettings.openId.openidProviderId
        /// </summary>
        public string OpenidProviderId { get; set; }

        /// <summary>
        /// Gets or sets how to send token to the server.
        /// map from AuthenticationSettings.openId.bearerTokenSendingMethods
        /// </summary>
        public string[] BearerTokenSendingMethod { get; set; }

        // map from SubscriptionKeyParameterNames.Header
        public string SubscriptionKeyHeaderName { get; set; }

        // map from SubscriptionKeyParameterNames.Query
        public string SubscriptionKeyQueryParamName { get; set; }

        /// <summary>
        /// Gets or sets describes the Revision of the Api. If no value is
        /// provided, default revision 1 is created
        /// </summary>
        public string ApiRevision { get; set; }

        /// <summary>
        /// Gets or sets indicates the Version identifier of the API if the API
        /// is versioned
        /// </summary>
        public string ApiVersion { get; set; }

        /// <summary>
        /// Gets or sets indicates if API revision is current api revision.
        /// </summary>
        public bool IsCurrent { get; set;  }
        
        /// <summary>
        /// Gets indicates if API revision is accessible via the gateway.
        /// </summary>
        public bool IsOnline { get; set; }

        /// <summary>
        /// Gets or sets specifies whether an API or Product subscription is
        /// required for accessing the API.
        /// </summary>
        public bool? SubscriptionRequired { get; set; }

        /// <summary>
        /// Gets or sets description of the Api Revision.
        /// </summary>
        public string ApiRevisionDescription { get; set; }

        /// <summary>
        /// Gets or sets description of the Api Version.
        /// </summary>
        public string ApiVersionSetDescription { get; set; }

        /// <summary>
        /// Gets or sets a resource identifier for the related ApiVersionSet.
        /// </summary>
        public string ApiVersionSetId { get; set; }

        /// <summary>
        /// Gets or sets the email address of the contact person/organization.
        /// </summary>
        public string ContactEmail { get; set; }

        /// <summary>
        /// Gets or sets the identifying name of the contact person/organization.
        /// </summary>
        public string ContactName { get; set; }

        /// <summary>
        /// Gets or sets the URL pointing to the contact information.
        /// </summary>
        public string ContactUrl { get; set; }

        /// <summary>
        /// Gets or sets the license name used for the API.
        /// </summary>
        public string LicenseName { get; set; }

        /// <summary>
        /// Gets or sets a URL to the License for the API.
        /// </summary>
        public string LicenseUrl { get; set; }

        /// <summary>
        /// Gets or sets a URL to the Terms of Service for the API.
        /// </summary>
        public string TermsOfServiceUrl { get; set; }
    }
}