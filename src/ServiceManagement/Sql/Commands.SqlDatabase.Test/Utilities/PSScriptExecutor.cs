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

namespace Microsoft.WindowsAzure.Commands.SqlDatabase.Test.Utilities
{
    /// <summary>
    /// Helper class that executes a given powershell script
    /// </summary>
    public class PSScriptExecutor
    {
        private static string lastOutputLine = "FAIL";

        /// <summary>
        /// Executes the script given by the scriptFileName
        /// </summary>
        /// <param name="scriptFileName">Powershell script file that needs to be executed.</param>
        /// <returns>true, if the last line of the script returns PASS. Otherwise false</returns>
        public static bool ExecuteScript(string scriptFileName)
        {
            return PSScriptExecutor.ExecuteScript(scriptFileName, string.Empty);
        }

        /// <summary>
        /// Executes the script given by the scriptFileName
        /// </summary>
        /// <param name="scriptFileName">Powershell script file that needs to be executed.</param>
        /// <param name="argument">Arguments for the script file.</param>
        /// <returns>true, if the last line of the script returns PASS. Otherwise false</returns>
        public static bool ExecuteScript(string scriptFileName, string argument)
        {
            return PSScriptExecutor.ExecuteScript(scriptFileName, argument, TimeSpan.FromMinutes(2));
        }

        /// <summary>
        /// Executes the script given by the scriptFileName
        /// </summary>
        /// <param name="scriptFileName">Powershell script file that needs to be executed.</param>
        /// <param name="argument">Arguments for the script file.</param>
        /// <param name="timeout"> Timeout for script execution.</param>
        /// <returns>true, if the last line of the script returns PASS. Otherwise false</returns>
        public static bool ExecuteScript(string scriptFileName, string argument, TimeSpan timeout)
        {
            lastOutputLine = "FAIL"; // reset the previous result
            
            Process process = new Process();
            process.StartInfo.FileName = "powershell.exe";
            process.StartInfo.Arguments = string.Format(" -File {0} {1}", scriptFileName, argument);
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.CreateNoWindow = true;
            process.StartInfo.RedirectStandardOutput = true;
            process.StartInfo.RedirectStandardError = true;

            process.OutputDataReceived += new DataReceivedEventHandler(OutputHandler);
            process.ErrorDataReceived += new DataReceivedEventHandler(ErrorHandler);
            process.Start();
            process.BeginOutputReadLine();
            process.BeginErrorReadLine();
            process.WaitForExit((int)timeout.TotalMilliseconds);

            return (lastOutputLine.ToUpper() == "PASS");
        }

        private static void ErrorHandler(object sendingProcess, DataReceivedEventArgs outLine)
        {
            if (outLine.Data != null)
            {
                Console.WriteLine("Error:" + outLine.Data);
            }
        }

        private static void OutputHandler(object sendingProcess, DataReceivedEventArgs outLine)
        {
            if (outLine.Data != null)
            {
                Console.WriteLine(outLine.Data);

                // Sometime the logging will have blank lines too.
                // Save only the non empty line to validate whether the script execution is success or not
                if (!string.IsNullOrEmpty(outLine.Data))
                {
                    lastOutputLine = outLine.Data;
                }
            }
        }
    }
}
