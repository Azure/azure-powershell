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
    using ResourceManager.Common.ArgumentCompleters;
    using System.Management.Automation;
    using Rest.Azure;
    using Microsoft.Azure.Management.RedisCache.Models;
    using Microsoft.Azure.Commands.RedisCache.Models;

    [Cmdlet("New", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "RedisCacheAccessPolicy", DefaultParameterSetName = NormalParameterSet, SupportsShouldProcess = true), OutputType(typeof(PSRedisAccessPolicy))]
    public class NewAzureRedisCacheAccessPolicy : RedisCacheCmdletBase
    {
        private const string NormalParameterSet = "NormalParameterSet";
        private const string ParentObjectParameterSet = "CacheObjectParameterSet";

        [Parameter(ParameterSetName = NormalParameterSet, ValueFromPipelineByPropertyName = true, Mandatory = false, HelpMessage = "Name of resource group under which cache exists.")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(ParameterSetName = NormalParameterSet, ValueFromPipelineByPropertyName = true, Mandatory = true, HelpMessage = "Name of redis cache.")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(ParameterSetName = ParentObjectParameterSet, Mandatory = true, ValueFromPipeline = true, HelpMessage = "Object of type RedisCacheAttributes")]
        [ValidateNotNull]
        public RedisCacheAttributes TopLevelResourceObject { get; set; }

        [Parameter(Mandatory = true, HelpMessage = "The name of the access policy that is being added to the Redis cache.")]
        [ValidateNotNullOrEmpty]
        public string AccessPolicyName { get; set; }

        [Parameter(Mandatory = true, HelpMessage = "Permissions for the access policy. Learn how to configure permissions at https://aka.ms/redis/AADPreRequisites")]
        [ValidateNotNullOrEmpty]
        public string Permission { get; set; }

        public override void ExecuteCmdlet()
        {
            if (ParameterSetName.Equals(ParentObjectParameterSet))
            {
                FetchResourceGroupNameAndCacheNameFromParentObject();
            }
            Utility.ValidateResourceGroupAndResourceName(ResourceGroupName, Name);
            ResourceGroupName = CacheClient.GetResourceGroupNameIfNotProvided(ResourceGroupName, Name);

            ConfirmAction(
                string.Format(Resources.CreateAccessPolicy, AccessPolicyName, Name),
                Name,
                () =>
                {
                    RedisCacheAccessPolicy redisAccessPolicy = CacheClient.SetAccessPolicy(ResourceGroupName, Name, AccessPolicyName, Permission);
                    if (redisAccessPolicy == null)
                    {
                        throw new CloudException(string.Format(Resources.AccessPolicyCreationFailed));
                    }
                    WriteObject(new PSRedisAccessPolicy(ResourceGroupName, Name, redisAccessPolicy));
                }
            );
        }
        private void FetchResourceGroupNameAndCacheNameFromParentObject()
        {
            ResourceGroupName = TopLevelResourceObject.ResourceGroupName;
            Name = TopLevelResourceObject.Name;
        }
    }
}