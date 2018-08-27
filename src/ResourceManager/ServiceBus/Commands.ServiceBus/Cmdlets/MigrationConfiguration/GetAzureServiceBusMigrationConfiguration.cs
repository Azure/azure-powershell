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

using Microsoft.Azure.Commands.ServiceBus;
using Microsoft.Azure.Commands.ServiceBus.Models;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;

namespace Microsoft.Azure.Commands.ServiceBus.Commands.Migration
{
    /// <summary>
    /// 'Get-GetAzureServiceBusMigrationConfiguration' CmdletRetrieves Migration Configuration for Standard to Premium    
    /// </summary>
    [Cmdlet("Get", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "ServiceBusMigration", DefaultParameterSetName = MigrationConfigurationParameterSet), OutputType(typeof(PSServiceBusMigrationConfigurationAttributes))]
    public class GetAzureServiceBusMigrationConfiguration : AzureServiceBusCmdletBase
    {
        [Parameter(Mandatory = true, ParameterSetName = MigrationConfigurationParameterSet, Position = 0, HelpMessage = "Resource Group Name")]
        [ValidateNotNullOrEmpty]
        [ResourceGroupCompleter]
        public string ResourceGroupName { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = MigrationConfigurationParameterSet, Position = 1, HelpMessage = "Namespace Name")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = NamespaceInputObjectParameterSet, ValueFromPipeline = true, Position = 0, HelpMessage = "Namespace Object")]
        [ValidateNotNullOrEmpty]
        public PSNamespaceAttributes InputObject { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = ResourceIdParameterSet, ValueFromPipelineByPropertyName = true, Position = 0, HelpMessage = "Namespace Resource Id")]
        [ValidateNotNullOrEmpty]
        public string ResourceId { get; set; }

        public override void ExecuteCmdlet()
        {
            
            if (ParameterSetName == NamespaceInputObjectParameterSet)
            {
                LocalResourceIdentifier getParamMigrationconfig = new LocalResourceIdentifier(InputObject.Id);

                ResourceGroupName = getParamMigrationconfig.ResourceGroupName;
                Name = getParamMigrationconfig.ResourceName;
            }
            else if (ParameterSetName == ResourceIdParameterSet)
            {
                LocalResourceIdentifier getParamMigrationconfig = new LocalResourceIdentifier(ResourceId);

                ResourceGroupName = getParamMigrationconfig.ResourceGroupName;
                Name = getParamMigrationconfig.ResourceName;
            }
           
            try
            {
                PSServiceBusMigrationConfigurationAttributes migrationConfiguration = Client.GetServiceBusMigrationConfiguration(ResourceGroupName, Name);
                WriteObject(migrationConfiguration);
            }
            catch (Management.ServiceBus.Models.ErrorResponseException ex)
            {
                WriteError(ServiceBusClient.WriteErrorforBadrequest(ex));
            }

        }
    }
}
