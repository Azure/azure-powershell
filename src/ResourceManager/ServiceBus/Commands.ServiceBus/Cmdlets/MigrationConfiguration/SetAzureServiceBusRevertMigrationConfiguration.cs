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
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;

namespace Microsoft.Azure.Commands.ServiceBus.Commands.Migration
{
    /// <summary>
    /// 'Set-AzureRmServiceBusRevertMigration' Cmdlet disables the Migration and stops replicating changes from standard to premium
    /// </summary>
    [Cmdlet(VerbsCommon.Set, ServicebusRevertMigrationConfiguration, DefaultParameterSetName = MigrationConfigurationParameterSet, SupportsShouldProcess = true), OutputType(typeof(bool))]
    public class SetAzureServiceBusRevertMigrationConfiguration : AzureServiceBusCmdletBase
    {
        [Parameter(Mandatory = true, ParameterSetName = MigrationConfigurationParameterSet, ValueFromPipelineByPropertyName = true, Position = 0, HelpMessage = "Resource Group Name")]
        [ValidateNotNullOrEmpty]
        [ResourceGroupCompleter]
        [Alias("ResourceGroup")]
        public string ResourceGroupName { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = MigrationConfigurationParameterSet, ValueFromPipelineByPropertyName = true, Position = 1, HelpMessage = "Standard Namespace Name")]
        [ValidateNotNullOrEmpty]
        public string Namespace { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = NamespaceInputObjectParameterSet, ValueFromPipeline = true, Position = 0, HelpMessage = "Service Bus Migration Configuration Standard Namespace Object")]
        [ValidateNotNullOrEmpty]
        public PSServiceBusDRConfigurationAttributes InputObject { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = NamespaceResourceIdParameterSet, ValueFromPipelineByPropertyName = true, Position = 0, HelpMessage = "Service Bus Migration Configuration Standard Namespace Resource Id")]
        [ValidateNotNullOrEmpty]
        public string ResourceId { get; set; }

        [Parameter(Mandatory = false)]
        public SwitchParameter PassThru { get; set; }

        public override void ExecuteCmdlet()
        {
            if (ParameterSetName == NamespaceInputObjectParameterSet)
            {
                ResourceIdentifier getParamMigration = GetResourceDetailsFromId(InputObject.Id);
                if (getParamMigration.ResourceGroupName != null && getParamMigration.ResourceName != null)
                {
                    if (ShouldProcess(target: getParamMigration.ResourceName, action: string.Format(Resources.RevertMigrationConfiguration)))
                    {
                        Client.SetServiceBusRevertMigrationConfiguration(getParamMigration.ResourceGroupName, getParamMigration.ResourceName);
                        if (PassThru)
                        {
                            WriteObject(true);
                        }
                    }
                }
                else
                {
                    WriteObject(false);
                }
            }

            if (ParameterSetName == NamespaceResourceIdParameterSet)
            {
                ResourceIdentifier getParamMigration = GetResourceDetailsFromId(ResourceId);
                if (getParamMigration.ResourceGroupName != null && getParamMigration.ResourceName != null)
                {
                    if (ShouldProcess(target: getParamMigration.ResourceName, action: string.Format(Resources.RevertMigrationConfiguration)))
                    {
                        Client.SetServiceBusRevertMigrationConfiguration(getParamMigration.ResourceGroupName, getParamMigration.ResourceName);
                        if (PassThru)
                        {
                            WriteObject(true);
                        }
                    }
                }
                else
                {
                    WriteObject(false);
                }
            }

            if (ParameterSetName == MigrationConfigurationParameterSet)
            {
                if (ShouldProcess(target: Namespace, action: string.Format(Resources.RevertMigrationConfiguration)))
                {
                    Client.SetServiceBusRevertMigrationConfiguration(ResourceGroupName, Namespace);
                    if (PassThru)
                    {
                        WriteObject(true);
                    }
                }
            }
        }
    }
}