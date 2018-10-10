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
using System.Management.Automation;
using System.Management.Automation.Runspaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Microsoft.WindowsAzure.Commands.ScenarioTest.Common
{
    public static class PowerShellExtensions
    {
        public static string PowerShellEnvironmentFormat = "Set-Item env:{0} \"{1}\"";
        public static string PowerShellVariableFormat = "${0}={1}";
        public static string CredentialImportFormat = "Import-AzurePublishSettingsFile '{0}'";

        /// <summary>
        /// Gets a powershell variable from the current session and converts it back to it's original type.
        /// </summary>
        /// <typeparam name="T">The powershell object original type</typeparam>
        /// <param name="powershell">The PowerShell instance</param>
        /// <param name="name">The variable name</param>
        /// <returns>The variable object</returns>
        public static T GetPowerShellVariable<T>(this System.Management.Automation.PowerShell powershell, string name)
        {
            object obj = powershell.Runspace.SessionStateProxy.GetVariable(name);

            if (obj is PSObject)
            {
                return (T)(obj as PSObject).BaseObject;
            }
            else
            {
                return (T)obj;
            }
        }

        /// <summary>
        /// Gets a powershell enumerable collection from the current session and converts it back to it's original type.
        /// </summary>
        /// <typeparam name="T">The powershell object original type</typeparam>
        /// <param name="powershell">The PowerShell instance</param>
        /// <param name="name">The variable name</param>
        /// <returns>The collection in list</returns>
        public static List<T> GetPowerShellCollection<T>(this System.Management.Automation.PowerShell powershell, string name)
        {
            List<T> result = new List<T>();

            try
            {
                object[] objects = (object[])powershell.Runspace.SessionStateProxy.GetVariable(name);

                foreach (object item in objects)
                {
                    if (item is PSObject)
                    {
                        result.Add((T)(item as PSObject).BaseObject);
                    }
                    else
                    {
                        result.Add((T)item);
                    }
                }
            }
            catch (Exception) { /* Do nothing */ }

            return result;
        }

        /// <summary>
        /// Sets a new PSVariable to the current scope.
        /// </summary>
        /// <param name="powershell">The PowerShell instance</param>
        /// <param name="name">The variable name</param>
        /// <param name="value">The variable value</param>
        public static void SetVariable(this System.Management.Automation.PowerShell powershell, string name, object value)
        {
            powershell.Runspace.SessionStateProxy.SetVariable(name, value);
        }

        /// <summary>
        /// Logs a PowerShell exception thrown from PowerShell.Invoke, parsing the inner 
        /// PowerShell error record if available
        /// </summary>
        /// <param name="runtimeException">The exception to parse</param>
        public static void LogPowerShellException(this System.Management.Automation.PowerShell powershell, Exception runtimeException, TestContext context)
        {
            context.WriteLine("Caught Exception: {0}\n", runtimeException);
            context.WriteLine("Message: {0}\n", runtimeException.Message);
            IContainsErrorRecord recordContainer = runtimeException as IContainsErrorRecord;
            if (recordContainer != null)
            {
                ErrorRecord record = recordContainer.ErrorRecord;
                context.WriteLine("PowerShell Error Record: {0}\nException:{1}\nDetails:{2}\nScript Stack Trace: {3}\n: Target: {4}\n", record, record.Exception, record.ErrorDetails, record.ScriptStackTrace, record.TargetObject);
            }

            if (runtimeException.InnerException != null)
            {
                powershell.LogPowerShellException(runtimeException.InnerException, context);
            }
        }

        /// <summary>
        /// Log the PowerShell Streams from a PowerShell invocation
        /// </summary>
        /// <param name="powershell">The PowerShell instance to log</param>
        public static void LogPowerShellResults(this System.Management.Automation.PowerShell powershell, TestContext context)
        {
            powershell.LogPowerShellResults(null, context);
        }

        /// <summary>
        /// Log the PowerShell Streams from a PowerShell invocation
        /// </summary>
        /// <param name="powershell">The PowerShell instance to log</param>
        public static void LogPowerShellResults(this System.Management.Automation.PowerShell powershell, Collection<PSObject> output, TestContext context)
        {
            if (output != null)
            {
                LogPowerShellStream<PSObject>(output, "OUTPUT", context);
            }
            if (powershell.Commands != null && powershell.Commands.Commands != null && 
                powershell.Commands.Commands.Count > 0)
            {
                context.WriteLine("================== COMMANDS =======================\n");
                foreach (Command command in powershell.Commands.Commands)
                {
                    context.WriteLine("{0}\n", command.CommandText);
                }

                context.WriteLine("===================================================\n");
            }

            LogPowerShellStream<DebugRecord>(powershell.Streams.Debug, "DEBUG", context);
            LogPowerShellStream<ErrorRecord>(powershell.Streams.Error, "ERROR", context);
            LogPowerShellStream<ProgressRecord>(powershell.Streams.Progress, "PROGRESS", context);
            LogPowerShellStream<VerboseRecord>(powershell.Streams.Verbose, "VERBOSE", context);
            LogPowerShellStream<WarningRecord>(powershell.Streams.Warning, "WARNING", context);
        }

        /// <summary>
        /// Add an environment variable to the PowerShell instance
        /// </summary>
        /// <param name="powerShell">The powershell instance to alter</param>
        /// <param name="variableKey">The variable name</param>
        /// <param name="variableValue">The variable value</param>
        public static void AddEnvironmentVariable(this System.Management.Automation.PowerShell powerShell, string variableKey, string variableValue)
        {
            powerShell.AddScript(string.Format(PowerShellEnvironmentFormat, variableKey, variableValue));
        }

        /// <summary>
        /// Add an environment variable to the PowerShell instance
        /// </summary>
        /// <param name="powerShell">The powershell instance to alter</param>
        /// <param name="variableKey">The variable name</param>
        /// <param name="variableValue">The variable value</param>
        public static void AddPowerShellVariable(this System.Management.Automation.PowerShell powerShell, string variableKey, string variableValue)
        {
            powerShell.AddScript(string.Format(PowerShellVariableFormat, variableKey, variableValue));
        }
        /// <summary>
        /// Import credentials into PowerShell
        /// </summary>
        /// <param name="powerShell">The PowerShell instance to alter</param>
        /// <param name="credentialPath">The fully qualified path top the credentials</param>
        public static void ImportCredentials(this System.Management.Automation.PowerShell powerShell, string credentialPath)
        {
            powerShell.AddScript(string.Format(CredentialImportFormat, credentialPath));
        }

        /// <summary>
        /// Remove all credentials for the current user
        /// </summary>
        /// <param name="powerShell">The PowerShell instance to use for removing credentials</param>
        public static void RemoveCredentials(this System.Management.Automation.PowerShell powerShell)
        {
            powerShell.AddScript("try {$sub = Get-AzureSubscription | Remove-AzureSubscription -Force} catch {}");
        }

        /// <summary>
        /// Log a single PowerShell stream, using the given name
        /// </summary>
        /// <typeparam name="T">The type of the internal data record (different for every stream)</typeparam>
        /// <param name="stream">The stream to log</param>
        /// <param name="name">The name of the stream to print in the log</param>
        private static void LogPowerShellStream<T>(ICollection<T> stream, string name, TestContext context)
        {
            if (stream != null && stream.Count > 0)
            {

                context.WriteLine("---------------------------------------------------------------\n");
                context.WriteLine("{0} STREAM\n", name);
                context.WriteLine("---------------------------------------------------------------\n");
                foreach (T item in stream)
                {
                    context.WriteLine("{0}\n", item.ToString());
                }
                context.WriteLine("---------------------------------------------------------------\n");
                context.WriteLine("");
            }
        }
    }
}
