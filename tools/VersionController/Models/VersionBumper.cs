using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Management.Automation;
using System.Reflection;
using System.Text.RegularExpressions;

namespace VersionController.Models
{
    public class VersionBumper
    {
        private VersionFileHelper _fileHelper;
        private VersionMetadataHelper _metadataHelper;

        private string _oldVersion, _newVersion;
        private bool _isPreview;

        public VersionBumper(VersionFileHelper fileHelper)
        {
            _fileHelper = fileHelper;
            _metadataHelper = new VersionMetadataHelper(_fileHelper);
        }

        /// <summary>
        /// Bump the version in all necessary files.
        /// </summary>
        public void BumpAllVersions()
        {
            var moduleName = _fileHelper.ModuleName;
            Console.WriteLine("Bumping version for " + moduleName + "...");
            using (PowerShell powershell = PowerShell.Create())
            {
                powershell.AddScript("$metadata = Test-ModuleManifest -Path " + _fileHelper.OutputModuleManifestPath + ";$metadata.Version;$metadata.PrivateData.PSData.Prerelease");
                var cmdletResult = powershell.Invoke();
                _oldVersion = cmdletResult[0]?.ToString();
                _isPreview = !string.IsNullOrEmpty(cmdletResult[1]?.ToString());
            }

            if (_oldVersion == null)
            {
                throw new Exception("Unable to obtain old version of " + moduleName + " using the built module manifest.");
            }

            _newVersion = IsNewModule() ? _oldVersion : GetBumpedVersion();
            if (_oldVersion == _newVersion)
            {
                Console.WriteLine(_fileHelper.ModuleName + " is a new module. Keeping the version at " + _oldVersion);

                // Generate the serialized module metadata file
                _metadataHelper.SerializeModule();
            }
            else
            {
                Console.WriteLine("Updating version for " + _fileHelper.ModuleName + " from " + _oldVersion + " to " + _newVersion);
            }

            UpdateSerializedAssemblyVersion();
            UpdateChangeLog();
            var releaseNotes = GetReleaseNotes();
            UpdateOutputModuleManifest(releaseNotes);
            UpdateRollupModuleManifest();
            UpdateAssemblyInfo();
            UpdateDependentModules();
            Console.WriteLine("Finished bumping version " + moduleName + "\n");
        }

        /// <summary>
        /// Apply a version bump to a given version.
        /// </summary>
        /// <returns>The updated version after the bump has been applied.</returns>
        private string GetBumpedVersion()
        {
            var moduleName = _fileHelper.ModuleName;
            var splitVersion = _oldVersion.Split('.').Select(v => int.Parse(v)).ToArray();
            var versionBump = _metadataHelper.GetVersionBumpUsingSerialized();
            if (string.Equals(moduleName, "AzureRM.Profile"))
            {
                var commonCodeVersionBump = _metadataHelper.GetVersionBumpForCommonCode();
                if (commonCodeVersionBump == Version.MAJOR)
                {
                    throw new Exception("Breaking change detected in common code.");
                }
                else if (commonCodeVersionBump == Version.MINOR && versionBump == Version.PATCH)
                {
                    versionBump = Version.MINOR;
                }
            }

            // PATCH update for preview modules (0.x.x or x.x.x-preview)
            if (splitVersion[0] == 0 || _isPreview)
            {
                versionBump = Version.PATCH;
            }

            if (versionBump == Version.MAJOR)
            {
                splitVersion[0]++;
                splitVersion[1] = 0;
                splitVersion[2] = 0;
            }
            else if (versionBump == Version.MINOR)
            {
                splitVersion[1]++;
                splitVersion[2] = 0;
            }
            else
            {
                splitVersion[2]++;
            }

            return string.Join(".", splitVersion);
        }

        /// <summary>
        /// Bumps the version of the nested module in the serialized module metadata JSON file.
        /// </summary>
        private void UpdateSerializedAssemblyVersion()
        {
            var outputModuleManifestPath = _fileHelper.OutputModuleManifestPath;
            var serializedCmdletsDirectory = _fileHelper.SerializedCmdletsDirectory;
            IList<string> nestedModules = null;
            using (PowerShell powershell = PowerShell.Create())
            {
                powershell.AddScript("(Test-ModuleManifest -Path " + outputModuleManifestPath + ").NestedModules");
                var cmdletResult = powershell.Invoke();
                nestedModules = cmdletResult.Select(c => c.ToString()).ToList();
            }

            foreach (var nestedModule in nestedModules)
            {
                var serializedCmdletName = nestedModule + ".dll.json";
                var serializedCmdletFile = Directory.GetFiles(serializedCmdletsDirectory, serializedCmdletName).FirstOrDefault();
                if (serializedCmdletFile == null)
                {
                    continue;
                }
                var file = File.ReadAllLines(serializedCmdletFile);
                var pattern = nestedModule + @"(\s*),(\s*)Version(\s*)=(\s*)" + _oldVersion;
                var updatedFile = file.Select(l => Regex.Replace(l, pattern, nestedModule + ", Version=" + _newVersion));
                File.WriteAllLines(serializedCmdletFile, updatedFile);
            }
        }

        /// <summary>
        /// Bumps the RequiredVersion field for a given module in the hashtable of RequiredModules
        /// in the AzureRM module manifest file.
        /// </summary>
        private void UpdateRollupModuleManifest()
        {
            var rollupModuleManifestPath = _fileHelper.RollupModuleManifestPath;
            var moduleName = _fileHelper.ModuleName;

            // Skip this step since preview modules should not be included in AzureRM
            if (_isPreview)
            {
                return;
            }

            var file = File.ReadAllLines(rollupModuleManifestPath);
            var pattern = @"ModuleName(\s*)=(\s*)(['\""])" + moduleName + @"(['\""])(\s*);(\s*)RequiredVersion(\s*)=(\s*)(['\""])" + _oldVersion + @"(['\""])";
            var updatedFile = file.Select(l => Regex.Replace(l, pattern, "ModuleName = '" + moduleName + "'; RequiredVersion = '" + _newVersion + "'"));
            var pattern2 = @"ModuleName(\s*)=(\s*)(['\""])" + moduleName + @"(['\""])(\s*);(\s*)ModuleVersion(\s*)=(\s*)(['\""])" + _oldVersion + @"(['\""])";
            var updatedFile2 = updatedFile.Select(l => Regex.Replace(l, pattern2, "ModuleName = '" + moduleName + "'; ModuleVersion = '" + _newVersion + "'"));
            File.WriteAllLines(rollupModuleManifestPath, updatedFile2);
        }

        /// <summary>
        /// Bumps the AssemblyVersion and AssemblyFileVersion fields in all AssemblyInfo.cs
        /// files for a given module project.
        /// </summary>
        private void UpdateAssemblyInfo()
        {
            var assemblyInfoPaths = _fileHelper.AssemblyInfoPaths;
            foreach (var assemblyInfoPath in assemblyInfoPaths)
            {
                var file = File.ReadAllLines(assemblyInfoPath);
                var pattern = @"AssemblyVersion\(([\""])" + _oldVersion + @"([\""])\)";
                file = file.Select(l => Regex.Replace(l, pattern, "AssemblyVersion(\"" + _newVersion + "\")")).ToArray();
                pattern = @"AssemblyFileVersion\(([\""])" + _oldVersion + @"([\""])\)";
                var updatedFile = file.Select(l => Regex.Replace(l, pattern, "AssemblyFileVersion(\"" + _newVersion + "\")"));
                File.WriteAllLines(assemblyInfoPath, updatedFile);
            }
        }

        /// <summary>
        /// Get the releases notes for the current release from a change log.
        /// </summary>
        /// <returns>List of non-empty strings representing the lines of the release notes.</returns>
        private List<string> GetReleaseNotes()
        {
            var changeLogPath = _fileHelper.ChangeLogPath;
            var file = File.ReadAllLines(changeLogPath);
            var idx = 0;
            while (idx < file.Length && !file[idx].Equals("## Version " + _newVersion))
            {
                idx++;
            }

            var releaseNotes = new List<string>();
            while (++idx < file.Length && !file[idx].Contains("## Version"))
            {
                releaseNotes.Add(file[idx]);
            }

            return releaseNotes.Where(l => !string.IsNullOrWhiteSpace(l))
                                                .Select(l => l.Replace("`", "'"))
                                                .Select(l => l.Replace("\"", "'")).ToList();
        }

        /// <summary>
        /// Update the module version and release notes for a module manifest file.
        /// </summary>
        /// <param name="releaseNotes">Release notes for the current release from the change log.</param>
        private void UpdateOutputModuleManifest(List<string> releaseNotes)
        {
            var moduleName = _fileHelper.ModuleName;
            var outputModuleDirectory = _fileHelper.OutputModuleDirectory;
            var outputModuleManifestPath = _fileHelper.OutputModuleManifestPath;
            var projectModuleManifestPath = _fileHelper.ProjectModuleManifestPath;
            var tempModuleManifestPath = Path.Combine(outputModuleDirectory, moduleName + "-temp.psd1");
            File.Copy(outputModuleManifestPath, tempModuleManifestPath, true);
            var script = "$releaseNotes = @();";
            releaseNotes.ForEach(l => script += "$releaseNotes += \"" + l + "\";");
            script += $"$env:PSModulePath+=\";{_fileHelper.OutputResourceManagerDirectory};{_fileHelper.SrcDirectory}\\Package\\Release\\Storage\";";
            script += "Update-ModuleManifest -Path " + tempModuleManifestPath + " -ModuleVersion " + _newVersion + " -ReleaseNotes $releaseNotes";
            using (PowerShell powershell = PowerShell.Create())
            {
                powershell.AddScript(script);
                var result = powershell.Invoke();
                if (powershell.Streams.Error.Any())
                {
                    Console.WriteLine($"Found error in updating module {_fileHelper.ModuleName}: {powershell.Streams.Error.First().ToString()}");
                }
            }

            var tempModuleContent = File.ReadAllLines(tempModuleManifestPath);
            tempModuleContent = tempModuleContent.Select(l => l = l.Replace(moduleName + "-temp", moduleName)).ToArray();
            var pattern = @"RootModule(\s*)=(\s*)(['\""])" + moduleName + @"(\.)psm1(['\""])";
            tempModuleContent = tempModuleContent.Select(l => Regex.Replace(l, pattern, @"# RootModule = ''")).ToArray();
            File.WriteAllLines(projectModuleManifestPath, tempModuleContent);
            File.Delete(tempModuleManifestPath);
        }

        /// <summary>
        /// Creates a new header for the current release based on the new version.
        /// </summary>
        private void UpdateChangeLog()
        {
            var changeLogPath = _fileHelper.ChangeLogPath;
            var file = File.ReadAllLines(changeLogPath);
            var newFile = new string[file.Length + 2];
            var idx = 0;
            while (idx < file.Length && !file[idx].Equals("## Current Release"))
            {
                newFile[idx] = file[idx];
                idx++;
            }

            newFile[idx] = file[idx];
            newFile[idx + 1] = string.Empty;
            newFile[idx + 2] = "## Version " + _newVersion;
            while (++idx < file.Length)
            {
                newFile[idx + 2] = file[idx];
            }

            File.WriteAllLines(changeLogPath, newFile);
        }

        /// <summary>
        /// Update the ModuleVersion of the bumped module in any dependent module's RequiredModule field.
        /// </summary>
        private void UpdateDependentModules()
        {
            var moduleName = _fileHelper.ModuleName;
            var projectDirectories = _fileHelper.ProjectDirectories;
            var outputDirectories = _fileHelper.OutputDirectories;
            foreach (var projectDirectory in projectDirectories)
            {
                var moduleManifestPaths = Directory.GetFiles(projectDirectory, "*.psd1", SearchOption.AllDirectories)
                                                   .Where(f => !f.Contains("Netcore") &&
                                                               !f.Contains("bin") &&
                                                               !f.Contains("dll-Help") &&
                                                               !f.Contains("Stack"))
                                                   .ToList();
                foreach (var moduleManifestPath in moduleManifestPaths)
                {
                    var file = File.ReadAllLines(moduleManifestPath);
                    var pattern = @"ModuleName(\s*)=(\s*)(['\""])" + moduleName + @"(['\""])(\s*);(\s*)ModuleVersion(\s*)=(\s*)(['\""])" + _oldVersion + @"(['\""])";
                    if (file.Where(l => Regex.IsMatch(l, pattern)).Any())
                    {
                        var updatedFile = file.Select(l => Regex.Replace(l, pattern, "ModuleName = '" + moduleName + "'; ModuleVersion = '" + _newVersion + "'"));
                        File.WriteAllLines(moduleManifestPath, updatedFile);
                        var updatedModuleName = Path.GetFileNameWithoutExtension(moduleManifestPath);
                        foreach (var outputDirectory in outputDirectories)
                        {
                            var outputModuleDirectory = Directory.GetDirectories(outputDirectory, updatedModuleName).FirstOrDefault();
                            if (outputModuleDirectory == null)
                            {
                                continue;
                            }

                            var outputModuleManifestPath = Directory.GetFiles(outputModuleDirectory, updatedModuleName + ".psd1").FirstOrDefault();
                            if (outputModuleManifestPath == null)
                            {
                                continue;
                            }

                            File.WriteAllLines(outputModuleManifestPath, updatedFile);
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Check whether or not the given module is new by searching for past entries in the change log.
        /// </summary>
        /// <returns>True if the module is new, false otherwise.</returns>
        private bool IsNewModule()
        {
            var changeLogPath = _fileHelper.ChangeLogPath;
            var file = File.ReadAllLines(changeLogPath);
            var idx = 0;
            while (idx < file.Length && !file[idx].Equals("## Current Release"))
            {
                idx++;
            }

            while (++idx < file.Length)
            {
                if (file[idx].Contains("## Version"))
                {
                    return false;
                }
            }

            return true;
        }
    }
}
