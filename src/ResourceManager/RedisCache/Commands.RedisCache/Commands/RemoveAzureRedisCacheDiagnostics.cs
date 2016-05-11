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
    using Microsoft.Azure.Management.Redis.Models;
    using System.Management.Automation;
    using System;
    using Microsoft.Azure.Commands.RedisCache.Models;

    [Cmdlet(VerbsCommon.Remove, "AzureRmRedisCacheDiagnostics"), OutputType(typeof(void))]
    public class RemoveAzureRedisCacheDiagnostics : RedisCacheCmdletBase
    {
        [Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true, HelpMessage = "Name of resource group under which cache exists.")]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true, HelpMessage = "Name of redis cache.")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Do not ask for confirmation.")]
        public SwitchParameter Force { get; set; }

        public override void ExecuteCmdlet()
        {
            RedisCacheAttributes cache = new RedisCacheAttributes(CacheClient.GetCache(ResourceGroupName, Name), ResourceGroupName);
            if (!Force.IsPresent)
            {
                ConfirmAction(
                Force.IsPresent,
                string.Format(Resources.RemovingRedisCacheDiagnostics, Name),
                string.Format(Resources.RemoveRedisCacheDiagnostics, Name),
                Name,
                () => CacheClient.SetDiagnostics(cache.Id, null));
            }
            else
            {
                CacheClient.SetDiagnostics(cache.Id, null);
            }
        }
    }
}