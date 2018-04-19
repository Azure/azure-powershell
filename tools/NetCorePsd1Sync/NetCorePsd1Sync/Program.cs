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
using System.IO;
using System.Linq;
using System.Management.Automation;
using NetCorePsd1Sync.Utility;
using static NetCorePsd1Sync.NetCoreDefinitionGenerator;

namespace NetCorePsd1Sync
{
    public static class Program
    {
        private const string Validate = "-v";
        private const string Create = "-c";

        private static readonly Dictionary<string, Action<string>> ModeMap = new Dictionary<string, Action<string>>
        {
            { Validate, ValidateDefinitionFiles },
            { Create, CreateDefinitionFiles }
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

        private static void ValidateDefinitionFiles(string rmPath)
        {
            var modulePaths = GetModulePaths(rmPath, true);
            var desktopFilePaths = GetDesktopFilePaths(modulePaths);
            var desktopHashtables = GetDesktopHashtables(desktopFilePaths);
            foreach (var desktopHashtable in desktopHashtables)
            {
                var netCorePath = ConvertDesktopToNetCorePath(desktopHashtable.GetValueAsString("FilePath"));
                var netCoreFileName = Path.GetFileNameWithoutExtension(netCorePath);

                var oldCmdletList = desktopHashtable.GetValueAsStringList("CmdletsToExport");
                var oldAliasesList = desktopHashtable.GetValueAsStringList("AliasesToExport");
                var oldFunctionsList = desktopHashtable.GetValueAsStringList("FunctionsToExport");
                if (!File.Exists(netCorePath) || !(oldCmdletList.Any() || oldAliasesList.Any() || oldFunctionsList.Any()))
                {
                    var priorColor = Console.ForegroundColor;
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine($"Skipping {netCoreFileName}");
                    Console.ForegroundColor = priorColor;
                    continue;
                }

                Console.WriteLine($"Validating {netCoreFileName}");
                Hashtable netCoreHashtable;
                using (var powershell = PowerShell.Create())
                {
                    netCoreHashtable = GetHashtable(powershell, netCorePath);
                }

                var newCmdletList = netCoreHashtable.GetValueAsStringList("CmdletsToExport");
                var newAliasesList = netCoreHashtable.GetValueAsStringList("AliasesToExport");
                var newFunctionsList = netCoreHashtable.GetValueAsStringList("FunctionsToExport");

                var missingCmdlets = oldCmdletList.Where(oc => !newCmdletList.Contains(oc)).ToList();
                var missingAliases = oldAliasesList.Where(oa => !newAliasesList.Contains(oa)).ToList();
                var missingFunctions = oldFunctionsList.Where(of => !newFunctionsList.Contains(of)).ToList();

                // ReSharper disable once InvertIf
                if (missingCmdlets.Any() || missingAliases.Any() || missingFunctions.Any())
                {
                    var priorColor = Console.ForegroundColor;
                    Console.ForegroundColor = ConsoleColor.Red;
                    if (missingCmdlets.Any())
                    {
                        Console.WriteLine($"Missing cmdlets: {String.Join(", ", missingCmdlets)} : {netCoreFileName}");
                    }
                    if (missingAliases.Any())
                    {
                        Console.WriteLine($"Missing aliases: {String.Join(", ", missingAliases)} : {netCoreFileName}");
                    }
                    if (missingFunctions.Any())
                    {
                        Console.WriteLine($"Missing functions: {String.Join(", ", missingFunctions)} : {netCoreFileName}");
                    }
                    Console.ForegroundColor = priorColor;
                    Environment.ExitCode = 1;
                }
            }
        }

        private static void CreateDefinitionFiles(string rmPath)
        {
            var modulePaths = GetModulePaths(rmPath);
            var desktopFilePaths = GetDesktopFilePaths(modulePaths);
            var desktopHashtables = GetDesktopHashtables(desktopFilePaths);
            foreach (var desktopHashtable in desktopHashtables)
            {
                var netCoreFilePath = ConvertDesktopToNetCorePath(desktopHashtable.GetValueAsString("FilePath"));
                Console.WriteLine($"Creating {netCoreFilePath}");
                var netCoreDefinition = CreateNetCoreDefinition(desktopHashtable);
                if (File.Exists(netCoreFilePath))
                {
                    using (var powershell = PowerShell.Create())
                    {
                        var netCoreHashtable = GetHashtable(powershell, netCoreFilePath);
                        netCoreDefinition = CreateNetCoreDefinition(netCoreHashtable);
                        var rootModule = netCoreHashtable.GetValueAsString("RootModule");
                        netCoreDefinition.RootModule = rootModule == String.Empty ? null : rootModule;
                        netCoreDefinition.Guid = new Guid(netCoreHashtable.GetValueAsString("GUID"));
                        netCoreDefinition.Description = netCoreHashtable.GetValueAsString("Description");
                        netCoreDefinition.RequiredModules = netCoreHashtable.GetValueAsArray("RequiredModules").Any() ? netCoreDefinition.RequiredModules : null;

                        var netCoreHeader = ReadDefinitionHeader(netCoreFilePath);
                        netCoreDefinition.ManifestHeader.ModuleName = Path.GetFileNameWithoutExtension(desktopHashtable.GetValueAsString("FilePath"));
                        netCoreDefinition.ManifestHeader.Date = netCoreHeader.Date;
                    }
                }
                File.WriteAllLines(netCoreFilePath, netCoreDefinition.ToDefinitionEntry());
            }
        }
    }
}
