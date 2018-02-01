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

    [Cmdlet(VerbsCommon.Get, "AzureRmRedisCacheFirewallRule"), OutputType(typeof(List<PSRedisFirewallRule>))]
    public class GetAzureRedisCacheFirewallRule : RedisCacheCmdletBase
    {
        [Parameter(ValueFromPipelineByPropertyName = true, Mandatory = false, HelpMessage = "Name of resource group in which cache exists.")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true, HelpMessage = "Name of redis cache.")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = true, Mandatory = false, HelpMessage = "Name of firewall rule.")]
        public string RuleName { get; set; }

        public override void ExecuteCmdlet()
        {
            Utility.ValidateResourceGroupAndResourceName(ResourceGroupName, Name);
            ResourceGroupName = CacheClient.GetResourceGroupNameIfNotProvided(ResourceGroupName, Name);

            if (!string.IsNullOrEmpty(RuleName))
            {
                RedisFirewallRule redisFirewallRule = CacheClient.GetFirewallRule(
                    resourceGroupName: ResourceGroupName,
                    cacheName: Name,
                    ruleName: RuleName);

                if (redisFirewallRule == null)
                {
                    throw new CloudException(string.Format(Resources.FirewallRuleNotFound, Name, RuleName));
                }
                WriteObject(new PSRedisFirewallRule(ResourceGroupName, Name, redisFirewallRule));
            }
            else
            {
                IPage<RedisFirewallRule> response = CacheClient.ListFirewallRules(ResourceGroupName, Name);
                List<PSRedisFirewallRule> list = new List<PSRedisFirewallRule>();
                foreach (RedisFirewallRule redisFirewallRule in response)
                {
                    list.Add(new PSRedisFirewallRule(ResourceGroupName, Name, redisFirewallRule));
                }
                
                while (!string.IsNullOrEmpty(response.NextPageLink))
                {
                    response = CacheClient.ListFirewallRules(response.NextPageLink);
                    foreach (RedisFirewallRule redisFirewallRule in response)
                    {
                        list.Add(new PSRedisFirewallRule(ResourceGroupName, Name, redisFirewallRule));
                    }
                }

                WriteObject(list, true);
            }
        }
    }
}