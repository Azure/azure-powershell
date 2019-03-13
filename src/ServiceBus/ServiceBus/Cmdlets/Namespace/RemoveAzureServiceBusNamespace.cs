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
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;

namespace Microsoft.Azure.Commands.ServiceBus.Commands.Namespace
{
    /// <summary>
    /// 'Remove-AzServiceBusNamespace' Cmdlet deletes the specified ServiceBus Namespace
    /// </summary>
    [Cmdlet("Remove", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "ServiceBusNamespace", DefaultParameterSetName = NamespacePropertiesParameterSet, SupportsShouldProcess = true), OutputType(typeof(bool))]
    public class RemoveAzureRmServiceBusNamespace : AzureServiceBusCmdletBase
    {
        [Parameter(Mandatory = true, ParameterSetName = NamespacePropertiesParameterSet, ValueFromPipelineByPropertyName = true, Position = 0, HelpMessage = "The name of the resource group")]
        [ResourceGroupCompleter]
        [Alias("ResourceGroup")]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = NamespacePropertiesParameterSet, ValueFromPipelineByPropertyName = true, Position = 1, HelpMessage = "Namespace Name.")]
        [Alias(AliasNamespaceName)]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = NamespaceInputObjectParameterSet, ValueFromPipeline = true, Position = 0, HelpMessage = "Service Bus Namespace Object")]
        [ValidateNotNullOrEmpty]
        public PSNamespaceAttributes InputObject { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = NamespaceResourceIdParameterSet, ValueFromPipelineByPropertyName = true, Position = 0, HelpMessage = "Service Bus Namespace Resource Id")]
        [ValidateNotNullOrEmpty]
        public string ResourceId { get; set; }

        [Parameter(Mandatory = false)]
        public SwitchParameter PassThru { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Run cmdlet in the background")]
        public SwitchParameter AsJob { get; set; }

        public override void ExecuteCmdlet()
        {
            if (ParameterSetName.Equals(NamespaceInputObjectParameterSet))
            {
                ResourceGroupName = InputObject.ResourceGroup;
                Name = InputObject.Name;
            }
            else if (ParameterSetName.Equals(NamespaceResourceIdParameterSet))
            {
                LocalResourceIdentifier identifier = new LocalResourceIdentifier(InputObject.Id);
                ResourceGroupName = identifier.ResourceGroupName;
                Name = identifier.ResourceName;
            }

            // delete a namespace             
            if (ShouldProcess(target: Name, action: string.Format(Resources.RemoveNamespace, Name, ResourceGroupName)))
            {
                try
                {
                    var result = Client.BeginDeleteNamespace(ResourceGroupName, Name);
                    if (PassThru)
                    {
                        WriteObject(result);
                    }
                }
                catch (Management.ServiceBus.Models.ErrorResponseException ex)
                {
                    WriteError(ServiceBusClient.WriteErrorforBadrequest(ex));
                }
            }
        }
    }
}
