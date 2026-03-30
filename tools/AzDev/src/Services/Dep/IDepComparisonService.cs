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

using System.Collections.Generic;
using AzDev.Models.Dep;

namespace AzDev.Services.Dep
{
    /// <summary>
    /// Interface for comparing package dependencies.
    /// </summary>
    internal interface IDepComparisonService
    {
        /// <summary>
        /// Compares dependencies between two versions of a package.
        /// </summary>
        /// <param name="packageName">The name of the package to compare.</param>
        /// <param name="oldVersion">The old version of the package.</param>
        /// <param name="newVersion">The new version of the package.</param>
        /// <param name="targetFramework">The target framework (e.g., "netstandard2.0").</param>
        /// <returns>A list of dependency differences.</returns>
        IEnumerable<PackageDepDiff> ComparePackageDependencies(
            string packageName,
            string oldVersion,
            string newVersion,
            string targetFramework);
    }
}
