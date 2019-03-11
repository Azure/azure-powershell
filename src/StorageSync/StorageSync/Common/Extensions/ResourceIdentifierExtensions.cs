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

using Microsoft.Azure.Commands.StorageSync.Properties;
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;
using System;

namespace Microsoft.Azure.Commands.StorageSync.Common.Extensions
{
    /// <summary>
    /// Class ResourceIdentifierExtensions.
    /// </summary>
    public static class ResourceIdentifierExtensions
    {
        /// <summary>
        /// Get the parent resource name starting from level 0, immediate parent
        /// </summary>
        /// <param name="resourceIdentifier">The resource identifier.</param>
        /// <param name="resourceType">Type of the resource.</param>
        /// <param name="level">The level.</param>
        /// <returns>System.String.</returns>
        /// <exception cref="ArgumentException">Invalid argument {nameof(resourceIdentifier.ParentResource)} - ParentResource
        /// or
        /// Invalid argument {nameof(level)} - level
        /// or
        /// Invalid argument {nameof(resourceType)} - resourceType</exception>
        public static string GetParentResourceName(this ResourceIdentifier resourceIdentifier, string resourceType, int level = 0)
        {
            if (resourceIdentifier?.ParentResource == null)
            {
                return null;
            }

            string[] parentResourceTokens = resourceIdentifier.ParentResource.Split(new[] { '/' });

            if (parentResourceTokens.Length % 2 != 0)
            {
                throw new ArgumentException(string.Format(StorageSyncResources.InvalidArgumentErrorFormat, nameof(resourceIdentifier.ParentResource)), nameof(resourceIdentifier.ParentResource));
            }

            if (parentResourceTokens.Length < 2 * (level + 1))
            {
                throw new ArgumentException(string.Format(StorageSyncResources.InvalidArgumentErrorFormat, nameof(level)), nameof(level));
            }

            if(!String.Equals(resourceType, parentResourceTokens[parentResourceTokens.Length - 2 * (level + 1)],StringComparison.OrdinalIgnoreCase))
            {
                throw new ArgumentException(string.Format(StorageSyncResources.InvalidArgumentErrorFormat, nameof(resourceType)), nameof(resourceType));
            }

            return parentResourceTokens[parentResourceTokens.Length - 2 * level - 1];
        }
    }
}
