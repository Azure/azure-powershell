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
    using ResourceManager.Common.ArgumentCompleters;
    using System.Management.Automation;
    using Properties;
    using Models;

    [Cmdlet("Remove", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "RedisCacheAccessPolicy", DefaultParameterSetName = NormalParameterSet, SupportsShouldProcess = true), OutputType(typeof(bool))]
    public class RemoveAzureRedisCacheAccessPolicy : RedisCacheCmdletBase
    {
        private const string NormalParameterSet = "NormalParameterSet";
        private const string ParentObjectParameterSet = "CacheObjectParameterSet";
        private const string InputObjectParameterSet = "RedisCacheAccessPolicyObject";
        private const string ResourceIdParameterSet = "ResourceIdParameterSet";

        [Parameter(ParameterSetName = NormalParameterSet, ValueFromPipelineByPropertyName = true, Mandatory = false, HelpMessage = "Name of resource group in which cache exists.")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(ParameterSetName = NormalParameterSet, ValueFromPipelineByPropertyName = true, Mandatory = true, HelpMessage = "Name of redis cache.")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(ParameterSetName = ResourceIdParameterSet, ValueFromPipelineByPropertyName = true, Mandatory = true, HelpMessage = "ARM Id of Redis Cache Access Policy")]
        [ValidateNotNullOrEmpty]
        public string ResourceId { get; set; }

        [Parameter(ParameterSetName = ParentObjectParameterSet, Mandatory = true, ValueFromPipeline = true, HelpMessage = "Object of type RedisCacheAttributes")]
        [ValidateNotNull]
        public RedisCacheAttributes TopLevelResourceObject { get; set; }

        [Parameter(ParameterSetName = InputObjectParameterSet, Mandatory = true, ValueFromPipeline = true, HelpMessage = "Object of type PSRedisAccessPolicy")]
        [ValidateNotNull]
        public PSRedisAccessPolicy InputObject { get; set; }

        [Parameter(ParameterSetName = NormalParameterSet, ValueFromPipelineByPropertyName = true, Mandatory = true, HelpMessage = "The name of the access policy that is being deleted from the Redis cache.")]
        [Parameter(ParameterSetName = ParentObjectParameterSet, ValueFromPipelineByPropertyName = true, Mandatory = true, HelpMessage = "The name of the access policy that is being deleted from the Redis cache.")]
        [ValidateNotNullOrEmpty]
        public string AccessPolicyName { get; set; }

        [Parameter(Mandatory = false)]
        public SwitchParameter PassThru { get; set; }

        public override void ExecuteCmdlet()
        {
            if (ParameterSetName.Equals(ParentObjectParameterSet))
            {
                FetchResourceGroupNameAndCacheNameFromParentObject();
            }
            if (ParameterSetName.Equals(InputObjectParameterSet))
            {
                FetchDetailsFromInputObject();
            }
            else if (ParameterSetName.Equals(ResourceIdParameterSet))
            {
                FetchDetailsFromChildResourceId();
            }

            Utility.ValidateResourceGroupAndResourceName(ResourceGroupName, Name);
            ResourceGroupName = CacheClient.GetResourceGroupNameIfNotProvided(ResourceGroupName, Name);

            ConfirmAction(
                string.Format(Resources.RemoveAccessPolicy, AccessPolicyName, Name),
                Name,
                () =>
                {
                    CacheClient.RemoveAccessPolicy(ResourceGroupName, Name, AccessPolicyName);
                    if (PassThru)
                    {
                        WriteObject(true);
                    }
                });
        }
        private void FetchDetailsFromInputObject()
        {
            ResourceGroupName = InputObject.ResourceGroupName;
            Name = InputObject.Name;
            AccessPolicyName = InputObject.AccessPolicyName;
        }

        private void FetchDetailsFromChildResourceId()
        {
            (ResourceGroupName, Name, AccessPolicyName) = Utility.GetDetailsFromRedisCacheChildResourceId(ResourceId);
        }
        private void FetchResourceGroupNameAndCacheNameFromParentObject()
        {
            ResourceGroupName = TopLevelResourceObject.ResourceGroupName;
            Name = TopLevelResourceObject.Name;
        }
    }
}
