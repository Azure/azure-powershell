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

using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Management.Automation;
using System.Text.RegularExpressions;
using Tools.Common.Models;
using Tools.Common.Utilities;

using VersionController.Netcore.Models;

namespace VersionController.Models
{
    public class VersionBumper
    {
        private VersionFileHelper _fileHelper;
        private VersionMetadataHelper _metadataHelper;
        private ILoggerFactory _loggerFactory;
        private ILogger _logger;

        private string _oldVersion, _newVersion;
        private bool _isPreview;

        // Use static variable to store accounts version to avoid calculating more than once
        private static string _accountsVersion = null;

        private IList<string> _changedModules { get; set; }

        private AzurePSVersion _assignedVersion { get; set;}

        public AzurePSVersion MinimalVersion { get; set; }
        public string PSRepositories { get; set; }

        private ReleaseType _releaseType { get; set; }

        public VersionBumper(VersionFileHelper fileHelper, IList<string> changedModules, ReleaseType releaseType = ReleaseType.STS)
        {
            _fileHelper = fileHelper;
            _metadataHelper = new VersionMetadataHelper(_fileHelper);
            _loggerFactory = LoggerFactory.Create(builder => builder.AddConsole().AddDebug());
            _logger = _loggerFactory.CreateLogger<VersionBumper>();
            _changedModules = changedModules;
            _releaseType = releaseType;
        }

        public VersionBumper(VersionFileHelper fileHelper, IList<string> changedModules, AzurePSVersion assignedVersion, ReleaseType releaseType = ReleaseType.STS)
        {
            _fileHelper = fileHelper;
            _metadataHelper = new VersionMetadataHelper(_fileHelper);
            _loggerFactory = LoggerFactory.Create(builder => builder.AddConsole().AddDebug());
            _logger = _loggerFactory.CreateLogger<VersionBumper>();
            _changedModules = changedModules;
            _assignedVersion = assignedVersion;
            _releaseType = releaseType;
        }

        /// <summary>
        /// Bump the version in all necessary files.
        /// </summary>
        public void BumpAllVersions()
        {
            var moduleName = _fileHelper.ModuleName;
            Console.WriteLine("Bumping version for " + moduleName + "...");

            (_oldVersion, _isPreview) = GetOldVersion();
            if (_assignedVersion != null) 
            {
                _newVersion = _assignedVersion.ToString();
            } else 
            {
                _newVersion = IsNewModule() ? _oldVersion : GetBumpedVersion();
            }
            if (MinimalVersion != null && MinimalVersion > new AzurePSVersion(_newVersion))
            {
                Console.WriteLine($"Adjust version from {_newVersion} to {MinimalVersion} due to MinimalVersion.csv");
                _newVersion = MinimalVersion.ToString();
            }

            if (_oldVersion != _newVersion)
            {
                Console.WriteLine("Updating version for " + _fileHelper.ModuleName + " from " + _oldVersion + " to " + _newVersion);
            }

            UpdateSerializedCmdlet();
            UpdateSerializedAssemblyVersion();
            UpdateChangeLog();
            var releaseNotes = GetReleaseNotes();
            _accountsVersion = _accountsVersion ?? GetLatestAccountsVersion();
            UpdateOutputModuleManifest(releaseNotes);
            UpdateDependentModules();
            UpdateRollupModuleManifest();
            UpdateAssemblyInfo();
            Console.WriteLine("Finished bumping version " + moduleName + "\n");
        }

        private string GetLatestAccountsVersion()
        {
            var localVersion = GetLocalAccountsVersion();

            var version = ModuleHelper.GetLatestVersionFromPSGallery("Az.Accounts", _releaseType);
            if (!string.IsNullOrEmpty(localVersion) && !string.IsNullOrEmpty(version))
            {
                return new System.Version(localVersion).CompareTo(value: new System.Version(version)) > 0 ? localVersion : version;
            } else if (string.IsNullOrEmpty(localVersion))
            {
                return version;
            } else if (string.IsNullOrEmpty(version))
            {
                return localVersion;
            }
            else
            {
                throw new Exception("Can not find the latest version for Az.Accounts.");
            }
        }

        /// <summary>
        /// Get the latest version of Az.Accounts in local
        /// </summary>
        /// <returns></returns>
        private string GetLocalAccountsVersion()
        {

            // Assume in outputModuleDirectory/../Az.Accounts/Az.Accounts.psd1 exists
            var accountsOutputDirectory = Path.Combine(Directory.GetParent(_fileHelper.OutputModuleDirectory).FullName, "Az.Accounts");
            var accountsManifest = Directory.GetFiles(accountsOutputDirectory, "Az.Accounts.psd1", SearchOption.TopDirectoryOnly)
                                            .FirstOrDefault();

            string localVersion = null;
            bool localPreview = false;
            using (PowerShell powershell = PowerShell.Create())
            {
                powershell.AddScript("$metadata = Test-ModuleManifest -Path " + accountsManifest + ";$metadata.Version;$metadata.PrivateData.PSData.Prerelease");
                var cmdletResult = powershell.Invoke();
                localVersion = cmdletResult[0]?.ToString();
                localPreview = !string.IsNullOrEmpty(cmdletResult[1]?.ToString());
            }
            // Console.WriteLine("The version of Az.Accounts in local is " + localVersion);
            return localPreview ? null : localVersion;
        }

        /// <summary>
        /// Get the local version of the module.
        /// </summary>
        /// <returns>The old version and is or not preview before the bump.</returns>
        public Tuple<string, bool> GetOldVersion()
        {
            string version;
            string localVersion = null;
            // string localVersion = null, psVersion = null, testVersion = null;
            bool isPreview;
            bool localPreview = false;
            // bool localPreview = false, psPreview = false, testPreview = false;
            var moduleName = _fileHelper.ModuleName;

            using (PowerShell powershell = PowerShell.Create())
            {
                powershell.AddScript("$metadata = Test-ModuleManifest -Path " + _fileHelper.OutputModuleManifestPath + ";$metadata.Version;$metadata.PrivateData.PSData.Prerelease");
                var cmdletResult = powershell.Invoke();
                localVersion = cmdletResult[0]?.ToString();
                localPreview = !string.IsNullOrEmpty(cmdletResult[1]?.ToString());
            }
            if (localVersion == null)
            {
                throw new Exception("Unable to obtain old version of " + moduleName + " using the built module manifest.");
            }
            version = localVersion;
            isPreview = localPreview;

            return Tuple.Create(version, isPreview);
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
            if (string.Equals(moduleName, "Az.Accounts"))
            {
                var commonCodeVersionBump = _metadataHelper.GetVersionBumpForCommonCode(_releaseType);
                if (commonCodeVersionBump == Version.MAJOR)
                {
                    throw new Exception("Breaking change detected in common code.");
                }
                else if (commonCodeVersionBump == Version.MINOR && versionBump == Version.PATCH)
                {
                    versionBump = Version.MINOR;
                }
                // for https://github.com/Azure/azure-powershell/pull/12356
                // Because of the wrong compare script in the link above, we need to avoid the minor bump when the version of Az.Accounts is 1.9.x
                // So we add a special judge for it when the version is 1.9.x and the expect bump type is minor, 
                // we will change the type to patch so that it can work until 1.9.9.Once the version is greater or equal than 2.0.0
                // this special judge will not works anymore.
                if (splitVersion[0] == 1 && splitVersion[1] == 9 && versionBump == Version.MINOR)
                {
                    versionBump = Version.PATCH;
                }
            }

            // PATCH update for preview modules (x.x.x-preview)
            if (_isPreview)
            {
                versionBump = Version.PATCH;
            }
            // Breaking change is allowed when module version is less than 1.0.0. Downgrade bumped version to minor for this case.
            if (splitVersion[0] == 0 && versionBump == Version.MAJOR)
            {
                versionBump = Version.MINOR;
            }

            List<AzurePSVersion> galleryVersion = ModuleHelper.GetAllVersionsFromGallery(_fileHelper.ModuleName, PSRepositories);
            AzurePSVersion bumpedVersion = galleryVersion.Count == 0 ? new AzurePSVersion(0, 1, 0) : GetBumpedVersionByType(new AzurePSVersion(_oldVersion), versionBump);
            AzurePSVersion maxGAedVersionInGallery = ModuleHelper.GetLatestVersionFromGalleryUnderSameMajorVersion(bumpedVersion, galleryVersion, false);
            AzurePSVersion maxPreGAedVersionInGallery = ModuleHelper.GetLatestVersionFromGalleryUnderSameMajorVersion(bumpedVersion, galleryVersion, true);

            // Continue bumping version until bumpedVersion is higher than maxGAedVersionInGallery in same major version
            while (maxGAedVersionInGallery >= bumpedVersion)
            {
                string warningMsg = $"The GA version of {moduleName} in gallery ({maxGAedVersionInGallery}) is greater or equal to the bumped version({bumpedVersion}). Continue bumping version for {moduleName}.";
                _logger.LogWarning(warningMsg);
                bumpedVersion = GetBumpedVersionByType(bumpedVersion, versionBump);
            }

            // Continue bumping version until bumpedVersion is higher than maxPreGAedVersionInGallery in same major version
            while (maxPreGAedVersionInGallery >= bumpedVersion)
            {
                _logger.LogWarning($"There is greater preview version in the gallery. Continue bumping version for ${moduleName}");
                bumpedVersion = GetBumpedVersionByType(bumpedVersion, Version.MINOR);
            }
            
            return bumpedVersion.ToString();
        }

        /// <summary>
        /// Get bumped version by type.
        /// </summary>
        /// <param name="version">The version before bump.</param>
        /// <param name="type">The bump type.</param>
        /// <returns>The version after bump.</returns>
        private AzurePSVersion GetBumpedVersionByType(AzurePSVersion version, Version type)
        {
            AzurePSVersion bumpedVersion;
            if (type == Version.MAJOR)
            {
                bumpedVersion = new AzurePSVersion(version.Major + 1, 0, 0, version.Label);
            }
            else if (type == Version.MINOR)
            {
                bumpedVersion = new AzurePSVersion(version.Major, version.Minor + 1, 0, version.Label);
            }
            else
            {
                bumpedVersion = new AzurePSVersion(version.Major, version.Minor, version.Patch + 1, version.Label);
            }
            return bumpedVersion;
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
                powershell.AddScript("Set-ExecutionPolicy -ExecutionPolicy Unrestricted -Scope Process;");
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
                var pattern = nestedModule + @"(\s*),(\s*)Version(\s*)=(\s*)(\s*)(\d*).(\d*).(\d*).(\d*)(\s*)";
                var updatedFile = file.Select(l => Regex.Replace(l, pattern, nestedModule + ", Version=" + _newVersion + ".0"));
                File.WriteAllLines(serializedCmdletFile, updatedFile);
            }
        }

        /// <summary>
        /// Bumps the RequiredVersion field for a given module in the hashtable of RequiredModules
        /// in the Az module manifest file.
        /// </summary>
        private void UpdateRollupModuleManifest()
        {
            var rollupModuleManifestPath = _fileHelper.RollupModuleManifestPath;
            var moduleName = _fileHelper.ModuleName;

            // Skip this step since preview modules should not be included in Az
            if (_isPreview)
            {
                return;
            }

            var file = File.ReadAllLines(rollupModuleManifestPath);
            var pattern = @"ModuleName(\s*)=(\s*)(['\""])" + moduleName + @"(['\""])(\s*);(\s*)RequiredVersion(\s*)=(\s*)(['\""])" + _oldVersion + @"(['\""])";
            var updatedFile = file.Select(l => Regex.Replace(l, pattern, "ModuleName = '" + moduleName + "'; RequiredVersion = '" + _newVersion + "'"));
            var pattern2 = @"ModuleName(\s*)=(\s*)(['\""])" + moduleName + @"(['\""])(\s*);(\s*)ModuleVersion(\s*)=(\s*)(['\""])" + _oldVersion + @"(['\""])";
            var updatedFile2 = _releaseType == ReleaseType.STS ? updatedFile.Select(l => Regex.Replace(l, pattern2, "ModuleName = '" + moduleName + "'; ModuleVersion = '" + _newVersion + "'")) :
                updatedFile.Select(l => Regex.Replace(l, pattern2, "ModuleName = '" + moduleName + "'; RequiredVersion = '" + _newVersion + "'"));
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
                var pattern = @"^(\s*)\[assembly:(\s*)AssemblyVersion\(([\""])(\d*).(\d*).(\d*)([\""])\)";
                file = file.Select(l => Regex.Replace(l, pattern, "[assembly: AssemblyVersion(\"" + _newVersion + "\")")).ToArray();
                pattern = @"^(\s*)\[assembly:(\s*)AssemblyFileVersion\(([\""])(\d*).(\d*).(\d*)([\""])\)";
                var updatedFile = file.Select(l => Regex.Replace(l, pattern, "[assembly: AssemblyFileVersion(\"" + _newVersion + "\")"));
                File.WriteAllLines(assemblyInfoPath, updatedFile);
            }
        }

        private void UpdateSerializedCmdlet()
        {
            var moduleName = _fileHelper.ModuleName;
            var version = _newVersion;
            var newModuleMetadata = _metadataHelper.NewModuleMetadata;
            newModuleMetadata.ModuleName = moduleName;
            newModuleMetadata.ModuleVersion = version;
            var serializedCmdletsDirectory = _fileHelper.SerializedCmdletsDirectory;
            var serializedCmdletName = $"{moduleName}.json";
            var serializedCmdletFile = Directory.GetFiles(serializedCmdletsDirectory, serializedCmdletName).FirstOrDefault();
            VersionMetadataHelper.SerializeCmdlets(serializedCmdletFile, newModuleMetadata);
        }

        /// <summary>
        /// Get the releases notes for the upcoming release from a change log.
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
        /// <param name="releaseNotes">Release notes for the upcoming release from the change log.</param>
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

            // Get required module list and update Az,Accounts' version
            var getRequiredModulesScript = "Import-LocalizedData -BaseDirectory " + outputModuleDirectory + " -FileName " + Path.GetFileName(outputModuleManifestPath) + " -BindingVariable moduleInfo;";
            getRequiredModulesScript += "$requiredModules = @();";
            if(_releaseType == ReleaseType.STS)
            {
                getRequiredModulesScript += "$moduleInfo.RequiredModules.ForEach({ " +
                            "if ($_.ModuleName -eq \"Az.Accounts\"){ " +
                            "  $requiredModules += @{ModuleName = \"Az.Accounts\"; ModuleVersion = \"" + _accountsVersion + "\"} " +
                            "}else " +
                            "{ " +
                            "  $requiredModules += $_ " +
                            "} " +
                          "});";
            }
            else
            {
                getRequiredModulesScript += "$moduleInfo.RequiredModules.ForEach({ " +
                            "if ($_.ModuleName -eq \"Az.Accounts\"){ " +
                            "  $requiredModules += @{ModuleName = \"Az.Accounts\"; RequiredVersion = \"" + _accountsVersion + "\"} " +
                            "}else " +
                            "{ " +
                            "  $requiredModules += $_ " +
                            "} " +
                          "});";
            }

            // Update module manifest
            script += getRequiredModulesScript;
            script += $"$env:PSModulePath+=\";{_fileHelper.OutputResourceManagerDirectory}\";";
            script += "Set-ExecutionPolicy -ExecutionPolicy Unrestricted -Scope Process;";
            script += "if ($requiredModules.Count -gt 0){" +
                   "Update-ModuleManifest -Path " + tempModuleManifestPath + " -ModuleVersion " + _newVersion + " -ReleaseNotes $releaseNotes" + " -RequiredModules $requiredModules" +
                "}else {" +
                   "Update-ModuleManifest -Path " + tempModuleManifestPath + " -ModuleVersion " + _newVersion + " -ReleaseNotes $releaseNotes" +
                "};";
            script += "$?";

            using (PowerShell powershell = PowerShell.Create())
            {
                powershell.AddScript(script);
                var result = powershell.Invoke();
                bool exitcode = false;
                if (result.Count > 0 && 
                    (!bool.TryParse(result.Last()?.ToString(), out exitcode)) || !exitcode)
                {
                    var errorMsg = $"Found error in updating module {_fileHelper.ModuleName}: {powershell.Streams.Error.First()?.ToString()}";
                    _logger.LogError(errorMsg);
                    throw new Exception(errorMsg);
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
        /// Update the ModuleVersion of the bumped module in any dependent module's RequiredModule field.
        /// </summary>
        private void UpdateDependentModules()
        {
            var moduleName = _fileHelper.ModuleName;
            var projectDirectories = _fileHelper.ProjectDirectories;
            foreach (var projectDirectory in projectDirectories)
            {
                var moduleManifestPaths = Directory.GetFiles(projectDirectory, "*.psd1", SearchOption.AllDirectories)
                                                   .Where(f => !f.Contains("Netcore") &&
                                                               !f.Contains("bin") &&
                                                               !f.Contains("dll-Help") &&
                                                               !ModuleFilter.IsAzureStackModule(f))
                                                   // Only update changed modules in this release
                                                   .Intersect(_changedModules)
                                                   .ToList();
                foreach (var moduleManifestPath in moduleManifestPaths)
                {
                    var file = File.ReadAllLines(moduleManifestPath);
                    var pattern = @"ModuleName(\s*)=(\s*)(['\""])" + moduleName + @"(['\""])(\s*);(\s*)ModuleVersion(\s*)=(\s*)(['\""])" + "\\d+(\\.\\d+)+" + @"(['\""])";
                    if (file.Where(l => Regex.IsMatch(l, pattern)).Any())
                    {
                        var updatedFile = file.Select(l => Regex.Replace(l, pattern, "ModuleName = '" + moduleName + "'; ModuleVersion = '" + _newVersion + "'"));
                        File.WriteAllLines(moduleManifestPath, updatedFile);
                    }
                }
            }
        }
        
        /// <summary>
        /// Creates a new header for the upcoming release based on the new version.
        /// </summary>
        private void UpdateChangeLog()
        {
            var changeLogPath = _fileHelper.ChangeLogPath;
            var file = File.ReadAllLines(changeLogPath);
            var newFile = new string[file.Length + 2];
            var idx = 0;
            while (idx < file.Length && !file[idx].Equals("## Upcoming Release"))
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
        /// Check whether or not the given module is new by searching for past entries in the change log.
        /// </summary>
        /// <returns>True if the module is new, false otherwise.</returns>
        private bool IsNewModule()
        {
            var changeLogPath = _fileHelper.ChangeLogPath;
            var file = File.ReadAllLines(changeLogPath);
            var idx = 0;
            while (idx < file.Length && !file[idx].Equals("## Upcoming Release"))
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
