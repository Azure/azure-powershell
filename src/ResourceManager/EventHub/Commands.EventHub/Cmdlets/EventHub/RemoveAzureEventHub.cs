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

using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using System.Management.Automation;
namespace Microsoft.Azure.Commands.EventHub.Commands.EventHub
{
    /// <summary>
    /// 'Remove-AzureRmEventHub' Cmdlet removes the specified EventHub
    /// </summary>
    [Cmdlet(VerbsCommon.Remove, EventHubVerb, SupportsShouldProcess = true)]
    public class RemoveAzureEventHub : AzureEventHubsCmdletBase
    {
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, Position = 0, HelpMessage = "Resource Group Name")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
         public string ResourceGroupName { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, Position = 1, HelpMessage = "Namespace Name")]
        [ValidateNotNullOrEmpty]
        [Alias(AliasNamespaceName)]
        public string Namespace { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, Position = 2, HelpMessage = "EventHub Name")]
        [ValidateNotNullOrEmpty]
        [Alias(AliasEventHubName)]
        public string Name { get; set; }

        public override void ExecuteCmdlet()
        {
            // delete a EventHub 
            if(ShouldProcess(target:Name, action:string.Format(Resources.RemovingEventHub,Name,Namespace)))
            {
                WriteObject(Client.DeleteEventHub(ResourceGroupName, Namespace, Name));
            }            
        }
    }
}
