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
using System.Management.Automation;
using Microsoft.Azure.Commands.FrontDoor.Properties;
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;

namespace Microsoft.Azure.Commands.FrontDoor.Helpers
{
    public static class ResourceIdentifierExtensions
    {
        private const string FrontDoors = "frontdoors";
        private const string FrontendEndpointResourceTypeName = "Microsoft.Network/Frontdoors/FrontendEndpoints";
        private const string FrontDoorResourceTypeName = "Microsoft.Network/frontdoors";

        public static string GetFrontDoorName(this ResourceIdentifier resourceId)
        {
            return GetChildResourceName(resourceId, FrontDoors);
        }

        public static bool IsFrontendEndpointResourceType(this ResourceIdentifier resourceId)
        {
            return string.Equals(resourceId.ResourceType, FrontendEndpointResourceTypeName, StringComparison.OrdinalIgnoreCase);
        }

        public static bool IsFrontDoorResourceType(this ResourceIdentifier resourceId)
        {
            return string.Equals(resourceId.ResourceType, FrontDoorResourceTypeName, StringComparison.OrdinalIgnoreCase);
        }

        private static string GetChildResourceName(this ResourceIdentifier resourceId, string resourceType)
        {
            var parentResource = resourceId.ParentResource.Split(new[] { '/' });

            for (int idx = 0; idx < parentResource.Length; idx++)
            {
                if (parentResource[idx].Equals(resourceType, StringComparison.OrdinalIgnoreCase))
                {
                    return parentResource[idx + 1];
                }
            }

            return null;
        }
    }
}