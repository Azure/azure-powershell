﻿using Newtonsoft.Json;
using StaticAnalysis.BreakingChangeAnalyzer;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Management.Automation;
using System.Reflection;
using Tools.Common.Helpers;
using Tools.Common.Loaders;
using Tools.Common.Loggers;
using Tools.Common.Models;

namespace VersionController.Models
{
    public class VersionMetadataHelper
    {
        private VersionFileHelper _fileHelper;
        private AnalysisLogger _logger;
        private AppDomain _appDomain;

        public VersionMetadataHelper(VersionFileHelper fileHelper)
        {
            _fileHelper = fileHelper;
            _logger = new AnalysisLogger(_fileHelper.DebugDirectory, _fileHelper.PackageDirectory);
        }

        /// <summary>
        /// Deserialize a json file containing the module metadata for an assembly.
        /// </summary>
        /// <param name="fileName">Path to the json file to be deserialized.</param>
        /// <returns></returns>
        private ModuleMetadata DeserializeCmdlets(string fileName)
        {
            return JsonConvert.DeserializeObject<ModuleMetadata>(File.ReadAllText(fileName));
        }

        /// <summary>
        /// Serialize the cmdlets so they can be compared to change modules later
        /// </summary>
        /// <param name="fileName">Name of the file cmdlets are being serialized to.</param>
        /// <param name="cmdlets">List of cmdlets that are to be serialized.</param>
        private void SerializeCmdlets(string fileName, ModuleMetadata moduleMetadata)
        {
            string json = JsonConvert.SerializeObject(moduleMetadata, Formatting.Indented);
            File.WriteAllText(fileName, json);
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
                    issueLogger.LogBreakingChangeIssue(
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
                typeMetadataHelper.CompareMethodMetadata(cmdletMetadata, oldTypeMetadata, newTypeMetadata, issueLogger);
                typeMetadataHelper.CompareConstructorMetadata(cmdletMetadata, oldTypeMetadata, newTypeMetadata, issueLogger);
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

            Console.WriteLine("Saving AzureRM.Profile from the PowerShell Gallery to check common code changes. This will take a few seconds.");
            Version versionBump = Version.PATCH;
            var issueLogger = _logger.CreateLogger<BreakingChangeIssue>("BreakingChangeIssues.csv");
            using (PowerShell powershell = PowerShell.Create())
            {
                powershell.AddScript("Save-Module -Name AzureRM.Profile -Repository PSGallery -Path " + outputModuleDirectory);
                var cmdletResult = powershell.Invoke();
            }

            try
            {
                var commonAssemblies = new List<string>
                {
                    Path.Combine(outputModuleDirectory, "Microsoft.Azure.Commands.Common.Authentication.Abstractions.dll"),
                    Path.Combine(outputModuleDirectory, "Microsoft.WindowsAzure.Commands.Common.dll"),
                    Path.Combine(outputModuleDirectory, "Microsoft.Azure.Commands.ResourceManager.Common.dll"),
                    Path.Combine(outputModuleDirectory, "Microsoft.Azure.Commands.Common.Authorization.dll"),
                    Path.Combine(outputModuleDirectory, "Microsoft.Azure.Commands.Common.Graph.RBAC.dll"),
                    Path.Combine(outputModuleDirectory, "Microsoft.Azure.Commands.Common.Network.dll"),
                    Path.Combine(outputModuleDirectory, "Microsoft.WindowsAzure.Commands.Common.Storage.dll")
                };

                foreach (var commonAssembly in commonAssemblies)
                {
                    var assemblyName = Path.GetFileName(commonAssembly);

                    var newFile = File.ReadAllBytes(commonAssembly);
                    var newAssembly = Assembly.Load(newFile);

                    var oldAssemblyPath = Directory.GetFiles(galleryModuleDirectory, assemblyName, SearchOption.AllDirectories).FirstOrDefault();
                    if (oldAssemblyPath == null)
                    {
                        throw new Exception("Could not find assembly " + assemblyName + " in the folder saved from the PowerShell Gallery for AzureRM.Profile.");
                    }

                    var oldFile = File.ReadAllBytes(oldAssemblyPath);
                    var oldAssembly = Assembly.Load(oldFile);

                    CmdletLoader.ModuleMetadata = new ModuleMetadata();
                    var oldTypeMetadataDictionary = CmdletLoader.ModuleMetadata.TypeDictionary;
                    foreach (var oldType in oldAssembly.GetTypes())
                    {
                        if (oldType.Namespace == null)
                        {
                            // Sealed / private type
                            continue;
                        }

                        var oldTypeMetadata = new TypeMetadata(oldType);
                        if (!oldTypeMetadataDictionary.ContainsKey(oldType.ToString()))
                        {
                            oldTypeMetadataDictionary[oldType.ToString()] = oldTypeMetadata;
                        }
                    }

                    CmdletLoader.ModuleMetadata = new ModuleMetadata();
                    var newTypeMetadataDictionary = CmdletLoader.ModuleMetadata.TypeDictionary;
                    foreach (var newType in newAssembly.GetTypes())
                    {
                        if (newType.Namespace == null)
                        {
                            // Sealed / private type
                            continue;
                        }

                        var newTypeMetadata = new TypeMetadata(newType);
                        if (!newTypeMetadataDictionary.ContainsKey(newType.ToString()))
                        {
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
                var directories = Directory.GetDirectories(outputModuleDirectory, "AzureRM.Profile", SearchOption.TopDirectoryOnly);
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
        public Version GetVersionBumpUsingSerialized(bool serialize = true)
        {
            var outputModuleManifestPath = _fileHelper.OutputModuleManifestPath;
            var outputModuleDirectory = _fileHelper.OutputModuleDirectory;
            var outputDirectories = _fileHelper.OutputDirectories;
            var serializedCmdletsDirectory = _fileHelper.SerializedCmdletsDirectory;
            var moduleName = _fileHelper.ModuleName;

            IEnumerable<string> nestedModules = null;
            using (PowerShell powershell = PowerShell.Create())
            {
                powershell.AddScript("(Test-ModuleManifest -Path " + outputModuleManifestPath + ").NestedModules");
                var cmdletResult = powershell.Invoke();
                nestedModules = cmdletResult.Select(c => c.ToString() + ".dll");
            }

            Version versionBump = Version.PATCH;
            if (nestedModules.Any())
            {
                var tempVersionBump = Version.PATCH;
                var issueLogger = _logger.CreateLogger<BreakingChangeIssue>("BreakingChangeIssues.csv");

                List<string> requiredModules = null;
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
                }

                requiredModules.Add(outputModuleDirectory);
                foreach (var nestedModule in nestedModules)
                {
                    var assemblyPath = Directory.GetFiles(outputModuleDirectory, nestedModule, SearchOption.AllDirectories).FirstOrDefault();
                    var proxy = EnvironmentHelpers.CreateProxy<CmdletLoader>(outputModuleManifestPath, out _appDomain);
                    var newModuleMetadata = proxy.GetModuleMetadata(assemblyPath, requiredModules);
                    var serializedCmdletName = nestedModule + ".json";
                    var serializedCmdletFile = Directory.GetFiles(serializedCmdletsDirectory, serializedCmdletName).FirstOrDefault();

                    var oldModuleMetadata = DeserializeCmdlets(serializedCmdletFile);

                    CmdletLoader.ModuleMetadata = oldModuleMetadata;

                    issueLogger.Decorator.AddDecorator(a => a.AssemblyFileName = assemblyPath, "AssemblyFileName");
                    CheckBreakingChangesInModules(oldModuleMetadata, newModuleMetadata, issueLogger);

                    if (issueLogger.Records.Any())
                    {
                        tempVersionBump = Version.MAJOR;
                    }
                    else if (!oldModuleMetadata.Equals(newModuleMetadata))
                    {
                        tempVersionBump = Version.MINOR;
                    }

                    if (tempVersionBump != Version.PATCH && serialize)
                    {
                        SerializeCmdlets(serializedCmdletFile, newModuleMetadata);
                    }

                    if (tempVersionBump == Version.MAJOR)
                    {
                        versionBump = Version.MAJOR;
                    }
                    else if (tempVersionBump == Version.MINOR && versionBump == Version.PATCH)
                    {
                        versionBump = Version.MINOR;
                    }
                }
            }
            else
            {
                throw new NullReferenceException("No nested modules found for " + moduleName);
            }

            return versionBump;
        }

        /// <summary>
        /// Determine which version bump should be applied to a module version.
        /// This will compare the cmdlet assemblies in the output (built) module manifest with
        /// the cmdlet assemblies in the saved gallery folder.
        /// </summary>
        /// <returns>Version enum representing the version bump to be applied.</returns>
        public Version GetVersionBumpUsingGallery()
        {
            var outputModuleManifestPath = _fileHelper.OutputModuleManifestPath;
            var outputModuleDirectory = _fileHelper.OutputModuleDirectory;
            var outputDirectories = _fileHelper.OutputDirectories;
            var serializedCmdletsDirectory = _fileHelper.SerializedCmdletsDirectory;
            var galleryModuleVersionDirectory = _fileHelper.GalleryModuleVersionDirectory;
            var moduleName = _fileHelper.ModuleName;

            IEnumerable<string> nestedModules = null;
            using (PowerShell powershell = PowerShell.Create())
            {
                powershell.AddScript("(Test-ModuleManifest -Path " + outputModuleManifestPath + ").NestedModules");
                var cmdletResult = powershell.Invoke();
                nestedModules = cmdletResult.Select(c => c.ToString() + ".dll");
            }

            Version versionBump = Version.PATCH;
            if (nestedModules.Any())
            {
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

                requiredModules.Add(outputModuleDirectory);
                galleryRequiredModules.Add(galleryModuleVersionDirectory);
                foreach (var nestedModule in nestedModules)
                {
                    var assemblyPath = Directory.GetFiles(galleryModuleVersionDirectory, nestedModule).FirstOrDefault();
                    var proxy = EnvironmentHelpers.CreateProxy<CmdletLoader>(galleryModuleVersionDirectory, out _appDomain);
                    var oldModuleMetadata = proxy.GetModuleMetadata(assemblyPath, galleryRequiredModules);

                    assemblyPath = Directory.GetFiles(outputModuleDirectory, nestedModule).FirstOrDefault();
                    proxy = EnvironmentHelpers.CreateProxy<CmdletLoader>(galleryModuleVersionDirectory, out _appDomain);
                    var newModuleMetadata = proxy.GetModuleMetadata(assemblyPath, requiredModules);

                    CmdletLoader.ModuleMetadata = oldModuleMetadata;

                    issueLogger.Decorator.AddDecorator(a => a.AssemblyFileName = assemblyPath, "AssemblyFileName");
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
                }
            }
            else
            {
                throw new NullReferenceException("No nested modules found for " + moduleName);
            }

            return versionBump;
        }
    }
}
