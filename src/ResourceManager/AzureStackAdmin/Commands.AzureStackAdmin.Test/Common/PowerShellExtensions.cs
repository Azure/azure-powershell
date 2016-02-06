namespace Microsoft.AzureStack.Commands.Admin.Test.Common
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Management.Automation;
    using System.Management.Automation.Runspaces;

    public static class PowerShellExtensions
    {
        private const string PowerShellEnvironmentFormat = "Set-Item env:{0} \"{1}\"";
        private const string PowerShellVariableFormat = "${0}={1}";
        private const string CredentialImportFormat = "Import-AzurePublishSettingsFile '{0}'";

        /// <summary>
        /// Gets a PowerShell variable from the current session and converts it back to it's original type.
        /// </summary>
        /// <typeparam name="T">The PowerShell object original type</typeparam>
        /// <param name="powerShell">The PowerShell instance</param>
        /// <param name="name">The variable name</param>
        /// <returns>The variable object</returns>
        public static T GetPowerShellVariable<T>(this PowerShell powerShell, string name)
        {
            object obj = powerShell.Runspace.SessionStateProxy.GetVariable(name);

            PSObject pso;
            if ((pso = obj as PSObject) != null)
            {
                return (T)pso.BaseObject;
            }
            else
            {
                return (T)obj;
            }
        }

        /// <summary>
        /// Gets a PowerShell enumerable collection from the current session and converts it back to it's original type.
        /// </summary>
        /// <typeparam name="T">The PowerShell object original type</typeparam>
        /// <param name="powershell">The PowerShell instance</param>
        /// <param name="name">The variable name</param>
        /// <returns>The collection in list</returns>
        public static List<T> GetPowerShellCollection<T>(this PowerShell powershell, string name)
        {
            List<T> result = new List<T>();

            object[] objects = (object[])powershell.Runspace.SessionStateProxy.GetVariable(name);

            foreach (object item in objects)
            {
                PSObject pso;
                if ((pso = item as PSObject) != null)
                {
                    result.Add((T)pso.BaseObject);
                }
                else
                {
                    result.Add((T)item);
                }
            }

            return result;
        }

        /// <summary>
        /// Sets a new PSVariable to the current scope.
        /// </summary>
        /// <param name="powershell">The PowerShell instance</param>
        /// <param name="name">The variable name</param>
        /// <param name="value">The variable value</param>
        public static void SetVariable(this PowerShell powershell, string name, object value)
        {
            powershell.Runspace.SessionStateProxy.SetVariable(name, value);
        }

        /// <summary>
        /// Logs a PowerShell exception thrown from PowerShell.Invoke, parsing the inner
        /// PowerShell error record if available
        /// </summary>
        /// <param name="powershell">The PowerShell instance</param>
        /// <param name="runtimeException">The exception to parse</param>
        public static void LogPowerShellException(this PowerShell powershell, Exception runtimeException)
        {
            Console.WriteLine("Caught Exception: {0}\n", runtimeException);
            Console.WriteLine("Message: {0}\n", runtimeException.Message);
            IContainsErrorRecord recordContainer = runtimeException as IContainsErrorRecord;
            if (recordContainer != null)
            {
                ErrorRecord record = recordContainer.ErrorRecord;
                Console.WriteLine("PowerShell Error Record: {0}\nException:{1}\nDetails:{2}\nScript Stack Trace: {3}\n: Target: {4}\n", record, record.Exception, record.ErrorDetails, record.InvocationInfo, record.TargetObject);
            }

            if (runtimeException.InnerException != null)
            {
                powershell.LogPowerShellException(runtimeException.InnerException);
            }
        }

        /// <summary>
        /// Log the PowerShell Streams from a PowerShell invocation
        /// </summary>
        /// <param name="powershell">The PowerShell instance to log</param>
        public static void LogPowerShellResults(this PowerShell powershell)
        {
            powershell.LogPowerShellResults(null);
        }

        /// <summary>
        /// Log the PowerShell Streams from a PowerShell invocation
        /// </summary>
        /// <param name="powershell">The PowerShell instance to log</param>
        /// <param name="output">The output stream records</param>
        public static void LogPowerShellResults(this PowerShell powershell, Collection<PSObject> output)
        {
            if (output != null)
            {
                LogPowerShellStream<PSObject>(output, "OUTPUT");
            }

            if (powershell.Commands != null && powershell.Commands.Commands != null &&
                powershell.Commands.Commands.Count > 0)
            {
                Console.WriteLine("================== COMMANDS =======================\n");
                foreach (Command command in powershell.Commands.Commands)
                {
                    Console.WriteLine("{0}\n", command.CommandText);
                }

                Console.WriteLine("===================================================\n");
            }

            LogPowerShellStream<DebugRecord>(powershell.Streams.Debug, "DEBUG");
            LogPowerShellStream<ErrorRecord>(powershell.Streams.Error, "ERROR");
            LogPowerShellStream<ProgressRecord>(powershell.Streams.Progress, "PROGRESS");
            LogPowerShellStream<VerboseRecord>(powershell.Streams.Verbose, "VERBOSE");
            LogPowerShellStream<WarningRecord>(powershell.Streams.Warning, "WARNING");
        }

        /// <summary>
        /// Add an environment variable to the PowerShell instance
        /// </summary>
        /// <param name="powerShell">The PowerShell instance to alter</param>
        /// <param name="variableKey">The variable name</param>
        /// <param name="variableValue">The variable value</param>
        public static void AddEnvironmentVariable(this PowerShell powerShell, string variableKey, string variableValue)
        {
            powerShell.AddScript(string.Format(PowerShellEnvironmentFormat, variableKey, variableValue));
        }

        /// <summary>
        /// Add an environment variable to the PowerShell instance
        /// </summary>
        /// <param name="powerShell">The PowerShell instance to alter</param>
        /// <param name="variableKey">The variable name</param>
        /// <param name="variableValue">The variable value</param>
        public static void AddPowerShellVariable(this PowerShell powerShell, string variableKey, string variableValue)
        {
            powerShell.AddScript(string.Format(PowerShellVariableFormat, variableKey, variableValue));
        }

        /// <summary>
        /// Import credentials into PowerShell
        /// </summary>
        /// <param name="powerShell">The PowerShell instance to alter</param>
        /// <param name="credentialPath">The fully qualified path top the credentials</param>
        public static void ImportCredentials(this PowerShell powerShell, string credentialPath)
        {
            powerShell.AddScript(string.Format(CredentialImportFormat, credentialPath));
        }

        /// <summary>
        /// Remove all credentials for the current user
        /// </summary>
        /// <param name="powerShell">The PowerShell instance to use for removing credentials</param>
        public static void RemoveCredentials(this PowerShell powerShell)
        {
            powerShell.AddScript("try {$sub = Get-AzureSubscription | Remove-AzureSubscription -Force} catch {}");
        }

        /// <summary>
        /// Log a single PowerShell stream, using the given name
        /// </summary>
        /// <typeparam name="T">The type of the internal data record (different for every stream)</typeparam>
        /// <param name="stream">The stream to log</param>
        /// <param name="name">The name of the stream to print in the log</param>
        private static void LogPowerShellStream<T>(ICollection<T> stream, string name)
        {
            if (stream != null && stream.Count > 0)
            {
                Console.WriteLine("---------------------------------------------------------------\n");
                Console.WriteLine("{0} STREAM\n", name);
                Console.WriteLine("---------------------------------------------------------------\n");
                foreach (T item in stream)
                {
                    Console.WriteLine("{0}\n", item);
                }

                Console.WriteLine("---------------------------------------------------------------\n");
                Console.WriteLine(string.Empty);
            }
        }
    }
}
