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
    /// Equality comparer, used to uniquely store assembly records by assembly name
    /// </summary>
    public class AssemblyNameComparer : IEqualityComparer<AssemblyName>
    {
        private static string GetComparisonName(AssemblyName name)
        {
            if (name == null)
            {
                throw new ArgumentNullException("name");
            }

            return string.Format("{0}.v{1}", name.Name, name.Version);
        }

        public bool Equals(AssemblyName assembly1, AssemblyName assembly2)
        {
            if (assembly1 == null)
            {
                throw new ArgumentNullException("assembly1");
            }

            if (assembly2 == null)
            {
                throw new ArgumentNullException("assembly2");
            }

            return StringComparer.OrdinalIgnoreCase.Equals(GetComparisonName(assembly1), GetComparisonName(assembly2));
        }

        public int GetHashCode(AssemblyName obj)
        {
            return StringComparer.OrdinalIgnoreCase.GetHashCode(GetComparisonName(obj));
        }
    }
}
