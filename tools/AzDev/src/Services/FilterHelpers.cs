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
        /// <summary>
        /// Filter projects by name or module name.
        /// </summary>
        /// <param name="codebase"></param>
        /// <param name="filter">Can be part of a module or project name.</param>
        /// <returns>A collection of projects whose names match the filter, or whose parent modules' names match.</returns>
        /// <exception cref="ArgumentException"></exception>
        public static IEnumerable<Project> FilterProjects(this Codebase codebase, string filter)
        {
            if (string.IsNullOrEmpty(filter))
            {
                throw new ArgumentException("Filter cannot be null or empty.");
            }
            var lowerFilter = filter.ToLower();
            var matchByModule = codebase.Modules.Where(m => m.Name.ToLower().Contains(lowerFilter)).SelectMany(m => m.Projects);
            var matchByProject = codebase.Modules.SelectMany(m => m.Projects).Where(p => p.Name.ToLower().Contains(lowerFilter));
            return matchByModule.Concat(matchByProject).Distinct();
        }
    }
}
