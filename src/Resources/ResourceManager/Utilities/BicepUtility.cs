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
using System.Collections.ObjectModel;
using System.IO;
using System.Management.Automation;
using System.Text.RegularExpressions;
using AzurePowerShell = System.Management.Automation.PowerShell;

namespace Microsoft.Azure.Commands.ResourceManager.Cmdlets.Utilities
{
    internal static class BicepUtility
    {
        private const string MinimalVersionRequirement = "0.3.1";

        private const string MinimalVersionRequirementForBicepPublish = "0.4.1008";

        public static bool IsBicepExecutable { get; private set; } = false;

        public static bool IsBicepFile(string templateFilePath)
        {
            return ".bicep".Equals(Path.GetExtension(templateFilePath), System.StringComparison.OrdinalIgnoreCase);
        }

        public static bool CheckBicepExecutable()
        {
            var powershell = AzurePowerShell.Create();
            powershell.AddScript("Get-Command bicep");
            powershell.Invoke();
            IsBicepExecutable = powershell.HadErrors ? false : true;
            return IsBicepExecutable;
        }

        private static string CheckMinimalVersionRequirement(string minimalVersionRequirement)
        {
            if (!IsBicepExecutable && !CheckBicepExecutable())
            {
                throw new AzPSApplicationException(Properties.Resources.BicepNotFound);
            }

            string currentBicepVersion = GetBicepVesion();
            if (Version.Parse(minimalVersionRequirement).CompareTo(Version.Parse(currentBicepVersion)) > 0)
            {
                throw new AzPSApplicationException(string.Format(Properties.Resources.BicepVersionRequirement, minimalVersionRequirement));
            };
            return currentBicepVersion;
        }

        public static string GetBicepVesion()
        {
            var result = RunBicepCommand(AzurePowerShell.Create(), "-v")[0].ToString();
            Regex pattern = new Regex("\\d+(\\.\\d+)+");
            string bicepVersion = pattern.Match(result)?.Value;
            return bicepVersion;
        }

        public delegate void OutputMethod(string msg);

        public static void PublishBicepModule(string bicepFilePath, string target, OutputMethod outputMethod)
        {
            string currentBicepVersion = CheckMinimalVersionRequirement(MinimalVersionRequirementForBicepPublish);

            RunBicepCommand($"publish '{bicepFilePath}' --target '{target}'", currentBicepVersion, outputMethod);
        }

        public static string BuildFile(string bicepTemplateFilePath, OutputMethod outputMethod = null)
        {
            string tempDirectory = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString());

            if (FileUtilities.DataStore.FileExists(bicepTemplateFilePath))
            {
                string currentBicepVersion = CheckMinimalVersionRequirement(MinimalVersionRequirement);

                Directory.CreateDirectory(tempDirectory);
                RunBicepCommand($"build '{bicepTemplateFilePath}' --outdir '{tempDirectory}'", currentBicepVersion, outputMethod);
            }
            else
            {
                throw new AzPSArgumentException(Properties.Resources.InvalidBicepFilePath, "TemplateFile");
            }

            return Path.Combine(tempDirectory, Path.GetFileName(bicepTemplateFilePath)).Replace(".bicep", ".json");
        }

        private static void RunBicepCommand(string command, string currentBicepVersion, OutputMethod outputMethod)
        {
            var powershell = AzurePowerShell.Create();
            var result = RunBicepCommand(powershell, command);

            if (outputMethod != null)
            {
                outputMethod(string.Format("Using Bicep v{0}", currentBicepVersion));
                result.ForEach(r => outputMethod(r.ToString()));
            }

            string errorMsg = string.Empty;
            if (powershell.HadErrors)
            {
                powershell.Streams.Error.ForEach(e => { errorMsg += (e + Environment.NewLine); });
                errorMsg = errorMsg.Substring(0, errorMsg.Length- Environment.NewLine.Length);
                outputMethod(errorMsg);
            }

            powershell.AddScript("$LASTEXITCODE");
            result = powershell.Invoke();
            int.TryParse(result.ToString(), out int exitcode);
            
            if (exitcode != 0)
            {
                throw new AzPSApplicationException(errorMsg);
            }
        }

        private static Collection<PSObject> RunBicepCommand(AzurePowerShell powershell, string command) =>
            powershell.AddScript($"bicep {command}").Invoke();
    }
}
