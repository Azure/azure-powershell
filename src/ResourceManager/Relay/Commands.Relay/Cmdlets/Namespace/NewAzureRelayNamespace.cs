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

using Microsoft.Azure.Commands.Relay.Models;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Commands.ResourceManager.Common.Tags;
using System.Collections;
using System.Collections.Generic;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Relay.Commands.Namespace
{
    /// <summary>
    /// this commandlet will let you Create Relay namespace.
    /// </summary>
    [Cmdlet(VerbsCommon.New, RelayNamespaceVerb, SupportsShouldProcess = true), OutputType(typeof(RelayNamespaceAttributes))]
    public class NewAzureRelayNamespace : AzureRelayCmdletBase
    {
        /// <summary>
        /// Name of the resource group.
        /// </summary>
        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            Position = 0,
            HelpMessage = "Resource Group Name.")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
         public string ResourceGroupName { get; set; }

        /// <summary>
        /// Relay Namespace Name.
        /// </summary>
        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            Position = 1,
            HelpMessage = "Relay Namespace Name.")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        /// <summary>
        /// Relay Namespace Location.
        /// </summary>
        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            Position = 2,
            HelpMessage = "Relay Namespace Location.")]
        [LocationCompleter("Microsoft.Relay/namespaces")]
        [ValidateNotNullOrEmpty]
        public string Location { get; set; }

        
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
            // Create a new Relay namespaces
            Dictionary<string, string> tagDictionary = TagsConversionHelper.CreateTagDictionary(Tag, validate: true);
            if (ShouldProcess(target: Name, action: string.Format("Create a new Relay-Namespace:{0} under Resource Group:{1}", Name, ResourceGroupName)))
            {
                WriteObject(Client.BeginCreateNamespace(ResourceGroupName, Name, Location, tagDictionary));
            }
        }
    }
}
