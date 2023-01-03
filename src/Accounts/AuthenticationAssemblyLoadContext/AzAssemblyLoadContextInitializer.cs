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
using System.Runtime.Loader;
using Microsoft.Azure.PowerShell.AssemblyLoading;

namespace Microsoft.Azure.PowerShell.AuthenticationAssemblyLoadContext
{
    public static class AzAssemblyLoadContextInitializer
    {
        private static ConcurrentDictionary<string, (string Path, Version Version)> AzSharedAssemblyMap { get; set; }
        private static ConcurrentDictionary<string, string> ModuleAlcEntryAssemblyMap { get; set; }

        static AzAssemblyLoadContextInitializer()
        {
            var azSharedAssemblies = ConditionalAssemblyProvider.GetAssemblies();
            AzSharedAssemblyMap = new ConcurrentDictionary<string, (string, Version)>(azSharedAssemblies, StringComparer.OrdinalIgnoreCase);
            ModuleAlcEntryAssemblyMap = new ConcurrentDictionary<string, string>();
        }

        /// <summary>
        /// Registers the shared ALC and listen to assembly resolving event of the default ALC.
        /// </summary>
        public static void RegisterAzSharedAssemblyLoadContext()
        {
            AssemblyLoadContext.Default.Resolving += Default_Resolving;
        }

        /// <summary>
        /// Registers an ALC to be instantiated later.
        /// </summary>
        /// <param name="contextEntryAssembly">Name of the entry assembly, typically "{Module}.AlcWrapper.dll". It must be unique for each module.</param>
        /// <param name="directory">Root directory to look for assemblies.</param>
        public static void RegisterModuleAssemblyLoadContext(string contextEntryAssembly, string directory)
        {
            ModuleAlcEntryAssemblyMap.TryAdd(contextEntryAssembly, directory);
        }

        private static System.Reflection.Assembly Default_Resolving(AssemblyLoadContext context, System.Reflection.AssemblyName assemblyName)
        {
            if (AzSharedAssemblyMap.TryGetValue(assemblyName.Name, out var azSharedAssembly) && azSharedAssembly.Version >= assemblyName.Version)
            {
                return AzAssemblyLoadContext.GetForDirectory(AzSharedAssemblyLoadContext.Key).LoadFromAssemblyName(assemblyName);
            }

            if (ModuleAlcEntryAssemblyMap.TryGetValue(assemblyName.Name, out string moduleLoadContextDirectory))
            {
                return AzAssemblyLoadContext.GetForDirectory(moduleLoadContextDirectory).LoadFromAssemblyPath(Path.Combine(moduleLoadContextDirectory, assemblyName.Name + ".dll"));
            }
            return null;
        }
    }
}
