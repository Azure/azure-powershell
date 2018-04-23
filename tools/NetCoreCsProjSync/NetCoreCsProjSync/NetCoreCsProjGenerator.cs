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
using System.Xml.Serialization;
using NetCoreCsProjSync.NewModel;
using NetCoreCsProjSync.OldModel;
using Newtonsoft.Json;

namespace NetCoreCsProjSync
{
    internal static class NetCoreCsProjGenerator
    {
        private const string CsProjExtension = @".csproj";
        private const string CsProjFilter = @"*" + CsProjExtension;
        private const string NetCoreDenoter = @".Netcore";
        private const string NetCoreCsProjExtension = NetCoreDenoter + CsProjExtension;
        private const string NetCoreFilter = @"*" + NetCoreCsProjExtension;

        private const string CommandsFilter = @"Commands.*";
        private const string TestFolderDenoter = @".Test";
        private const string TestFolderDenoter2 = @".UnitTest";

        // https://stackoverflow.com/a/25245678/294804
        public static IEnumerable<string> GetProjectFolderPaths(string rmPath, bool ignoreExisting = false) =>
            Directory.EnumerateDirectories(rmPath).SelectMany(md =>
                Directory.EnumerateDirectories(md, CommandsFilter).Where(pd =>
                    !pd.EndsWith(TestFolderDenoter) && !pd.EndsWith(TestFolderDenoter2) &&
                    Directory.EnumerateFiles(pd, CsProjFilter, SearchOption.TopDirectoryOnly).Any() &&
                    (ignoreExisting || !Directory.EnumerateFiles(pd, NetCoreFilter, SearchOption.TopDirectoryOnly).Any())));

        public static IEnumerable<string> GetDesktopFilePaths(IEnumerable<string> projectPaths) =>
            projectPaths.Select(pd => Directory.EnumerateFiles(pd, CsProjFilter, SearchOption.TopDirectoryOnly).First(f => !f.Contains(NetCoreCsProjExtension)));

        public static string ConvertDesktopToNetCorePath(string desktopPath) =>
            Path.Combine(Path.GetDirectoryName(desktopPath), Path.GetFileNameWithoutExtension(desktopPath) + NetCoreCsProjExtension);

        public static IEnumerable<OldProjectDefinition> GetDesktopDefinitions(IEnumerable<string> desktopFilePaths)
        {
            var serializer = new XmlSerializer(typeof(OldProjectDefinition));
            foreach (var path in desktopFilePaths)
            {
                using (var fileStream = new FileStream(path, FileMode.Open))
                {
                    var definition = (OldProjectDefinition) serializer.Deserialize(fileStream);
                    definition.FilePath = path;
                    yield return definition;
                }
            }
        }

        public static readonly List<string> ModuleSkipList = File.Exists("ModuleSkipList.json")
            ? JsonConvert.DeserializeObject<List<string>>(File.ReadAllText("ModuleSkipList.json")) :
            new List<string>
            {
                "Aks",
                "AnalysisServices.Dataplane",
                "Compute.ManagedService",
                "Profile",
                "RecoveryServices.Backup.Logger",
                "Tags"
            };

        public static readonly Dictionary<string, List<string>> ModuleMap = File.Exists("ModuleMap.json")
            ? JsonConvert.DeserializeObject<Dictionary<string, List<string>>>(File.ReadAllText("ModuleMap.json")) :
            new Dictionary<string, List<string>>
            {
                { "AnalysisServices",                           new List<string> { "Management.Analysis" } },
                { "ApiManagement.ServiceManagement",            new List<string> { "Management.ApiManagement" } },
                { "AzureBackup",                                new List<string> { "Management.BackupServices", "WindowsAzure.Management.Scheduler" } },
                { "Batch",                                      new List<string> { "Azure.Batch", "Management.Batch" } },
                { "Management.CognitiveServices",               new List<string> { "Management.CognitiveServices" } },
                { "Compute",                                    new List<string> { "Management.Compute", "Management.KeyVault" } },
                { "DataFactories",                              new List<string> { "Management.DataFactories", "DataTransfer.Gateway.Encryption" } },
                { "DataFactoryV2",                              new List<string> { "Management.DataFactory" } },
                { "DataLakeAnalytics",                          new List<string> { "Management.DataLake.Analytics" } },
                { "DataLakeStore",                              new List<string> { "Management.DataLake.Store" } },
                { "HDInsight",                                  new List<string> { "Management.HDInsight", "Management.HDInsight.Job" } },
                { "Insights",                                   new List<string> { "Management.Monitor" } },
                { "KeyVault",                                   new List<string> { "Azure.KeyVault", "Azure.KeyVault.WebKey", "Management.KeyVault" } },
                { "LogicApp",                                   new List<string> { "Management.Logic", "Management.WebSites" } },
                { "OperationalInsights",                        new List<string> { "Management.OperationalInsights", "Azure.OperationalInsights" } },
                { "Partner",                                    new List<string> { "Management.ManagementPartner" } },
                { "PowerBI",                                    new List<string> { "Management.PowerBIDedicated" } },
                { "Management.PowerBIEmbedded",                 new List<string> { "Management.PowerBIEmbedded" } },
                { "RecoveryServices.Backup.Cmdlets",            new List<string> { "Management.RecoveryServices.Backup" } },
                { "RecoveryServices.Backup.Helpers",            new List<string> { "Management.RecoveryServices.Backup" } },
                { "RecoveryServices.Backup.Models",             new List<string> { "Management.RecoveryServices.Backup" } },
                { "RecoveryServices.Backup.Providers",          new List<string> { "Management.RecoveryServices.Backup" } },
                { "RecoveryServices.Backup.ServiceClientAdapter", new List<string> { "Management.RecoveryServices", "Management.RecoveryServices.Backup" } },
                { "RecoveryServices.SiteRecovery",              new List<string> { "Management.RecoveryServices", "Management.RecoveryServices.SiteRecovery" } },
                { "RedisCache",                                 new List<string> { "Azure.Insights", "Management.Redis" } },
                { "Resources",                                  new List<string> { "Management.Authorization" } },
                { "Resources.Rest",                             new List<string> { "Management.ResourceManager" } },
                { "ServiceFabric",                              new List<string> { "Azure.KeyVault", "Azure.KeyVault.WebKey", "Management.Compute", "Management.KeyVault", "Management.Network", "Management.ResourceManager", "Management.ServiceFabric", "Management.Storage" } },
                { "Sql",                                        new List<string> { "Management.Sql", "Microsoft.Azure.Management.Storage", "WindowsAzure.Management.Storage" } },
                { "Management.Storage",                         new List<string> { "Management.Storage" } },
                { "UsageAggregates",                            new List<string> { "Commerce.UsageAggregates" } }
            };

        public static Version StringToVersion(string version) => new Version(version.Split('-').First());

        private static string CreateVersionFromHintPath(string hintPath)
        {
            var slashParts = hintPath.Split('\\');
            if (slashParts[0] != "..") return null;

            var parts = slashParts[4].Split('.');
            //https://stackoverflow.com/a/18251942/294804
            var firstDigitIndex = parts.Select((p, i) => (Index: i, Part: p)).First(a => a.Part.All(Char.IsDigit)).Index;
            //https://stackoverflow.com/a/14435083/294804
            return String.Join('.', parts.Skip(firstDigitIndex));
        }

        public static string GetVersionString(OldReference oldReference)
        {
            const string versionToken = " Version=";
            var hasVersion = oldReference.Include.Contains(versionToken);
            var hasHintPath = oldReference.HintPath != null;
            var version = hasHintPath ? CreateVersionFromHintPath(oldReference.HintPath) : null;
            return version ?? (hasVersion ? oldReference.Include.Split(',')[1].Replace(versionToken, String.Empty) : null);
        }

        private static NewPackageReference ConvertOldToNewPackageReference(OldReference oldReference)
        {
            var version = GetVersionString(oldReference);
            var include = oldReference.Include.Split(',').First();
            return version == null || include == "System.Management.Automation" ? null : new NewPackageReference { Include = include, Version = version };
        }

        private static string ModifyOutputPath(string outputPath)
        {
            var length = outputPath.Length - (outputPath.EndsWith('\\') ? 1 : 0);
            return $"{outputPath.Substring(0, length)}{NetCoreDenoter}\\";
        }

        private static string ModifyPsd1Info(string psd1Info) => $"{psd1Info.Replace(".psd1", String.Empty)}{NetCoreDenoter}.psd1";


        private static readonly Dictionary<string, string> ProjectReferenceMapper = new Dictionary<string, string>
        {
            {"Commands.Common.csproj",                              "Common.Netcore.csproj"},
            {"Commands.Common.Authentication.csproj",               "Common.Authentication.Netcore.csproj"},
            {"Commands.Common.Authentication.Abstractions.csproj",  "Common.Authentication.Abstractions.Netcore.csproj"},
            {"Commands.Common.Authorization.csproj",                "Common.Authorization.Netcore.csproj"},
            {"Commands.Common.Graph.RBAC.csproj",                   "Common.Rbac.Netcore.csproj"},
            {"Commands.Common.Network.csproj",                      "Common.Network.Netcore.csproj"},
            {"Commands.Common.Storage.csproj",                      "Common.Storage.Netcore.csproj"},

            {"Commands.Common.Authentication.ResourceManager.csproj","Common.ResourceManager.Authentication.Netcore.csproj"},
            {"Commands.Common.Strategies.csproj",                   "Common.Strategies.Netcore.csproj"},
            {"Commands.ResourceManager.Common.csproj",              "Common.ResourceManager.Netcore.csproj"},

            {"Commands.Resources.Rest.csproj",                      "Commands.Resources.Rest.Netcore.csproj"}
        };

        private static string ModifyProjectReferencePath(string includePath)
        {
            var parts = includePath.Split('\\');
            var lastPart = parts.Last();
            var newLastPart = ProjectReferenceMapper.ContainsKey(lastPart) ? ProjectReferenceMapper[lastPart] : lastPart;
            var newParts = parts.Take(parts.Length - 1).Append(newLastPart);
            return String.Join('\\', newParts);
        }

        public static NewProjectDefinition ConvertOldToNewNetCore(OldProjectDefinition oldDefinition)
        {
            var oldReferences = oldDefinition.ItemGroups.Where(ig => ig.References?.Any() ?? false).SelectMany(ig => ig.References);
            var newPackageReferences = oldReferences.Select(ConvertOldToNewPackageReference).Where(r => r != null).ToList();
            var packageReferencesItemGroup = !newPackageReferences.Any() ? null : new NewItemGroup
            {
                PackageReferences = newPackageReferences
            };
            var noneItems = oldDefinition.ItemGroups.Where(ig => ig.NoneItems?.Any() ?? false).SelectMany(ig => ig.NoneItems).ToList();
            var psd1None = noneItems.FirstOrDefault(ni => ni.Include?.EndsWith("psd1") ?? false);
            var psd1ItemGroup = psd1None == null ? null : new NewItemGroup
            {
                NoneItems = new List<NewNone>
                {
                    new NewNone
                    {
                        Include = ModifyPsd1Info(psd1None.Include),
                        Link = psd1None.Link == null ? null : ModifyPsd1Info(psd1None.Link),
                        CopyToOutputDirectory = "PreserveNewest"
                    }
                }
            };
            var newProjectReferences = oldDefinition.ItemGroups.Where(ig => ig.ProjectReferences?.Any() ?? false).SelectMany(ig => ig.ProjectReferences)
                .Select(pr => new NewProjectReference { Include = ModifyProjectReferencePath(pr.Include) }).ToList();
            var projectReferencesItemGroup = !newProjectReferences.Any() ? null : new NewItemGroup
            {
                ProjectReferences = newProjectReferences
            };
            var ps1XmlInclude = noneItems.FirstOrDefault(ni => ni.Include?.EndsWith("ps1xml") ?? false)?.Include;
            if (ps1XmlInclude == null)
            {
                var contentItems = oldDefinition.ItemGroups.Where(ig => ig.ContentItems?.Any() ?? false).SelectMany(ig => ig.ContentItems).ToList();
                ps1XmlInclude = contentItems.FirstOrDefault(ci => ci.Include?.EndsWith("ps1xml") ?? false)?.Include;
            }
            var ps1XmlItemGroup = ps1XmlInclude == null ? null : new NewItemGroup
            {
                NoneItems = new List<NewNone>
                {
                    new NewNone
                    {
                        Update = ps1XmlInclude,
                        CopyToOutputDirectory = "PreserveNewest"
                    }
                }
            };

            return new NewProjectDefinition
            {
                Sdk = "Microsoft.NET.Sdk",
                Import = new NewImport
                {
                    Project = @"..\..\..\..\tools\Common.Netcore.Dependencies.targets"
                },
                PropertyGroups = new List<NewPropertyGroup>
                {
                    new NewPropertyGroup
                    {
                        TargetFramework = "netcoreapp2.0",
                        AssemblyName = oldDefinition.PropertyGroups.First(pg => pg.AssemblyName != null).AssemblyName,
                        RootNamespace = oldDefinition.PropertyGroups.First(pg => pg.RootNamespace != null).RootNamespace,
                        GenerateAssemblyInfo = false,
                        AllowUnsafeBlocks = true,
                        CopyLocalLockFileAssemblies = true,
                        AppendTargetFrameworkToOutputPath = false
                    },
                    new NewPropertyGroup
                    {
                        Condition = "'$(Configuration)|$(Platform)'=='Debug|AnyCPU'",
                        OutputPath = ModifyOutputPath(oldDefinition.PropertyGroups.First(pg => pg.OutputPath?.Contains("Debug") ?? false).OutputPath),
                        DelaySign = false,
                        DefineConstants = "TRACE;DEBUG;NETSTANDARD"
                    },
                    new NewPropertyGroup
                    {
                        Condition = "'$(Configuration)|$(Platform)'=='Release|AnyCPU'",
                        OutputPath = ModifyOutputPath(oldDefinition.PropertyGroups.First(pg => pg.OutputPath?.Contains("Release") ?? false).OutputPath),
                        DocumentationFile = String.Empty,
                        SignAssembly = true,
                        DelaySign = true,
                        AssemblyOriginatorKeyFile = "MSSharedLibKey.snk",
                        DefineConstants = "TRACE;RELEASE;NETSTANDARD;SIGN"
                    }
                },
                ItemGroups = new List<NewItemGroup>
                {
                    packageReferencesItemGroup,
                    psd1ItemGroup,
                    projectReferencesItemGroup,
                    new NewItemGroup
                    {
                        CompileItems = new List<NewCompile>
                        {
                            new NewCompile
                            {
                                Update = @"Properties\Resources.Designer.cs",
                                DesignTime = true,
                                AutoGen = true,
                                DependentUpon = "Resources.resx"
                            }
                        }
                    },
                    new NewItemGroup
                    {
                        EmbeddedResources = new List<NewEmbeddedResource>
                        {
                            new NewEmbeddedResource
                            {
                                Update = @"Properties\Resources.resx",
                                Generator = "ResXFileCodeGenerator",
                                LastGenOutput = "Resources.Designer.cs"
                            }
                        }
                    },
                    ps1XmlItemGroup,
                    new NewItemGroup
                    {
                        ContentItems = new List<NewContent>
                        {
                            new NewContent
                            {
                                Include = @"help\**\*",
                                CopyToOutputDirectory = "PreserveNewest"
                            }
                        }
                    }
                }
            };
        }
    }
}
