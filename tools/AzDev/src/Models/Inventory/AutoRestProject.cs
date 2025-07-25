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
using System.IO;
using System.IO.Abstractions;
using System.Linq;
using System.Text.RegularExpressions;
using AzDev.Services;

namespace AzDev.Models.Inventory
{
    internal class AutoRestProject : Project
    {
        protected AutoRestProject(IFileSystem fs, string path) : base(fs, path)
        {
            _lazySwaggers = new Lazy<IEnumerable<SwaggerReference>>(LoadSwaggers);
            _lazyReadmeText = new Lazy<string>(() => LoadReadme());
        }
        internal AutoRestProject() {}
        public IEnumerable<SwaggerReference> Swaggers => _lazySwaggers.Value;
        private Lazy<IEnumerable<SwaggerReference>> _lazySwaggers;
        private string ReadmeText => _lazyReadmeText.Value;
        private Lazy<string> _lazyReadmeText;

        public new static AutoRestProject FromFileSystem(IFileSystem fs, string path)
        {
            return new AutoRestProject(fs, path)
            {
                Type = ProjectType.AutoRestBased,
                Name = fs.Path.GetFileName(path)
            };
        }

        private IEnumerable<SwaggerReference> LoadSwaggers()
        {
            Regex yamlBlockPattern = new Regex(@"(?ms)```\s*yaml(.*?)```");
            var matches = yamlBlockPattern.Matches(ReadmeText);
            var yamlBlocks = new List<string>();
            if (matches.Count == 0)
            {
                throw new Exception($"No YAML blocks found in README.md for [{Path}]");
            }
            else
            {
                foreach (Match match in matches)
                {
                    yamlBlocks.Add(match.Groups[1].Value.Trim());
                }
            }

            var swaggers = new List<SwaggerReference>();
            return yamlBlocks.Select(y => YamlHelper.Deserialize<AutoRestYamlConfig>(y))
                .Where(c => c != null)
                .SelectMany(c =>
                    c.InputFile.Concat(c.Require).Concat(c.TryRequire)
                        .Where(uri => !Conventions.IsAutorestInputButNotSwagger(uri))
                        .Select(uri => new SwaggerReference(uri, c.Commit)));
        }

        private string LoadReadme()
        {
            foreach (var file in FileSystem.Directory.GetFiles(Path, "*.md"))
            {
                if (file.EndsWith("readme.md", StringComparison.OrdinalIgnoreCase))
                {
                    if (!file.EndsWith("README.md", StringComparison.Ordinal))
                    {
                        throw new Exception($"Found incorrect casing of README.md in [{file}]");
                    }
                    return FileSystem.File.ReadAllText(file);
                }
            }
            throw new FileNotFoundException($"README.md not found in [{Path}]");
        }
    }
}
