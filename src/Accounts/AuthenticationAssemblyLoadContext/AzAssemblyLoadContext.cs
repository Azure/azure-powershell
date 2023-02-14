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

using System.Collections.Concurrent;
using System.IO;
using System.Reflection;
using System.Runtime.Loader;

namespace Microsoft.Azure.PowerShell.AuthenticationAssemblyLoadContext
{
    /// <summary>
    /// Assembly load context of a service module.
    /// The way of looking for assemblies is based on directory.
    /// </summary>
    internal class AzAssemblyLoadContext : AzAssemblyLoadContextBase
    {
        private string AssemblyDirectory { get; set; }

        private static readonly ConcurrentDictionary<string, AssemblyLoadContext> DependencyLoadContexts = new ConcurrentDictionary<string, AssemblyLoadContext>();

        /// <summary>
        /// Get an ALC for a certain directory that contains assemblies.
        /// </summary>
        /// <remarks>
        /// There are two types of possible value for <paramref name="directoryPath"/>:
        /// 1. <see cref="AzSharedAssemblyLoadContext.Key"/> which will create if not exist and return an ALC for shared libraries.
        /// 2. A directory in a service module that contains the assemblies to be loaded into the ALC of the service module.
        /// </remarks>
        internal static AssemblyLoadContext GetForDirectory(string directoryPath)
        {
            return DependencyLoadContexts.GetOrAdd(directoryPath, path => path.Equals(AzSharedAssemblyLoadContext.Key) ? new AzSharedAssemblyLoadContext() : (AssemblyLoadContext)new AzAssemblyLoadContext(directoryPath));
        }

        /// <summary>
        /// Initialize an `AzAssemblyLoadContext` instance.
        /// </summary>
        /// <param name="directory">Root directory to look for assembly.</param>
        /// <returns></returns>
        public AzAssemblyLoadContext(string directory) : base(directory)
        {
            AssemblyDirectory = directory;
        }

        protected override Assembly LoadAfterCacheMiss(AssemblyName requestedAssemblyName)
        {
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
                    CacheAssembly(loadedAssemblyName.Name, loadedAssembly);
                }
                return loadedAssembly;
            }

            return null;
        }
    }
}
