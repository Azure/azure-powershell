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
    using System.Management.Automation;
    using Rest.Azure;

    [Cmdlet(VerbsCommon.New, "AzureRmRedisCacheFirewallRule", DefaultParameterSetName = NormalParameterSet, SupportsShouldProcess = true), OutputType(typeof(PSRedisFirewallRule))]
    public class NewAzureRedisCacheFirewallRule : RedisCacheCmdletBase
    {
        private const string NormalParameterSet = "NormalParameterSet";
        private const string InputObjectParameterSet = "RedisCacheAttributesObject";
        private const string ResourceIdParameterSet = "ResourceIdParameterSet";

        [Parameter(ParameterSetName = NormalParameterSet, ValueFromPipelineByPropertyName = true, Mandatory = false, HelpMessage = "Name of resource group in which cache exists.")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(ParameterSetName = NormalParameterSet, ValueFromPipelineByPropertyName = true, Mandatory = true, HelpMessage = "Name of redis cache.")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(ParameterSetName = InputObjectParameterSet, Mandatory = true, ValueFromPipeline = true, HelpMessage = "Object of type RedisCacheAttributes")]
        [ValidateNotNull]
        public RedisCacheAttributes InputObject { get; set; }

        [Parameter(ParameterSetName = ResourceIdParameterSet, ValueFromPipelineByPropertyName = true, Mandatory = true, HelpMessage = "ARM Id of Redis Cache.")]
        [ValidateNotNullOrEmpty]
        public string ResourceId { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true, HelpMessage = "Name of firewall rule.")]
        [ValidateNotNullOrEmpty]
        public string RuleName { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true, HelpMessage = "Starting IP address.")]
        [ValidateNotNullOrEmpty]
        public string StartIP { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true, HelpMessage = "Ending IP address.")]
        [ValidateNotNullOrEmpty]
        public string EndIP { get; set; }

        public override void ExecuteCmdlet()
        {
            // In case of piped parent object "RedisCacheAttributes" fetch ResourceGroupName and Name from it
            if (ParameterSetName.Equals(InputObjectParameterSet))
            {
                FetchResourceGroupNameAndNameFromInputObject();
            }
            else if (ParameterSetName.Equals(ResourceIdParameterSet))
            {
                FetchResourceGroupNameAndNameFromResourceId();
            }

            Utility.ValidateResourceGroupAndResourceName(ResourceGroupName, Name);
            ResourceGroupName = CacheClient.GetResourceGroupNameIfNotProvided(ResourceGroupName, Name);

            ConfirmAction(
                string.Format(Resources.CreatingFirewallRule, Name),
                Name,
                () =>
                {
                    RedisFirewallRule redisFirewallRule = CacheClient.SetFirewallRule(
                        resourceGroupName: ResourceGroupName,
                        cacheName: Name,
                        ruleName: RuleName,
                        startIP: StartIP,
                        endIP: EndIP);

                    if (redisFirewallRule == null)
                    {
                        throw new CloudException(string.Format(Resources.FirewallRuleCreationFailed));
                    }
                    WriteObject(new PSRedisFirewallRule(ResourceGroupName, Name, redisFirewallRule));
                }
            );
        }

        private void FetchResourceGroupNameAndNameFromInputObject()
        {
            ResourceGroupName = InputObject.ResourceGroupName;
            Name = InputObject.Name;
        }

        private void FetchResourceGroupNameAndNameFromResourceId()
        {
            ResourceGroupName = Utility.GetResourceGroupNameFromRedisCacheId(ResourceId);
            Name = Utility.GetRedisCacheNameFromRedisCacheId(ResourceId);
        }
    }
}