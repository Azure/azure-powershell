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
    /// this commandlet will let you Create Eventhub namespace.
    /// </summary>
    [Cmdlet(VerbsCommon.New, EventHubNamespaceVerb, SupportsShouldProcess = true, DefaultParameterSetName = NamespaceParameterSet), OutputType(typeof(PSNamespaceAttributes))]
    public class NewAzureEventHubNamespace : AzureEventHubsCmdletBase
    {
        /// <summary>
        /// Name of the resource group.
        /// </summary>
        [Parameter( Mandatory = true, ValueFromPipelineByPropertyName = true, Position = 0, HelpMessage = "Resource Group Name")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
         public string ResourceGroupName { get; set; }

        /// <summary>
        /// EventHub Namespace Name.
        /// </summary>
        [Parameter(Mandatory = true, ParameterSetName = NamespaceParameterSet, ValueFromPipelineByPropertyName = true, Position = 1, HelpMessage = "EventHub Namespace Name.")]
        [Parameter(Mandatory = true, ParameterSetName = AutoInflateParameterSet, ValueFromPipelineByPropertyName = true, Position = 1,HelpMessage = "EventHub Namespace Name.")]
        [ValidateNotNullOrEmpty]
        [Alias(AliasNamespaceName)]
        public string Name { get; set; }

        /// <summary>
        /// EventHub Namespace Location.
        /// </summary>
        [Parameter(Mandatory = true, ParameterSetName = NamespaceParameterSet, ValueFromPipelineByPropertyName = true, Position = 2, HelpMessage = "EventHub Namespace Location.")]        
        [Parameter(Mandatory = true, ParameterSetName = AutoInflateParameterSet, ValueFromPipelineByPropertyName = true, Position = 2, HelpMessage = "EventHub Namespace Location.")]
        [LocationCompleter("Microsoft.EventHub/namespaces")]
        [ValidateNotNullOrEmpty]
        public string Location { get; set; }

        /// <summary>
        /// Namespace Sku Name.
        /// </summary>
        [Parameter(Mandatory = false, ParameterSetName = NamespaceParameterSet, ValueFromPipelineByPropertyName = true, Position = 3, HelpMessage = "Namespace Sku Name.")]        
        [Parameter(Mandatory = false, ParameterSetName = AutoInflateParameterSet, ValueFromPipelineByPropertyName = true, Position = 3, HelpMessage = "Namespace Sku Name.")]
        [ValidateSet(SKU.Basic, SKU.Standard, SKU.Premium, IgnoreCase = true)]
        public string SkuName { get; set; }

        /// <summary>
        /// The eventhub throughput units.
        /// </summary>
        [Parameter(Mandatory = false, ParameterSetName = NamespaceParameterSet, ValueFromPipelineByPropertyName = true, Position = 4, HelpMessage = "The eventhub throughput units.")]
        [Parameter(Mandatory = false, ParameterSetName = AutoInflateParameterSet, ValueFromPipelineByPropertyName = true, Position = 4, HelpMessage = "The eventhub throughput units.")]
        public int? SkuCapacity { get; set; }
        
        /// <summary>
        /// Hashtables which represents resource Tags.
        /// </summary>
        [Parameter(Mandatory = false, ParameterSetName = NamespaceParameterSet, ValueFromPipelineByPropertyName = true, Position = 5, HelpMessage = "Hashtables which represents resource Tags.")]
        [Parameter(Mandatory = false, ParameterSetName = AutoInflateParameterSet, ValueFromPipelineByPropertyName = true, Position = 5, HelpMessage = "Hashtables which represents resource Tags.")]
        public Hashtable Tag { get; set; }

        /// <summary>
        /// Indicates whether AutoInflate is enabled.
        /// </summary>
        [Parameter(Mandatory = true, ParameterSetName = AutoInflateParameterSet, HelpMessage = "Indicates whether AutoInflate is enabled")]
        public SwitchParameter EnableAutoInflate { get; set; }

        /// <summary>
        /// Upper limit of throughput units when AutoInflate is enabled.
        /// </summary>
        [Parameter(Mandatory = false, ParameterSetName = AutoInflateParameterSet, ValueFromPipelineByPropertyName = true, Position = 7, HelpMessage = "Upper limit of throughput units when AutoInflate is enabled, value should be within 0 to 20 throughput units.")]
        [ValidateRange(0,20)]
        public int? MaximumThroughputUnits { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public override void ExecuteCmdlet()
        {
            // Create a new EventHub namespaces
            Dictionary<string, string> tagDictionary = TagsConversionHelper.CreateTagDictionary(Tag, validate: true);
            if (ShouldProcess(target: Name, action: string.Format(Resources.CreateNamespace, Name, ResourceGroupName)))
            {
                if(EnableAutoInflate.IsPresent)
                WriteObject(Client.BeginCreateNamespace(ResourceGroupName, Name, Location, SkuName, SkuCapacity, tagDictionary, true, MaximumThroughputUnits));
                else
                WriteObject(Client.BeginCreateNamespace(ResourceGroupName, Name, Location, SkuName, SkuCapacity, tagDictionary, false, MaximumThroughputUnits));
            }
        }
    }
}
