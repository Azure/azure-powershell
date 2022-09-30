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

using Newtonsoft.Json;
using StaticAnalysis.BreakingChangeAnalyzer;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Management.Automation;
using System.Reflection;
using System.Text.RegularExpressions;
using Tools.Common.Issues;
using Tools.Common.Loaders;
using Tools.Common.Loggers;
using Tools.Common.Models;

namespace VersionController.Models
{
    public class VersionMetadataHelper
    {
        private VersionFileHelper _fileHelper;
        private AnalysisLogger _logger;
        private ModuleMetadata _newModuleMetadata;

        public ModuleMetadata NewModuleMetadata { get { return _newModuleMetadata; } }

        public VersionMetadataHelper(VersionFileHelper fileHelper)
        {
            _fileHelper = fileHelper;
            _logger = new AnalysisLogger(_fileHelper.ArtifactsVersionControllerDirectory, _fileHelper.ExceptionsDirectory);
            _newModuleMetadata = MetadataLoader.GetModuleMetadata(_fileHelper.ModuleName);
        }

        /// <summary>
        /// Deserialize a json file containing the module metadata for an assembly.
        /// </summary>
        /// <param name="fileName">Path to the json file to be deserialized.</param>
        /// <returns></returns>
        private ModuleMetadata DeserializeCmdlets(string fileName)
        {
            return File.Exists(fileName) ? JsonConvert.DeserializeObject<ModuleMetadata>(File.ReadAllText(fileName)) : null;
        }

        /// <summary>
        /// Serialize the cmdlets so they can be compared to change modules later
        /// </summary>
        /// <param name="fileName">Name of the file cmdlets are being serialized to.</param>
        /// <param name="cmdlets">List of cmdlets that are to be serialized.</param>
        public static string SerializeCmdlets(string fileName, ModuleMetadata moduleMetadata)
        {
            string json = JsonConvert.SerializeObject(moduleMetadata, new JsonSerializerSettings
            {
                Formatting = Formatting.Indented,
                NullValueHandling = NullValueHandling.Ignore,
                ContractResolver = VersionMetadataContractResolver.Instance
            });
            File.WriteAllText(fileName, json);
            return fileName;
        }

        /// <summary>
        /// Compare two module metadata objects for breaking changes from
        /// the old metadata to the new metadata.
        /// </summary>
        /// <param name="oldModuleMetadata">ModuleMetadata object containing the old module information.</param>
        /// <param name="newModuleMetadata">ModuleMetadata object containing the new module information.</param>
        /// <param name="issueLogger">Temporary logger used to track the breaking changes found.</param>
        private void CheckBreakingChangesInModules(
            ModuleMetadata oldModuleMetadata,
            ModuleMetadata newModuleMetadata,
            ReportLogger<BreakingChangeIssue> issueLogger)
        {
            var oldCmdlets = oldModuleMetadata.Cmdlets;
            var newCmdlets = newModuleMetadata.Cmdlets;
            var oldTypeDictionary = oldModuleMetadata.TypeDictionary;
            var newTypeDictionary = newModuleMetadata.TypeDictionary;
            TypeMetadataHelper typeMetadataHelper = new TypeMetadataHelper(oldTypeDictionary, newTypeDictionary);
            CmdletMetadataHelper cmdletMetadataHelper = new CmdletMetadataHelper(typeMetadataHelper);
            cmdletMetadataHelper.CompareCmdletMetadata(oldCmdlets, newCmdlets, issueLogger);
        }

        /// <summary>
        /// Check for breaking changes in the public API of types.
        /// </summary>
        /// <param name="oldTypeMetadataDictionary">Dictionary of type names mapped to metadata from the old module.</param>
        /// <param name="newTypeMetadataDictionary">Dictionary of type names mapped to metadata from the new module.</param>
        /// <param name="issueLogger">Temporary logger used to track the breaking changes found.</param>
        private void CheckBreakingChangesInTypes(
            Dictionary<string, TypeMetadata> oldTypeMetadataDictionary,
            Dictionary<string, TypeMetadata> newTypeMetadataDictionary,
            ReportLogger<BreakingChangeIssue> issueLogger)
        {
            var typeMetadataHelper = new TypeMetadataHelper(oldTypeMetadataDictionary, newTypeMetadataDictionary);
            foreach (var type in oldTypeMetadataDictionary.Keys)
            {
                var cmdletMetadata = new CmdletMetadata()
                {
                    NounName = "Common",
                    VerbName = type
                };

                if (!newTypeMetadataDictionary.ContainsKey(type))
                {
                    issueLogger?.LogBreakingChangeIssue(
                        cmdlet: cmdletMetadata,
                        severity: 0,
                        problemId: 0,
                        description: string.Empty,
                        remediation: string.Empty);
                    continue;
                }

                var oldTypeMetadata = oldTypeMetadataDictionary[type];
                var newTypeMetadata = newTypeMetadataDictionary[type];
                typeMetadataHelper.CompareTypeMetadata(cmdletMetadata, oldTypeMetadata, newTypeMetadata, issueLogger);
                typeMetadataHelper.CompareMethodSignatures(cmdletMetadata, oldTypeMetadata.Methods, newTypeMetadata.Methods, issueLogger);
                typeMetadataHelper.CompareMethodSignatures(cmdletMetadata, oldTypeMetadata.Constructors, newTypeMetadata.Constructors, issueLogger);
            }
        }

        /// <summary>
        /// Determine what kind of version bump should be applied to the common
        /// code library. We want to ensure that there were no breaking changes
        /// made to the common code to preserve backwards-compatibility.
        /// </summary>
        /// <returns>Version bump that should be applied to the common code library.</returns>
        public Version GetVersionBumpForCommonCode()
        {
            var outputModuleDirectory = _fileHelper.OutputModuleDirectory;
            var galleryModuleDirectory = _fileHelper.GalleryModuleDirectory;
            Console.WriteLine("Saving Az.Accounts from the PowerShell Gallery to check common code changes. This will take a few seconds.");
            Version versionBump = Version.PATCH;
            var issueLogger = _logger.CreateLogger<BreakingChangeIssue>("BreakingChangeIssues.csv");
            IEnumerable<string> commonAssemblies = null;
            using (PowerShell powershell = PowerShell.Create())
            {
                powershell.AddScript("Save-Module -Name Az.Accounts -Repository PSGallery -Path " + outputModuleDirectory );
                var cmdletResult = powershell.Invoke();
            }

            var galleryModuleVersionDirectory = _fileHelper.GalleryModuleVersionDirectory;
            using (PowerShell powershell = PowerShell.Create())
            {
                powershell.AddScript("$metadata = Test-ModuleManifest -Path " + Path.Combine(galleryModuleVersionDirectory, "Az.Accounts.psd1") + ";$metadata.RequiredAssemblies");
                var cmdletResult = powershell.Invoke();
                commonAssemblies = cmdletResult.Select(c => c.ToString().Substring(2)).Where(s => Regex.IsMatch(s, "Microsoft.*.Commands.*"));
            }

            try
            {
                foreach (var commonAssembly in commonAssemblies)
                {
                    var fullAssemblyPath = Path.Combine(outputModuleDirectory, commonAssembly);
                    var assemblyName = Path.GetFileName(commonAssembly);
                    var oldAssemblyPath = Directory.GetFiles(galleryModuleDirectory, assemblyName, SearchOption.AllDirectories).FirstOrDefault();
                    if (oldAssemblyPath == null)
                    {
                        throw new Exception("Could not find assembly " + assemblyName + " in the folder saved from the PowerShell Gallery for Az.Accounts.");
                    }

                    var oldAssembly = Assembly.LoadFrom(oldAssemblyPath);
                    CmdletLoader.ModuleMetadata = new ModuleMetadata();
                    var oldTypeMetadataDictionary = CmdletLoader.ModuleMetadata.TypeDictionary;
                    foreach (var oldType in oldAssembly.GetTypes())
                    {
                        if (oldType.Namespace == null)
                        {
                            // Sealed / private type
                            continue;
                        }

                        if (oldType.FullName != null && oldType.FullName.Contains("+"))
                        {
                            oldTypeMetadataDictionary[oldType.ToString()] = new TypeMetadata() { Name = oldType.ToString() };
                        }

                        if (!oldTypeMetadataDictionary.ContainsKey(oldType.ToString()))
                        {
                            var oldTypeMetadata = new TypeMetadata(oldType);
                            oldTypeMetadataDictionary[oldType.ToString()] = oldTypeMetadata;
                        }
                    }

                    var newAssembly = Assembly.LoadFrom(fullAssemblyPath);
                    CmdletLoader.ModuleMetadata = new ModuleMetadata();
                    var newTypeMetadataDictionary = CmdletLoader.ModuleMetadata.TypeDictionary;
                    foreach (var newType in newAssembly.GetTypes())
                    {
                        if (newType.Namespace == null)
                        {
                            // Sealed / private type
                            continue;
                        }

                        if (newType.FullName != null && newType.FullName.Contains("+"))
                        {
                            newTypeMetadataDictionary[newType.ToString()] = new TypeMetadata() { Name = newType.ToString() };
                        }

                        if (!newTypeMetadataDictionary.ContainsKey(newType.ToString()))
                        {
                            var newTypeMetadata = new TypeMetadata(newType);
                            newTypeMetadataDictionary[newType.ToString()] = newTypeMetadata;
                        }
                    }

                    issueLogger.Decorator.AddDecorator(a => a.AssemblyFileName = Path.GetFileName(commonAssembly), "AssemblyFileName");
                    CheckBreakingChangesInTypes(oldTypeMetadataDictionary, newTypeMetadataDictionary, issueLogger);
                    if (issueLogger.Records.Any())
                    {
                        return Version.MAJOR;
                    }
                    else
                    {
                        foreach (var type in oldTypeMetadataDictionary.Keys)
                        {
                            if (!newTypeMetadataDictionary.ContainsKey(type))
                            {
                                continue;
                            }

                            var oldTypeMetadata = oldTypeMetadataDictionary[type];
                            var newTypeMetadata = newTypeMetadataDictionary[type];
                            if (!oldTypeMetadata.Equals(newTypeMetadata))
                            {
                                versionBump = Version.MINOR;
                            }
                        }

                        if (oldTypeMetadataDictionary.Keys.Count != newTypeMetadataDictionary.Keys.Count)
                        {
                            versionBump = Version.MINOR;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                var directories = Directory.GetDirectories(outputModuleDirectory, "Az.Accounts", SearchOption.TopDirectoryOnly);
                foreach (var directory in directories)
                {
                    try
                    {
                        Directory.Delete(directory, true);
                    }
                    catch (Exception ex)
                    {
                        var blank = ex.Message;
                    }
                }
            }

            Console.WriteLine("Found " + versionBump + " version bump for common code changes.");
            return versionBump;
        }

        /// <summary>
        /// Determine what version bump should be applied to a module version.
        /// This will compare the cmdlet assemblies in the output (built) module manifest with
        /// the corresponding deserialized module metadata from the JSON file.
        /// </summary>
        /// <param name="serialize">Whether or not the module metadata should be serialized.</param>
        /// <returns>Version enum representing the version bump to be applied.</returns>
        public Version GetVersionBumpUsingSerialized()
        {
            var outputModuleManifestPath = _fileHelper.OutputModuleManifestPath;
            var outputModuleDirectory = _fileHelper.OutputModuleDirectory;
            var outputDirectories = _fileHelper.OutputDirectories;
            var serializedCmdletsDirectory = _fileHelper.SerializedCmdletsDirectory;
            var moduleName = _fileHelper.ModuleName;

            var tempVersionBump = Version.PATCH;
            var issueLogger = _logger.CreateLogger<BreakingChangeIssue>("BreakingChangeIssues.csv");

            var newModuleMetadata = _newModuleMetadata;
            var serializedCmdletName = $"{moduleName}.json";
            var serializedCmdletFile = Directory.GetFiles(serializedCmdletsDirectory, serializedCmdletName).FirstOrDefault();
            if (serializedCmdletFile == null)
            {
                var currentColor = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"Warning: {moduleName} does not have a previously serialized cmdlet for comparison.");
                Console.ForegroundColor = currentColor;
                var newCmdletFile = Path.Join(serializedCmdletsDirectory, serializedCmdletName);
                // Use newly build one, only bump PATCH version
                serializedCmdletFile = SerializeCmdlets(newCmdletFile, newModuleMetadata);
            }
            var oldModuleMetadata = DeserializeCmdlets(serializedCmdletFile);
            CmdletLoader.ModuleMetadata = oldModuleMetadata;
            issueLogger.Decorator.AddDecorator(a => a.AssemblyFileName = moduleName, "AssemblyFileName");
            CheckBreakingChangesInModules(oldModuleMetadata, newModuleMetadata, issueLogger);
            if (issueLogger.Records.Any())
            {
                var currentColor = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"Detected below {issueLogger.Records.Count} breack change(s):");
                foreach (IReportRecord record in issueLogger.Records)
                {
                    Console.WriteLine(((BreakingChangeIssue)record).Target + " " + record.ProblemId + " " + record.Description);
                }
                Console.ForegroundColor = currentColor;
                tempVersionBump = Version.MAJOR;
            }
            else if (!oldModuleMetadata.Equals(newModuleMetadata))
            {
                tempVersionBump = Version.MINOR;
            }

            return tempVersionBump;
        }

        /// <summary>
        /// Determine which version bump should be applied to a module version.
        /// This will compare the cmdlet assemblies in the output (built) module manifest with
        /// the cmdlet assemblies in the saved gallery folder.
        /// </summary>
        /// <returns>Version enum representing the version bump to be applied.</returns>
        public Version GetVersionBumpUsingGallery()
        {
            Console.WriteLine("Comparing the cmdlet assemblies with assemblies in the saved gallery folder...");
            var outputModuleManifestPath = _fileHelper.OutputModuleManifestPath;
            var outputModuleDirectory = _fileHelper.OutputModuleDirectory;
            var outputDirectories = _fileHelper.OutputDirectories;
            var serializedCmdletsDirectory = _fileHelper.SerializedCmdletsDirectory;
            var galleryModuleVersionDirectory = _fileHelper.GalleryModuleVersionDirectory;
            var moduleName = _fileHelper.ModuleName;

            Version versionBump = Version.PATCH;
            var tempVersionBump = Version.PATCH;
            var issueLogger = _logger.CreateLogger<BreakingChangeIssue>("BreakingChangeIssues.csv");
            List<string> requiredModules = null;
            List<string> galleryRequiredModules = null;
            using (PowerShell powershell = PowerShell.Create())
            {
                powershell.AddScript("(Test-ModuleManifest -Path " + outputModuleManifestPath + ").RequiredModules");
                var cmdletResult = powershell.Invoke();
                requiredModules = cmdletResult.Select(c => c.ToString())
                                                .Join(outputDirectories,
                                                    module => 1,
                                                    directory => 1,
                                                    (module, directory) => Path.Combine(directory, module))
                                                .Where(f => Directory.Exists(f))
                                                .ToList();
                galleryRequiredModules = cmdletResult.Select(c => c.ToString())
                                                        .Select(f => Directory.GetDirectories(outputModuleDirectory, f).FirstOrDefault())
                                                        .Select(f => Directory.GetDirectories(f).FirstOrDefault())
                                                        .ToList();
            }

            galleryRequiredModules.Add(galleryModuleVersionDirectory);
            var galleryModulePsd1Path = Directory.EnumerateFiles(Path.Combine(outputModuleDirectory, $"{moduleName}"), "*.psd1", SearchOption.AllDirectories).FirstOrDefault();
            var newModuleMetadata = MetadataLoader.GetModuleMetadata(moduleName);
            
            var serializedCmdletName = $"{moduleName}.json";
            var serializedCmdletFile = Directory.GetFiles(serializedCmdletsDirectory, serializedCmdletName).FirstOrDefault();
            if (serializedCmdletFile == null)
            {
                var currentColor = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"Warning: {moduleName} does not have a previously serialized cmdlet for comparison.");
                Console.ForegroundColor = currentColor;
                var newCmdletFile = Path.Join(serializedCmdletsDirectory, serializedCmdletName);
                SerializeCmdlets(newCmdletFile, newModuleMetadata);
            }
            var oldModuleMetadata = DeserializeCmdlets(serializedCmdletFile);
            CmdletLoader.ModuleMetadata = oldModuleMetadata;
            issueLogger.Decorator.AddDecorator(a => a.AssemblyFileName = moduleName, "AssemblyFileName");
            CheckBreakingChangesInModules(oldModuleMetadata, newModuleMetadata, issueLogger);
            if (issueLogger.Records.Any())
            {
                tempVersionBump = Version.MAJOR;
            }
            else if (!oldModuleMetadata.Equals(newModuleMetadata))
            {
                tempVersionBump = Version.MINOR;
            }

            if (tempVersionBump == Version.MAJOR)
            {
                versionBump = Version.MAJOR;
            }
            else if (tempVersionBump == Version.MINOR && versionBump == Version.PATCH)
            {
                versionBump = Version.MINOR;
            }

            return versionBump;
        }

        /// <summary>
        /// Generate the serialized module metadata for a given module.
        /// </summary>
        public void SerializeModule()
        {
            var serializedCmdletsDirectory = _fileHelper.SerializedCmdletsDirectory;
            var moduleName = _fileHelper.ModuleName;

            var newModuleMetadata = MetadataLoader.GetModuleMetadata(moduleName);
            var serializedCmdletName = $"{moduleName}.json";
            var serializedCmdletFile = Path.Combine(serializedCmdletsDirectory, serializedCmdletName);
            SerializeCmdlets(serializedCmdletFile, newModuleMetadata);
        }
    }
}
