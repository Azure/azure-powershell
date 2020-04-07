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

using Microsoft.Azure.Commands.FrontDoor.Common;
using Microsoft.Azure.Commands.FrontDoor.Properties;
using Microsoft.Azure.Management.FrontDoor;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.FrontDoor.Cmdlets
{
    [Cmdlet("Remove", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "FrontDoor" + "RulesEngine"), OutputType(typeof(bool))]
    public class RemoveFrontDoorRulesEngine : AzureFrontDoorCmdletBase
    {
        /// <summary>
        /// The resource group name of the Front Door.
        /// </summary>
        [Parameter(Mandatory = true, HelpMessage = "The resource group name that the Front Door will be created in.")]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        /// <summary>
        /// The Front Door name.
        /// </summary>
        [Parameter(Mandatory = true, HelpMessage = "Front Door name.")]
        [ValidateNotNullOrEmpty]
        public string FrontDoorName { get; set; }

        /// <summary>
        /// The rules engine name.
        /// </summary>
        [Parameter(Mandatory = false, HelpMessage = "Rules engine name.")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Return object (if specified).")]
        public SwitchParameter PassThru { get; set; }

        public override void ExecuteCmdlet()
        {
            var existingRulesEngine = FrontDoorManagementClient.RulesEngines.Get(ResourceGroupName, FrontDoorName, Name);

            if (existingRulesEngine == null)
            {
                throw new PSArgumentException(string.Format(Resources.Error_DeleteNonExistingFrontDoor,
                    Name,
                    ResourceGroupName));
            }

            if (ShouldProcess(Resources.FrontDoorTarget, string.Format(Resources.RemoveFrontDoor, Name)))
            {
                FrontDoorManagementClient.FrontDoors.Delete(ResourceGroupName, Name);
                if (PassThru)
                {
                    WriteObject(true);
                }
            }
        }
    }
}
