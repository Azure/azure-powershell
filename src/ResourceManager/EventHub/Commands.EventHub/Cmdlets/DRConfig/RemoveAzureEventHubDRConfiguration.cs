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
namespace Microsoft.Azure.Commands.EventHub.Commands.GeoDR
{
    /// <summary>
    /// 'Remove-AzureRmEventHubDRConfiguration' Cmdlet Deletes an Alias(Disaster Recovery configuration)
    /// </summary>
    [Cmdlet(VerbsCommon.Remove, EventHubDRConfigurationVerb, SupportsShouldProcess = true, DefaultParameterSetName = AliasPropertiesParameterSet), OutputType(typeof(bool))]
    public class RemoveEventHubDRConfiguration : AzureEventHubsCmdletBase
    {
        [Parameter(Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            Position = 0,
            HelpMessage = "Resource Group Name.")]
        [ValidateNotNullOrEmpty]
         public string ResourceGroupName { get; set; }

        [Parameter(Mandatory = true,
            ParameterSetName = AliasPropertiesParameterSet,
            ValueFromPipelineByPropertyName = true,
            Position = 1,
            HelpMessage = "Namespace Name.")]
        [ValidateNotNullOrEmpty]
        [Alias(AliasNamespaceName)]
        [Parameter(Mandatory = true, Position = 1, ValueFromPipelineByPropertyName = true, ParameterSetName = AliasInputObjectParameterSet, HelpMessage = "Namespace Name")]
        public string Namespace { get; set; }

        [Parameter(Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            ParameterSetName = AliasPropertiesParameterSet,
            Position = 2,
            HelpMessage = "Alias (GeoDR)")]
        [ValidateNotNullOrEmpty]
        [Alias(AliasAliasName)]
        [Parameter(Mandatory = false, Position = 2, ValueFromPipelineByPropertyName = true, ParameterSetName = AliasInputObjectParameterSet, HelpMessage = "Alias (GeoDr)")]
        public string Name { get; set; }

        [Parameter(Mandatory = true,
            ParameterSetName = AliasInputObjectParameterSet,
            ValueFromPipelineByPropertyName = true,
            Position = 3,
            HelpMessage = "Alias Configuration object.")]
        [Alias(AliasAliasObj)]
        [ValidateNotNullOrEmpty]
        [Parameter(Mandatory = false,
            ParameterSetName = AliasPropertiesParameterSet,
            ValueFromPipelineByPropertyName = true,
            Position = 3,
            HelpMessage = "Alias Configuration object.")]
        public EventHubDRConfigurationAttributes InputObject { get; set; }

        public override void ExecuteCmdlet()
        {            
            if (ParameterSetName == AliasInputObjectParameterSet)
            {
                // delete an Alias 
                if (ShouldProcess(target: InputObject.Name, action: string.Format(Resources.DRRemoveAlias, InputObject.Name, Namespace)))
                {
                    WriteObject(Client.DeleteEventHubDRConfiguration(ResourceGroupName, Namespace, InputObject.Name));
                }
            }

            if (ParameterSetName == AliasPropertiesParameterSet)
            {
                // delete an Alias 
                if (ShouldProcess(target: Name, action: string.Format(Resources.DRRemoveAlias, Name, Namespace)))
                {
                    WriteObject(Client.DeleteEventHubDRConfiguration(ResourceGroupName, Namespace, Name));
                }

            }
        }
    }
}
