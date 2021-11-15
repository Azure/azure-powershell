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

using Microsoft.Azure.Commands.Synapse.Common;
using Microsoft.Azure.Commands.Synapse.Models;
using Microsoft.Azure.Management.Synapse.Models;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Synapse.Commands
{
    [Cmdlet(VerbsCommon.New, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + SynapseConstants.SynapsePrefix + SynapseConstants.ManagedVirtualNetworkConfig)]
    [OutputType(typeof(PSManagedVirtualNetworkSettings))]
    public class NewAzureSynapseManagedVirtualNetworkConfig : SynapseManagementCmdletBase
    {
        [Parameter(Mandatory = false, HelpMessage = HelpMessages.PreventDataExfiltration)]
        public SwitchParameter PreventDataExfiltration { get; set; }

        [Parameter(Mandatory = false, HelpMessage = HelpMessages.AllowedAadTenantIdsForLinking)]
        public string[] AllowedAadTenantIdsForLinking { get; set; }

        public override void ExecuteCmdlet()
        {
            var settings = new ManagedVirtualNetworkSettings
            {
                PreventDataExfiltration = this.PreventDataExfiltration,
                AllowedAadTenantIdsForLinking = this.AllowedAadTenantIdsForLinking
            };

            WriteObject(new PSManagedVirtualNetworkSettings(settings));
        }
    }
}
