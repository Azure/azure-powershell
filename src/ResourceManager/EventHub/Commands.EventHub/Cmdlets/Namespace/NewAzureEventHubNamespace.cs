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
using Microsoft.Azure.Commands.ResourceManager.Common.Tags;
using System.Collections;
using System.Collections.Generic;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.EventHub.Commands.Namespace
{
    /// <summary>
    /// this commandlet will let you Create Eventhub namespace.
    /// </summary>
    [Cmdlet(VerbsCommon.New, EventHubNamespaceVerb, SupportsShouldProcess = true), OutputType(typeof(NamespaceAttributes))]
    public class NewAzureEventHubNamespace : AzureEventHubsCmdletBase
    {
        /// <summary>
        /// Name of the resource group.
        /// </summary>
        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            Position = 0,
            HelpMessage = "Resource Group Name.")]
        [ValidateNotNullOrEmpty]
         public string ResourceGroupName { get; set; }

        /// <summary>
        /// EventHub Namespace Name.
        /// </summary>
        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            Position = 1,
            HelpMessage = "EventHub Namespace Name.")]
        [ValidateNotNullOrEmpty]
        public string NamespaceName { get; set; }

        /// <summary>
        /// EventHub Namespace Location.
        /// </summary>
        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            Position = 2,
            HelpMessage = "EventHub Namespace Location.")]
        [ValidateNotNullOrEmpty]
        public string Location { get; set; }

        /// <summary>
        /// Namespace Sku Name.
        /// </summary>
        [Parameter(
          Mandatory = false,
          ValueFromPipelineByPropertyName = true,
          HelpMessage = "Namespace Sku Name.")]
        [ValidateSet(SKU.Basic,
          SKU.Standard,
          SKU.Premium,
          IgnoreCase = true)]
        public string SkuName { get; set; }


        /// <summary>
        /// The eventhub throughput units.
        /// </summary>
        [Parameter(
          Mandatory = false,
          ValueFromPipelineByPropertyName = true,
          HelpMessage = "The eventhub throughput units.")]
        public int? SkuCapacity { get; set; }
        
        /// <summary>
        /// Hashtables which represents resource Tags.
        /// </summary>
        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Hashtables which represents resource Tags.")]
        public Hashtable Tag { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public override void ExecuteCmdlet()
        {
            // Create a new EventHub namespaces
            Dictionary<string, string> tagDictionary = TagsConversionHelper.CreateTagDictionary(Tag, validate: true);
            NamespaceAttributes nsAttribute = Client.BeginCreateNamespace(ResourceGroupName, NamespaceName, Location, SkuName, SkuCapacity, tagDictionary);
            WriteObject(nsAttribute);
        }
    }
}
