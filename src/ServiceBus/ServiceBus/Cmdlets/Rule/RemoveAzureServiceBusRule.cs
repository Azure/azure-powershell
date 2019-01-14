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
namespace Microsoft.Azure.Commands.ServiceBus.Commands.Rule
{
    /// <summary>
    /// 'Remove-AzServiceBusRule' Cmdlet removes the specified Rule
    /// </summary>
    [Cmdlet("Remove", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "ServiceBusRule", DefaultParameterSetName = RuleResourceParameterSet, SupportsShouldProcess = true), OutputType(typeof(bool))]
    public class RemoveAzureRmServiceBusRule : AzureServiceBusCmdletBase
    {
        [Parameter(Mandatory = true, ParameterSetName = RuleResourceParameterSet, ValueFromPipelineByPropertyName = true, Position = 0, HelpMessage = "The name of the resource group")]
        [ResourceGroupCompleter]
        [Alias("ResourceGroup")]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = RuleResourceParameterSet, ValueFromPipelineByPropertyName = true, Position = 1, HelpMessage = "Namespace Name")]
        [Alias(AliasNamespaceName)]
        [ValidateNotNullOrEmpty]
        public string Namespace { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = RuleResourceParameterSet, ValueFromPipelineByPropertyName = true, Position = 2, HelpMessage = "Topic Name")]
        [Alias(AliasTopicName)]
        [ValidateNotNullOrEmpty]
        public string Topic { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = RuleResourceParameterSet, ValueFromPipelineByPropertyName = true, Position = 3, HelpMessage = "Subscription Name")]
        [Alias(AliasSubscriptionName)]
        [ValidateNotNullOrEmpty]
        public string Subscription { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = RuleResourceParameterSet, ValueFromPipelineByPropertyName = true, Position = 4, HelpMessage = "Rule Name")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = RuleInputObjectParameterSet, ValueFromPipeline = true, Position = 0, HelpMessage = "Service Bus Rule Object")]
        [ValidateNotNullOrEmpty]
        public PSTopicAttributes InputObject { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = RuleResourceIdParameterSet, ValueFromPipelineByPropertyName = true, Position = 0, HelpMessage = "Service Bus Rule Resource Id")]
        [ValidateNotNullOrEmpty]
        public string ResourceId { get; set; }

        [Parameter(Mandatory = false)]
        public SwitchParameter PassThru { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Run cmdlet in the background")]
        public SwitchParameter AsJob { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Do not ask for confirmation.")]
        public SwitchParameter Force { get; set; }
                
        public override void ExecuteCmdlet()
        {
            if (ParameterSetName.Equals(RuleInputObjectParameterSet))
            {
                LocalResourceIdentifier identifier = new LocalResourceIdentifier(InputObject.Id);

                ResourceGroupName = identifier.ResourceGroupName;
                Namespace = identifier.ParentResource;
                Topic = Namespace = identifier.ParentResource1;
                Subscription = Namespace = identifier.ParentResource2;
                Name = Namespace = identifier.ResourceName;
            }

            if (ParameterSetName.Equals(RuleResourceIdParameterSet))
            {
                LocalResourceIdentifier identifier = new LocalResourceIdentifier(ResourceId);

                ResourceGroupName = identifier.ResourceGroupName;
                Namespace = identifier.ParentResource;
                Topic = Namespace = identifier.ParentResource1;
                Subscription = Namespace = identifier.ParentResource2;
                Name = Namespace = identifier.ResourceName;
            }

            try
            {
                // delete a Rule            
                ConfirmAction(
                    Force.IsPresent,
                    string.Format(Resources.RemoveRule, Name, Subscription, Namespace),
                    string.Format(Resources.RemoveRule, Name, Subscription, Namespace),
                    Name,
                    () =>
                    {
                        var result = Client.DeleteRule(ResourceGroupName, Namespace, Topic, Subscription, Name);

                        if (PassThru)
                        {
                            WriteObject(result);
                        }
                    });
            }
            catch (Management.ServiceBus.Models.ErrorResponseException ex)
            {
                WriteError(ServiceBusClient.WriteErrorforBadrequest(ex));
            }
        }
    }
}
