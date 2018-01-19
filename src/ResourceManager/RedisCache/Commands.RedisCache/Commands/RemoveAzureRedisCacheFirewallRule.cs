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

    [Cmdlet(VerbsCommon.Remove, "AzureRmRedisCacheFirewallRule", DefaultParameterSetName = NormalParameterSet, SupportsShouldProcess = true), OutputType(typeof(bool))]
    public class RemoveAzureRedisCacheFirewallRule : RedisCacheCmdletBase
    {
        private const string NormalParameterSet = "NormalParameterSet";
        private const string InputObjectParameterSet = "PSRedisFirewallRuleObject";

        [Parameter(ParameterSetName = NormalParameterSet, ValueFromPipelineByPropertyName = true, Mandatory = false, HelpMessage = "Name of resource group in which cache exists.")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(ParameterSetName = NormalParameterSet, ValueFromPipelineByPropertyName = true, Mandatory = true, HelpMessage = "Name of redis cache.")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(ParameterSetName = NormalParameterSet, ValueFromPipelineByPropertyName = true, Mandatory = true, HelpMessage = "Name of firewall rule.")]
        [ValidateNotNullOrEmpty]
        public string RuleName { get; set; }

        [Parameter(ParameterSetName = InputObjectParameterSet, Mandatory = true, ValueFromPipeline = true, HelpMessage = "Object of type PSRedisFirewallRule")]
        [ValidateNotNull]
        public PSRedisFirewallRule InputObject { get; set; }

        [Parameter(Mandatory = false)]
        public SwitchParameter PassThru { get; set; }

        public override void ExecuteCmdlet()
        {
            if (ParameterSetName.Equals(InputObjectParameterSet))
            {
                ResourceGroupName = InputObject.ResourceGroupName;
                Name = InputObject.Name;
                RuleName = InputObject.RuleName;
            }

            Utility.ValidateResourceGroupAndResourceName(ResourceGroupName, Name);
            ResourceGroupName = CacheClient.GetResourceGroupNameIfNotProvided(ResourceGroupName, Name);

            ConfirmAction(
                string.Format(Resources.RemoveFirewallRule, RuleName, Name),
                Name,
                () =>
                {
                    CacheClient.RemoveFirewallRule(ResourceGroupName, Name, RuleName);
                    if (PassThru)
                    {
                        WriteObject(true);
                    }
                });
        }
    }
}