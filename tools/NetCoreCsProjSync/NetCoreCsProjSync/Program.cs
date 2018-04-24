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
using System.Xml;
using System.Xml.Serialization;
using NetCoreCsProjSync.NewModel;
using static NetCoreCsProjSync.NetCoreCsProjGenerator;

namespace NetCoreCsProjSync
{
    public static class Program
    {
        private const string Validate = "-v";
        private const string Create = "-c";

        private static readonly Dictionary<string, Action<string>> ModeMap = new Dictionary<string, Action<string>>
        {
            { Validate, ValidateCsProjFiles },
            { Create, CreateCsProjFiles }
        };

        public static void Main(string[] args)
        {
            var rmPath = args.FirstOrDefault(a => !ModeMap.ContainsKey(a)) ?? @"..\..\..\src\ResourceManager";
            if (!Directory.Exists(rmPath))
            {
                throw new ArgumentException($"Directory [{rmPath}] does not exist");
            }
            //https://stackoverflow.com/a/17563994/294804
            var mode = args.Any(a => a.IndexOf(Create, StringComparison.InvariantCultureIgnoreCase) >= 0) ? Create : Validate;
            ModeMap[mode](rmPath);
        }

        private static void ValidateCsProjFiles(string rmPath)
        {
            var projectFolders = GetProjectFolderPaths(rmPath, true);
            var desktopFilePaths = GetDesktopFilePaths(projectFolders);
            var desktopDefinitions = GetDesktopDefinitions(desktopFilePaths);

            foreach (var desktopDefinition in desktopDefinitions)
            {
                var netCorePath = ConvertDesktopToNetCorePath(desktopDefinition.FilePath);
                var desktopFileName = Path.GetFileNameWithoutExtension(desktopDefinition.FilePath);
                var moduleName = desktopFileName.Replace("Commands.", String.Empty);
                var netCoreFileName = Path.GetFileNameWithoutExtension(netCorePath);
                if (!File.Exists(netCorePath) || ModuleSkipList.Contains(moduleName))
                {
                    var priorColor = Console.ForegroundColor;
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine($"Skipping {netCoreFileName}");
                    Console.ForegroundColor = priorColor;
                    continue;
                }

                Console.WriteLine($"Validating {netCoreFileName}");
                var oldReferences = desktopDefinition.ItemGroups.Where(ig => ig.References?.Any() ?? false).SelectMany(ig => ig.References).ToArray();
                var managementPackageNames = ModuleMap.ContainsKey(moduleName) ? ModuleMap[moduleName] : new List<string> { $"Management.{moduleName}" } ;
                foreach (var managementPackageName in managementPackageNames)
                {
                    var oldManagementReference = oldReferences.FirstOrDefault(r => (r?.Include?.Contains(managementPackageName) ?? false) || (r?.HintPath?.Contains(managementPackageName) ?? false));
                    if (oldManagementReference == null)
                    {
                        var priorColor = Console.ForegroundColor;
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine($"{desktopFileName}: Could not locate management library containing {managementPackageName}");
                        Console.ForegroundColor = priorColor;
                        Environment.ExitCode = 1;
                        continue;
                    }

                    var serializer = new XmlSerializer(typeof(NewProjectDefinition));
                    NewProjectDefinition netCoreDefinition;
                    using (var fileStream = new FileStream(netCorePath, FileMode.Open))
                    {
                        netCoreDefinition = (NewProjectDefinition)serializer.Deserialize(fileStream);
                    }

                    var newPackageReferences = netCoreDefinition.ItemGroups.Where(ig => ig.PackageReferences?.Any() ?? false).SelectMany(ig => ig.PackageReferences);
                    var newManagementReference = newPackageReferences.FirstOrDefault(r => r?.Include?.Contains(managementPackageName) ?? false);
                    if (newManagementReference == null)
                    {
                        var priorColor = Console.ForegroundColor;
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine($"{netCoreFileName}: Could not locate management library containing {managementPackageName}");
                        Console.ForegroundColor = priorColor;
                        Environment.ExitCode = 1;
                        continue;
                    }

                    var oldVersionString = GetVersionString(oldManagementReference);
                    var oldVersion = StringToVersion(oldVersionString);
                    var newVersionString = newManagementReference.Version;
                    var newVersion = StringToVersion(newVersionString);
                    // ReSharper disable once InvertIf
                    if (oldVersion > newVersion)
                    {
                        var priorColor = Console.ForegroundColor;
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine($"Version mismatch: {oldVersionString} > {newVersionString} : {managementPackageName}");
                        Console.ForegroundColor = priorColor;
                        Environment.ExitCode = 1;
                    }
                }
            }
        }

        private static void CreateCsProjFiles(string rmPath)
        {
            var projectFolders = GetProjectFolderPaths(rmPath);
            var desktopFilePaths = GetDesktopFilePaths(projectFolders);
            var desktopDefinitions = GetDesktopDefinitions(desktopFilePaths);

            var serializer = new XmlSerializer(typeof(NewProjectDefinition));
            foreach (var desktopDefinition in desktopDefinitions)
            {
                var path = ConvertDesktopToNetCorePath(desktopDefinition.FilePath);
                Console.WriteLine($"Creating {path}");

                var netCoreDefinition = ConvertOldToNewNetCore(desktopDefinition);
                //https://stackoverflow.com/a/760290/294804
                //https://stackoverflow.com/a/3732234/294804
                var blankNamespaces = new XmlSerializerNamespaces(new[] { XmlQualifiedName.Empty });
                var xmlSettings = new XmlWriterSettings { OmitXmlDeclaration = true, Indent = true };
                using (var stringWriter = new StringWriter())
                using (var xmlWriter = XmlWriter.Create(stringWriter, xmlSettings))
                {
                    serializer.Serialize(xmlWriter, netCoreDefinition, blankNamespaces);
                    var lines = stringWriter.ToString().Split(Environment.NewLine).ToList();
                    var newLineIndecies = lines.Select((l, i) => (Index: i, Line: l)).Where(a =>
                            a.Line.StartsWith("<Project") || a.Line.StartsWith("  <Import") ||
                            a.Line.StartsWith("  </PropertyGroup>") || a.Line.StartsWith("  </ItemGroup>"))
                        .Select(a => a.Index).ToList();

                    for (var i = 0; i < newLineIndecies.Count; ++i)
                    {
                        lines.Insert(newLineIndecies[i] + i + 1, String.Empty);
                    }
                    File.WriteAllLines(path, lines.Take(lines.Count - 1));
                    using (var streamWriter = File.AppendText(path))
                    {
                        streamWriter.Write(lines.Last());
                    }
                }
            }
        }
    }
}
