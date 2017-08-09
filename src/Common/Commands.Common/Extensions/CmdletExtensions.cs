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

using Microsoft.WindowsAzure.Commands.Common;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Management.Automation;
using System.Management.Automation.Runspaces;
using System.Reflection;
using System.Text;

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

        /// <summary>
        /// Execute the given cmdlet in powershell usign the given pipeline parameters.  
        /// </summary>
        /// <typeparam name="T">The output type for the cmdlet</typeparam>
        /// <param name="cmdlet">The cmdlet to execute</param>
        /// <param name="name">The name of the cmdlet</param>
        /// <param name="cmdletParameters">The parameters to pass to the cmdlet on the pipeline</param>
        /// <returns>The output of executing the cmdlet</returns>
        public static List<T> ExecuteCmdletInPipeline<T>(this PSCmdlet cmdlet, string name, params object[] cmdletParameters)
        {
            List<T> output = new List<T>();
            using (System.Management.Automation.PowerShell powershell = System.Management.Automation.PowerShell.Create(RunspaceMode.NewRunspace))
            {
                var info = new CmdletInfo(name, cmdlet.GetType());
                Collection<T> result = powershell.AddCommand(info).Invoke<T>(cmdletParameters);
                if (powershell.Streams.Error != null && powershell.Streams.Error.Count > 0)
                {
                    StringBuilder details = new StringBuilder();
                    powershell.Streams.Error.ForEach(e => details.AppendFormat("Error: {0}\n", e.ToString()));
                    throw new InvalidOperationException(string.Format("Errors while running cmdlet:\n {0}", details.ToString()));
                }

                if (result != null && result.Count > 0)
                {
                    result.ForEach(output.Add);
                }
            }

            return output;
        }

        /// <summary>
        /// Execute the given cmdlet in powershell with the given parameters after injecting the given exception.  It is expected that the cmdlet has a runtime that can be used for receiving output
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="cmdlet">The cmdlet to execute</param>
        /// <param name="name">The name of the cmdlet</param>
        /// <param name="exception">The exception to inject into the error stream</param>
        /// <param name="cmdletParameters">The parameters to pass to the cmdlet on the pipeline</param>
        public static void ExecuteCmdletWithExceptionInPipeline<T>(this PSCmdlet cmdlet, string name, Exception exception, params KeyValuePair<string, object>[] cmdletParameters)
        {
            List<T> output = new List<T>();
            using (System.Management.Automation.PowerShell powershell = System.Management.Automation.PowerShell.Create(RunspaceMode.NewRunspace))
            {
                var info = new CmdletInfo(name, cmdlet.GetType());
                powershell.AddCommand("Write-Error");
                powershell.AddParameter("Exception", exception);
                powershell.Invoke();
                powershell.Commands.Clear();
                powershell.AddCommand(info);
                foreach (var pair in cmdletParameters)
                {
                    if (pair.Value == null)
                    {
                        powershell.AddParameter(pair.Key);
                    }
                    else
                    {
                        powershell.AddParameter(pair.Key, pair.Value);
                    }
                }
                Collection<T> result = powershell.Invoke<T>();
                powershell.Streams.Error.ForEach(cmdlet.WriteError);
                powershell.Streams.Debug.ForEach(d => cmdlet.WriteDebug(d.Message));
                powershell.Streams.Verbose.ForEach(v => cmdlet.WriteWarning(v.Message));
                powershell.Streams.Warning.ForEach(w => cmdlet.WriteWarning(w.Message));

                if (result != null && result.Count > 0)
                {
                    result.ForEach(r => cmdlet.WriteObject(r));
                }
            }
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

        public static void SetBoundParameters(this PSCmdlet cmdlt, IDictionary<string, object> parameters)
        {
            foreach (var pair in parameters)
            {
                cmdlt.MyInvocation.BoundParameters.Add(pair.Key, pair.Value);
            }
        }

        public static void InvokeEndProcessing(this PSCmdlet cmdlt)
        {
            MethodInfo dynMethod = (typeof(PSCmdlet)).GetMethod("EndProcessing", BindingFlags.NonPublic | BindingFlags.Instance);
            dynMethod.Invoke(cmdlt, null);
        }

        public static void EnableDataCollection(this AzurePSCmdlet cmdlt)
        {
            FieldInfo dynField = (typeof(AzurePSCmdlet)).GetField("_dataCollectionProfile", BindingFlags.NonPublic | BindingFlags.Static);
            dynField.SetValue(cmdlt, new AzurePSDataCollectionProfile(true));
        }

        public static void DisableDataCollection(this AzurePSCmdlet cmdlt)
        {
            FieldInfo dynField = (typeof(AzurePSCmdlet)).GetField("_dataCollectionProfile", BindingFlags.NonPublic | BindingFlags.Static);
            dynField.SetValue(cmdlt, new AzurePSDataCollectionProfile(false));
        }

        #endregion
    }
}
