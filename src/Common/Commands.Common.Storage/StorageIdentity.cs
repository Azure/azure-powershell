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
using System.Text.RegularExpressions;

namespace Microsoft.WindowsAzure.Commands.Common.Storage
{
    public class StorageIdentity
    {
        private const string StorageIdentityRegex =
            "/subscriptions/([^/]+)/resourceGroups/([^/]+)/microsoft.storage/storageAccounts/(\\w+)";
        public StorageIdentity(string identity)
        {
            var matcher = new Regex(StorageIdentityRegex);
            var result = matcher.Match(identity);
            if (!result.Success || result.Groups == null || result.Groups.Count < 3)
            {
                throw new InvalidOperationException(string.Format("Cannot find resource grpoup name and storage account name from resource identity {0}", identity));
            }

            this.ResourceGroupName = result.Groups[1].Value;
            this.StorageAccountName = result.Groups[2].Value;
        }

        public string ResourceGroupName { get; private set; }

        public string StorageAccountName { get; private set; }
    }
}
