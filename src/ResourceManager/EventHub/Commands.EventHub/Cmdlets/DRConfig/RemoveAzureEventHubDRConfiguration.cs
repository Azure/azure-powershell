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
using Microsoft.Azure.Commands.EventHub.Models;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;

namespace Microsoft.Azure.Commands.EventHub.Commands.GeoDR
{
    /// <summary>
    /// 'Remove-AzureRmEventHubDRConfiguration' Cmdlet Deletes an Alias(Disaster Recovery configuration)
    /// </summary>
    [Cmdlet(VerbsCommon.Remove, EventHubDRConfigurationVerb, SupportsShouldProcess = true, DefaultParameterSetName = AliasPropertiesParameterSet), OutputType(typeof(bool))]
    public class RemoveEventHubDRConfiguration : AzureEventHubsCmdletBase
    {
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, Position = 0, HelpMessage = "Resource Group Name")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = AliasPropertiesParameterSet, ValueFromPipelineByPropertyName = true, Position = 1, HelpMessage = "Namespace Name")]
        [Parameter(Mandatory = true, ParameterSetName = AliasInputObjectParameterSet, ValueFromPipelineByPropertyName = true, Position = 1, HelpMessage = "Namespace Name")]
        [ValidateNotNullOrEmpty]
        [Alias(AliasNamespaceName)]
        public string Namespace { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = AliasPropertiesParameterSet, ValueFromPipelineByPropertyName = true, Position = 2, HelpMessage = "Alias (GeoDR)")]
        [Parameter(Mandatory = false, ParameterSetName = AliasInputObjectParameterSet, ValueFromPipelineByPropertyName = true, HelpMessage = "Alias (GeoDr)")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = AliasInputObjectParameterSet, ValueFromPipelineByPropertyName = true, Position = 3,HelpMessage = "Alias Configuration object")]        
        [Parameter(Mandatory = false, ParameterSetName = AliasPropertiesParameterSet, ValueFromPipelineByPropertyName = true, HelpMessage = "Alias Configuration object")]
        [Alias(AliasAliasObj)]
        [ValidateNotNullOrEmpty]
        public PSEventHubDRConfigurationAttributes InputObject { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Do not ask for confirmation")]
        public SwitchParameter Force { get; set; }

        [Parameter(Mandatory = false)]
        public SwitchParameter PassThru { get; set; }

        public override void ExecuteCmdlet()
        {            
            if (ParameterSetName == AliasInputObjectParameterSet)
            {                
                ConfirmAction(
                Force.IsPresent,
                string.Format(Resources.DRRemoveAlias, InputObject.Name, Namespace),
                string.Format(Resources.DRRemoveAlias, InputObject.Name, Namespace),
                InputObject.Name,
                () =>
                {
                    Client.DeleteEventHubDRConfiguration(ResourceGroupName, Namespace, InputObject.Name);
                    if (PassThru)
                    {
                        WriteObject(true);
                    }
                });
            }

            if (ParameterSetName == AliasPropertiesParameterSet)
            {
                ConfirmAction(
                Force.IsPresent,
                string.Format(Resources.DRRemoveAlias, Name, Namespace),
                string.Format(Resources.DRRemoveAlias, Name, Namespace),
                Name,
                () =>
                {
                    Client.DeleteEventHubDRConfiguration(ResourceGroupName, Namespace, Name);
                    if (PassThru)
                    {
                        WriteObject(true);
                    }
                });

            }
        }
    }
}
