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

namespace Microsoft.Azure.Commands.RedisCache
{
    using Microsoft.Azure.Commands.RedisCache.Models;
    using Microsoft.Azure.Commands.RedisCache.Properties;
    using System;
    using System.Management.Automation;

    [Cmdlet(VerbsCommon.Set, "AzureRmRedisCacheDiagnostics"), OutputType(typeof(void))]
    public class SetAzureRedisCacheDiagnostics : RedisCacheCmdletBase
    {
        [Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true, HelpMessage = "Name of resource group under which cache exists.")]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true, HelpMessage = "Name of redis cache.")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true, HelpMessage = "ARM Resource Id for storage account.")]
        [ValidateNotNullOrEmpty]
        public string StorageAccountId { get; set; }

        public override void ExecuteCmdlet()
        {
            string storageAccountName = GetStorageAccountName(StorageAccountId);
            RedisCacheAttributes cache = new RedisCacheAttributes(CacheClient.GetCache(ResourceGroupName, Name), ResourceGroupName);
            CacheClient.SetDiagnostics(cache.Id, storageAccountName);
        }

        private string GetStorageAccountName(string storageAccountId)
        {
            Utility.ValidateResourceGroupAndResourceName(ResourceGroupName, Name);
            if (string.IsNullOrEmpty(storageAccountId))
            {
                throw new ArgumentException(Resources.StorageAccountIdException);
            }
            else
            {
                string[] resourceParts = storageAccountId.Split('/');
                // Valid ARM uri when split on '/' should have 9 parts. Ex: /subscriptions/<sub-id>/resourceGroups/<resource group name>/providers/Microsoft.ClassicStorage/storageAccounts/<account name>
                if (resourceParts.Length != 9)
                {
                    throw new ArgumentException(Resources.StorageAccountIdException);
                }
                return resourceParts[8];
            }
        }
    }
}