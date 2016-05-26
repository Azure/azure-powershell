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
using System.Linq;
using System.Reflection;
using System.Text;

namespace StaticAnalysis.DependencyAnalyzer
{
    /// <summary>
    /// Information about assemblies
    /// </summary>
    public class AssemblyRecord : ICloneable
    {
        HashSet<AssemblyRecord> _parents = new HashSet<AssemblyRecord>();
        IList<AssemblyName> _children = new List<AssemblyName>();
        /// <summary>
        /// The path to the assembly
        /// </summary>
        public string Location { get; set; }

        public string Name { get { return AssemblyName.Name; } }
        public Version Version { get { return AssemblyName.Version; } }
        public HashSet<AssemblyRecord> ReferencingAssembly { get { return _parents; } }

        public IList<AssemblyName> Children { get { return _children; } }

        public AssemblyName AssemblyName { get; set; }

        /// <summary>
        /// The majorVersion portion of the file version for the assembly.  This may or may not match the assembly version
        /// </summary>
        public int AssemblyFileMajorVersion { get; set; }

        /// <summary>
        /// The minorVersion portion of the file version for the assembly file. This may or may not match the corresponding 
        /// part of the assembly version.
        /// </summary>
        public int AssemblyFileMinorVersion { get; set; }

        public override bool Equals(object obj)
        {
            var assembly = obj as AssemblyRecord;
            if (assembly != null)
            {
                return string.Equals(assembly.Name, Name, StringComparison.OrdinalIgnoreCase) &&
                       assembly.Version == Version;
            }

            return false;
        }

        public object Clone()
        {
            var copiedParents = new HashSet<AssemblyRecord>();
            foreach (var parent in _parents)
            {
                copiedParents.Add(parent.Clone() as AssemblyRecord);
            }

            return new AssemblyRecord()
            {
                _parents = copiedParents,
                AssemblyFileMajorVersion = AssemblyFileMajorVersion,
                AssemblyFileMinorVersion = AssemblyFileMinorVersion,
                AssemblyName = AssemblyName,
                Location = Location
            };

        }

        /// <summary>
        /// Compare the assembly record to an assembly name
        /// </summary>
        /// <param name="assembly">The assembly name to compare with</param>
        /// <returns>True if the assembly name is a reference to this assembly, otherwise false</returns>
        public bool Equals(AssemblyName assembly)
        {
            return string.Equals(assembly.Name, Name, StringComparison.OrdinalIgnoreCase) &&
                   assembly.Version == Version;
        }

        public bool Equals(AssemblyRecord record)
        {
            return Equals(record.AssemblyName)
                && AssemblyFileMajorVersion == record.AssemblyFileMajorVersion
                && AssemblyFileMinorVersion == record.AssemblyFileMinorVersion;
        }

        public override string ToString()
        {
            StringBuilder output = new StringBuilder();
            output.AppendLine(string.Format("AssemblyName: {0}, Version:{1}, FileVersion: {2}.{3}, Location:{4}", 
                Name, Version, AssemblyFileMajorVersion, AssemblyFileMinorVersion, Location));
            if (ReferencingAssembly.Any())
            {
                output.AppendFormat("-> Parents: ({0})", string.Join(", ", ReferencingAssembly));
            }

            return output.ToString();

        }

        public override int GetHashCode()
        {
            return string.Format("{0}-{1}-{2}", AssemblyName, AssemblyFileMajorVersion, AssemblyFileMinorVersion).GetHashCode();
        }


        /// <summary>
        /// Get all the ancestors in the ancestor tree
        /// </summary>
        /// <returns>The full set of ancestors in the ancestor tree.</returns>
        public HashSet<AssemblyRecord> GetAncestors()
        {
            var result = new HashSet<AssemblyRecord>();
            foreach (var parent in ReferencingAssembly)
            {
                result.Add(parent);
                foreach (var grandParent in parent.GetAncestors())
                {
                    result.Add(grandParent);
                }

            }

            return result;
        }
    }
}
