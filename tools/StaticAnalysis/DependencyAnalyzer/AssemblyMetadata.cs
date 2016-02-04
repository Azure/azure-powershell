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
using System.Collections.Generic;
using System.Reflection;

namespace StaticAnalysis.DependencyAnalyzer
{
    /// <summary>
    /// Serializable assembly metadata class, used to return assembly information from a remote AppDomain
    /// </summary>
    [Serializable]
    public class AssemblyMetadata
    {
        AssemblyName _name;
        string _location;
        IList<AssemblyName> _references;

        public AssemblyMetadata(Assembly assembly)
        {
            if (assembly == null)
            {
                throw new ArgumentNullException("assembly");
            }

            _name = assembly.GetName();
            _location = assembly.Location;
            _references = new List<AssemblyName>();
            foreach (var child in assembly.GetReferencedAssemblies())
            {
                _references.Add(child);
            }
        }

        /// <summary>
        /// Path to the assembly.
        /// </summary>
        public string Location { get { return _location; } }

        /// <summary>
        /// The assembly name
        /// </summary>
        /// <returns>The assembly name for this assembly, including name and the version</returns>
        public AssemblyName GetName()
        {
            return _name;
        }

        /// <summary>
        /// The list of referenced assemblies
        /// </summary>
        /// <returns>A list of assembly name references for all assemblies referenced in the assembly manifest</returns>
        public IEnumerable<AssemblyName> GetReferencedAssemblies()
        {
            return _references;
        }
    }
}
