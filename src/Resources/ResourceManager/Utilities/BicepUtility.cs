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
    using Microsoft.Azure.Commands.Common.Authentication.Abstractions;
    using Microsoft.Azure.Commands.Common.Exceptions;
    using Microsoft.WindowsAzure.Commands.Utilities.Common;
    using System;
    using System.IO;
    using System.Management.Automation;
    using System.Text.RegularExpressions;

    internal static class BicepUtility
    {
        private static bool IsBicepExecutable = false;

        private const string MinimalVersionRequirement = "0.3.1";

        private const string MinimalVersionRequirementForBicepPublish = "0.4.1008";

        public delegate void OutputCallback(string msg);

        public static bool IsBicepFile(string templateFilePath) =>
            ".bicep".Equals(Path.GetExtension(templateFilePath), StringComparison.OrdinalIgnoreCase);

        public static string BuildFile(string bicepTemplateFilePath, OutputCallback writeVerbose = null, OutputCallback writeWarning = null)
        {
            if (!FileUtilities.DataStore.FileExists(bicepTemplateFilePath))
            {
                throw new AzPSArgumentException(Properties.Resources.InvalidBicepFilePath, "TemplateFile");
            }

            string tempDirectory = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString());
            Directory.CreateDirectory(tempDirectory);

            RunBicepCommand($"bicep build '{bicepTemplateFilePath}' --outdir '{tempDirectory}'", MinimalVersionRequirement, writeVerbose, writeWarning);

            string buildResultPath = Path.Combine(tempDirectory, Path.GetFileName(bicepTemplateFilePath)).Replace(".bicep", ".json");
            if (!FileUtilities.DataStore.FileExists(buildResultPath))
            {
                throw new AzPSApplicationException(string.Format(Properties.Resources.BuildBicepFileToJsonFailed, bicepTemplateFilePath));
            }

            return buildResultPath;
        }

        public static void PublishFile(string bicepFilePath, string target, OutputCallback writeVerbose = null, OutputCallback writeWarning = null)
        {
            if (!FileUtilities.DataStore.FileExists(bicepFilePath))
            {
                throw new AzPSArgumentException(Properties.Resources.InvalidBicepFilePath, "File");
            }

            RunBicepCommand($"bicep publish '{bicepFilePath}' --target '{target}'", MinimalVersionRequirementForBicepPublish, writeVerbose, writeWarning);
        }

        private static void CheckBicepExecutable()
        {
            using (var powerShell = PowerShell.Create())
            {
                if (IsBicepExecutable)
                {
                    return;
                }

                powerShell.AddScript("Get-Command bicep");
                powerShell.Invoke();
                powerShell.AddScript("$?");
                var result = powerShell.Invoke();
                // Cache result
                bool.TryParse(result[0].ToString(), out IsBicepExecutable);

                if (!IsBicepExecutable)
                {
                    throw new AzPSApplicationException(Properties.Resources.BicepNotFound);
                }
            }
        }

        private static string CheckMinimalVersionRequirement(string minimalVersionRequirement)
        {
            string currentBicepVersion = GetBicepVersion();
            if (Version.Parse(minimalVersionRequirement).CompareTo(Version.Parse(currentBicepVersion)) > 0)
            {
                throw new AzPSApplicationException(string.Format(Properties.Resources.BicepVersionRequirement, minimalVersionRequirement));
            };
            return currentBicepVersion;
        }

        private static string GetBicepVersion()
        {
            using (var powerShell = PowerShell.Create())
            {
                powerShell.AddScript("bicep -v");
                var result = powerShell.Invoke()[0].ToString();
                Regex pattern = new Regex("\\d+(\\.\\d+)+");
                string bicepVersion = pattern.Match(result)?.Value;

                return bicepVersion;
            }
        }

        private static int GetLastExitCode(PowerShell powershell)
        {
            powershell.AddScript("$LASTEXITCODE");
            var result = powershell.Invoke();
            int.TryParse(result[0]?.ToString(), out int exitcode);
            return exitcode;
        }

        private static void RunBicepCommand(string command, string minimalVersionRequirement, OutputCallback writeVerbose = null, OutputCallback writeWarning = null)
        {
            CheckBicepExecutable();

            string currentBicepVersion = CheckMinimalVersionRequirement(minimalVersionRequirement);

            using (var powerShell = PowerShell.Create())
            {
                powerShell.AddScript(command);
                var result = powerShell.Invoke();

                if (writeVerbose != null)
                {
                    writeVerbose(string.Format("Using Bicep v{0}", currentBicepVersion));
                    result.ForEach(r => writeVerbose(r.ToString()));
                }

                // Bicep uses error stream to report warning message and error message, record it
                string warningOrErrorMsg = string.Empty;
                if (powerShell.HadErrors)
                {
                    powerShell.Streams.Error.ForEach(e => { warningOrErrorMsg += (e + Environment.NewLine); });
                    warningOrErrorMsg = warningOrErrorMsg.Substring(0, warningOrErrorMsg.Length - Environment.NewLine.Length);
                }

                if (0 == GetLastExitCode(powerShell))
                {
                    // print warning message
                    if (writeWarning != null && !string.IsNullOrEmpty(warningOrErrorMsg))
                    {
                        writeWarning(warningOrErrorMsg);
                    }
                }
                else
                {
                    throw new AzPSApplicationException(warningOrErrorMsg);
                }
            }
        }
    }
}