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
    public class AssemblyNameComparer : IEqualityComparer<AssemblyName>
    {
        public static string GetComparisonName(AssemblyName name)
        {
            return string.Format("{0}.v{1}", name.Name, name.Version);
        }

        public bool Equals(AssemblyName x, AssemblyName y)
        {
            return StringComparer.OrdinalIgnoreCase.Equals(GetComparisonName(x), GetComparisonName(y));
        }

        public int GetHashCode(AssemblyName obj)
        {
            return StringComparer.OrdinalIgnoreCase.GetHashCode(GetComparisonName(obj));
        }
    }
}
