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
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using Microsoft.Azure.Management.FrontDoor;
using System.Linq;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
namespace Microsoft.Azure.Commands.FrontDoor.Cmdlets
{
    /// <summary>
    /// Defines the New-AzFrontDoor cmdlet.
    /// </summary>
    [Cmdlet("Remove", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "FrontDoorContent", SupportsShouldProcess = true), OutputType(typeof(bool))]
    public class RemoveAzureRmFrontDoorContent : AzureFrontDoorCmdletBase
    {
        /// <summary>
        /// The resource group name of the Front Door.
        /// </summary>
        [Parameter(Mandatory = true, HelpMessage = "The resource group name of the Front Door")]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        /// <summary>
        /// The Front Door name.
        /// </summary>
        [Parameter(Mandatory = true, HelpMessage = "Front Door name.")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        /// <summary>
        /// The path to the content to be purged.
        /// </summary>
        [Parameter(Mandatory = true, HelpMessage = "The paths to the content to be purged.")]
        public string[] ContentPath { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Return object (if specified).")]
        public SwitchParameter PassThru { get; set; }

        public override void ExecuteCmdlet()
        {
            if (ShouldProcess(Resources.FrontDoorTarget, string.Format(Resources.PurgeFrontDoor, Name)))
            {
                var parameters = new Microsoft.Azure.Management.FrontDoor.Models.PurgeParameters(ContentPath);
                FrontDoorManagementClient.Endpoints.PurgeContent(ResourceGroupName, Name, parameters);
                if (PassThru)
                {
                    WriteObject(true);
                }
            }
        }
    }
}
