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

using Microsoft.Azure.Management.ApiManagement.Models;

namespace Microsoft.Azure.Commands.ApiManagement.ServiceManagement.Models
{
    public class PsApiManagementApi
    {
        public string ApiId { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string ServiceUrl { get; set; }

        public string Path { get; set; }

        public string ApiType { get; set; }

        public PsApiManagementSchema[] Protocols { get; set; }

        // map from AuthenticationSettings.OAuth2.AuthorizationServerId
        public string AuthorizationServerId { get; set; }

        // map from AuthenticationSettings.OAuth2.Scope
        public string AuthorizationScope { get; set; }

        // map from SubscriptionKeyParameterNames.Header
        public string SubscriptionKeyHeaderName { get; set; }

        // map from SubscriptionKeyParameterNames.Query
        public string SubscriptionKeyQueryParamName { get; set; }

        public string ApiRevision { get; set; }

        public string ApiVersion { get; set; }

        public bool IsCurrent { get; set;  }

        public bool IsOnline { get; set; }

        public string ApiRevisionId
        {
            get
            {
                return ApiId.ApiRevisionIdentifier(ApiRevision);
            }
        }
    }
}