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
    [Cmdlet(VerbsCommon.Set, EventHubNamespaceVerb, SupportsShouldProcess = true, DefaultParameterSetName = NamespaceParameterSet), OutputType(typeof(PSNamespaceAttributes))]
    public class SetAzureEventHubNamespace : AzureEventHubsCmdletBase
    {
        [Parameter(Mandatory = true, ParameterSetName = NamespaceParameterSet, ValueFromPipelineByPropertyName = true, Position = 0, HelpMessage = "Resource Group Name.")]
        [Parameter(Mandatory = true, ParameterSetName = AutoInflateParameterSet, ValueFromPipelineByPropertyName = true, Position = 0, HelpMessage = "Resource Group Name.")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
         public string ResourceGroupName { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = NamespaceParameterSet, ValueFromPipelineByPropertyName = true, Position = 1, HelpMessage = "EventHub Namespace Name.")]
        [Parameter(Mandatory = true, ParameterSetName = AutoInflateParameterSet, ValueFromPipelineByPropertyName = true, Position = 1, HelpMessage = "EventHub Namespace Name.")]
        [ValidateNotNullOrEmpty]
        [Alias(AliasNamespaceName)]
        public string Name { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = NamespaceParameterSet, ValueFromPipelineByPropertyName = true, Position = 2, HelpMessage = "EventHub Namespace Location.")]
        [Parameter(Mandatory = true, ParameterSetName = AutoInflateParameterSet, ValueFromPipelineByPropertyName = true, Position = 2, HelpMessage = "EventHub Namespace Location.")]
        [LocationCompleter("Microsoft.EventHub/namespaces")]
        [ValidateNotNullOrEmpty]
        public string Location { get; set; }

        [Parameter(Mandatory = false, ParameterSetName = NamespaceParameterSet, ValueFromPipelineByPropertyName = true, Position = 3, HelpMessage = "Namespace Sku Name.")]
        [Parameter(Mandatory = false, ParameterSetName = AutoInflateParameterSet, ValueFromPipelineByPropertyName = true, Position = 3, HelpMessage = "Namespace Sku Name.")]
        [ValidateSet(SKU.Basic,
          SKU.Standard,
          SKU.Premium,
          IgnoreCase = true)]
        public string SkuName { get; set; }

        [Parameter(Mandatory = false, ParameterSetName = NamespaceParameterSet, ValueFromPipelineByPropertyName = true, Position = 4,HelpMessage = "The eventhub throughput units.")]
        [Parameter(Mandatory = false, ParameterSetName = AutoInflateParameterSet, ValueFromPipelineByPropertyName = true, Position = 4, HelpMessage = "The eventhub throughput units.")]
        public int? SkuCapacity { get; set; }

        [Parameter(Mandatory = false, ParameterSetName = NamespaceParameterSet, ValueFromPipelineByPropertyName = true, Position = 5, HelpMessage = "Disable/Enable Namespace.")]
        [Parameter(Mandatory = false, ParameterSetName = AutoInflateParameterSet, ValueFromPipelineByPropertyName = true, Position = 5, HelpMessage = "Disable/Enable Namespace.")]
        public Models.NamespaceState? State { get; set; }

        [Parameter(Mandatory = false, ParameterSetName = NamespaceParameterSet, ValueFromPipelineByPropertyName = true, Position = 6, HelpMessage = "Hashtables which represents resource Tag.")]
        [Parameter(Mandatory = false, ParameterSetName = AutoInflateParameterSet, ValueFromPipelineByPropertyName = true, Position = 6, HelpMessage = "Hashtables which represents resource Tag.")]
        public Hashtable Tag { get; set; }

        /// <summary>
        /// Indicates whether AutoInflate is enabled.
        /// </summary>
        [Parameter(Mandatory = true, ParameterSetName = AutoInflateParameterSet, HelpMessage = "Indicates whether AutoInflate is enabled")]
        public SwitchParameter EnableAutoInflate { get; set; }

        /// <summary>
        /// Upper limit of throughput units when AutoInflate is enabled.
        /// </summary>
        [Parameter(Mandatory = false, ParameterSetName = AutoInflateParameterSet, ValueFromPipelineByPropertyName = true, HelpMessage = "Upper limit of throughput units when AutoInflate is enabled, value should be within 0 to 20 throughput units.")]        
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
