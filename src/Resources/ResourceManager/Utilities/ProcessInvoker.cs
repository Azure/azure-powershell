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

namespace Microsoft.Azure.Commands.ResourceManager.Cmdlets.Utilities
{
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Management.Automation;
    using System.Text;

    public class ProcessOutput
    {
        public string Stdout { get; set; }

        public string Stderr { get; set; }

        public int ExitCode { get; set; }
    }

    public class ProcessInput
    {
        public string Executable { get; set; }

        public string Arguments { get; set; }

        public Dictionary<string, string> EnvVars { get; set; }
    }

    public interface IProcessInvoker
    {
        bool CheckExecutableExists(string executable);

        ProcessOutput Invoke(ProcessInput input);
    }

    public class ProcessInvoker : IProcessInvoker
    {
        private static IProcessInvoker Instance = null;

        /// <summary>
        /// This hook can be used in the future for the test framework to provide a mock IProcessInvoker instance,
        /// in order to support record/replay for binaries.
        /// </summary>
        /// <param name="instance">The process invoker instance</param>
        public static void InitializeWithMock(IProcessInvoker instance)
            => Instance = instance;

        public static IProcessInvoker Create()
            => Instance ?? new ProcessInvoker();

        public bool CheckExecutableExists(string executable)
        {
            using (var powerShell = PowerShell.Create())
            {
                powerShell.AddScript($"Get-Command {executable}");
                powerShell.Invoke();
                powerShell.AddScript("$?");
                var result = powerShell.Invoke();
                // Cache result
                bool.TryParse(result[0].ToString(), out var executableExists);

                return executableExists;
            }
        }

        public ProcessOutput Invoke(ProcessInput input)
        {
            var proc = new Process
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = input.Executable,
                    Arguments = input.Arguments,
                    UseShellExecute = false,
                    RedirectStandardOutput = true,
                    RedirectStandardError = true,
                    StandardOutputEncoding = Encoding.UTF8,
                    StandardErrorEncoding = Encoding.UTF8,
                    CreateNoWindow = true,
                }
            };

            if (input.EnvVars != null)
            {
                foreach (var kvp in input.EnvVars)
                {
                    proc.StartInfo.Environment[kvp.Key] = kvp.Value;
                }
            }

            var stderr = new StringBuilder();
            proc.ErrorDataReceived += (sender, e) =>  stderr.AppendLine(e.Data);
            proc.Start();
    
            // To avoid deadlocks, use an asynchronous read operation on at least one of the streams.  
            proc.BeginErrorReadLine();
            var stdout = proc.StandardOutput.ReadToEnd();  
            proc.WaitForExit();
    
            return new ProcessOutput {
                Stdout = stdout,
                Stderr = stderr.ToString(),
                ExitCode = proc.ExitCode
            };
        }
    }
}
