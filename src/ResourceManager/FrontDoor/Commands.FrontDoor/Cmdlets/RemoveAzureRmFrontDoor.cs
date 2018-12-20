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

using System;
using System.Collections;
using System.Management.Automation;
using System.Net;
using Microsoft.Azure.Commands.FrontDoor.Common;
using Microsoft.Azure.Commands.FrontDoor.Helpers;
using Microsoft.Azure.Commands.FrontDoor.Models;
using Microsoft.Azure.Commands.FrontDoor.Properties;
using Microsoft.Azure.Management.FrontDoor;
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;
using System.Linq;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Commands.ResourceManager;

namespace Microsoft.Azure.Commands.FrontDoor.Cmdlets
{
    /// <summary>
    /// Defines the Remove-AzFrontDoor cmdlet.
    /// </summary>
    [Cmdlet("Remove", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "FrontDoor", SupportsShouldProcess = true, DefaultParameterSetName = FieldsParameterSet), OutputType(typeof(bool))]
    public class RemoveAzureRmFrontDoor : AzureFrontDoorCmdletBase
    {
        [Parameter(Mandatory = true, ParameterSetName = FieldsParameterSet, HelpMessage = "The resource group to which the Front Door belongs.")]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = FieldsParameterSet, HelpMessage = "The name of the Front Door to delete.")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = ObjectParameterSet, ValueFromPipeline = true, HelpMessage = "The Front Door object to delete.")]
        [ValidateNotNullOrEmpty]
        public PSFrontDoor InputObject { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = ResourceIdParameterSet, ValueFromPipelineByPropertyName = true, HelpMessage = "Resource Id of the Front Door to delete")]
        [ValidateNotNullOrEmpty]
        public string ResourceId { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Return object (if specified).")]
        public SwitchParameter PassThru { get; set; }

        public override void ExecuteCmdlet()
        {
            if (ParameterSetName == ObjectParameterSet)
            {
                ResourceIdentifier identifier = new ResourceIdentifier(InputObject.Id);
                ResourceGroupName = identifier.ResourceGroupName;
                Name = InputObject.Name;
            }
            else if (ParameterSetName == ResourceIdParameterSet)
            {
                ResourceIdentifier identifier = new ResourceIdentifier(ResourceId);
                ResourceGroupName = identifier.ResourceGroupName;
                Name = InputObject.Name;
            }


            var existingProfile = FrontDoorManagementClient.FrontDoors.ListByResourceGroup(ResourceGroupName)
                .FirstOrDefault(fd => fd.Name.ToLower() == Name.ToLower());
                

            if (existingProfile == null)
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
