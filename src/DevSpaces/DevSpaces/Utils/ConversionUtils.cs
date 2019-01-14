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
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;

namespace Microsoft.Azure.Commands.DevSpaces.Utils
{
    public static class ConversionUtils
    {
        public const string DevSpacesControllerResourceTypeName = "Microsoft.DevSpaces/controllers";
        public const string ManagedClusterResourceTypeName = "Microsoft.Containerservice/managedclusters";

        public static bool TryParseResourceId(string resourceId, string type, out string resourceGroupName, out string name)
        {
            resourceGroupName = string.Empty;
            name = string.Empty;
            var parsed = false;

            if (!string.IsNullOrEmpty(resourceId))
            {
                var resourceIdentifier = new ResourceIdentifier(resourceId);
                resourceGroupName = resourceIdentifier.ResourceGroupName;

                if (string.Equals(resourceIdentifier.ResourceType, type, StringComparison.OrdinalIgnoreCase))
                {
                    name = resourceIdentifier.ResourceName;
                    parsed = true;
                }
            }

            return parsed;
        }
    }
}
