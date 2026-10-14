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

namespace Microsoft.Azure.Commands.NetAppFiles.Helpers
{
    /// <summary>
    /// Helpers for safely extracting the ARM resource hierarchy from a
    /// fully-qualified resource Id. Used by cmdlet object/parent-object
    /// parameter sets to avoid crashing on a leaf-only <c>Name</c> returned
    /// by the service for nested resources.
    /// </summary>
    internal static class ResourceIdHelpers
    {
        /// <summary>
        /// Returns the resource-name segments of an ARM resource Id in the
        /// same order/indexing that the legacy <c>InputObject.Name.Split('/')</c>
        /// pattern produced when the service happened to return a composite
        /// name. For an Id of the form
        /// <c>/subscriptions/{s}/resourceGroups/{rg}/providers/{ns}/{t0}/{n0}/{t1}/{n1}/.../{tN}/{nN}</c>
        /// the result is <c>[ n0, n1, ..., nN ]</c>.
        /// </summary>
        /// <param name="resourceId">Fully-qualified ARM resource Id.</param>
        /// <returns>The ordered array of resource-name segments.</returns>
        public static string[] NamePartsFromId(string resourceId)
        {
            if (string.IsNullOrEmpty(resourceId))
            {
                throw new ArgumentNullException(nameof(resourceId));
            }

            var resourceIdentifier = new ResourceIdentifier(resourceId);

            // ParentResource is "{type0}/{name0}/{type1}/{name1}/.../{typeN-1}/{nameN-1}"
            // and ResourceName is the leaf {nameN}. Names are at odd indices.
            var parentSegments = (resourceIdentifier.ParentResource ?? string.Empty)
                .Split(new[] { '/' }, StringSplitOptions.RemoveEmptyEntries);

            int parentNameCount = parentSegments.Length / 2;
            var nameParts = new string[parentNameCount + 1];
            for (int i = 0; i < parentNameCount; i++)
            {
                nameParts[i] = parentSegments[(2 * i) + 1];
            }
            nameParts[parentNameCount] = resourceIdentifier.ResourceName;
            return nameParts;
        }
    }
}
