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

namespace Microsoft.Azure.Commands.DeploymentManager.Utilities
{
    using System.IO;

    internal static class FileUtilities
    {
        internal static string GetHealthCheckPropertiesFromFile(string currentPath, string propertiesFilePath)
        {
            var propertiesFileFullPath = Path.IsPathRooted(propertiesFilePath) ?
                propertiesFilePath :
                Path.Combine(currentPath, propertiesFilePath);

            if (!File.Exists(propertiesFileFullPath))
            {
                throw new FileNotFoundException(
                    string.Format(Messages.HealthCheckPropertiesFileNotFound, propertiesFilePath));
            }

            return File.ReadAllText(propertiesFileFullPath);
        }

    }
}
