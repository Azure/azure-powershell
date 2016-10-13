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
using System.Collections;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.EventHub.Cmdlets.Namespace
{

    [Cmdlet(VerbsCommon.New, EventHubNamespaceVerb), OutputType(typeof(NamespaceAttributes))]
    public class NewAzureEventHubNamespace : AzureEventHubsCmdletBase
    {
        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            Position = 0,
            HelpMessage = "Resource Group Name.")]
        [ValidateNotNullOrEmpty]
         public string ResourceGroupName { get; set; }

        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            Position = 1,
            HelpMessage = "EventHub Namespace Name.")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            Position = 2,
            HelpMessage = "EventHub Namespace Location.")]
        [ValidateNotNullOrEmpty]
        public string Location { get; set; }

        [Parameter(
          Position = 3,
          Mandatory = false,
          ValueFromPipelineByPropertyName = true,
          HelpMessage = "Namespace Sku Name.")]
        [ValidateSet(SKU.Basic,
          SKU.Standard,
          SKU.Premium,
          IgnoreCase = true)]
        public string SkuName { get; set; }

        [Parameter(
          Position = 4,
          Mandatory = false,
          ValueFromPipelineByPropertyName = true,
          HelpMessage = "The eventhub throughput units.")]
        public int? SkuCapacity { get; set; }

        [Parameter(
          Position = 5,
          Mandatory = false,
          ValueFromPipelineByPropertyName = true,
          HelpMessage = "Indicates whether to create ACS namespace.")]
        public bool? CreateACSNamespace { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            Position = 6,
            HelpMessage = "Hashtables which represents resource Tags.")]
        public Hashtable Tags { get; set; }

        public override void ExecuteCmdlet()
        {
            // Create a new EventHub namespace 
            var nsAttribute = Client.BeginCreateNamespace(ResourceGroupName, Name, Location, SkuName, SkuCapacity, CreateACSNamespace, ConvertTagsToDictionary(Tags));
            WriteObject(nsAttribute);
        }
    }
}
