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
using System.IO.Abstractions;
using System.Linq;
using AzDev.Models.Inventory;

namespace AzDev.Services
{
    internal static class Conventions
    {
        public static bool IsAutorestBasedProject(string path, out string reason)
        {
            if (path.EndsWith(".autorest", StringComparison.InvariantCultureIgnoreCase))
            {
                reason = $"[{path}] ends with '.autorest'.";
                return true;
            }
            else
            {
                reason = $"[{path}] does not end with '.autorest'.";
                return false;
            }
        }

        public static bool IsExcludedModuleDirectory(string dir)
        {
            var slash = System.IO.Path.DirectorySeparatorChar;
            return dir.EndsWith($"{slash}shared") || dir.EndsWith($"{slash}{FileOrDirNames.Lib}");
        }

        internal static bool IsLegacyHelperProject(string path, out string reason)
        {
            if (path.EndsWith(".helper", StringComparison.InvariantCultureIgnoreCase))
            {
                reason = $"[{path}] ends with '.helper'.";
                return true;
            }
            else if (path.EndsWith(".helpers", StringComparison.InvariantCultureIgnoreCase))
            {
                reason = $"[{path}] ends with '.helpers'.";
                return true;
            }
            else
            {
                reason = $"[{path}] does not end with '.helper' or '.helpers'.";
                return false;
            }
        }

        internal static bool IsTestProject(string path, out string reason)
        {
            if (path.EndsWith(".test", StringComparison.InvariantCultureIgnoreCase))
            {
                reason = $"[{path}] ends with '.test'.";
                return true;
            }
            else
            {
                reason = $"[{path}] does not end with '.test'.";
                return false;
            }
        }

        internal static bool IsTrack1SdkProject(string path, out string reason)
        {
            if (path.EndsWith(".management.sdk", StringComparison.InvariantCultureIgnoreCase))
            {
                reason = $"[{path}] ends with '.management.sdk'.";
                return true;
            }
            if (path.EndsWith(".sdk", StringComparison.InvariantCultureIgnoreCase)) // legacy naming
            {
                reason = $"[{path}] ends with '.sdk' but not '.management.sdk. This is not allowed after Az 13.";
                return true;
            }
            else
            {
                reason = $"[{path}] does not end with '.management.sdk'.";
                return false;
            }
        }

        internal static bool IsSwaggerReferenceLocal(string path)
        {
            return path.TrimStart().StartsWith("..", StringComparison.InvariantCultureIgnoreCase);
        }

        internal static bool IsExcludedProjectDirectory(IFileSystem fs, string path, out string reason)
        {
            if (path.StartsWith(".") || fs.Path.GetFileName(path).StartsWith("."))
            {
                reason = "Path starts with '.' or contains a dir/file starting with '.'.";
                return true;
            }

            if (!TryGetOnlyCsprojPath(fs, path, out var _, out var cannotFindCsproj)
                && !IsAutorestBasedProject(path, out var notAutorestBased))
            {
                reason = $"Path does not contain a single .csproj file: {cannotFindCsproj} and is not autorest based: {notAutorestBased}";
                return true;
            }

            reason = null;
            return false;
        }

        internal static bool IsAutorestInputButNotSwagger(string uri)
        {
            return uri.EndsWith("readme.azure.noprofile.md", StringComparison.InvariantCultureIgnoreCase);
        }

        internal static bool IsWrapperProject(IFileSystem fs, string path, out string typeDeductionReason)
        {
            if (!TryGetOnlyCsprojPath(fs, path, out var csproj, out var reason))
            {
                typeDeductionReason = $"Failed to get csproj path: {reason}";
                return false;
            }

            var project = CsprojReader.Parse(fs.File.ReadAllText(csproj));
            if (project.PackageReferences.Any() || project.ProjectReferences.Any())
            {
                typeDeductionReason = $"[{csproj} has package references or project reference.";
                return false;
            }
            else if (fs.Directory.GetParent(path).Name.Equals(fs.Path.GetFileName(path), StringComparison.InvariantCultureIgnoreCase))
            {
                typeDeductionReason = $"[{csproj}] does not contain package references or project reference and is in a dir named the same as its parent.";
                return true;
            }
            else
            {
                typeDeductionReason = $"[{csproj}] does not contain package references or project reference but dir name is different from parent dir.";
                return false;
            }
        }

        private static bool TryGetOnlyCsprojPath(IFileSystem fs, string path, out string csproj, out string failureReason)
        {
            var csprojs = fs.Directory.GetFiles(path, "*.csproj", System.IO.SearchOption.TopDirectoryOnly);
            if (csprojs.Length != 1)
            {
                csproj = null;
                failureReason = $"[{path}] contains {csprojs.Length} .csproj files. Expected: 1.";
                return false;
            }
            else
            {
                csproj = csprojs[0];
                failureReason = null;
                return true;
            }
        }

        internal static bool IsSdkBasedProject(IFileSystem fs, string path, out string typeDeductionReason)
        {
            if (!TryGetOnlyCsprojPath(fs, path, out var csproj, out var reason))
            {
                typeDeductionReason = $"Failed to get csproj path: {reason}";
                return false;
            }

            var project = CsprojReader.Parse(fs.File.ReadAllText(csproj));
            if (project.PackageReferences.Any(p =>
                    p.StartsWith("Microsoft.Azure.Management.") // track 1 management plane
                    || p.StartsWith("Microsoft.Azure.") // track 1 data plane
                    || p.StartsWith("Azure.")) // track 2 data plane
                || project.ProjectReferences.Any(p =>
                    p.EndsWith(".Management.Sdk.csproj") // local sdk
                    || p.EndsWith(".Helpers.csproj"))) // local sdk helpers
            {
                typeDeductionReason = $"[{csproj} contains package references to track 1 sdk package or project reference to track 1 sdk project.";
                return true;
            }
            else
            {
                typeDeductionReason = $"[{csproj}] does not contain package references nor project reference to track 1 sdk.";
                return false;
            }
        }

        internal static ModuleType DeductModuleType(IEnumerable<Project> projects, out string reason)
        {
            var projectTypes = projects.Select(p => p.Type);

            if (projectTypes.Contains(ProjectType.LegacyHelper) && !projectTypes.Contains(ProjectType.SdkBased))
            {
                projectTypes = projectTypes.Concat(new[] { ProjectType.SdkBased });
            }

            if (projectTypes.Contains(ProjectType.AutoRestBased) && projectTypes.Contains(ProjectType.SdkBased))
            {
                reason = "Projects in module consist of AutoRestBased and SdkBased.";
                return ModuleType.Hybrid;
            }
            if (projectTypes.Contains(ProjectType.AutoRestBased))
            {
                reason = "Projects in module consist of AutoRestBased but not SdkBased.";
                return ModuleType.AutoRestBased;
            }
            if (projectTypes.Contains(ProjectType.SdkBased))
            {
                reason = "Projects in module consist of SdkBased but not AutoRestBased.";
                return ModuleType.SdkBased;
            }
            reason = "Projects in module do not consist of AutoRestBased nor SdkBased.";
            return ModuleType.Other;
        }
    }
}
