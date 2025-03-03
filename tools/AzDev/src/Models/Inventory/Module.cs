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
using System.IO.Abstractions;
using System.Linq;
using AzDev.Services;

namespace AzDev.Models.Inventory
{
    internal class Module : IFileSystemBasedModel
    {
        public string Name { get; internal set; }
        public string Path { get; internal set; }
        public IEnumerable<Project> Projects { get; internal set; } = Enumerable.Empty<Project>();
        public ModuleType Type { get; internal set; }
        public string TypeDeductionReason { get; internal set; }

        protected IFileSystem FileSystem { get; }
        protected Module(IFileSystem fs, string path)
        {
            FileSystem = fs;
            Path = path;
        }
        internal Module() { }

        public static Module FromFileSystem(IFileSystem fs, ILogger logger, string path)
        {
            Module m = new Module(fs, path)
            {
                Name = fs.Path.GetFileName(path),
                Projects = fs.Directory.GetDirectories(path)
                    .Where(dir =>
                    {
                        var exclude = Conventions.IsExcludedProjectDirectory(fs, dir, out var r);
                        if (exclude) logger.Debug($"Excluding project directory '{dir}' because {r}");
                        return !exclude;
                    })
                    .Select(dir => Project.FromFileSystem(fs, dir))
                    .ToList()
            };

            (m.Type, m.TypeDeductionReason) = (Conventions.DeductModuleType(m.Projects, out string reason), reason);
            return m;
        }
    }
}
