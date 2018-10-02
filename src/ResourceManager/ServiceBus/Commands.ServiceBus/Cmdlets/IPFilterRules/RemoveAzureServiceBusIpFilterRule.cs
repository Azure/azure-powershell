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
using System.Management.Automation;
using Microsoft.Azure.Commands.ServiceBus.Models;

namespace Microsoft.Azure.Commands.ServiceBus.Commands.serviceBus
{
    /// <summary>
    /// 'Remove-AzureRmServiceBusIPFilterRule' Cmdlet removes the specified ServiceBus namespace
    /// </summary>
    [Cmdlet("Remove", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "ServiceBusIPFilterRule", DefaultParameterSetName = IpFilterRulePropertiesParameterSet, SupportsShouldProcess = true), OutputType(typeof(bool))]
    public class RemoveAzureServiceBusIpFilterRule : AzureServiceBusCmdletBase
    {
        [Parameter(Mandatory = true, ParameterSetName = IpFilterRulePropertiesParameterSet, Position = 0, HelpMessage = "Resource Group Name")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
         public string ResourceGroupName { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = IpFilterRulePropertiesParameterSet, Position = 1, HelpMessage = "Namespace Name")]
        [ValidateNotNullOrEmpty]
        [Alias(AliasNamespaceName)]
        public string Namespace { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = IpFilterRulePropertiesParameterSet, Position = 2, HelpMessage = "Ip Filter Rule Name")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = IpFilterRuleInputObjectParameterSet, ValueFromPipeline = true, Position = 0, HelpMessage = "Ip Filter Rule Object")]
        [ValidateNotNullOrEmpty]
        public PSIpFilterRuleAttributes InputObject { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = IpFilterRuleResourceIdParameterSet, ValueFromPipelineByPropertyName = true, Position = 0, HelpMessage = "Ip Filter Rule Resource Id")]
        [ValidateNotNullOrEmpty]
        public string ResourceId { get; set; }

        [Parameter(Mandatory = false)]
        public SwitchParameter PassThru { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Run cmdlet in the background")]
        public SwitchParameter AsJob { get; set; }

        public override void ExecuteCmdlet()
        {

            if (ParameterSetName.Equals(IpFilterRuleInputObjectParameterSet))
            {
                LocalResourceIdentifier identifier = new LocalResourceIdentifier(InputObject.Id);
                ResourceGroupName = identifier.ResourceGroupName;
                Namespace = identifier.ParentResource;
                Name = identifier.ResourceName;
            }
            else if (ParameterSetName.Equals(IpFilterRuleResourceIdParameterSet))
            {
                LocalResourceIdentifier identifier = new LocalResourceIdentifier(ResourceId);
                ResourceGroupName = identifier.ResourceGroupName;
                Namespace = identifier.ParentResource;
                Name = identifier.ResourceName;
            }

            // delete a Ip Filter Rule 
            if (ShouldProcess(target:Name, action:string.Format(Resources.RemoveIpFilterRule,Name,Namespace)))
            {
                try
                {
                    var result = Client.DeleteIPFilterRule(ResourceGroupName, Namespace, Name);

                    if (PassThru.IsPresent)
                    {
                        WriteObject(result);
                    }
                }
                catch (Management.ServiceBus.Models.ErrorResponseException ex)
                {
                    WriteError(ServiceBus.ServiceBusClient.WriteErrorforBadrequest(ex));
                }
            }            
        }
    }
}
