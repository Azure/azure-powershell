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
using System.Collections;
using System.Collections.Generic;
using System.Management.Automation;
using Microsoft.Azure.Commands.ResourceManager.Common.Tags;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;

namespace Microsoft.Azure.Commands.ServiceBus.Commands.Namespace
{
    /// <summary>
    /// 'New-AzureRmServiceBusNamespace' cmdlet creates a new Servicebus NameSpace
    /// </summary>
    [Cmdlet(VerbsCommon.New, ServiceBusNamespaceVerb, SupportsShouldProcess = true), OutputType(typeof(PSNamespaceAttributes))]
    public class NewAzureRmServiceBusNamespace : AzureServiceBusCmdletBase
    {
        /// <summary>
        /// Name of the resource group.
        /// </summary>
        [Parameter( Mandatory = true, ValueFromPipelineByPropertyName = true, Position = 0, HelpMessage = "Resource Group Name")]
        [ResourceGroupCompleter]
        [Alias("ResourceGroup")]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        /// <summary>
        /// EventHub Namespace Location.
        /// </summary>
        [Parameter( Mandatory = true, ValueFromPipelineByPropertyName = true, Position = 1, HelpMessage = "ServiceBus Namespace Location")]
        [LocationCompleter("Microsoft.ServiceBus/namespaces")]
        [ValidateNotNullOrEmpty]
        public string Location { get; set; }

        /// <summary>
        /// EventHub Namespace Name.
        /// </summary>
        [Parameter( Mandatory = true, ValueFromPipelineByPropertyName = true, Position = 2, HelpMessage = "ServiceBus Namespace Name")]
        [Alias(AliasNamespaceName)]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }
        
        /// <summary>
        /// Namespace Sku Name.
        /// </summary>
        [Parameter( Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "Namespace Sku Name")]
        [ValidateSet(SKU.Basic, SKU.Standard, SKU.Premium, IgnoreCase = true)]
        public string SkuName { get; set; }

        /// <summary>
        /// Hashtables which represents resource Tags.
        /// </summary>
        [Parameter( Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "Hashtables which represents resource Tags")]
        public Hashtable Tag { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public override void ExecuteCmdlet()
        {
            // Create a new ServiceBus namespace
            Dictionary<string, string> tagDictionary = TagsConversionHelper.CreateTagDictionary(Tag, validate: true);

            if (ShouldProcess(target: Name, action: string.Format(Resources.CreateNamesapce, Name, ResourceGroupName)))
            {
                WriteObject(Client.BeginCreateNamespace(ResourceGroupName, Name, Location, SkuName, tagDictionary));
            }
        }
    }
}
