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
using Microsoft.Azure.Commands.FrontDoor.Helpers;
using Microsoft.Azure.Commands.FrontDoor.Models;
using Microsoft.Azure.Commands.FrontDoor.Properties;
using Microsoft.Azure.Management.FrontDoor;
using System.Linq;
using System.Management.Automation;
using System.Net;

namespace Microsoft.Azure.Commands.FrontDoor.Cmdlets
{
    /// <summary>
    /// Defines the Get-AzFrontDoor cmdlet.
    /// </summary>
    [Cmdlet("Get", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "FrontDoor"), OutputType(typeof(PSFrontDoor))]
    public class GetFrontDoor : AzureFrontDoorCmdletBase
    {
        /// <summary>
        /// The resource group name of the Front Door.
        /// </summary>
        [Parameter(Mandatory = false, HelpMessage = "The resource group name.")]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        /// <summary>
        /// The Front Door name.
        /// </summary>
        [Parameter(Mandatory = false, HelpMessage = "Front Door name.")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        public override void ExecuteCmdlet()
        {
            if (Name == null && ResourceGroupName == null)
            {
                // List by subscription.
                var frontDoors = FrontDoorManagementClient.FrontDoors.List().Select(p => p.ToPSFrontDoor());
                WriteObject(frontDoors, true);
            }
            else if (Name == null && ResourceGroupName != null)
            {
                // List by Resource Group name.
                var frontDoors =
                    FrontDoorManagementClient.FrontDoors.ListByResourceGroup(ResourceGroupName).Select(p => p.ToPSFrontDoor());
                WriteObject(frontDoors.ToArray(), true);
            }
            else if (Name != null && ResourceGroupName == null)
            {
                // Let's return all front Doors that match that name, or a single profile if there's just one.
                var frontDoors = FrontDoorManagementClient.FrontDoors.List().Select(p => p.ToPSFrontDoor()).Where(p => p.Name == Name);
                if (frontDoors.Count() == 1)
                {
                    WriteObject(frontDoors.First());
                }
                else
                {
                    WriteObject(frontDoors, true);
                }
            }
            else
            {
                try
                {
                    // Get by both Profile Name and Resource Group Name.
                    var frontDoor = FrontDoorManagementClient.FrontDoors.Get(ResourceGroupName, Name);
                    WriteObject(frontDoor.ToPSFrontDoor());
                }
                catch (Microsoft.Azure.Management.FrontDoor.Models.ErrorResponseException e)
                {
                    if (e.Response.StatusCode.Equals(HttpStatusCode.NotFound))
                    {
                        throw new PSArgumentException(string.Format(Resources.Error_FrontDoorNotFound,
                            Name,
                            ResourceGroupName));
                    }
                }
            }
        }
    }
}
