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

using Microsoft.Azure.Commands.ResourceManager.Cmdlets.Components;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Microsoft.Azure.Commands.ContainerRegistry
{
    static class ConversionUtilities
    {
        private readonly static string StorageResourceTypeName = "Microsoft.Storage/storageAccounts";
        private readonly static string RegistryResourceTypeName = "Microsoft.ContainerRegistry/registries";
        private readonly static string RegistryReplicationResourceTypeName = "Microsoft.ContainerRegistry/registries/replications";
        private readonly static string RegistryWebhookResourceTypeName = "Microsoft.ContainerRegistry/registries/webhooks";

        public static IDictionary<string, string> ToDictionary(Hashtable ht)
        {
            if (ht == null)
            {
                return null;
            }
            else
            {
                var dictionary = new Dictionary<string, string>();
                foreach (var entry in ht.Cast<DictionaryEntry>())
                {
                    dictionary[(string)entry.Key] = entry.Value?.ToString();
                }
                return dictionary;
            }
        }

        public static string ParseResourceGroupFromId(string idFromServer)
        {
            if (!string.IsNullOrEmpty(idFromServer))
            {
                var resourceIdentifier = new ResourceIdentifier(idFromServer);                

                return resourceIdentifier.ResourceGroupName;
            }
            return null;
        }

        public static string ParseStorageAccountFromId(string storageAccountIdFromServer)
        {
            if (!string.IsNullOrEmpty(storageAccountIdFromServer))
            {
                var resourceIdentifier = new ResourceIdentifier(storageAccountIdFromServer);
                if(string.Equals(resourceIdentifier.ResourceType, StorageResourceTypeName, StringComparison.OrdinalIgnoreCase))
                {
                    return resourceIdentifier.ResourceName;
                }
            }
            return null;
        }

        public static bool TryParseRegistryRelatedResourceId(string idFromServer, out string resourceGroupName, out string registryName, out string childResourceName)
        {
            resourceGroupName = string.Empty;
            registryName = string.Empty;
            childResourceName = string.Empty;
            var parsed = false;

            if (!string.IsNullOrEmpty(idFromServer))
            {
                var resourceIdentifier = new ResourceIdentifier(idFromServer);
                resourceGroupName = resourceIdentifier.ResourceGroupName;

                if (string.Equals(resourceIdentifier.ResourceType, RegistryResourceTypeName, StringComparison.OrdinalIgnoreCase))
                {
                    registryName = resourceIdentifier.ResourceName;
                    parsed = true;
                }
                else if(string.Equals(resourceIdentifier.ResourceType, RegistryReplicationResourceTypeName, StringComparison.OrdinalIgnoreCase) ||
                    string.Equals(resourceIdentifier.ResourceType, RegistryWebhookResourceTypeName, StringComparison.OrdinalIgnoreCase))
                {
                    childResourceName = resourceIdentifier.ResourceName;
                    registryName = resourceIdentifier.ParentResource.Split(new char[] { '/'})[1];
                    parsed = true;
                }
            }
            return parsed;
        }
    }
}
