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
using System.IO;
using System.Net.Http.Headers;

namespace Microsoft.WindowsAzure.Commands.Common
{
    public class AzurePowerShell
    {
        public const string AssemblyCompany = "Microsoft";

        public const string AssemblyProduct = "Microsoft Azure Powershell";

        public const string AssemblyCopyright = "Copyright © Microsoft";

        public const string AssemblyVersion = "2.1.0";

        public const string AssemblyFileVersion = "2.1.0";

        public const string ProfileFile = "AzureProfile.json";

        public const string OldProfileFile = "WindowsAzureProfile.xml";

        public const string OldProfileFileBackup = "WindowsAzureProfile.xml.bak";

        public const string TokenCacheFile = "TokenCache.dat";

        public static ProductInfoHeaderValue UserAgentValue = new ProductInfoHeaderValue(
            "AzurePowershell",
            string.Format("v{0}", AzurePowerShell.AssemblyVersion));

        public static string ProfileDirectory = Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
            "Windows Azure PowerShell");
    }
}
