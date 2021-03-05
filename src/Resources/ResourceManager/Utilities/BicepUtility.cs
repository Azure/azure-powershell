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

using System.IO;

namespace Microsoft.Azure.Commands.ResourceManager.Cmdlets.Utilities
{
    internal static class BicepUtility
    {
        public static bool IsBicepExecutable { get; private set; } = false;

        public static bool IsBicepFile(string templateFilePath)
        {
            return ".bicep".Equals(Path.GetExtension(templateFilePath), System.StringComparison.OrdinalIgnoreCase);
        }

        public static bool CheckBicepExecutable()
        {
            System.Management.Automation.PowerShell powershell = System.Management.Automation.PowerShell.Create();
            powershell.AddScript("Get-Command bicep");
            powershell.Invoke();
            IsBicepExecutable = powershell.HadErrors ? false : true;
            return IsBicepExecutable;
        }

        public static string GetBicepVesion()
        {
            System.Management.Automation.PowerShell powershell = System.Management.Automation.PowerShell.Create();
            powershell.AddScript("bicep -v");
            var result = powershell.Invoke();
            return result[0].ToString();
        }

        public delegate void OutputMethod(string msg);

        public static string BuildFile(string bicepTemplateFilePath, OutputMethod outputMethod = null)
        {
            if (!IsBicepExecutable && !CheckBicepExecutable())
            {
                throw new AzPSApplicationException(Properties.Resources.BicepNotFound);
            }

            if (FileUtilities.DataStore.FileExists(bicepTemplateFilePath))
            {
                System.Management.Automation.PowerShell powershell = System.Management.Automation.PowerShell.Create();
                powershell.AddScript($"bicep build '{bicepTemplateFilePath}'");
                var result = powershell.Invoke();
                if (outputMethod != null)
                {
                    outputMethod(string.Format("Using {0}", GetBicepVesion()));
                    foreach(var r in result)
                    {
                        outputMethod(r.ToString());
                    }
                }
                if (powershell.HadErrors)
                {
                    throw new AzPSApplicationException(powershell.Streams.Error.ToString());
                }
                return bicepTemplateFilePath.Replace(".bicep", ".json");
            }
            else
            {
                throw new AzPSArgumentException(Properties.Resources.InvalidBicepFilePath, "TemplateFile");
            }
        }

    }
}
