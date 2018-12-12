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
using System.Linq;
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;

namespace Microsoft.Azure.Commands.Kusto.Utilities
{
    class KustoUtils
    {
        public static void GetResourceGroupNameAndClusterNameFromClusterId(
            string clusterId,
            out string resourceGroupName,
            out string clusterName)
        {
            var identifier = new ResourceIdentifier(clusterId);
            resourceGroupName = identifier.ResourceGroupName;
            clusterName = identifier.ResourceName;
        }

        public static void GetResourceGroupNameClusterNameAndDatabaseNameFromDatabaseId(
            string databaseId,
            out string resourceGroupName,
            out string clusterName,
            out string databaseName)
        {
            var identifier = new ResourceIdentifier(databaseId);
            resourceGroupName = identifier.ResourceGroupName;
            clusterName = identifier.ParentResource.Split('/').Last();
            databaseName = identifier.ResourceName;
        }

        public static void GetResourceGroupNameFromClusterId(
            string clusterId,
            out string resourceGroupName)
        {
            var identifier = new ResourceIdentifier(clusterId);
            resourceGroupName = identifier.ResourceGroupName;
        }

        private static string[] ParseClusterResourceId(string clusterId)
        {
            

            if (string.IsNullOrEmpty(clusterId))
            {
                throw new ArgumentNullException(nameof(clusterId));
            }

            // ResourceID should be in the following format:
            // /subscriptions/{subid}/resourceGroups/{rg}/providers/Microsoft.Kusto/clusters/{cluster}
            string[] tokens = clusterId.Split(new[] { '/' }, StringSplitOptions.RemoveEmptyEntries);
            if (tokens.Length != 8)
            {
                throw new Exception($"ResourceId {clusterId} not in the expected format");
            }

            return tokens;
        }

        private static string[] ParseDatabaseResourceId(string databaseId)
        {
            if (string.IsNullOrEmpty(databaseId))
            {
                throw new ArgumentNullException(nameof(databaseId));
            }

            // ResourceID should be in the following format:
            // /subscriptions/{subid}/resourceGroups/{rg}/providers/Microsoft.Kusto/clusters/{cluster}/databases/{database}
            string[] tokens = databaseId.Split(new[] { '/' }, StringSplitOptions.RemoveEmptyEntries);
            if (tokens.Length != 10)
            {
                throw new Exception($"ResourceId {databaseId} not in the expected format");
            }

            return tokens;
        }
    }
}
