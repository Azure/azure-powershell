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

using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Management.Network;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Network
{
    [Cmdlet("Remove", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "NetworkManagerSecurityAdminRule", SupportsShouldProcess = true), OutputType(typeof(bool))]
    public class RemoveAzNetworkManagerSecurityAdminRuleCommand : NetworkManagerSecurityAdminRuleBaseCmdlet
    {
        [Alias("ResourceName")]
        [Parameter(
     Mandatory = true,
     ValueFromPipelineByPropertyName = true,
     HelpMessage = "The resource name.")]
        [ValidateNotNullOrEmpty]
        [ResourceNameCompleter("Microsoft.Network/networkManagers/securityAdminConfigurations/ruleCollections/rules", "ResourceGroupName", "NetworkManagerName", "SecurityAdminConfigurationName", "RuleCollectionName")]
        [SupportsWildcards]
        public string Name { get; set; }

        [Parameter(
           Mandatory = true,
           ValueFromPipelineByPropertyName = true,
           HelpMessage = "The network manager security admin rule collection name.")]
        [ValidateNotNullOrEmpty]
        [ResourceNameCompleter("Microsoft.Network/networkManagers/securityAdminConfigurations/ruleCollections", "ResourceGroupName", "NetworkManagerName", "SecurityAdminConfigurationName")]
        [SupportsWildcards]
        public virtual string RuleCollectionName { get; set; }

        [Alias("ConfigName")]
        [Parameter(
           Mandatory = true,
           ValueFromPipelineByPropertyName = true,
           HelpMessage = "The network manager security admin configuration name.")]
        [ValidateNotNullOrEmpty]
        [ResourceNameCompleter("Microsoft.Network/networkManagers/securityAdminConfigurations", "ResourceGroupName", "NetworkManagerName")]
        [SupportsWildcards]
        public virtual string SecurityAdminConfigurationName { get; set; }

        [Parameter(
           Mandatory = true,
           ValueFromPipelineByPropertyName = true,
           HelpMessage = "The network manager name.")]
        [ValidateNotNullOrEmpty]
        [ResourceNameCompleter("Microsoft.Network/networkManagers", "ResourceGroupName")]
        [SupportsWildcards]
        public virtual string NetworkManagerName { get; set; }

        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The resource group name.")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public virtual string ResourceGroupName { get; set; }

        [Parameter(
           Mandatory = false,
           HelpMessage = "Deletes the resource even if it is part of a deployed configuration. If the configuration has been deployed, the service will do a cleanup deployment in the background, prior to the delete.")]
        public SwitchParameter ForceDelete { get; set; }

        [Parameter(
           Mandatory = false,
           HelpMessage = "Do not ask for confirmation.")]
        public SwitchParameter Force { get; set; }

        [Parameter(Mandatory = false)]
        public SwitchParameter PassThru { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Run cmdlet in the background")]
        public SwitchParameter AsJob { get; set; }

        public override void Execute()
        {
            base.Execute();
            ConfirmAction(
                Force.IsPresent,
                string.Format(Properties.Resources.RemovingResource, Name),
                Properties.Resources.RemoveResourceMessage,
                Name,
                () =>
                {
                    bool forceDelete = false;
                    if (ForceDelete.IsPresent)
                    {
                        forceDelete = true;
                    }
                    this.NetworkManagerSecurityAdminRuleOperationClient.Delete(this.ResourceGroupName, this.NetworkManagerName, this.SecurityAdminConfigurationName, this.RuleCollectionName, this.Name, forceDelete);
                    if (PassThru.IsPresent)
                    {
                        WriteObject(true);
                    }
                });
        }
    }
}
