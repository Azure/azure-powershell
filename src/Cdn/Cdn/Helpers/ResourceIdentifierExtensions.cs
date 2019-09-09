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

namespace Microsoft.Azure.Commands.Cdn.Helpers
{
    public static class ResourceIdentifierExtensions
    {
        private const string Profiles = "profiles";
        private const string Endpoints = "endpoints";
        private const string CustomDomains = "customdomains";

        public static string GetProfileName(this ResourceIdentifier resourceId)
        {
            return GetChildResourceName(resourceId, Profiles);
        }

        public static string GetEndpointName(this ResourceIdentifier resourceId)
        {
            return GetChildResourceName(resourceId, Endpoints);
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