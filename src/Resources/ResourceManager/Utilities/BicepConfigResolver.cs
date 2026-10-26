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

namespace Microsoft.Azure.Commands.ResourceManager.Cmdlets.Utilities
{
    using Newtonsoft.Json;
    using Microsoft.Azure.Commands.Common.Authentication;
    using Microsoft.Azure.Commands.Common.Authentication.Abstractions;
    using Microsoft.Azure.Commands.Common.Exceptions;
    using System;
    using System.Collections.Generic;
    using System.IO;

    /// <summary>
    /// Minimal model of a bicepconfig.json file. Only the fields relevant to resolving the
    /// effective 'bicep.version' constraint are represented here; all other sections of the
    /// file (analyzers, module aliases, etc.) are intentionally ignored, since Bicep itself
    /// remains the source of truth for the rest of the config when it actually compiles.
    /// </summary>
    internal class BicepConfigFile
    {
        [JsonProperty("extends")]
        public string Extends { get; set; }

        [JsonProperty("bicep")]
        public BicepSection Bicep { get; set; }
    }

    internal class BicepSection
    {
        [JsonProperty("version")]
        public string Version { get; set; }
    }

    /// <summary>
    /// Resolves the effective 'bicep.version' constraint that applies to a given Bicep
    /// entrypoint file, by locating the nearest bicepconfig.json and following its 'extends'
    /// chain.
    /// </summary>
    internal class BicepConfigResolver
    {
        private const string ConfigFileName = "bicepconfig.json";

        private const int MaxExtendsChainDepth = 64;

        private readonly IDataStore dataStore;

        public BicepConfigResolver(IDataStore dataStore)
        {
            this.dataStore = dataStore;
        }

        public static BicepConfigResolver Create()
            => new BicepConfigResolver(FileUtilities.DataStore);

        /// <summary>
        /// Walks up the directory tree starting at the entrypoint file's directory, looking
        /// for the nearest bicepconfig.json. Returns null if none is found before reaching
        /// the root of the file system.
        /// </summary>
        public string FindNearestConfigFile(string entrypointFilePath)
        {
            var directory = Path.GetDirectoryName(Path.GetFullPath(entrypointFilePath));

            while (!string.IsNullOrEmpty(directory))
            {
                var candidate = Path.Combine(directory, ConfigFileName);
                if (dataStore.FileExists(candidate))
                {
                    return candidate;
                }

                directory = Path.GetDirectoryName(directory);
            }

            return null;
        }

        /// <summary>
        /// Follows the 'extends' chain starting at the given config file, and returns the
        /// first non-null 'bicep.version' value found walking from the leaf config towards
        /// the root. An explicit "version": null in an intermediate layer is treated as "no
        /// opinion" and falls through to a deeper layer in the chain, matching Bicep's
        /// config-merging semantics.
        /// </summary>
        public string ResolveVersionConstraint(string configFilePath)
        {
            var visited = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
            var currentPath = Path.GetFullPath(configFilePath);
            var depth = 0;

            while (currentPath != null)
            {
                if (depth > MaxExtendsChainDepth)
                {
                    throw new AzPSApplicationException(string.Format(Properties.Resources.BicepConfigExtendsChainTooDeep, configFilePath, MaxExtendsChainDepth));
                }

                if (!visited.Add(currentPath))
                {
                    throw new AzPSApplicationException(string.Format(Properties.Resources.BicepConfigExtendsCycleDetected, configFilePath));
                }

                if (!dataStore.FileExists(currentPath))
                {
                    throw new AzPSApplicationException(string.Format(Properties.Resources.BicepConfigFileNotFound, currentPath, configFilePath));
                }

                var config = ParseConfigFile(currentPath);

                if (!string.IsNullOrEmpty(config.Bicep?.Version))
                {
                    // Note: this only captures the raw constraint string.
                    return config.Bicep.Version;
                }

                if (string.IsNullOrEmpty(config.Extends))
                {
                    currentPath = null;
                }
                else
                {
                    // Matches the Bicep compiler : 'extends' must be a
                    // relative path. Rejecting absolute paths here avoids silently following
                    // a path the real compiler would refuse to compile.
                    if (Path.IsPathRooted(config.Extends))
                    {
                        throw new AzPSApplicationException(string.Format(Properties.Resources.BicepConfigExtendsAbsolutePath, config.Extends, currentPath));
                    }

                    currentPath = Path.GetFullPath(Path.Combine(Path.GetDirectoryName(currentPath), config.Extends));
                }

                depth++;
            }

            return null;
        }

        /// <summary>
        /// Convenience method combining config discovery and 'extends' chain resolution.
        /// Returns null if no bicepconfig.json applies, or none in the chain specifies a
        /// 'bicep.version'.
        /// </summary>
        public string ResolveEffectiveVersion(string entrypointFilePath)
        {
            var configFilePath = FindNearestConfigFile(entrypointFilePath);
            return configFilePath == null ? null : ResolveVersionConstraint(configFilePath);
        }

        private BicepConfigFile ParseConfigFile(string configFilePath)
        {
            var contents = dataStore.ReadFileAsText(configFilePath);

            try
            {
                return JsonConvert.DeserializeObject<BicepConfigFile>(contents) ?? new BicepConfigFile();
            }
            catch (JsonException ex)
            {
                throw new AzPSApplicationException(string.Format(Properties.Resources.BicepConfigInvalidJson, configFilePath, ex.Message));
            }
        }
    }
}
