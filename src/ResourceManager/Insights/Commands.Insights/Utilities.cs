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
using System.Globalization;
using System.Reflection;

namespace Microsoft.Azure.Commands.Insights
{
    /// <summary>
    /// Static class contaning common functions
    /// </summary>
    public static class Utilities
    {
        /// <summary>
        /// Gets the file version of the currently (executing) dll.
        /// </summary>
        /// <returns>The string with the file version of the current dll or null if an error happened</returns>
        public static string GetCurrentDllFileVersion()
        {
            Assembly CurrentAssembly = Assembly.GetExecutingAssembly();
            System.Diagnostics.FileVersionInfo fileVersionInfo = System.Diagnostics.FileVersionInfo.GetVersionInfo(CurrentAssembly.Location);
            return fileVersionInfo.FileVersion;
        }

        /// <summary>
        /// Gets a string with a default description for artifacts like alert rules or autoscale settings
        /// </summary>
        /// <param name="artifactName">The name of the artifact to deacribe, e.g.: alert rule, autoscale setting</param>
        /// <returns>A string with a default description for artifacts like alert rules or autoscale settings</returns>
        public static string GetDefaultDescription(string artifactName)
        {
            const string fileVersionTemplate = "This {0} was created from Powershell version: {1}";
            return string.Format(CultureInfo.InvariantCulture, fileVersionTemplate, artifactName, GetCurrentDllFileVersion() ?? "Unknown");
        }

        /// <summary>
        /// Checks if the given string represents a valid uri
        /// </summary>
        /// <param name="uri">The string representing a uri</param>
        /// <param name="argName">The name of the argument to report as invalid</param>
        public static void ValidateUri(string uri, string argName = "Uri")
        {
            Uri tempUri;
            if (!Uri.TryCreate(uri, UriKind.RelativeOrAbsolute, out tempUri))
            {
                throw new ArgumentException(string.Format("Invalid {0}: {1}", argName, uri));
            }
        }
    }
}
