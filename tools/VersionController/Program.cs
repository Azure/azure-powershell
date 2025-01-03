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
using System.Linq;
using System.Management.Automation;
using System.Reflection;
using Tools.Common.Loaders;
using Tools.Common.Models;
using Tools.Common.Utilities;
using VersionController.Models;
using VersionController.Netcore.Models;

namespace VersionController
{
    public class Program
    {
        private static VersionBumper _versionBumper;
        private static SyntaxChangelogGenerator _syntaxChangelogGenerator = new SyntaxChangelogGenerator();
        private static Dictionary<string, AzurePSVersion> _minimalVersion = new Dictionary<string, AzurePSVersion>();
        private static List<string> _projectDirectories, _outputDirectories;
        private static string _rootDirectory, _moduleNameFilter, _exceptionsDirectory, _assignedVersion;
        private static ReleaseType _releaseType = ReleaseType.STS;
        private static bool _generateSyntaxChangelog = true;

        private const string Psd1NameExtension = ".psd1";

        private static IList<string> ExceptionFileNames = new List<string>()
        {
            "AssemblyVersionConflict.csv",
            "BreakingChangeIssues.csv",
            "ExtraAssemblies.csv",
            "HelpIssues.csv",
            "MissingAssemblies.csv",
            "SignatureIssues.csv",
            "ExampleIssues.csv"
        };
        public static void Main(string[] args)
        {
            // bez: to do: change positional parameters to dictionary parameters
            Initialize(args);
            ConsolidateExceptionFiles(_exceptionsDirectory);
            ValidateManifest();
            if (_generateSyntaxChangelog && _releaseType == ReleaseType.STS) {
               GenerateSyntaxChangelog(_rootDirectory);
            }
            BumpVersions();
        }

        private static void Initialize(string[] args)
        {
            var executingAssemblyPath = Assembly.GetExecutingAssembly().Location;
            var versionControllerDirectory = Directory.GetParent(executingAssemblyPath).FullName;
            var artifactsDirectory = Directory.GetParent(versionControllerDirectory).FullName;
            _rootDirectory = Directory.GetParent(artifactsDirectory).FullName;
            _projectDirectories = new List<string> { Path.Combine(_rootDirectory, @"src\") }.Where((d) => Directory.Exists(d)).ToList();
            _outputDirectories = new List<string> { Path.Combine(_rootDirectory, @"artifacts\Release\") }.Where((d) => Directory.Exists(d)).ToList();
            _moduleNameFilter = string.Empty;
            _exceptionsDirectory  = Path.Combine(versionControllerDirectory, "Exceptions");
            SharedAssemblyLoader.Load(_outputDirectories.FirstOrDefault());

            if(null != args)
            {
                switch (args.Length)
                {
                    case 0:
                        break;
                    case 1:
                        Enum.TryParse(args[0], out _releaseType);
                        break;
                    default:
                        if (args.Length > 0 && !string.IsNullOrEmpty(args[0]))
                        {
                            _exceptionsDirectory = args[0];
                            _generateSyntaxChangelog = false;
                        }

                        if (!Directory.Exists(_exceptionsDirectory))
                        {
                            throw new ArgumentException("Please provide a path to the Exceptions folder in the output directory (artifacts/Exceptions).");
                        }
                        if (args.Length > 1 && !string.IsNullOrEmpty(args[1]))
                        {
                            _moduleNameFilter = args[1] + Psd1NameExtension;
                        }
                        if(args.Length > 2  && !string.IsNullOrEmpty(args[2]))
                        {
                            Enum.TryParse(args[2], out _releaseType);
                        }
                        if (args.Length > 3  && !string.IsNullOrEmpty(args[3]))
                        {
                            _assignedVersion = args[3];
                        }
                        break;
                }
            }           
        }

        private static void GenerateSyntaxChangelog(string projectDirectories)
        {
            try
            {
                _syntaxChangelogGenerator.Analyze(projectDirectories);
            }
            catch (Exception ex) {
                Console.WriteLine($"Warning: Cannot generate syntax change log because {ex.Message}");
            }
        }

        private static void ValidateManifest()
        {
            foreach (var directory in _projectDirectories)
            {
                var children = Directory.GetDirectories(directory);
                foreach (var childDir in children)
                {
                    if(GetModuleReadMe(childDir))
                    {
                        ValidateManifestPerModule(childDir);
                    }
                }
            }
        }

        private static void ValidateManifestPerModule(string directory)
        {
            var changeLogs = Directory.GetFiles(directory, "ChangeLog.md", SearchOption.AllDirectories);
            if(changeLogs.Length != 1)
            {
                Console.Error.WriteLine($"no ChangeLog.md under {directory}");
            } else
            {
                //Check psd1 file
                GetModuleManifestPath(Directory.GetParent(changeLogs.FirstOrDefault()).FullName);
            }
        }

        // For long term, all modules should contain readme.md to describe module
        // It returns true/false for short term.
        private static bool GetModuleReadMe(string directory)
        {
            return File.Exists(Path.Combine(directory, "readme.md"));
        }

        /// <summary>
        /// Bump the version of changed modules or a specified module.
        /// </summary>
        private static void BumpVersions()
        {
            string targetRepositories = null;
            using (PowerShell powershell = PowerShell.Create())
            {
                powershell.AddScript("Set-ExecutionPolicy -ExecutionPolicy Unrestricted -Scope Process;");
                powershell.AddScript("Register-PackageSource -Name PSGallery -Location https://www.powershellgallery.com/api/v2 -ProviderName PowerShellGet");
                powershell.AddScript("Get-PSRepository");
                var repositories = powershell.Invoke();
                string psgallery = null;
                foreach (var repo in repositories)
                {
                    if ("https://www.powershellgallery.com/api/v2".Equals(repo.Properties["SourceLocation"]?.Value))
                    {
                        psgallery = repo.Properties["Name"]?.Value?.ToString();
                    }
                }
                if (psgallery == null)
                {
                    throw new Exception("Cannot calculate module version because PSGallery is not available.");
                }
                targetRepositories = psgallery;
            }

            var changedModules = new List<string>();
            foreach (var directory in _projectDirectories)
            {
                var changeLogs = Directory.GetFiles(directory, "ChangeLog.md", SearchOption.AllDirectories)
                                            .Where(f => !ModuleFilter.IsAzureStackModule(f) && IsChangeLogUpdated(f))
                                            .Select(f => GetModuleManifestPath(Directory.GetParent(f).FullName))
                                            .Where(m => m.Contains(_moduleNameFilter))
                                            .ToList();
                changedModules.AddRange(changeLogs);
            }

            // Read MinimalVersion.csv
            var executingAssemblyPath = Assembly.GetExecutingAssembly().Location;
            var versionControllerDirectory = Directory.GetParent(executingAssemblyPath).FullName;
            var miniVersionFile = Path.Combine(versionControllerDirectory, "MinimalVersion.csv");
            var changedModuleNames = changedModules.Select(c => Path.GetFileName(c).Replace(".psd1", ""));
            if (File.Exists(miniVersionFile))
            {
                var file = File.ReadAllLines(miniVersionFile);
                var header = file.First();
                var lines = file.Skip(1).Where(c => !string.IsNullOrWhiteSpace(c));

                var bumpingModule = _moduleNameFilter.Replace(Psd1NameExtension, "");
                List<string> _minimalVersionContent = new List<string>() { header };
                foreach (var line in lines)
                {
                    var cols = line.Split(",").Select(c => c.StartsWith("\"") ? c.Substring(1) : c)
                                              .Select(c => c.EndsWith("\"") ? c.Substring(0, c.Length - 1) : c)
                                              .Select(c => c.Trim()).ToArray();
                    if (cols.Length >= 2)
                    {
                        _minimalVersion.Add(cols[0], new AzurePSVersion(cols[1]));

                        // Bump one module, only remove its minimal version from MinimalVersion.csv content
                        if (!string.IsNullOrEmpty(bumpingModule) && !cols[0].Equals(bumpingModule) ||
                            !changedModuleNames.Contains(cols[0]))
                        {
                            _minimalVersionContent.Add(line);
                        }
                    }
                }

                // Clean MinimalVersion.csv
                File.WriteAllLines(Path.Combine(_rootDirectory, @"tools\VersionController", "MinimalVersion.csv"), _minimalVersionContent.ToArray());
            }

            //Make Az.Accounts as the last module to calculate
            changedModules = changedModules.OrderByDescending(c => c.Contains("Az.Accounts") ? "" : c).ToList();
            foreach (var projectModuleManifestPath in changedModules)
            {
                var moduleFileName = Path.GetFileName(projectModuleManifestPath);
                var moduleName = moduleFileName.Replace(".psd1", "");

                var outputModuleManifest = _outputDirectories
                                            .SelectMany(d => Directory.GetDirectories(d, moduleName))
                                            .SelectMany(d => Directory.GetFiles(d, moduleFileName))
                                            .ToList();
                if (outputModuleManifest.Count == 0)
                {
                    throw new FileNotFoundException("No module manifest file found in output directories");
                }
                else if (outputModuleManifest.Count > 1)
                {
                    throw new IndexOutOfRangeException("Multiple module manifest files found in output directories");
                }

                var outputModuleManifestFile = outputModuleManifest.FirstOrDefault();
                if (!string.IsNullOrEmpty(_assignedVersion)) {
                    _versionBumper = new VersionBumper(new VersionFileHelper(_rootDirectory, outputModuleManifestFile, projectModuleManifestPath), changedModules,new AzurePSVersion(_assignedVersion), _releaseType);
                } else {
                    _versionBumper = new VersionBumper(new VersionFileHelper(_rootDirectory, outputModuleManifestFile, projectModuleManifestPath), changedModules, _releaseType);
                }
                _versionBumper.PSRepositories = targetRepositories;
                if (_minimalVersion.ContainsKey(moduleName))
                {
                    _versionBumper.MinimalVersion = _minimalVersion[moduleName];
                }

                _versionBumper.BumpAllVersions();
            }
        }
        
        /// <summary>
        /// Check if a change log has anything under the Upcoming Release header.
        /// </summary>
        /// <param name="changeLogPath">Path to the change log.</param>
        /// <returns>True if there is an entry under the Upcoming Release header, false otherwise.</returns>
        private static bool IsChangeLogUpdated(string changeLogPath)
        {
            var file = File.ReadAllLines(changeLogPath);
            var idx = 0;
            while (idx < file.Length && !file[idx].Equals("## Upcoming Release"))
            {
                idx++;
            }

            if (idx == file.Length)
            {
                throw new IndexOutOfRangeException("Unable to find the Upcoming Release header in change log " + changeLogPath);
            }

            bool found = false;
            while (++idx < file.Length && !file[idx].Contains("## Version"))
            {
                if (!string.IsNullOrWhiteSpace(file[idx]))
                {
                    found = true;
                    break;
                }
            }

            if (found && idx < file.Length)
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Get the path to the module manifest file from its parent folder. Excludes the
        /// Netcore module manifest file, and does extra validation around the number of
        /// module manifest files found.
        /// </summary>
        /// <param name="parentFolder">The folder containing the checked-in module manifest file.</param>
        /// <returns>The path to the module manifest file.</returns>
        private static string GetModuleManifestPath(string parentFolder)
        {
            var moduleManifest = Directory.GetFiles(parentFolder, "*.psd1").ToList();
            if (moduleManifest.Count == 0)
            {
                throw new FileNotFoundException("No module manifest file found in directory " + parentFolder);
            }
            else if (moduleManifest.Count > 1)
            {
                throw new IndexOutOfRangeException("Multiple module manifest files found in directory " + parentFolder);
            }

            return moduleManifest.FirstOrDefault();
        }

        private static void ConsolidateExceptionFiles(string exceptionsDirectory)
        {
            foreach (var exceptionFileName in ExceptionFileNames)
            {
                var moduleExceptionFilePaths = Directory.EnumerateFiles(exceptionsDirectory, exceptionFileName, SearchOption.AllDirectories).ToList();
                var exceptionFilePath = Path.Combine(exceptionsDirectory, exceptionFileName);
                if (File.Exists(exceptionFilePath))
                {
                    File.Delete(exceptionFilePath);
                }

                File.Create(exceptionFilePath).Close();
                var fileEmpty = true;
                foreach (var moduleExceptionFilePath in moduleExceptionFilePaths)
                {
                    var content = File.ReadAllLines(moduleExceptionFilePath);
                    if (content.Length > 1)
                    {
                        if (fileEmpty)
                        {
                            // Write the header
                            File.WriteAllLines(exceptionFilePath, new string[] { content.FirstOrDefault() });
                            fileEmpty = false;
                        }

                        // Write everything but the header
                        content = content.Skip(1).ToArray();
                        File.AppendAllLines(exceptionFilePath, content);
                    }
                }
            }
        }
    }
}
