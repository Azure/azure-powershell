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

using System.Management.Automation;
using System.Management.Automation.Runspaces;
using Microsoft.Azure.Commands.WebApps.Models;
using Microsoft.Azure.Commands.WebApps.Utilities;

namespace Microsoft.Azure.Commands.WebApps
{
    public class WebAppSlotBaseCmdlet : WebAppBaseClientCmdLet
    {
        [Parameter(Position = 0, Mandatory = true, HelpMessage = "The name of the resource group.")]
        [ValidateNotNullOrEmpty]
        [Alias("ResourceGroup", "RG")]
        public string ResourceGroupName { get; set; }

        [Parameter(Position = 1, Mandatory = true, HelpMessage = "The name of the production web app.",   ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        [Alias("WebSiteName")]
        public string Name { get; set; }

        [Parameter(Position = 2, Mandatory = false, HelpMessage = "The name of the web app slot.")]
        [ValidateNotNullOrEmpty]
        public string Slot { get; set; }

        protected override void ProcessRecord()
        {
            string webAppName, slotName;
            if (WebsitesClient.TryParseAppAndSlotNames(Name, out webAppName, out slotName))
            {
                Name = webAppName;

                // We have to choose between the slot name embedded in the name parameter or the slot parameter. 
                // The choice for now is to prefer the embeeded slot name over the slot parameter. 
                Slot = slotName;
            }
        }
    }
}

