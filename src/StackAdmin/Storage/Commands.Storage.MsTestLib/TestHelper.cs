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
using System.Diagnostics;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;

namespace MS.Test.Common.MsTestLib
{
    public class TestHelper
    {
        // default time out for runcmd
        public const int RUNCMD_TIMEOUT_MS = 900000;

        public static int RunCmd(string cmd, string args)
        {
            return RunCmd(cmd, args, RUNCMD_TIMEOUT_MS);
        }

        public static int RunCmd(string cmd, string args, out string stdout, out string stderr)
        {
            return RunCmd(cmd, args, out stdout, out stderr, RUNCMD_TIMEOUT_MS);
        }

        public static int RunCmd(string cmd, string args, int timeout)
        {
            string stdout, stderr;
            return RunCmd(cmd, args, out stdout, out stderr, timeout);
        }

        public static int RunCmd(string cmd, string args, out string stdout, out string stderr, int timeout)
        {
            Test.Logger.Verbose("Running: {0} {1}", cmd, args);
            ProcessStartInfo psi = new ProcessStartInfo(cmd, args);
            psi.CreateNoWindow = true;
            psi.WindowStyle = ProcessWindowStyle.Hidden;
            psi.UseShellExecute = false;
            psi.RedirectStandardError = true;
            psi.RedirectStandardOutput = true;
            Process p = Process.Start(psi);
            // To avoid deadlock between Process.WaitForExit and Process output redirection buffer filled up, we need to async read output before calling Process.WaitForExit
            StringBuilder outputBuffer = new StringBuilder();
            p.OutputDataReceived += (sendingProcess, outLine) =>
            {
                if (!String.IsNullOrEmpty(outLine.Data))
                {
                    outputBuffer.Append(outLine.Data+"\n");
                }
            };
            StringBuilder errorBuffer = new StringBuilder();
            p.ErrorDataReceived += (sendingProcess, outLine) =>
            {
                if (!String.IsNullOrEmpty(outLine.Data))
                {
                    errorBuffer.Append(outLine.Data+"\n");
                }
            };
            p.BeginOutputReadLine();
            p.BeginErrorReadLine();
            p.WaitForExit(timeout);
            stdout = outputBuffer.ToString();
            stderr = errorBuffer.ToString();
            if (p.HasExited)
            {
                Test.Logger.Verbose("Stdout: {0}", stdout);
                if (!string.IsNullOrEmpty(stderr)
                    && !string.Equals(stdout, stderr, StringComparison.InvariantCultureIgnoreCase))
                    Test.Logger.Verbose("Stderr: {0}", stderr);
                return p.ExitCode;
            }
            else
            {
                Test.Logger.Verbose("--Command timed out!");
                p.Kill();
                Test.Logger.Verbose("Stdout: {0}", stdout);
                if (!string.IsNullOrEmpty(stderr)
                    && !string.Equals(stdout, stderr, StringComparison.InvariantCultureIgnoreCase))
                    Test.Logger.Verbose("Stderr: {0}", stderr);
                return int.MinValue;
            }
        }
        public delegate bool RunningCondition(object arg);
        /// <summary>
        /// run cmd and specify the running condition. If running condition is not met, process will be terminated.
        /// </summary>
        public static int RunCmd(string cmd, string args, out string stdout, out string stderr, RunningCondition rc, object rcArg)
        {
            Test.Logger.Verbose("Running: {0} {1}", cmd, args);
            ProcessStartInfo psi = new ProcessStartInfo(cmd, args);
            psi.CreateNoWindow = true;
            psi.WindowStyle = ProcessWindowStyle.Hidden;
            psi.UseShellExecute = false;
            psi.RedirectStandardError = true;
            psi.RedirectStandardOutput = true;
            Process p = Process.Start(psi);
            // To avoid deadlock between Process.WaitForExit and Process output redirection buffer filled up, we need to async read output before calling Process.WaitForExit
            StringBuilder outputBuffer = new StringBuilder();
            p.OutputDataReceived += (sendingProcess, outLine) =>
            {
                if (!String.IsNullOrEmpty(outLine.Data))
                {
                    outputBuffer.Append(outLine.Data + "\n");
                }
            };
            StringBuilder errorBuffer = new StringBuilder();
            p.ErrorDataReceived += (sendingProcess, outLine) =>
            {
                if (!String.IsNullOrEmpty(outLine.Data))
                {
                    errorBuffer.Append(outLine.Data + "\n");
                }
            };
            p.BeginOutputReadLine();
            p.BeginErrorReadLine();
            DateTime nowTime = DateTime.Now;
            DateTime timeOut = nowTime.AddMilliseconds(RUNCMD_TIMEOUT_MS);
            while (rc(rcArg))
            {
                if (p.HasExited)
                {
                    // process has existed
                    break;
                }
                else if (timeOut > DateTime.Now)
                {
                    //time out
                    break;
                }
                else
                {
                    //continue to wait
                    Thread.Sleep(100);
                }
            }
            stdout = outputBuffer.ToString();
            stderr = errorBuffer.ToString(); 
            if (p.HasExited)
            {
                Test.Logger.Verbose("Stdout: {0}", stdout);
                if (!string.IsNullOrEmpty(stderr)
                    && !string.Equals(stdout, stderr, StringComparison.InvariantCultureIgnoreCase))
                    Test.Logger.Verbose("Stderr: {0}", stderr);
                return p.ExitCode;
            }
            else
            {
                Test.Logger.Verbose("--Command timed out!");
                p.Kill();
                Test.Logger.Verbose("Stdout: {0}", stdout);
                if (!string.IsNullOrEmpty(stderr)
                    && !string.Equals(stdout, stderr, StringComparison.InvariantCultureIgnoreCase))
                    Test.Logger.Verbose("Stderr: {0}", stderr);
                return int.MinValue;
            }
        }
        public static bool StringMatch(string source, string pattern)
        {
                Regex r = new Regex(pattern);
                Match m = r.Match(source);
                return m.Success;
        }

    }
}
