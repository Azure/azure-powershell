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
        public static string[] GetProfiles(CommandInvocationIntrinsics invokeCommand, bool listAvailable, params string[] moduleNames)
        {
            var command = "Get-Module";
            command += moduleNames != null && moduleNames.Any() ? $" -Name {String.Join(", ", moduleNames.Select(mn => $"'{mn}'"))}" : String.Empty;
            command += listAvailable ? " -ListAvailable" : String.Empty;

            var profiles = new string[] { };
            var modules = listAvailable ? Pwsh.Create().AddScript(command).Invoke<PSObject>() : invokeCommand.NewScriptBlock(command).Invoke();
            if (modules != null && modules.Any())
            {
                profiles = modules.SelectMany(GetProfiles).Distinct().ToArray();
            }

            return profiles;
        }

        private static string[] GetProfiles(PSObject module)
        {
            var profiles = new string[] { };
            var moduleInfo = module?.BaseObject as PSModuleInfo;
            var moduleProfileInfo = ((moduleInfo?.PrivateData as Hashtable)?["PSData"] as Hashtable)?["Profiles"];
            var moduleProfiles = moduleProfileInfo as object[] ?? (moduleProfileInfo != null ? new[] { moduleProfileInfo } : null);
            return moduleProfiles != null && moduleProfiles.Any() ? moduleProfiles.Cast<string>().ToArray() : profiles;
        }
    }
}