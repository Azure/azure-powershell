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
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace Microsoft.Azure.PowerShell.AuthenticationAssemblyLoadContext
{
    /// <summary>
    /// Assemblies that the host process (PowerShell and its .NET runtime) already provides.
    /// </summary>
    /// <remarks>
    /// If an assembly such as System.Text.Json is loaded both from the runtime and from Az.Accounts,
    /// the process ends up with two copies of the same types and calls across them fail with
    /// MissingMethodException. Deferring to the runtime copy when it is new enough keeps a single copy.
    /// </remarks>
    internal static class RuntimeProvidedAssemblies
    {
        private static readonly Lazy<IDictionary<string, string>> TrustedPlatformAssemblyPaths =
            new Lazy<IDictionary<string, string>>(() => ParseTrustedPlatformAssemblies(AppContext.GetData("TRUSTED_PLATFORM_ASSEMBLIES") as string));

        private static readonly ConcurrentDictionary<string, Version> Versions = new ConcurrentDictionary<string, Version>(StringComparer.OrdinalIgnoreCase);

        /// <summary>
        /// Whether the runtime copy of <paramref name="requestedAssemblyName"/> should be used instead of the copy shipped in Az.Accounts.
        /// </summary>
        internal static bool ShouldUseRuntimeCopy(AssemblyName requestedAssemblyName, Version shippedVersion)
        {
            return IsSatisfiedByRuntime(GetRuntimeVersion(requestedAssemblyName.Name), shippedVersion, requestedAssemblyName.Version);
        }

        /// <summary>
        /// The runtime copy is used only when it is at least as new as both the shipped copy and the requested version.
        /// </summary>
        internal static bool IsSatisfiedByRuntime(Version runtimeVersion, Version shippedVersion, Version requestedVersion)
        {
            return runtimeVersion != null
                && shippedVersion != null
                && runtimeVersion >= shippedVersion
                && (requestedVersion == null || runtimeVersion >= requestedVersion);
        }

        internal static Version GetRuntimeVersion(string assemblyName)
        {
            if (string.IsNullOrEmpty(assemblyName) || !TrustedPlatformAssemblyPaths.Value.TryGetValue(assemblyName, out var path))
            {
                return null;
            }

            return Versions.GetOrAdd(assemblyName, _ =>
            {
                try
                {
                    return AssemblyName.GetAssemblyName(path).Version;
                }
                catch
                {
                    return null;
                }
            });
        }

        internal static IDictionary<string, string> ParseTrustedPlatformAssemblies(string trustedPlatformAssemblies)
        {
            var paths = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
            if (string.IsNullOrEmpty(trustedPlatformAssemblies))
            {
                return paths;
            }

            foreach (var path in trustedPlatformAssemblies.Split(Path.PathSeparator, StringSplitOptions.RemoveEmptyEntries))
            {
                if (path.EndsWith(".dll", StringComparison.OrdinalIgnoreCase))
                {
                    paths[Path.GetFileNameWithoutExtension(path)] = path;
                }
            }
            return paths;
        }
    }
}
