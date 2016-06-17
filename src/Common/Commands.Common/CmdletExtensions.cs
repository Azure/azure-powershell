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
using System.Collections.ObjectModel;
using System.IO;
using System.Management.Automation;
using System.Reflection;

namespace Microsoft.WindowsAzure.Commands.Utilities.Common
{
    public static class CmdletExtensions
    {
        public static string AsAbsoluteLocation(this string realtivePath)
        {
            return Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, realtivePath));
        }

        public static string TryResolvePath(this PSCmdlet psCmdlet, string path)
        {
            try
            {
                return psCmdlet.ResolvePath(path);
            }
            catch
            {
                return path;
            }
        }

        public static string ResolvePath(this PSCmdlet psCmdlet, string path)
        {
            if (path == null)
            {
                return null;
            }

            if (psCmdlet.SessionState == null)
            {
                return path;
            }

            path = path.Trim('"', '\'', ' ');
            var result = psCmdlet.SessionState.Path.GetResolvedPSPathFromPSPath(path);
            string fullPath = string.Empty;

            if (result != null && result.Count > 0)
            {
                fullPath = result[0].ProviderPath;
            }

            return fullPath;
        }

        public static List<T> ExecuteScript<T>(this PSCmdlet cmdlet, string contents)
        {
            List<T> output = new List<T>();

            using (System.Management.Automation.PowerShell powershell = System.Management.Automation.PowerShell.Create(RunspaceMode.CurrentRunspace))
            {
                powershell.AddScript(contents);
                Collection<T> result = powershell.Invoke<T>();

                if (cmdlet.SessionState != null)
                {
                    powershell.Streams.Error.ForEach(e => cmdlet.WriteError(e));
                    powershell.Streams.Verbose.ForEach(r => cmdlet.WriteVerbose(r.Message));
                    powershell.Streams.Warning.ForEach(r => cmdlet.WriteWarning(r.Message));
                }

                if (result != null && result.Count > 0)
                {
                    output.AddRange(result);
                }
            }

            return output;
        }
        #region PowerShell Commands

        public static void RemoveModule(this PSCmdlet cmdlet, string moduleName)
        {
            string contents = string.Format("Remove-Module {0}", moduleName);
            ExecuteScript<object>(cmdlet, contents);
        }

        public static List<PSModuleInfo> GetLoadedModules(this PSCmdlet cmdlet)
        {
            return ExecuteScript<PSModuleInfo>(cmdlet, "Get-Module");
        }

        public static void ImportModule(this PSCmdlet cmdlet, string modulePath)
        {
            string contents = string.Format("Import-Module '{0}'", modulePath);
            ExecuteScript<object>(cmdlet, contents);
        }

        public static void RemoveAzureAliases(this PSCmdlet cmdlet)
        {
            string contents = "Get-Alias | where { $_.Description -eq 'AzureAlias' } | foreach { Remove-Item alias:\\$($_.Name) }";
            ExecuteScript<object>(cmdlet, contents);
        }

        public static void InvokeBeginProcessing(this PSCmdlet cmdlt)
        {
            MethodInfo dynMethod = (typeof(PSCmdlet)).GetMethod("BeginProcessing", BindingFlags.NonPublic | BindingFlags.Instance);
            dynMethod.Invoke(cmdlt, null);
        }

        public static void SetParameterSet(this PSCmdlet cmdlt, string value)
        {
            FieldInfo dynField = (typeof(Cmdlet)).GetField("_parameterSetName", BindingFlags.NonPublic | BindingFlags.Instance);
            dynField.SetValue(cmdlt, value);
        }

        public static void InvokeEndProcessing(this PSCmdlet cmdlt)
        {
            MethodInfo dynMethod = (typeof(PSCmdlet)).GetMethod("EndProcessing", BindingFlags.NonPublic | BindingFlags.Instance);
            dynMethod.Invoke(cmdlt, null);
        }

        #endregion
    }
}
