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

namespace Microsoft.Azure.Commands.ApiManagement.Models
{
    public class PsApiManagementConnectivityStatus
    {
        /// <summary>
        /// Gets or sets the hostname of the resource which the service depends
        /// on. This can be the database, storage or any other azure resource
        /// on which the service depends upon.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets resource Connectivity Status Type identifier. Possible
        /// values include: 'initializing', 'success', 'failure'
        /// </summary>
        public string Status { get; set; }

        /// <summary>
        /// Gets or sets error details of the connectivity to the resource.
        /// </summary>
        public string Error { get; set; }

        /// <summary>
        /// Gets or sets the date when the resource connectivity status was
        /// last updated. This status should be updated every 15 minutes. If
        /// this status has not been updated, then it means that the service
        /// has lost network connectivity to the resource, from inside the
        /// Virtual Network.The date conforms to the following format:
        /// `yyyy-MM-ddTHH:mm:ssZ` as specified by the ISO 8601 standard.
        /// </summary>
        public System.DateTime LastUpdated { get; set; }

        /// <summary>
        /// Gets the date when the resource connectivity status last
        /// Changed from success to failure or vice-versa. The date conforms to
        /// the following format: `yyyy-MM-ddTHH:mm:ssZ` as specified by the
        /// ISO 8601 standard.
        /// </summary>
        public System.DateTime LastStatusChange { get; set; }

        /// <summary>
        /// Gets the resourceType.
        /// </summary>
        public string ResourceType { get; set; }

        /// <summary>
        /// Gets whether Resourcetype is optional.
        /// </summary>
        public bool? IsOptional { get; set; }
    }
}
