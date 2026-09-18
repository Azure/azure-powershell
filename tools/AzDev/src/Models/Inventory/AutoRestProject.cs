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
        private static readonly Regex YamlBlockPattern = new Regex(@"(?ms)```\s*yaml(.*?)```", RegexOptions.Compiled);

        protected AutoRestProject(IFileSystem fs, string path) : base(fs, path)
        {
            _lazySwaggers = new Lazy<IEnumerable<SwaggerReference>>(LoadSwaggers);
            _lazyReadmeText = new Lazy<string>(LoadReadme);
            _lazyAutoRestVersion = new Lazy<string>(DetectAutoRestVersion);
            _lazyConfigs = new Lazy<IEnumerable<AutoRestYamlConfig>>(LoadYamlConfigs);
        }
        internal AutoRestProject() { }
        public IEnumerable<SwaggerReference> Swaggers => _lazySwaggers.Value;
        private Lazy<IEnumerable<SwaggerReference>> _lazySwaggers;
        private string ReadmeText => _lazyReadmeText.Value;
        private Lazy<string> _lazyReadmeText;
        public string AutoRestVersion => _lazyAutoRestVersion.Value;
        private Lazy<string> _lazyAutoRestVersion;
        private IEnumerable<AutoRestYamlConfig> Configs => _lazyConfigs.Value;
        private Lazy<IEnumerable<AutoRestYamlConfig>> _lazyConfigs;

        public new static AutoRestProject FromFileSystem(IFileSystem fs, string path)
        {
            var proj = new AutoRestProject(fs, path)
            {
                Type = ProjectType.AutoRestBased,
                Name = fs.Path.GetFileName(path)
            };
            // Populate SubType with detected AutoRest.PowerShell version (v3/v4/Invalid)
            proj.SubType = proj.AutoRestVersion;
            return proj;
        }

        private IEnumerable<SwaggerReference> LoadSwaggers()
        {
            if (!Configs.Any())
            {
                return Enumerable.Empty<SwaggerReference>();
            }
            return Configs.SelectMany(c =>
                c.InputFile.Concat(c.Require).Concat(c.TryRequire)
                    .Where(uri => !Conventions.IsAutorestInputButNotSwagger(uri))
                    .Select(uri => new SwaggerReference(uri, c.Commit)));
        }

        private string DetectAutoRestVersion()
        {
            // Default: v4 if omitted
            // If present, map 3.x -> v3, 4.x -> v4; otherwise Invalid
            var configs = Configs;
            if (!configs.Any())
            {
                return "v4";
            }

            // Find a key that matches @autorest/powershell in use-extension
            foreach (var c in configs)
            {
                if (c.UseExtension != null && c.UseExtension.Count > 0)
                {
                    var kvp = c.UseExtension.FirstOrDefault(k => k.Key.Replace("\"", string.Empty).Equals("@autorest/powershell", StringComparison.OrdinalIgnoreCase));
                    if (!string.IsNullOrEmpty(kvp.Key))
                    {
                        var val = kvp.Value?.Trim();
                        return Conventions.MapAutoRestPowerShellVersion(val);
                    }
                }
            }

            // If no key found in any block, default is v4
            return "v4";
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

        private IEnumerable<AutoRestYamlConfig> LoadYamlConfigs()
        {
            var matches = YamlBlockPattern.Matches(ReadmeText);
            if (matches.Count == 0)
            {
                return Enumerable.Empty<AutoRestYamlConfig>();
            }
            return matches
                .Select(m => m.Groups[1].Value.Trim())
                .Select(y => YamlHelper.TryDeserialize<AutoRestYamlConfig>(y, out var c) ? c : null)
                .Where(c => c != null)!;
        }
    }
}
