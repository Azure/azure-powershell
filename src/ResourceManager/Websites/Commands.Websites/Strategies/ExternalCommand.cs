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

using Microsoft.Azure.Commands.WebApps.Properties;
using System;
using System.Diagnostics;
using System.IO;
using System.Management.Automation;
using System.Threading.Tasks;

namespace Microsoft.Azure.Commands.WebApps.Strategies
{
    /// <summary>
    /// interface representing a command
    /// </summary>
    public abstract class ExternalCommand
    {

        public ExternalCommand(PathIntrinsics pathIntrinsics, string commandName, string workingDirectory = null)
        {
            PathInfo = pathIntrinsics;
            Name = commandName;
            WorkingDirectory = PathInfo.CurrentFileSystemLocation.Path;
            if (workingDirectory != null)
            {
                WorkingDirectory = PathInfo.GetUnresolvedProviderPathFromPSPath(workingDirectory);
                if (!Directory.Exists(WorkingDirectory))
                {
                    throw new ArgumentOutOfRangeException(nameof(workingDirectory), string.Format(Microsoft.Azure.Commands.WebApps.Properties.Resources.GitDirectoryDoesNotExist, workingDirectory));
                }
            }
        }

        public string Name { get; protected set; }

        protected PathIntrinsics PathInfo { get; set; }

        protected string WorkingDirectory { get; set; }

        protected virtual ProcessStartInfo GetStartInfo(string arguments)
        {
            return new ProcessStartInfo
            {
                FileName = Name,
                UseShellExecute = false,
                RedirectStandardError = true,
                RedirectStandardOutput = true,
                CreateNoWindow = true,
                WorkingDirectory = WorkingDirectory,
                Arguments = arguments
            };
        }

        protected virtual Process GetProcess(string arguments)
        {
            var process = new Process();
            process.StartInfo = GetStartInfo(arguments);
            process.EnableRaisingEvents = true;
            return process;
        }

        public virtual Task<bool> CheckExistence(string command = null)
        {
            var check = GetProcess(command);
            var completer= new TaskCompletionSource<bool>();
            check.Exited += (state, sender) => completer.TrySetResult(check.ExitCode == 0);
            check.Start();
            return completer.Task;
        }

        public Task<string> Execute(string parameters)
        {
            var check = GetProcess(parameters);
            var completer = new TaskCompletionSource<string>();
            check.Exited += (state, sender) => completer.TrySetResult(check.StandardOutput.ReadToEnd());
            check.Start();
            return completer.Task;
        }

        public abstract string InstallationInstructions { get; }
    }
}
