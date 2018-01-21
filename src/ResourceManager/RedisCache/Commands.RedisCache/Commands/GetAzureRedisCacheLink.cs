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
    using System.Collections.Generic;
    using System.Management.Automation;
    using Rest.Azure;
    using ResourceManager.Common.ArgumentCompleters;
    using System;

    [Cmdlet(VerbsCommon.Get, "AzureRmRedisCacheLink", DefaultParameterSetName = AllLinksForCacheSet), OutputType(typeof(List<PSRedisLinkedServer>))]
    public class GetAzureRedisCacheLink : RedisCacheCmdletBase
    {
        internal const string AllLinksForCacheSet = "AllLinksForCache";
        internal const string AllLinksForPrimaryCacheSet = "AllLinksForPrimaryCache";
        internal const string AllLinksForSecondaryCacheSet = "AllLinksForSecondaryCache";
        internal const string SingleLinkSet = "SingleLink";

        [Parameter(ParameterSetName = AllLinksForCacheSet, 
            ValueFromPipelineByPropertyName = true, Mandatory = true, HelpMessage = "Name of redis cache.")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(ParameterSetName = AllLinksForPrimaryCacheSet, 
            ValueFromPipelineByPropertyName = true, Mandatory = true, HelpMessage = "Name of primary redis cache in link.")]
        [Parameter(ParameterSetName = SingleLinkSet,
            ValueFromPipelineByPropertyName = true, Mandatory = true, HelpMessage = "Name of primary redis cache in link.")]
        [ValidateNotNullOrEmpty]
        public string PrimaryServerName { get; set; }

        [Parameter(ParameterSetName = AllLinksForSecondaryCacheSet, 
            ValueFromPipelineByPropertyName = true, Mandatory = true, HelpMessage = "Name of secondary redis cache in link.")]
        [Parameter(ParameterSetName = SingleLinkSet,
            ValueFromPipelineByPropertyName = true, Mandatory = true, HelpMessage = "Name of secondary redis cache in link.")]
        [ValidateNotNullOrEmpty]
        public string SecondaryServerName { get; set; }

        public override void ExecuteCmdlet()
        {
            Utility.ValidateResourceGroupAndResourceName(null, Name);
            Utility.ValidateResourceGroupAndResourceName(null, PrimaryServerName);
            Utility.ValidateResourceGroupAndResourceName(null, SecondaryServerName);

            if (!string.IsNullOrWhiteSpace(Name))
            {
                // All links for cache
                List<PSRedisLinkedServer> list = GetAllLinks(Name);
                WriteObject(list, true);
            }
            else if (!string.IsNullOrWhiteSpace(PrimaryServerName) && !string.IsNullOrWhiteSpace(SecondaryServerName))
            {
                // specific link only
                string resourceGroupName = CacheClient.GetResourceGroupNameIfNotProvided(null, PrimaryServerName);
                RedisLinkedServerWithProperties redisLinkedServer = CacheClient.GetLinkedServer(
                    resourceGroupName: resourceGroupName,
                    cacheName: PrimaryServerName,
                    linkedCacheName: SecondaryServerName);

                if (redisLinkedServer == null || redisLinkedServer.ServerRole != ReplicationRole.Secondary)
                {
                    throw new CloudException(string.Format(Resources.LinkedServerNotFound, PrimaryServerName, SecondaryServerName));
                }
                WriteObject(new PSRedisLinkedServer(redisLinkedServer));
            }
            else if (!string.IsNullOrWhiteSpace(PrimaryServerName))
            {
                // all primary links only
                List<PSRedisLinkedServer> list = GetAllLinksByRoleType(PrimaryServerName, ReplicationRole.Primary);
                WriteObject(list, true);
            }
            else
            {
                // all secondary links only
                List<PSRedisLinkedServer> list = GetAllLinksByRoleType(SecondaryServerName, ReplicationRole.Secondary);
                WriteObject(list, true);
            }

        }

        private List<PSRedisLinkedServer> GetAllLinks(string cacheName)
        {
            string resourceGroupName = CacheClient.GetResourceGroupNameIfNotProvided(null, cacheName);
            IPage<RedisLinkedServerWithProperties> response = CacheClient.ListLinkedServer(resourceGroupName, cacheName);

            List<PSRedisLinkedServer> list = new List<PSRedisLinkedServer>();
            foreach (RedisLinkedServerWithProperties redisLinkedServer in response)
            {
                list.Add(new PSRedisLinkedServer(redisLinkedServer));
            }

            while (!string.IsNullOrEmpty(response.NextPageLink))
            {
                response = CacheClient.ListLinkedServer(response.NextPageLink);
                foreach (RedisLinkedServerWithProperties redisLinkedServer in response)
                {
                    list.Add(new PSRedisLinkedServer(redisLinkedServer));
                }
            }
            return list;
        }

        private List<PSRedisLinkedServer> GetAllLinksByRoleType(string cacheName, ReplicationRole roleType)
        {
            List<PSRedisLinkedServer> list = GetAllLinks(cacheName);
            if (roleType == ReplicationRole.Primary)
            {
                List<PSRedisLinkedServer> allPrimary = new List<PSRedisLinkedServer>();
                foreach (var link in list)
                {
                    if (link.PrimaryServerName.Equals(cacheName, StringComparison.OrdinalIgnoreCase))
                    {
                        allPrimary.Add(link);
                    }
                }
                return allPrimary;
            }
            else
            {
                List<PSRedisLinkedServer> allSecondary = new List<PSRedisLinkedServer>();
                foreach (var link in list)
                {
                    if (link.SecondaryServerName.Equals(cacheName, StringComparison.OrdinalIgnoreCase))
                    {
                        allSecondary.Add(link);
                    }
                }
                return allSecondary;
            }
        }
    }
}