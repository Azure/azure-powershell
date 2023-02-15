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
using System.Collections.Generic;

namespace Microsoft.Azure.Commands.Common.Authentication.Config.Internal
{
    /// <summary>
    /// Utility methods and constants for manipulating Configuration paths
    /// </summary>
    internal static class ConfigurationPath
    {
        /// <summary>
        /// The delimiter ":" used to separate individual keys in a path.
        /// </summary>
        public static readonly string KeyDelimiter = ":";

        /// <summary>
        /// Combines path segments into one path.
        /// </summary>
        /// <param name="pathSegments">The path segments to combine.</param>
        /// <returns>The combined path.</returns>
        public static string Combine(params string[] pathSegments)
        {
            if (pathSegments == null)
            {
                throw new ArgumentNullException(nameof(pathSegments));
            }
            return string.Join(KeyDelimiter, pathSegments);
        }

        /// <summary>
        /// Combines path segments into one path.
        /// </summary>
        /// <param name="pathSegments">The path segments to combine.</param>
        /// <returns>The combined path.</returns>
        public static string Combine(IEnumerable<string> pathSegments)
        {
            if (pathSegments == null)
            {
                throw new ArgumentNullException(nameof(pathSegments));
            }
            return string.Join(KeyDelimiter, pathSegments);
        }

        /// <summary>
        /// Extracts the last path segment from the path.
        /// </summary>
        /// <param name="path">The path.</param>
        /// <returns>The last path segment of the path.</returns>
        public static string GetSectionKey(string path)
        {
            if (string.IsNullOrEmpty(path))
            {
                return path;
            }

            int lastDelimiterIndex = path.LastIndexOf(KeyDelimiter, StringComparison.OrdinalIgnoreCase);
            return lastDelimiterIndex == -1 ? path : path.Substring(lastDelimiterIndex + 1);
        }

        /// <summary>
        /// Extracts the path corresponding to the parent node for a given path.
        /// </summary>
        /// <param name="path">The path.</param>
        /// <returns>The original path minus the last individual segment found in it. Null if the original path corresponds to a top level node.</returns>
        public static string GetParentPath(string path)
        {
            if (string.IsNullOrEmpty(path))
            {
                return null;
            }

            int lastDelimiterIndex = path.LastIndexOf(KeyDelimiter, StringComparison.OrdinalIgnoreCase);
            return lastDelimiterIndex == -1 ? null : path.Substring(0, lastDelimiterIndex);
        }
    }
}
