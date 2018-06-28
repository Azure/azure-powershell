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

using System.Diagnostics;
using System.Security.Permissions;

namespace Microsoft.WindowsAzure.Commands.Utilities.Common
{
    public class ProcessHelper
    {
        public string StandardOutput { get; set; }
        public string StandardError { get; set; }
        public int ExitCode { get; set; }

        [PermissionSet(SecurityAction.LinkDemand, Name = "FullTrust")]
        public static void Start(string target)
        {
            Process.Start(target);
        }

        [PermissionSet(SecurityAction.LinkDemand, Name = "FullTrust")]
        public static int StartAndWaitForProcess(ProcessStartInfo processInfo, out string standardOutput, out string standardError)
        {
            processInfo.CreateNoWindow = true;
            processInfo.UseShellExecute = false;
            processInfo.RedirectStandardOutput = true;
            processInfo.RedirectStandardError = true;

            Process p = Process.Start(processInfo);
            p.WaitForExit();

            int exitCode = p.ExitCode;
            standardOutput = p.StandardOutput.ReadToEnd();
            standardError = p.StandardError.ReadToEnd();

            p.Close();
            return exitCode;
        }

        public virtual void StartAndWaitForProcess(string command, string arguments)
        {
            StandardOutput = string.Empty;
            StandardError = string.Empty;
            ProcessStartInfo startInfo = new ProcessStartInfo(command, arguments);
            string output, error;
            ExitCode = StartAndWaitForProcess(startInfo, out output, out error);
            StandardOutput = output;
            StandardError = error;
        }
    }
}
