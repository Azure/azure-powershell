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
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Castle.DynamicProxy.Generators.Emitters;

namespace Microsoft.Azure.Commands.Examples.Test
{
    public class ProcessHelper : IDisposable
    {
        /// <summary>
        /// The process running the service.
        /// </summary>

        string _shellProcessName = "bash.exe";

        string _arguments;
        string _directory;
        Dictionary<string, string> _environment = new Dictionary<string, string>();
        Process _process;

        public IDictionary<string, string> EnvironmentVariables
        {
            get { return _environment; }
        }

        public string ShellProcessName
        {
            get { return _shellProcessName; }
            set { _shellProcessName = value; }
        }

        public ProcessHelper(string directory, params string[] arguments)
        {
            _directory = directory;
            if (arguments != null && arguments.Length > 0)
            {
                _arguments = string.Join(" ", arguments);
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing && _process != null && !_process.HasExited)
            {
                EndProcess(_process);
                _process = null;
            }
        }


        public static string GetPathToExecutable(string executableName)
        {
            var paths = Environment.GetEnvironmentVariable("PATH");
            foreach (var path in paths.Split(new[] { Path.PathSeparator }, StringSplitOptions.RemoveEmptyEntries))
            {
                var fullPath = Path.Combine(path, Path.GetFileName(executableName));
                if (File.Exists(fullPath))
                {
                    return fullPath;
                }

                var ext = Path.GetExtension(executableName);
                var exec = (ext == ".cmd" || ext == ".exe") ? Path.GetFileNameWithoutExtension(executableName) : executableName;
                fullPath = Path.Combine(path, exec);
                if (File.Exists(fullPath))
                {
                    return fullPath;
                }
            }

            return null;
        }

        public void StartAndWaitForExist()
        {
            StartAndWaitForExit(TimeSpan.FromMinutes(30));
        }
        public int StartAndWaitForExit(TimeSpan timeout)
        {
            var shellPath = GetPathToExecutable(_shellProcessName);
            if (shellPath == null)
            {
                throw new InvalidOperationException($"Could not find path to '{_shellProcessName}'");
            }

            _process = StartProcess(shellPath, _arguments, _directory);
            if (_process.WaitForExit((int) timeout.TotalMilliseconds))
            {
                return _process.ExitCode;
            }

            try
            {
                EndProcess(_process);
            }
            finally 
            {
                throw new TimeoutException($"Process using executable with path '{shellPath}' timed out");
            }

        }

        /// <summary>
        /// Run the given command with arguments. Return the result in standard output.
        /// </summary>
        /// <param name="path">The path to the command to execute.</param>
        /// <param name="arguments">The arguments to pass to the command.</param>
        /// <param name="workingDirectory">The working directory for the process being launched.</param>
        /// <returns>The process</returns>
        private Process StartProcess(
            string path,
            string arguments,
            string workingDirectory)
        {
            var process = new Process();
            var startInfo = process.StartInfo;
            startInfo.CreateNoWindow = false;
            startInfo.RedirectStandardOutput = true;
            startInfo.RedirectStandardError = true;
            startInfo.WorkingDirectory = workingDirectory;
            startInfo.UseShellExecute = false;
            startInfo.FileName = path;
            startInfo.Arguments = arguments;
            SetEnvironmentVariables(startInfo);
            process.OutputDataReceived += ProcessOutput;
            process.ErrorDataReceived += ProcessError;
            process.Start();
            process.BeginOutputReadLine();
            return process;
        }

        private void SetEnvironmentVariables(ProcessStartInfo startInfo)
        {
            foreach (var key in _environment.Keys)
            {
                startInfo.Environment[key] = _environment[key];
            }
        }

        private void ProcessError(object sender, DataReceivedEventArgs e)
        {
            var formatted = $"ERROR: {e.Data}";
            Trace.WriteLine(formatted);
            Debug.WriteLine(formatted);
        }

        private void ProcessOutput(object sender, DataReceivedEventArgs e)
        {
            Trace.WriteLine(e.Data);
            Debug.WriteLine(e.Data);
        }

        private static void EndProcess(Process process)
        {
            process.Kill();
            process.WaitForExit(2000);
            process.Dispose();
        }
    }
}
