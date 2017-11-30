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
    /// 'Set-AzureRmRelayNamespace' Cmdlet updates the specified Relay Namespace
    /// </summary>
    [Cmdlet(VerbsCommon.Set, RelayNamespaceVerb, SupportsShouldProcess = true), OutputType(typeof(RelayNamespaceAttributes))]
    public class SetAzureRelayNamespace : AzureRelayCmdletBase
    {
        [Parameter(Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            Position = 0,
            HelpMessage = "Resource Group Name.")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
         public string ResourceGroupName { get; set; }

        [Parameter(Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            Position = 1,
            HelpMessage = "Relay Namespace Name.")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }
        
        [Parameter(Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Hashtables which represents resource Tag.")]
        public Hashtable Tag { get; set; }

        [Parameter(Mandatory = false,
           ValueFromPipeline = true,
           HelpMessage = "Relay Namespace object.")]
        [ValidateNotNullOrEmpty]
        public RelayNamespaceAttirbutesUpdateParameter InputObject { get; set; }

        public override void ExecuteCmdlet()
        {
            RelayNamespaceAttirbutesUpdateParameter relayNamespace = new RelayNamespaceAttirbutesUpdateParameter();
            
            if (InputObject != null)
            {
                relayNamespace = InputObject;
            }
            else
            {
                // Update a Relay namespace 
                Dictionary<string, string> tagDictionary = TagsConversionHelper.CreateTagDictionary(Tag, validate: true);

                relayNamespace.Tags = tagDictionary;
            }
            if (ShouldProcess(target: Name, action: string.Format(Resources.UpdateRelayNamespace, Name, ResourceGroupName)))
            {
                WriteObject(Client.UpdateNamespace(ResourceGroupName, Name, relayNamespace));
            }
        }
    }
}
