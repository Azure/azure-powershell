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
    using System;
    using System.Collections.Generic;
    using System.Management.Automation;
    using Microsoft.Azure.Commands.RedisCache.Properties;
    using Microsoft.Azure.Management.Redis.Models;
    using RebootTypeStrings = Microsoft.Azure.Management.Redis.Models.RebootType;

    [Cmdlet(VerbsCommon.Reset, "AzureRmRedisCache", SupportsShouldProcess = true), OutputType(typeof(bool))]
    public class ResetAzureRedisCache : RedisCacheCmdletBase
    {
        [Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true, HelpMessage = "Name of resource group under which cache exists.")]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true, HelpMessage = "Name of redis cache.")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true, HelpMessage = "Specifies which node to reboot.")]
        [ValidateSet(RebootTypeStrings.PrimaryNode, RebootTypeStrings.SecondaryNode, RebootTypeStrings.AllNodes, IgnoreCase = false)]
        public string RebootType { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = true, Mandatory = false, HelpMessage = "In case of cluster cache specifies which shard to reboot.")]
        public int? ShardId { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Do not ask for confirmation.")]
        public SwitchParameter Force { get; set; }

        [Parameter(Mandatory = false)]
        public SwitchParameter PassThru { get; set; }

        public override void ExecuteCmdlet()
        {
            Utility.ValidateResourceGroupAndResourceName(ResourceGroupName, Name);
            if (!Force.IsPresent)
            {
                ConfirmAction(
                Force.IsPresent,
                string.Format(Resources.RebootingRedisCache, Name, RebootType),
                string.Format(Resources.RebootRedisCache, Name),
                Name,
                () => CacheClient.RebootCache(ResourceGroupName, Name, RebootType, ShardId));
            }
            else
            {
                CacheClient.RebootCache(ResourceGroupName, Name, RebootType, ShardId);
            }

            if (PassThru)
            {
                WriteObject(true);
            }
        }
    }
}