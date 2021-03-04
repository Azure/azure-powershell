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

namespace Microsoft.Azure.Commands.ResourceManager.Cmdlets.Utilities
{
    internal static class BicepUtility
    {
        public static bool IsBicepExecutable { get; private set; } = false;

        public static bool IsBicepFile(string templateFilePath)
        {
            return ".bicep".Equals(Path.GetExtension(templateFilePath), System.StringComparison.OrdinalIgnoreCase);
        }

        public delegate List<T> ScriptExecutor<T>(string script);

        public static bool CheckBicepExecutable<T>(ScriptExecutor<T> executeScript)
        {
            try
            {
                executeScript("get-command bicep");
            }
            catch
            {
                IsBicepExecutable = false;
                return IsBicepExecutable;
            }
            IsBicepExecutable = true;
            return IsBicepExecutable;
        }

        public static string BuildFile<T>(ScriptExecutor<T> executeScript, string bicepTemplateFilePath)
        {
            if (!IsBicepExecutable && !CheckBicepExecutable(executeScript))
            {
                throw new AzPSApplicationException(Properties.Resources.BicepNotFound);
            }
            
            string tempPath = Path.Combine(Path.GetTempPath(), Path.GetFileName(bicepTemplateFilePath));

            try{
                if (Uri.IsWellFormedUriString(bicepTemplateFilePath, UriKind.Absolute))
                {
                    FileUtilities.DataStore.WriteFile(tempPath, GeneralUtilities.DownloadFile(bicepTemplateFilePath));
                }
                else if (FileUtilities.DataStore.FileExists(bicepTemplateFilePath))
                {
                    File.Copy(bicepTemplateFilePath, tempPath, true);
                }
                else
                {
                    throw new AzPSArgumentException(Properties.Resources.InvalidBicepFilePathOrUri, "TemplateFile");
                }
                executeScript($"bicep build '{tempPath}'");
                return tempPath.Replace(".bicep", ".json");
            }
            finally
            {
                File.Delete(tempPath);
            }
            
        }
    }
}
