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

using Microsoft.Azure.PowerShell.AssemblyLoading;
using System;
using System.Collections.Concurrent;
using System.IO;
using System.Reflection;

namespace Microsoft.Azure.PowerShell.AuthenticationAssemblyLoadContext
{
    /// <summary>
    /// Assembly load context of the shared assemblies in Az.Accounts module.
    /// Assemblies are provided by <see cref="ConditionalAssemblyProvider"/>.
    /// </summary>
    internal class AzSharedAssemblyLoadContext : AzAssemblyLoadContextBase
    {
        /// <summary>
        /// Key to get the shared ALC.
        /// </summary>
        public const string Key = nameof(AzSharedAssemblyLoadContext);

        private ConcurrentDictionary<string, (string Path, Version Version)> _assemblies;

        public AzSharedAssemblyLoadContext() : base(Key)
        {
            _assemblies = new ConcurrentDictionary<string, (string, Version)>(ConditionalAssemblyProvider.GetAssemblies(), StringComparer.OrdinalIgnoreCase);
        }

        protected override Assembly LoadAfterCacheMiss(AssemblyName requestedAssemblyName)
        {
            if (_assemblies.TryGetValue(requestedAssemblyName.Name, out var assembly)
                && File.Exists(assembly.Path))
            {
                var loadedAssembly = LoadFromAssemblyPath(assembly.Path);
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
