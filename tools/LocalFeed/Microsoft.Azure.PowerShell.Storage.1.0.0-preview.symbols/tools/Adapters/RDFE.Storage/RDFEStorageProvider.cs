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

using Microsoft.WindowsAzure.Management.Storage;
using Microsoft.WindowsAzure.Commands.Common.Storage;
using Microsoft.Azure.Commands.Common.Storage.Adapters;
using Microsoft.Azure.Commands.Common.Authentication.Abstractions;

namespace Microsoft.Azure.Commands.Management.Storage.Models
{
    public class RDFEStorageProvider : IStorageServiceProvider
    {
        IStorageManagementClient _client;
        IAzureEnvironment _environment;

        public RDFEStorageProvider(IStorageManagementClient client, IAzureEnvironment environment)
        {
            _client = client;
            _environment = environment;
        }
        public IStorageService GetStorageService(string name, string unused)
        {
            var keys = _client.StorageAccounts.GetKeys(name);
            return new CloudStorageService(name, new [] { keys.PrimaryKey, keys.SecondaryKey }, _environment);
        }
    }
}
