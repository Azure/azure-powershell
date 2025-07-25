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

using Microsoft.WindowsAzure.Commands.Common.Storage;
using Microsoft.Azure.PowerShell.Cmdlets.Compute.Helpers.Storage;

namespace Microsoft.Azure.Commands.Compute
{
    public class ARMStorageProvider : IStorageServiceProvider
    {
        IStorageManagementClient _client;

        public ARMStorageProvider(IStorageManagementClient client)
        {
            _client = client;
        }
        public IStorageService GetStorageService(string name, string resourceGroupName)
        {
            var account = _client.StorageAccounts.GetProperties(resourceGroupName, name);
            var keys = _client.StorageAccounts.ListKeys(resourceGroupName, name);
            return new ARMStorageService(account, keys.GetKey1(), keys.GetKey2());
        }
    }
}
