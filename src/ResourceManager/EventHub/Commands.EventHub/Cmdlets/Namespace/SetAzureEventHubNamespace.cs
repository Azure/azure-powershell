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
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Commands.ResourceManager.Common.Tags;
using System.Collections;
using System.Collections.Generic;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.EventHub.Commands.Namespace
{
    /// <summary>
    /// 'Set-AzureRmEventHubNamespace' Cmdlet updates the specified Eventhub Namespace
    /// </summary>
    [Cmdlet(VerbsCommon.Set, EventHubNamespaceVerb, SupportsShouldProcess = true, DefaultParameterSetName = NamespaceParameterSet), OutputType(typeof(NamespaceAttributes))]
    public class SetAzureEventHubNamespace : AzureEventHubsCmdletBase
    {
        [Parameter(Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            Position = 0,
            HelpMessage = "Resource Group Name.",
          ParameterSetName = NamespaceParameterSet)]
        [Parameter(Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            Position = 0,
            HelpMessage = "Resource Group Name.",
          ParameterSetName = AutoInflateParameterSet)]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
         public string ResourceGroupName { get; set; }

        [Parameter(Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            Position = 1,
            HelpMessage = "EventHub Namespace Name.",
          ParameterSetName = NamespaceParameterSet)]
        [Parameter(Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            Position = 1,
            HelpMessage = "EventHub Namespace Name.",
          ParameterSetName = AutoInflateParameterSet)]
        [ValidateNotNullOrEmpty]
        [Alias(AliasNamespaceName)]
        public string Name { get; set; }

        [Parameter(Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            Position = 2,
            HelpMessage = "EventHub Namespace Location.",
          ParameterSetName = NamespaceParameterSet)]
        [Parameter(Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            Position = 2,
            HelpMessage = "EventHub Namespace Location.",
          ParameterSetName = AutoInflateParameterSet)]
        [LocationCompleter("Microsoft.EventHub/namespaces")]
        [ValidateNotNullOrEmpty]
        public string Location { get; set; }

        [Parameter(
          Mandatory = false,
          Position = 3,          
          ValueFromPipelineByPropertyName = true,
          HelpMessage = "Namespace Sku Name.",
          ParameterSetName = NamespaceParameterSet)]
        [Parameter(
          Mandatory = false,
          Position = 3,
          ValueFromPipelineByPropertyName = true,
          HelpMessage = "Namespace Sku Name.",
          ParameterSetName = AutoInflateParameterSet)]
        [ValidateSet(SKU.Basic,
          SKU.Standard,
          SKU.Premium,
          IgnoreCase = true)]
        public string SkuName { get; set; }

        [Parameter(          
          Mandatory = false,
            Position = 4,
          ValueFromPipelineByPropertyName = true,
          HelpMessage = "The eventhub throughput units.",
          ParameterSetName = NamespaceParameterSet)]
        [Parameter(
          Mandatory = false,
            Position = 4,
          ValueFromPipelineByPropertyName = true,
          HelpMessage = "The eventhub throughput units.",
          ParameterSetName = AutoInflateParameterSet)]
        public int? SkuCapacity { get; set; }

        [Parameter(Mandatory = false,
            Position = 5,
            ValueFromPipelineByPropertyName = true,            
            HelpMessage = "Disable/Enable Namespace.",
          ParameterSetName = NamespaceParameterSet)]
        [Parameter(Mandatory = false,
            Position = 5,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Disable/Enable Namespace.",
          ParameterSetName = AutoInflateParameterSet)]
        public Models.NamespaceState? State { get; set; }

        [Parameter(Mandatory = false,
            Position = 6,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Hashtables which represents resource Tag.",
          ParameterSetName = NamespaceParameterSet)]
        [Parameter(Mandatory = false,
            Position = 6,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Hashtables which represents resource Tag.",
          ParameterSetName = AutoInflateParameterSet)]
        public Hashtable Tag { get; set; }

        /// <summary>
        /// Indicates whether AutoInflate is enabled.
        /// </summary>
        [Parameter(
            Mandatory = true,
            HelpMessage = "Indicates whether AutoInflate is enabled",
            ParameterSetName = AutoInflateParameterSet
            )]
        public SwitchParameter EnableAutoInflate { get; set; }

        /// <summary>
        /// Upper limit of throughput units when AutoInflate is enabled.
        /// </summary>
        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Upper limit of throughput units when AutoInflate is enabled, value should be within 0 to 20 throughput units.",
            ParameterSetName = AutoInflateParameterSet
            )]        
        [ValidateRange(0,20)]        
        public int? MaximumThroughputUnits { get; set; }

        public override void ExecuteCmdlet()
        {
            // Update a EventHub namespace 
            Dictionary<string, string> tagDictionary = TagsConversionHelper.CreateTagDictionary(Tag, validate: true);

            if (ShouldProcess(target: Name, action: string.Format(Resources.UpdateNamespace, Name, ResourceGroupName)))
            {
                if(EnableAutoInflate.IsPresent)
                    WriteObject(Client.UpdateNamespace(ResourceGroupName, Name, Location, SkuName, SkuCapacity, State, tagDictionary, true, MaximumThroughputUnits));
                else
                    WriteObject(Client.UpdateNamespace(ResourceGroupName, Name, Location, SkuName, SkuCapacity, State, tagDictionary, false, MaximumThroughputUnits));
            }
        }
    }
}
