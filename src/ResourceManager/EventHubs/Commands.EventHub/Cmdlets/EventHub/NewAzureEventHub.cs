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
using Microsoft.Azure.Management.EventHub.Models;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.EventHub.Cmdlets.EventHub
{

    [Cmdlet(VerbsCommon.New, EventHubVerb), OutputType(typeof(EventHubAttributes))]
    public class NewAzureEventHub : AzureEventHubsCmdletBase
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

        [Parameter(Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            Position = 1,
            HelpMessage = "Eventhub Name.")]
        [ValidateNotNullOrEmpty]
        public string EventhubName { get; set; }

        [Parameter(Mandatory = true,
            ParameterSetName = InputFileParameterSetName,
            Position = 3,
            HelpMessage = "File name containing a single EventHub definition.")]
        [ValidateNotNullOrEmpty]
        public string InputFile { get; set; }

        [Parameter(Mandatory = true,
            ParameterSetName = EventHubParameterSetName,
            Position = 3,
            HelpMessage = "EventHub definition.")]
        [ValidateNotNullOrEmpty]
        public EventHubAttributes EventHubObj { get; set; }

        public override void ExecuteCmdlet()
        {
            EventHubAttributes eventHub = null;
            if (!string.IsNullOrEmpty(InputFile))
            {
                eventHub = ParseInputFile<EventHubAttributes>(InputFile);
            }
            else
            {
                eventHub = EventHubObj;
            }

            var eventHubAttributes = Client.CreateOrUpdateEventHub(ResourceGroupName, Name, eventHub.Name, eventHub);
            WriteObject(eventHubAttributes);
        }
    }
}
