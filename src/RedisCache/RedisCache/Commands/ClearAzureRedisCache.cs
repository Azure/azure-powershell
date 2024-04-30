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
    using ResourceManager.Common.ArgumentCompleters;
    using System.Management.Automation;

    [Cmdlet("Clear", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "RedisCache", DefaultParameterSetName = NormalParameterSet, SupportsShouldProcess = true), OutputType(typeof(bool))]
    public class ClearAzureRedisCache : RedisCacheCmdletBase
    {
        private const string NormalParameterSet = "NormalParameterSet";
        private const string InputObjectParameterSet = "RedisCacheAccessPolicyObject";
        private const string ResourceIdParameterSet = "ResourceIdParameterSet";

        [Parameter(ParameterSetName = NormalParameterSet, ValueFromPipelineByPropertyName = true, Mandatory = false, HelpMessage = "Name of resource group under which cache exists.")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(ParameterSetName = NormalParameterSet, ValueFromPipelineByPropertyName = true, Mandatory = true, HelpMessage = "Name of redis cache.")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(ParameterSetName = ResourceIdParameterSet, ValueFromPipelineByPropertyName = true, Mandatory = true, HelpMessage = "ARM Id of Redis Cache")]
        [ValidateNotNullOrEmpty]
        public string ResourceId { get; set; }

        [Parameter(ParameterSetName = InputObjectParameterSet, Mandatory = true, ValueFromPipeline = true, HelpMessage = "Object of type RedisCacheAttributes")]
        [ValidateNotNull]
        public RedisCacheAttributes InputObject { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Do not ask for confirmation.")]
        public SwitchParameter Force { get; set; }

        [Parameter(Mandatory = false)]
        public SwitchParameter PassThru { get; set; }

        public override void ExecuteCmdlet()
        {
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
                Force.IsPresent,
                string.Format(Resources.FlushingRedisCache, Name),
                string.Format(Resources.FlushRedisCache, Name),
                Name,
                () => CacheClient.FlushCache(ResourceGroupName, Name));

            if (PassThru)
            {
                WriteObject(true);
            }
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
