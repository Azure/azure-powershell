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

using Microsoft.Azure.Commands.Common;
using Microsoft.Azure.Commands.Common.Authentication.Abstractions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Management.Automation;
using System.Reflection;
using System.Text;
using System.Threading;

namespace Microsoft.WindowsAzure.Commands.Utilities.Common
{
    public static class CmdletExtensions
    {
        /// <summary>
        /// Execute this cmdlet in the background and return a job that tracks the results
        /// </summary>
        /// <typeparam name="T">The cmdlet type</typeparam>
        /// <param name="cmdlet">The cmdlet to execute</param>
        /// <param name="jobName">The name of the job</param>
        /// <returns>The job tracking cmdlet execution</returns>
        public static Job ExecuteAsJob<T>(this T cmdlet, string jobName) where T : AzurePSCmdlet
        {
            if (cmdlet == null)
            {
                throw new ArgumentNullException(nameof(cmdlet));
            }

            return ExecuteAsJob(cmdlet, jobName, cmd => cmd.ExecuteCmdlet());
        }

        /// <summary>
        /// Execute this cmdlet in the background and return a job that tracks the results
        /// </summary>
        /// <typeparam name="T">The cmdlet type</typeparam>
        /// <param name="cmdlet">The cmdlet to execute</param>
        /// <param name="jobName">The name of the job</param>
        /// <param name="executor">The method to execute in the background job</param>
        /// <returns>The job tracking cmdlet execution</returns>
        public static Job ExecuteAsJob<T>(this T cmdlet, string jobName, Action<T> executor) where T : AzurePSCmdlet
        {
            if (cmdlet == null)
            {
                throw new ArgumentNullException(nameof(cmdlet));
            }

            if (executor == null)
            {
                throw new ArgumentNullException(nameof(executor));
            }

            var job = AzureLongRunningJob<T>.Create(cmdlet, cmdlet?.MyInvocation?.MyCommand?.Name, jobName, executor);
            cmdlet.SafeAddToJobRepository(job);
            ThreadPool.QueueUserWorkItem(job.RunJob, job);
            return job;
        }

        /// <summary>
        /// Determine if AsJob is present
        /// </summary>
        /// <typeparam name="T">The cmdlet type</typeparam>
        /// <param name="cmdlet">The cmdlet</param>
        /// <returns>True if the cmdlet shoudl run as a Job, otherwise false</returns>
        public static bool AsJobPresent<T>(this T cmdlet) where T : AzurePSCmdlet
        {
            if (cmdlet == null)
            {
                throw new ArgumentNullException(nameof(cmdlet));
            }

            return (cmdlet.MyInvocation?.BoundParameters != null
                && cmdlet.MyInvocation.BoundParameters.ContainsKey("AsJob"));
        }

        /// <summary>
        /// Execute the given cmdlet synchronously os as a job, based on input parameters
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="cmdlet"></param>
        public static void ExecuteSynchronouslyOrAsJob<T>(this T cmdlet) where T: AzurePSCmdlet
        {
            if (cmdlet == null)
            {
                throw new ArgumentNullException(nameof(cmdlet));
            }

            cmdlet.ExecuteSynchronouslyOrAsJob(c => c.ExecuteCmdlet());
        }

        /// <summary>
        /// Decide whether to execute this cmdlet as a job or synchronously, based on input parameters
        /// </summary>
        /// <typeparam name="T">The cmdlet type</typeparam>
        /// <param name="cmdlet">The cmdlet to execute</param>
        /// <param name="executor">The cmdlet method to execute</param>
        public static void ExecuteSynchronouslyOrAsJob<T>(this T cmdlet, Action<T> executor) where T : AzurePSCmdlet
        {
            if (cmdlet == null)
            {
                throw new ArgumentNullException(nameof(cmdlet));
            }

            if (executor == null)
            {
                throw new ArgumentNullException(nameof(executor));
            }

            if (cmdlet.AsJobPresent())
            {
                cmdlet.WriteObject(cmdlet.ExecuteAsJob(cmdlet.ImplementationBackgroundJobDescription, executor));
            }
            else
            {
                executor(cmdlet);
            }
        }

        /// <summary>
        /// Safely Attempt to copy a property value from source to target
        /// </summary>
        /// <typeparam name="T">The type fo the source and target objects</typeparam>
        /// <param name="property">The property to copy</param>
        /// <param name="source">The source object to copy from</param>
        /// <param name="target">The target object to copy to</param>
        public static void SafeCopyValue<T>(this PropertyInfo property, T source, T target)
        {
            if (property == null)
            {
                throw new ArgumentNullException(nameof(property));
            }

            try
            {
                property.SetValue(target, property.GetValue(source));
            }
            catch
            {
                // ignore get and set errors
            }
        }

        /// <summary>
        /// Safely Attempt to copy a field value from source to target
        /// </summary>
        /// <typeparam name="T">The type of the source and target objects</typeparam>
        /// <param name="field">The field to copy</param>
        /// <param name="source">The source object to copy from</param>
        /// <param name="target">The target object to copy to</param>
        public static void SafeCopyValue<T>(this FieldInfo field, T source, T target)
        {
            if (field == null)
            {
                throw new ArgumentNullException(nameof(field));
            }

            try
            {
                field.SetValue(target, field.GetValue(source));
            }
            catch
            {
                // ignore get and set errors
            }
        }

        /// <summary>
        /// Safely copy the selected parameter set from one cmdlet to another
        /// </summary>
        /// <typeparam name="T">The cmdlet type</typeparam>
        /// <param name="source">The cmdlet to copy the parameter set name from</param>
        /// <param name="target">The cmdlet to copy to</param>
        public static void SafeCopyParameterSet<T>(this T source, T target) where T : AzurePSCmdlet
        {
            if (source != null && target != null)
            {
                if (!string.IsNullOrWhiteSpace(source.ParameterSetName))
                {
                    try
                    {
                        target.SetParameterSet(source.ParameterSetName);
                    }
                    catch
                    {

                    }
                }
            }
        }

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
            PropertyInfo dynField = (typeof(AzurePSCmdlet)).GetProperty("_dataCollectionProfile", BindingFlags.NonPublic | BindingFlags.Instance);
            dynField.SetValue(cmdlt, new AzurePSDataCollectionProfile(true));
        }

        public static void DisableDataCollection(this AzurePSCmdlet cmdlt)
        {
            PropertyInfo dynField = (typeof(AzurePSCmdlet)).GetProperty("_dataCollectionProfile", BindingFlags.NonPublic | BindingFlags.Instance);
            dynField.SetValue(cmdlt, new AzurePSDataCollectionProfile(false));
        }

        #endregion


        static void SafeAddToJobRepository(this AzurePSCmdlet cmdlet, Job job)
        {
            try
            {
                cmdlet.JobRepository.Add(job);
            }
            catch
            {
                // ignore errors in adding the job to the repository
            }
        }

    }
}
