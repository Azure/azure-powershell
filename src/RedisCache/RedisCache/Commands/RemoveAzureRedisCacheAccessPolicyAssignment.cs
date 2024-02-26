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

    [Cmdlet("Remove", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "RedisCacheAccessPolicyAssignment", DefaultParameterSetName = NormalParameterSet, SupportsShouldProcess = true), OutputType(typeof(bool))]
    public class RemoveAzureRedisCacheAccessPolicyAssignment : RedisCacheCmdletBase
    {
        private const string NormalParameterSet = "NormalParameterSet";
        private const string ParentObjectParameterSet = "CacheObjectParameterSet";
        private const string InputObjectParameterSet = "RedisCacheAccessPolicyAssignmentObject";
        private const string ResourceIdParameterSet = "ResourceIdParameterSet";

        [Parameter(ParameterSetName = NormalParameterSet, ValueFromPipelineByPropertyName = true, Mandatory = false, HelpMessage = "Name of resource group in which cache exists.")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(ParameterSetName = NormalParameterSet, ValueFromPipelineByPropertyName = true, Mandatory = true, HelpMessage = "Name of Redis Cache.")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(ParameterSetName = NormalParameterSet, ValueFromPipelineByPropertyName = true, Mandatory = true, HelpMessage = "The name of the Access Policy Assignment that is being deleted from the Redis cache.")]
        [Parameter(ParameterSetName = ParentObjectParameterSet, ValueFromPipelineByPropertyName = true, Mandatory = true, HelpMessage = "The name of the Access Policy Assignment that is being deleted from the Redis cache.")]
        [ValidateNotNullOrEmpty]
        public string AccessPolicyAssignmentName { get; set; }

        [Parameter(ParameterSetName = ResourceIdParameterSet, ValueFromPipelineByPropertyName = true, Mandatory = true, HelpMessage = "ARM Id of Redis Cache Access Policy Assignment")]
        [ValidateNotNullOrEmpty]
        public string ResourceId { get; set; }

        [Parameter(ParameterSetName = InputObjectParameterSet, Mandatory = true, ValueFromPipeline = true, HelpMessage = "Object of type PSRedisAccessPolicyAssignment")]
        [ValidateNotNull]
        public PSRedisAccessPolicyAssignment InputObject { get; set; }

        [Parameter(ParameterSetName = ParentObjectParameterSet, Mandatory = true, ValueFromPipeline = true, HelpMessage = "Object of type RedisCacheAttributes")]
        [ValidateNotNull]
        public RedisCacheAttributes TopLevelResourceObject { get; set; }

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
                string.Format(Resources.RemoveAccessPolicyAssignment, AccessPolicyAssignmentName, Name),
                Name,
                () =>
                {
                    CacheClient.RemoveAccessPolicyAssignment(ResourceGroupName, Name, AccessPolicyAssignmentName);
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
            AccessPolicyAssignmentName = InputObject.AccessPolicyAssignmentName;
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
