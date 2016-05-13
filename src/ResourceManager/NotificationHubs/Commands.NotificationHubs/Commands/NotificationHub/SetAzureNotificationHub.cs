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

using Microsoft.Azure.Commands.NotificationHubs.Models;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.NotificationHubs.Commands.NotificationHub
{

    [Cmdlet(VerbsCommon.Set, "AzureRmNotificationHub"), OutputType(typeof(NotificationHubAttributes))]
    public class SetAzureNotificationHub : AzureNotificationHubsCmdletBase
    {
        [Parameter(Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            Position = 0,
            HelpMessage = "The name of the resource group")]
        [ValidateNotNullOrEmpty]
        public string ResourceGroup { get; set; }

        [Parameter(Mandatory = true,
           ValueFromPipelineByPropertyName = true,
           Position = 1,
           HelpMessage = "Namespace Name.")]
        [ValidateNotNullOrEmpty]
        public string Namespace { get; set; }

        [Parameter(Mandatory = true,
            ParameterSetName = InputFileParameterSetName,
            Position = 2,
            HelpMessage = "File name containing a single NotificationHub definition.")]
        [ValidateNotNullOrEmpty]
        public string InputFile { get; set; }

        [Parameter(Mandatory = true,
            ParameterSetName = NotificationHubParameterSetName,
            Position = 2,
            HelpMessage = "NotificationHub definition.")]
        [ValidateNotNullOrEmpty]
        public NotificationHubAttributes NotificationHubObj { get; set; }

        public override void ExecuteCmdlet()
        {
            NotificationHubAttributes hub = null;
            if (!string.IsNullOrEmpty(InputFile))
            {
                hub = ParseInputFile<NotificationHubAttributes>(InputFile);
            }
            else
            {
                hub = NotificationHubObj;
            }

            var hubAttributes = Client.UpdateNotificationHub(ResourceGroup, Namespace, hub);
            WriteObject(hubAttributes);
        }
    }
}
