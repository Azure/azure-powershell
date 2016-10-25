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

using System.IO;
using System.Text.RegularExpressions;
using Microsoft.Azure.Management.MachineLearning.WebServices.Models;
using Microsoft.Azure.Management.MachineLearning.WebServices.Util;

namespace Microsoft.Azure.Commands.MachineLearning.Utilities
{
    internal static class CmdletHelpers
    {
        private static readonly Regex MlResourceIdRegex = 
            new Regex(
                    @"^\/subscriptions\/(?<subscriptionId>[^\/]+)\/resourceGroups\/"+
                    @"(?<resourceGroupName>[^\/]+)\/providers\/Microsoft.MachineLearning\/"+
                    @"(?<resourceTypeName>[^\/]+)\/(?<resourceName>[^\/]+)$", 
                    RegexOptions.IgnoreCase);

        internal static bool TryParseMlResourceMetadataFromResourceId(
                                string resourceId, 
                                out string subscriptionId, 
                                out string resourceGroupName, 
                                out string resourceName)
        {
            var match = CmdletHelpers.MlResourceIdRegex.Match(resourceId);
            if (match.Success)
            {
                subscriptionId = match.Groups["subscriptionId"].Value;
                resourceGroupName = match.Groups["resourceGroupName"].Value;
                resourceName = match.Groups["resourceName"].Value;
                return true;
            }

            subscriptionId = null;
            resourceGroupName = null;
            resourceName = null;
            return false;
        }

        internal static string GetWebServiceDefinitionFromFile(string currentPath, string definitionFilePath)
        {
            var definitionFileFullPath = 
                    Path.IsPathRooted(definitionFilePath) ? 
                        definitionFilePath : 
                        Path.Combine(currentPath, definitionFilePath);

            if (!File.Exists(definitionFileFullPath))
            {
                throw new FileNotFoundException(Resources.MissingDefinitionFile, definitionFileFullPath);
            }

            return File.ReadAllText(definitionFileFullPath);
        }
    }
}
