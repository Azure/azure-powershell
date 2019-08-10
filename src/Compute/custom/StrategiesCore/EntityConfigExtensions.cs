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

using System.Collections.Generic;
using System.Linq;

namespace Microsoft.Azure.Commands.Common.Strategies
{
    public static class EntityConfigExtensions
    {
        public static string IdToString(this IEnumerable<string> id)
            => "/" + string.Join("/", id);

        public static string DefaultIdStr(this IEntityConfig config)
            => config.GetIdFromSubscription().IdToString();

        public static string GetResourceGroupName(this IEntityConfig config)
            => config.ResourceGroup?.Name ?? config.Name;

        public static IEnumerable<string> GetIdFromSubscription(this IEntityConfig config)
        {
            var resourceGroupId = new[] 
            {
                ResourceId.ResourceGroups, config.GetResourceGroupName()
            };
            return config.ResourceGroup == null
                ? resourceGroupId
                : resourceGroupId.Concat(config.GetProvidersId());
        }

        internal static IEnumerable<string> GetProvidersId(this IEntityConfig config)
            => new[] { ResourceId.Providers }.Concat(config.GetIdFromResourceGroup());
    }
}
