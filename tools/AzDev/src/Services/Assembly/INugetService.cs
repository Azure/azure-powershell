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

namespace AzDev.Services.Assembly
{
    /// <summary>
    /// Interface for operations related to NuGet packages.
    /// </summary>
    internal interface INugetService
    {
        /// <summary>
        /// Downloads the specified assembly from NuGet and extracts it to the specified directory.
        /// </summary>
        /// <param name="packageName"></param>
        /// <param name="packageVersion"></param>
        /// <param name="targetFramework"></param>
        /// <param name="destinationPath"></param>
        /// <param name="downloadRuntimes"></param>
        /// <returns>Path to the downloaded assembly, excluding runtime assemblies.</returns>
        string DownloadAssembly(string packageName, string packageVersion, string targetFramework, string destinationPath, bool downloadRuntimes);
    }
}
