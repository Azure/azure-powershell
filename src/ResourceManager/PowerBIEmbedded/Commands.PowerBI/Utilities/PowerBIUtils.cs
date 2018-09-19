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

namespace Microsoft.Azure.Commands.PowerBI.Utilities
{
    class PowerBIUtils
    {
        public static void GetResourceGroupNameAndCapacityName(
            string resourceId,
            out string resourceGroupName,
            out string capacityName)
        {
            string[] tokens = ParseResourceId(resourceId);
            resourceGroupName = tokens[3];
            capacityName = tokens[7];
        }

        public static void GetResourceGroupName(
            string resourceId,
            out string resourceGroupName)
        {
            string[] tokens = ParseResourceId(resourceId);
            resourceGroupName = tokens[3];
        }

        private static string[] ParseResourceId(string resourceId)
        {
            if (string.IsNullOrEmpty(resourceId))
            {
                throw new ArgumentNullException(nameof(resourceId));
            }

            // ResourceID should be in the following format:
            // /subscriptions/{subid}/resourceGroups/{rg}/providers/Microsoft.PowerBIDedicated/capacities/{capacity}
            string[] tokens = resourceId.Split(new[] { '/' }, StringSplitOptions.RemoveEmptyEntries);
            if (tokens.Length != 8)
            {
                throw new Exception($"ResourceId {resourceId} not in the expected format");
            }

            return tokens;
        }
    }
}
