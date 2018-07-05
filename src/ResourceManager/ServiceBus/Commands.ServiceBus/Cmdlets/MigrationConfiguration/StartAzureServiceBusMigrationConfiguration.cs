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
using Microsoft.Azure.Management.ServiceBus.Models;
using System.Management.Automation;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;

namespace Microsoft.Azure.Commands.ServiceBus.Commands.Migration
{
    /// <summary>
    /// 'New-AzureRmServicebusGeoDRConfiguration' Cmdlet Creates an new Alias(Disaster Recovery configuration)
    /// </summary>
    [Cmdlet(VerbsLifecycle.Start, ServicebusMigrationConfigurationVerb, DefaultParameterSetName = MigrationConfigurationParameterSet, SupportsShouldProcess = true), OutputType(typeof(PSServiceBusDRConfigurationAttributes))]
    public class StartAzureServiceBusMigrationConfiguration : AzureServiceBusCmdletBase
    {
        [Parameter(Mandatory = true, ParameterSetName = MigrationConfigurationParameterSet, ValueFromPipelineByPropertyName = true, Position = 0, HelpMessage = "Resource Group Name")]
        [ValidateNotNullOrEmpty]
        [ResourceGroupCompleter]
        public string ResourceGroupName { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = MigrationConfigurationParameterSet, ValueFromPipelineByPropertyName = true, Position = 1, HelpMessage = "Standard Namespace Name")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = NamespaceInputObjectParameterSet, ValueFromPipeline = true, Position = 0, HelpMessage = "Standard Namespace Object")]
        [ValidateNotNullOrEmpty]
        public PSNamespaceAttributes InputObject { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = NamespaceResourceIdParameterSet, ValueFromPipelineByPropertyName = true, Position = 0, HelpMessage = "Standard Namespace Resource Id")]
        [ValidateNotNullOrEmpty]
        public string ResourceId { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, Position = 2, HelpMessage = "Premium Namespace ARM Id")]
        [ValidateNotNullOrEmpty]
        public string TargetNameSpace { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, Position = 3, HelpMessage = "Post Migration Name for Standrad Namespace in Migration")]
        [ValidateNotNullOrEmpty]
        public string PostMigrationName { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Run cmdlet in the background")]
        public SwitchParameter AsJob { get; set; }

        public override void ExecuteCmdlet()
        {
            PSServiceBusMigrationConfigurationAttributes migrationConfiguration = new PSServiceBusMigrationConfigurationAttributes() { TargetNamespace = this.TargetNameSpace, PostMigrationName = this.PostMigrationName };
            

            if (ParameterSetName == NamespaceInputObjectParameterSet)
            {
                ResourceIdentifier getParamMigrationConfiguration = GetResourceDetailsFromId(InputObject.Id);

                if (getParamMigrationConfiguration.ResourceGroupName != null && getParamMigrationConfiguration.ResourceName != null)
                {
                    if (ShouldProcess(target: InputObject.Name, action: string.Format(Resources.StartMigrationConfiguration)))
                    {
                        WriteObject(Client.StartServiceBusMigrationConfiguration(getParamMigrationConfiguration.ResourceGroupName, getParamMigrationConfiguration.ResourceName, migrationConfiguration));
                    }
                }
            }

            if (ParameterSetName == NamespaceResourceIdParameterSet)
            {
                ResourceIdentifier getParamMigrationConfiguration = GetResourceDetailsFromId(ResourceId);

                if (getParamMigrationConfiguration.ResourceGroupName != null && getParamMigrationConfiguration.ResourceName != null)
                {
                    if (ShouldProcess(target: getParamMigrationConfiguration.ResourceName, action: string.Format(Resources.StartMigrationConfiguration)))
                    {
                        WriteObject(Client.StartServiceBusMigrationConfiguration(getParamMigrationConfiguration.ResourceGroupName, getParamMigrationConfiguration.ResourceName, migrationConfiguration));
                    }
                }
            }

            if (ParameterSetName == MigrationConfigurationParameterSet)
            {
                if (ShouldProcess(target: Name, action: string.Format(Resources.StartMigrationConfiguration)))
                {
                    WriteObject(Client.StartServiceBusMigrationConfiguration(ResourceGroupName, Name, migrationConfiguration));
                }
            }
        }
    }
}
