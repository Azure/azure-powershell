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

using Microsoft.Azure.Commands.WebApps.Utilities;
using Microsoft.Azure.Management.WebSites.Models;
using Microsoft.WindowsAzure.Commands.Common.CustomAttributes;
using System.Collections.Generic;
using System.Security;

namespace Microsoft.Azure.Commands.WebApps.Models
{
    public class PSSite : Site
    {
        public PSSite(Site other)
            : base(other)
        {
            if (other is PSSite site)
            {
                AzureStorageAccounts = site.AzureStorageAccounts;
                AzureStoragePath = site.AzureStoragePath;
                VnetInfo = site.VnetInfo;
                VnetInfo = VnetInfo?.Count <= 0 ? null : VnetInfo;
                GitRemoteName = site.GitRemoteName;
                GitRemoteUri = site.GitRemoteUri;
                GitRemoteUsername = site.GitRemoteUsername;
                GitRemotePassword = site.GitRemotePassword;
            }
        }

        public string GitRemoteName { get; set; }
        public string GitRemoteUri { get; set; }
        public string GitRemoteUsername { get; set; }
        public SecureString GitRemotePassword { get; set; }
        public AzureStoragePropertyDictionaryResource AzureStorageAccounts { get; set; }
        public WebAppAzureStoragePath[] AzureStoragePath { get; set; }
        public IList<VnetInfo> VnetInfo { get; set; } = null;
    }
}
