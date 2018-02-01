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
    using Microsoft.Azure.Management.Redis.Models;
    using ResourceManager.Common.ArgumentCompleters;
    using System;
    using System.Management.Automation;
    using Rest.Azure;

    [Cmdlet(VerbsCommon.New, "AzureRmRedisCacheLink", SupportsShouldProcess = true), OutputType(typeof(PSRedisLinkedServer))]
    public class NewAzureRedisCacheLink : RedisCacheCmdletBase
    {
        [Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true, HelpMessage = "Name of primary redis cache in link.")]
        [ValidateNotNullOrEmpty]
        public string PrimaryServerName { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true, HelpMessage = "Name of secondary redis cache in link.")]
        [ValidateNotNullOrEmpty]
        public string SecondaryServerName { get; set; }

        public override void ExecuteCmdlet()
        {
            Utility.ValidateResourceGroupAndResourceName(null, PrimaryServerName);
            Utility.ValidateResourceGroupAndResourceName(null, SecondaryServerName);

            RedisResource primaryCache = CacheClient.GetCache(PrimaryServerName);
            RedisResource secondaryCache = CacheClient.GetCache(SecondaryServerName);

            ConfirmAction(
                string.Format(Resources.LinkingRedisCache, SecondaryServerName, PrimaryServerName),
                PrimaryServerName,
                () =>
                {
                    RedisLinkedServerWithProperties redisLinkedServer = CacheClient.SetLinkedServer(
                       resourceGroupName: Utility.GetResourceGroupNameFromRedisCacheId(primaryCache.Id),
                       cacheName: primaryCache.Name,
                       linkedCacheName: secondaryCache.Name,
                       linkedCacheId: secondaryCache.Id,
                       linkedCacheLocation: secondaryCache.Location,
                       serverRole: ReplicationRole.Secondary);

                    if (redisLinkedServer == null)
                    {
                        throw new CloudException(string.Format(Resources.LinkedServerCreationFailed, SecondaryServerName, PrimaryServerName));
                    }
                    WriteObject(new PSRedisLinkedServer(redisLinkedServer));
                }
            );
        }
    }
}