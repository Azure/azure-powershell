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
using AzDev.Models.Dep;
using AzDev.Services.Assembly;

namespace AzDev.Services.Dep
{
    internal class DefaultDepComparisonService : IDepComparisonService
    {
        private readonly INugetService _nugetService;
        private readonly ILogger _logger;

        public DefaultDepComparisonService(INugetService nugetService, ILogger logger)
        {
            _nugetService = nugetService;
            _logger = logger;
        }

        public IEnumerable<PackageDepDiff> ComparePackageDependencies(
            string packageName,
            string oldVersion,
            string newVersion,
            string targetFramework)
        {
            _logger.Debug($"[{nameof(DefaultDepComparisonService)}] Comparing {packageName} from {oldVersion} to {newVersion} for {targetFramework}");

            var oldDeps = _nugetService.GetPackageDependencies(packageName, oldVersion, targetFramework).ToList();
            var newDeps = _nugetService.GetPackageDependencies(packageName, newVersion, targetFramework).ToList();

            // Debug mode: list all dependencies
            _logger.Debug($"[{nameof(DefaultDepComparisonService)}] Old version {oldVersion} dependencies:");
            foreach (var dep in oldDeps)
            {
                _logger.Debug($"  - {dep.Id} {dep.Version}");
            }
            _logger.Debug($"[{nameof(DefaultDepComparisonService)}] New version {newVersion} dependencies:");
            foreach (var dep in newDeps)
            {
                _logger.Debug($"  - {dep.Id} {dep.Version}");
            }

            var results = new List<PackageDepDiff>();

            // Find dependencies that were added or changed
            foreach (var newDep in newDeps)
            {
                var oldDep = oldDeps.FirstOrDefault(d => d.Id.Equals(newDep.Id, StringComparison.OrdinalIgnoreCase));

                if (oldDep == null)
                {
                    // Dependency was added
                    results.Add(new PackageDepDiff
                    {
                        DepName = newDep.Id,
                        OldVersion = null,
                        NewVersion = newDep.Version,
                        ParentDep = packageName
                    });
                }
                else if (!oldDep.Version.Equals(newDep.Version))
                {
                    // Dependency version changed - add the immediate change
                    results.Add(new PackageDepDiff
                    {
                        DepName = newDep.Id,
                        OldVersion = oldDep.Version,
                        NewVersion = newDep.Version,
                        ParentDep = packageName
                    });

                    // Recursively compare the changed dependency
                    var recursiveChanges = ComparePackageDependencies(
                        newDep.Id,
                        oldDep.Version,
                        newDep.Version,
                        targetFramework);

                    results.AddRange(recursiveChanges);
                }
            }

            // Find dependencies that were removed
            foreach (var oldDep in oldDeps)
            {
                if (!newDeps.Any(d => d.Id.Equals(oldDep.Id, StringComparison.OrdinalIgnoreCase)))
                {
                    results.Add(new PackageDepDiff
                    {
                        DepName = oldDep.Id,
                        OldVersion = oldDep.Version,
                        NewVersion = null,
                        ParentDep = packageName
                    });
                }
            }

            return results;
        }
    }
}
