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

using Microsoft.PowerShell;
using System;
using System.Linq;
using System.Management.Automation;
using System.Management.Automation.Runspaces;
using System.Runtime.InteropServices;

namespace Microsoft.Azure.PoerShell.Tools.AzPredictor.MockPSConsole
{
    using PowerShell = System.Management.Automation.PowerShell;

    /// <summary>
    /// The handle id for stdin, stdout, and stderr.
    /// </summary>
    enum StandardHandleId : uint
    {
        /// <summary>
        /// The id of stderr
        /// </summary>
        Error = unchecked((uint)-12),

        /// <summary>
        /// The id of stdout
        /// </summary>
        Output = unchecked((uint)-11),

        /// <summary>
        /// The id of stdin
        /// </summary>
        Input = unchecked((uint)-10),
    }

    class Program
    {
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
        public static extern bool GetConsoleMode(IntPtr hConsoleOutput, out uint dwMode);

        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
        public static extern bool SetConsoleMode(IntPtr hConsoleOutput, uint dwMode);

        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
        public static extern IntPtr GetStdHandle(uint handleId);

        static void CauseCrash(ConsoleKeyInfo? key = null, object arg = null)
        {
            throw new Exception("intentional crash for test purposes");
        }

        public const uint ENABLE_VIRTUAL_TERMINAL_PROCESSING = 0x04;
        public const uint ENABLE_VIRTUAL_TERMINAL_INPUT = 0x0200;

        [STAThread]
        static void Main(string[] args)
        {
            var handle = GetStdHandle((uint)StandardHandleId.Output);
            GetConsoleMode(handle, out var mode);
            var vtEnabled = SetConsoleMode(handle, mode | ENABLE_VIRTUAL_TERMINAL_PROCESSING);

            var iss = InitialSessionState.CreateDefault2();
            if (!args.Any())
            {
                args = new string[] { "../Az.Tools.Predictor/Az.Tools.Predictor.psd1" };
            }

            iss.ImportPSModule(args[0]);
            iss.ExecutionPolicy = ExecutionPolicy.Bypass;
            var rs = RunspaceFactory.CreateRunspace(new MockPSHost(), iss);
            rs.Open();
            Runspace.DefaultRunspace = rs;

            PSConsoleReadLine.SetOptions(new SetPSReadLineOption
            {
                HistoryNoDuplicates = false,
                PredictionViewStyle = PredictionViewStyle.ListView,
                PredictionSource = PredictionSource.HistoryAndPlugin,
            });

            if (vtEnabled)
            {
                var options = PSConsoleReadLine.GetOptions();
                options.CommandColor = "#8181f7";
                options.StringColor = "\x1b[38;5;100m";
            }

            using (var ps = PowerShell.Create(rs))
            {
                var executionContext = ps.AddScript("$ExecutionContext").Invoke<EngineIntrinsics>().First();

                // Detect if the read loop will enter VT input mode.
                var vtInputEnvVar = Environment.GetEnvironmentVariable("PSREADLINE_VTINPUT");
                var stdin = GetStdHandle((uint)StandardHandleId.Input);
                GetConsoleMode(stdin, out var inputMode);
                if (vtInputEnvVar == "1" || (inputMode & ENABLE_VIRTUAL_TERMINAL_INPUT) != 0)
                {
                    Console.WriteLine("\x1b[33mDefault input mode = virtual terminal\x1b[m");
                }
                else
                {
                    Console.WriteLine("\x1b[33mDefault input mode = Windows\x1b[m");
                }

                // This is a workaround to ensure the command analysis cache has been created before
                // we enter into ReadLine.  It's a little slow and infrequently needed, so just
                // uncomment if you hit a hang, run it once, then comment it out again.
                //ps.Commands.Clear();
                //ps.AddCommand("Get-Command").Invoke();

                executionContext.InvokeProvider.Item.Set("function:prompt", ScriptBlock.Create("'TestHostPS> '"));

                while (true)
                {
                    ps.Commands.Clear();
                    Console.Write(string.Join("", ps.AddCommand("prompt").Invoke<string>()));

                    var line = PSConsoleReadLine.ReadLine(rs, executionContext, true);
                    Console.WriteLine(line);
                    line = line.Trim().ToLower();
                    if (line.Equals("exit"))
                        Environment.Exit(0);
                    if (line.Equals("cmd"))
                        PSConsoleReadLine.SetOptions(new SetPSReadLineOption { EditMode = EditMode.Windows });
                    if (line.Equals("emacs"))
                        PSConsoleReadLine.SetOptions(new SetPSReadLineOption { EditMode = EditMode.Emacs });
                    if (line.Equals("vi"))
                        PSConsoleReadLine.SetOptions(new SetPSReadLineOption { EditMode = EditMode.Vi });
                    if (line.Equals("nodupes"))
                        PSConsoleReadLine.SetOptions(new SetPSReadLineOption { HistoryNoDuplicates = true });
                    if (line.Equals("vtinput"))
                        Environment.SetEnvironmentVariable("PSREADLINE_VTINPUT", "1");
                    if (line.Equals("novtinput"))
                        Environment.SetEnvironmentVariable("PSREADLINE_VTINPUT", "0");
                    if (line.Equals("listview"))
                        PSConsoleReadLine.SetOptions(new SetPSReadLineOption { PredictionViewStyle = PredictionViewStyle.ListView });
                    if (line.Equals("inlineview"))
                        PSConsoleReadLine.SetOptions(new SetPSReadLineOption { PredictionViewStyle = PredictionViewStyle.InlineView });
                    if (line.Equals("history"))
                        PSConsoleReadLine.SetOptions(new SetPSReadLineOption { PredictionSource = PredictionSource.History });
                    if (line.Equals("plugin"))
                        PSConsoleReadLine.SetOptions(new SetPSReadLineOption { PredictionSource = PredictionSource.Plugin });
                    if (line.Equals("historyplugin"))
                        PSConsoleReadLine.SetOptions(new SetPSReadLineOption { PredictionSource = PredictionSource.HistoryAndPlugin });
                    if (line.StartsWith("import-module"))
                        ps.AddScript(line).Invoke();
                    if (line.StartsWith("get-module"))
                    {
                        var modules = ps.AddScript(line).Invoke().ToList();
                        foreach (var m in modules)
                        {
                            Console.WriteLine(((PSModuleInfo)m.BaseObject).Name);
                        }
                    }
                }
            }
        }
    }
}
