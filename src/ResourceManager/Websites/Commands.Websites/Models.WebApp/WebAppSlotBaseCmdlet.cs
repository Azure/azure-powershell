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

using Microsoft.Azure.Commands.WebApps.Models;
using Microsoft.Azure.Commands.WebApps.Utilities;
using Microsoft.Azure.Management.WebSites.Models;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.WebApps
{
    public class WebAppSlotBaseCmdlet : WebAppBaseClientCmdLet
    {
        protected const string ParameterSet1Name = "S1";
        protected const string ParameterSet2Name = "S2";

        [Parameter(ParameterSetName = ParameterSet1Name, Position = 0, Mandatory = true, HelpMessage = "The name of the resource group.")]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(ParameterSetName = ParameterSet1Name, Position = 1, Mandatory = true, HelpMessage = "The name of the web app.", ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(ParameterSetName = ParameterSet1Name, Position = 2, Mandatory = true, HelpMessage = "The name of the web app slot.")]
        [ValidateNotNullOrEmpty]
        public string Slot { get; set; }

        [Parameter(ParameterSetName = ParameterSet2Name, Position = 0, Mandatory = true, HelpMessage = "The web app object", ValueFromPipeline = true)]
        [ValidateNotNullOrEmpty]
        public Site WebApp { get; set; }

        public override void ExecuteCmdlet()
        {
            switch (ParameterSetName)
            {
                case ParameterSet1Name:
                    string webAppName, slotName;
                    if (CmdletHelpers.TryParseAppAndSlotNames(Name, out webAppName, out slotName))
                    {
                        Name = webAppName;

                        // We have to choose between the slot name embedded in the name parameter or the slot parameter. 
                        // The choice for now is to prefer the embeeded slot name over the slot parameter. 
                        Slot = slotName;
                    }
                    break;
                case ParameterSet2Name:
                    string rg, name, slot;
                    CmdletHelpers.TryParseWebAppMetadataFromResourceId(WebApp.Id, out rg, out name, out slot);
                    if (string.IsNullOrEmpty(slot))
                    {
                        throw new ValidationMetadataException("Input object is a production web app. It should be deployment slot");
                    }

                    ResourceGroupName = rg;
                    Name = name;
                    Slot = slot;
                    break;
            }
        }
    }
}

