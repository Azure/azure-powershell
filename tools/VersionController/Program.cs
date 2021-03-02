using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Management.Automation;
using System.Reflection;
using VersionController.Models;

namespace VersionController
{
    public class Program
    {
        private static VersionBumper _versionBumper;
        private static VersionValidator _versionValidator;

        private static List<string> _projectDirectories, _outputDirectories;
        private static string _rootDirectory, _moduleNameFilter;

        private static IList<string> ExceptionFileNames = new List<string>()
        {
            "AssemblyVersionConflict.csv",
            "BreakingChangeIssues.csv",
            "ExtraAssemblies.csv",
            "HelpIssues.csv",
            "MissingAssemblies.csv",
            "SignatureIssues.csv"
        };

        public static void Main(string[] args)
        {
            var executingAssemblyPath = Assembly.GetExecutingAssembly().Location;
            var packageDirectory = Directory.GetParent(executingAssemblyPath).FullName;
            var srcDirectory = Directory.GetParent(packageDirectory).FullName;

             _rootDirectory = Directory.GetParent(srcDirectory).FullName;

            _projectDirectories = new List<string>
            {
                Path.Combine(srcDirectory, @"ResourceManager\"),
                Path.Combine(srcDirectory, @"ServiceManagement\"),
                Path.Combine(srcDirectory, @"Storage\")
            }.Where((d) => Directory.Exists(d)).ToList();

            _outputDirectories = new List<string>
            {
                Path.Combine(srcDirectory, @"Package\Release\ResourceManager\AzureResourceManager\"),
                Path.Combine(srcDirectory, @"Package\Release\ServiceManagement\"),
                Path.Combine(srcDirectory, @"Package\Release\Storage\")
            }.Where((d) => Directory.Exists(d)).ToList();

            var exceptionsDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Exceptions");
            if (args != null && args.Length > 0)
            {
                exceptionsDirectory = args[0];
            }
            
            if (!Directory.Exists(exceptionsDirectory))
            {
                throw new ArgumentException("Please provide a path to the Exceptions folder in the output directory (src/Package/Exceptions).");
            }

            _moduleNameFilter = string.Empty;
            if (args != null && args.Length > 1)
            {
                _moduleNameFilter = args[1] + ".psd1";
            }

            ConsolidateExceptionFiles(exceptionsDirectory);
            BumpVersions();
            ValidateVersionBump();
        }

        /// <summary>
        /// Bump the version of changed modules or a specified module.
        /// </summary>
        private static void BumpVersions()
        {
            var changedModules = new List<string>();
            foreach (var directory in _projectDirectories)
            {
                var changeLogs = Directory.GetFiles(directory, "ChangeLog.md", SearchOption.AllDirectories)
                                            .Where(f => !f.Contains("Stack") && IsChangeLogUpdated(f))
                                            .Select(f => GetModuleManifestPath(Directory.GetParent(f).FullName))
                                            .Where(m => m.Contains(_moduleNameFilter))
                                            .ToList();
                changedModules.AddRange(changeLogs);
            }

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

                _versionBumper = new VersionBumper(new VersionFileHelper(_rootDirectory, outputModuleManifestFile, projectModuleManifestPath));

                _versionBumper.BumpAllVersions();
            }
        }

        /// <summary>
        /// Validate version bump of changed modules or a specified module.
        /// </summary>
        private static void ValidateVersionBump()
        {
            var changedModules = new List<string>();
            foreach (var directory in _projectDirectories)
            {
                var changeLogs = Directory.GetFiles(directory, "ChangeLog.md", SearchOption.AllDirectories)
                                            .Where(f => !f.Contains("Stack"))
                                            .Select(f => GetModuleManifestPath(Directory.GetParent(f).FullName))
                                            .Where(m => !string.IsNullOrEmpty(m) && m.Contains(_moduleNameFilter))
                                            .ToList();
                changedModules.AddRange(changeLogs);
            }

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

                var validatorFileHelper = new VersionFileHelper(_rootDirectory, outputModuleManifestFile, projectModuleManifestPath);

                _versionValidator = new VersionValidator(validatorFileHelper);

                _versionValidator.ValidateAllVersionBumps();
            }
        }

        /// <summary>
        /// Check if a change log has anythign under the Current Release header.
        /// </summary>
        /// <param name="changeLogPath">Path to the change log.</param>
        /// <returns>True if there is an entry under the Current Release header, false otherwise.</returns>
        private static bool IsChangeLogUpdated(string changeLogPath)
        {
            var file = File.ReadAllLines(changeLogPath);
            var idx = 0;
            while (idx < file.Length && !file[idx].Equals("## Current Release"))
            {
                idx++;
            }

            if (idx == file.Length)
            {
                throw new IndexOutOfRangeException("Unable to find the Current Release header in change log " + changeLogPath);
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
            var moduleManifest = Directory.GetFiles(parentFolder, "*.psd1").Where(f => !f.Contains("Az.")).ToList();
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
