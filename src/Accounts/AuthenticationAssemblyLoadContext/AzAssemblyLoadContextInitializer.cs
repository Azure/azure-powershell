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
using System.Runtime.Loader;

namespace Microsoft.Azure.PowerShell.AuthenticationAssemblyLoadContext
{
    public static class AzAssemblyLoadContextInitializer
    {
        private static string AzSharedAssemblyDirectory { get; set; }
        private static ConcurrentDictionary<string, Version> AzSharedAssemblyMap { get; set; }
        private static ConcurrentDictionary<string, string> ModuleAlcEntryAssemblyMap { get; set; }

        static AzAssemblyLoadContextInitializer()
        {
            //TODO: Generate assembly version info into AzSharedAssemblies.json during build
            var azSharedAssemblies = new Dictionary<string, Version>()
            {
                {"Azure.Core", new Version("1.25.0.0")},
                {"Azure.Identity", new Version("1.6.0.0")},
                {"Microsoft.Bcl.AsyncInterfaces", new Version("1.1.1.0")},
                {"Microsoft.Identity.Client", new Version("4.39.0.0") },
                {"Microsoft.Identity.Client.Extensions.Msal", new Version("2.19.3.0") },
                {"System.Memory.Data", new Version("1.0.2.0")},
                {"System.Text.Json", new Version("4.0.1.2")},
            };

            AzSharedAssemblyMap = new ConcurrentDictionary<string, Version>(azSharedAssemblies, StringComparer.OrdinalIgnoreCase);

            ModuleAlcEntryAssemblyMap = new ConcurrentDictionary<string, string>();
        }

        /// <summary>
        /// Registers the shared ALC and listen to assembly resolving event of the default ALC.
        /// </summary>
        /// <param name="azSharedAssemblyDirectory">Root directory to look for assemblies.</param>
        public static void RegisterAzSharedAssemblyLoadContext(string azSharedAssemblyDirectory)
        {
            AzSharedAssemblyDirectory = azSharedAssemblyDirectory;
            AssemblyLoadContext.Default.Resolving += Default_Resolving;
        }

        /// <summary>
        /// Registers an ALC to be instanciated later.
        /// </summary>
        /// <param name="contextEntryAssembly">Name of the entry assembly, typically "{Module}.AlcWrapper.dll". It must be unique for each module.</param>
        /// <param name="directory">Root directory to look for assemblies.</param>
        public static void RegisterModuleAssemblyLoadContext(string contextEntryAssembly, string directory)
        {
            ModuleAlcEntryAssemblyMap.TryAdd(contextEntryAssembly, directory);
        }

        private static System.Reflection.Assembly Default_Resolving(AssemblyLoadContext context, System.Reflection.AssemblyName assemblyName)
        {
            if (AzSharedAssemblyMap.ContainsKey(assemblyName.Name) && AzSharedAssemblyMap[assemblyName.Name] >= assemblyName.Version)
            {
                return AzAssemblyLoadContext.GetForDirectory(AzSharedAssemblyDirectory).LoadFromAssemblyName(assemblyName);
            }

            if (ModuleAlcEntryAssemblyMap.TryGetValue(assemblyName.Name, out string moduleLoadContextDirectory))
            {
                return AzAssemblyLoadContext.GetForDirectory(moduleLoadContextDirectory).LoadFromAssemblyPath(Path.Combine(moduleLoadContextDirectory, assemblyName.Name + ".dll"));
            }
            return null;
        }
    }
}
