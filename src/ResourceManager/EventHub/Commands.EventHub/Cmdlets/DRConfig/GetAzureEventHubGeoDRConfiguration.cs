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

using Microsoft.Azure.Commands.EventHub.Models;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;

namespace Microsoft.Azure.Commands.EventHub.Commands.GeoDR
{
    /// <summary>
    /// 'Get-AzureEventHubDRConfiguration' CmdletRetrieves Alias(Disaster Recovery configuration) for primary or secondary namespace    
    /// </summary>
    [Cmdlet(VerbsCommon.Get, EventHubDRConfigurationVerb, DefaultParameterSetName = GeoDRParameterSet), OutputType(typeof(List<PSEventHubDRConfigurationAttributes>))]
    public class GetEventHubGeoDRConfiguration : AzureEventHubsCmdletBase
    {
        [Parameter(Mandatory = true, ParameterSetName = GeoDRParameterSet, ValueFromPipelineByPropertyName = true, Position = 0, HelpMessage = "Resource Group Name")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
         public string ResourceGroupName { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = GeoDRParameterSet, ValueFromPipelineByPropertyName = true, Position = 1, HelpMessage = "Namespace Name")]
        [ValidateNotNullOrEmpty]
        public string Namespace { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = NamespaceInputObjectParameterSet, ValueFromPipeline = true, Position = 0, HelpMessage = "Namespace Object")]
        [ValidateNotNullOrEmpty]
        public PSNamespaceAttributes InputObject { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = ResourceIdParameterSet, ValueFromPipelineByPropertyName = true, Position = 0, HelpMessage = "Namespace Resource Id")]
        [ValidateNotNullOrEmpty]
        public string ResourceId { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "DR Configuration Name")]
        public string Name { get; set; }

        public override void ExecuteCmdlet()
        {
            ResourceIdentifier getParamGeoDR = new ResourceIdentifier();

            if (ParameterSetName == NamespaceInputObjectParameterSet)
            {
                getParamGeoDR = GetResourceDetailsFromId(InputObject.Id);

                if (getParamGeoDR.ResourceGroupName != null && getParamGeoDR.ResourceName != null)
                {
                    if (!string.IsNullOrEmpty(Name))
                    {
                        PSEventHubDRConfigurationAttributes drConfiguration = Client.GetEventHubDRConfiguration(getParamGeoDR.ResourceGroupName, getParamGeoDR.ResourceName, Name);
                        WriteObject(drConfiguration);
                    }
                    else
                    {
                        IEnumerable<PSEventHubDRConfigurationAttributes> drConfigurationList = Client.ListAllEventHubDRConfiguration(getParamGeoDR.ResourceGroupName, getParamGeoDR.ResourceName);
                        WriteObject(drConfigurationList.ToList(), true);
                    }
                }
            }

            if (ParameterSetName == ResourceIdParameterSet)
            {
                getParamGeoDR = GetResourceDetailsFromId(ResourceId);

                if (getParamGeoDR.ResourceGroupName != null && getParamGeoDR.ResourceName != null)
                {
                    if (!string.IsNullOrEmpty(Name))
                    {
                        PSEventHubDRConfigurationAttributes drConfiguration = Client.GetEventHubDRConfiguration(getParamGeoDR.ResourceGroupName, getParamGeoDR.ResourceName, Name);
                        WriteObject(drConfiguration);
                    }
                    else
                    {
                        IEnumerable<PSEventHubDRConfigurationAttributes> drConfigurationList = Client.ListAllEventHubDRConfiguration(getParamGeoDR.ResourceGroupName, getParamGeoDR.ResourceName);
                        WriteObject(drConfigurationList.ToList(), true);
                    }
                }
            }

            if (ParameterSetName == GeoDRParameterSet)
            {
                if (!string.IsNullOrEmpty(Name))
                {
                    // Get a DRConfiguration
                    PSEventHubDRConfigurationAttributes drConfiguration = Client.GetEventHubDRConfiguration(ResourceGroupName, Namespace, Name);
                    WriteObject(drConfiguration);
                }
                else
                {
                    // Get all DRConfigurations
                    IEnumerable<PSEventHubDRConfigurationAttributes> drConfigurationList = Client.ListAllEventHubDRConfiguration(ResourceGroupName, Namespace);
                    WriteObject(drConfigurationList.ToList(), true);
                }
            }            
        }
    }
}
