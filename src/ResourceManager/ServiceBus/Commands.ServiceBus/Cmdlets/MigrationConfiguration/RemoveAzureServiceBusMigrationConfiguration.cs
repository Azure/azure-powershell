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
    /// 'Remove-AzureRmServicebusMigrationConfiguration' Cmdlet Deletes Migration Coinfiguration)
    /// </summary>
    [Cmdlet(VerbsCommon.Remove, ServicebusMigrationConfigurationVerb, DefaultParameterSetName = MigrationConfigurationParameterSet, SupportsShouldProcess = true), OutputType(typeof(bool))]
    public class RemoveAzureServiceBusMigrationConfiguration : AzureServiceBusCmdletBase
    {
        [Parameter(Mandatory = true, ParameterSetName = MigrationConfigurationParameterSet, ValueFromPipelineByPropertyName = true, Position = 0, HelpMessage = "Resource Group Name")]
        [ValidateNotNullOrEmpty]
        [ResourceGroupCompleter]
        public string ResourceGroupName { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = MigrationConfigurationParameterSet, ValueFromPipelineByPropertyName = true, Position = 1, HelpMessage = "Standard Namespace Name")]
        [ValidateNotNullOrEmpty]   
        public string Namespace { get; set; }

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
                ResourceIdentifier getParamMigration = GetResourceDetailsFromId(InputObject.Id);

                if (getParamMigration.ResourceGroupName != null && getParamMigration.ResourceName != null)
                {
                    if (ShouldProcess(target: getParamMigration.ResourceName, action: string.Format(Resources.RemoveMigrationConfiguration)))
                    {
                        Client.DeleteServiceBusMigrationConfiguration(getParamMigration.ResourceGroupName, getParamMigration.ResourceName);
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
                ResourceIdentifier getParamGeoDR = GetResourceDetailsFromId(ResourceId);

                if (getParamGeoDR.ResourceGroupName != null && getParamGeoDR.ResourceName != null)
                {
                    if (ShouldProcess(target: getParamGeoDR.ResourceName, action: string.Format(Resources.RemoveMigrationConfiguration)))
                    {
                        Client.DeleteServiceBusMigrationConfiguration(getParamGeoDR.ResourceGroupName, getParamGeoDR.ResourceName);
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
                if (ShouldProcess(target: Namespace, action: string.Format(Resources.RemoveMigrationConfiguration)))
                {
                    Client.DeleteServiceBusMigrationConfiguration(ResourceGroupName, Namespace);
                    if (PassThru)
                    {
                        WriteObject(true);
                    }
                }
            }
        }
    }
}
