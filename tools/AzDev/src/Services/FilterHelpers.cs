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
using AzDev.Models.Inventory;

namespace AzDev.Services
{
    internal static class FilterHelpers
    {
        private static IEqualityComparer<Project> projectByNameComparer = new ProjectNameComparer();

        public static IEnumerable<Project> FilterProjects(this Codebase codebase, string filter)
        {
            if (string.IsNullOrEmpty(filter))
            {
                throw new ArgumentException("Filter cannot be null or empty.");
            }
            var lowerFilter = filter.ToLower();
            var matchByModule = codebase.Modules.Where(m => m.Name.ToLower().Contains(lowerFilter)).SelectMany(m => m.Projects);
            var matchByProject = codebase.Modules.SelectMany(m => m.Projects).Where(p => p.Name.ToLower().Contains(lowerFilter));
            // todo: somehow they are duplicated projects with same properties but different references
            // for now, just distinct them by path and name
            // need to investigate why they are duplicated
            return matchByModule.Concat(matchByProject).Distinct(projectByNameComparer);
        }
    }

    internal class ProjectNameComparer : IEqualityComparer<Project>
    {
        public bool Equals(Project x, Project y)
        {
            return x.Path == y.Path && x.Name == y.Name;
        }

        public int GetHashCode(Project obj)
        {
            return obj.Path == null ? 0 : obj.Path.GetHashCode();
        }
    }
}
