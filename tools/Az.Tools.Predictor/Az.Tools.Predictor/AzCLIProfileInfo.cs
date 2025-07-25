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

using Newtonsoft.Json;
using System;
using System.IO;

// This is copied from src/Accounts/Authentication/Modules/AzCliProfileInfo.cs

namespace Microsoft.Azure.PowerShell.Tools.AzPredictor
{
    /// <summary>
    /// this class defines installation id field in Azure CLI context. This information is shared between Azure CLI and Azure PowerShell
    /// </summary>
    internal class AzCLIProfileInfo
    {
        [JsonProperty(PropertyName = "installationId")]
        internal string installationId { get; set; }

        public static readonly string AzCLIProfileFile = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), ".Azure", "AzureProfile.json");
    }
}
