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
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Management.Automation;
using NetCorePsd1Sync.Model;
using NetCorePsd1Sync.Utility;
using static NetCorePsd1Sync.Model.PsDefinitionConstants;

namespace NetCorePsd1Sync
{
    internal static class NetCoreDefinitionGenerator
    {
        private const string Psd1Extension = @".psd1";
        private const string Psd1Filter = @"*" + Psd1Extension;
        private const string NetCorePsd1Extension = @".Netcore" + Psd1Extension;
        private const string NetCoreFilter = @"*" + NetCorePsd1Extension;

        private static readonly Version NetCoreModuleVersion = new Version(0, 10, 0);
        private const string NetCoreCompatiblePsEdition = "Core";
        private static readonly Version NetCorePsVersion = new Version(5, 1);

        // https://stackoverflow.com/a/25245678/294804
        public static IEnumerable<string> GetModulePaths(string rmPath, bool ignoreExisting = false) => 
            Directory.EnumerateDirectories(rmPath).Where(d =>
                Directory.EnumerateFiles(d, Psd1Filter, SearchOption.TopDirectoryOnly).Any() &&
                (ignoreExisting || !Directory.EnumerateFiles(d, NetCoreFilter, SearchOption.TopDirectoryOnly).Any()));

        public static IEnumerable<string> GetDesktopFilePaths(IEnumerable<string> modulePaths) =>
            modulePaths.Select(m => Directory.EnumerateFiles(m, Psd1Filter, SearchOption.TopDirectoryOnly).First(f => !f.Contains(NetCorePsd1Extension)));

        public static string ConvertDesktopToNetCorePath(string desktopPath) =>
            Path.Combine(Path.GetDirectoryName(desktopPath), Path.GetFileNameWithoutExtension(desktopPath) + NetCorePsd1Extension);

        public static PsDefinitionHeader ReadDefinitionHeader(string path)
        {
            var lines = File.ReadAllLines(path);

            var moduleDisplayName = AttributeHelper.GetPropertyAttributeValue<PsDefinitionHeader, string, DisplayNameAttribute, string>(pd => pd.ModuleName, attr => attr.DisplayName, String.Empty);
            var nameLine = lines.First(l => l.Contains(moduleDisplayName));
            var nameLinePrefixIndex = nameLine.IndexOf(ElementPrefix, StringComparison.Ordinal);
            var name = nameLine.Substring(nameLinePrefixIndex + ElementPrefix.Length, nameLine.LastIndexOf(ElementPostfix, StringComparison.Ordinal) - (nameLinePrefixIndex + ElementPrefix.Length));

            var authorDisplayName = AttributeHelper.GetPropertyAttributeValue<PsDefinitionHeader, string, DisplayNameAttribute, string>(pd => pd.Author, attr => attr.DisplayName, String.Empty);
            var authorLine = lines.First(l => l.Contains(authorDisplayName));
            var authorLineDelimiterIndex = authorLine.IndexOf(HeaderDelimiter, StringComparison.Ordinal);
            var author = authorLine.Substring(authorLineDelimiterIndex + HeaderDelimiter.Length);

            var dateDisplayName = AttributeHelper.GetPropertyAttributeValue<PsDefinitionHeader, DateTime, DisplayNameAttribute, string>(pd => pd.Date, attr => attr.DisplayName, String.Empty);
            var dateLine = lines.First(l => l.Contains(dateDisplayName));
            var dateLineDelimiterIndex = dateLine.IndexOf(HeaderDelimiter, StringComparison.Ordinal);
            var date = dateLine.Substring(dateLineDelimiterIndex + HeaderDelimiter.Length);

            return new PsDefinitionHeader
            {
                ModuleName = name,
                Author = author,
                Date = DateTime.Parse(date)
            };
        }

        public static Hashtable GetHashtable(PowerShell powershell, string path)
        {
            var script = $"Get-Content '{path}' | Out-String | Invoke-Expression";
            powershell.AddScript(script);
            if (!(powershell.Invoke().First().BaseObject is Hashtable hashtable))
            {
                throw new FileFormatException("Missing manifest hashtable data");
            }
            hashtable.Add("FilePath", path);
            return hashtable;
        }

        public static IEnumerable<Hashtable> GetDesktopHashtables(IEnumerable<string> desktopFilePaths)
        {
            using (var powershell = PowerShell.Create())
            {
                foreach (var path in desktopFilePaths)
                {
                    yield return GetHashtable(powershell, path);
                }
            }
        }

        public static PsDefinition CreateNetCoreDefinition(Hashtable desktopData)
        {
            var psData = new PsData();
            var desktopPsData = desktopData.GetValueAsHashtable("PrivateData").GetValueAsHashtable("PSData");
            if (desktopPsData.Any())
            {
                psData = new PsData
                {
                    Tags = desktopPsData.GetValueAsStringList("Tags"),
                    LicenseUri = new Uri(desktopPsData.GetValueAsString("LicenseUri")),
                    ProjectUri = new Uri(desktopPsData.GetValueAsString("ProjectUri")),
                    ReleaseNotes = String.Empty,
                    Prerelease = desktopPsData.ContainsKey("Prerelease") ? desktopPsData.GetValueAsString("Prerelease") : null
                };
            }

            var filename = Path.GetFileNameWithoutExtension(desktopData.GetValueAsString("FilePath"));
            var typesToProcess = desktopData.GetValueAsStringList("TypesToProcess");
            var formatsToProcess = desktopData.GetValueAsStringList("FormatsToProcess");
            return new PsDefinition
            {
                ManifestHeader = new PsDefinitionHeader { ModuleName = filename, Author = desktopData.GetValueAsString("Author") },
                ModuleVersion = NetCoreModuleVersion,
                CompatiblePsEditions = new List<string> { NetCoreCompatiblePsEdition },
                Author = desktopData.GetValueAsString("Author"),
                CompanyName = desktopData.GetValueAsString("CompanyName"),
                Copyright = desktopData.GetValueAsString("Copyright"),
                Description = $"[PowerShell .Net Core] {desktopData.GetValueAsString("Description")}",
                PowerShellVersion = NetCorePsVersion,
                RequiredModules = new List<ModuleReference> { new ModuleReference { ModuleName = "AzureRM.Profile.Netcore", ModuleVersion = NetCoreModuleVersion } },
                RequiredAssemblies = desktopData.GetValueAsStringList("RequiredAssemblies"),
                TypesToProcess = typesToProcess.Any() ? typesToProcess : null,
                FormatsToProcess = formatsToProcess.Any() ? formatsToProcess : null,
                NestedModules = desktopData.GetValueAsStringList("NestedModules").Select(m => new ModuleReference { ModuleName = m }).ToList(),
                AliasesToExport = desktopData.GetValueAsStringList("AliasesToExport"),
                CmdletsToExport = desktopData.GetValueAsStringList("CmdletsToExport"),
                VariablesToExport = null,
                PrivateData = new PrivateData { PsData = psData }
            };
        }
    }
}
