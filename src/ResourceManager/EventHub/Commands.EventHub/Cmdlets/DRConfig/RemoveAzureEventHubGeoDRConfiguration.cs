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
using System.Text.RegularExpressions;
using Microsoft.Azure.Commands.EventHub.Models;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;

namespace Microsoft.Azure.Commands.EventHub.Commands.GeoDR
{    
    /// <summary>
    /// 'Remove-AzureRmEventHubDRConfiguration' Cmdlet Deletes an Alias(Disaster Recovery configuration)
    /// </summary>
    [Cmdlet(VerbsCommon.Remove, EventHubDRConfigurationVerb, DefaultParameterSetName = GeoDRParameterSet, SupportsShouldProcess = true), OutputType(typeof(bool))]
    public class RemoveEventHubGeoDRConfiguration : AzureEventHubsCmdletBase
    {
        [Parameter(Mandatory = true, ParameterSetName = GeoDRParameterSet, ValueFromPipelineByPropertyName = true, Position = 0, HelpMessage = "Resource Group Name")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = GeoDRParameterSet, ValueFromPipelineByPropertyName = true, Position = 1, HelpMessage = "Namespace Name")]
        [ValidateNotNullOrEmpty]
        public string Namespace { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = GeoDRParameterSet, ValueFromPipelineByPropertyName = true, Position = 2, HelpMessage = "Alias (GeoDR)")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = GeoDRInputObjectParameterSet, ValueFromPipeline = true, Position = 0, HelpMessage = "Eventhub GeoDR Configuration Object")]
        [ValidateNotNullOrEmpty]
        public PSEventHubDRConfigurationAttributes InputObject { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = GeoDRConfigResourceIdParameterSet, ValueFromPipelineByPropertyName = true, Position = 0, HelpMessage = "GeoDRConfiguration Resource Id")]
        [ValidateNotNullOrEmpty]
        public string ResourceId { get; set; }

        [Parameter(Mandatory = false)]
        public SwitchParameter PassThru { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Run cmdlet in the background")]
        public SwitchParameter AsJob { get; set; }

        public override void ExecuteCmdlet()
        {
            if (ParameterSetName == GeoDRInputObjectParameterSet)
            {
                ResourceIdentifier getParamGeoDR = GetResourceDetailsFromId(InputObject.Id);

                if (getParamGeoDR.ResourceGroupName != null && getParamGeoDR.ParentResource != null && getParamGeoDR.ResourceName != null)
                {
                    if (ShouldProcess(target: Name, action: string.Format(Resources.DRRemoveAlias, getParamGeoDR.ResourceName, getParamGeoDR.ParentResource)))
                    {
                        Client.DeleteEventHubDRConfiguration(getParamGeoDR.ResourceGroupName, getParamGeoDR.ParentResource, getParamGeoDR.ResourceName);
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

            if (ParameterSetName == GeoDRConfigResourceIdParameterSet)
            {
                ResourceIdentifier getParamGeoDR = GetResourceDetailsFromId(ResourceId);

                if (getParamGeoDR.ResourceGroupName != null && getParamGeoDR.ParentResource != null && getParamGeoDR.ResourceName != null)
                {
                    if (ShouldProcess(target: Name, action: string.Format(Resources.DRRemoveAlias, getParamGeoDR.ResourceName, getParamGeoDR.ParentResource)))
                    {
                        Client.DeleteEventHubDRConfiguration(getParamGeoDR.ResourceGroupName, getParamGeoDR.ParentResource, getParamGeoDR.ResourceName);
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

            if (ParameterSetName == GeoDRParameterSet)
            {
                if (ShouldProcess(target: Name, action: string.Format(Resources.DRRemoveAlias, Name, Namespace)))
                {
                    Client.DeleteEventHubDRConfiguration(ResourceGroupName, Namespace, Name);
                    if (PassThru)
                    {
                        WriteObject(true);
                    }
                }                
            }
        }
    }
}
