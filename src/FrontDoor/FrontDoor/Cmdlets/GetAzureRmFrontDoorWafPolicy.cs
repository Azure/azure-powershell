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
using System.Linq;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;

namespace Microsoft.Azure.Commands.FrontDoor.Cmdlets
{
    /// <summary>
    /// Defines the Get-AzFrontDoorFireWallPolicy cmdlet.
    /// </summary>
    [Cmdlet("Get", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "FrontDoorWafPolicy"), OutputType(typeof(PSPolicy))]
    public class GetAzureRmFrontDoorWafPolicy : AzureFrontDoorCmdletBase
    {
        /// <summary>
        /// The resource group name.
        /// </summary>
        [Parameter(Mandatory = true, HelpMessage = "The resource group name.")]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        /// <summary>
        /// The FireWallPolicy name.
        /// </summary>
        [Parameter(Mandatory = false, HelpMessage = "FireWallPolicy name.")]
        public string Name { get; set; }

        public override void ExecuteCmdlet()
        {
            if (Name == null)
            {
                // List by Resource Group name.
                var Policies = FrontDoorManagementClient.Policies.List(ResourceGroupName).Select(p => p.ToPSPolicy());
                WriteObject(Policies.ToArray(), true);
            }
            else
            {
                try
                {
                    // Get by both Profile Name and Resource Group Name.
                    var policy = FrontDoorManagementClient.Policies.Get(ResourceGroupName, Name);
                    WriteObject(policy.ToPSPolicy());
                }
                catch (Microsoft.Azure.Management.FrontDoor.Models.ErrorResponseException e)
                {
                    if (e.Response.StatusCode.Equals(HttpStatusCode.NotFound))
                    {
                        throw new PSArgumentException(string.Format(
                            Resources.Error_WebApplicationFirewallPolicyNotFound,
                            Name,
                            ResourceGroupName));
                    }
                }
            }
        }
    }
}
