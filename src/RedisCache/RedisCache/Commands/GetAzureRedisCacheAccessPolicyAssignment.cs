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
    using System.Collections.Generic;
    using System.Management.Automation;
    using Rest.Azure;
    using ResourceManager.Common.ArgumentCompleters;
    using Microsoft.Azure.Management.RedisCache.Models;

    [Cmdlet("Get", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "RedisCacheAccessPolicyAssignment", DefaultParameterSetName = NormalParameterSet), OutputType(typeof(PSRedisAccessPolicyAssignment))]
    public class GetAzureRedisCacheAccessPolicyAssignment : RedisCacheCmdletBase
    {
        private const string NormalParameterSet = "NormalParameterSet";
        private const string ParentObjectParameterSet = "CacheObjectParameterSet";
        private const string ResourceIdParameterSet = "ResourceIdParameterSet";

        [Parameter(ParameterSetName = NormalParameterSet, ValueFromPipelineByPropertyName = true, Mandatory = false, HelpMessage = "Name of resource group in which cache exists.")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(ParameterSetName = NormalParameterSet, ValueFromPipelineByPropertyName = true, Mandatory = true, HelpMessage = "Name of Redis Cache.")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(ParameterSetName = ResourceIdParameterSet, ValueFromPipelineByPropertyName = true, Mandatory = true, HelpMessage = "ARM Id of Redis Cache Access Policy Assignment")]
        [ValidateNotNullOrEmpty]
        public string ResourceId { get; set; }

        [Parameter(ParameterSetName = ParentObjectParameterSet, Mandatory = true, ValueFromPipeline = true, HelpMessage = "Object of type RedisCacheAttributes")]
        [ValidateNotNull]
        public RedisCacheAttributes TopLevelResourceObject { get; set; }

        [Parameter(ParameterSetName = NormalParameterSet, ValueFromPipelineByPropertyName = true, Mandatory = false, HelpMessage = "Name of Access Policy Assignment.")]
        [Parameter(ParameterSetName = ParentObjectParameterSet, ValueFromPipelineByPropertyName = true, Mandatory = false, HelpMessage = "Name of Access Policy Assignment.")]
        public string AccessPolicyAssignmentName { get; set; }        

        public override void ExecuteCmdlet()
        {
            if (ParameterSetName.Equals(ParentObjectParameterSet))
            {
                FetchResourceGroupNameAndCacheNameFromParentObject();
            }
            else if (ParameterSetName.Equals(ResourceIdParameterSet))
            {
                FetchDetailsFromChildResourceId();
            }
            Utility.ValidateResourceGroupAndResourceName(ResourceGroupName, Name);
            ResourceGroupName = CacheClient.GetResourceGroupNameIfNotProvided(ResourceGroupName, Name);

            if (!string.IsNullOrEmpty(AccessPolicyAssignmentName))
            {
                RedisCacheAccessPolicyAssignment redisAccessPolicyAssignment = CacheClient.GetAccessPolicyAssignment(ResourceGroupName, Name, AccessPolicyAssignmentName);

                if (redisAccessPolicyAssignment == null)
                {
                    throw new CloudException(string.Format(Resources.AccessPolicyAssignmentNotFound, Name, AccessPolicyAssignmentName));
                }
                WriteObject(new PSRedisAccessPolicyAssignment(ResourceGroupName, Name, redisAccessPolicyAssignment));
            }
            else
            {
                IPage<RedisCacheAccessPolicyAssignment> response = CacheClient.ListAccessPolicyAssignments(ResourceGroupName, Name);
                List<PSRedisAccessPolicyAssignment> list = new List<PSRedisAccessPolicyAssignment>();
                foreach (RedisCacheAccessPolicyAssignment redisAccessPolicyAssignment in response)
                {
                    list.Add(new PSRedisAccessPolicyAssignment(ResourceGroupName, Name, redisAccessPolicyAssignment));
                }
                
                while (!string.IsNullOrEmpty(response.NextPageLink))
                {
                    response = CacheClient.ListAccessPolicyAssignments(response.NextPageLink);
                    foreach (RedisCacheAccessPolicyAssignment redisAccessPolicyAssignment in response)
                    {
                        list.Add(new PSRedisAccessPolicyAssignment(ResourceGroupName, Name, redisAccessPolicyAssignment));
                    }
                }
                WriteObject(list, true);
            }
        }
        private void FetchDetailsFromChildResourceId()
        {
            (ResourceGroupName, Name, AccessPolicyAssignmentName) = Utility.GetDetailsFromRedisCacheChildResourceId(ResourceId);
        }
        private void FetchResourceGroupNameAndCacheNameFromParentObject()
        {
            ResourceGroupName = TopLevelResourceObject.ResourceGroupName;
            Name = TopLevelResourceObject.Name;
        }
    }
}
