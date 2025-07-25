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
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;

using Tools.Common.Models;

namespace Tools.Common.Loaders
{
    public class AssemblyMetadataLoader
    {
        //MetadataLoadContext allows to load different versions of one assembly
        private MetadataLoadContext _metadataLoadContext;

        public AssemblyMetadataLoader()
        {
            var files = Directory.GetFiles(RuntimeEnvironment.GetRuntimeDirectory(), "*.dll");
            MetadataAssemblyResolver metadataAssemblyResolver = new PathAssemblyResolver(files);
            _metadataLoadContext = new MetadataLoadContext(metadataAssemblyResolver);
        }

        public AssemblyMetadata GetReflectedAssemblyFromFile(string assemblyPath)
        {
            if (string.IsNullOrWhiteSpace(assemblyPath))
            {
                throw new ArgumentException("assemblyPath");
            }

            var assembly = _metadataLoadContext.LoadFromAssemblyPath(assemblyPath);
            return new AssemblyMetadata(assembly);
        }
    }
}
