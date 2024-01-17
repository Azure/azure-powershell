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

    [Cmdlet("New", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "RedisCacheAccessPolicyAssignment", DefaultParameterSetName = NormalParameterSet, SupportsShouldProcess = true), OutputType(typeof(PSRedisAccessPolicyAssignment))]
    public class NewAzureRedisCacheAccessPolicyAssignment : RedisCacheCmdletBase
    {
        private const string NormalParameterSet = "NormalParameterSet";
        private const string InputObjectParameterSet = "RedisCacheAttributesObject";
        private const string ResourceIdParameterSet = "ResourceIdParameterSet";

        [Parameter(ParameterSetName = NormalParameterSet, ValueFromPipelineByPropertyName = true, Mandatory = false, HelpMessage = "Name of resource group under which cache exists.")]
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

        [Parameter(Mandatory = true, HelpMessage = "Name of Access Policy Assignment being added to the cache.")]
        public string AccessPolicyAssignmentName { get; set; }

        [Parameter(Mandatory = true, HelpMessage = "Name of Access Policy.")]
        public string AccessPolicyName { get; set; }

        [Parameter(Mandatory = true, HelpMessage = "Name of Object Id.")]
        public string ObjectId { get; set; }

        [Parameter(Mandatory = true, HelpMessage = "Name of Object Id Alias.")]
        public string ObjectIdAlias { get; set; }

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
                string.Format(Resources.CreateAccessPolicyAssignment, AccessPolicyAssignmentName, Name),
                Name,
                () =>
                {
                    RedisCacheAccessPolicyAssignment redisAccessPolicyAssignment = CacheClient.SetAccessPolicyAssignment(
                        resourceGroupName: ResourceGroupName,
                        cacheName: Name,
                        accessPolicyAssignmentName: AccessPolicyAssignmentName,
                        accessPolicyName: AccessPolicyName,
                        objectId: ObjectId,
                        objectIdAlias: ObjectIdAlias);
                    if (redisAccessPolicyAssignment == null)
                    {
                        throw new CloudException(string.Format(Resources.AccessPolicyAssignmentCreationFailed));
                    }
                    WriteObject(new PSRedisAccessPolicyAssignment(ResourceGroupName, Name, redisAccessPolicyAssignment));
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