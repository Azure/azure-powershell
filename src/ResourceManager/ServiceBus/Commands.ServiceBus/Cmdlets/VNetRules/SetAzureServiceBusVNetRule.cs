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

using Microsoft.Azure.Commands.ServiceBus.Models;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.ServiceBus.Commands.serviceBus
{
    /// <summary>
    /// 'Set-AzureRmServiceBusVNetRule' Cmdlet updates the specified VNetRule
    /// </summary>
    [Cmdlet("Set", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "ServiceBusVNetRule", DefaultParameterSetName = VnetRulePropertiesParameterSet, SupportsShouldProcess = true), OutputType(typeof(PSVirtualNetWorkRuleAttributes))]
    public class SetAzureServiceBusVNetRule : AzureServiceBusCmdletBase
    {
        [Parameter(Mandatory = true, ParameterSetName = VnetRulePropertiesParameterSet, Position = 0, HelpMessage = "Resource Group Name")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
         public string ResourceGroupName { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = VnetRulePropertiesParameterSet, Position = 1, HelpMessage = "Namespace Name")]
        [ValidateNotNullOrEmpty]
        [Alias(AliasNamespaceName)]
        public string Namespace { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = VnetRulePropertiesParameterSet, Position = 2, HelpMessage = "Virtual Network Rule Name")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = VnetRuleInputObjectParameterSet, ValueFromPipeline = true, HelpMessage = "Virtual Network Rule Object")]
        [ValidateNotNullOrEmpty]
        public PSVirtualNetWorkRuleAttributes InputObject { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = VnetRuleResourceIdParameterSet, ValueFromPipelineByPropertyName = true, Position = 0, HelpMessage = "Virtual Network Rule Resource Id")]
        [ValidateNotNullOrEmpty]
        public string ResourceId { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "ARM ID of Virtual Network Subnet")]
        [ValidateNotNullOrEmpty]
        public string VirtualNetworkSubnetId { get; set; }

        public override void ExecuteCmdlet()
        {
            PSVirtualNetWorkRuleAttributes vnetrule = new PSVirtualNetWorkRuleAttributes();

            if (ParameterSetName.Equals(VnetRuleInputObjectParameterSet))
            {
                LocalResourceIdentifier identifier = new LocalResourceIdentifier(InputObject.Id);
                ResourceGroupName = identifier.ResourceGroupName;
                Namespace = identifier.ParentResource;
                Name = identifier.ResourceName;
                VirtualNetworkSubnetId = InputObject.VirtualNetworkSubnetId;
            }
            else if (ParameterSetName.Equals(VnetRuleResourceIdParameterSet))
            {
                LocalResourceIdentifier identifier = new LocalResourceIdentifier(ResourceId);
                ResourceGroupName = identifier.ResourceGroupName;
                Namespace = identifier.ParentResource;
                Name = identifier.ResourceName;
            }

            if (!string.IsNullOrEmpty(VirtualNetworkSubnetId))
            {
                vnetrule.VirtualNetworkSubnetId = VirtualNetworkSubnetId;
            }

            if (ShouldProcess(target:Name, action: string.Format(Resources.UpdateIpVNetRule,Name,Namespace)))
            {
                try
                {
                    WriteObject(Client.CreateOrUpdateVNetRule(ResourceGroupName, Namespace, Name, vnetrule));
                }
                catch (Management.ServiceBus.Models.ErrorResponseException ex)
                {
                    WriteError(ServiceBus.ServiceBusClient.WriteErrorforBadrequest(ex));
                }
            }
        }
    }
}
