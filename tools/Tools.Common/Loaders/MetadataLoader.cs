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
        public static ModuleMetadata GetModuleMetadata(string moduleName)
        {
            using (var powershell = PowerShell.Create(RunspaceMode.NewRunspace))
            {
                if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                {
                    powershell.AddScript("Set-ExecutionPolicy Unrestricted -Scope Process -ErrorAction Ignore");
                }
                powershell.AddScript("$error.clear()");
                powershell.AddScript($"Write-Debug \"current directory: { AppDomain.CurrentDomain.BaseDirectory }\"");
                string rootPath = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..", ".."));
                string repoToolsPath = Path.Combine(rootPath, "tools");
                powershell.AddScript($"cd {repoToolsPath}\\ModuleMetadata");
                powershell.AddScript($"Import-Module {repoToolsPath}\\ModuleMetadata\\GetModuleMetadata.psm1");
                string accountsPsd1Path = Directory.GetFiles(Path.Combine(rootPath, "artifacts"), "Az.Accounts.psd1", SearchOption.AllDirectories)[0];
                if (accountsPsd1Path == null)
                {

                }
                powershell.AddScript($"Import-Module {accountsPsd1Path}");
                string modulePsd1Path = Directory.GetFiles(Path.Combine(rootPath, "artifacts"), $"{moduleName}.psd1", SearchOption.AllDirectories)[0];
                if (modulePsd1Path == null)
                {

                }
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
