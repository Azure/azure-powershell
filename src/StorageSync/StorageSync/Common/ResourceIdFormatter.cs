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
using System.Collections.Generic;
using System.Text;

namespace Microsoft.Azure.Commands.StorageSync.Common
{
    /// <summary>
    /// Class ResourceIdFormatter.
    /// </summary>
    public static class ResourceIdFormatter
    {
        /// <summary>
        /// Constructs a resource Id
        /// </summary>
        /// <param name="subscriptionId">Subscription Id</param>
        /// <param name="resourceGroupName">Resource group name</param>
        /// <param name="resources">Key-value pairs, each one contains resource type and resource name</param>
        /// <returns>Return the resource Id</returns>
        /// <exception cref="ArgumentException">resourceGroupName</exception>
        public static string GenerateResourceId(
            Guid subscriptionId,
            string resourceGroupName,
            IList<KeyValuePair<string, string>> resources = null)
        {
            if (string.IsNullOrEmpty(resourceGroupName))
            {
                throw new ArgumentException(nameof(resourceGroupName));
            }

            var sb = new StringBuilder();

            sb.Append($"/{StorageSyncConstants.SubscriptionTypeName}/{subscriptionId}");

            sb.Append($"/{StorageSyncConstants.ResourceGroupTypeName}/{resourceGroupName}");

            if (resources?.Count > 0)
            {
                sb.Append($"/{StorageSyncConstants.ProvidersTypeName}/{StorageSyncConstants.ResourceProvider}");
                foreach (var resourcePair in resources)
                {
                    sb.Append($"/{resourcePair.Key}/{resourcePair.Value}");
                }
            }

            return sb.ToString();
        }
    }
}
