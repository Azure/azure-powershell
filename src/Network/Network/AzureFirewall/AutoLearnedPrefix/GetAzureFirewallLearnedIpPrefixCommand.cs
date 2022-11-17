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
// --------

using System;
using System.Collections.Generic;
using System.Management.Automation;
using Microsoft.Azure.Commands.Network.Models;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Management.Network;
using Microsoft.Azure.Management.Network.Models;


namespace Microsoft.Azure.Commands.Network
{
    [Cmdlet(VerbsCommon.Get, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "FirewallLearnedIpPrefix"), OutputType(typeof(PSAzureFirewallIpPrefix), typeof(IEnumerable<PSAzureFirewallIpPrefix>))]
    public class GetAzureFirewallLearnedIpPrefixCommand : AzureFirewallBaseCmdlet
    {
        [Alias("ResourceName")]
        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The firewall resource name.")]
        [ResourceNameCompleter("Microsoft.Network/azureFirewalls", "ResourceGroupName")]
        [ValidateNotNullOrEmpty]
        [SupportsWildcards]
        public string Name { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The resource group name.")]
        [ValidateNotNullOrEmpty]
        [SupportsWildcards]
        public virtual string ResourceGroupName { get; set; }
        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();
            if (ShouldGetByName(ResourceGroupName, Name))
            {
                var learnedIPPrefixes = this.AzureFirewallClient.ListLearnedPrefixes(this.ResourceGroupName, this.Name);
                var pslearnedIPPrefixes = new PSAzureFirewallIpPrefix();
                if (learnedIPPrefixes != null)
                {
                    pslearnedIPPrefixes = NetworkResourceManagerProfile.Mapper.Map<PSAzureFirewallIpPrefix>(learnedIPPrefixes);
                }
                WriteObject(pslearnedIPPrefixes);
            }
            else
            {
                throw new ArgumentException($" Name and ResourceGroupName should be provided to get firewall learned IP prefixes.");
            }
        }
    }
}
