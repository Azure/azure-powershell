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
using System.Reflection;

namespace StaticAnalysis.DependencyAnalyzer
{
    /// <summary>
    /// A class using .Net Remoting to load assemblies and retrieve information in a separate app domain
    /// </summary>
    public class AssemblyLoader : MarshalByRefObject
    {
        /// <summary>
        /// Load the assembly in the reflection context by name. Will succeed if the referenced assembly name can 
        /// be found using default assembly loading rules (i.e. it is in the current directory or the GAC)
        /// </summary>
        /// <param name="assemblyName">The full name of the assembly</param>
        /// <returns>Information on the given assembly, if it was loaded successfully, or null if there is an 
        /// assembly loading issue. </returns>
        public AssemblyMetadata GetReflectedAssemblyInfo(string assemblyName)
        {
            if (string.IsNullOrWhiteSpace(assemblyName))
            {
                throw new ArgumentException("assemblyName");
            }

            AssemblyMetadata result = null;
            try
            {
                result = new AssemblyMetadata(Assembly.ReflectionOnlyLoad(assemblyName));
            }
            catch
            {
            }

            return result;
        }

        /// <summary>
        /// Load the assembly found at the given path in the reflection context and return assembly metadata
        /// </summary>
        /// <param name="assemblyPath">The full path to the assembly file.</param>
        /// <returns>Assembly metadata if the assembly is loaded successfully, or null if there are load errors.</returns>
        public AssemblyMetadata GetReflectedAssemblyFromFile(string assemblyPath)
        {
            if (string.IsNullOrWhiteSpace(assemblyPath))
            {
                throw new ArgumentException("assemblyPath");
            }

            AssemblyMetadata result = null;
            try
            {
                return new AssemblyMetadata(Assembly.ReflectionOnlyLoadFrom(assemblyPath));
            }
            catch
            {
            }

            return result;
        }
    }
}
