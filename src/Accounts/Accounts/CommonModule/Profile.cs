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
using Pwsh = System.Management.Automation.PowerShell;

namespace Microsoft.Azure.Commands.Common
{
    /// <summary>
    /// Methods for working with Azure profiles
    /// </summary>
    internal static class Profile
    {
        public static string[] GetProfiles(CommandInvocationIntrinsics invokeCommand, bool listAvailable = false, params string[] moduleNames) =>
            GetModules(invokeCommand, listAvailable, moduleNames).SelectMany(GetProfiles).Distinct().ToArray();

        internal static PSModuleInfo[] GetModules(CommandInvocationIntrinsics invokeCommand, bool listAvailable = false, params string[] moduleNames)
        {
            var command = "Get-Module";
            command += moduleNames != null && moduleNames.Any() ? $" -Name {CommaSeparatedQuotedList(moduleNames)}" : String.Empty;
            command += listAvailable ? " -ListAvailable" : String.Empty;
            var modules = listAvailable ? Pwsh.Create().AddScript(command).Invoke<PSObject>() : invokeCommand.NewScriptBlock(command).Invoke();
            return modules != null ? modules.Select(m => m?.BaseObject as PSModuleInfo).Where(m => m != null).ToArray() : new PSModuleInfo[] { };
        }

        internal static string[] GetProfiles(PSModuleInfo moduleInfo)
        {
            var moduleProfileInfo = ((moduleInfo?.PrivateData as Hashtable)?["PSData"] as Hashtable)?["Profiles"];
            var moduleProfiles = moduleProfileInfo as object[] ?? (moduleProfileInfo != null ? new[] { moduleProfileInfo } : null);
            return moduleProfiles != null && moduleProfiles.Any() ? moduleProfiles.Cast<string>().ToArray() : new string[] { };
        }

        internal static void ReloadModules(CommandInvocationIntrinsics invokeCommand, params PSModuleInfo[] moduleInfos)
        {
            var modulePaths = CommaSeparatedQuotedList(moduleInfos.Select(GetModulePath).ToArray());
            if (!String.IsNullOrEmpty(modulePaths))
            {
                var command = $"Import-Module -Name {modulePaths} -Force";
                invokeCommand.NewScriptBlock(command).Invoke();
            }
        }

        private static string CommaSeparatedQuotedList(params string[] items) => String.Join(", ", items.Where(i => !String.IsNullOrEmpty(i)).Select(i => $"'{i}'"));

        private static string GetModulePath(PSModuleInfo moduleInfo)
        {
            var scriptPsd1 = Path.Combine(moduleInfo.ModuleBase, $"{moduleInfo.Name}.psd1");
            return moduleInfo.ModuleType == ModuleType.Script && File.Exists(scriptPsd1) ? scriptPsd1 : moduleInfo.Path;
        }
    }
}