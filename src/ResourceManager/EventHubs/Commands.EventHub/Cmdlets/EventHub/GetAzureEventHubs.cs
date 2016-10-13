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

namespace Microsoft.Azure.Commands.EventHub.Cmdlets.EventHub
{
    [Cmdlet(VerbsCommon.Get, EventHubVerb), OutputType(typeof(List<EventHubAttributes>))]
    public class GetAzureEventHub : AzureEventHubsCmdletBase
    {
        [Parameter(Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            Position = 0,
            HelpMessage = "Resource Group Name.")]
        [ValidateNotNullOrEmpty]
         public string ResourceGroupName { get; set; }

        [Parameter(Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            Position = 1,
            HelpMessage = "Namespace Name.")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            Position = 2,
            HelpMessage = "EventHub Name.")]
        public string EventHubName { get; set; }

        public override void ExecuteCmdlet()
        {
            if (!string.IsNullOrEmpty(EventHubName))
            {
                // Get a EventHub
                var eventHub = Client.GetEventHub(ResourceGroupName, Name, EventHubName);
                WriteObject(eventHub);
            }
            else
            {
                // Get all EventHubs
                var eventHubsList = Client.ListAllEventHubs(ResourceGroupName, Name);
                WriteObject(eventHubsList.ToList(), true);
            }
        }
    }
}
