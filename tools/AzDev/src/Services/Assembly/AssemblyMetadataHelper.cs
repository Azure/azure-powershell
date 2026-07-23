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
using System.IO.Abstractions;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Runtime.Versioning;
using AzDev.Models.Assembly;

namespace AzDev.Services.Assembly
{
    internal class AssemblyMetadataService : IAssemblyMetadataService
    {
        private IFileSystem _fs;

        public AssemblyMetadataService(IFileSystem fs)
        {
            _fs = fs;
        }

        public RuntimeAssembly ParseAssemblyMetadata(string path)
        {
            string[] runtimeAssemblies = _fs.Directory.GetFiles(RuntimeEnvironment.GetRuntimeDirectory(), "*.dll");
            var resolver = new PathAssemblyResolver(runtimeAssemblies);

            // low priority: reuse mlc?
            using var mlc = new MetadataLoadContext(resolver);
            using var asmStream = _fs.File.OpenRead(path);

            try
            {
                var assembly = mlc.LoadFromStream(asmStream);
                AssemblyName name = assembly.GetName();
                return new RuntimeAssembly()
                {
                    Name = name?.Name,
                    Version = name?.Version,
                    TargetFramework = GetTargetFramework(assembly)
                };
            }
            catch (BadImageFormatException e)
            {
                throw new BadImageFormatException($"The file {path} is not a valid assembly. Please check the file.", e);
            }
        }

        private static string GetTargetFramework(System.Reflection.Assembly assembly)
        {
            return assembly.GetCustomAttributesData()
                .FirstOrDefault(x => x.AttributeType.ToString() == typeof(TargetFrameworkAttribute).ToString())
                ?.ConstructorArguments[0].Value?.ToString();
        }
    }
}
