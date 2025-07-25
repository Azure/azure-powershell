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

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Management.Automation;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;

using Tools.Common.Models;

namespace Tools.Common.Loaders
{
    public class MetadataLoader
    {
        private static string _rootPath = Path.GetFullPath(Path.Combine(Assembly.GetExecutingAssembly().Location, "..", "..", ".."));

        public static ModuleMetadata GetModuleMetadata(string moduleName)
        {
            // bez: notice that this search way always find artifacts/Debug/{moduleName}/psd1 first, which may cause some issues
            // to work around this issue, clear Debug folder if we are intended to bump version for Release
            string modulePsd1Path = Directory.GetFiles(Path.Combine(_rootPath, "artifacts"), $"{moduleName}.psd1", SearchOption.AllDirectories)[0];
            if (modulePsd1Path == null)
            {
                Console.Error.WriteLine($"Cannot find {moduleName}.psd1 in {Path.Combine(_rootPath, "artifacts")}!");
            }
            return GetModuleMetadata(moduleName, modulePsd1Path);
        }

        private static ModuleMetadata GetModuleMetadata(string moduleName, string modulePsd1Path)
        {
            using (var powershell = PowerShell.Create(RunspaceMode.NewRunspace))
            {
                if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                {
                    powershell.AddScript("Set-ExecutionPolicy Unrestricted -Scope Process -ErrorAction Ignore");
                }
                powershell.AddScript("$error.clear()");
                powershell.AddScript($"Write-Debug \"current directory: { Assembly.GetExecutingAssembly().Location}\"");
                string repoToolsPath = Path.Combine(_rootPath, "tools");
                powershell.AddScript($"cd {repoToolsPath}\\ModuleMetadata");
                powershell.AddScript($"Import-Module {repoToolsPath}\\ModuleMetadata\\GetModuleMetadata.psm1");
                string accountsPsd1Path = Directory.GetFiles(Path.Combine(_rootPath, "artifacts"), "Az.Accounts.psd1", SearchOption.AllDirectories)[0];
                if (accountsPsd1Path == null)
                {
                    Console.Error.WriteLine($"Cannot find Az.Accounts.psd1 in {Path.Combine(_rootPath, "artifacts", "Accounts")}!");
                }
                powershell.AddScript($"Import-Module {accountsPsd1Path}");
                powershell.AddScript($"(Get-ModuleMetadata -Psd1Path {modulePsd1Path} -ModuleName {moduleName}).ToJsonString()");

                Collection<PSObject> output = powershell.Invoke();
                if (powershell.HadErrors)
                {
                    Console.WriteLine("================================");
                    for (var index = 0; index < powershell.Streams.Error.Count; ++index)
                    {
                        Console.WriteLine(powershell.Streams.Error.ElementAt(index).Exception);
                    }
                    Console.WriteLine("================================");
                }
                var jsonString = (string)output[0].BaseObject;
                return JsonConvert.DeserializeObject<ModuleMetadata>(jsonString);
            }
        }
    }
}
