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
using System.IO;
using System.Text;
using System.Threading;
using Microsoft.Azure.Commands.Common.ScenarioTest;
using Xunit;

namespace Microsoft.Azure.Commands.Common.ScenarioTest
{
    public class ProcessHelper : IDisposable
    {
        /// <summary>
        /// The process running the service.
        /// </summary>

        string _executableName = "bash.exe";

        StringBuilder _processOutput = new StringBuilder();

        string _arguments;
        string _directory;
        Dictionary<string, string> _environment = new Dictionary<string, string>();
        Process _process;

        public IDictionary<string, string> EnvironmentVariables
        {
            get { return _environment; }
        }

        public string ExecutableName
        {
            get { return _executableName; }
            set { _executableName = value; }
        }

        public string Output { get { return _processOutput.ToString(); }}

        public ProcessHelper(string directory, string executableName, params string[] arguments)
        {
            _executableName = executableName;
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
            if (disposing && _process != null )
            {
                try
                {
                    EndProcess();
                }
                catch
                {
                }

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

                var exec = Path.GetFileNameWithoutExtension(executableName);
                var fullPathNoExe = Path.Combine(path, exec);
                if (File.Exists(fullPath))
                {
                    return fullPath;
                }

                if (File.Exists(fullPathNoExe))
                {
                    return fullPathNoExe;
                }
            }

            return null;
        }

        public int StartAndWaitForExit()
        {
            return StartAndWaitForExit(TimeSpan.FromMinutes(60));
        }

        public int StartAndWaitForExit(TimeSpan timeout)
        {
            var shellPath = GetPathToExecutable(_executableName);
            if (shellPath == null)
            {
                throw new InvalidOperationException($"Could not find path to '{_executableName}'");
            }

            _process = StartProcess(shellPath, _arguments, _directory);
            if (_process.WaitForExit((int) timeout.TotalMilliseconds))
            {
                return _process.ExitCode;
            }

            throw new TimeoutException($"Process using executable with path '{shellPath}' timed out");
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
            process.BeginErrorReadLine();
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
            Logger.Instance.WriteError(e.Data);
        }

        private void ProcessOutput(object sender, DataReceivedEventArgs e)
        {
            Logger.Instance.WriteMessage(e.Data);
            _processOutput.Append(e.Data);
        }

        private void EndProcess()
        {
            _process.CancelOutputRead();
            _process.CancelErrorRead();
            _process.WaitForExit(2000);
            _process.Dispose();
        }
    }
}
