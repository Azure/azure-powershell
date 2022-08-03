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

using Microsoft.Azure.Commands.Common.Authentication.Config.Internal;
using Microsoft.Azure.PowerShell.Common.Config;
using System;
using System.Collections.Generic;

namespace Microsoft.Azure.Commands.Common.Authentication.Config
{
    /// <summary>
    /// Helper class to deal with the full path where configs are stored.
    /// </summary>
    internal static class ConfigPathHelper
    {
        /// <summary>
        /// Gets a list of paths to check when getting a config value by key and invocation info.
        /// </summary>
        /// <param name="key">The key in the config definition.</param>
        /// <param name="invocation">Command invocation info, containing command name and module name.</param>
        public static IEnumerable<string> EnumerateConfigPaths(string key, InternalInvocationInfo invocation = null)
        {
            if (!string.IsNullOrEmpty(invocation?.CmdletName))
            {
                yield return GetPathOfConfig(key, invocation.CmdletName);
            }
            if (!string.IsNullOrEmpty(invocation?.ModuleName))
            {
                yield return GetPathOfConfig(key, invocation.ModuleName);
            }
            yield return GetPathOfConfig(key);
        }

        /// <summary>
        /// Get the path (full key) of a config by its key and what it applies to.
        /// </summary>
        /// <param name="key"></param>
        /// <param name="appliesTo">Global appliesTo by default.</param>
        /// <returns></returns>
        internal static string GetPathOfConfig(string key, string appliesTo = null)
        {
            if (string.IsNullOrEmpty(appliesTo))
            {
                appliesTo = ConfigFilter.GlobalAppliesTo;
            }
            return appliesTo + ConfigurationPath.KeyDelimiter + key;
        }

        /// <summary>
        /// Returns if a path (full key) of a config matches the given key.
        /// </summary>
        public static bool ArePathAndKeyMatch(string path, string key)
        {
            if (string.IsNullOrEmpty(path) || string.IsNullOrEmpty(key))
            {
                throw new ArgumentNullException();
            }
            int index = path.IndexOf(ConfigurationPath.KeyDelimiter);
            return index != -1 && path.Substring(index + 1).Equals(key, StringComparison.OrdinalIgnoreCase);
        }
    }
}
