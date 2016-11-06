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
    using Microsoft.Azure.Commands.RedisCache.Properties;
    using Microsoft.Azure.Management.Redis.Models;
    using System.Management.Automation;

    [Cmdlet(VerbsCommon.New, "AzureRmRedisCacheKey", SupportsShouldProcess = true),
        OutputType(typeof(RedisAccessKeys))]
    public class NewAzureRedisCacheKey : RedisCacheCmdletBase
    {
        [Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true, HelpMessage = "Name of resource group under which cache exists.")]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true, HelpMessage = "Name of redis cache.")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(Mandatory = true, HelpMessage = "Regenerate this key.")]
        [ValidateNotNullOrEmpty]
        [ValidateSet("Primary", "Secondary", IgnoreCase = false)]
        public string KeyType { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Do not ask for confirmation.")]
        public SwitchParameter Force { get; set; }

        public override void ExecuteCmdlet()
        {
            Utility.ValidateResourceGroupAndResourceName(ResourceGroupName, Name);
            RedisKeyType keyTypeToRegenerated = RedisKeyType.Primary;
            if (KeyType.Equals("Secondary"))
            {
                keyTypeToRegenerated = RedisKeyType.Secondary;
            }

            ConfirmAction(
                Force.IsPresent,
                string.Format(Resources.RegeneratingRedisCacheKey, Name, keyTypeToRegenerated.ToString()),
                string.Format(Resources.RegenerateRedisCacheKey, Name, keyTypeToRegenerated.ToString()),
                Name,
                () =>
                {
                    CacheClient.RegenerateAccessKeys(ResourceGroupName, Name, keyTypeToRegenerated);
                    RedisListKeysResult keysResponse = CacheClient.GetAccessKeys(ResourceGroupName, Name);
                    WriteObject(new RedisAccessKeys()
                    {
                        PrimaryKey = keysResponse.PrimaryKey,
                        SecondaryKey = keysResponse.SecondaryKey
                    });
                }
            );
        }
    }
}