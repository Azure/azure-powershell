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
    internal class AzAssemblyLoadContext : AssemblyLoadContext
    {
        private string AssemblyDirectory { get; set; }

        private static readonly ConcurrentDictionary<string, AzAssemblyLoadContext> DependencyLoadContexts = new ConcurrentDictionary<string, AzAssemblyLoadContext>();

        internal static AzAssemblyLoadContext GetForDirectory(string directoryPath)
        {
            return DependencyLoadContexts.GetOrAdd(directoryPath, (path) => new AzAssemblyLoadContext(path));
        }

        public AzAssemblyLoadContext(string directory)
        {
            AssemblyDirectory = directory;
        }

        protected override Assembly Load(AssemblyName assemblyName)
        {
            //TODO: Use cache for loaded assemblies, may refer to PowerShell code https://github.com/PowerShell/PowerShell/blob/8f8ddc3fb76a03dad93f5664314c2795dd69f390/src/System.Management.Automation/CoreCLR/CorePsAssemblyLoadContext.cs

            string assemblyFileName = $"{assemblyName.Name}.dll";

            // Now try to load the assembly from the dependency directory
            string dependencyAsmPath = Path.Join(AssemblyDirectory, assemblyFileName);
            if (File.Exists(dependencyAsmPath))
            {
                return LoadFromAssemblyPath(dependencyAsmPath);
            }

            return null;
        }
    }
}
