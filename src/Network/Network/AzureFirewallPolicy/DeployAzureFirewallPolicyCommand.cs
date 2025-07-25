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

using System;
using System.Management.Automation;
using Microsoft.Azure.Commands.Network.Models;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;
using Microsoft.Azure.Management.Network;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using Microsoft.Azure.Management.Network.Models;

namespace Microsoft.Azure.Commands.Network
{
    [Cmdlet("Deploy", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "FirewallPolicy", SupportsShouldProcess = true, DefaultParameterSetName = DeployByNameParameterSet), OutputType(typeof(PSAzureFirewallPolicy))]
    public class DeployAzureFirewallPolicyCommand : AzureFirewallPolicyBaseCmdlet
    {
        private const string DeployByNameParameterSet = "DeployByNameParameterSet";
        private const string DeployByResourceIdParameterSet = "DeployByResourceIdParameterSet";
        private const string DeployByInputObjectParameterSet = "DeployByInputObjectParameterSet";


        [Alias("ResourceName")]
        [Parameter(
           Mandatory = true,
           ValueFromPipelineByPropertyName = true,
           HelpMessage = "The resource name.", ParameterSetName = DeployByNameParameterSet)]
        [ResourceNameCompleter("Microsoft.Network/azureFirewalls", "ResourceGroupName")]
        [ValidateNotNullOrEmpty]
        [SupportsWildcards]
        public virtual string Name { get; set; }

        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The resource group name.", ParameterSetName = DeployByNameParameterSet)]
        [ValidateNotNullOrEmpty]
        [SupportsWildcards]
        public virtual string ResourceGroupName { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Run cmdlet in the background")]
        public SwitchParameter AsJob { get; set; }

        [Parameter(
                    Mandatory = true,
                    ValueFromPipelineByPropertyName = true,
                    HelpMessage = "The resource Id.", ParameterSetName = DeployByResourceIdParameterSet)]
        [ValidateNotNullOrEmpty]
        [SupportsWildcards]
        public virtual string ResourceId { get; set; }

        [Parameter(
           Mandatory = true,
           ValueFromPipelineByPropertyName = true,
           HelpMessage = "The resource.", ParameterSetName = DeployByInputObjectParameterSet)]
        [ValidateNotNullOrEmpty]
        public PSAzureFirewallPolicy InputObject { get; set; }

        public override void Execute()
        {
            base.Execute();

            if (this.IsParameterBound(c => c.InputObject))
            {
                this.ResourceGroupName = InputObject.ResourceGroupName;
                this.Name = InputObject.Name;
            }

            else if (this.IsParameterBound(c => c.ResourceId))
            {
                var resourceInfo = new ResourceIdentifier(ResourceId);
                this.ResourceGroupName = resourceInfo.ResourceGroupName;
                this.Name = resourceInfo.ResourceName;
            }            
            if (!NetworkBaseCmdlet.IsResourcePresent(() => GetAzureFirewallPolicy(ResourceGroupName, Name)))
            {
                throw new ArgumentException(Properties.Resources.ResourceNotFound);
            }
          
            this.AzureFirewallPolicyDeploymentsClient.Deploy(this.ResourceGroupName, this.Name);
            var getAzureFirewallPolicy = this.GetAzureFirewallPolicy(ResourceGroupName, Name);
            WriteObject(getAzureFirewallPolicy);
        }
    }
}
