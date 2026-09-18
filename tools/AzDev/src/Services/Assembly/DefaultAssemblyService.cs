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
using System.Text;
using AzDev.Models.Assembly;
using Newtonsoft.Json;

namespace AzDev.Services.Assembly
{
    internal class DefaultAssemblyService : IAssemblyService
    {
        private readonly IFileSystem _fs;
        private readonly INugetService _nuget;
        private readonly ILogger _logger;
        private readonly IAssemblyMetadataService _assemblyMetadataService;

        public DefaultAssemblyService(IFileSystem fs, INugetService nuget, ILogger logger, IAssemblyMetadataService assemblyMetadataService)
        {
            _assemblyMetadataService = assemblyMetadataService;
            _logger = logger;
            _fs = fs;
            _nuget = nuget;
        }

        public void UpdateAssembly(string manifestFilePath, string downloadPath, string runtimeMetadataPath, string cgManifestPath)
        {
            _logger.Information($"[{nameof(DefaultAssemblyService)}] Updating assembly using manifest: {manifestFilePath}, download path: {downloadPath}, runtime metadata path: {runtimeMetadataPath}, cg manifest path: {cgManifestPath}");

            if (!_fs.File.Exists(manifestFilePath))
            {
                throw new FileNotFoundException($"Manifest file does not exist", manifestFilePath);
            }

            var devAssemblies = ParseManifest(_fs.File.ReadAllText(manifestFilePath));
            CleanDownloadDirectory(downloadPath);
            var inspectedAssemblies = devAssemblies.Select(da => DownloadAndInspect(da, downloadPath)).OrderBy(x => x.Path).ToList();
            _logger.Information($"[{nameof(DefaultAssemblyService)}] Downloaded and inspected {inspectedAssemblies.Count} assemblies.");
            UpdateRuntimeManifestFile(inspectedAssemblies, runtimeMetadataPath);
            UpdateCgManifest(inspectedAssemblies, cgManifestPath);
        }

        private static List<DevAssembly> ParseManifest(string manifestInJson)
        {
            try
            {
                var manifestDataList = JsonConvert.DeserializeObject<List<DevAssembly>>(manifestInJson);
                return manifestDataList;
            }
            catch (Exception ex)
            {
                throw new Exception("Error reading or parsing manifest file: " + ex.Message, ex);
            }
        }

        private void CleanDownloadDirectory(string downloadPath)
        {
            var subDirs = _fs.Directory.GetDirectories(downloadPath, "net*");
            foreach (var subDir in subDirs)
            {
                _logger.Debug($"[{nameof(DefaultAssemblyService)}] Deleting directory: {subDir}");
                _fs.Directory.Delete(subDir, true);
            }
        }

        private DevAssemblyExtended DownloadAndInspect(DevAssembly devAssembly, string downloadPath)
        {
            var packageName = devAssembly.PackageName;
            var packageVersion = devAssembly.PackageVersion;
            var targetFramework = devAssembly.TargetFramework;
            var pathWithTargetFramework = Path.Combine(downloadPath, targetFramework);

            if (!_fs.Directory.Exists(pathWithTargetFramework))
            {
                _fs.Directory.CreateDirectory(pathWithTargetFramework);
            }

            string path = _nuget.DownloadAssembly(packageName, packageVersion, targetFramework, downloadPath, devAssembly.CopyRuntimeAssemblies);

            return new DevAssemblyExtended
            {
                DevAssembly = devAssembly,
                Path = path,
                AssemblyVersion = _assemblyMetadataService.ParseAssemblyMetadata(path).Version
            };
        }

        private void UpdateRuntimeManifestFile(IEnumerable<DevAssemblyExtended> assemblies, string runtimeManifestPath)
        {
            _logger.Information($"[{nameof(DefaultAssemblyService)}] Updating runtime manifest file: {runtimeManifestPath}");
            string runtimeManifestContent = _fs.File.ReadAllText(runtimeManifestPath);
            int regionStart = runtimeManifestContent.IndexOf("#region Generated", StringComparison.OrdinalIgnoreCase);
            int regionEnd = runtimeManifestContent.IndexOf("#endregion", regionStart, StringComparison.OrdinalIgnoreCase);
            const string indent = "    ";
            StringBuilder sb = new();

            sb.Append(runtimeManifestContent[..(regionStart + "#region Generated".Length)]);
            sb.AppendLine();
            foreach (var asm in assemblies)
            {
                var devAsm = asm.DevAssembly;
                sb.Append($"{indent}{indent}{indent}{indent}");
                sb.Append($"CreateAssembly(\"{devAsm.TargetFramework}\", \"{devAsm.PackageName}\", \"{asm.AssemblyVersion}\")");
                if (devAsm.WindowsPowerShell && !devAsm.PowerShell7Plus)
                {
                    sb.Append($".WithWindowsPowerShell()");
                }
                if (devAsm.PowerShell7Plus && !devAsm.WindowsPowerShell)
                {
                    sb.Append($".WithPowerShellCore()");
                }
                sb.AppendLine(",");
            }
            sb.Append($"{indent}{indent}{indent}{indent}");
            sb.Append(runtimeManifestContent.AsSpan(regionEnd));

            _fs.File.WriteAllText(runtimeManifestPath, sb.ToString());
        }

        /// <summary>
        /// Update the Component Governance manifest file.
        /// The manifest file is a JSON file that contains information about the assemblies used in the project
        /// that cannot be found from the csproj files.
        /// </summary>
        private void UpdateCgManifest(List<DevAssemblyExtended> inspectedAssemblies, string manifestPath)
        {
            _logger.Information($"[{nameof(DefaultAssemblyService)}] Updating Component Governance manifest file: {manifestPath}");
            var cgManifest = _fs.File.ReadAllText(manifestPath);
            var cgManifestObj = JsonConvert.DeserializeObject<CgManifest>(cgManifest);
            if (cgManifestObj == null)
            {
                throw new Exception("Error reading or parsing CG manifest file.");
            }

            cgManifestObj.Registrations = inspectedAssemblies.Select(asm =>
            {
                return new CgRegistration
                {
                    Component = new CgComponent
                    {
                        Type = "nuget",
                        Nuget = new CgNugetComponent
                        {
                            Name = asm.DevAssembly.PackageName,
                            Version = asm.DevAssembly.PackageVersion
                        }
                    }
                };
            }).ToList();

            _fs.File.WriteAllText(manifestPath, JsonConvert.SerializeObject(cgManifestObj, Formatting.Indented));
        }
    }

    #region Component Governance Manifest Models
    internal class CgManifest
    {
        [JsonProperty("$schema")]
        public string Schema { get; set; }

        [JsonProperty("version")]
        public int Version { get; set; }

        [JsonProperty("registrations")]
        public List<CgRegistration> Registrations { get; set; }
    }

    internal class CgRegistration
    {
        [JsonProperty("component")]
        public CgComponent Component { get; set; }
    }

    internal class CgComponent
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("nuget")]
        public CgNugetComponent Nuget { get; set; }
    }

    internal class CgNugetComponent
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("version")]
        public string Version { get; set; }
    }
    #endregion
}
