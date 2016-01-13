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

namespace Microsoft.Azure.Commands.Common
{
    public class AzurePowerShell
    {
        public const string AssemblyCompany = "Microsoft";

        public const string AssemblyProduct = "Microsoft Azure Powershell";

        public const string AssemblyCopyright = "Copyright © Microsoft";

        public const string AssemblyVersion = "1.0.0";

        public const string AssemblyFileVersion = "1.0.1";

        public const string ProfileFile = "AzureProfile.json";

        public const string OldProfileFile = "WindowsAzureProfile.xml";

        public const string OldProfileFileBackup = "WindowsAzureProfile.xml.bak";

        public const string TokenCacheFile = "TokenCache.dat";

        public const string ProfileVariable = "_azpsh_profile";

        public const string UserAgentVariable = "_azpsh_user_agents";

        public const string DataStoreVariable = "_azpsh_data_store";

        public static ProductInfoHeaderValue UserAgentValue = new ProductInfoHeaderValue(
            "CLU",
            string.Format("v{0}", AzurePowerShell.AssemblyVersion));

        public static String ProfileDirectory = Directory.GetCurrentDirectory();

    }
}
