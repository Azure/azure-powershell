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

using Microsoft.Azure.Commands.Common.Authentication.Abstractions;
using Microsoft.Azure.Commands.Common.Exceptions;
using Microsoft.WindowsAzure.Commands.Utilities.Common;

using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

namespace Microsoft.Azure.Commands.ResourceManager.Cmdlets.Utilities
{
    internal static class BicepUtility
    {
        public static bool IsBicepExecutable { get; private set; } = false;

        public static string MinimalVersionRequirement { get; private set; } = "0.3.1";

        public static bool IsBicepFile(string templateFilePath)
        {
            return ".bicep".Equals(Path.GetExtension(templateFilePath), System.StringComparison.OrdinalIgnoreCase);
        }

        public static bool CheckBicepExecutable()
        {
            System.Management.Automation.PowerShell powershell = System.Management.Automation.PowerShell.Create();
            powershell.AddScript("Get-Command bicep");
            powershell.Invoke();
            powershell.AddScript("$?");
            var result = powershell.Invoke();
            bool.TryParse(result[0].ToString(), out bool res);
            // Cache result
            IsBicepExecutable = res;
            return IsBicepExecutable;
        }

        private static string CheckMinimalVersionRequirement(string minimalVersionRequirement)
        {
            string currentBicepVersion = GetBicepVesion();
            if (Version.Parse(minimalVersionRequirement).CompareTo(Version.Parse(currentBicepVersion)) > 0)
            {
                throw new AzPSApplicationException(string.Format(Properties.Resources.BicepVersionRequirement, minimalVersionRequirement));
            };
            return currentBicepVersion;
        }

        public static string GetBicepVesion()
        {
            System.Management.Automation.PowerShell powershell = System.Management.Automation.PowerShell.Create();
            powershell.AddScript("bicep -v");
            var result = powershell.Invoke()[0].ToString();
            Regex pattern = new Regex("\\d+(\\.\\d+)+");
            string bicepVersion = pattern.Match(result)?.Value;
            return bicepVersion;
        }

        public static int GetLastExitCode(System.Management.Automation.PowerShell powershell)
        {
            powershell.AddScript("$LASTEXITCODE");
            var result = powershell.Invoke();
            int.TryParse(result[0].ToString(), out int exitcode);
            return exitcode;
        }

        public delegate void VerboseOutputMethod(string msg);
        public delegate void WarningOutputMethod(string msg);

        public static string BuildFile(string bicepTemplateFilePath, VerboseOutputMethod writeVerbose = null, WarningOutputMethod writeWarning = null)
        {
            if (!IsBicepExecutable && !CheckBicepExecutable())
            {
                throw new AzPSApplicationException(Properties.Resources.BicepNotFound);
            }

            string currentBicepVersion = CheckMinimalVersionRequirement(MinimalVersionRequirement);

            string tempDirectory = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString());
            Directory.CreateDirectory(tempDirectory);

            if (FileUtilities.DataStore.FileExists(bicepTemplateFilePath))
            {
                using (System.Management.Automation.PowerShell powershell = System.Management.Automation.PowerShell.Create())
                {
                    powershell.AddScript($"bicep build '{bicepTemplateFilePath}' --outdir '{tempDirectory}'");
                    var result = powershell.Invoke();
                    
                    if (writeVerbose != null)
                    {
                        writeVerbose(string.Format("Using Bicep v{0}", currentBicepVersion));
                        result.ForEach(r => writeVerbose(r.ToString()));
                    }

                    // Bicep uses error stream to report warning message and error message, record it
                    string warningOrErrorMsg = string.Empty;
                    if (powershell.HadErrors)
                    {
                        powershell.Streams.Error.ForEach(e => { warningOrErrorMsg += (e + Environment.NewLine); });
                        warningOrErrorMsg = warningOrErrorMsg.Substring(0, warningOrErrorMsg.Length - Environment.NewLine.Length);
                    }

                    if (0 == GetLastExitCode(powershell))
                    {
                        // print warning message
                        if(writeWarning != null && !string.IsNullOrEmpty(warningOrErrorMsg))
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
            else
            {
                throw new AzPSArgumentException(Properties.Resources.InvalidBicepFilePath, "TemplateFile");
            }

            string buildResultPath = Path.Combine(tempDirectory, Path.GetFileName(bicepTemplateFilePath)).Replace(".bicep", ".json");
            if (!FileUtilities.DataStore.FileExists(buildResultPath))
            {
                throw new AzPSApplicationException(string.Format(Properties.Resources.BuildBicepFileToJsonFailed, bicepTemplateFilePath));
            }
            return buildResultPath;
        }
    }
}
