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
using System.IO;
using System.Reflection;
using System.Runtime.Loader;

namespace Microsoft.Azure.PowerShell.AuthenticationAssemblyLoadContext
{
    internal class AzAssemblyLoadContext : AssemblyLoadContext
    {
        private string AssemblyDirectory { get; set; }

        private ConcurrentDictionary<string, Assembly> AssemblyCache { get; set; } =
            new ConcurrentDictionary<string, Assembly>(StringComparer.OrdinalIgnoreCase);

        private static readonly ConcurrentDictionary<string, AzAssemblyLoadContext> DependencyLoadContexts = new ConcurrentDictionary<string, AzAssemblyLoadContext>();

        internal static AzAssemblyLoadContext GetForDirectory(string directoryPath)
        {
            return DependencyLoadContexts.GetOrAdd(directoryPath, (path) => new AzAssemblyLoadContext(path));
        }

        /// <summary>
        /// Initialize an `AzAssemblyLoadContext` instance.
        /// </summary>
        /// <param name="directory">Root directory to look for assembly.</param>
        /// <returns></returns>
        public AzAssemblyLoadContext(string directory)
        {
            AssemblyDirectory = directory;
        }

        protected override Assembly Load(AssemblyName requestedAssemblyName)
        {
            if (AssemblyCache.TryGetValue(requestedAssemblyName.Name, out Assembly assembly))
            {
                if (IsAssemblyMatching(requestedAssemblyName, assembly.GetName()))
                {
                    return assembly;
                }
            }

            string assemblyFileName = $"{requestedAssemblyName.Name}.dll";

            // Now try to load the assembly from the dependency directory
            string dependencyAsmPath = Path.Join(AssemblyDirectory, assemblyFileName);
            if (File.Exists(dependencyAsmPath))
            {
                //Assembly.ReflectionOnlyLoadFrom
                var loadedAssembly = LoadFromAssemblyPath(dependencyAsmPath);
                var loadedAssemblyName = loadedAssembly.GetName();
                if (IsAssemblyMatching(requestedAssemblyName, loadedAssemblyName))
                {
                    AssemblyCache.TryAdd(loadedAssemblyName.Name, loadedAssembly);
                }
                return loadedAssembly;
            }

            return null;
        }

        private bool IsAssemblyMatching(AssemblyName requestedAssembly, AssemblyName loadedAssembly)
        {
            // We use the same rules as CoreCLR loader to compare the requested assembly and loaded assembly:
            //  1. If 'Version' of the requested assembly is specified, then the requested version should be less or equal to the loaded version;
            //  2. If 'CultureName' of the requested assembly is specified (not NullOrEmpty), then the CultureName of the loaded assembly should be the same;
            //  3. If 'PublicKeyToken' of the requested assembly is specified (not Null or EmptyArray), then the PublicKenToken of the loaded assembly should be the same.

            // Version of the requested assembly should be the same or before the version of loaded assembly
            if (requestedAssembly.Version != null && requestedAssembly.Version.CompareTo(loadedAssembly.Version) > 0)
            {
                return false;
            }

            // CultureName of requested assembly and loaded assembly should be the same
            string requestedCultureName = requestedAssembly.CultureName;
            if (!string.IsNullOrEmpty(requestedCultureName) && !requestedCultureName.Equals(loadedAssembly.CultureName, StringComparison.OrdinalIgnoreCase))
            {
                return false;
            }

            // PublicKeyToken should be the same, unless it's not specified in the requested assembly
            byte[] requestedPublicKeyToken = requestedAssembly.GetPublicKeyToken();
            byte[] loadedPublicKeyToken = loadedAssembly.GetPublicKeyToken();

            if (requestedPublicKeyToken != null && requestedPublicKeyToken.Length > 0)
            {
                if (loadedPublicKeyToken == null || requestedPublicKeyToken.Length != loadedPublicKeyToken.Length)
                    return false;

                for (int i = 0; i < requestedPublicKeyToken.Length; i++)
                {
                    if (requestedPublicKeyToken[i] != loadedPublicKeyToken[i])
                        return false;
                }
            }

            return true;
        }
    }
}
