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
using System.Linq;
using System.Reflection;
using System.Management.Automation;
using Tools.Common.Models;
using Tools.Common.Extensions;
using System.IO;

namespace Tools.Common.Loaders
{
    // TODO: Remove IfDef
#if NETSTANDARD
    public class CmdletLoader
#else
    public class CmdletLoader : MarshalByRefObject
#endif
    {
        public static ModuleMetadata ModuleMetadata;

        public ModuleMetadata GetModuleMetadata(string assemblyPath, List<string> commonOutputFolders)
        {
            AppDomain.CurrentDomain.AssemblyResolve += (sender, args) =>
            {
                foreach (var commonOutputFolder in commonOutputFolders)
                {
                    var assemblyName = args.Name.Substring(0, args.Name.IndexOf(","));
                    var dll = Directory.GetFiles(commonOutputFolder, "*.dll").FirstOrDefault(f => Path.GetFileNameWithoutExtension(f) == assemblyName);
                    if (dll == null)
                    {
                        continue;
                    }

                    return Assembly.LoadFrom(dll);
                }

                return null;
            };

            return GetModuleMetadata(assemblyPath);
        }

        static public ModuleMetadata GetModuleMetadata()
        {
            ModuleMetadata = new ModuleMetadata();

            return ModuleMetadata;
        }

        /// <summary>
        /// Get the ModuleMetadata from a cmdlet assembly.
        /// </summary>
        /// <param name="assmeblyPath">Path to the cmdlet assembly.</param>
        /// <returns>ModuleMetadata containing information about the cmdlets found in the given assembly.</returns>
        public ModuleMetadata GetModuleMetadata(string assemblyPath)
        {
            var powershell = PowerShell.Create();
            powershell.AddScript("import-module tools//GetModuleMedatada.ps1; Get-ModuleMetadataFromDotNet " + assemblyPath);
            var requiredModules = powershell.Invoke().ToList();
            Console.WriteLine(powershell.Streams.Error.ToString());

            return new ModuleMetadata();
        }
    }
}
