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
    public class PsApiManagementApiVersionSet
    {
        /// <summary>
        /// Api Version Set Id
        /// </summary>
        public string ApiVersionSetId { get; set; }

        /// <summary>
        /// Gets or sets description of API Version Set.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets name of query parameter that indicates the API Version
        /// if versioningScheme is set to `query`.
        /// </summary>
        public string VersionQueryName { get; set; }

        /// <summary>
        /// Gets or sets name of HTTP header parameter that indicates the API
        /// Version if versioningScheme is set to `header`.
        /// </summary>
        public string VersionHeaderName { get; set; }

        /// <summary>
        /// Gets or sets name of API Version Set
        /// </summary>
        public string DisplayName { get; set; }

        /// <summary>
        /// Gets or sets an value that determines where the API Version
        /// identifer will be located in a HTTP request. Possible values
        /// include: 'Segment', 'Query', 'Header'
        /// </summary>
        public PsApiManagementVersioningScheme VersioningScheme { get; set; }
    }
}