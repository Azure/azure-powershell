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
    using System;
    using System.Text.RegularExpressions;

    public class PsApiManagementCache : PsApiManagementArmResource
    {
        static readonly Regex CacheNameRegex = new Regex(@"(.*?)/providers/microsoft.apimanagement/service/(?<serviceName>[^/]+)/caches/(?<cacheId>[^/]+)", RegexOptions.IgnoreCase);

        /// <summary>
        /// Identifier of the Cache
        /// </summary>
        public string CacheId { get; set; }

        /// <summary>
        /// Gets or sets cache description
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets runtime connection string to cache
        /// </summary>
        public string ConnectionString { get; set; }

        /// <summary>
        /// Gets or sets original uri of entity in external system cache points
        /// to
        /// </summary>
        public string AzureRedisResourceId { get; set; }

        public PsApiManagementCache()  {   }

        public PsApiManagementCache(string armResourceId)
        {            
            this.Id = armResourceId;

            var match = CacheNameRegex.Match(Id);
            if (match.Success)
            {
                var cacheNameGroup = match.Groups["cacheId"];
                if (cacheNameGroup != null && cacheNameGroup.Success)
                {
                    this.CacheId = cacheNameGroup.Value;
                    return;
                }
            }

            throw new ArgumentException($"Arm ResourceId {armResourceId} is not a valid Cache resource.");
        }
    }
}
