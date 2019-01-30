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

using System.Management.Automation;
using Microsoft.Azure.Commands.ServiceBus.Models;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;

namespace Microsoft.Azure.Commands.ServiceBus.Commands.Migration
{
    /// <summary>
    /// 'Remove-AzServicebusMigrationConfiguration' Cmdlet Deletes Migration Coinfiguration)
    /// </summary>
    [Cmdlet("Remove", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "ServiceBusMigration", DefaultParameterSetName = MigrationConfigurationParameterSet, SupportsShouldProcess = true), OutputType(typeof(bool))]
    public class RemoveAzureServiceBusMigrationConfiguration : AzureServiceBusCmdletBase
    {
        [Parameter(Mandatory = true, ParameterSetName = MigrationConfigurationParameterSet, Position = 0, HelpMessage = "Resource Group Name")]
        [ValidateNotNullOrEmpty]
        [ResourceGroupCompleter]
        public string ResourceGroupName { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = MigrationConfigurationParameterSet, Position = 1, HelpMessage = "Standard Namespace Name")]
        [ValidateNotNullOrEmpty]   
        public string Name { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = NamespaceInputObjectParameterSet, ValueFromPipeline = true, Position = 0, HelpMessage = "Service Bus Migration Standard Namespace Object")]
        [ValidateNotNullOrEmpty]
        public PSServiceBusDRConfigurationAttributes InputObject { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = NamespaceResourceIdParameterSet, ValueFromPipelineByPropertyName = true, Position = 0, HelpMessage = "Service Bus Migration Standard Namespace Resource Id")]
        [ValidateNotNullOrEmpty]
        public string ResourceId { get; set; }

        [Parameter(Mandatory = false)]
        public SwitchParameter PassThru { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Run cmdlet in the background")]
        public SwitchParameter AsJob { get; set; }

        public override void ExecuteCmdlet()
        {
            if (ParameterSetName == NamespaceInputObjectParameterSet)
            {
                LocalResourceIdentifier Identifier = new LocalResourceIdentifier(InputObject.Id);

                ResourceGroupName = Identifier.ResourceGroupName;
                Name = Identifier.ResourceName;                
            }
            else if (ParameterSetName == NamespaceResourceIdParameterSet)
            {
                LocalResourceIdentifier Identifier = new LocalResourceIdentifier(ResourceId);

                ResourceGroupName = Identifier.ResourceGroupName;
                Name = Identifier.ResourceName;
            }

            if (ShouldProcess(target: Name, action: string.Format(Resources.RemoveMigrationConfiguration)))
            {
                try
                {
                    Client.DeleteServiceBusMigrationConfiguration(ResourceGroupName, Name);
                    if (PassThru)
                    {
                        WriteObject(true);
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
