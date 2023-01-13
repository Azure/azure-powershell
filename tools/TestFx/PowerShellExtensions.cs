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

using Microsoft.Azure.ServiceManagement.Common.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Management.Automation;
using System.Management.Automation.Runspaces;

namespace Microsoft.Azure.Commands.TestFx
{
    public static class PowerShellExtensions
    {
        public static void LogPowerShellException(
            this System.Management.Automation.PowerShell powershell,
            Exception runtimeException,
            XunitTracingInterceptor xunitLogger)
        {
            if (xunitLogger != null)
            {
                xunitLogger.Information($"Caught Exception: {runtimeException}");
                xunitLogger.Information($"Message: {runtimeException.Message}");
            }

            if (runtimeException is IContainsErrorRecord recordContainer)
            {
                ErrorRecord record = recordContainer.ErrorRecord;
                xunitLogger?.Information(FormatErrorRecord(record));
            }

            if (runtimeException.InnerException != null)
            {
                powershell.LogPowerShellException(runtimeException.InnerException, xunitLogger);
            }
        }

        internal static string FormatErrorRecord(ErrorRecord record)
        {
            return $"PowerShell Error Record: {record}\nException:{record.Exception}\nDetails:{record.ErrorDetails}\nScript Stack Trace: {record.ScriptStackTrace}\n: Target: {record.TargetObject}\n";
        }

        public static void LogPowerShellResults(
            this System.Management.Automation.PowerShell powershell,
            Collection<PSObject> output,
            XunitTracingInterceptor xunitLogger)
        {
            if (output != null)
            {
                LogPowerShellStream(xunitLogger, output, "OUTPUT");
            }

            if (xunitLogger != null &&
                powershell.Commands != null &&
                powershell.Commands.Commands != null &&
                powershell.Commands.Commands.Count > 0)
            {
                xunitLogger.Information("================== COMMANDS =======================\n");

                foreach (Command command in powershell.Commands.Commands)
                {
                    xunitLogger.Information($"{command.CommandText}\n");
                }

                xunitLogger.Information("===================================================\n");
            }

            LogPowerShellStream(xunitLogger, powershell.Streams.Debug, "DEBUG");
            LogPowerShellStream(xunitLogger, powershell.Streams.Error.Select(FormatErrorRecord).ToList(), "ERROR");
            LogPowerShellStream(xunitLogger, powershell.Streams.Progress, "PROGRESS");
            LogPowerShellStream(xunitLogger, powershell.Streams.Verbose, "VERBOSE");
            LogPowerShellStream(xunitLogger, powershell.Streams.Warning, "WARNING");
        }

        private static void LogPowerShellStream<T>(
            XunitTracingInterceptor xunitLogger,
            ICollection<T> stream,
            string name)
        {
            if (xunitLogger != null && stream != null && stream.Count > 0)
            {
                xunitLogger.Information("---------------------------------------------------------------\n");
                xunitLogger.Information($"{name} STREAM\n");
                xunitLogger.Information("---------------------------------------------------------------\n");
                foreach (T item in stream)
                {
                    if (item != null)
                    {
                        xunitLogger.Information($"{item}\n");
                    }
                }
                xunitLogger.Information("---------------------------------------------------------------\n");
                xunitLogger.Information("");
            }
        }
    }
}
