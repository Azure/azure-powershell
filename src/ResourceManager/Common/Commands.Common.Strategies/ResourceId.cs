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

namespace Microsoft.Azure.Commands.Common.Strategies
{
    public static class ResourceId
    {
        public const string Subscriptions = "subscriptions";
        public const string ResourceGroups = "resourceGroups";
        public const string Providers = "providers";

        /// <summary>
        /// Returns 'null' if the given id is not parsable.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static IResourceId TryParse(string id)
        {
            const int EmptyI = 0;
            const int SubscriptionsI = 1;
            const int SubscriptionIdI = 2;
            const int ResourceGroupsI = 3;
            const int ResourceGroupNameI = 4;
            const int ProvidersI = 5;
            const int NamespaceI = 6;
            const int ProviderI = 7;
            const int NameI = 8;

            var parts = id.Split('/');
            return parts.Length == 9
                    && parts[EmptyI] == string.Empty
                    && parts[SubscriptionsI] == Subscriptions
                    && parts[ResourceGroupsI] == ResourceGroups
                    && parts[ProvidersI] == Providers
                ? new Implementation(
                    subscriptionId: parts[SubscriptionIdI],
                    resourceGroupName: parts[ResourceGroupNameI],
                    resourceType: new ResourceType(
                        namespace_: parts[NamespaceI],
                        provider: parts[ProviderI]),
                    name: parts[NameI])
                : null;
        }

        sealed class Implementation : IResourceId
        {
            public string Name { get; }

            public string ResourceGroupName { get; }

            public ResourceType ResourceType { get; }

            public string SubscriptionId { get; }

            public Implementation(
                string subscriptionId,
                string resourceGroupName,
                ResourceType resourceType,
                string name)
            {
                SubscriptionId = subscriptionId;
                ResourceGroupName = resourceGroupName;
                ResourceType = resourceType;
                Name = name;
            }
        }
    }
}
